using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.Search;
using Pyro.Common.Tools.Headers;
using Pyro.Common.Tools;
using Hl7.Fhir.Utility;
using Hl7.Fhir.Model;
using Pyro.Common.Extentions;
using Pyro.Common.Exceptions;
using Pyro.Common.CompositionRoot;
using Pyro.Common.RequestMetadata;

namespace Pyro.Common.Service
{
  public class BundleTransactionService : IBundleTransactionService
  {
    private readonly IResourceServices IResourceServices;    
    private readonly IRequestHeaderFactory IRequestHeaderFactory;
    private readonly IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory;
    private readonly IPyroFhirUriFactory IPyroFhirUriFactory;
    private readonly IPyroRequestUriFactory IPyroRequestUriFactory;
    private readonly ISearchParameterGenericFactory ISearchParameterGenericFactory;
    private readonly IRequestMetaFactory IRequestMetaFactory;

    private IPyroRequestUri _RequestUri { get; set; }
    private IRequestHeader _RequestHeader { get; set; }
    private IResourceServiceOutcome _ServiceOperationOutcome;
    private Dictionary<string, string> OldNewResourceReferanceMap;

    public BundleTransactionService(IResourceServices IResourceServices, IRequestHeaderFactory IRequestHeaderFactory, IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory, ISearchParameterGenericFactory ISearchParameterGenericFactory, IPyroFhirUriFactory IPyroFhirUriFactory, IPyroRequestUriFactory IPyroRequestUriFactory, IRequestMetaFactory IRequestMetaFactory)
    {
      this.IResourceServices = IResourceServices;      
      this.IRequestHeaderFactory = IRequestHeaderFactory;
      this.IResourceServiceOutcomeFactory = IResourceServiceOutcomeFactory;
      this.IPyroFhirUriFactory = IPyroFhirUriFactory;
      this.ISearchParameterGenericFactory = ISearchParameterGenericFactory;
      this.IPyroRequestUriFactory = IPyroRequestUriFactory;
      this.IRequestMetaFactory = IRequestMetaFactory;
    }

    public IResourceServiceOutcome Transact(Resource Resource, IRequestMeta RequestMeta)
    {
      if (IResourceServices == null)      
        throw new ArgumentNullException("IResourceServices can not be null.");      
      if (Resource == null)      
        throw new ArgumentNullException("Resource can not be null.");      
      if (RequestMeta == null)      
        throw new ArgumentNullException("RequestMeta can not be null.");
      
      _RequestHeader = RequestMeta.RequestHeader ?? throw new ArgumentNullException("RequestHeaders can not be null.");
      _RequestUri = RequestMeta.PyroRequestUri ?? throw new ArgumentNullException("RequestUri can not be null.");

      _ServiceOperationOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
      _ServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;
      Bundle bundle = Resource as Bundle;

      if (bundle == null)
      {
        var Message = $"The FHIR server's service root endpoint can only accept 'Bundle' resources. Resource received was: {Resource.ResourceType.ToString()}";
        var OpOutcome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Invalid, Message);
        _ServiceOperationOutcome.ResourceResult = OpOutcome;
        _ServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.Forbidden;
        _ServiceOperationOutcome.OperationType = Enum.RestEnum.CrudOperationType.Create;
        return _ServiceOperationOutcome;
      }
      else if (bundle.Type != Bundle.BundleType.Transaction || (bundle.Type != Bundle.BundleType.Transaction && bundle.Type != Bundle.BundleType.Batch))
      {
        var Message = $"The FHIR server's service root endpoint can only accept Bundle resources of Bundle.type = 'Transaction' or Bundle.type = 'Batch'. Type found was {bundle.Type.ToString()}";
        var OpOutcome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Invalid, Message);
        _ServiceOperationOutcome.ResourceResult = OpOutcome;
        _ServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.Forbidden;
        _ServiceOperationOutcome.OperationType = Enum.RestEnum.CrudOperationType.Create;
        return _ServiceOperationOutcome;
      }
      else
      {

        bundle.Type = Bundle.BundleType.TransactionResponse;
        bundle.Id = Guid.NewGuid().ToString();
        if (bundle.Meta == null)
          bundle.Meta = new Meta();
        bundle.Meta.LastUpdated = DateTimeOffset.Now;


        //FHIR Spec: http://build.fhir.org/bundle.html#transaction
        //  If there is no request element, then there SHALL be a resource and the server must infer 
        //  whether this is a create or an update from the resource identity supplied.
        //  NO Request Processing        
        foreach (var NoRequestEntry in bundle.Entry.Where(x => x.Request == null || !x.Request.Method.HasValue))
        {
          NoRequestEntry.Request = GenerateRequestComponentForEntry(NoRequestEntry);
        }

        //All entries with a Request, should be all at this point
        var EntryWithRequestList = bundle.Entry.Where(x => x.Request != null && x.Request.Method.HasValue);
        var EntryWithResourceAndRequestList = EntryWithRequestList.Where(x => x.Resource != null);

        var DeleteEntries = EntryWithRequestList.Where(x => x.Request.Method == Bundle.HTTPVerb.DELETE);
        var POSTEntries = EntryWithResourceAndRequestList.Where(x => x.Request.Method == Bundle.HTTPVerb.POST);
        var PUTEntries = EntryWithResourceAndRequestList.Where(x => x.Request.Method == Bundle.HTTPVerb.PUT);
        var GETEntries = EntryWithRequestList.Where(x => x.Request.Method == Bundle.HTTPVerb.GET);

        try
        {
          //DELETE Processing
          for (int i = 0; i < DeleteEntries.Count(); i++)
          {
            if (!DeleteProcessing(DeleteEntries.ElementAt(i), i))
            {
              return _ServiceOperationOutcome;
            }
          }
          
          //Assign new id's for POSTs and then update all POST and PUT entrie referances          
          AssignResourceIdsAndUpdateReferances(POSTEntries, PUTEntries);

          //POST Processing        
          for (int i = 0; i < POSTEntries.Count(); i++)
          {
            if (!PostProcessing(POSTEntries.ElementAt(i), i))
            {
              _ServiceOperationOutcome.SuccessfulTransaction = false;
              return _ServiceOperationOutcome;
            }
          }

          //PUT Processing        
          for (int i = 0; i < PUTEntries.Count(); i++)
          {
            if (!PutProcessing(PUTEntries.ElementAt(i), i))
            {
              _ServiceOperationOutcome.SuccessfulTransaction = false;
              return _ServiceOperationOutcome;
            }
          }

          //GET Processing        
          for (int i = 0; i < GETEntries.Count(); i++)
          {
            if (!GetProcessing(GETEntries.ElementAt(i), i))
            {
              _ServiceOperationOutcome.SuccessfulTransaction = false;
              return _ServiceOperationOutcome;
            }
          }
          
          _ServiceOperationOutcome.ResourceResult = bundle;
          _ServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;
          _ServiceOperationOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
          _ServiceOperationOutcome.SuccessfulTransaction = true;
        }
        catch (Exception Exec)
        {
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError, FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }

      return _ServiceOperationOutcome;
    }

    private bool DeleteProcessing(Bundle.EntryComponent DeleteEntry, int DeleteEntryIndex)
    {
      IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(DeleteEntry.Request);
      RequestMeta.RequestHeader.Prefer = _RequestHeader.Prefer;      
      IResourceServiceOutcome ResourceServiceOutcome = null;
      
      if (RequestMeta.SearchParameterGeneric.ParameterList.Count > 0)
      {
        ResourceServiceOutcome = IResourceServices.ConditionalDelete(RequestMeta);
      }
      else
      {
        ResourceServiceOutcome = IResourceServices.Delete(RequestMeta.PyroRequestUri.FhirRequestUri.ResourceId, RequestMeta);
      }

      if (ResourceServiceOutcome.SuccessfulTransaction)
      {
        DeleteEntry.Response = new Bundle.ResponseComponent();
        DeleteEntry.Response.Status = FormatHTTPStatusCodeAsString(ResourceServiceOutcome.HttpStatusCode);
        DeleteEntry.FullUrl = null;
        if (ResourceServiceOutcome.ResourceResult != null)
        {
          if (ResourceServiceOutcome.ResourceResult.ResourceType == ResourceType.OperationOutcome)
          {
            DeleteEntry.Response.Outcome = ResourceServiceOutcome.ResourceResult;
          }
          else
          {
            DeleteEntry.Resource = ResourceServiceOutcome.ResourceResult;
          }
        }
        if (ResourceServiceOutcome.LastModified != null && ResourceServiceOutcome.ResourceVersionNumber != null)
        {
          DeleteEntry.Response.Etag = HttpHeaderSupport.GetEntityTagHeaderValueFromVersion(ResourceServiceOutcome.ResourceVersionNumber).ToString();
          DeleteEntry.Response.LastModified = ResourceServiceOutcome.LastModified;
        }
        return true;
      }
      else
      {
        if (ResourceServiceOutcome.ResourceResult != null && ResourceServiceOutcome.ResourceResult is OperationOutcome Op)
        {
          IdentifieBatchEntityToClient(Op, DeleteEntry.FullUrl, "DELETE", DeleteEntryIndex);
        }
        _ServiceOperationOutcome = ResourceServiceOutcome;
        return false;
      }
    }
    private bool PostProcessing(Bundle.EntryComponent PostEntry, int PostEntryIndex)
    {
    IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(PostEntry.Request);
      if (RequestMeta.PyroRequestUri.FhirRequestUri.IsOperation)
      {
        var Message = $"The FHIR server does not support the use of Operations within Transaction Bundles, found Operation request type of : '{RequestMeta.PyroRequestUri.FhirRequestUri.OperationName}'.";
        var OpOutcome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Invalid, Message);
        _ServiceOperationOutcome.ResourceResult = OpOutcome;
        _ServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.Forbidden;
        _ServiceOperationOutcome.OperationType = Enum.RestEnum.CrudOperationType.Create;
        return false;
      }

      IPyroFhirUri ResourceIdToForce = IPyroFhirUriFactory.CreateFhirRequestUri();
      if (String.IsNullOrEmpty(PostEntry.FullUrl))
      {
        //Assgin a new GUID as there is not FullURL GUID to lookup from refererancing 
        ResourceIdToForce.Parse($"{PostEntry.Resource.TypeName}/{Common.Tools.FhirGuid.FhirGuid.NewFhirGuid()}");
      }
      else
      {
        //Use the new Resource id that we assigned when updating all referances by looking it up in the GetUUIDfromFullURL dic
        ResourceIdToForce.Parse(OldNewResourceReferanceMap[GetUUIDfromFullURL(PostEntry.FullUrl)]);
      }
      //Remove the Resource Id in the resource as this is a POST and no id should be present in the resource, we do force the new id given this is a transaction operation 
      if (!String.IsNullOrEmpty(PostEntry.Resource.Id))
        PostEntry.Resource.Id = String.Empty;
      
      IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.Post(PostEntry.Resource, RequestMeta, ResourceIdToForce.ResourceId);

      if (ResourceServiceOutcome.SuccessfulTransaction)
      {
        PostEntry.FullUrl = CreateFullUrl(ResourceServiceOutcome);
        PostEntry.Response = new Bundle.ResponseComponent();
        PostEntry.Response.Status = FormatHTTPStatusCodeAsString(ResourceServiceOutcome.HttpStatusCode);

        if (ResourceServiceOutcome.ResourceResult != null)
        {
          if (ResourceServiceOutcome.ResourceResult.ResourceType == ResourceType.OperationOutcome)
          {
            PostEntry.Response.Outcome = ResourceServiceOutcome.ResourceResult;
          }
          else
          {
            PostEntry.Resource = ResourceServiceOutcome.ResourceResult;
          }
        }
        if (ResourceServiceOutcome.LastModified != null)
        {
          PostEntry.Response.Etag = HttpHeaderSupport.GetEntityTagHeaderValueFromVersion(ResourceServiceOutcome.ResourceVersionNumber).ToString();
          PostEntry.Response.LastModified = ResourceServiceOutcome.LastModified;
        }
        PostEntry.Response.Status = $"{((int)ResourceServiceOutcome.HttpStatusCode).ToString()} {ResourceServiceOutcome.HttpStatusCode.ToString()}";
        PostEntry.Response.Location = FormatResponseLocation(ResourceServiceOutcome.RequestUri.OriginalString, ResourceServiceOutcome.FhirResourceId, ResourceServiceOutcome.ResourceVersionNumber);
        return true;
      }
      else
      {
        if (ResourceServiceOutcome.ResourceResult != null && ResourceServiceOutcome.ResourceResult is OperationOutcome Op)
        {
          IdentifieBatchEntityToClient(Op, PostEntry.FullUrl, "POST", PostEntryIndex);
        }
        _ServiceOperationOutcome = ResourceServiceOutcome;
        return false;
      }
    }
    private bool PutProcessing(Bundle.EntryComponent PutEntry, int PutEntryIndex)
    {      
      IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(PutEntry.Request);
      RequestMeta.RequestHeader.Prefer = _RequestHeader.Prefer;      
      IResourceServiceOutcome ResourceServiceOutcome = null;
      if (RequestMeta.SearchParameterGeneric.ParameterList.Count > 0)
      {
        ResourceServiceOutcome = IResourceServices.ConditionalPut(PutEntry.Resource, RequestMeta);
      }
      else
      {
        ResourceServiceOutcome = IResourceServices.Put(RequestMeta.PyroRequestUri.FhirRequestUri.ResourceId, PutEntry.Resource, RequestMeta);
      }

      if (ResourceServiceOutcome.SuccessfulTransaction)
      {
        PutEntry.FullUrl = CreateFullUrl(ResourceServiceOutcome);
        PutEntry.Response = new Bundle.ResponseComponent();
        PutEntry.Response.Status = FormatHTTPStatusCodeAsString(ResourceServiceOutcome.HttpStatusCode);

        if (ResourceServiceOutcome.ResourceResult != null)
        {
          if (ResourceServiceOutcome.ResourceResult.ResourceType == ResourceType.OperationOutcome)
          {
            PutEntry.Response.Outcome = ResourceServiceOutcome.ResourceResult;
          }
          else
          {
            PutEntry.Resource = ResourceServiceOutcome.ResourceResult;
          }
        }
        if (ResourceServiceOutcome.LastModified != null)
        {
          PutEntry.Response.Etag = HttpHeaderSupport.GetEntityTagHeaderValueFromVersion(ResourceServiceOutcome.ResourceVersionNumber).ToString();
          PutEntry.Response.LastModified = ResourceServiceOutcome.LastModified;
          PutEntry.Response.Location = FormatResponseLocation(RequestMeta.PyroRequestUri.FhirRequestUri.OriginalString, ResourceServiceOutcome.FhirResourceId, ResourceServiceOutcome.ResourceVersionNumber);
        }
        return true;
      }
      else
      {
        if (ResourceServiceOutcome.ResourceResult != null && ResourceServiceOutcome.ResourceResult is OperationOutcome Op)
        {
          IdentifieBatchEntityToClient(Op, PutEntry.FullUrl, "PUT", PutEntryIndex);
        }
        _ServiceOperationOutcome = ResourceServiceOutcome;
        return false;
      }
    }   

    private bool GetProcessing(Bundle.EntryComponent GetEntry, int GetEntryIndex)
    {
      IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta();
      RequestMeta.Set(GetEntry.Request);
      RequestMeta.RequestHeader.Prefer = _RequestHeader.Prefer;

      IResourceServiceOutcome ResourceServiceOutcome = null;                  
      if (RequestMeta.SearchParameterGeneric.ParameterList.Count > 0)
      {
        ResourceServiceOutcome = IResourceServices.GetSearch(RequestMeta);
      }
      else
      {
        ResourceServiceOutcome = IResourceServices.GetRead(RequestMeta.PyroRequestUri.FhirRequestUri.ResourceId, RequestMeta);
      }

      if (ResourceServiceOutcome.SuccessfulTransaction)
      {
        GetEntry.FullUrl = CreateFullUrl(ResourceServiceOutcome);
        GetEntry.Response = new Bundle.ResponseComponent();
        GetEntry.Response.Status = FormatHTTPStatusCodeAsString(ResourceServiceOutcome.HttpStatusCode);

        if (ResourceServiceOutcome.ResourceResult != null)
        {
          if (ResourceServiceOutcome.ResourceResult.ResourceType == ResourceType.OperationOutcome)
          {
            GetEntry.Response.Outcome = ResourceServiceOutcome.ResourceResult;
          }
          else
          {
            GetEntry.Resource = ResourceServiceOutcome.ResourceResult;
          }
        }
        if (ResourceServiceOutcome.LastModified.HasValue)
        {
          GetEntry.Response.Etag = HttpHeaderSupport.GetEntityTagHeaderValueFromVersion(ResourceServiceOutcome.ResourceVersionNumber).ToString();
          if (ResourceServiceOutcome.IsDeleted.HasValue && !ResourceServiceOutcome.IsDeleted.Value)
            GetEntry.Response.LastModified = ResourceServiceOutcome.LastModified;
          GetEntry.Response.Location = FormatResponseLocation(RequestMeta.PyroRequestUri.FhirRequestUri.OriginalString, ResourceServiceOutcome.FhirResourceId, ResourceServiceOutcome.ResourceVersionNumber);
        }
        return true;
      }
      else
      {
        if (ResourceServiceOutcome.ResourceResult != null && ResourceServiceOutcome.ResourceResult is OperationOutcome Op)
        {
          IdentifieBatchEntityToClient(Op, GetEntry.FullUrl, "GET", GetEntryIndex);
        }
        _ServiceOperationOutcome = ResourceServiceOutcome;
        return false;
      }
    }

    private string ConstructRequestUrl(Bundle.EntryComponent Entry)
    {
      //The FHIR spec examples show the Request.url without a leading slash '/', yet the Synthia data adds a leading slash.
      //We remove it here is it is seen.
      string RequestUrl = String.Empty;
      if (Entry.Request.Url.StartsWith(@"/"))
      {
        RequestUrl = Entry.Request.Url.Substring(1, Entry.Request.Url.Length - 1);
      }
      else
      {
        RequestUrl = Entry.Request.Url;
      }
      return $"{_RequestUri.FhirRequestUri.UriPrimaryServiceRoot.OriginalString}/{RequestUrl}";      
    }

    private string CreateFullUrl(IResourceServiceOutcome ResourceServiceOutcome)
    {
      //Get Search results will have either a bundle or no resource and do not require FullURLs
      if (ResourceServiceOutcome.ResourceResult != null && ResourceServiceOutcome.ResourceResult.ResourceType != ResourceType.Bundle)
      {
        return $"{_RequestUri.FhirRequestUri.UriPrimaryServiceRoot.OriginalString}/{ResourceServiceOutcome.ResourceResult.TypeName}/{ResourceServiceOutcome.FhirResourceId}";
        //return $"{ResourceServiceOutcome.RequestUri.UriPrimaryServiceRoot.Scheme}://{ResourceServiceOutcome.ServiceRootUri.OriginalString}/{ResourceServiceOutcome.ResourceResult.TypeName}/{ResourceServiceOutcome.FhirResourceId}";
      }
      return null;
    }

    private void IdentifieBatchEntityToClient(OperationOutcome op, string FullURL, string OperationType, int EntityIndexInType)
    {
      EntityIndexInType = EntityIndexInType + 1;
      string Message = string.Empty;
      if (String.IsNullOrWhiteSpace(FullURL))
      {
        Message = $"The Issue/s were found in the {EntityIndexInType.Ordinal()} {OperationType} bundel entry";
      }
      else
      {
        Message = $"The Issue/s were found in the bundel entry identified by the FullURL: {FullURL}";
      }      
      OperationOutcome NewOp = FhirOperationOutcomeSupport.Append(OperationOutcome.IssueSeverity.Information, OperationOutcome.IssueType.Informational, Message, op);
    }

    private string FormatResponseLocation(string originalString, string FhirResourceId, string ResourceVersionNumber)
    {
      return $"{originalString}/{FhirResourceId}/_history/{ResourceVersionNumber}";
    }

    private void AssignResourceIdsAndUpdateReferances(IEnumerable<Bundle.EntryComponent> PostEntryList, IEnumerable<Bundle.EntryComponent> PutEntryList)
    {
      OldNewResourceReferanceMap = new Dictionary<string, string>();
      //First assign a new GUID id for all FullUrls
      foreach (var PostEntry in PostEntryList)
      {
        if (!string.IsNullOrEmpty(PostEntry.FullUrl))
        {
          string NewId = Guid.NewGuid().ToString();
          string ResourceName = PostEntry.Resource.ResourceType.ToString();
          string FullUrlUUID = GetUUIDfromFullURL(PostEntry.FullUrl);
          OldNewResourceReferanceMap.Add(FullUrlUUID, $"{ResourceName}/{NewId}");
        }       
      }

      //Then roll through all POST and PUT entries updating referances     
      IEnumerable<Bundle.EntryComponent> PostAndPutList = PostEntryList.Concat(PutEntryList);
      foreach (var PostPutItem in PostAndPutList)
      {
        if (PostPutItem.Resource is DomainResource dr)
        {
          //Update all <a href="" & <img src=""
          dr.Text.UpdateAllReferances(OldNewResourceReferanceMap);
        }
      }

      List<ResourceReference> RefList = PostAndPutList.AllReferences();
      foreach (var resRef in RefList.Where(rr => !string.IsNullOrEmpty(rr.Reference)))
      {
        // TODO: If this is an identifier reference, then we must resolve the reference
        // Otherwise these are just normal references
        string UUID = resRef.Reference.Split(':')[resRef.Reference.Split(':').Length - 1];
        if (OldNewResourceReferanceMap.ContainsKey(UUID))
        {
          resRef.Reference = OldNewResourceReferanceMap[UUID];
        }
      }
    }
    private string GetUUIDfromFullURL(string FullURL)
    {
      string Result = FullURL;
      if (FullURL.Contains(":"))
      {
        var FullURLUUIDSplit = FullURL.Split(':');
        if (FullURLUUIDSplit.Length == 3)
        {
          Result = FullURLUUIDSplit[2];
        }
        else if (FullURLUUIDSplit.Length == 2)
        {
          Result = FullURLUUIDSplit[1];
        }
      }
      return Result;
    }
    private string FormatHTTPStatusCodeAsString(System.Net.HttpStatusCode HttpStatusCode)
    {
      return $"{((int)HttpStatusCode).ToString()} {HttpStatusCode.ToString()}";
    }

    private Bundle.RequestComponent GenerateRequestComponentForEntry(Bundle.EntryComponent Entry)
    {
      var RequestComponent = new Bundle.RequestComponent();
      if (!string.IsNullOrWhiteSpace(Entry.Resource.Id))
      {
        //Perform a PUT (Update)
        RequestComponent.Method = Bundle.HTTPVerb.PUT;
        RequestComponent.Url = $"{Entry.Resource.TypeName}/{Entry.Resource.Id}";
      }
      else
      {
        //Perform a POST (Create)
        RequestComponent.Method = Bundle.HTTPVerb.POST;
        RequestComponent.Url = $"{Entry.Resource.TypeName}";
      }
      return RequestComponent;
    }
  }
}

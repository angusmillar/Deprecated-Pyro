using System;
using System.Collections.Generic;
using System.Linq;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.Tools.Headers;
using Pyro.Common.Tools;
using Hl7.Fhir.Model;
using Pyro.Common.Extentions;
using Pyro.Common.Exceptions;
using Pyro.Common.CompositionRoot;
using Pyro.Common.RequestMetadata;
using Pyro.Common.Service.ResourceService;
using Hl7.Fhir.Utility;
using Pyro.Common.SearchIndexer.Indexer;
using Pyro.Common.Service.SearchParameters;

namespace Pyro.Common.FhirOperation.BundleTransaction
{
  public class BundleTransactionOperation : IBundleTransactionOperation
  {
    private readonly IResourceServices IResourceServices;
    private readonly IRequestHeaderFactory IRequestHeaderFactory;
    private readonly IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory;
    private readonly IPyroFhirUriFactory IPyroFhirUriFactory;
    private readonly IPyroRequestUriFactory IPyroRequestUriFactory;
    private readonly ISearchParameterGenericFactory ISearchParameterGenericFactory;
    private readonly IRequestMetaFactory IRequestMetaFactory;
    private readonly IInMemoryResourceSearch IInMemoryResourceSearch;
    private readonly ISearchParameterServiceFactory ISearchParameterServiceFactory;

    private IPyroRequestUri _RequestUri { get; set; }
    private IRequestHeader _RequestHeader { get; set; }
    private IResourceServiceOutcome _ServiceOperationOutcome;
    private Dictionary<string, string> _OldNewResourceReferanceMap;

    public BundleTransactionOperation(IResourceServices IResourceServices, IRequestHeaderFactory IRequestHeaderFactory, IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory, ISearchParameterGenericFactory ISearchParameterGenericFactory, IPyroFhirUriFactory IPyroFhirUriFactory, IPyroRequestUriFactory IPyroRequestUriFactory, IRequestMetaFactory IRequestMetaFactory, IInMemoryResourceSearch IInMemoryResourceSearch, ISearchParameterServiceFactory ISearchParameterServiceFactory)
    {
      this.IResourceServices = IResourceServices;
      this.IRequestHeaderFactory = IRequestHeaderFactory;
      this.IResourceServiceOutcomeFactory = IResourceServiceOutcomeFactory;
      this.IPyroFhirUriFactory = IPyroFhirUriFactory;
      this.ISearchParameterGenericFactory = ISearchParameterGenericFactory;
      this.IPyroRequestUriFactory = IPyroRequestUriFactory;
      this.IRequestMetaFactory = IRequestMetaFactory;
      this.IInMemoryResourceSearch = IInMemoryResourceSearch;

      this.ISearchParameterServiceFactory = ISearchParameterServiceFactory;
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
      else if (bundle.Type != Bundle.BundleType.Transaction)
      {
        var Message = $"The FHIR server's service root endpoint can only accept Bundle resources of Bundle.type = 'Transaction'. Type found was {bundle.Type.ToString()}";
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
          //below sets the request element to POST or PUT based on the the resource having a FhirID or not
          //from here forward they can be treated like all other entries
          NoRequestEntry.Request = GenerateRequestComponentForEntry(NoRequestEntry);
        }

        //1. Get all POST & PUT entryies that have an IfNoneExsist entry request property
        List<Bundle.EntryComponent> POSTAndPUTIfNoneExsitsList = bundle.Entry.Where(x => (x.Request.Method == Bundle.HTTPVerb.POST || x.Request.Method == Bundle.HTTPVerb.PUT) && !string.IsNullOrWhiteSpace(x.Request.IfNoneExist)).ToList();
        List<IfNoneExistsMapItem> IfNoneExistsMapItemList = new List<IfNoneExistsMapItem>(); ;
        if (POSTAndPUTIfNoneExsitsList != null)
        {          
          foreach (var Entry in POSTAndPUTIfNoneExsitsList)
          {
            var IfNoneExistsMapItem = new IfNoneExistsMapItem();
            IfNoneExistsMapItem.LoadEntry(Entry);
            IfNoneExistsMapItemList.Add(IfNoneExistsMapItem);
          }
          //2. Lookup each in the database to see if they exists
          //   if True this has updated the FhirIdMap as required or if false it will have updated
          //   the _ServiceOperationOutcome with an operationOutcome to report
          if (!LookUpIfNoneExistInDatabase(IfNoneExistsMapItemList))
          {
            return _ServiceOperationOutcome;
          }
        }
        //3. If the if-none-exist items exist then no need to process them any further, yet must keep their database FhirID 
        //   mapped to their FullURL GUID to resolve any idenitfer referances to them in other resources         
        //4. If they do not exist then treat them like noraml POST and remove the IfNoneExsist property from the bundle entry
        //   Note: the above is done and set into the items within the 'IfNoneExistsMapItemList'

        //Get all Delete entries
        List<Bundle.EntryComponent> DeleteEntries = bundle.Entry.Where(x => x.Request.Method == Bundle.HTTPVerb.DELETE).ToList();

        //Get all POST entries minus IfNoneExistsItems that did exist in the database
        List<Bundle.EntryComponent> POSTEntries = bundle.Entry.Where(x => x.Request.Method == Bundle.HTTPVerb.POST && string.IsNullOrWhiteSpace(x.Request.IfNoneExist)).ToList();

        //Get all PUT entries minus IfNoneExistsItems that did exist in the database
        List<Bundle.EntryComponent> PUTEntries = bundle.Entry.Where(x => x.Request.Method == Bundle.HTTPVerb.PUT && string.IsNullOrWhiteSpace(x.Request.IfNoneExist)).ToList();

        //Get all GET entries
        List<Bundle.EntryComponent> GETEntries = bundle.Entry.Where(x => x.Request.Method == Bundle.HTTPVerb.GET).ToList();


        //5. Roll through all remaining POST & PUT entries and update all referances as follows:
        //   a. Update normaly referances that have UUID's that are links to FullURL UUIDs (e.g <reference value="urn:uuid:ba58c03b-4ff6-4e86-8883-8851f40fb8f7" /> )
        AssignResourceIdsAndUpdateReferances(POSTEntries, PUTEntries, IfNoneExistsMapItemList);
        //   b. Update any identifer referances (e.g <reference value="Patient?identifier=123456" /> )
        //      - first checking the IfNoneExist resources that were found in the database using the InMemoryIndexer and use the FhirId we found 
        //        in the db for the referance update
        //      - If not found in the transaction bundle IfNoneExist resources then search the whole database for the resource and if found use it's 
        //        FHIRid to update, remember to reject the transaction bundle if not found or many found
        UpdateResourceIdentifierReferences(POSTEntries, PUTEntries, IfNoneExistsMapItemList);

        
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



          //POST Processing        
          for (int i = 0; i < POSTEntries.Count(); i++)
          {
            // Do not commit IfNoneExist Resources that were found in the database
            var Process = IfNoneExistsMapItemList.SingleOrDefault(x => x.FullUrl == POSTEntries.ElementAt(i).FullUrl && x.FoundInDatabase);
            if (Process == null)
            {
              if (!PostProcessing(POSTEntries.ElementAt(i), i))
              {
                _ServiceOperationOutcome.SuccessfulTransaction = false;
                return _ServiceOperationOutcome;
              }
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

          //Update the bundle response elements for the IfNoneExist resources that were found in the database based
          foreach (IfNoneExistsMapItem IfNoneExistsMapItem in IfNoneExistsMapItemList.Where(x => x.FoundInDatabase))
          {
            var BundleEntry = bundle.Entry.SingleOrDefault(x => x.FullUrl == IfNoneExistsMapItem.FullUrl);            
            BundleEntry.FullUrl = $"{_RequestUri.FhirRequestUri.UriPrimaryServiceRoot.OriginalString}/{IfNoneExistsMapItem.ResourceName}/{IfNoneExistsMapItem.FhirId}";
            BundleEntry.Resource = IfNoneExistsMapItem.DatabaseResource;
            BundleEntry.Request = null;
            BundleEntry.Response = new Bundle.ResponseComponent();
            BundleEntry.Response.Status = FormatHTTPStatusCodeAsString(System.Net.HttpStatusCode.OK);
            BundleEntry.Response.Etag = HttpHeaderSupport.GetEntityTagHeaderValueFromVersion(IfNoneExistsMapItem.ResourceVersion).ToString();
            BundleEntry.Response.LastModified = IfNoneExistsMapItem.ResourceLastUpdated;
            BundleEntry.Response.Location = FormatResponseLocation(IfNoneExistsMapItem.ResourceName, IfNoneExistsMapItem.FhirId, IfNoneExistsMapItem.ResourceVersion);
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

    private bool LookUpIfNoneExistInDatabase(List<IfNoneExistsMapItem> IfNoneExistsMapItemList)
    {
      foreach (var IfNoneExistsMapItem in IfNoneExistsMapItemList.Where(x => !string.IsNullOrWhiteSpace(x.IfNoneExistEntryRequestProperty)))
      {
        IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set($"{IfNoneExistsMapItem.ResourceName}?{IfNoneExistsMapItem.IfNoneExistEntryRequestProperty}");
        var ResourceServiceOutcome = IResourceServices.GetSearch(RequestMeta);
        if (ResourceServiceOutcome.HttpStatusCode == System.Net.HttpStatusCode.OK)
        {
          if (ResourceServiceOutcome.ResourceResult != null)
          {
            if (ResourceServiceOutcome.ResourceResult is Bundle SearchBundle)
            {
              var DatabaseMatchedResourceList = SearchBundle.Entry.Where(x => x.Resource.ResourceType == IfNoneExistsMapItem.Entry.Resource.ResourceType).ToArray();
              if (DatabaseMatchedResourceList.Count() == 1)
              {
                IfNoneExistsMapItem.UpdateFhirId(DatabaseMatchedResourceList[0].Resource.Id);
                IfNoneExistsMapItem.FoundInDatabase = true;
                IfNoneExistsMapItem.ResourceVersion = DatabaseMatchedResourceList[0].Resource.Meta.VersionId;
                IfNoneExistsMapItem.ResourceLastUpdated = DatabaseMatchedResourceList[0].Resource.Meta.LastUpdated;
                IfNoneExistsMapItem.DatabaseResource = DatabaseMatchedResourceList[0].Resource;
              }
              else if (DatabaseMatchedResourceList.Count() == 0)
              {
                IfNoneExistsMapItem.RemoveIfNoneExists();
                IfNoneExistsMapItem.FoundInDatabase = false;                
              }
              else
              {
                //The db match count is greater than 1 or 0 so fail the transaction bundle as we have many matches
                var Message = $"A resource in the transaction bundle with the FullUrl of '{IfNoneExistsMapItem.FullUrl}' which had a request property of ifNoneExist: {IfNoneExistsMapItem.IfNoneExistEntryRequestProperty} matched to more than one resource in the server. The matched resource ids were: ";
                string IdList = string.Empty;
                foreach (var Res in DatabaseMatchedResourceList)
                {
                  IdList = IdList + $"{Res.Resource.ResourceType.GetLiteral()}/{Res.Resource.Id}, ";
                }
                Message = Message + IdList;
                var OpOutcome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Processing, Message);
                _ServiceOperationOutcome.ResourceResult = OpOutcome;
                _ServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.PreconditionFailed;
                _ServiceOperationOutcome.OperationType = Enum.RestEnum.CrudOperationType.Create;
                return false;
              }
            }
          }
        }
        else
        {
          //Why would we not get HTTP OK on a search? Must be an error fail the transaction bundle
          string Message = $"Internal Server Error: When looking up the 'IfNoneExsits' resources in the bundle transaction the resource search did not return HTTP OK.";
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError, FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Message), Message);
        }
      }
      //no isues so return true;
      return true;
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

      DeleteEntry.Request = null;
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
        ResourceIdToForce.Parse(_OldNewResourceReferanceMap[GetUUIDfromFullURL(PostEntry.FullUrl)]);
      }
      //Remove the Resource Id in the resource as this is a POST and no id should be present in the resource, we do force the new id given this is a transaction operation 
      if (!String.IsNullOrEmpty(PostEntry.Resource.Id))
        PostEntry.Resource.Id = String.Empty;

      IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.Post(PostEntry.Resource, RequestMeta, ResourceIdToForce.ResourceId);

      PostEntry.Request = null;
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
        PostEntry.Response.Location = FormatResponseLocation(PostEntry.Resource.TypeName, ResourceServiceOutcome.FhirResourceId, ResourceServiceOutcome.ResourceVersionNumber);
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

      PutEntry.Request = null;
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
          PutEntry.Response.Location = FormatResponseLocation(PutEntry.Resource.ResourceType.GetLiteral(), ResourceServiceOutcome.FhirResourceId, ResourceServiceOutcome.ResourceVersionNumber);
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

      GetEntry.Request = null;
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
          GetEntry.Response.Location = FormatResponseLocation(ResourceServiceOutcome.ResourceResult.ResourceType.GetLiteral(), ResourceServiceOutcome.FhirResourceId, ResourceServiceOutcome.ResourceVersionNumber);
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

    private string FormatResponseLocation(string ResourceName, string FhirResourceId, string ResourceVersionNumber)
    {
      return $"{_RequestUri.FhirRequestUri.UriPrimaryServiceRoot.OriginalString}/{ResourceName}/{FhirResourceId}/_history/{ResourceVersionNumber}";
    }

    private IEnumerable<Bundle.EntryComponent> GetifNoneExistPostEntryList(IEnumerable<Bundle.EntryComponent> pOSTEntries)
    {
      return pOSTEntries.Where(x => !string.IsNullOrWhiteSpace(x.Request.IfNoneMatch));
    }
    
    private void PopulateOldNewResourceIdReferanceMap(IEnumerable<Bundle.EntryComponent> PostEntryList, List<IfNoneExistsMapItem> IfNoneExistsMapItemList)
    {
      _OldNewResourceReferanceMap = new Dictionary<string, string>();
      //First assign a new GUID id for all FullUrls
      //This one only add referances that are not in the db as yet, are about to be added via this transaction and ForceFhirID
      foreach (var PostEntry in PostEntryList)
      {
        //if this entry is in the IfNoneExsist List then use it's fhir ID and referance as it may have come form the db.
        if (!string.IsNullOrEmpty(PostEntry.FullUrl))
        {
          var ifnoneExsistItem = IfNoneExistsMapItemList.SingleOrDefault(x => x.FullUrl == PostEntry.FullUrl);
          if (ifnoneExsistItem != null)
          {
            _OldNewResourceReferanceMap.Add(ifnoneExsistItem.FullUrlUUID, ifnoneExsistItem.ResourceReference);
          }
          else
          {
            //else just assign a new FhirID as this will be forced as the commited FhirID
            string FhirId = Common.Tools.FhirGuid.FhirGuid.NewFhirGuid();
            string ResourceName = PostEntry.Resource.ResourceType.ToString();
            string OldFullUrlUUID = GetUUIDfromFullURL(PostEntry.FullUrl);
            _OldNewResourceReferanceMap.Add(OldFullUrlUUID, $"{ResourceName}/{FhirId}");
          }
        }
      }
      //This only adds referances that are in the db, they will not be added in this transaction but any references to them need to be updated
      foreach (var IfNoneExistsItem in IfNoneExistsMapItemList)
      {
        var IfNoneExistsEntry = PostEntryList.SingleOrDefault(x => x.FullUrl == IfNoneExistsItem.FullUrl);
        if (IfNoneExistsEntry == null)
        {
          //It is a resource found in the db and therefor not in the POST list, but it's fhirID is a true db fhirID so anything referancing it need to be updated.
          _OldNewResourceReferanceMap.Add(IfNoneExistsItem.FullUrlUUID, IfNoneExistsItem.ResourceReference);
        }
      }
    }

    private void UpddateNarrativeResourceReferences(IEnumerable<Bundle.EntryComponent> EntryList)
    {
      if (_OldNewResourceReferanceMap.Count > 0)
      {
        //Then roll through all POST and PUT entries updating referances           
        foreach (var PostPutItem in EntryList)
        {
          if (PostPutItem.Resource is DomainResource dr)
          {
            //Update all <a href="" & <img src=""
            dr.Text.UpdateAllReferances(_OldNewResourceReferanceMap);
          }
        }
      }
    }

    private void UpdateResourceReferences(IEnumerable<Bundle.EntryComponent> EntryList)
    {
      if (_OldNewResourceReferanceMap.Count > 0)
      {
        List<ResourceReference> RefList = EntryList.AllReferences();
        foreach (var resRef in RefList.Where(rr => !string.IsNullOrEmpty(rr.Reference)))
        {
          //Is this a UUID referance
          string UUID = resRef.Reference.Split(':')[resRef.Reference.Split(':').Length - 1];
          if (_OldNewResourceReferanceMap.ContainsKey(UUID))
          {
            resRef.Reference = _OldNewResourceReferanceMap[UUID];
          }
        }
      }
    }

    private bool HasResourceIdentifierReferences(Resource Resource)
    {
      foreach (var Ref in Resource.AllReferences())
      {
        if (Ref.Reference.Contains('?'))
        {
          return true;
        }
      }
      return false;
    }

    private bool UpdateResourceIdentifierReferences(IEnumerable<Bundle.EntryComponent> PostEntryList, IEnumerable<Bundle.EntryComponent> PutEntryList, List<IfNoneExistsMapItem> IfNoneExsits)
    {
      List<Bundle.EntryComponent> EntryToSearchForIndenitifierReferenceList = new List<Bundle.EntryComponent>();
      foreach (var Entry in PostEntryList)
      {
        var IfNoneExsitItem = IfNoneExsits.SingleOrDefault(x => x.FullUrl == Entry.FullUrl);
        if (IfNoneExsitItem != null)
        {
          //we don't need to process the resources that where found in the db as they will not be commited.
          if (!IfNoneExsitItem.FoundInDatabase)
          {
            EntryToSearchForIndenitifierReferenceList.Add(Entry);
          }
        }
        else
        {
          EntryToSearchForIndenitifierReferenceList.Add(Entry);
        }

      }
      List<ResourceReference> RefList = EntryToSearchForIndenitifierReferenceList.AllReferences();

      foreach (var resRef in RefList.Where(rr => !string.IsNullOrEmpty(rr.Reference)))
      {        
        //e.g : "reference": "Patient?identifier=0987654321"
        if (resRef.Reference.Contains('?'))
        {
          //First Search ifNoneExist resources
          IRequestMeta RequestMetaFromReference = IRequestMetaFactory.CreateRequestMeta();

          //example: RequestMeta.Set("Patient?identifier=09876510001");
          RequestMetaFromReference.Set(resRef.Reference);
          RequestMetaFromReference.RequestHeader.Prefer = _RequestHeader.Prefer;

          ISearchParameterService SearchService = ISearchParameterServiceFactory.CreateSearchParameterService();
          ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchService.ProcessSearchParameters(RequestMetaFromReference.SearchParameterGeneric, SearchParameterService.SearchParameterServiceType.Base | SearchParameterService.SearchParameterServiceType.Resource, FHIRAllTypes.Patient, null);
          if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
          {
            //some error if the parameter parse failes, need to fail transactrion bundle and explain why.
            _ServiceOperationOutcome.ResourceResult = SearchParametersServiceOutcome.FhirOperationOutcome;
            _ServiceOperationOutcome.HttpStatusCode = SearchParametersServiceOutcome.HttpStatusCode;
            _ServiceOperationOutcome.OperationType = Enum.RestEnum.CrudOperationType.Create;
            return false;
          }

          Dictionary<string, Resource> FullUrlKeyedResourceList = new Dictionary<string, Resource>();
          foreach (var Entry in EntryToSearchForIndenitifierReferenceList)
          {
            FullUrlKeyedResourceList.Add(Entry.FullUrl, Entry.Resource);
          }
          foreach (var item in IfNoneExsits.Where(x => x.FoundInDatabase))
          {
            FullUrlKeyedResourceList.Add(item.FullUrl, item.Entry.Resource);
          }

          var SearchResultList = IInMemoryResourceSearch.SearchKeyedResourceList(FullUrlKeyedResourceList, SearchParametersServiceOutcome.SearchParameters);          
          if (SearchResultList != null && SearchResultList.Count == 1)
          {
            //we have found a single referance in the transaction bundle so update the idenitfer reference
            if (_OldNewResourceReferanceMap.ContainsKey(GetUUIDfromFullURL(SearchResultList[0].Key)))
            {
              resRef.Reference = _OldNewResourceReferanceMap[GetUUIDfromFullURL(SearchResultList[0].Key)];
              //Updated and all good!
            }
            else
            {
              throw new Exception("Internal Server Error: Reference not found in _OldNewResourceReferanceMap for transaction bundle post InMemoryIndexSearch.");
            }
          }
          else if (SearchResultList != null && SearchResultList.Count > 1)
          {
            //Report OperationOutcome as idenitrfer reference matches mutiple target resources in the transaction bundle, this is a PreconditionFailed
            string FullUrlList = string.Empty;
            foreach (var SearchItem in SearchResultList)
            {
              FullUrlList = FullUrlList + $"{SearchItem.Key}, ";
            }            
            var Message = $"The transaction bundle has a resource with a resource reference that uses search parameters. The reference in question is '{resRef.Reference}'. This referance resolves to more than a single resource within the transaction bundle. " + 
                         $"The fullUrls of the matched resources are :{FullUrlList}. References of this nature must only match a single resource either in the bundle or in the Fhir server database. ";                        
            var OpOutcome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Processing, Message);
            _ServiceOperationOutcome.ResourceResult = OpOutcome;
            _ServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.PreconditionFailed;
            _ServiceOperationOutcome.OperationType = Enum.RestEnum.CrudOperationType.Create;
            return false;            
          }
          else
          {
            //ResultList was null or count == 0
            //The reference is not found in the transaction bundle so search the database for a match
            IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta();
            RequestMeta.Set(resRef.Reference);
            RequestMeta.RequestHeader.Prefer = _RequestHeader.Prefer;
            var ResourceServiceOutcome = IResourceServices.GetSearch(RequestMeta);
            if (ResourceServiceOutcome.HttpStatusCode == System.Net.HttpStatusCode.OK && ResourceServiceOutcome.ResourceResult != null &&
              ResourceServiceOutcome.ResourceResult is Bundle ReturnedBundle)
            {
              if (ReturnedBundle.Entry.Count == 1)
              {
                string ResourceFhirId = ReturnedBundle.Entry[0].Resource.Id;
                string ResourceName = ReturnedBundle.Entry[0].Resource.ResourceType.GetLiteral();
                resRef.Reference = $"{ResourceName}/{ResourceFhirId}";
                //all good
              }
              else if (ReturnedBundle.Entry.Count > 1)
              {                
                //Report OperationOutcome as idenitrfer reference matches mutiple target resources in the database, this is a PreconditionFailed
                string FullUrlList = string.Empty;
                foreach (var SearchEntryItem in ReturnedBundle.Entry)
                {
                  FullUrlList = FullUrlList + $"{SearchEntryItem.FullUrl}, ";
                }
                var Message = $"The transaction bundle has a resource with a resource reference that uses search parameters. The reference in question is '{resRef.Reference}'. This referance resolves to more than a single resource within the Fhir server database. " +
                             $"The the matched resources are :{FullUrlList}. References of this nature must only match a single resource either in the bundle or in the Fhir server database. ";
                var OpOutcome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Processing, Message);
                _ServiceOperationOutcome.ResourceResult = OpOutcome;
                _ServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.PreconditionFailed;
                _ServiceOperationOutcome.OperationType = Enum.RestEnum.CrudOperationType.Create;
                return false;
              }
              else
              {
                // Zero matches, fhir specs says to: "if there are no matches, or multiple matches, the transaction fails, and an error is returned to the user"                
                var Message = $"The transaction bundle has a resource with a resource reference that uses search parameters. The reference in question is '{resRef.Reference}'. This referance resolves to no resource within the transaction bundle or the Fhir server database. " +
                             $"References of this nature must match a single resource either in the bundle or in the Fhir server database. ";
                var OpOutcome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Processing, Message);
                _ServiceOperationOutcome.ResourceResult = OpOutcome;
                _ServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.PreconditionFailed;
                _ServiceOperationOutcome.OperationType = Enum.RestEnum.CrudOperationType.Create;
                return false;
              }
            }
            else
            {
              //why would the search fail to return OK, maybe the search parameters were invalid.
              //Fail the entire transaction as more than a single resource match
              // Zero matches, fhir specs says to: "if there are no matches, or multiple matches, the transaction fails, and an error is returned to the user"                
              var Message = $"The transaction bundle has a resource with a resource reference that uses search parameters. The reference in question is '{resRef.Reference}'. " +
                           $"This reference's search parameter has caused an error when the search was performed. Please review the search parameters are valid.";
              var OpOutcome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Processing, Message);
              _ServiceOperationOutcome.ResourceResult = OpOutcome;
              _ServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.PreconditionFailed;
              _ServiceOperationOutcome.OperationType = Enum.RestEnum.CrudOperationType.Create;
              return false;
            }
          }
        }
      }
      //No earlier OperationOutcome returned false so return true;
      return true;
    }

    private void AssignResourceIdsAndUpdateReferances(IEnumerable<Bundle.EntryComponent> PostEntryList, IEnumerable<Bundle.EntryComponent> PutEntryList, List<IfNoneExistsMapItem> IfNoneExistsMapItemList)
    {
      PopulateOldNewResourceIdReferanceMap(PostEntryList, IfNoneExistsMapItemList);
      if (_OldNewResourceReferanceMap.Count > 0)
      {
        //Then roll through all POST and PUT entries updating referances is any exists in the _OldNewResourceReferanceMap     
        List<Bundle.EntryComponent> AllPostAndPutEntriesToBeCommitedToDatabaseList = PostEntryList.Concat(PutEntryList).ToList();
        UpddateNarrativeResourceReferences(AllPostAndPutEntriesToBeCommitedToDatabaseList);
        UpdateResourceReferences(AllPostAndPutEntriesToBeCommitedToDatabaseList);
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

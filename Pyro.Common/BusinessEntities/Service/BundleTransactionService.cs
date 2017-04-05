using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Dto.Headers;
using Pyro.Common.Tools;
using Hl7.Fhir.Model;
using Pyro.Common.Extentions;

namespace Pyro.Common.BusinessEntities.Service
{
  public class BundleTransactionService : IBundleTransactionService
  {   
    private IResourceServiceRequestTransactionBundle _ResourceServiceRequest;
    private IResourceServiceOutcome _ServiceOperationOutcome;
    private Dictionary<string, string> OldNewResourceReferanceMap;
    private IList<Tuple<Enum.RestEnum.CrudOperationType, System.Net.HttpStatusCode>> OperationHttpStatusCodeDic;
    internal BundleTransactionService(IResourceServiceRequestTransactionBundle ResourceServiceRequestTransactionBundle)
    {
      _ResourceServiceRequest = ResourceServiceRequestTransactionBundle;
    }

    public IResourceServiceOutcome Transact()
    {
      if (_ResourceServiceRequest.ServiceNegotiator == null)
      {
        throw new ArgumentNullException("_ServiceNegotiator can not be null.");
      }
      if (_ResourceServiceRequest == null)
      {
        throw new ArgumentNullException("_ResourceServiceRequest can not be null.");
      }

      _ServiceOperationOutcome = Common.CommonFactory.GetServiceOperationOutcome();

      _ServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;      
      bool IsTransactionSucsessfull = true;
      OperationHttpStatusCodeDic = new List<Tuple<Enum.RestEnum.CrudOperationType, System.Net.HttpStatusCode>>();
      Bundle bundle = _ResourceServiceRequest.Resource as Bundle;
      Resource OperationOutcomeIfFailed = null;

      if (bundle == null)
      {
        var Message = $"The FHIR server's service root endpoint can only accept 'Bundle' resources. Resource received was: {_ResourceServiceRequest.Resource.ResourceType.ToString()}";
        var OpOutcome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Invalid, Message);
        _ServiceOperationOutcome.ResourceResult = OpOutcome;
        _ServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.Forbidden;
        _ServiceOperationOutcome.OperationType = Enum.RestEnum.CrudOperationType.Create;
        _ServiceOperationOutcome.ServiceRootUri = _ResourceServiceRequest.DtoFhirRequestUri.PrimaryRootUrlStore.RootUri;
        return _ServiceOperationOutcome;
      }
      else if (bundle.Type != Bundle.BundleType.Transaction || (bundle.Type != Bundle.BundleType.Transaction && bundle.Type != Bundle.BundleType.Batch))
      {
        var Message = $"The FHIR server's service root endpoint can only accept Bundle resources of Bundle.type = 'Transaction' or Bundle.type = 'Batch'. Type found was {bundle.Type.ToString()}";
        var OpOutcome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Invalid, Message);
        _ServiceOperationOutcome.ResourceResult = OpOutcome;
        _ServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.Forbidden;
        _ServiceOperationOutcome.OperationType = Enum.RestEnum.CrudOperationType.Create;
        _ServiceOperationOutcome.ServiceRootUri = _ResourceServiceRequest.DtoFhirRequestUri.PrimaryRootUrlStore.RootUri;
        return _ServiceOperationOutcome;
      }
      else
      {
        Bundle BundleOutcome = new Bundle();
        BundleOutcome.Type = Bundle.BundleType.TransactionResponse;
        BundleOutcome.Id = bundle.Id;
        if (BundleOutcome.Meta == null)
          BundleOutcome.Meta = new Meta();
        BundleOutcome.Meta.LastUpdated = DateTimeOffset.Now;
        BundleOutcome.Entry = new List<Bundle.EntryComponent>();
        BundleOutcome.ResourceBase = _ResourceServiceRequest.DtoFhirRequestUri.PrimaryRootUrlStore.RootUri;

        _ResourceServiceRequest.ServiceNegotiator.BeginTransaction();
        //DELETE Processing 
        foreach (var DeleteEntry in bundle.Entry.Where(x => x.Request.Method == Bundle.HTTPVerb.DELETE))
        {
          Uri UriBuild = new Uri(_ResourceServiceRequest.DtoFhirRequestUri.PrimaryRootUrlStore.RootUri.OriginalString + "/" + DeleteEntry.Request.Url);
          _ResourceServiceRequest.DtoFhirRequestUri.FhirUri = Common.CommonFactory.GetFhirUri(UriBuild);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(_ResourceServiceRequest.DtoFhirRequestUri.FhirUri.Query);
          var ResourceService = _ResourceServiceRequest.ServiceNegotiator.GetTransactionalResourceService(_ResourceServiceRequest.DtoFhirRequestUri.FhirUri.ResourseType);
          IResourceServiceOutcome ResourceServiceOutcome = null;
          if (SearchParameterGeneric.ParameterList.Count > 0)
          {
            IResourceServiceRequestConditionalDelete ResourceServiceRequestConditionalDelete = Common.CommonFactory.GetResourceServiceRequestConditionalDelete(_ResourceServiceRequest.DtoFhirRequestUri, SearchParameterGeneric);
            ResourceServiceOutcome = ResourceService.ConditionalDelete(ResourceServiceRequestConditionalDelete);
          }
          else
          {
            IResourceServiceRequestDelete ResourceServiceRequest = Common.CommonFactory.GetResourceServiceRequestDelete(_ResourceServiceRequest.DtoFhirRequestUri.FhirUri.Id, _ResourceServiceRequest.DtoFhirRequestUri, SearchParameterGeneric);
            ResourceServiceOutcome = ResourceService.Delete(ResourceServiceRequest);
          }
          
          if (!ResourceServiceOutcome.SuccessfulTransaction)
          {
            _ResourceServiceRequest.ServiceNegotiator.RollbackTransaction();
            return ResourceServiceOutcome;
          }
          else
          {
            var EntryComponent = new Bundle.EntryComponent();
            BundleOutcome.Entry.Add(EntryComponent);
            EntryComponent.Request = DeleteEntry.Request;
            EntryComponent.Response = new Bundle.ResponseComponent();
            EntryComponent.Response.Status = ResourceServiceOutcome.HttpStatusCode.ToString();
            if (ResourceServiceOutcome.ResourceResult != null)
            {
              if (ResourceServiceOutcome.ResourceResult.ResourceType == ResourceType.OperationOutcome)
              {
                EntryComponent.Response.Outcome = ResourceServiceOutcome.ResourceResult;
              }
              else
              {
                EntryComponent.Resource = ResourceServiceOutcome.ResourceResult;
              }
            }
            if (ResourceServiceOutcome.LastModified != null && ResourceServiceOutcome.ResourceVersionNumber != null)
            {
              EntryComponent.Response.Etag = HttpHeaderSupport.AddVersionETag(ResourceServiceOutcome.ResourceVersionNumber).Tag;
              EntryComponent.Response.LastModified = ResourceServiceOutcome.LastModified;
              EntryComponent.Response.Location = ResourceServiceOutcome.RequestUri.OriginalString;
            }
          }
        }

        //Assign new id's for POSTs and then update all POST and PUT entrie referances       
        AssignResourceIdsAndUpdateReferances(bundle.Entry);

        //POST Processing
        foreach (var PostEntry in bundle.Entry.Where(x => x.Request.Method == Bundle.HTTPVerb.POST))
        {
          Uri UriBuild = new Uri(_ResourceServiceRequest.DtoFhirRequestUri.PrimaryRootUrlStore.RootUri, PostEntry.Request.Url);
          _ResourceServiceRequest.DtoFhirRequestUri.FhirUri = Common.CommonFactory.GetFhirUri(UriBuild);
          if (!string.IsNullOrWhiteSpace(_ResourceServiceRequest.DtoFhirRequestUri.FhirUri.ResourceOperation))
          {
            var Message = $"The FHIR server does not support the use of Operations within Transaction Bundles, found Operation request type of : '{_ResourceServiceRequest.DtoFhirRequestUri.FhirUri.ResourceOperation}'.";
            var OpOutcome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Invalid, Message);
            _ServiceOperationOutcome.ResourceResult = OpOutcome;
            _ServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.Forbidden;
            _ServiceOperationOutcome.OperationType = Enum.RestEnum.CrudOperationType.Create;
            _ServiceOperationOutcome.ServiceRootUri = _ResourceServiceRequest.DtoFhirRequestUri.PrimaryRootUrlStore.RootUri;
            return _ServiceOperationOutcome;
          }
          IFhirUri ResourceIdToForce = Common.CommonFactory.GetFhirUri(OldNewResourceReferanceMap[GetUUIDfromFullURL(PostEntry.FullUrl)]);
          //Prepare and perform POST (Add)
          IDtoRequestHeaders RequestHeaders = Common.CommonFactory.GetDtoRequestHeaders(PostEntry.Request);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(_ResourceServiceRequest.DtoFhirRequestUri.FhirUri.Query);
          IResourceServiceRequestPost ResourceServiceRequestPost = Common.CommonFactory.GetResourceServiceRequestPost(PostEntry.Resource, _ResourceServiceRequest.DtoFhirRequestUri, SearchParameterGeneric, RequestHeaders, ResourceIdToForce.Id);
          IResourceServices ResourceService = _ResourceServiceRequest.ServiceNegotiator.GetTransactionalResourceService(_ResourceServiceRequest.DtoFhirRequestUri.FhirUri.ResourseType);
          IResourceServiceOutcome ResourceServiceOutcome = ResourceService.Post(ResourceServiceRequestPost);

          if (!ResourceServiceOutcome.SuccessfulTransaction)
          {
            _ResourceServiceRequest.ServiceNegotiator.RollbackTransaction();
            return ResourceServiceOutcome;
          }
          else
          {
            var EntryComponent = new Bundle.EntryComponent();
            BundleOutcome.Entry.Add(EntryComponent);
            EntryComponent.Request = PostEntry.Request;
            EntryComponent.Response = new Bundle.ResponseComponent();
            EntryComponent.Response.Status = ResourceServiceOutcome.HttpStatusCode.ToString();

            if (ResourceServiceOutcome.ResourceResult != null)
            {
              if (ResourceServiceOutcome.ResourceResult.ResourceType == ResourceType.OperationOutcome)
              {
                EntryComponent.Response.Outcome = ResourceServiceOutcome.ResourceResult;
              }
              else
              {
                EntryComponent.Resource = ResourceServiceOutcome.ResourceResult;
              }
            }
            if (ResourceServiceOutcome.LastModified != null)
            {
              EntryComponent.Response.Etag = HttpHeaderSupport.AddVersionETag(ResourceServiceOutcome.ResourceVersionNumber).Tag;
              EntryComponent.Response.LastModified = ResourceServiceOutcome.LastModified;
            }
            EntryComponent.Response.Status = ResourceServiceOutcome.HttpStatusCode.ToString();
            EntryComponent.Response.Location = ResourceServiceOutcome.RequestUri.OriginalString;
          }
        }

        //PUT Processing
        foreach (var PutEntry in bundle.Entry.Where(x => x.Request.Method == Bundle.HTTPVerb.PUT))
        {
          Uri UriBuild = new Uri(_ResourceServiceRequest.DtoFhirRequestUri.PrimaryRootUrlStore.RootUri, PutEntry.Request.Url);
          _ResourceServiceRequest.DtoFhirRequestUri.FhirUri = Common.CommonFactory.GetFhirUri(UriBuild);
          IDtoRequestHeaders RequestHeaders = Common.CommonFactory.GetDtoRequestHeaders(PutEntry.Request);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(_ResourceServiceRequest.DtoFhirRequestUri.FhirUri.Query);          
          var ResourceService = _ResourceServiceRequest.ServiceNegotiator.GetTransactionalResourceService(_ResourceServiceRequest.DtoFhirRequestUri.FhirUri.ResourseType);
          IResourceServiceOutcome ResourceServiceOutcome = null;
          if (SearchParameterGeneric.ParameterList.Count > 0)
          {
            IResourceServiceRequestConditionalPut PyroServiceRequestConditionalPut = CommonFactory.GetResourceServiceRequestConditionalPut(PutEntry.Resource, _ResourceServiceRequest.DtoFhirRequestUri, SearchParameterGeneric);
            ResourceServiceOutcome = ResourceService.ConditionalPut(PyroServiceRequestConditionalPut);
          }
          else
          {
            IResourceServiceRequestPut ResourceServiceRequestPut = Common.CommonFactory.GetResourceServiceRequestPut(_ResourceServiceRequest.DtoFhirRequestUri.FhirUri.Id, PutEntry.Resource, _ResourceServiceRequest.DtoFhirRequestUri, SearchParameterGeneric, RequestHeaders);
            ResourceServiceOutcome = ResourceService.Put(ResourceServiceRequestPut);
          }

          if (!ResourceServiceOutcome.SuccessfulTransaction)
          {
            _ResourceServiceRequest.ServiceNegotiator.RollbackTransaction();
            return ResourceServiceOutcome;
          }
          else
          {
            var EntryComponent = new Bundle.EntryComponent();
            BundleOutcome.Entry.Add(EntryComponent);
            EntryComponent.Request = PutEntry.Request;
            EntryComponent.Response = new Bundle.ResponseComponent();
            EntryComponent.Response.Status = ResourceServiceOutcome.HttpStatusCode.ToString();

            if (ResourceServiceOutcome.ResourceResult != null)
            {
              if (ResourceServiceOutcome.ResourceResult.ResourceType == ResourceType.OperationOutcome)
              {
                EntryComponent.Response.Outcome = ResourceServiceOutcome.ResourceResult;
              }
              else
              {
                EntryComponent.Resource = ResourceServiceOutcome.ResourceResult;
              }
            }
            if (ResourceServiceOutcome.LastModified != null)
            {
              EntryComponent.Response.Etag = HttpHeaderSupport.AddVersionETag(ResourceServiceOutcome.ResourceVersionNumber).Tag;
              EntryComponent.Response.LastModified = ResourceServiceOutcome.LastModified;
              EntryComponent.Response.Location = HttpHeaderSupport.AddResponseLocation(ResourceServiceOutcome.RequestUri).OriginalString;
            }
          }
        }
        
        //GET Processing
        foreach (var GetEntry in bundle.Entry.Where(x => x.Request.Method == Bundle.HTTPVerb.GET))
        {
          Uri UriBuild = new Uri(_ResourceServiceRequest.DtoFhirRequestUri.PrimaryRootUrlStore.RootUri, GetEntry.Request.Url);
          _ResourceServiceRequest.DtoFhirRequestUri.FhirUri = Common.CommonFactory.GetFhirUri(UriBuild);
          IDtoRequestHeaders RequestHeaders = Common.CommonFactory.GetDtoRequestHeaders(GetEntry.Request);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(_ResourceServiceRequest.DtoFhirRequestUri.FhirUri.Query);
          IResourceServiceOutcome ResourceServiceOutcome = null;
          var ResourceService = _ResourceServiceRequest.ServiceNegotiator.GetTransactionalResourceService(_ResourceServiceRequest.DtoFhirRequestUri.FhirUri.ResourseType);
          if (SearchParameterGeneric.ParameterList.Count > 0)
          {
            IResourceServiceRequestGetSearch ResourceServiceRequestGetSearch = Common.CommonFactory.GetResourceServiceRequestGetSearch(_ResourceServiceRequest.DtoFhirRequestUri, SearchParameterGeneric);
            ResourceServiceOutcome = ResourceService.GetSearch(ResourceServiceRequestGetSearch);
          }
          else
          {
            IResourceServiceRequestGetRead ResourceServiceRequestGetRead = Common.CommonFactory.GetResourceServiceRequestGetRead(_ResourceServiceRequest.DtoFhirRequestUri.FhirUri.Id, _ResourceServiceRequest.DtoFhirRequestUri, SearchParameterGeneric,RequestHeaders);            
            ResourceServiceOutcome = ResourceService.GetRead(ResourceServiceRequestGetRead);
          }

          if (!ResourceServiceOutcome.SuccessfulTransaction)
          {
            _ResourceServiceRequest.ServiceNegotiator.RollbackTransaction();
            return ResourceServiceOutcome;
          }
          else
          {
            var EntryComponent = new Bundle.EntryComponent();
            BundleOutcome.Entry.Add(EntryComponent);
            EntryComponent.Request = GetEntry.Request;
            EntryComponent.Response = new Bundle.ResponseComponent();
            EntryComponent.Response.Status = ResourceServiceOutcome.HttpStatusCode.ToString();

            if (ResourceServiceOutcome.ResourceResult != null)
            {
              if (ResourceServiceOutcome.ResourceResult.ResourceType == ResourceType.OperationOutcome)
              {
                EntryComponent.Response.Outcome = ResourceServiceOutcome.ResourceResult;
              }
              else
              {
                EntryComponent.Resource = ResourceServiceOutcome.ResourceResult;
              }
            }
            if (ResourceServiceOutcome.LastModified.HasValue)
            {
              EntryComponent.Response.Etag = HttpHeaderSupport.AddVersionETag(ResourceServiceOutcome.ResourceVersionNumber).Tag;
              if (ResourceServiceOutcome.IsDeleted.HasValue && !ResourceServiceOutcome.IsDeleted.Value)
                EntryComponent.Response.LastModified = ResourceServiceOutcome.LastModified;
              EntryComponent.Response.Location = HttpHeaderSupport.AddResponseLocation(ResourceServiceOutcome.RequestUri).OriginalString;
            }
          }
        }
                
        _ResourceServiceRequest.ServiceNegotiator.CommitTransaction();
        _ServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;
        _ServiceOperationOutcome.ResourceResult = BundleOutcome;
        _ServiceOperationOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;        
      }
      
      return _ServiceOperationOutcome;
    }

    private void AssignResourceIdsAndUpdateReferances(List<Bundle.EntryComponent> Entry)
    {
      OldNewResourceReferanceMap = new Dictionary<string, string>();
      //First assign a new GUID id for all FullUrls
      foreach (var PostEntry in Entry.Where(x => x.Request.Method == Bundle.HTTPVerb.POST))
      {
        if (PostEntry.Resource != null)
        {
          string NewId = Guid.NewGuid().ToString();
          string ResourceName = PostEntry.Resource.ResourceType.ToString();
          //string BaseUrl = _ResourceServiceRequest.DtoFhirRequestUri.PrimaryRootUrlStore.RootUrl;
          string FullUrlUUID = GetUUIDfromFullURL(PostEntry.FullUrl);
          OldNewResourceReferanceMap.Add(FullUrlUUID, $"{ResourceName}/{NewId}");
        }
      }

      //Then roll through all POST and PUT entries updating referances
      var PostAndPutEntryList = Entry.Where(x => x.Request.Method == Bundle.HTTPVerb.POST || x.Request.Method == Bundle.HTTPVerb.PUT);
      foreach(var PostPutItem in PostAndPutEntryList)
      {
        if (PostPutItem.Resource is DomainResource dr)
        {
          //Update all <a href="" & <img src=""
          dr.Text.UpdateAllReferances(OldNewResourceReferanceMap);
        }
      }
      List<ResourceReference> RefList = PostAndPutEntryList.AllReferences();
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
 
  }
}

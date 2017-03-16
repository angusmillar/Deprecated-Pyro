using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Dto.Headers;
using Pyro.Common.Tools;
using Hl7.Fhir.Model;

namespace Pyro.Common.BusinessEntities.Service
{
  public class BundleTransactionService : IBundleTransactionService
  {
    private IServiceNegotiator _ServiceNegotiator;
    private IResourceServiceRequest _ResourceServiceRequest;
    private IResourceServiceOutcome _ServiceOperationOutcome;
    internal BundleTransactionService(IServiceNegotiator ServiceNegotiator, IResourceServiceRequest ResourceServiceRequest)
    {
      _ServiceNegotiator = ServiceNegotiator;
      _ResourceServiceRequest = ResourceServiceRequest;
    }

    public IResourceServiceOutcome Transact()
    {
      if (_ServiceNegotiator == null)
      {
        throw new ArgumentNullException("_ServiceNegotiator can not be null.");
      }
      if (_ResourceServiceRequest == null)
      {
        throw new ArgumentNullException("_ResourceServiceRequest can not be null.");
      }

      _ServiceOperationOutcome = Common.CommonFactory.GetServiceOperationOutcome();


      Bundle bundle = _ResourceServiceRequest.Resource as Bundle;
      
      if (bundle == null)
      {
        var Message = $"The FHIR server's service root endpoint can only accept 'Bundle' resources. Resource received was: {_ResourceServiceRequest.Resource.ResourceType.ToString()}";
        var OpOutcome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Invalid, Message);
        _ServiceOperationOutcome.ResourceResult = OpOutcome;
        _ServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.Forbidden;
        _ServiceOperationOutcome.OperationType = Enum.RestEnum.CrudOperationType.Create;
        _ServiceOperationOutcome.ServiceRootUri = _ResourceServiceRequest.FhirRequestUri.PrimaryRootUrlStore.RootUri;
        return _ServiceOperationOutcome;
      }
      else if (bundle.Type != Bundle.BundleType.Transaction)
      {
        var Message = $"The FHIR server's service root endpoint can only accept Bundle resources of Bundle.type = 'Transaction'. Type found was {bundle.Type.ToString()}";
        var OpOutcome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Invalid, Message);
        _ServiceOperationOutcome.ResourceResult = OpOutcome;
        _ServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.Forbidden;
        _ServiceOperationOutcome.OperationType = Enum.RestEnum.CrudOperationType.Create;
        _ServiceOperationOutcome.ServiceRootUri = _ResourceServiceRequest.FhirRequestUri.PrimaryRootUrlStore.RootUri;
        return _ServiceOperationOutcome;
      }
      else
      {
        _ServiceNegotiator.BeginTransaction();
        //DELETE Processing 
        foreach (var DeleteEntry in bundle.Entry.Where(x => x.Request.Method == Bundle.HTTPVerb.DELETE))
        {
          Uri UriBuild = new Uri(_ResourceServiceRequest.FhirRequestUri.PrimaryRootUrlStore.RootUri, DeleteEntry.Request.Url);
          _ResourceServiceRequest.FhirRequestUri.FhirUri = Common.CommonFactory.GetFhirUri(UriBuild);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(_ResourceServiceRequest.FhirRequestUri.FhirUri.Query);
          IResourceServiceRequest ResourceServiceRequest = Common.CommonFactory.GetResourceServiceRequest(Enum.ServiceEnums.ServiceRequestType.Delete, _ResourceServiceRequest.FhirRequestUri.FhirUri.Id, _ResourceServiceRequest.FhirRequestUri, SearchParameterGeneric);
          var ResourceService = _ServiceNegotiator.GetTransactionalResourceService(_ResourceServiceRequest.FhirRequestUri.FhirUri.ResourseType);
          IResourceServiceOutcome ResourceServiceOutcome = null;
          if (SearchParameterGeneric.ParameterList.Count > 0)
          {
            ResourceServiceOutcome = ResourceService.ConditionalDelete(ResourceServiceRequest);
          }
          else
          {
            ResourceServiceOutcome = ResourceService.Delete(ResourceServiceRequest);
          }
        }

        //POST Processing
        foreach (var PostEntry in bundle.Entry.Where(x => x.Request.Method == Bundle.HTTPVerb.POST))
        {
          Uri UriBuild = new Uri(_ResourceServiceRequest.FhirRequestUri.PrimaryRootUrlStore.RootUri, PostEntry.Request.Url);
          _ResourceServiceRequest.FhirRequestUri.FhirUri = Common.CommonFactory.GetFhirUri(UriBuild);
          if (!string.IsNullOrWhiteSpace(_ResourceServiceRequest.FhirRequestUri.FhirUri.ResourceOperation))
          {
            var Message = $"The FHIR server does not support the use of Operations with in Transaction Bundles, found Operation request: {_ResourceServiceRequest.FhirRequestUri.FhirUri.ResourceOperation}";
            var OpOutcome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Invalid, Message);
            _ServiceOperationOutcome.ResourceResult = OpOutcome;
            _ServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.Forbidden;
            _ServiceOperationOutcome.OperationType = Enum.RestEnum.CrudOperationType.Create;
            _ServiceOperationOutcome.ServiceRootUri = _ResourceServiceRequest.FhirRequestUri.PrimaryRootUrlStore.RootUri;
            return _ServiceOperationOutcome;
          }
          IDtoRequestHeaders RequestHeaders = Common.CommonFactory.GetDtoRequestHeaders(PostEntry.Request);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(_ResourceServiceRequest.FhirRequestUri.FhirUri.Query);
          IResourceServiceRequest ResourceServiceRequest = Common.CommonFactory.GetResourceServiceRequest(Enum.ServiceEnums.ServiceRequestType.Create, PostEntry.Resource, _ResourceServiceRequest.FhirRequestUri, SearchParameterGeneric, RequestHeaders);
          var ResourceService = _ServiceNegotiator.GetTransactionalResourceService(_ResourceServiceRequest.FhirRequestUri.FhirUri.ResourseType);
          IResourceServiceOutcome ResourceServiceOutcome = ResourceService.Post(ResourceServiceRequest);

          
          var FullUrl = Common.CommonFactory.GetFhirUri(PostEntry.FullUrl);
          if (ResourceServiceOutcome.ResourceResult.Id != FullUrl.Id)
          {

          }

        }

        //PUT Processing
        foreach (var PutEntry in bundle.Entry.Where(x => x.Request.Method == Bundle.HTTPVerb.PUT))
        {
          Uri UriBuild = new Uri(_ResourceServiceRequest.FhirRequestUri.PrimaryRootUrlStore.RootUri, PutEntry.Request.Url);
          _ResourceServiceRequest.FhirRequestUri.FhirUri = Common.CommonFactory.GetFhirUri(UriBuild);
          IDtoRequestHeaders RequestHeaders = Common.CommonFactory.GetDtoRequestHeaders(PutEntry.Request);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(_ResourceServiceRequest.FhirRequestUri.FhirUri.Query);
          IResourceServiceRequest ResourceServiceRequest = Common.CommonFactory.GetResourceServiceRequest(Enum.ServiceEnums.ServiceRequestType.Update, _ResourceServiceRequest.FhirRequestUri.FhirUri.Id, PutEntry.Resource, _ResourceServiceRequest.FhirRequestUri, SearchParameterGeneric, RequestHeaders);          
          var ResourceService = _ServiceNegotiator.GetTransactionalResourceService(_ResourceServiceRequest.FhirRequestUri.FhirUri.ResourseType);
          IResourceServiceOutcome ResourceServiceOutcome = null;
          if (SearchParameterGeneric.ParameterList.Count > 0)
          {
            ResourceServiceOutcome = ResourceService.ConditionalPut(ResourceServiceRequest);
          }
          else
          {
            ResourceServiceOutcome = ResourceService.Put(ResourceServiceRequest);
          }
        }

        
        //GET Processing
        foreach (var GetEntry in bundle.Entry.Where(x => x.Request.Method == Bundle.HTTPVerb.GET))
        {
          Uri UriBuild = new Uri(_ResourceServiceRequest.FhirRequestUri.PrimaryRootUrlStore.RootUri, GetEntry.Request.Url);
          _ResourceServiceRequest.FhirRequestUri.FhirUri = Common.CommonFactory.GetFhirUri(UriBuild);
          IDtoRequestHeaders RequestHeaders = Common.CommonFactory.GetDtoRequestHeaders(GetEntry.Request);
          IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(_ResourceServiceRequest.FhirRequestUri.FhirUri.Query);
          IResourceServiceRequest ResourceServiceRequest = Common.CommonFactory.GetResourceServiceRequest(Enum.ServiceEnums.ServiceRequestType.Update, _ResourceServiceRequest.FhirRequestUri.FhirUri.Id, GetEntry.Resource, _ResourceServiceRequest.FhirRequestUri, SearchParameterGeneric, RequestHeaders);
          var ResourceService = _ServiceNegotiator.GetTransactionalResourceService(_ResourceServiceRequest.FhirRequestUri.FhirUri.ResourseType);
          IResourceServiceOutcome ResourceServiceOutcome = null;
          if (SearchParameterGeneric.ParameterList.Count > 0)
          {
            ResourceServiceOutcome = ResourceService.ConditionalPut(ResourceServiceRequest);
          }
          else
          {
            ResourceServiceOutcome = ResourceService.Put(ResourceServiceRequest);
          }
        }


        _ServiceNegotiator.CommitTransaction();

        foreach (var Entry in bundle.Entry)
        {
          if (Entry.Request != null)
          {
            //var ResourceService = _ServiceNegotiator.GetTransactionalResourceService(DeleteEntry.Resource.TypeName);

          }
        }

        _ServiceNegotiator.CommitTransaction();
      }



      throw new NotImplementedException();
    }
  }
}

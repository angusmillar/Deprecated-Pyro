using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Enum;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.ITools;
using Pyro.Common.Interfaces.Dto.Headers;
using Pyro.Common.BusinessEntities.UriSupport;
using Pyro.Common.BusinessEntities.Service;
using Pyro.Common.BusinessEntities.Dto;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

namespace Pyro.Common
{
  public static class CommonFactory
  {
    //public static IFhirUri GetFhirUri(string value)
    //{
    //  return new DtoFhirUri(value);
    //}

    //public static IFhirUri GetFhirUri(Uri value)
    //{
    //  return new DtoFhirUri(value);
    //}

    public static IDtoRequestUri GetFhirRequestUri()
    {
      return new DtoRequestUri();
    }  

    public static IDtoRequestUri GetRequestUri(IDtoRootUrlStore PrimaryRootUrlStore, IFhirRequestUri FhirRequestUri)
    {
      return new DtoRequestUri(PrimaryRootUrlStore, FhirRequestUri);
    }
    
    public static IFhirRequestUri GetFhirRequestUri(string PrimaryServiceRoot, string RequestUri)
    {
      return new FhirRequestUri(PrimaryServiceRoot, RequestUri);
    }






    public static IDtoRootUrlStore GetRootUrlStore()
    {
      return new DtoRootUrlStore();
    }

    public static IResourceServiceOutcome GetResourceServiceOutcome()
    {
      return new ResourceServiceOutcome();
    }
    
   

    public static IFhirRequestUri GetFhirRequestUri(Uri PrimaryServiceRoot, string RequestUri)
    {
      return new FhirRequestUri(PrimaryServiceRoot, RequestUri);
    }

    
    public static IDatabaseOperationOutcome GetDatabaseOperationOutcome()
    {
      return new DtoDatabaseOperationOutcome();
    }

    public static IResourceServiceRequestGetRead GetResourceServiceRequestGetRead(string ResourceId, IDtoRequestUri DtoRequestUri, IDtoSearchParameterGeneric DtoSearchParameterGeneric, IDtoRequestHeaders RequestHeaders)
    {
      return new ResourceServiceRequestGetRead(ResourceId, DtoRequestUri, DtoSearchParameterGeneric, RequestHeaders);
    }

    public static IResourceServiceRequestGetSearch GetResourceServiceRequestGetSearch(IDtoRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric DtoSearchParameterGeneric)
    {
      return new ResourceServiceRequestGetSearch(DtoFhirRequestUri, DtoSearchParameterGeneric);
    }

    public static IResourceServiceRequestGetHistory GetResourceServiceRequestGetHistory(string FhirId, string Vid, IDtoRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric DtoSearchParameterGeneric)
    {
      return new ResourceServiceRequestGetHistory(FhirId, Vid, DtoFhirRequestUri, DtoSearchParameterGeneric);
    }

    public static IResourceServiceRequestPost GetResourceServiceRequestPost(Resource Resource, IDtoRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric DtoSearchParameterGeneric, IDtoRequestHeaders RequestHeaders)
    {
      return new ResourceServiceRequestPost(Resource, DtoFhirRequestUri, DtoSearchParameterGeneric, RequestHeaders);
    }

    public static IResourceServiceRequestPost GetResourceServiceRequestPost(Resource Resource, IDtoRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric DtoSearchParameterGeneric, IDtoRequestHeaders RequestHeaders, string ForceId)
    {
      return new ResourceServiceRequestPost(Resource, DtoFhirRequestUri, DtoSearchParameterGeneric, RequestHeaders, ForceId);
    }

    public static IResourceServiceRequestPost GetResourceServiceRequestPost(Resource Resource, IDtoRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric DtoSearchParameterGeneric)
    {
      return new ResourceServiceRequestPost(Resource, DtoFhirRequestUri, DtoSearchParameterGeneric);
    }

    public static IResourceServiceRequestPut GetResourceServiceRequestPut(string id, Resource Resource, IDtoRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric DtoSearchParameterGeneric, IDtoRequestHeaders RequestHeaders)
    {
      return new ResourceServiceRequestPut(id, Resource, DtoFhirRequestUri, DtoSearchParameterGeneric, RequestHeaders);
    }

    public static IResourceServiceRequestConditionalPut GetResourceServiceRequestConditionalPut(Resource Resource, IDtoRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric DtoSearchParameterGeneric)
    {
      return new ResourceServiceRequestConditionalPut(Resource, DtoFhirRequestUri, DtoSearchParameterGeneric);
    }

    public static IResourceServiceRequestDelete GetResourceServiceRequestDelete(string id, IDtoRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric DtoSearchParameterGeneric)
    {
      return new ResourceServiceRequestDelete(id, DtoFhirRequestUri, DtoSearchParameterGeneric);
    }

    public static IResourceServiceRequestConditionalDelete GetResourceServiceRequestConditionalDelete(IDtoRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric DtoSearchParameterGeneric)
    {
      return new ResourceServiceRequestConditionalDelete(DtoFhirRequestUri, DtoSearchParameterGeneric);
    }

    public static IResourceServiceRequestMetadata GetResourceServiceRequestMetadata(string ApplicationVersion, IDtoRootUrlStore RootUrl, IDtoSearchParameterGeneric DtoSearchParameterGeneric, ICommonServices CommonServices)
    {
      return new ResourceServiceRequestMetadata(ApplicationVersion, RootUrl, DtoSearchParameterGeneric, CommonServices);
    }

    public static IResourceServiceRequestTransactionBundle GetResourceServiceRequestTransactionBundle(Resource Resource, IDtoRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric DtoSearchParameterGeneric, IDtoRequestHeaders RequestHeaders, IServiceNegotiator ServiceNegotiator)
    {
      return new ResourceServiceRequestTransactionBundle(Resource, DtoFhirRequestUri, DtoSearchParameterGeneric, RequestHeaders, ServiceNegotiator);
    }
    
    public static IApplicationCacheSupport GetApplicationCacheService()
    {
      return new Tools.ApplicationCacheSupport();
    }

    public static IDtoSearchParameterGeneric GetDtoSearchParameterGeneric()
    {
      return new BusinessEntities.Search.DtoSearchParameterGeneric();
    }

    public static IDtoSearchParameterGeneric GetDtoSearchParameterGeneric(SearchParams SearchParams)
    {
      return new BusinessEntities.Search.DtoSearchParameterGeneric(SearchParams);
    }

    public static IDtoSearchParameterGeneric GetDtoSearchParameterGeneric(string SearchParamsString)
    {
      return new BusinessEntities.Search.DtoSearchParameterGeneric(SearchParamsString);
    }

    public static ISearchParametersServiceRequest GetSearchParametersServiceRequest()
    {
      return new SearchParametersServiceRequest();
    }

    public static ISearchParametersServiceOutcome GetSearchParametersServiceOutcome()
    {
      return new SearchParametersServiceOutcome();
    }

    public static IDtoRequestHeaders GetDtoRequestHeaders(Bundle.RequestComponent RequestComponent)
    {
      return new BusinessEntities.Dto.Headers.DtoRequestHeaders(RequestComponent);
    }

    public static IDtoRequestHeaders GetDtoRequestHeaders(System.Net.Http.Headers.HttpRequestHeaders HttpRequestHeaders)
    {
      return new BusinessEntities.Dto.Headers.DtoRequestHeaders(HttpRequestHeaders);
    }

    public static IFhirNarativeGenerationSupport GetFhirNarativeSupport()
    {
      return new Tools.FhirNarativeGenerationSupport();
    }

    public static IBundleTransactionService GetBundleTransactionService(IResourceServiceRequestTransactionBundle ResourceServiceRequestTransactionBundle)
    {
      return new BundleTransactionService(ResourceServiceRequestTransactionBundle);
    }

    public static IResourceOperationsServiceRequest GetResourceOperationsServiceRequest(string OperationName, Resource ParametersResource, IResourceServices ResourceServices, IDtoRequestUri FhirRequestUri, IDtoSearchParameterGeneric SearchParameterGeneric, IDtoRequestHeaders RequestHeaders)
    {
      return new ResourceOperationsServiceRequest(OperationName, ParametersResource, ResourceServices, FhirRequestUri, SearchParameterGeneric, RequestHeaders);
    }

    public static IBaseOperationsServiceRequest GetBaseOperationsServiceRequest(string OperationName, Resource ParametersResource, IServiceNegotiator ServiceNegotiator, IDtoRequestUri FhirRequestUri, IDtoSearchParameterGeneric SearchParameterGeneric, IDtoRequestHeaders RequestHeaders)
    {
      return new BaseOperationsServiceRequest(OperationName, ParametersResource, ServiceNegotiator, FhirRequestUri, SearchParameterGeneric, RequestHeaders);
    }

    public static IResourceServiceDeleteHistoryIndexesRequest GetResourceServiceDeleteHistoryIndexesRequest()
    {
      return new ResourceServiceDeleteHistoryIndexesRequest();
    }
    
  }
}

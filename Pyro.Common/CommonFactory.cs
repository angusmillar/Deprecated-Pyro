using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Enum;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.Tools;
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
    public static IFhirUri GetFhirUri(string value)
    {
      return new DtoFhirUri(value);
    }

    public static IFhirUri GetFhirUri(Uri value)
    {
      return new DtoFhirUri(value);
    }

    public static IDtoFhirRequestUri GetFhirRequestUri()
    {
      return new DtoFhirRequestUri();
    }

    public static IDtoFhirRequestUri GetFhirRequestUri(IDtoRootUrlStore PrimaryRootUrlStore)
    {
      return new DtoFhirRequestUri(PrimaryRootUrlStore);
    }

    public static IDtoFhirRequestUri GetFhirRequestUri(IDtoRootUrlStore PrimaryRootUrlStore, IFhirUri RequestUri)
    {
      return new DtoFhirRequestUri(PrimaryRootUrlStore, RequestUri);
    }

    public static IDtoRootUrlStore GetRootUrlStore()
    {
      return new DtoRootUrlStore();
    }

    public static IResourceServiceOutcome GetServiceOperationOutcome()
    {
      return new ResourceServiceOutcome();
    }

    public static IDatabaseOperationOutcome GetDatabaseOperationOutcome()
    {
      return new DtoDatabaseOperationOutcome();
    }

    public static IResourceServiceRequestGetRead GetResourceServiceRequestGetRead(string ResourceId, IDtoFhirRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric DtoSearchParameterGeneric, IDtoRequestHeaders RequestHeaders)
    {
      return new ResourceServiceRequestGetRead(ResourceId, DtoFhirRequestUri, DtoSearchParameterGeneric, RequestHeaders);
    }

    public static IResourceServiceRequestGetSearch GetResourceServiceRequestGetSearch(IDtoFhirRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric DtoSearchParameterGeneric)
    {
      return new ResourceServiceRequestGetSearch(DtoFhirRequestUri, DtoSearchParameterGeneric);
    }

    public static IResourceServiceRequestGetHistory GetResourceServiceRequestGetHistory(string FhirId, string Vid, IDtoFhirRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric DtoSearchParameterGeneric)
    {
      return new ResourceServiceRequestGetHistory(FhirId, Vid, DtoFhirRequestUri, DtoSearchParameterGeneric);
    }

    public static IResourceServiceRequestPost GetResourceServiceRequestPost(Resource Resource, IDtoFhirRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric DtoSearchParameterGeneric, IDtoRequestHeaders RequestHeaders)
    {
      return new ResourceServiceRequestPost(Resource, DtoFhirRequestUri, DtoSearchParameterGeneric, RequestHeaders);
    }

    public static IResourceServiceRequestPost GetResourceServiceRequestPost(Resource Resource, IDtoFhirRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric DtoSearchParameterGeneric, IDtoRequestHeaders RequestHeaders, string ForceId)
    {
      return new ResourceServiceRequestPost(Resource, DtoFhirRequestUri, DtoSearchParameterGeneric, RequestHeaders, ForceId);
    }

    public static IResourceServiceRequestPost GetResourceServiceRequestPost(Resource Resource, IDtoFhirRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric DtoSearchParameterGeneric)
    {
      return new ResourceServiceRequestPost(Resource, DtoFhirRequestUri, DtoSearchParameterGeneric);
    }

    public static IResourceServiceRequestPut GetResourceServiceRequestPut(string id, Resource Resource, IDtoFhirRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric DtoSearchParameterGeneric, IDtoRequestHeaders RequestHeaders)
    {
      return new ResourceServiceRequestPut(id, Resource, DtoFhirRequestUri, DtoSearchParameterGeneric, RequestHeaders);
    }

    public static IResourceServiceRequestConditionalPut GetResourceServiceRequestConditionalPut(Resource Resource, IDtoFhirRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric DtoSearchParameterGeneric)
    {
      return new ResourceServiceRequestConditionalPut(Resource, DtoFhirRequestUri, DtoSearchParameterGeneric);
    }

    public static IResourceServiceRequestDelete GetResourceServiceRequestDelete(string id, IDtoFhirRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric DtoSearchParameterGeneric)
    {
      return new ResourceServiceRequestDelete(id, DtoFhirRequestUri, DtoSearchParameterGeneric);
    }

    public static IResourceServiceRequestConditionalDelete GetResourceServiceRequestConditionalDelete(IDtoFhirRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric DtoSearchParameterGeneric)
    {
      return new ResourceServiceRequestConditionalDelete(DtoFhirRequestUri, DtoSearchParameterGeneric);
    }

    public static IResourceServiceRequestMetadata GetResourceServiceRequestMetadata(string ApplicationVersion, IDtoRootUrlStore RootUrl, IDtoSearchParameterGeneric DtoSearchParameterGeneric)
    {
      return new ResourceServiceRequestMetadata(ApplicationVersion, RootUrl, DtoSearchParameterGeneric);
    }

    public static IResourceServiceRequestTransactionBundle GetResourceServiceRequestTransactionBundle(Resource Resource, IDtoFhirRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric DtoSearchParameterGeneric, IDtoRequestHeaders RequestHeaders, IServiceNegotiator ServiceNegotiator)
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
  }
}

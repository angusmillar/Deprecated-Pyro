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
using Pyro.Common.BusinessEntities.FhirOperation;

namespace Pyro.Common
{
  public static class CommonFactory
  {
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

    public static IDtoRequestHeaders GetDtoRequestHeaders()
    {
      return new BusinessEntities.Dto.Headers.DtoRequestHeaders();
    }

    public static IDtoRequestHeaders GetDtoRequestHeaders(Bundle.RequestComponent RequestComponent)
    {
      var IDtoRequestHeaders = new BusinessEntities.Dto.Headers.DtoRequestHeaders();
      IDtoRequestHeaders.Parse(RequestComponent);
      return IDtoRequestHeaders;
    }

    public static IDtoRequestHeaders GetDtoRequestHeaders(System.Net.Http.Headers.HttpRequestHeaders HttpRequestHeaders)
    {
      var IDtoRequestHeaders = new BusinessEntities.Dto.Headers.DtoRequestHeaders();
      IDtoRequestHeaders.Parse(HttpRequestHeaders);
      return IDtoRequestHeaders;
    }

    public static IFhirNarativeGenerationSupport GetFhirNarativeSupport()
    {
      return new Tools.FhirNarativeGenerationSupport();
    }


  }
}

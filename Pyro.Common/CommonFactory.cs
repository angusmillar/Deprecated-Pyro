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
using Pyro.Common.Interfaces;
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

    public static IDtoRootUrlStore GetRootUrlStore()
    {
      return new DtoRootUrlStore();
    }

    public static IResourceServiceOutcome GetPyroServiceOperationOutcome()
    {
      return new ResourceServiceOutcome();
    }

    public static IDatabaseOperationOutcome GetDatabaseOperationOutcome()
    {
      return new DtoDatabaseOperationOutcome();
    }

    public static IResourceServiceRequest GetResourceServiceRequest(ServiceEnums.ServiceRequestType ServiceRequestType, IDtoSearchParameterGeneric DtoSearchParameterGeneric)
    {
      return new ResourceServiceRequest(ServiceRequestType, DtoSearchParameterGeneric);
    }

    public static IResourceServiceRequest GetResourceServiceRequest(ServiceEnums.ServiceRequestType ServiceRequestType, string id, IDtoFhirRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric DtoSearchParameterGeneric)
    {
      return new ResourceServiceRequest(ServiceRequestType, id, DtoFhirRequestUri, DtoSearchParameterGeneric);
    }

    public static IResourceServiceRequest GetResourceServiceRequest(ServiceEnums.ServiceRequestType ServiceRequestType, string id, Resource Resource, IDtoFhirRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric DtoSearchParameterGeneric)
    {
      return new ResourceServiceRequest(ServiceRequestType, id, Resource, DtoFhirRequestUri, DtoSearchParameterGeneric);
    }

    public static IResourceServiceRequest GetResourceServiceRequest(ServiceEnums.ServiceRequestType ServiceRequestType, Resource Resource, IDtoFhirRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric DtoSearchParameterGeneric)
    {
      return new ResourceServiceRequest(ServiceRequestType, Resource, DtoFhirRequestUri, DtoSearchParameterGeneric);
    }

    public static IResourceServiceRequest GetResourceServiceRequest(ServiceEnums.ServiceRequestType ServiceRequestType, IDtoFhirRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric DtoSearchParameterGeneric)
    {
      return new ResourceServiceRequest(ServiceRequestType, DtoFhirRequestUri, DtoSearchParameterGeneric);
    }

    public static IResourceServiceRequest GetResourceServiceRequest(ServiceEnums.ServiceRequestType ServiceRequestType, string FhirId, string Vid, IDtoFhirRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric DtoSearchParameterGeneric)
    {
      return new ResourceServiceRequest(ServiceRequestType, FhirId, Vid, DtoFhirRequestUri, DtoSearchParameterGeneric);
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

  }
}

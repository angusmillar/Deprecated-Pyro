using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Enum;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Service;
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

    public static IResourceServiceRequest GetResourceServiceRequest(ServiceEnums.ServiceRequestType ServiceRequestType, SearchParams SearchParams)
    {
      return new ResourceServiceRequest(ServiceRequestType, SearchParams);
    }

    public static IResourceServiceRequest GetResourceServiceRequest(ServiceEnums.ServiceRequestType ServiceRequestType, string id, IDtoFhirRequestUri DtoFhirRequestUri, SearchParams SearchParams)
    {
      return new ResourceServiceRequest(ServiceRequestType, id, DtoFhirRequestUri, SearchParams);
    }

    public static IResourceServiceRequest GetResourceServiceRequest(ServiceEnums.ServiceRequestType ServiceRequestType, string id, Resource Resource, IDtoFhirRequestUri DtoFhirRequestUri, SearchParams SearchParams)
    {
      return new ResourceServiceRequest(ServiceRequestType, id, Resource, DtoFhirRequestUri, SearchParams);
    }

    public static IResourceServiceRequest GetResourceServiceRequest(ServiceEnums.ServiceRequestType ServiceRequestType, Resource Resource, IDtoFhirRequestUri DtoFhirRequestUri, SearchParams SearchParams)
    {
      return new ResourceServiceRequest(ServiceRequestType, Resource, DtoFhirRequestUri, SearchParams);
    }

    public static IResourceServiceRequest GetResourceServiceRequest(ServiceEnums.ServiceRequestType ServiceRequestType, IDtoFhirRequestUri DtoFhirRequestUri, SearchParams SearchParams)
    {
      return new ResourceServiceRequest(ServiceRequestType, DtoFhirRequestUri, SearchParams);
    }

    public static IResourceServiceRequest GetResourceServiceRequest(ServiceEnums.ServiceRequestType ServiceRequestType, string FhirId, string Vid, IDtoFhirRequestUri DtoFhirRequestUri, SearchParams SearchParams)
    {
      return new ResourceServiceRequest(ServiceRequestType, FhirId, Vid, DtoFhirRequestUri, SearchParams);
    }


  }
}

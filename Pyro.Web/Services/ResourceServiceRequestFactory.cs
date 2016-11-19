using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Enum;
using Pyro.Common.Interfaces.UriSupport;
using Hl7.Fhir.Rest;

namespace Pyro.Web.Services
{
  public static class ResourceServiceRequestFactory
  {

    public static IResourceServiceRequest Create(ServiceEnums.ServiceRequestType ServiceRequestType, SearchParams SearchParams)
    {
      return new ResourceServiceRequest(ServiceRequestType, SearchParams);
    }


    public static IResourceServiceRequest Create(ServiceEnums.ServiceRequestType ServiceRequestType, string id, IDtoFhirRequestUri DtoFhirRequestUri, SearchParams SearchParams)
    {
      return new ResourceServiceRequest(ServiceRequestType, id, DtoFhirRequestUri, SearchParams);
    }

    public static IResourceServiceRequest Create(ServiceEnums.ServiceRequestType ServiceRequestType, string id, Resource Resource, IDtoFhirRequestUri DtoFhirRequestUri, SearchParams SearchParams)
    {
      return new ResourceServiceRequest(ServiceRequestType, id, Resource, DtoFhirRequestUri, SearchParams);
    }

    public static IResourceServiceRequest Create(ServiceEnums.ServiceRequestType ServiceRequestType, Resource Resource, IDtoFhirRequestUri DtoFhirRequestUri, SearchParams SearchParams)
    {
      return new ResourceServiceRequest(ServiceRequestType, Resource, DtoFhirRequestUri, SearchParams);
    }

    public static IResourceServiceRequest Create(ServiceEnums.ServiceRequestType ServiceRequestType, IDtoFhirRequestUri DtoFhirRequestUri, SearchParams SearchParams)
    {
      return new ResourceServiceRequest(ServiceRequestType, DtoFhirRequestUri, SearchParams);
    }

    public static IResourceServiceRequest Create(ServiceEnums.ServiceRequestType ServiceRequestType, string FhirId, string Vid, IDtoFhirRequestUri DtoFhirRequestUri, SearchParams SearchParams)
    {
      return new ResourceServiceRequest(ServiceRequestType, FhirId, Vid, DtoFhirRequestUri, SearchParams);
    }


  }
}

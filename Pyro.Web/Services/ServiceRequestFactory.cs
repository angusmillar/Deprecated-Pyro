using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.Services;
using Pyro.Common.Enum;
using Pyro.Common.Interfaces.UriSupport;
using Hl7.Fhir.Rest;

namespace Pyro.Web.Services
{
  public static class ServiceRequestFactory
  {

    public static IServiceRequest Create(ServiceEnums.ServiceRequestType ServiceRequestType, string id)
    {
      return new ServiceRequest(ServiceRequestType, id);
    }

    public static IServiceRequest Create(ServiceEnums.ServiceRequestType ServiceRequestType, string id, Resource Resource, IDtoFhirRequestUri DtoFhirRequestUri)
    {
      return new ServiceRequest(ServiceRequestType, id, Resource, DtoFhirRequestUri);
    }

    public static IServiceRequest Create(ServiceEnums.ServiceRequestType ServiceRequestType, Resource Resource, IDtoFhirRequestUri DtoFhirRequestUri)
    {
      return new ServiceRequest(ServiceRequestType, Resource, DtoFhirRequestUri);
    }

    public static IServiceRequest Create(ServiceEnums.ServiceRequestType ServiceRequestType, IDtoFhirRequestUri DtoFhirRequestUri, SearchParams SearchParams)
    {
      return new ServiceRequest(ServiceRequestType, DtoFhirRequestUri, SearchParams);
    }

    public static IServiceRequest Create(ServiceEnums.ServiceRequestType ServiceRequestType, string FhirId, string Vid, IDtoFhirRequestUri DtoFhirRequestUri, SearchParams SearchParams)
    {
      return new ServiceRequest(ServiceRequestType, FhirId, Vid, DtoFhirRequestUri, SearchParams);
    }


  }
}

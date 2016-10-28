using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.Services;
using Pyro.Common.Interfaces.UriSupport;
using Hl7.Fhir.Rest;

namespace Pyro.Web.Services
{
  public static class PyroServiceRequestFactory
  {
    public static IPyroServiceRequest Create(string id, Resource Resource, IDtoFhirRequestUri DtoFhirRequestUri)
    {
      return new PyroServiceRequest(id, Resource, DtoFhirRequestUri);
    }

    public static IPyroServiceRequest Create(Resource Resource, IDtoFhirRequestUri DtoFhirRequestUri)
    {
      return new PyroServiceRequest(Resource, DtoFhirRequestUri);
    }

    public static IPyroServiceRequest Create(IDtoFhirRequestUri DtoFhirRequestUri, SearchParams SearchParams)
    {
      return new PyroServiceRequest(DtoFhirRequestUri, SearchParams);
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Blaze.Common.Interfaces.Services;
using Blaze.Common.Interfaces.UriSupport;

namespace Blaze.Web.BlazeService
{
  public static class BlazeServiceRequestFactory
  {
    public static IBlazeServiceRequest Create(string id, Resource Resource, IDtoFhirRequestUri DtoFhirRequestUri)
    {
      return new Blaze.Web.BlazeService.BlazeServiceRequest(id, Resource, DtoFhirRequestUri);
    }
    public static IBlazeServiceRequest Create(Resource Resource, IDtoFhirRequestUri DtoFhirRequestUri)
    {
      return new Blaze.Web.BlazeService.BlazeServiceRequest(Resource, DtoFhirRequestUri);
    }
  }
}

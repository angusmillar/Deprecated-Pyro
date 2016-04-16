using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Common.Interfaces.Services;

namespace Blaze.BlazeService
{
  public static class BlazeServiceRequestFactory
  {
    public static IBlazeServiceRequest Create(string id, Resource Resource, Uri RequestUri)
    {
      return new Blaze.BlazeService.BlazeServiceRequest(id, Resource, RequestUri);
    }
    public static IBlazeServiceRequest Create(Resource Resource, Uri RequestUri)
    {
      return new Blaze.BlazeService.BlazeServiceRequest(Resource, RequestUri);
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Common.Interfaces.Services;

namespace Blaze.BlazeService
{
  public class BlazeServiceRequest : IBlazeServiceRequest
  {
    public string ResourceId { get; set; }
    public Resource Resource { get; set; }
    public Uri RequestUri { get; set; }

    public BlazeServiceRequest(string ResourceId, Resource Resource, Uri RequestUri)
    {
      this.ResourceId = ResourceId;
      this.Resource = Resource;
      this.RequestUri = RequestUri;
    }

    public BlazeServiceRequest(Resource Resource, Uri RequestUri)
    {
      this.ResourceId = null;
      this.Resource = Resource;
      this.RequestUri = RequestUri;
    }
  }
}

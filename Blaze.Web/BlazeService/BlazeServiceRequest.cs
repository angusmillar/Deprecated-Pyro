using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Blaze.Common.Interfaces.Services;
using Blaze.Common.Interfaces.FhirUri;

namespace Blaze.Web.BlazeService
{
  public class BlazeServiceRequest : IBlazeServiceRequest
  {
    public string ResourceId { get; set; }
    public Resource Resource { get; set; }
    public IFhirUri RequestFhirUri { get; set; }

    public BlazeServiceRequest(string ResourceId, Resource Resource, IFhirUri RequestFhirUri)
    {
      this.ResourceId = ResourceId;
      this.Resource = Resource;
      this.RequestFhirUri = RequestFhirUri;
    }

    public BlazeServiceRequest(Resource Resource, IFhirUri RequestFhirUri)
    {
      this.ResourceId = null;
      this.Resource = Resource;
      this.RequestFhirUri = RequestFhirUri;
    }
  }
}

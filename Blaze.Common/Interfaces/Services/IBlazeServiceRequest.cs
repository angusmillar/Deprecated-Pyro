using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Blaze.Common.Interfaces.FhirUri;

namespace Blaze.Common.Interfaces.Services
{
  public interface IBlazeServiceRequest
  {
    string ResourceId { get; set; }
    Resource Resource { get; set; }
    IFhirUri RequestFhirUri { get; set; }
  }
}

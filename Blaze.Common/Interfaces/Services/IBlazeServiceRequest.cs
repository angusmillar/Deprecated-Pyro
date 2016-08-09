using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Blaze.Common.Interfaces.UriSupport;

namespace Blaze.Common.Interfaces.Services
{
  public interface IBlazeServiceRequest
  {
    string ResourceId { get; set; }
    Resource Resource { get; set; }
    IDtoFhirRequestUri FhirRequestUri { get; set; }
    SearchParams SearchParams { get; set; }

  }
}

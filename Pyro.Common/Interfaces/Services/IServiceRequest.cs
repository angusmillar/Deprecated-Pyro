using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Pyro.Common.Enum;
using Pyro.Common.Interfaces.UriSupport;

namespace Pyro.Common.Interfaces.Services
{
  public interface IServiceRequest
  {
    ServiceEnums.ServiceRequestType ServiceRequestType { get; set;}
    string ResourceId { get; set; }
    string VersionId { get; set; }
    Resource Resource { get; set; }
    IDtoFhirRequestUri FhirRequestUri { get; set; }
    SearchParams SearchParams { get; set; }

  }
}

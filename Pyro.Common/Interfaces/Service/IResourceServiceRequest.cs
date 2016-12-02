using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Pyro.Common.Enum;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Interfaces.Dto;

namespace Pyro.Common.Interfaces.Service
{
  public interface IResourceServiceRequest
  {
    ServiceEnums.ServiceRequestType ServiceRequestType { get; set;}
    string ResourceId { get; set; }
    string VersionId { get; set; }
    Resource Resource { get; set; }
    IDtoFhirRequestUri FhirRequestUri { get; set; }    
    IDtoSearchParameterGeneric SearchParameterGeneric { get; set; }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Dto.Headers;

namespace Pyro.Common.Interfaces.Service
{
  public interface IResourceServiceRequestPut
  {    
    string ResourceId { get; set; }    
    Resource Resource { get; set; }
    IDtoRequestUri RequestUri { get; set; }
    IDtoSearchParameterGeneric SearchParameterGeneric { get; set; }
    IDtoRequestHeaders RequestHeaders { get; set; }
  }
}

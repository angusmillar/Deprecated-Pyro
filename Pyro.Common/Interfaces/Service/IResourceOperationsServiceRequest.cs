﻿using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Dto.Headers;
using Pyro.Common.Interfaces.UriSupport;

namespace Pyro.Common.Interfaces.Service
{
  public interface IResourceOperationsServiceRequest
  {    
    string OperationName { get; set; }
    Resource Resource { get; set; }
    IResourceServices ResourceServices { get; set; }
    IDtoFhirRequestUri FhirRequestUri { get; set; }
    IDtoSearchParameterGeneric SearchParameterGeneric { get; set; }
    IDtoRequestHeaders RequestHeaders { get; set; }
  }
}
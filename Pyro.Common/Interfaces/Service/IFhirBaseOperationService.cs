using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Dto.Headers;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.UriSupport;

namespace Pyro.Common.Interfaces.Service
{
  public interface IFhirBaseOperationService
  {
    IResourceServiceOutcome Process(string OperationName, IDtoRequestUri RequestUri, IDtoSearchParameterGeneric SearchPrameterGeneric, IDtoRequestHeaders RequestHeaders, Resource Resource);
  }
}
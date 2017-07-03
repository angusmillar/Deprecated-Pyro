using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.UriSupport;

namespace Pyro.Common.Interfaces.Service
{
  public interface IServerSearchParameterService
  {
    IResourceServiceOutcome ProcessSet(IDtoRequestUri RequestUri, IDtoSearchParameterGeneric SearchParameterGeneric, Resource Resource);
    IResourceServiceOutcome ProcessReport(IDtoRequestUri RequestUri, IDtoSearchParameterGeneric SearchParameterGeneric, Resource Resource);
    IResourceServiceOutcome ProcessIndex(IDtoRequestUri RequestUri, IDtoSearchParameterGeneric SearchParameterGeneric, Resource Resource);
  }
}
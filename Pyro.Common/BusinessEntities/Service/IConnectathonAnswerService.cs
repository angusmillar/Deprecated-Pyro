using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.UriSupport;

namespace Pyro.Common.BusinessEntities.Service
{
  public interface IConnectathonAnswerService
  {
    IResourceServiceOutcome Process(IDtoRequestUri RequestUri, IDtoSearchParameterGeneric SearchParameterGeneric, Resource Resource);
  }
}
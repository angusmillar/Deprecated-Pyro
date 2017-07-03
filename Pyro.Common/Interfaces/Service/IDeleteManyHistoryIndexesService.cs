using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.UriSupport;

namespace Pyro.Common.Interfaces.Service
{
  public interface IDeleteHistoryIndexesService
  {
    IResourceServiceOutcome DeleteMany(
      IDtoRequestUri RequestUri,
      IDtoSearchParameterGeneric SearchParameterGeneric,
      Resource Resource);

    IResourceServiceOutcome DeleteSingle(
      IDtoRequestUri RequestUri,
      IDtoSearchParameterGeneric SearchParameterGeneric);
  }
}
using Hl7.Fhir.Model;
using Pyro.Common.Search;
using Pyro.Common.Tools.UriSupport;

namespace Pyro.Common.Service
{
  public interface IDeleteHistoryIndexesService
  {
    IResourceServiceOutcome DeleteMany(
      IPyroRequestUri RequestUri,
      ISearchParameterGeneric SearchParameterGeneric,
      Resource Resource);

    IResourceServiceOutcome DeleteSingle(
      IPyroRequestUri RequestUri,
      ISearchParameterGeneric SearchParameterGeneric);
  }
}
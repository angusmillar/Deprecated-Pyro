using Hl7.Fhir.Model;
using Pyro.Common.Search;
using Pyro.Common.Service.ResourceService;
using Pyro.Common.Tools.UriSupport;

namespace Pyro.Common.FhirOperation.DeleteHistoryIndexes
{
  public interface IDeleteHistoryIndexesOperation
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
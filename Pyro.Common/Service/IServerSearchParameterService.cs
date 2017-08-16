using Hl7.Fhir.Model;
using Pyro.Common.Search;
using Pyro.Common.Tools.UriSupport;

namespace Pyro.Common.Service
{
  public interface IServerSearchParameterService
  {
    IResourceServiceOutcome ProcessSet(IPyroRequestUri RequestUri, ISearchParameterGeneric SearchParameterGeneric, Resource Resource);
    IResourceServiceOutcome ProcessReport(IPyroRequestUri RequestUri, ISearchParameterGeneric SearchParameterGeneric, Resource Resource);
    IResourceServiceOutcome ProcessIndex(IPyroRequestUri RequestUri, ISearchParameterGeneric SearchParameterGeneric, Resource Resource);
  }
}
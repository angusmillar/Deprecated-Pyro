using Hl7.Fhir.Model;
using Pyro.Common.Search;
using Pyro.Common.Service.ResourceService;
using Pyro.Common.Tools.UriSupport;

namespace Pyro.Common.FhirOperation.ServerSearchParameter
{
  public interface IServerSearchParameterOperation
  {
    IResourceServiceOutcome ProcessSet(IPyroRequestUri RequestUri, ISearchParameterGeneric SearchParameterGeneric, Resource Resource);
    IResourceServiceOutcome ProcessReport(IPyroRequestUri RequestUri, ISearchParameterGeneric SearchParameterGeneric, Resource Resource);
    IResourceServiceOutcome ProcessIndex(IPyroRequestUri RequestUri, ISearchParameterGeneric SearchParameterGeneric, Resource Resource);
  }
}
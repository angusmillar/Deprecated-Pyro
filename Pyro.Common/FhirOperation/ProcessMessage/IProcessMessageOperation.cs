using Hl7.Fhir.Model;
using Pyro.Common.Search;
using Pyro.Common.Service.ResourceService;
using Pyro.Common.Tools.UriSupport;

namespace Pyro.Common.FhirOperation.ProcessMessage
{
  public interface IProcessMessageOperation
  {
    IResourceServiceOutcome Process(IPyroRequestUri RequestUri, ISearchParameterGeneric SearchParameterGeneric, Resource Resource);
  }
}
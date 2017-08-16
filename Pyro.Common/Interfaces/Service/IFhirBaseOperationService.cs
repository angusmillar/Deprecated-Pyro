using Hl7.Fhir.Model;
using Pyro.Common.Search;
using Pyro.Common.Tools.Headers;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.Service;

namespace Pyro.Common.Interfaces.Service
{
  public interface IFhirBaseOperationService
  {
    IResourceServiceOutcome Process(string OperationName, IPyroRequestUri RequestUri, ISearchParameterGeneric SearchPrameterGeneric, IRequestHeader RequestHeaders, Resource Resource);
  }
}
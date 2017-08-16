using Hl7.Fhir.Model;
using Pyro.Common.Search;
using Pyro.Common.Tools.Headers;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.Service;

namespace Pyro.Common.Interfaces.Service
{
  public interface IFhirResourceInstanceOperationService
  {
    IResourceServiceOutcome Process(string OperationName, Resource Resource, IPyroRequestUri RequestUri, ISearchParameterGeneric SearchParameterGeneric, IRequestHeader RequestHeaders);
  }
}
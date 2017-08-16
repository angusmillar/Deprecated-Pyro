using Hl7.Fhir.Model;
using Pyro.Common.FhirOperation;
using Pyro.Common.Search;
using Pyro.Common.Tools.Headers;
using Pyro.Common.Tools.UriSupport;

namespace Pyro.Common.Service
{
  public interface IFhirValidateOperationService
  {
    IResourceServiceOutcome ValidateResource(
      OperationClass OperationClass,
      Resource Resource,
      IPyroRequestUri RequestUri,
      ISearchParameterGeneric SearchParameterGeneric,
      IRequestHeader RequestHeaders);

    IResourceServiceOutcome ValidateResourceInstance(
      OperationClass OperationClass,
      Resource Resource,
      IPyroRequestUri RequestUri,
      ISearchParameterGeneric SearchParameterGeneric,
      IRequestHeader RequestHeaders);
  }
}
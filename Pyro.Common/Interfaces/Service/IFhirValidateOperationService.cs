using Hl7.Fhir.Model;
using Pyro.Common.BusinessEntities.FhirOperation;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Dto.Headers;
using Pyro.Common.Interfaces.UriSupport;

namespace Pyro.Common.Interfaces.Service
{
  public interface IFhirValidateOperationService
  {
    IResourceServiceOutcome ValidateResource(
      OperationClass OperationClass,
      Resource Resource,
      IDtoRequestUri RequestUri,
      IDtoSearchParameterGeneric SearchParameterGeneric,
      IDtoRequestHeaders RequestHeaders);

    IResourceServiceOutcome ValidateResourceInstance(
      OperationClass OperationClass,
      Resource Resource,
      IDtoRequestUri RequestUri,
      IDtoSearchParameterGeneric SearchParameterGeneric,
      IDtoRequestHeaders RequestHeaders);
  }
}
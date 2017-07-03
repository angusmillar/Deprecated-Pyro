using Hl7.Fhir.Model;
using Pyro.Common.BusinessEntities.FhirOperation;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Service;

namespace Pyro.Common.BusinessEntities.Service
{
  public interface ISearchParameterService
  {
    ISearchParametersServiceOutcome ProcessResourceSearchParameters(
      IDtoSearchParameterGeneric SearchParameterGeneric,
      SearchParameterService.SearchParameterServiceType SearchParameterServiceType,
      FHIRAllTypes? ResourceType);

    ISearchParametersServiceOutcome ProcessOperationSearchParameters(
      IDtoSearchParameterGeneric SearchParameterGeneric,
      SearchParameterService.SearchParameterServiceType SearchParameterServiceType,
      OperationClass OperationClass);

    ISearchParametersServiceOutcome ProcessBaseSearchParameters(
      IDtoSearchParameterGeneric SearchParameterGeneric);

    ISearchParametersServiceOutcome ProcessBundleSearchParameters(
      IDtoSearchParameterGeneric SearchParameterGeneric);

    ISearchParametersServiceOutcome ProcessSearchParameters(
      IDtoSearchParameterGeneric SearchParameterGeneric,
      SearchParameterService.SearchParameterServiceType
      SearchParameterServiceType,
      FHIRAllTypes? ResourceType,
      OperationClass OperationClass);
  }
}
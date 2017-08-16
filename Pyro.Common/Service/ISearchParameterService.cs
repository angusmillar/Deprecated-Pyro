using Hl7.Fhir.Model;
using Pyro.Common.FhirOperation;
using Pyro.Common.Search;

namespace Pyro.Common.Service
{
  public interface ISearchParameterService
  {
    ISearchParametersServiceOutcome ProcessResourceSearchParameters(
      ISearchParameterGeneric SearchParameterGeneric,
      SearchParameterService.SearchParameterServiceType SearchParameterServiceType,
      FHIRAllTypes? ResourceType);

    ISearchParametersServiceOutcome ProcessOperationSearchParameters(
      ISearchParameterGeneric SearchParameterGeneric,
      SearchParameterService.SearchParameterServiceType SearchParameterServiceType,
      OperationClass OperationClass);

    ISearchParametersServiceOutcome ProcessBaseSearchParameters(
      ISearchParameterGeneric SearchParameterGeneric);

    ISearchParametersServiceOutcome ProcessBundleSearchParameters(
      ISearchParameterGeneric SearchParameterGeneric);

    ISearchParametersServiceOutcome ProcessSearchParameters(
      ISearchParameterGeneric SearchParameterGeneric,
      SearchParameterService.SearchParameterServiceType
      SearchParameterServiceType,
      FHIRAllTypes? ResourceType,
      OperationClass OperationClass);
  }
}
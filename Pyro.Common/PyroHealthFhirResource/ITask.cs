using Pyro.Common.PyroHealthFhirResource.Tasks;

namespace Pyro.Common.PyroHealthFhirResource
{
  public interface ITask
  {
    ILoadFhirSpecificationDefinitions LoadFhirSpecificationDefinitionsTask { get; }
    ISetCompartmentDefinitions SetCompartmentDefinitions { get; }
    ISetSearchParameterDefinitions SetSearchParameterDefinitions { get; }
    ISearchParameterIndexing SearchParameterIndexing { get; }
  }
}
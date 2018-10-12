using Pyro.Common.PyroHealthFhirResource.Tasks;

namespace Pyro.Common.PyroHealthFhirResource
{
  public class Task : ITask
  {
    private readonly ILoadFhirSpecificationDefinitions ILoadFhirSpecificationDefinitions;
    private readonly ISetCompartmentDefinitions ISetCompartmentDefinitions;
    private readonly ISetSearchParameterDefinitions ISetSearchParameterDefinitions;
    private readonly ISearchParameterIndexing ISearchParameterIndexing;

    public Task(ILoadFhirSpecificationDefinitions ILoadFhirSpecificationDefinitions,
      ISetCompartmentDefinitions ISetCompartmentDefinitions,
      ISetSearchParameterDefinitions ISetSearchParameterDefinitions,
      ISearchParameterIndexing ISearchParameterIndexing)
    {
      this.ILoadFhirSpecificationDefinitions = ILoadFhirSpecificationDefinitions;
      this.ISetCompartmentDefinitions = ISetCompartmentDefinitions;
      this.ISetSearchParameterDefinitions = ISetSearchParameterDefinitions;
      this.ISearchParameterIndexing = ISearchParameterIndexing;
    }

    public ILoadFhirSpecificationDefinitions LoadFhirSpecificationDefinitionsTask => ILoadFhirSpecificationDefinitions;
    public ISetCompartmentDefinitions SetCompartmentDefinitions => ISetCompartmentDefinitions;
    public ISetSearchParameterDefinitions SetSearchParameterDefinitions => ISetSearchParameterDefinitions;
    public ISearchParameterIndexing SearchParameterIndexing => ISearchParameterIndexing;
    

  }
}

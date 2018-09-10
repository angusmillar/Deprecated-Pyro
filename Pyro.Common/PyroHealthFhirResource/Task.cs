using Pyro.Common.PyroHealthFhirResource.Tasks;

namespace Pyro.Common.PyroHealthFhirResource
{
  public class Task : ITask
  {
    private readonly ILoadFhirSpecificationDefinitions ILoadFhirSpecificationDefinitions;
    private readonly ISetCompartmentDefinitions ISetCompartmentDefinitions;
    private readonly ISetSearchParameterDefinitions ISetSearchParameterDefinitions;

    public Task(ILoadFhirSpecificationDefinitions ILoadFhirSpecificationDefinitions,
      ISetCompartmentDefinitions ISetCompartmentDefinitions,
      ISetSearchParameterDefinitions ISetSearchParameterDefinitions)
    {
      this.ILoadFhirSpecificationDefinitions = ILoadFhirSpecificationDefinitions;
      this.ISetCompartmentDefinitions = ISetCompartmentDefinitions;
      this.ISetSearchParameterDefinitions = ISetSearchParameterDefinitions;
    }

    public ILoadFhirSpecificationDefinitions LoadFhirSpecificationDefinitionsTask => ILoadFhirSpecificationDefinitions;
    public ISetCompartmentDefinitions SetCompartmentDefinitions => ISetCompartmentDefinitions;
    public ISetSearchParameterDefinitions SetSearchParameterDefinitions => ISetSearchParameterDefinitions;

  }
}

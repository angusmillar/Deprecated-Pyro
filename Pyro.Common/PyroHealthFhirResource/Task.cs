using Pyro.Common.PyroHealthFhirResource.Tasks;

namespace Pyro.Common.PyroHealthFhirResource
{
  public class Task : ITask
  {
    private readonly ILoadFhirSpecificationDefinitions ILoadFhirSpecificationDefinitions;
    private readonly ISetCompartmentDefinitions ISetCompartmentDefinitions;

    public Task(ILoadFhirSpecificationDefinitions ILoadFhirSpecificationDefinitions,
      ISetCompartmentDefinitions ISetCompartmentDefinitions)
    {
      this.ILoadFhirSpecificationDefinitions = ILoadFhirSpecificationDefinitions;
      this.ISetCompartmentDefinitions = ISetCompartmentDefinitions;
    }

    public ILoadFhirSpecificationDefinitions LoadFhirSpecificationDefinitionsTask => ILoadFhirSpecificationDefinitions;
    public ISetCompartmentDefinitions SetCompartmentDefinitions => ISetCompartmentDefinitions;

  }
}

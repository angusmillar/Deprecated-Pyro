using Pyro.Common.PyroHealthFhirResource.Tasks;

namespace Pyro.Common.PyroHealthFhirResource
{
  public class Task : ITask
  {
    private readonly ILoadFhirSpecificationDefinitions ILoadFhirSpecificationDefinitions;

    public Task(ILoadFhirSpecificationDefinitions ILoadFhirSpecificationDefinitions)
    {
      this.ILoadFhirSpecificationDefinitions = ILoadFhirSpecificationDefinitions;
    }

    public ILoadFhirSpecificationDefinitions LoadFhirSpecificationDefinitionsTask => ILoadFhirSpecificationDefinitions;

  }
}

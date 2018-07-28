using Pyro.Common.PyroHealthFhirResource.Tasks;

namespace Pyro.Common.PyroHealthFhirResource
{
  public interface ITask
  {
    ILoadFhirSpecificationDefinitions LoadFhirSpecificationDefinitionsTask { get; }
  }
}
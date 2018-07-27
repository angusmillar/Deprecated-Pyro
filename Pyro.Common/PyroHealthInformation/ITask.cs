using Pyro.Common.PyroHealthInformation.Tasks;

namespace Pyro.Common.PyroHealthInformation
{
  public interface ITask
  {
    ILoadFhirSpecificationDefinitions LoadFhirSpecificationDefinitionsTask { get; }
  }
}
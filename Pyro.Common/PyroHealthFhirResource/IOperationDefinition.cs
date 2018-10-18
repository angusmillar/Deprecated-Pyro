using Pyro.Common.PyroHealthFhirResource.OperationDefinitions;

namespace Pyro.Common.PyroHealthFhirResource
{
  public interface IOperationDefinition
  {
    IServerIndexesSet ServerIndexesSet { get; }
    IServerIndexesIndex ServerIndexesIndex { get; }
  }
}
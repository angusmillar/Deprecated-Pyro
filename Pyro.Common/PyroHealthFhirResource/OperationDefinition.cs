using Pyro.Common.PyroHealthFhirResource.OperationDefinitions;
using Pyro.Common.PyroHealthFhirResource.Organizations;

namespace Pyro.Common.PyroHealthFhirResource
{
  public class OperationDefinition : IOperationDefinition
  {
    private readonly IServerIndexesSet IServerIndexesSet;
    private readonly IServerIndexesIndex IServerIndexesIndex;
    
    public OperationDefinition(IServerIndexesSet IServerIndexesSet, IServerIndexesIndex IServerIndexesIndex)
    {
      this.IServerIndexesSet = IServerIndexesSet;
      this.IServerIndexesIndex = IServerIndexesIndex;
    }
    public IServerIndexesSet ServerIndexesSet => IServerIndexesSet;
    public IServerIndexesIndex ServerIndexesIndex => IServerIndexesIndex;
    
  }
}

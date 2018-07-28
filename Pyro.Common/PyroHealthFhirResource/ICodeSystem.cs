using Pyro.Common.PyroHealthFhirResource.CodeSystems;

namespace Pyro.Common.PyroHealthFhirResource
{
  public interface ICodeSystem
  {
    IPyroFhirServer PyroFhirServerCodeSystem { get; }
    IPyroTask PyroTaskCodeSystem { get; }
    IPyroHealth PyroHealthCodeSystem { get; }
  }
}
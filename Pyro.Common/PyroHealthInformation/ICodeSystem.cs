using Pyro.Common.PyroHealthInformation.CodeSystems;

namespace Pyro.Common.PyroHealthInformation
{
  public interface ICodeSystem
  {
    IPyroFhirServer PyroFhirServerCodeSystem { get; }
    IPyroTask PyroTaskCodeSystem { get; }
    IPyroHealth PyroHealthCodeSystem { get; }
  }
}
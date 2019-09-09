using Pyro.Common.PyroHealthFhirResource.CodeSystems;

namespace Pyro.Common.PyroHealthFhirResource
{
  public interface ICodeSystem
  {
    IPyroFhirServer PyroFhirServerCodeSystem { get; }
    IPyroTask PyroTaskCodeSystem { get; }
    IPyroHealth PyroHealthCodeSystem { get; }
    IPyroHL7V2MessageTypeEvent PyroHL7V2MessageTypeEvent { get; }
  }
}
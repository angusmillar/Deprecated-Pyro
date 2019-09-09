using Pyro.Common.PyroHealthFhirResource.CodeSystems;

namespace Pyro.Common.PyroHealthFhirResource
{
  public class CodeSystem : ICodeSystem
  {
    private readonly IPyroFhirServer IPyroFhirServer;
    private readonly IPyroTask IPyroTask;
    private readonly IPyroHealth IPyroHealth;
    private readonly IPyroHL7V2MessageTypeEvent IPyroHL7V2MessageTypeEvent;
    

    public CodeSystem(IPyroFhirServer IPyroFhirServer, IPyroTask IPyroTask, IPyroHealth IPyroHealth, IPyroHL7V2MessageTypeEvent IPyroHL7V2MessageTypeEvent)
    {
      this.IPyroFhirServer = IPyroFhirServer;
      this.IPyroTask = IPyroTask;
      this.IPyroHealth = IPyroHealth;
      this.IPyroHL7V2MessageTypeEvent = IPyroHL7V2MessageTypeEvent;
    }

    public IPyroFhirServer PyroFhirServerCodeSystem => IPyroFhirServer;
    public IPyroTask PyroTaskCodeSystem => IPyroTask;
    public IPyroHealth PyroHealthCodeSystem => IPyroHealth;
    public IPyroHL7V2MessageTypeEvent PyroHL7V2MessageTypeEvent => IPyroHL7V2MessageTypeEvent;
  }
}

using Pyro.Common.PyroHealthFhirResource.CodeSystems;

namespace Pyro.Common.PyroHealthFhirResource
{
  public class CodeSystem : ICodeSystem
  {
    private readonly IPyroFhirServer IPyroFhirServer;
    private readonly IPyroTask IPyroTask;
    private readonly IPyroHealth IPyroHealth;

    public CodeSystem(IPyroFhirServer IPyroFhirServer, IPyroTask IPyroTask, IPyroHealth IPyroHealth)
    {
      this.IPyroFhirServer = IPyroFhirServer;
      this.IPyroTask = IPyroTask;
      this.IPyroHealth = IPyroHealth;
    }

    public IPyroFhirServer PyroFhirServerCodeSystem => IPyroFhirServer;
    public IPyroTask PyroTaskCodeSystem => IPyroTask;
    public IPyroHealth PyroHealthCodeSystem => IPyroHealth;    
  }
}

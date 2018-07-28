namespace Pyro.Common.PyroHealthFhirResource
{

  public class PyroFhirResource : IPyroFhirResource
  {

    private readonly IOrganization IOrganization;
    private readonly ICodeSystem ICodeSystem;
    private readonly ITask ITask;
    private readonly IDevice IDevice;

    public PyroFhirResource(IOrganization IOrganization, ICodeSystem ICodeSystem, ITask ITask, IDevice IDevice)
    {
      this.IOrganization = IOrganization;
      this.ICodeSystem = ICodeSystem;
      this.ITask = ITask;
      this.IDevice = IDevice;
    }
    
    public IOrganization Organization => IOrganization;
    public ICodeSystem CodeSystem => ICodeSystem;
    public ITask Task => ITask;
    public IDevice Device => IDevice;
  }
}

using System.Collections.Generic;
using Hl7.Fhir.Model;

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

    public IEnumerable<Resource> ResourceToLoadOnStartupList()
    {
      List<Resource> ResourceList = new List<Resource>();
      
      //Orginisation
      ResourceList.Add(IOrganization.PyroHealthOrganization.GetResource());
      
      //CodeSystem
      ResourceList.Add(ICodeSystem.PyroFhirServerCodeSystem.GetResource());
      ResourceList.Add(ICodeSystem.PyroHealthCodeSystem.GetResource());
      ResourceList.Add(ICodeSystem.PyroTaskCodeSystem.GetResource());
      
      //Device
      ResourceList.Add(IDevice.PyroFhirServerDevice.GetResource());
      
      //Task
      ResourceList.Add(ITask.LoadFhirSpecificationDefinitionsTask.GetResource());

      return ResourceList;      
    }
  }
}

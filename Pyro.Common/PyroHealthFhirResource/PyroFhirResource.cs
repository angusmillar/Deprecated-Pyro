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
    private readonly ICompartmentDefinition ICompartmentDefinition;

    public PyroFhirResource(IOrganization IOrganization, 
      ICodeSystem ICodeSystem, 
      ITask ITask, 
      IDevice IDevice,
      ICompartmentDefinition ICompartmentDefinition)
    {
      this.IOrganization = IOrganization;
      this.ICodeSystem = ICodeSystem;
      this.ITask = ITask;
      this.IDevice = IDevice;
      this.ICompartmentDefinition = ICompartmentDefinition;
    }
    
    public IOrganization Organization => IOrganization;
    public ICodeSystem CodeSystem => ICodeSystem;
    public ITask Task => ITask;
    public IDevice Device => IDevice;
    public ICompartmentDefinition CompartmentDefinition => ICompartmentDefinition;

    public IEnumerable<Resource> ResourceToLoadOnStartupList()
    {
      List<Resource> ResourceList = new List<Resource>();
      
      //Organisation
      ResourceList.Add(IOrganization.PyroHealthOrganization.GetResource());
      
      //CodeSystem
      ResourceList.Add(ICodeSystem.PyroFhirServerCodeSystem.GetResource());
      ResourceList.Add(ICodeSystem.PyroHealthCodeSystem.GetResource());
      ResourceList.Add(ICodeSystem.PyroTaskCodeSystem.GetResource());
      
      //Device
      ResourceList.Add(IDevice.PyroFhirServerDevice.GetResource());

      //Task
      ResourceList.Add(ITask.SetCompartmentDefinitions.GetResource());
      ResourceList.Add(ITask.LoadFhirSpecificationDefinitionsTask.GetResource());
      
      //Below is only used in development to load the specification search parameters into the database
      //We then extract them out and make SQL seed scripts to load on database creation. 
      //ResourceList.Add(ITask.SetSearchParameterDefinitions.GetResource());


      //CompartmentDefinition
      ResourceList.Add(ICompartmentDefinition.PyroCompartmentDefinitionEncounter.GetResource());
      ResourceList.Add(ICompartmentDefinition.PyroCompartmentDefinitionDevice.GetResource());
      ResourceList.Add(ICompartmentDefinition.PyroCompartmentDefinitionPatient.GetResource());
      ResourceList.Add(ICompartmentDefinition.PyroCompartmentDefinitionPractitioner.GetResource());
      ResourceList.Add(ICompartmentDefinition.PyroCompartmentDefinitionRelatedPerson.GetResource());

      return ResourceList;      
    }
  }
}

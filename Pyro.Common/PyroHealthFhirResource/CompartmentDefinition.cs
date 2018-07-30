using Pyro.Common.PyroHealthFhirResource.CompartmentDefinitions;

namespace Pyro.Common.PyroHealthFhirResource
{
  public class CompartmentDefinition : ICompartmentDefinition
  {
    public CompartmentDefinition(IPyroCompartmentDefinitionDevice IPyroCompartmentDefinitionDevice,
      IPyroCompartmentDefinitionEncounter IPyroCompartmentDefinitionEncounter,
      IPyroCompartmentDefinitionPatient IPyroCompartmentDefinitionPatient,
      IPyroCompartmentDefinitionPractitioner IPyroCompartmentDefinitionPractitioner,
      IPyroCompartmentDefinitionRelatedPerson IPyroCompartmentDefinitionRelatedPerson)
    {
      this.PyroCompartmentDefinitionDevice = IPyroCompartmentDefinitionDevice;
      this.PyroCompartmentDefinitionEncounter = IPyroCompartmentDefinitionEncounter;
      this.PyroCompartmentDefinitionPatient = IPyroCompartmentDefinitionPatient;
      this.PyroCompartmentDefinitionPractitioner = IPyroCompartmentDefinitionPractitioner;
      this.PyroCompartmentDefinitionRelatedPerson = IPyroCompartmentDefinitionRelatedPerson;
    }

    public IPyroCompartmentDefinitionDevice PyroCompartmentDefinitionDevice { get; }
    public IPyroCompartmentDefinitionEncounter PyroCompartmentDefinitionEncounter { get; }
    public IPyroCompartmentDefinitionPatient PyroCompartmentDefinitionPatient { get; }
    public IPyroCompartmentDefinitionPractitioner PyroCompartmentDefinitionPractitioner { get; }
    public IPyroCompartmentDefinitionRelatedPerson PyroCompartmentDefinitionRelatedPerson { get; }
  }
}

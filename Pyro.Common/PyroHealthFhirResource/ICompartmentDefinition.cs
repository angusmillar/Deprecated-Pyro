using Pyro.Common.PyroHealthFhirResource.CompartmentDefinitions;

namespace Pyro.Common.PyroHealthFhirResource
{
  public interface ICompartmentDefinition
  {
    IPyroCompartmentDefinitionEncounter PyroCompartmentDefinitionEncounter { get; }
    IPyroCompartmentDefinitionPatient PyroCompartmentDefinitionPatient { get; }
    IPyroCompartmentDefinitionPractitioner PyroCompartmentDefinitionPractitioner { get; }
    IPyroCompartmentDefinitionRelatedPerson PyroCompartmentDefinitionRelatedPerson { get; }
    IPyroCompartmentDefinitionDevice PyroCompartmentDefinitionDevice { get; }
  }
}
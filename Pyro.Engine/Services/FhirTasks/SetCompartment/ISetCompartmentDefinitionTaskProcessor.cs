using Hl7.Fhir.Model;

namespace Pyro.Engine.Services.FhirTasks.SetCompartment
{
  public interface ISetCompartmentDefinitionTaskProcessor
  {
    Task.TaskStatus Run(Task Task);
  }
}
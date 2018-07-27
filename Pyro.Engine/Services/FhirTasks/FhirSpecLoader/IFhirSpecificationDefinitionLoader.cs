using Hl7.Fhir.Model;

namespace Pyro.Engine.Services.FhirTasks.FhirSpecLoader
{
  public interface IFhirSpecificationDefinitionLoader
  {
    Task.TaskStatus Run(Task Task);
  }
}
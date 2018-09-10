using Hl7.Fhir.Model;

namespace Pyro.Engine.Services.FhirTasks.SearchParameterLoader
{
  public interface ISearchParameterResourceLoader
  {
    Task.TaskStatus Run(Task Task);
  }
}
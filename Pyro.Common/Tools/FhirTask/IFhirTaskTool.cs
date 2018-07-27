using Hl7.Fhir.Model;

namespace Pyro.Common.Tools.FhirTask
{
  public interface IFhirTaskTool
  {
    bool UpdateTaskAsStatus(Task.TaskStatus TaskStatus, Task Task);
  }
}
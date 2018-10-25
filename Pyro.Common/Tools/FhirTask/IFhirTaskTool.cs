using Hl7.Fhir.Model;
using Pyro.Common.Enum;

namespace Pyro.Common.Tools.FhirTask
{
  public interface IFhirTaskTool
  {
    bool UpdateTaskAsStatus(Task.TaskStatus TaskStatus, Task Task);
    Task GetFhirTaskAndMarkAsInProgress(string TaskFhirId, string _ConnectionId, BackgroundTaskEnum.BackgroundTaskType _TaskType, Task MainIndexTask);
  }
}
using Hl7.Fhir.Model;
using Pyro.Common.DtoEntity;
using System.Collections.Generic;
using static Pyro.Common.Enum.BackgroundTaskEnum;

namespace Pyro.Common.Interfaces.Service
{
  public interface IServiceFhirTaskQueue
  {
    DtoFhirTaskQueue AddFhirTaskQueue(DtoFhirTaskQueue DtoFhirTaskQueue);
    DtoFhirTaskQueue GetFhirTaskQueueByFhirTaskIdAndTypeWhereNoPerformer(string FhirTaskId, string TaskType);
    bool AttemptToUpdateFhirTaskQueueStatus(string FhirTaskId, string TaskType, string ConnectionId, Hl7.Fhir.Model.Task.TaskStatus TaskStatus);
    bool AttemptToUpdateFhirTaskQueueWithPerfomersConnectionId(string FhirTaskId, string TaskType, string ConnectionId, Task.TaskStatus TaskStatus);
    List<DtoFhirTaskQueue> GetPendingQueueList(BackgroundTaskType TaskType, int BatchSize = 50);
    int RemovePerfomrerConnectionIdFromQueueItemsByStatus(string ConnectionId, Hl7.Fhir.Model.Task.TaskStatus TaskStatus);
    int ClearConnectionIdFromAllNonCompletedQueueItems();
  }
}
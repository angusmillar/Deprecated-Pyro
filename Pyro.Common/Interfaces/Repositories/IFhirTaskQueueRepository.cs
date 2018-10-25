using Hl7.Fhir.Model;
using Pyro.Common.DtoEntity;
using System.Collections.Generic;
using static Pyro.Common.Enum.BackgroundTaskEnum;

namespace Pyro.Common.Interfaces.Repositories
{
  public interface IFhirTaskQueueRepository
  {
    DtoFhirTaskQueue AddFhirTaskQueue(DtoFhirTaskQueue DtoFhirTaskQueue);
    bool AttemptToUpdateFhirTaskQueueWithPerfomersConnectionId(string FhirTaskId, string TaskType, string ConnectionId, Task.TaskStatus TaskStatus);
    DtoFhirTaskQueue GetFhirTaskQueueByFhirTaskIdAndTypeWhereNoPerformer(string FhirTaskId, string TaskType);
    List<DtoFhirTaskQueue> GetPendingQueueList(BackgroundTaskType TaskType, int BatchSize);
    int ClearConnectionIdFromAllNonCompletedQueueItems();
    int RemovePerfomrerConnectionIdFromQueueItemsByStatus(string ConnectionId, Hl7.Fhir.Model.Task.TaskStatus TaskStatus);
    bool AttemptToUpdateFhirTaskQueueStatus(string FhirTaskId, string TaskType, string ConnectionId, Hl7.Fhir.Model.Task.TaskStatus TaskStatus);

  }
}
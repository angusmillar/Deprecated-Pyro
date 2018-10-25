using Pyro.Common.DtoEntity;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.Service;
using System.Collections.Generic;
using static Pyro.Common.Enum.BackgroundTaskEnum;

namespace Pyro.Engine.Services.FhirTaskQueue
{
  public class ServiceFhirTaskQueue : IServiceFhirTaskQueue
  {
    private readonly IFhirTaskQueueRepository IFhirTaskQueueRepository;

    public ServiceFhirTaskQueue(IFhirTaskQueueRepository IFhirTaskQueueRepository)
    {
      this.IFhirTaskQueueRepository = IFhirTaskQueueRepository;
    }

    public DtoFhirTaskQueue AddFhirTaskQueue(DtoFhirTaskQueue DtoFhirTaskQueue)
    {
      return IFhirTaskQueueRepository.AddFhirTaskQueue(DtoFhirTaskQueue);
    }

    public bool AttemptToUpdateFhirTaskQueueWithPerfomersConnectionId(string FhirTaskId, string TaskType, string ConnectionId, Hl7.Fhir.Model.Task.TaskStatus TaskStatus)
    {
      return IFhirTaskQueueRepository.AttemptToUpdateFhirTaskQueueWithPerfomersConnectionId(FhirTaskId, TaskType, ConnectionId, TaskStatus);
    }

    public int RemovePerfomrerConnectionIdFromQueueItemsByStatus(string ConnectionId, Hl7.Fhir.Model.Task.TaskStatus TaskStatus)
    {
      return IFhirTaskQueueRepository.RemovePerfomrerConnectionIdFromQueueItemsByStatus(ConnectionId, TaskStatus);
    }

    public bool AttemptToUpdateFhirTaskQueueStatus(string FhirTaskId, string TaskType, string ConnectionId, Hl7.Fhir.Model.Task.TaskStatus TaskStatus)
    {
      return IFhirTaskQueueRepository.AttemptToUpdateFhirTaskQueueStatus(FhirTaskId,  TaskType, ConnectionId, TaskStatus);
    }

    public int ClearConnectionIdFromAllNonCompletedQueueItems()
    {
      return IFhirTaskQueueRepository.ClearConnectionIdFromAllNonCompletedQueueItems();
    }

    public DtoFhirTaskQueue GetFhirTaskQueueByFhirTaskIdAndTypeWhereNoPerformer(string FhirTaskId, string TaskType)
    {
      return IFhirTaskQueueRepository.GetFhirTaskQueueByFhirTaskIdAndTypeWhereNoPerformer(FhirTaskId, TaskType);
    }

    public List<DtoFhirTaskQueue> GetPendingQueueList(BackgroundTaskType TaskType, int BatchSize = 50)
    {
      return IFhirTaskQueueRepository.GetPendingQueueList(TaskType, BatchSize);
    }
  }
}

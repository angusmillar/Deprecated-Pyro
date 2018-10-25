using System.Collections.Generic;
using Pyro.Common.DtoEntity;
using Pyro.Common.Enum;

namespace Pyro.Common.Interfaces.Repositories
{
  public interface IFhirTaskWorkerRepository
  {
    DtoFhirTaskWorker AddFhirTaskWorker(DtoFhirTaskWorker DtoFhirTaskWorker);
    bool AttemptToClaim(BackgroundTaskEnum.BackgroundTaskType TaskType, string ConnectionId);
    bool AttemptToUnClaim(BackgroundTaskEnum.BackgroundTaskType TaskType, string ConnectionId);
    void DeleteFhirTaskWorker(BackgroundTaskEnum.BackgroundTaskType TaskType);
    bool ForceUnClaimForType(BackgroundTaskEnum.BackgroundTaskType TaskType);
    DtoFhirTaskWorker GetFhirTaskWorker(BackgroundTaskEnum.BackgroundTaskType TaskType);
    DtoFhirTaskWorker GetFhirTaskWorker(BackgroundTaskEnum.BackgroundTaskType TaskType, bool IsClaimed);
    List<DtoFhirTaskWorker> GetFhirTaskWorkerList();
    List<DtoFhirTaskWorker> GetFhirTaskWorkerList(bool AreClaimed);
    List<DtoFhirTaskWorker> GetFhirTaskWorkerList(string ConnectionId);
  }
}
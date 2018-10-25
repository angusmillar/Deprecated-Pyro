using System.Collections.Generic;
using Pyro.Common.DtoEntity;
using Pyro.Common.Enum;

namespace Pyro.Common.Interfaces.Service
{
  public interface IServiceFhirTaskWorker
  {
    DtoFhirTaskWorker AddFhirTaskWorker(DtoFhirTaskWorker DtoFhirTaskWorker);
    bool AttemptToClaim(BackgroundTaskEnum.BackgroundTaskType BackgroundTaskType, string ConnectionId);
    bool AttemptToUnClaim(BackgroundTaskEnum.BackgroundTaskType BackgroundTaskType, string ConnectionId);
    void DeleteFhirTaskWorker(BackgroundTaskEnum.BackgroundTaskType BackgroundTaskType);
    bool ForceUnClaimForType(BackgroundTaskEnum.BackgroundTaskType BackgroundTaskType);
    DtoFhirTaskWorker GetFhirTaskWorker(BackgroundTaskEnum.BackgroundTaskType BackgroundTaskType);
    DtoFhirTaskWorker GetFhirTaskWorker(BackgroundTaskEnum.BackgroundTaskType BackgroundTaskType, bool IsClaimed);
    List<DtoFhirTaskWorker> GetFhirTaskWorkerList();
    List<DtoFhirTaskWorker> GetFhirTaskWorkerList(bool AreClaimed);
    List<DtoFhirTaskWorker> GetFhirTaskWorkerList(string ConnectedId);
  }
}
using Pyro.Common.DtoEntity;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.Service;
using System.Collections.Generic;
using static Pyro.Common.Enum.BackgroundTaskEnum;

namespace Pyro.Engine.Services.FhirTaskWorker
{
  public class ServiceFhirTaskWorker : IServiceFhirTaskWorker
  {
    private readonly IFhirTaskWorkerRepository IFhirTaskWorkerRepository;
    public ServiceFhirTaskWorker(IFhirTaskWorkerRepository IFhirTaskWorkerRepository)
    {
      this.IFhirTaskWorkerRepository = IFhirTaskWorkerRepository;
    }

    public DtoFhirTaskWorker AddFhirTaskWorker(DtoFhirTaskWorker DtoFhirTaskWorker)
    {
      return IFhirTaskWorkerRepository.AddFhirTaskWorker(DtoFhirTaskWorker);
    }

    public bool AttemptToClaim(BackgroundTaskType BackgroundTaskType, string ConnectionId)
    {
      return IFhirTaskWorkerRepository.AttemptToClaim(BackgroundTaskType, ConnectionId);
    }

    public bool AttemptToUnClaim(BackgroundTaskType BackgroundTaskType, string ConnectionId)
    {
      return IFhirTaskWorkerRepository.AttemptToUnClaim(BackgroundTaskType, ConnectionId);
    }

    public bool ForceUnClaimForType(BackgroundTaskType BackgroundTaskType)
    {
      return IFhirTaskWorkerRepository.ForceUnClaimForType(BackgroundTaskType);
    }

    public void DeleteFhirTaskWorker(BackgroundTaskType BackgroundTaskType)
    {
      IFhirTaskWorkerRepository.DeleteFhirTaskWorker(BackgroundTaskType);
    }
    
    public List<DtoFhirTaskWorker> GetFhirTaskWorkerList(bool AreClaimed)
    {
      return IFhirTaskWorkerRepository.GetFhirTaskWorkerList(AreClaimed);
    }

    public List<DtoFhirTaskWorker> GetFhirTaskWorkerList(string ConnectedId)
    {
      return IFhirTaskWorkerRepository.GetFhirTaskWorkerList(ConnectedId);
    }

    public List<DtoFhirTaskWorker> GetFhirTaskWorkerList()
    {
      return IFhirTaskWorkerRepository.GetFhirTaskWorkerList();
    }

    public DtoFhirTaskWorker GetFhirTaskWorker(BackgroundTaskType BackgroundTaskType)
    {
      return IFhirTaskWorkerRepository.GetFhirTaskWorker(BackgroundTaskType);
    }

    public DtoFhirTaskWorker GetFhirTaskWorker(BackgroundTaskType BackgroundTaskType, bool IsClaimed)
    {
      return IFhirTaskWorkerRepository.GetFhirTaskWorker(BackgroundTaskType, IsClaimed);
    }
    
  }
}

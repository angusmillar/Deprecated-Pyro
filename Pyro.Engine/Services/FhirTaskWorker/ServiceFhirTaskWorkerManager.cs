using Pyro.Common.DtoEntity;
using Pyro.Common.Enum;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using static Pyro.Common.Enum.BackgroundTaskEnum;

namespace Pyro.Engine.Services.FhirTaskWorker
{
  public class ServiceFhirTaskWorkerManager : IServiceFhirTaskWorkerManager
  {
    private readonly IUnitOfWork IUnitOfWork;
    private readonly ILog ILog;
    private readonly IServiceFhirTaskWorker IServiceFhirTaskWorker;
    private readonly IServiceBackburnerConnection IServiceBackburnerConnection;
    private readonly IServiceFhirTaskQueue IServiceFhirTaskQueue;
    public ServiceFhirTaskWorkerManager(IServiceFhirTaskWorker IServiceFhirTaskWorker,
                                        IServiceBackburnerConnection IServiceBackburnerConnection,
                                        IServiceFhirTaskQueue IServiceFhirTaskQueue,
                                        IUnitOfWork IUnitOfWork,
                                        ILog ILog)
    {
      this.IUnitOfWork = IUnitOfWork;
      this.ILog = ILog;
      this.IServiceFhirTaskWorker = IServiceFhirTaskWorker;
      this.IServiceBackburnerConnection = IServiceBackburnerConnection;
      this.IServiceFhirTaskQueue = IServiceFhirTaskQueue;
    }

    public void PyroServerStartup()
    {
      using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
      {
        try
        {
          ILog.Info($"Server start-up: Reset background Task items.");
          ClearAllConnections();
          ClearAllWorkers();
          ClearAllNonCompletedQueueItems();          
          Transaction.Commit();
        }
        catch (Exception Exec)
        {
          ILog.Error(Exec, $"Internal Server Error: Failed to reset and clean up background task workers");
          Transaction.Rollback();
        }
      }
      LoadTaskTypes();
    }

    public void WorkerConnected(string ConnectionId)
    {
      try
      {
        IServiceBackburnerConnection.AddConnectionAsConnected(ConnectionId);
      }
      catch (Exception Exec)
      {
        ILog.Error(Exec, $"Failed to clean up background worker information on Worker Disconnected event. Connection Id was : {ConnectionId}");
      }
    }

    public void WorkerDisconnected(string ConnectionId)
    {
      using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
      {
        try
        {
          //Remove the Connection
          IServiceBackburnerConnection.UpdateAsDisconnected(ConnectionId);
          ILog.Info($"Background worker disconnected with connection Id: {ConnectionId}");
          List<DtoFhirTaskWorker> ConnectionIdWorkerList = IServiceFhirTaskWorker.GetFhirTaskWorkerList(ConnectionId);
          foreach (DtoFhirTaskWorker Worker in ConnectionIdWorkerList)
          {            
            //Remove each Worker 
            if (IServiceFhirTaskWorker.AttemptToUnClaim(Worker.GetTaskType(), Worker.ClaimedBy))
            {
              ILog.Info($"  Successfully reclaimed worker task type : {Worker.TaskType} from connection Id: {Worker.ClaimedBy} on disconnect event.");
              //Remove each Queue Item
              int NumberOf = IServiceFhirTaskQueue.RemovePerfomrerConnectionIdFromQueueItemsByStatus(ConnectionId, Hl7.Fhir.Model.Task.TaskStatus.InProgress);
              if (NumberOf > 0)
                ILog.Info($"  Successfully reclaimed orphaned FhirTaskQueue items, total: {NumberOf}");
            }
            else
            {
              ILog.Error($"UnSuccessful attempt to unclaimed worker task type : {Worker.TaskType} from connection Id: {Worker.ClaimedBy} on disconnect event.");
            }
          }
          if (ConnectionIdWorkerList.Count == 0)
          {
            ILog.Info($"No claimed worker tasks for connection Id {ConnectionId} to be re-claimed.");
          }          
          Transaction.Commit();
        }
        catch (Exception Exec)
        {
          ILog.Error(Exec, $"Failed to clean up background worker information on Worker Disconnected event. Connection Id was : {ConnectionId}");
          Transaction.Rollback();
        }
      }
    }

    private void ClearAllConnections()
    {
      int NumberOf = IServiceBackburnerConnection.UpdateAllConnectedAsDisconnected();
      if (NumberOf > 0)
        ILog.Info($"  Successfully reclaimed background worker connections, total: {NumberOf}");
      IServiceBackburnerConnection.CleanConnections();
    }

    private void ClearAllNonCompletedQueueItems()
    {
      int NumberOf = IServiceFhirTaskQueue.ClearConnectionIdFromAllNonCompletedQueueItems();
      if (NumberOf > 0)
        ILog.Info($"  Successfully reclaimed orphaned Fhir Task Queue items, total: {NumberOf}");
    }

    private void ClearAllWorkers()
    {
      var BackgroundTaskTypeList = Enum.GetValues(typeof(BackgroundTaskType)).Cast<BackgroundTaskType>();
      int NumberOf = 0;
      foreach (var Worker in IServiceFhirTaskWorker.GetFhirTaskWorkerList(true))
      {        
        if (IServiceFhirTaskWorker.ForceUnClaimForType(Worker.GetTaskType()))
        {
          NumberOf++;
        }
      }
      if (NumberOf > 0)
        ILog.Info($"  Successfully reclaimed orphaned Fhir Task Worker items, total: {NumberOf}");
    }

    private void LoadTaskTypes()
    {
      var BackgroundTaskTypeList = Enum.GetValues(typeof(BackgroundTaskType)).Cast<BackgroundTaskType>();
      foreach (BackgroundTaskType Type in BackgroundTaskTypeList)
      {
        DtoFhirTaskWorker Worker = IServiceFhirTaskWorker.GetFhirTaskWorker(Type);
        if (Worker == null)
        {
          IServiceFhirTaskWorker.AddFhirTaskWorker(new DtoFhirTaskWorker() { TaskType = Type.GetPyroLiteral(), ClaimedBy = null });
          ILog.Info($"Added new Task Worker Type of : {Type.GetPyroLiteral()}");
        }
      }
    }
  }

}

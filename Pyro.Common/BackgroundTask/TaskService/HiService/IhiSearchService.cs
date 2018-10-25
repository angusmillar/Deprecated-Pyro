using Hl7.Fhir.Model;
using Pyro.Common.BackgroundTask.TaskPayload;
using Pyro.Common.CompositionRoot;
using Pyro.Common.DtoEntity;
using Pyro.Common.Enum;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Logging;
using Pyro.Common.RequestMetadata;
using Pyro.Common.Service.ResourceService;
using Pyro.Common.Tools;
using Pyro.Common.Tools.FhirTask;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading;
using static Pyro.Common.Enum.BackgroundTaskEnum;

namespace Pyro.Common.BackgroundTask.TaskService.HiService
{
  public class IhiSearchService : IIhiSearchService
  {
    private readonly IUnitOfWork IUnitOfWork;
    private readonly IResourceServices IResourceApiServices;
    private readonly IRequestMetaFactory IRequestMetaFactory;
    private readonly IServiceFhirTaskQueue IServiceFhirTaskQueue;
    private readonly IFhirTaskWorkerRepository IFhirTaskWorkerRepository;
    private readonly IFhirTaskTool IFhirTaskTool;
    private readonly ILog ILog;

    private bool _ErrorDetected = false;
    private string _ErrorMessage = string.Empty;    
    private string _ConnectionId = string.Empty;
    private CancellationTokenSource _CancellationToken;
    private BackgroundTaskType _TaskType;
    private IBackgroundTaskPayload _BackgroundTaskPayload;

    public IhiSearchService(IUnitOfWork IUnitOfWork, IResourceServices IResourceApiServices, IRequestMetaFactory IRequestMetaFactory, IServiceFhirTaskQueue IServiceFhirTaskQueue, IFhirTaskWorkerRepository IFhirTaskWorkerRepository, IFhirTaskTool IFhirTaskTool, ILog ILog)
    {
      this.IUnitOfWork = IUnitOfWork;
      this.IResourceApiServices = IResourceApiServices;
      this.IRequestMetaFactory = IRequestMetaFactory;
      this.IServiceFhirTaskQueue = IServiceFhirTaskQueue;
      this.IFhirTaskWorkerRepository = IFhirTaskWorkerRepository;
      this.IFhirTaskTool = IFhirTaskTool;
      this.ILog = ILog;
    }

    public void Run(IBackgroundTaskPayload BackgroundTaskPayload, string ConnectionId, CancellationTokenSource CancellationToken)
    {
      _BackgroundTaskPayload = BackgroundTaskPayload;
      _TaskType = _BackgroundTaskPayload.TaskType;
      _ConnectionId = ConnectionId;
      _CancellationToken = CancellationToken;
      bool MoreWorkTodo = true;
      bool WasAnyWorkDone = false;
      try
      {
        while (MoreWorkTodo)
        {
          _CancellationToken.Token.ThrowIfCancellationRequested();
          //This is the list of Ready or In-Progress (What do we do with inError, I think we neeed a skip bool
          List<DtoFhirTaskQueue> FhirTaskQueueList = IServiceFhirTaskQueue.GetPendingQueueList(_BackgroundTaskPayload.TaskType, 50);
          foreach (var FhirTaskQueue in FhirTaskQueueList)
          {
            CancellationToken.Token.ThrowIfCancellationRequested();
            Task.TaskStatus TaskStatusOutcome = ProcessTask(FhirTaskQueue.TaskFhirId, _ConnectionId);
            WasAnyWorkDone = true;
          }
          if (FhirTaskQueueList.Count == 0)
            MoreWorkTodo = false;
        }        
        if (!WasAnyWorkDone)
        {
          ILog.Info($"ConnectionId: {_ConnectionId} found no queued tasks to perform for task type: {_TaskType.GetPyroLiteral()}");
        }
        if (IFhirTaskWorkerRepository.AttemptToUnClaim(_BackgroundTaskPayload.TaskType, ConnectionId))
        {
          ILog.Info($"ConnectionId: {ConnectionId} has unclaimed the task worker of type: {_TaskType.GetPyroLiteral()}  based on the triggered task Id of : {_BackgroundTaskPayload.TaskId}");
        }
      }
      catch (OperationCanceledException CancelExec)
      {
        IFhirTaskWorkerRepository.AttemptToUnClaim(_BackgroundTaskPayload.TaskType, ConnectionId);
        throw CancelExec;
      }
    }

    private Task.TaskStatus ProcessTask(string TaskFhirId, string ConnectionId)
    {

      //Try and get the Task to process      
      Task MainIndexTask = AttemptToGetTheFhirTask(TaskFhirId, ConnectionId);

      if (MainIndexTask == null)
      {
        //If the Task associated with the Queue Task can not be found the just return completed
        ILog.Info($"ConnectionId: {_ConnectionId}, Task Type: {_TaskType.GetPyroLiteral()}, Resource: Task/{TaskFhirId}, no work to be performed.");
        ILog.Info($"ConnectionId: {_ConnectionId}, Completed Task Type: {_BackgroundTaskPayload.TaskType.GetPyroLiteral()}, Resource: Task/{TaskFhirId}");
        ConsoleSupport.TimeStampWriteLine(BackgroundTaskLogMessageSupport.TaskOutCome(_BackgroundTaskPayload, Task.TaskStatus.Completed));

        using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
        {
          try
          {
            _CancellationToken.Token.ThrowIfCancellationRequested();
            if (IServiceFhirTaskQueue.AttemptToUpdateFhirTaskQueueStatus(TaskFhirId, _TaskType.GetPyroLiteral(), ConnectionId, Task.TaskStatus.Completed))
            {
              Transaction.Commit();
              return Task.TaskStatus.Completed;
            }
            else
            {
              throw new ApplicationException($"Unable to update the FhirTaskQueue status as Completed after completing the tasks work, FHIR Task reference was: Task/{TaskFhirId} using connection id: {ConnectionId} for task type: {_TaskType.GetPyroLiteral()}");
            }
          }
          catch (OperationCanceledException OperationCanceled)
          {
            //do something and throw again!
            throw OperationCanceled;
          }
          catch (Exception Exec)
          {
            _ErrorDetected = true;
            Transaction.Rollback();
            ILog.Error(Exec, $"FHIR Task ID: {TaskFhirId}");
          }
        }
        return Task.TaskStatus.Completed;
      }
      else
      {
        //Found the FHIR Task so do its work
        using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
        {
          try
          {
            _CancellationToken.Token.ThrowIfCancellationRequested();
            IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set("Patient/IHIStatusExample");
            IResourceServiceOutcome ResourceServiceOutcome = IResourceApiServices.GetRead("IHIStatusExample", RequestMeta);
            ResourceServiceOutcome.SummaryType = RequestMeta.SearchParameterGeneric.SummaryType;
            Transaction.Commit();
            _ErrorDetected = false;
          }
          catch (OperationCanceledException OperationCanceled)
          {
            //do something and throw again!
            throw OperationCanceled;
          }
          catch (Exception Exec)
          {
            _ErrorDetected = true;
            Transaction.Rollback();
            ILog.Error(Exec, $"FHIR Task ID: {TaskFhirId}");
          }
        }

        
        
        //Update the Task and the Queue items based of Success or not 
        if (!_ErrorDetected)
        {
          ConsoleSupport.TimeStampWriteLine(BackgroundTaskLogMessageSupport.TaskOutCome(_BackgroundTaskPayload, Task.TaskStatus.Completed));
          using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
          {
            if (IFhirTaskTool.UpdateTaskAsStatus(Task.TaskStatus.Completed, MainIndexTask))
            {
              ILog.Info($"ConnectionId: {_ConnectionId}, Completed Task Type: {_TaskType.GetPyroLiteral()}, Resource: Task/{TaskFhirId}");
              if (IServiceFhirTaskQueue.AttemptToUpdateFhirTaskQueueStatus(TaskFhirId, _TaskType.GetPyroLiteral(), ConnectionId, Task.TaskStatus.Completed))
              {
                Transaction.Commit();
                return Task.TaskStatus.Completed;
              }
              else
              {
                throw new ApplicationException($"Unable to update the FhirTaskQueue status as Completed after completing the tasks work, FHIR Task reference was: Task/{TaskFhirId} using connection id: {ConnectionId} for task type: {_TaskType.GetPyroLiteral()}");
              }
            }
            else
            {
              throw new ApplicationException($"Unable to update the FHIR Task status after completing the tasks work, FHIR Task reference was: Task/{TaskFhirId} for task type: {_TaskType.GetPyroLiteral()}");
            }
          }

        }
        else
        {
          using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
          {
            if (IFhirTaskTool.UpdateTaskAsStatus(Task.TaskStatus.Failed, MainIndexTask))
            {
              ConsoleSupport.TimeStampWriteLine(BackgroundTaskLogMessageSupport.TaskOutCome(_BackgroundTaskPayload, Task.TaskStatus.Failed));
              ILog.Info($"ConnectionId: {_ConnectionId}, Failed Task Type: {_TaskType.GetPyroLiteral()}, Resource: Task/{TaskFhirId}");
              if (IServiceFhirTaskQueue.AttemptToUpdateFhirTaskQueueStatus(TaskFhirId, _TaskType.GetPyroLiteral(), ConnectionId, Task.TaskStatus.Failed))
              {
                Transaction.Commit();
                return Task.TaskStatus.Failed;
              }
              else
              {
                throw new ApplicationException($"Unable to update the FhirTaskQueue status as Failed after error performing the tasks work, FHIR Task reference was: Task/{TaskFhirId} using connection id: {ConnectionId} for task type: {_TaskType.GetPyroLiteral()}");
              }
            }
            else
            {
              throw new ApplicationException($"Unable to update the FHIR Task status after as failed, FHIR Task reference was: Task/{TaskFhirId} for task type: {_TaskType.GetPyroLiteral()}");
            }
          }
        }
      }
    }

    private Task AttemptToGetTheFhirTask(string TaskFhirId, string ConnectionId)
    {
      Task FhirTask = null;
      if (IServiceFhirTaskQueue.AttemptToUpdateFhirTaskQueueWithPerfomersConnectionId(TaskFhirId, _TaskType.GetPyroLiteral(), ConnectionId, Task.TaskStatus.InProgress))
      {
        ILog.Info($"ConnectionId: {_ConnectionId} Claimed the Task with Id: {TaskFhirId}");
        FhirTask = IFhirTaskTool.GetFhirTaskAndMarkAsInProgress(TaskFhirId, ConnectionId, _TaskType, FhirTask);
      }
      return FhirTask;
    }

  }
}

//using Pyro.Backburner.Tools;
using Pyro.Common.BackgroundTask.TaskPayload;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.RequestMetadata;
using Pyro.Common.Service.ResourceService;
using Pyro.Common.Tools;
using System;
using System.Data.Entity;
using Pyro.Common.Logging;
using Hl7.Fhir.Model;
using Pyro.Common.Tools.FhirTask;
using Hl7.Fhir.Utility;
using Pyro.Common.Enum;
using System.Collections.Generic;
using System.Linq;
using Pyro.Common.DtoEntity;
using static Pyro.Common.Enum.BackgroundTaskEnum;
using System.Threading;

namespace Pyro.Common.BackgroundTask.TaskService.Indexer
{
  public class IndexerService : IIndexerService
  {
    private readonly IUnitOfWork IUnitOfWork;
    private readonly IResourceServices IResourceServices;    
    private readonly IRequestMetaFactory IRequestMetaFactory;
    private readonly IFhirTaskTool IFhirTaskTool;
    private readonly IServiceSearchParameterService IServiceSearchParameterService;
    private readonly IServiceFhirTaskQueue IServiceFhirTaskQueue;
    private readonly IFhirTaskWorkerRepository IFhirTaskWorkerRepository;
    private readonly ILog ILog;

    private bool _ErrorDetected = false;
    private string _ErrorMessage = string.Empty;
    private string _TaskStatusCodeSystem = "http://hl7.org/fhir/task-status";
    private string _ConnectionId = string.Empty;
    private CancellationTokenSource _CancellationToken;
    private BackgroundTaskType _TaskType;
    private IBackgroundTaskPayload _BackgroundTaskPayload;
    private List<Common.Search.DtoServiceSearchParameterHeavy> _SearchParameterList;

    public IndexerService(IUnitOfWork IUnitOfWork, 
      IResourceServices IResourceApiServices, 
      IRequestMetaFactory IRequestMetaFactory, 
      ILog ILog, 
      IFhirTaskTool IFhirTaskTool, 
      IServiceSearchParameterService IServiceSearchParameterService,
      IServiceFhirTaskQueue IServiceFhirTaskQueue, 
      IFhirTaskWorkerRepository IFhirTaskWorkerRepository)
    {
      this.IUnitOfWork = IUnitOfWork;      
      this.IResourceServices = IResourceApiServices;
      this.IRequestMetaFactory  = IRequestMetaFactory;
      this.ILog = ILog;
      this.IFhirTaskTool = IFhirTaskTool;
      this.IServiceSearchParameterService = IServiceSearchParameterService;
      this.IServiceFhirTaskQueue = IServiceFhirTaskQueue;
      this.IFhirTaskWorkerRepository = IFhirTaskWorkerRepository;
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
          //This is the list of Ready or In-Progress (What do we do with inError, I think we need a skip bool)
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
      
      //First get the Task to process
      Task MainIndexTask = null;
      
      if (IServiceFhirTaskQueue.AttemptToUpdateFhirTaskQueueWithPerfomersConnectionId(TaskFhirId, _TaskType.GetPyroLiteral(), ConnectionId, Task.TaskStatus.InProgress))
      {
        ILog.Info($"ConnectionId: {_ConnectionId} Claimed the Task with Id: {TaskFhirId}");
        MainIndexTask = IFhirTaskTool.GetFhirTaskAndMarkAsInProgress(TaskFhirId, ConnectionId, _TaskType, MainIndexTask);
      }
      
      //If there is a no Task then this for this connection ID then report as Completed
      if (MainIndexTask == null)
      {
        ILog.Info($"ConnectionId: {_ConnectionId}, Task Type: {_TaskType.GetPyroLiteral()}, Resource: Task/{TaskFhirId}, no work to be performed.");
        ILog.Info($"ConnectionId: {_ConnectionId}, Completed Task Type: {_BackgroundTaskPayload.TaskType.GetPyroLiteral()}, Resource: Task/{TaskFhirId}");
        ConsoleSupport.TimeStampWriteLine(BackgroundTaskLogMessageSupport.TaskOutCome(_BackgroundTaskPayload, Task.TaskStatus.Completed));
        return Task.TaskStatus.Completed;
      }
      else
      {
        //Else process the FHIR Task
        
        //Gets the key info we require from the FHIR Task
        List<TaskIndexItem> TaskInputList = GetTaskInputDetail(MainIndexTask);

        //We must process search indexes in batches by the resource type they apply to, so we don't need to read in the resource blob many times
        var TaskInputListGroupedByResourceType = TaskInputList.GroupBy(x => x.ResourceType);
        foreach (var InputItemForResourceList in TaskInputListGroupedByResourceType)
        {
          GetResourceTypeSearchParameterDbRecords(InputItemForResourceList, TaskFhirId);          
          if (_ErrorDetected)
          {
            //There are two loops here, so if an error here we need to break again and report.
            break;
          }
          else
          {
            //Now for the resource re-indexing
            using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
            {
              try
              {
                //This does the grunt work to update and add the indexes for all resource of said type                
                List<ResourceType> ResourceNameArray = null; 
                if (InputItemForResourceList.Key == ResourceType.Resource.GetLiteral())
                {
                  ResourceNameArray = Common.Tools.ResourceNameResolutionSupport.GetUsableResourceTypeList();
                }
                else
                {
                  ResourceNameArray = new List<ResourceType>() { Common.Tools.ResourceNameResolutionSupport.GetResourceType(InputItemForResourceList.Key) };
                }

                foreach(ResourceType CurrentResourceType in ResourceNameArray)
                {                  
                  IResourceServices.AddAndUpdateResourceIndexes(CurrentResourceType, _SearchParameterList, _CancellationToken);
                }
                Transaction.Commit();

                //Update the indexes we have completed 
                var CompletedTaskItems = TaskInputList.Where(x => _SearchParameterList.Any(s => s.Id == x.SearchParamTableId));
                foreach (var TaskItem in CompletedTaskItems)
                {
                  ILog.Info($"ConnectionId: {_ConnectionId}, Task Type: {_TaskType.GetPyroLiteral()}, Resource: Task/{MainIndexTask.Id}, Finished indexing Search Parameter: Resource: {TaskItem.ResourceType}, Name: {TaskItem.SearchParameterName}, _SearchParamId: {TaskItem.SearchParamTableId}.");                  
                  TaskItem.TaskStatus = Task.TaskStatus.Completed;
                }
                //Does not commit only updates the Task resource in memory
                UpdateTasksResourceWithProgress(MainIndexTask, Task.TaskStatus.InProgress, TaskInputList);
              }
              catch (OperationCanceledException CancelExec)
              {                
                Transaction.Rollback();
                throw CancelExec;
              }
              catch (Exception Exec)
              {
                _ErrorDetected = true;
                _ErrorMessage = $"ConnectionId: {_ConnectionId}, FHIR Task ID: {MainIndexTask.Id} of type {_TaskType.GetPyroLiteral()} has failed. " +
                  $"Error in updating the FHIR servers' resource indexes. See exception message in server logs for more information.";
                ILog.Error(Exec, _ErrorMessage);

                //Update the FHIR Task as Failed
                var CompletedTaskItems = TaskInputList.Where(x => _SearchParameterList.Any(s => s.Id == x.SearchParamTableId));
                foreach (var TaskItem in CompletedTaskItems)
                {
                  TaskItem.TaskStatus = Task.TaskStatus.Failed;
                }
                //Does not commit only updates the Task resource in memory
                UpdateTasksResourceWithProgress(MainIndexTask, Task.TaskStatus.Failed, TaskInputList);
                Transaction.Rollback();
                break;
              }
            }

            //Now we Commit the Task update with the current progress InProgress.
            using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
            {
              try
              {
                foreach (var Param in _SearchParameterList)
                {
                  Param.IsIndexed = true;
                  IServiceSearchParameterService.UpdateServiceSearchParametersHeavy(Param);
                }

                if (IFhirTaskTool.UpdateTaskAsStatus(MainIndexTask.Status.Value, MainIndexTask))
                {
                  Transaction.Commit();
                }
              }
              catch (Exception Exec)
              {
                _ErrorDetected = true;
                _ErrorMessage = $"ConnectionId: {_ConnectionId}, FHIR Task ID: {MainIndexTask.Id} of type {_TaskType.GetPyroLiteral()} has failed. " +
                  $"Error updating servers' SearchParameter IsIndexed to true post re-indexing. See exception message in server logs for more information.";
                ILog.Error(Exec, _ErrorMessage);
              }
            }
          }
        }


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

    

    private void GetResourceTypeSearchParameterDbRecords(IGrouping<string, TaskIndexItem> InputItemForResourceList, string TaskFhirId)
    {      
      _SearchParameterList = new List<Common.Search.DtoServiceSearchParameterHeavy>();
      //Get each Search Parameter record for the same resource type from the database _SearchParam table 
      foreach (TaskIndexItem TaskIndexItemForResource in InputItemForResourceList.ToList())
      {
        try
        {
          //Get the SearchParameters from the database
          Common.Search.DtoServiceSearchParameterHeavy SearchParametersHeavy = IServiceSearchParameterService.GetServiceSearchParametersHeavyById(TaskIndexItemForResource.SearchParamTableId);
          if (SearchParametersHeavy != null)
          {
            //Add each to the list to process later.
            _SearchParameterList.Add(SearchParametersHeavy);
          }
          else
          {
            _ErrorDetected = true;
            _ErrorMessage = $"ConnectionId: {_ConnectionId}, FHIR Task ID: {TaskFhirId} of type {_TaskType.GetPyroLiteral()} has failed. " +
              $"Unable to get DtoServiceSearchParameterHeavy with the Id: {TaskIndexItemForResource.SearchParamTableId}, for ResourceType {TaskIndexItemForResource.ResourceType}, SearchName: {TaskIndexItemForResource.SearchParameterName}.";
            ILog.Error(_ErrorMessage);
            break;
          }
        }
        catch (Exception Exec)
        {
          _ErrorDetected = true;
          _ErrorMessage = $"ConnectionId: {_ConnectionId}, FHIR Task ID: {TaskFhirId} of type {_TaskType.GetPyroLiteral()} has failed. " +
            $"Unable to get DtoServiceSearchParameterHeavy with the Id: {TaskIndexItemForResource.SearchParamTableId}, for ResourceType {TaskIndexItemForResource.ResourceType}, SearchName: {TaskIndexItemForResource.SearchParameterName}. See Exception Message for more info.";
          ILog.Error(Exec, _ErrorMessage);
          break;
        }
      }      
    }
    
    private void UpdateTasksResourceWithProgress(Task MainIndexTask, Task.TaskStatus TaskStatus, List<TaskIndexItem> TaskIndexItemList)
    {
      MainIndexTask.Status = TaskStatus;
      MainIndexTask.LastModifiedElement = new FhirDateTime(DateTimeOffset.Now);
      MainIndexTask.Input = new List<Task.ParameterComponent>();
      MainIndexTask.Output = new List<Task.OutputComponent>();

      var InProgressList = TaskIndexItemList.Where(x => x.TaskStatus != Task.TaskStatus.Completed);
      foreach (var InProgress in InProgressList)
      {        
        var IdComponent = new Task.ParameterComponent();
        IdComponent.Type = new CodeableConcept()
        {
          Coding = new List<Coding>()
           {
              new Coding()
              {
                 System = Common.PyroHealthFhirResource.CodeSystems.PyroFhirServer.System,
                 Code = Common.PyroHealthFhirResource.CodeSystems.PyroFhirServer.Codes.SearchParamTableId.GetPyroLiteral()
              }
           }
        };
        IdComponent.Value = new Hl7.Fhir.Model.Integer() { Value = InProgress.SearchParamTableId };
        MainIndexTask.Input.Add(IdComponent);

        var ResourceComponent = new Task.ParameterComponent();
        ResourceComponent.Type = new CodeableConcept()
        {
          Coding = new List<Coding>()
           {
              new Coding()
              {
                 System = Common.PyroHealthFhirResource.CodeSystems.PyroFhirServer.System,
                 Code = Common.PyroHealthFhirResource.CodeSystems.PyroFhirServer.Codes.ResourceType.GetPyroLiteral()
              }
           }
        };
        ResourceComponent.Value = new Hl7.Fhir.Model.FhirString() { Value = InProgress.ResourceType };
        MainIndexTask.Input.Add(ResourceComponent);

        var NameComponent = new Task.ParameterComponent();
        NameComponent.Type = new CodeableConcept()
        {
          Coding = new List<Coding>()
           {
              new Coding()
              {
                 System = Common.PyroHealthFhirResource.CodeSystems.PyroFhirServer.System,
                 Code = Common.PyroHealthFhirResource.CodeSystems.PyroFhirServer.Codes.SearchParameterName.GetPyroLiteral()
              }
           }
        };
        NameComponent.Value = new Hl7.Fhir.Model.FhirUri() { Value = InProgress.SearchParameterName };
        MainIndexTask.Input.Add(NameComponent);
      }

      var CompletedList = TaskIndexItemList.Where(x => x.TaskStatus == Task.TaskStatus.Completed);

      foreach(var Completed in CompletedList)
      {
        var IdComponent = new Task.OutputComponent();
        IdComponent.Type = new CodeableConcept()
        {
          Coding = new List<Coding>()
           {
              new Coding()
              {
                 System = Common.PyroHealthFhirResource.CodeSystems.PyroFhirServer.System,
                 Code = Common.PyroHealthFhirResource.CodeSystems.PyroFhirServer.Codes.SearchParamTableId.GetPyroLiteral()
              },
              new Coding()
              {
                 System = _TaskStatusCodeSystem,
                 Code = Task.TaskStatus.Completed.GetLiteral()
              }
           }
        };
        IdComponent.Value = new Hl7.Fhir.Model.Integer() { Value = Completed.SearchParamTableId };
        MainIndexTask.Output.Add(IdComponent);

        var ResourceComponent = new Task.OutputComponent();
        ResourceComponent.Type = new CodeableConcept()
        {
          Coding = new List<Coding>()
           {
              new Coding()
              {
                 System = Common.PyroHealthFhirResource.CodeSystems.PyroFhirServer.System,
                 Code = Common.PyroHealthFhirResource.CodeSystems.PyroFhirServer.Codes.ResourceType.GetPyroLiteral()
              },
              new Coding()
              {
                 System = _TaskStatusCodeSystem,
                 Code = Task.TaskStatus.Completed.GetLiteral()
              }
           }
        };
        ResourceComponent.Value = new Hl7.Fhir.Model.FhirString() { Value = Completed.ResourceType };
        MainIndexTask.Output.Add(ResourceComponent);

        var NameComponent = new Task.OutputComponent();
        NameComponent.Type = new CodeableConcept()
        {
          Coding = new List<Coding>()
           {
              new Coding()
              {
                 System = Common.PyroHealthFhirResource.CodeSystems.PyroFhirServer.System,
                 Code = Common.PyroHealthFhirResource.CodeSystems.PyroFhirServer.Codes.SearchParameterName.GetPyroLiteral()
              },
              new Coding()
              {
                 System = _TaskStatusCodeSystem,
                 Code = Task.TaskStatus.Completed.GetLiteral()
              }
           }
        };
        NameComponent.Value = new Hl7.Fhir.Model.FhirUri() { Value = Completed.SearchParameterName };
        MainIndexTask.Output.Add(NameComponent);
      }
     
    }

    //Get the Key information from the Task to perform the indexing
    private List<TaskIndexItem> GetTaskInputDetail(Task MainIndexTask)
    {
      var ReturnList = new List<TaskIndexItem>();
      TaskIndexItem Item = new TaskIndexItem();
      foreach (var Input in MainIndexTask.Input)
      {
        var TypeId = Input.Type.Coding.SingleOrDefault(x => x.System == Common.PyroHealthFhirResource.CodeSystems.PyroFhirServer.System && x.Code == Common.PyroHealthFhirResource.CodeSystems.PyroFhirServer.Codes.SearchParamTableId.GetPyroLiteral());
        if (TypeId != null)
        {
          if (Item.SearchParamTableId > 0)
            ReturnList.Add(Item.Clone() as TaskIndexItem);

          Item = new TaskIndexItem();
          if (Input.Value is Hl7.Fhir.Model.Integer FhirInt)
          {
            if (FhirInt.Value.HasValue)
              Item.SearchParamTableId = FhirInt.Value.Value;
          }          
        }

        var TypeResourceName = Input.Type.Coding.SingleOrDefault(x => x.System == Common.PyroHealthFhirResource.CodeSystems.PyroFhirServer.System && x.Code == Common.PyroHealthFhirResource.CodeSystems.PyroFhirServer.Codes.ResourceType.GetPyroLiteral());
        if (TypeResourceName != null)
        {          
          if (Input.Value is Hl7.Fhir.Model.FhirString FhirString)
          {            
            Item.ResourceType = FhirString.Value;
          }
        }

        var TypeSearchParameterName = Input.Type.Coding.SingleOrDefault(x => x.System == Common.PyroHealthFhirResource.CodeSystems.PyroFhirServer.System && x.Code == Common.PyroHealthFhirResource.CodeSystems.PyroFhirServer.Codes.SearchParameterName.GetPyroLiteral());
        if (TypeSearchParameterName != null)
        {
          if (Input.Value is Hl7.Fhir.Model.FhirString FhirString)
          {
            Item.SearchParameterName = FhirString.Value;
          }
        }

      }

      //Add the last one as it is not added in the logic above
      if (Item.SearchParamTableId > 0)
        ReturnList.Add(Item.Clone() as TaskIndexItem);

      return ReturnList;
    }

    private string FormatLogMessage(IBackgroundTaskPayload BackgroundTaskPayload)
    {
      if (BackgroundTaskPayload.TaskId == null)
        return $"ConnectionId: {_ConnectionId}, Run on start-up, Task Type: {BackgroundTaskPayload.TaskType.GetPyroLiteral()}";
      else
        return $"ConnectionId: {_ConnectionId}, Received Task Type: {BackgroundTaskPayload.TaskType.GetPyroLiteral()}, Resource: Task/{BackgroundTaskPayload.TaskId}";
    }
    private class TaskIndexItem : ICloneable
    {
      public TaskIndexItem()
      {
        this.SearchParamTableId = 0;
        this.TaskStatus = Task.TaskStatus.Ready;
      }

      public int SearchParamTableId { get; set; }
      public string ResourceType { get; set; }
      public string SearchParameterName { get; set; }
      public Task.TaskStatus TaskStatus { get; set; }

      public object Clone()
      {
        var Clone = new TaskIndexItem();
        Clone.ResourceType = this.ResourceType;
        Clone.SearchParameterName = this.SearchParameterName;
        Clone.SearchParamTableId = this.SearchParamTableId;
        return Clone;
      }
    }
  }
}

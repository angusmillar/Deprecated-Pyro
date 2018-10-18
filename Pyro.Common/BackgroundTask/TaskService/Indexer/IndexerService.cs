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

namespace Pyro.Common.BackgroundTask.TaskService.Indexer
{
  public class IndexerService : IIndexerService
  {
    private readonly IUnitOfWork IUnitOfWork;
    private readonly IResourceServices IResourceServices;    
    private readonly IRequestMetaFactory IRequestMetaFactory;
    private readonly IFhirTaskTool IFhirTaskTool;
    private readonly IServiceSearchParameterService IServiceSearchParameterService;
    private readonly ILog ILog;

    private bool _ErrorDetected = false;
    private string _ErrorMessage = string.Empty;
    private string _TaskStatusCodeSystem = "http://hl7.org/fhir/task-status";
    private string _ConnectionId = "[None]";
    private ITaskPayloadPyroServerIndexing _TaskPayloadPyroServerIndexing;
    private List<Common.Search.DtoServiceSearchParameterHeavy> _SearchParameterList;

    public IndexerService(IUnitOfWork IUnitOfWork, 
      IResourceServices IResourceApiServices, 
      IRequestMetaFactory IRequestMetaFactory, 
      ILog ILog, 
      IFhirTaskTool IFhirTaskTool, 
      IServiceSearchParameterService IServiceSearchParameterService)
    {
      this.IUnitOfWork = IUnitOfWork;      
      this.IResourceServices = IResourceApiServices;
      this.IRequestMetaFactory  = IRequestMetaFactory;
      this.ILog = ILog;
      this.IFhirTaskTool = IFhirTaskTool;
      this.IServiceSearchParameterService = IServiceSearchParameterService;
    }
    
    public void Run(ITaskPayloadPyroServerIndexing TaskPayloadPyroServerIndexing, string ConnectionId)
    {
      _TaskPayloadPyroServerIndexing = TaskPayloadPyroServerIndexing;
      _ConnectionId = ConnectionId;



      //First get the Task to process
      Task MainIndexTask = null;
      MainIndexTask = GetFhirTaskAndMarkAsInProgress(_TaskPayloadPyroServerIndexing.TaskId, MainIndexTask);

      //If there is a Task to process then begin that processing
      if (MainIndexTask == null)
      {
        ILog.Info($"ConnectionId: {_ConnectionId}, Task Type: {_TaskPayloadPyroServerIndexing.TaskType.GetPyroLiteral()}, Resource: Task/{_TaskPayloadPyroServerIndexing.TaskId}, no work to be performed.");
        ILog.Info($"ConnectionId: {_ConnectionId}, Completed Task Type: {_TaskPayloadPyroServerIndexing.TaskType.GetPyroLiteral()}, Resource: Task/{_TaskPayloadPyroServerIndexing.TaskId}");
        ConsoleSupport.TimeStampWriteLine(BackgroundTaskLogMessageSupport.TaskOutCome(_TaskPayloadPyroServerIndexing, Task.TaskStatus.Completed));
      }
      else
      {
        //Gets the key info we require from the FHIR Task
        List<TaskIndexItem> TaskInputList = GetTaskInputDetail(MainIndexTask);

        //We must process search indexes in batches by the resource type they apply to, so we don't need to read in the resource blob many times
        var TaskInputListGroupedByResourceType = TaskInputList.GroupBy(x => x.ResourceType);
        foreach (var InputItemForResourceList in TaskInputListGroupedByResourceType)
        {
          GetResourceTypeSearchParameterDbRecords(InputItemForResourceList);          
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
                var LightList = _SearchParameterList.Cast<Common.Search.DtoServiceSearchParameterLight>().ToList();
                ResourceType ResourceType = Common.Tools.ResourceNameResolutionSupport.GetResourceType(InputItemForResourceList.Key);
                IResourceServices.AddAndUpdateResourceIndexes(ResourceType, LightList);
                Transaction.Commit();

                //Update the indexes we have completed 
                var CompletedTaskItems = TaskInputList.Where(x => _SearchParameterList.Any(s => s.Id == x.SearchParamTableId));
                foreach (var TaskItem in CompletedTaskItems)
                {
                  ILog.Info($"ConnectionId: {_ConnectionId}, Task Type: {_TaskPayloadPyroServerIndexing.TaskType.GetPyroLiteral()}, Resource: Task/{MainIndexTask.Id}, Finished indexing Search Parameter: Resource: {TaskItem.ResourceType}, Name: {TaskItem.SearchParameterName}, _SearchParamId: {TaskItem.SearchParamTableId}.");                  
                  TaskItem.TaskStatus = Task.TaskStatus.Completed;
                }
                //Does not commit only updates the Task resource in memory
                UpdateTasksResourceWithProgress(MainIndexTask, Task.TaskStatus.InProgress, TaskInputList);
              }
              catch (Exception Exec)
              {
                _ErrorDetected = true;
                _ErrorMessage = $"ConnectionId: {_ConnectionId}, FHIR Task ID: {MainIndexTask.Id} of type {_TaskPayloadPyroServerIndexing.TaskType.GetPyroLiteral()} has failed. " +
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
                _ErrorMessage = $"ConnectionId: {_ConnectionId}, FHIR Task ID: {MainIndexTask.Id} of type {_TaskPayloadPyroServerIndexing.TaskType.GetPyroLiteral()} has failed. " +
                  $"Error updating servers' SearchParameter IsIndexed to true post re-indexing. See exception message in server logs for more information.";
                ILog.Error(Exec, _ErrorMessage);
              }
            }
          }
        }


        if (!_ErrorDetected)
        {
          ConsoleSupport.TimeStampWriteLine(BackgroundTaskLogMessageSupport.TaskOutCome(_TaskPayloadPyroServerIndexing, Task.TaskStatus.Completed));
          using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
          {            
            if (IFhirTaskTool.UpdateTaskAsStatus(Task.TaskStatus.Completed, MainIndexTask))
            {
              Transaction.Commit();
            }
          }
          ILog.Info($"ConnectionId: {_ConnectionId}, Completed Task Type: {_TaskPayloadPyroServerIndexing.TaskType.GetPyroLiteral()}, Resource: Task/{_TaskPayloadPyroServerIndexing.TaskId}");
        }
        else
        {          
          using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
          {
            if (IFhirTaskTool.UpdateTaskAsStatus(Task.TaskStatus.Failed, MainIndexTask))
            {
              Transaction.Commit();
            }
          }
          //every thing now completed
          ConsoleSupport.TimeStampWriteLine(BackgroundTaskLogMessageSupport.TaskOutCome(_TaskPayloadPyroServerIndexing, Task.TaskStatus.Failed));
          ILog.Info($"ConnectionId: {_ConnectionId}, Failed Task Type: {_TaskPayloadPyroServerIndexing.TaskType.GetPyroLiteral()}, Resource: Task/{_TaskPayloadPyroServerIndexing.TaskId}");
        }
      }
    }

    private void GetResourceTypeSearchParameterDbRecords(IGrouping<string, TaskIndexItem> InputItemForResourceList)
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
            _ErrorMessage = $"ConnectionId: {_ConnectionId}, FHIR Task ID: {_TaskPayloadPyroServerIndexing.TaskId} of type {_TaskPayloadPyroServerIndexing.TaskType.GetPyroLiteral()} has failed. " +
              $"Unable to get DtoServiceSearchParameterHeavy with the Id: {TaskIndexItemForResource.SearchParamTableId}, for ResourceType {TaskIndexItemForResource.ResourceType}, SearchName: {TaskIndexItemForResource.SearchParameterName}.";
            ILog.Error(_ErrorMessage);
            break;
          }
        }
        catch (Exception Exec)
        {
          _ErrorDetected = true;
          _ErrorMessage = $"ConnectionId: {_ConnectionId}, FHIR Task ID: {_TaskPayloadPyroServerIndexing.TaskId} of type {_TaskPayloadPyroServerIndexing.TaskType.GetPyroLiteral()} has failed. " +
            $"Unable to get DtoServiceSearchParameterHeavy with the Id: {TaskIndexItemForResource.SearchParamTableId}, for ResourceType {TaskIndexItemForResource.ResourceType}, SearchName: {TaskIndexItemForResource.SearchParameterName}. See Exception Message for more info.";
          ILog.Error(Exec, _ErrorMessage);
          break;
        }
      }      
    }

    private Task GetFhirTaskAndMarkAsInProgress(string TaskId, Task MainIndexTask)
    {
      using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
      {
        try
        {
          if (TaskId != null)
          {
            ILog.Info($"ConnectionId: {_ConnectionId}, Received Task Type: {_TaskPayloadPyroServerIndexing.TaskType.GetPyroLiteral()}, Resource: Task/{_TaskPayloadPyroServerIndexing.TaskId}");
            //If the TaskId is not null then it is a triggered run with a known Task ID
            IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(ResourceType.Task, TaskId);
            IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.GetRead(TaskId, RequestMeta);
            ResourceServiceOutcome.SummaryType = RequestMeta.SearchParameterGeneric.SummaryType;
            if (ResourceServiceOutcome.HttpStatusCode == System.Net.HttpStatusCode.OK && ResourceServiceOutcome.ResourceResult is Task IndexTask)
            {
              //If this returns false we assume another thread has started the task and we can do nothing. 
              if (IFhirTaskTool.UpdateTaskAsStatus(Task.TaskStatus.InProgress, IndexTask))
              {
                Transaction.Commit();
                MainIndexTask = IndexTask;
              }
            }
          }
          else
          {            
            //If the TaskId is null then it is a run on BackBurner start-up, we search for a single task
            IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set($"{ResourceType.Task.GetLiteral()}?" +
              $"code={Common.PyroHealthFhirResource.CodeSystems.PyroTask.System}|{Common.PyroHealthFhirResource.CodeSystems.PyroTask.Codes.SearchParameterIndexing.GetPyroLiteral()}&" +
              $"status={Task.TaskStatus.Ready.GetLiteral()}");
            IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.GetSearch(RequestMeta);
            ResourceServiceOutcome.SummaryType = RequestMeta.SearchParameterGeneric.SummaryType;
            if (ResourceServiceOutcome.HttpStatusCode == System.Net.HttpStatusCode.OK && ResourceServiceOutcome.ResourceResult is Bundle IndexTaskBundle)
            {
              if (IndexTaskBundle.Total == 1)
              {
                
                var IndexTask = IndexTaskBundle.Entry[0].Resource as Task;
                //If this returns false we assume another thread has started the task and we can do nothing. 
                ILog.Info($"ConnectionId: {_ConnectionId}, Found Task Type: {_TaskPayloadPyroServerIndexing.TaskType.GetPyroLiteral()}, Resource: Task/{IndexTask.Id}");
                if (IFhirTaskTool.UpdateTaskAsStatus(Task.TaskStatus.InProgress, IndexTask))
                {
                  Transaction.Commit();
                  MainIndexTask = IndexTask;
                }
              }
              else if (IndexTaskBundle.Total > 1)
              {
                string FhirIdList = string.Empty;
                foreach (var Res in IndexTaskBundle.Entry)
                {
                  FhirIdList = $"{Res.Resource.Id}, {FhirIdList}";
                }

                ILog.Error($"ConnectionId: {_ConnectionId}, Error detected by background search parameter indexer service. More than one Fhir Task with " +
                  $"code={Common.PyroHealthFhirResource.CodeSystems.PyroTask.System}|{Common.PyroHealthFhirResource.CodeSystems.PyroTask.Codes.SearchParameterIndexing.GetPyroLiteral()} and " +
                  $"status={Task.TaskStatus.Ready.GetLiteral()}. There must only be one Ready task at any time. The list of FHIR Task Ids found is: {FhirIdList}");
              }
            }
          }
        }
        catch (Exception Exec)
        {
          ILog.Error(Exec, $"ConnectionId: {_ConnectionId}, Error in obtaining or setting Task status");
        }
      }

      return MainIndexTask;
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

    private string FormatLogMessage(ITaskPayloadPyroServerIndexing TaskPayloadPyroServerIndexing)
    {
      if (TaskPayloadPyroServerIndexing.TaskId == null)
        return $"ConnectionId: {_ConnectionId}, Run on start-up, Task Type: {TaskPayloadPyroServerIndexing.TaskType.GetPyroLiteral()}";
      else
        return $"ConnectionId: {_ConnectionId}, Received Task Type: {TaskPayloadPyroServerIndexing.TaskType.GetPyroLiteral()}, Resource: Task/{TaskPayloadPyroServerIndexing.TaskId}";
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

using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Enum;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Logging;
using Pyro.Common.RequestMetadata;
using Pyro.Common.Service.ResourceService;
using Pyro.Common.Service.Trigger;
using System;
using System.Data.Entity;

namespace Pyro.Common.Tools.FhirTask
{
  public class FhirTaskTool : IFhirTaskTool
  {

    private readonly IUnitOfWork IUnitOfWork;
    private readonly IResourceServices IResourceServices;    
    private readonly IRequestHeaderFactory IRequestHeaderFactory;
    private readonly IRequestMetaFactory IRequestMetaFactory;
    private readonly IResourceTriggerService IResourceTriggerService;
    private readonly ILog ILog;

    public FhirTaskTool(IUnitOfWork IUnitOfWork,
      IResourceServices IResourceServices,      
      IRequestHeaderFactory IRequestHeaderFactory,
      IRequestMetaFactory IRequestMetaFactory,
      IResourceTriggerService IResourceTriggerService,
      ILog ILog)
    {
      this.IUnitOfWork = IUnitOfWork;
      this.IResourceServices = IResourceServices;      
      this.IRequestHeaderFactory = IRequestHeaderFactory;
      this.IRequestMetaFactory = IRequestMetaFactory;
      this.IResourceTriggerService = IResourceTriggerService;
      this.ILog = ILog;
    }


    public bool UpdateTaskAsStatus(Task.TaskStatus TaskStatus, Task Task)
    {
      try
      {
        //Set the task status only if it has not been updated since we got it from the server, using the IfMatch hearder and the VersionId
        var RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set($"{Task.ResourceType.GetLiteral()}/{Task.Id}");
        RequestMeta.RequestHeader = IRequestHeaderFactory.CreateRequestHeader();
        RequestMeta.RequestHeader.IfMatch = Common.Tools.HttpHeaderSupport.GetETagString(Task.VersionId);

        //Update the Task Properties
        Task.Status = TaskStatus;
        Task.LastModifiedElement = new FhirDateTime(DateTimeOffset.Now);

        this.IResourceTriggerService.TriggersActive = false;
        IResourceServiceOutcome PutResourceServiceOutcome = IResourceServices.Put(Task.Id, Task, RequestMeta);
        this.IResourceTriggerService.TriggersActive = true;
        if (PutResourceServiceOutcome.HttpStatusCode == System.Net.HttpStatusCode.OK)
        {
          Task = PutResourceServiceOutcome.ResourceResult as Task;
          return true;
        }
        else if (PutResourceServiceOutcome.HttpStatusCode == System.Net.HttpStatusCode.Conflict)
        {
          ILog.Warn($"Version conflict on Task status update, Task reference was: {Task.ResourceType.GetLiteral()}/{Task.Id}/_history/{Task.VersionId}.");
          return false;
        }
        else if (PutResourceServiceOutcome.HttpStatusCode == System.Net.HttpStatusCode.Created)
        {
          ILog.Error($"Internal Server Error: UpdateTaskAsStatus failed due to 201 Create being returned when OK Update was expected, Transaction was rolled back. Task reference was: {Task.ResourceType.GetLiteral()}/{Task.Id}");
          return false;
        }
        else
        {
          ILog.Error($"Internal Server Error: UpdateTaskAsStatus failed due to unexpected HTTP status code return, code was {PutResourceServiceOutcome.HttpStatusCode.ToString()}. Task reference was: {Task.ResourceType.GetLiteral()}/{Task.Id}/_history/{Task.VersionId}");
          return false;
        }
      }
      catch (Exception Exec)
      {
        ILog.Error(Exec, $"ResourceSeeding on Startup, PUT operations failed with exception. Task reference was: {Task.ResourceType.GetLiteral()}/{Task.Id}/_history/{Task.VersionId}");
        return false;
      }
    }


    public Task GetFhirTaskAndMarkAsInProgress(string TaskFhirId, string _ConnectionId, BackgroundTaskEnum.BackgroundTaskType _TaskType, Task MainIndexTask)
    {
      using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
      {
        try
        {
          if (TaskFhirId != null)
          {
            ILog.Info($"ConnectionId: {_ConnectionId}, Received Task Type: {_TaskType.GetPyroLiteral()}, Resource: Task/{TaskFhirId}");
            //If the TaskId is not null then it is a triggered run with a known Task ID
            IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(ResourceType.Task, TaskFhirId);
            IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.GetRead(TaskFhirId, RequestMeta);
            ResourceServiceOutcome.SummaryType = RequestMeta.SearchParameterGeneric.SummaryType;
            if (ResourceServiceOutcome.HttpStatusCode == System.Net.HttpStatusCode.OK && ResourceServiceOutcome.ResourceResult is Task IndexTask)
            {
              //If this returns false we assume another thread has started the task and we can do nothing. 
              if (UpdateTaskAsStatus(Task.TaskStatus.InProgress, IndexTask))
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
                ILog.Info($"ConnectionId: {_ConnectionId}, Found Task Type: {_TaskType.GetPyroLiteral()}, Resource: Task/{IndexTask.Id}");
                if (UpdateTaskAsStatus(Task.TaskStatus.InProgress, IndexTask))
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

  }
}

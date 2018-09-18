using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Enum;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Logging;
using Pyro.Common.Service.ResourceService;
using Pyro.Common.Service.Trigger;
using Pyro.Common.PyroHealthFhirResource.CodeSystems;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Pyro.Engine.Services.FhirTasks.FhirSpecLoader;
using Pyro.Engine.Services.FhirTasks.SetCompartment;
using Pyro.Common.Tools.FhirTask;
using Pyro.Common.Global;
using Pyro.Engine.Services.FhirTasks.SearchParameterLoader;

namespace Pyro.Engine.Services.FhirTasks
{
  public class TaskRunner : ITaskRunner
  {
    private readonly IResourceServices IResourceServices;
    private readonly IRequestMetaFactory IRequestMetaFactory;
    private readonly IRequestHeaderFactory IRequestHeaderFactory;
    private readonly ILog ILog;
    private readonly IPyroTask IPyroTaskCodeSystem;
    private readonly IPyroFhirServer IPyroFhirServerCodeSystem;
    private readonly IFhirTaskTool IFhirTaskTool;
    private readonly IGlobalProperties IGlobalProperties;
    private readonly IFhirSpecificationDefinitionLoader IFhirSpecificationDefinitionLoader;
    private readonly ISetCompartmentDefinitionTaskProcessor ISetCompartmentDefinitionTaskProcessor;
    private readonly ISearchParameterResourceLoader ISearchParameterResourceLoader;

    public TaskRunner(IResourceServices IResourceServices,
      IRequestMetaFactory IRequestMetaFactory,
      IRequestHeaderFactory IRequestHeaderFactory,
      ILog ILog,
      IPyroTask IPyroTaskCodeSystem,
      IPyroFhirServer IPyroFhirServerCodeSystem,
      IFhirTaskTool IFhirTaskTool,
      IGlobalProperties IGlobalProperties,
      IFhirSpecificationDefinitionLoader IFhirSpecificationDefinitionLoader,
      ISetCompartmentDefinitionTaskProcessor ISetCompartmentDefinitionTaskProcessor,
      ISearchParameterResourceLoader ISearchParameterResourceLoader)
    {
      this.IResourceServices = IResourceServices;
      this.IRequestMetaFactory = IRequestMetaFactory;
      this.IRequestHeaderFactory = IRequestHeaderFactory;
      this.ILog = ILog;
      this.IPyroTaskCodeSystem = IPyroTaskCodeSystem;
      this.IPyroFhirServerCodeSystem = IPyroFhirServerCodeSystem;
      this.IFhirTaskTool = IFhirTaskTool;
      this.IGlobalProperties = IGlobalProperties;
      this.IFhirSpecificationDefinitionLoader = IFhirSpecificationDefinitionLoader;
      this.ISetCompartmentDefinitionTaskProcessor = ISetCompartmentDefinitionTaskProcessor;
      this.ISearchParameterResourceLoader = ISearchParameterResourceLoader;
    }

    private IEnumerable<PyroFhirServer.Codes> _TaskIdentifierToRunList;

    public void Run(IEnumerable<PyroFhirServer.Codes> TaskIdentifierToRunList)
    {
      _TaskIdentifierToRunList = TaskIdentifierToRunList;
      if (_TaskIdentifierToRunList.Count() > 0)
      {
        List<Task> ReadyTaskOfTasksList = GetServerStartupTaskList();
        ProcessServerStartupTaskList(ReadyTaskOfTasksList);
      }
      else
      {
        ILog.Info("Server start-up: No FHIR Task to be run.");
      }
    }

    /// <summary>
    /// Add new tasks to this method in the order they need to be run.
    /// </summary>
    /// <param name="ReadyTaskOfTasksList"></param>
    /// <returns></returns>
    private List<Task> FilterAndOrderTasksToBeRun(List<Task> ReadyTaskOfTasksList)
    {
      var ReturnTaskList = new List<Task>();

      //Below manages the order that the Task are run. 
      //They are sourced from a search on the server so there is
      //little guarantee of order, so they are selected specifically as below.

      //1. Task: SetSearchDefinitions and Indexes
      Task SetSearchParameterDefinitions = GetTaskByCode(ReadyTaskOfTasksList, PyroTask.Codes.SetSearchParameterDefinitions);
      if (SetSearchParameterDefinitions != null)
      {
        ReturnTaskList.Add(SetSearchParameterDefinitions);
      }

      //2. Task: SetCompartmentDefinitions
      Task SetCompartmentDefinitions = GetTaskByCode(ReadyTaskOfTasksList, PyroTask.Codes.SetCompartmentDefinitions);
      if (SetCompartmentDefinitions != null)
      {
        ReturnTaskList.Add(SetCompartmentDefinitions);
      }

      //3. Task: LoadFhirDefinitionResources
      Task LoadFhirDefinitionResources = GetTaskByCode(ReadyTaskOfTasksList, PyroTask.Codes.LoadFhirDefinitionResources);
      if (LoadFhirDefinitionResources != null)
      {
        if (IGlobalProperties.LoadFhirDefinitionResources)
        {
          ReturnTaskList.Add(LoadFhirDefinitionResources);
        }
      }
      //Report on task to run
      if (ReturnTaskList.Count > 0)
      {
        ILog.Info("Server start-up: FHIR Task to be run:");
        ReturnTaskList.ForEach(x => ILog.Info($"    Fhir Task Id: {x.Id}"));
        ILog.Info("Server start-up: Begin Running Tasks:");
      }
      else
      {
        ILog.Info("Server start-up: No FHIR Task to be run.");
      }
      return ReturnTaskList;
    }

    /// <summary>
    /// Add new tasks to this method providing the service to run the task 
    /// </summary>
    /// <param name="Task"></param>
    /// <param name="TaskTypeCode"></param>
    private void TaskRun(Task Task, PyroTask.Codes TaskTypeCode)
    {
      switch (TaskTypeCode)
      {
        case PyroTask.Codes.LoadFhirDefinitionResources:
          IFhirSpecificationDefinitionLoader.Run(Task);
          break;
        case PyroTask.Codes.SetCompartmentDefinitions:
          ISetCompartmentDefinitionTaskProcessor.Run(Task);
          break;
        case PyroTask.Codes.SetSearchParameterDefinitions:
          ISearchParameterResourceLoader.Run(Task);
          break;
        default:
          throw new System.ApplicationException($"Unhanded Enum of : {TaskTypeCode.ToString()} of Enum type 'PyroTask.Codes' in TaskRunner");
      }
    }

    private List<Task> GetServerStartupTaskList()
    {
      var TaskResultList = new List<Task>();
      string SearchQuery = string.Empty;
      try
      {
        //Get Tasks that are PyroFhirServer 'ServerStartupTask' tasks that have a status of Ready or InProgress or OnHold        
        string IdentifierValue = string.Empty;
        foreach (var Id in _TaskIdentifierToRunList)
        {
          IdentifierValue += $",{IPyroFhirServerCodeSystem.GetSystem()}|{IPyroFhirServerCodeSystem.GetCode(Id)}";
        }
        IdentifierValue = IdentifierValue.TrimStart(',');
        string SearchTaskIdentifier = $"identifier={IdentifierValue}";
        string SearchTaskStatus = $"status={Task.TaskStatus.Ready.GetLiteral()},{Task.TaskStatus.InProgress.GetLiteral()},{Task.TaskStatus.OnHold.GetLiteral()}";
        SearchQuery = $"{SearchTaskIdentifier}&{SearchTaskStatus}";
        var RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set($"{ResourceType.Task}?{SearchQuery}");

        IResourceServiceOutcome PutResourceServiceOutcome = IResourceServices.GetSearch(RequestMeta);
        if (PutResourceServiceOutcome.HttpStatusCode == System.Net.HttpStatusCode.OK && PutResourceServiceOutcome.SuccessfulTransaction)
        {
          if (PutResourceServiceOutcome.ResourceResult != null && PutResourceServiceOutcome.ResourceResult is Bundle Bundle)
          {
            foreach (var Entry in Bundle.Entry)
            {
              if (Entry.Resource != null && Entry.Resource.ResourceType == ResourceType.Task)
                TaskResultList.Add(Entry.Resource as Task);
            }
          }
        }
      }
      catch (Exception Exec)
      {
        ILog.Error(Exec, $"Internal Server Error: Unable to load the list of Tasks of Tasks to process on Pyro Server Start-up. Search Query was: {ResourceType.Task.GetLiteral()}?{SearchQuery}");
      }
      return TaskResultList;
    }

    private void ProcessServerStartupTaskList(List<Task> ReadyTaskOfTasksList)
    {
      var TaskToRunList = FilterAndOrderTasksToBeRun(ReadyTaskOfTasksList);
      //Below managed the order that the Task are run. They are sourced from a search on the server so there is
      //little guarantee of order, so they are selected specifically as below.

      foreach(var TaskToRun in TaskToRunList)
      {
        //Get the tasks Code by the System and then convert to an Enum to pass into the TaskRun
        //If the Enum TryuParse fails then the task will not be processed and picked up by the IsTaskProcessed check below
        bool IsTaskProcessed = false;
        var CodeBySystem = TaskToRun.Code.Coding.SingleOrDefault(x => x.System == IPyroTaskCodeSystem.GetSystem());
        if (CodeBySystem != null)
        {          
          PyroTask.Codes Test;
          if (Enum.TryParse<PyroTask.Codes>(CodeBySystem.Code, out Test))
          {
            ILog.Info($"    Start Task : {TaskToRun.Id}");
            TaskRun(TaskToRun, Test);            
            ILog.Info($"    End Task: {TaskToRun.Id}");
            IsTaskProcessed = true;
          }          
        }       
        if (!IsTaskProcessed)
        {         
          throw new ApplicationException($"Internal Server Error: Detected server start-up Task that did not have a matching service to process it. The Task Resource id list was: {TaskToRun.Id}");
        }
      }
      if (TaskToRunList.Count > 0)
        ILog.Info($"Server start-up: All Tasks have completed"); 
    }

    private Task GetTaskByCode(List<Task> readyTaskOfTasksList, PyroTask.Codes Code)
    {
      try
      {
        var Task = readyTaskOfTasksList.SingleOrDefault(y => y.Code.Coding.Any(a => a.Code == IPyroTaskCodeSystem.GetCode(Code)));
        return Task;
      }
      catch (Exception Exec)
      {
        throw new ApplicationException($"Server start-up Task Resource did not contain a Task.code to identify the Task Type by.", Exec);
      }

    }
  }
}

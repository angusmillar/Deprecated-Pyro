using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Enum;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Logging;
using Pyro.Common.Service.ResourceService;
using Pyro.Common.Service.Trigger;
//using Pyro.Common.PyroHealthFhirResource;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Pyro.Engine.Services.FhirTasks.FhirSpecLoader;
using Pyro.Common.Tools.FhirTask;
using Pyro.Common.Global;

namespace Pyro.Engine.Services.FhirTasks
{
  public class TaskRunner : ITaskRunner
  {    
    private readonly IResourceServices IResourceServices;
    private readonly IRequestMetaFactory IRequestMetaFactory;
    private readonly IRequestHeaderFactory IRequestHeaderFactory;    
    private readonly IFhirSpecificationDefinitionLoader IFhirSpecificationDefinitionLoader;    
    private readonly ILog ILog;
    private readonly Common.PyroHealthFhirResource.CodeSystems.IPyroTask IPyroTaskCodeSystem;
    private readonly Common.PyroHealthFhirResource.CodeSystems.IPyroFhirServer IPyroFhirServerCodeSystem;
    private readonly IFhirTaskTool IFhirTaskTool;
    private readonly IGlobalProperties IGlobalProperties;

    public TaskRunner(IResourceServices IResourceServices,
      IRequestMetaFactory IRequestMetaFactory,
      IRequestHeaderFactory IRequestHeaderFactory,      
      ILog ILog,
      IFhirSpecificationDefinitionLoader IFhirSpecificationDefinitionLoader,      
      Common.PyroHealthFhirResource.CodeSystems.IPyroTask IPyroTaskCodeSystem,
      Common.PyroHealthFhirResource.CodeSystems.IPyroFhirServer IPyroFhirServerCodeSystem,
      IFhirTaskTool IFhirTaskTool,
      IGlobalProperties IGlobalProperties)
    {      
      this.IResourceServices = IResourceServices;
      this.IRequestMetaFactory = IRequestMetaFactory;
      this.IRequestHeaderFactory = IRequestHeaderFactory;      
      this.ILog = ILog;
      this.IFhirSpecificationDefinitionLoader = IFhirSpecificationDefinitionLoader;
      this.IPyroTaskCodeSystem = IPyroTaskCodeSystem;
      this.IPyroFhirServerCodeSystem = IPyroFhirServerCodeSystem;
      this.IFhirTaskTool = IFhirTaskTool;
      this.IGlobalProperties = IGlobalProperties;
    }
    
    private IEnumerable<Common.PyroHealthFhirResource.CodeSystems.PyroFhirServer.Codes> _TaskIdentifierToRunList;

    public void Run(IEnumerable<Common.PyroHealthFhirResource.CodeSystems.PyroFhirServer.Codes> TaskIdentifierToRunList)
    {
      _TaskIdentifierToRunList = TaskIdentifierToRunList;
      if (_TaskIdentifierToRunList.Count() > 0)
      {
        List<Task> ReadyTaskOfTasksList = GetServerStartupTaskList();
        ProcessServerStartupTaskList(ReadyTaskOfTasksList);
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
        ILog.Error(Exec, $"Internal Server Error: Unable to load the list of Tasks of Tasks to process on Pyro Server Startup. Search Query was: {ResourceType.Task.GetLiteral()}?{SearchQuery}");
      }
      return TaskResultList;
    }

    private void ProcessServerStartupTaskList(List<Task> readyTaskOfTasksList)
    {
      foreach (Task Task in readyTaskOfTasksList)
      {
        //Update the status of the task so no other processes (instance of the server) also try and process this task.
        //If this fails do nothing as we are to asume some other process is workng on this task.
        if (IFhirTaskTool.UpdateTaskAsStatus(Task.TaskStatus.InProgress, Task))
        {
          Task.TaskStatus? TaskStatus = null;
          var TaskTypeList = Task.Code?.Coding?.Where(x => x.System == IPyroTaskCodeSystem.GetSystem());
          if (TaskTypeList != null)
          {
            if (TaskTypeList.Any(x => x.Code == IPyroTaskCodeSystem.GetCode(Common.PyroHealthFhirResource.CodeSystems.PyroTask.Codes.LoadFhirSpecResources)) 
              && IGlobalProperties.LoadFhirDefinitionResources)
            {
              //This Task Manages it's own Transaction within
              TaskStatus = IFhirSpecificationDefinitionLoader.Run(Task);              
            }            
            //Add new tasks  here.
          }
        }
      }
    }
    
  }
}

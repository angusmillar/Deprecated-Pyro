using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Enum;
using Pyro.Common.Interfaces.Operation;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Logging;
using Pyro.Common.Tools.FhirTask;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Pyro.Engine.Services.FhirTasks.SetCompartment
{
  public class SetCompartmentDefinitionTaskProcessor : ISetCompartmentDefinitionTaskProcessor
  {
    private readonly ILog ILog;
    private readonly IUnitOfWork IUnitOfWork;
    private readonly IRequestMetaFactory IRequestMetaFactory;
    private readonly IResourceServices IResourceServices;
    private readonly IFhirTaskTool IFhirTaskTool;
    private readonly Common.PyroHealthFhirResource.CodeSystems.IPyroFhirServer IPyroFhirServerCodeSystem;
    private readonly Common.PyroHealthFhirResource.ICompartmentDefinition ICompartmentDefinition;
    private readonly IFhirResourceInstanceOperationService IFhirResourceInstanceOperationService;

    public SetCompartmentDefinitionTaskProcessor(ILog ILog,
      IUnitOfWork IUnitOfWork,
      IRequestMetaFactory IRequestMetaFactory,
      IResourceServices IResourceServices,
      IFhirTaskTool IFhirTaskTool,
      Common.PyroHealthFhirResource.CodeSystems.IPyroFhirServer IPyroFhirServerCodeSystem,
      Common.PyroHealthFhirResource.ICompartmentDefinition ICompartmentDefinition,
      IFhirResourceInstanceOperationService IFhirResourceInstanceOperationService)
    {
      this.ILog = ILog;
      this.IUnitOfWork = IUnitOfWork;
      this.IRequestMetaFactory = IRequestMetaFactory;
      this.IResourceServices = IResourceServices;
      this.IFhirTaskTool = IFhirTaskTool;
      this.IPyroFhirServerCodeSystem = IPyroFhirServerCodeSystem;
      this.ICompartmentDefinition = ICompartmentDefinition;
      this.IFhirResourceInstanceOperationService = IFhirResourceInstanceOperationService;
    }

    //Task.Status (Draft -> Requested -> Received -> Accepted -> Rejected ->
    //             Ready -> Cancelled -> In Progress -> On Hold -> 
    //             Failed -> Completed -> Entered in Error)

    public Task.TaskStatus Run(Task Task)
    {
      try
      {
        ILog.Info("Running Task: SetCompartmentDefinition");

        //Task.TaskStatus? LocalTaskStatus = null;
        Task.ExecutionPeriod = new Period();
        Task.ExecutionPeriod.StartElement = new FhirDateTime(DateTimeOffset.Now);
        //Update the status of the task so that no other processes (instances of the server) also try and process this task can start it.
        //If this fails do nothing as we are to asume some other process is workng on this task, just return InProgress.
        if (!IFhirTaskTool.UpdateTaskAsStatus(Task.TaskStatus.InProgress, Task))
          return Task.TaskStatus.InProgress;

        Task.Output = new List<Task.OutputComponent>();

        if (!ProcessCompartmentDefinitionList(Task))
        {
          using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
          {
            Task.ExecutionPeriod.EndElement = new FhirDateTime(DateTimeOffset.Now);
            IFhirTaskTool.UpdateTaskAsStatus(Task.TaskStatus.Failed, Task);
            Transaction.Commit();
          }
        }
        return Task.Status.Value;
      }
      catch (Exception Exec)
      {
        ILog.Error(Exec, $"Internal Server Error: Transaction was rolled back. " +
          $"Task reference was: {Task.ResourceType.GetLiteral()}/{Task.Id}/_history/{Task.VersionId} The Task was not processed.");
        return Task.TaskStatus.Failed;
      }
    }

    private bool ProcessCompartmentDefinitionList(Task Task)
    {
      ICollection<string> CompartmentDefinitionResourceIdList = new List<string>();
      CompartmentDefinitionResourceIdList.Add(ICompartmentDefinition.PyroCompartmentDefinitionDevice.GetResourceId());
      CompartmentDefinitionResourceIdList.Add(ICompartmentDefinition.PyroCompartmentDefinitionEncounter.GetResourceId());
      CompartmentDefinitionResourceIdList.Add(ICompartmentDefinition.PyroCompartmentDefinitionPatient.GetResourceId());
      CompartmentDefinitionResourceIdList.Add(ICompartmentDefinition.PyroCompartmentDefinitionPractitioner.GetResourceId());
      CompartmentDefinitionResourceIdList.Add(ICompartmentDefinition.PyroCompartmentDefinitionRelatedPerson.GetResourceId());

      using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
      {
        try
        {
          foreach (string ResourceId in CompartmentDefinitionResourceIdList)
          {
            if (!ProcessCompartmentDefinition(ResourceId))
            {
              Task.Status = Task.TaskStatus.Failed;
              Task.Output.Add(AddTaskOutputComponent(ResourceId, Task.TaskStatus.Failed));
              Task.ExecutionPeriod.EndElement = new FhirDateTime(DateTimeOffset.Now);
              return false;
              //Lower method will have logged why
            }
            else
            {
              Task.Output.Add(AddTaskOutputComponent(ResourceId, Task.TaskStatus.Completed));
            }
          }
          Task.ExecutionPeriod.EndElement = new FhirDateTime(DateTimeOffset.Now);
          Task.Status = Task.TaskStatus.Completed;
          IFhirTaskTool.UpdateTaskAsStatus(Task.TaskStatus.Completed, Task);
          Transaction.Commit();
          return true;
        }
        catch (Exception Exec)
        {
          ILog.Warn(Exec, $"Internal Server Error: Attempt to set the server's Compartments based on CompartmentDefinition resources failed. The attempt was rolled back.");
          Transaction.Rollback();
          return false;
        }
      }
    }

    private Task.OutputComponent AddTaskOutputComponent(string ResourceId, Task.TaskStatus Status)
    {
      var TaskOutputComponent = new Task.OutputComponent();
      TaskOutputComponent.Type = new CodeableConcept();
      TaskOutputComponent.Type.Coding = new List<Coding>();
      var StatusCoding = new Coding("http://hl7.org/fhir/task-status", Status.GetLiteral(), Status.GetLiteral());
      TaskOutputComponent.Type.Coding.Add(StatusCoding);
      var Ref = new ResourceReference($"{ResourceType.CompartmentDefinition.GetLiteral()}/{ResourceId}");
      TaskOutputComponent.Value = Ref;
      return TaskOutputComponent;
    }

    private bool ProcessCompartmentDefinition(string ResourceId)
    {
      //First Get the CompartmentDefinition resource 
      //Request: GET [base]/CompartmentDefinition/pyro-patient
      var GetRequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(ResourceType.CompartmentDefinition, $"{ResourceId}");
      var ResourceServiceOutcome = IResourceServices.GetRead(ResourceId, GetRequestMeta);
      if (ResourceServiceOutcome.HttpStatusCode == System.Net.HttpStatusCode.OK)
      {
        if (ResourceServiceOutcome.ResourceResult is CompartmentDefinition Def)
        {
          //Check if it is already an Active Compartment
          var ActiveCoding = IPyroFhirServerCodeSystem.GetCoding(Common.PyroHealthFhirResource.CodeSystems.PyroFhirServer.Codes.ActiveCompartment);
          if (Def.Meta.Tag.Any(x => x.System == ActiveCoding.System && x.Code == ActiveCoding.Code))
          {
            //If it is then set to Active (Note: On server start we will have bypassed the Protected Resource check so need to InActivate and then Activate it to make sure the 
            //Compartment is set correctly against the loaded Resource in the database table [_ServiceCompartment])
            //It is highly likley that this never occurs unless this task run on server that already has Compartments set, first time installs this would never happen.
            //Request: GET [base]/CompartmentDefinition/pyro-patient/x-set-compartment-inactive
            var GetInActivateRequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(ResourceType.CompartmentDefinition, $"{ResourceId}/${FhirOperationEnum.OperationType.xSetCompartmentInActive.GetPyroLiteral()}");
            var ResourceServiceOutcomeGetOpInActive = IFhirResourceInstanceOperationService.ProcessGet(ResourceType.CompartmentDefinition.GetLiteral(), ResourceId, FhirOperationEnum.OperationType.xSetCompartmentInActive.GetPyroLiteral(), GetInActivateRequestMeta);
            //Note: When a Compartment is made InActive it returns 204 NoContent to indicate it has been made InActive
            if (ResourceServiceOutcomeGetOpInActive.HttpStatusCode == System.Net.HttpStatusCode.NoContent)
            {
              return SetCompatmentAsActive(ResourceId);
            }
            else
            {
              ILog.Warn($"The resource CompartmentDefinition/{ResourceId} was marked as an Active compartment yet the server was not able to set the compartment to InActive inorder to update it. The HTTP status returned was: {ResourceServiceOutcome.HttpStatusCode.ToString()}");
              return false;
            }
          }
          else
          {
            //The Compartment is not set as Active so we can just Activate it
            //Note: ToDo: Do we actualy check that a Compartment code i.e 'Patient' is not set twice by two seperate resources?
            return SetCompatmentAsActive(ResourceId);
          }
        }
        else
        {
          ILog.Warn($"Unable to cast FHIR resource returned by get CompartmentDefinition/{ResourceId} to a CompartmentDefinition resource.");
          return false;
        }
      }
      else
      {
        ILog.Warn($"Unable to get the CompartmentDefinition resource inorder to set the Compartment on server startup. The resource was CompartmentDefinition/{ResourceId}. The HTTP status returned was: {ResourceServiceOutcome.HttpStatusCode.ToString()} ");
        return false;
      }
    }

    private bool SetCompatmentAsActive(string ResourceId)
    {
      //need the Code not the ResourceID
      var GetActivateRequestMeta = IRequestMetaFactory.CreateRequestMeta().Set(ResourceType.CompartmentDefinition, $"{ResourceId}/${FhirOperationEnum.OperationType.xSetCompartmentActive.GetPyroLiteral()}");
      var ResourceServiceOutcomeGetOpActive = IFhirResourceInstanceOperationService.ProcessGet(ResourceType.CompartmentDefinition.GetLiteral(), ResourceId, FhirOperationEnum.OperationType.xSetCompartmentActive.GetPyroLiteral(), GetActivateRequestMeta);
      if (ResourceServiceOutcomeGetOpActive.HttpStatusCode == System.Net.HttpStatusCode.OK)
      {
        return true;
      }
      else
      {
        if (ResourceServiceOutcomeGetOpActive.ResourceResult != null && ResourceServiceOutcomeGetOpActive.ResourceResult is OperationOutcome optout)
        {
          if (optout.Issue != null)
          {
            foreach (var Issue in optout.Issue)
            {
              if (Issue.Details != null)
              {
                if (!string.IsNullOrWhiteSpace(Issue.Details.Text))
                {
                  ILog.Error($"Error Setting the {ResourceType.CompartmentDefinition.GetLiteral()} Resource with the FHIR id of '{ResourceId}'. Error message: {Issue.Details.Text}");
                }
              }
            }
          }
        }        
        return false;
      }
    }
  }
}

using Hl7.Fhir.Utility;
using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Web.Hosting;
using Pyro.Common.Logging;
using Pyro.Common.Exceptions;
using Pyro.Common.Tools.FhirTask;
using System.Data.Entity;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Service.Trigger;
using Pyro.Common.Service.ResourceService;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.RequestMetadata;
using Pyro.Common.Interfaces.Operation;
using Pyro.Common.Enum;
using Pyro.Common.FhirOperation.ServerSearchParameter;
using Pyro.Common.Global;
using Pyro.Common.Cache;

namespace Pyro.Engine.Services.FhirTasks.SearchParameterLoader
{
  public class SearchParameterResourceLoader : ISearchParameterResourceLoader
  {
    private readonly ILog ILog;
    private readonly IUnitOfWork IUnitOfWork;
    private readonly IResourceServices IResourceServices;
    private readonly IRequestMetaFactory IRequestMetaFactory;
    private readonly IResourceTriggerService IResourceTriggerService;
    private readonly IFhirTaskTool IFhirTaskTool;
    private readonly IFhirBaseOperationServiceFactory IFhirBaseOperationServiceFactory;
    private readonly IServerSearchParameterOperation IServerSearchParameterOperation;
    private readonly IGlobalProperties IGlobalProperties;
    private readonly ICacheClear ICacheClear;

    private readonly string _ZipFileName = "definitions.xml.zip";
    private readonly string _TaskStatusSystem = "http://hl7.org/fhir/task-status";
    private readonly int _TaskCommitBlockSize = 500;

    private List<string> _SearchParameterResourceProcessedIdList;
    private string _ResourceIdInProgress = string.Empty;
    private string _ResourceIdInError = string.Empty;
    private string _InErrorMessage = string.Empty;
    private int TotalCounter;
    private Task _Task;
    private Task.TaskStatus _CurrentTaskStatus = Task.TaskStatus.InProgress;
    private Bundle _SearchParameterBundle = null;

    public SearchParameterResourceLoader(ILog ILog,
      IFhirTaskTool IFhirTaskTool,
      IResourceServices IResourceServices,
      IUnitOfWork IUnitOfWork,
      IResourceTriggerService IResourceTriggerService,
      IRequestMetaFactory IRequestMetaFactory,
      IFhirBaseOperationServiceFactory IFhirBaseOperationServiceFactory,
      IServerSearchParameterOperation IServerSearchParameterOperation,
      IGlobalProperties IGlobalProperties,
      ICacheClear ICacheClear)
    {
      this.ILog = ILog;
      this.IFhirTaskTool = IFhirTaskTool;
      this.IUnitOfWork = IUnitOfWork;
      this.IResourceTriggerService = IResourceTriggerService;
      this.IResourceServices = IResourceServices;
      this.IRequestMetaFactory = IRequestMetaFactory;
      this.IFhirBaseOperationServiceFactory = IFhirBaseOperationServiceFactory;
      this.IServerSearchParameterOperation = IServerSearchParameterOperation;
      this.IGlobalProperties = IGlobalProperties;
      this.ICacheClear = ICacheClear;
    }


    public Task.TaskStatus Run(Task Task)
    {
      _Task = Task;
      IGlobalProperties.ServerReadOnlyMode = true;
      IGlobalProperties.ServerReadOnlyModeMessage =
        "The server is currently running a first time start-up task which loads all the base FHIR " +
        "specification search parameter resources as active search indexes within the Pyro FHIR server. " +
        $"This Task can be monitored by performing a GET on the servers Task endpoint for the Id of '{_Task.Id}'. " +
        $"For example: 'GET [base]/Task/{_Task.Id}'. While this Task is in progress the server can not allow resource writes " +
        $"to the server as these resources would not have their search parameter values indexed. Only once the Task is finished " +
        $"and all base search parameters are loaded will the server automatically switch out of read only mode. ";



      _SearchParameterResourceProcessedIdList = new List<string>();
      try
      {
        _Task.ExecutionPeriod = new Period();
        _Task.ExecutionPeriod.StartElement = new FhirDateTime(DateTimeOffset.Now);
        //Update the status of the task so that no other processes (instances of the server) also try and process this task can start it.
        //If this fails do nothing as we are to assume some other process is working on this task, just return InProgress.
        if (!IFhirTaskTool.UpdateTaskAsStatus(Task.TaskStatus.InProgress, _Task))
        {
          IGlobalProperties.ServerReadOnlyMode = false;
          ICacheClear.ClearCache();
          return Task.TaskStatus.InProgress;
        }

        SetParametersBeforeRunningTaskLoad(_Task);

        _Task.Output = new List<Task.OutputComponent>();
        //We process each file in the zip one at a time and commit and update the Task each time.
        //Once the IFhirSpecificationDefinitionLoaderParameters.TaskStatus == Completed we then return, or return is the Load retunes false. 
        while (_CurrentTaskStatus == Task.TaskStatus.InProgress)
        {
          _SearchParameterBundle = LoadFromZip();
          if (_SearchParameterBundle != null)
          {
            TotalCounter = 0;
            int CommitBlockCounter = 0;
            IGlobalProperties.ServerReadOnlyModeMessage = SetServerReadOnlyMessage(0, _SearchParameterBundle.Entry.Count, _Task.Id);
            foreach (var Entry in _SearchParameterBundle.Entry)
            {
              TotalCounter++;
              IGlobalProperties.ServerReadOnlyModeMessage = SetServerReadOnlyMessage(TotalCounter, _SearchParameterBundle.Entry.Count, _Task.Id);
              if (Entry.Resource != null)
              {
                if (Entry.Resource is SearchParameter SearchParam)
                {
                  SpecificationCorrections(SearchParam);
                  if (!_SearchParameterResourceProcessedIdList.Contains(SearchParam.Id))
                  {
                    //Increment Counter end of loop
                    CommitBlockCounter++;
                    using (DbContextTransaction TransactionSet = IUnitOfWork.BeginTransaction())
                    {
                      try
                      {
                        _ResourceIdInProgress = SearchParam.Id;
                        AddSearchParameterResourceToServer(SearchParam);
                        if (FilterSearchParametersToSet(SearchParam))
                        {
                          if (!SetSearchParameterServerIndex(SearchParam.Id))
                          {
                            IGlobalProperties.ServerReadOnlyMode = false;
                            ICacheClear.ClearCache();
                            throw new Exception("Failed to Set index!");
                          }
                        }
                        _SearchParameterResourceProcessedIdList.Add(_ResourceIdInProgress);
                        TransactionSet.Commit();
                      }
                      catch (Exception Exec)
                      {
                        TransactionSet.Rollback();
                        using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
                        {
                          _InErrorMessage = Exec.Message;
                          _ResourceIdInError = _ResourceIdInProgress;
                          _CurrentTaskStatus = Task.TaskStatus.Failed;
                          SetParametersOnFailedTaskLoad(_Task);
                          IFhirTaskTool.UpdateTaskAsStatus(_Task.Status.Value, _Task);
                          Transaction.Commit();
                          break;
                        }
                      }
                    }
                  }
                }
                else
                {
                  string Message = "Internal Server Error: The search-parameter.xml file contained a non SearchParameter Resource Type as an entry, found type {Entry.Resource.TypeName}.";
                  using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
                  {
                    _InErrorMessage = Message;
                    SetParametersOnFailedTaskLoad(_Task);
                    IFhirTaskTool.UpdateTaskAsStatus(_Task.Status.Value, _Task);
                    Transaction.Commit();
                  }
                  IGlobalProperties.ServerReadOnlyMode = false;
                  ICacheClear.ClearCache();
                  throw new Exception(Message);
                }
              }
              else
              {
                string Message = $"Internal Server Error: The search-parameter.xml file contained a null resource entry.";
                using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
                {
                  _InErrorMessage = Message;
                  SetParametersOnFailedTaskLoad(_Task);
                  IFhirTaskTool.UpdateTaskAsStatus(_Task.Status.Value, _Task);
                  Transaction.Commit();
                }
                IGlobalProperties.ServerReadOnlyMode = false;
                ICacheClear.ClearCache();
                throw new Exception(Message);
              }

              //After each blockSize Commit the current progress to the Task
              //It is ok if we process SearchParameters that have already been processed as all that will happen is the 
              //SearchParameter Resource will be Updated and the SearchIndex will not be set again.
              if (CommitBlockCounter == _TaskCommitBlockSize)
              {
                using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
                {
                  SetParametersInProgressTaskLoad(_Task);
                  IFhirTaskTool.UpdateTaskAsStatus(_Task.Status.Value, _Task);
                  Transaction.Commit();
                }
                CommitBlockCounter = 0;
              }
            }

            //Finished all so mark as Completed
            if (_CurrentTaskStatus == Task.TaskStatus.InProgress)
            {
              ProcessCompositeSearchParameters();
              using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
              {
                SetParametersOnCompletedTaskLoad(_Task);
                IFhirTaskTool.UpdateTaskAsStatus(_Task.Status.Value, _Task);
                Transaction.Commit();
                _CurrentTaskStatus = Task.TaskStatus.Completed;
                IGlobalProperties.ServerReadOnlyMode = false;
                ICacheClear.ClearCache();
              }
            }
          }
        }
        return _CurrentTaskStatus;
      }
      catch (Exception Exec)
      {
        ILog.Error(Exec, $"Internal Server Error: Transaction was rolled back. " +
          $"Task reference was: {_Task.ResourceType.GetLiteral()}/{_Task.Id}/_history/{_Task.VersionId} The Task was not processed.");
        IGlobalProperties.ServerReadOnlyMode = false;
        ICacheClear.ClearCache();
        return Task.TaskStatus.Failed;
      }
    }


    private void ProcessCompositeSearchParameters()
    {
      List<SearchParameter> CompositeSearchParameterList = GetCompositeSearchParameterList();

      foreach (SearchParameter SearchParam in CompositeSearchParameterList)
      {
        TotalCounter++;
        IGlobalProperties.ServerReadOnlyModeMessage = SetServerReadOnlyMessage(TotalCounter, _SearchParameterBundle.Entry.Count, _Task.Id);

        using (DbContextTransaction TransactionSet = IUnitOfWork.BeginTransaction())
        {
          IGlobalProperties.ServerReadOnlyModeMessage = SetServerReadOnlyMessage(TotalCounter, _SearchParameterBundle.Entry.Count, _Task.Id);
          try
          {
            _ResourceIdInProgress = SearchParam.Id;
            AddSearchParameterResourceToServer(SearchParam);

            if (!SetSearchParameterServerIndex(SearchParam.Id))
            {
              IGlobalProperties.ServerReadOnlyMode = false;
              ICacheClear.ClearCache();
              throw new Exception("Failed to Set index!");
            }
            _SearchParameterResourceProcessedIdList.Add(_ResourceIdInProgress);
            TransactionSet.Commit();
          }
          catch (Exception Exec)
          {
            TransactionSet.Rollback();
            using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
            {
              _InErrorMessage = Exec.Message;
              _ResourceIdInError = _ResourceIdInProgress;
              _CurrentTaskStatus = Task.TaskStatus.Failed;
              SetParametersOnFailedTaskLoad(_Task);
              IFhirTaskTool.UpdateTaskAsStatus(_Task.Status.Value, _Task);
              Transaction.Commit();
              break;
            }
          }
        }
      }
    }

    private void SpecificationCorrections(SearchParameter SearchParameter)
    {
      //################################################################################################
      //This is an correction to the FHIR specification SearchParameter definitions found in the  
      //definitions.xml.zip file required for STU3, I believe it is fixed in R4 and it should be removed once tested that it is not hit.
      string IncorrectCanonicalUrl = "http://hl7.org/fhir/SearchParameter/Observation-code";
      string CorrectCanonicalUrl = "http://hl7.org/fhir/SearchParameter/clinical-code";
      var BrokenComponetList = SearchParameter.Component.Where(z => z.Definition == IncorrectCanonicalUrl);      
      foreach (var BrokenComponet in BrokenComponetList)
      {
        BrokenComponet.Definition = CorrectCanonicalUrl;
      }

      //################################################################################################
      //This FHIRPath expression fails to work and yet this correct does work, issues found in FHRI R4 3.5.0.
      //The old Expression was :
      //Expression = AuditEvent.agent.who.where(resolve() is Patient) | AuditEvent.entity.what.where(resolve() is Patient)
      if (SearchParameter.Name == "patient" && SearchParameter.Base.Contains(ResourceType.AuditEvent))
      {
        SearchParameter.Expression = "AuditEvent.entity.what.where(reference.startsWith('Patient')) | AuditEvent.agent.who.where(reference.startsWith('Patient'))"
      }
    }
    

    private List<SearchParameter> GetCompositeSearchParameterList()
    {
      List<SearchParameter> CompositeSearchParameterList = new List<SearchParameter>();
      foreach (var Entry in _SearchParameterBundle.Entry)
      {
        if (Entry.Resource != null)
        {
          if (Entry.Resource is SearchParameter SearchParam)
          {
            SpecificationCorrections(SearchParam);
            if (SearchParam.Type == SearchParamType.Composite)
              CompositeSearchParameterList.Add(SearchParam);
          }
        }
      }      
      return CompositeSearchParameterList;
    }

    private string SetServerReadOnlyMessage(int SerachParameterResourceCount, int SerachParameterResourceTotal, string TaskFhirID)
    {
      //Add another 31 to cover the Composite parameters that get loaded.
      SerachParameterResourceTotal = SerachParameterResourceTotal + 31;
      return $"Progress: ({SerachParameterResourceCount.ToString()}/{SerachParameterResourceTotal.ToString()}). The server is currently running a first time start-up task which loads all the base FHIR " +
             "specification search parameter resources as active search indexes within the Pyro FHIR server. " +
             $"The Task has completed {SerachParameterResourceCount.ToString()} of a total of {SerachParameterResourceTotal.ToString()} SearchParameter resources, so far. " +
             $"This Task can be monitored here or by performing a GET on the servers Task endpoint for the Id of '{TaskFhirID}'. " +
             $"For example: 'GET [base]/Task/{TaskFhirID}'. " +
             $"While this Task is in progress the server can not allow resource writes " +
             $"to the server as these resources would not have their search parameter values indexed. Only once the Task is finished " +
             $"and all base search parameters are loaded will the server automatically switch out of read only mode. " +
             $"This task is only required to run once on a new server install and should be complete in roughly 10 min. " +
             $"Thank you for your patience.";
    }

    private bool FilterSearchParametersToSet(SearchParameter SearchParam)
    {
      if (SearchParam.Expression == null)
      {
        //SearchParameter Resource that have no expression can not be tuened into working search parameters and are their for filtered out.
        //Here is the know SearchParameters that fall into this category:
        //Base = "DomainResource", SearchParam.Id == "DomainResource-text"
        //Base = "Resource", SearchParam.Id == "Resource-content"
        //Base = "Resource", SearchParam.Id == "Resource-query"
        //Base = "DataElement", SearchParam.Id == "elementdefinition-11179-DataElement-objectClass"
        //Base = "DataElement", SearchParam.Id == "elementdefinition-11179-DataElement-objectClassProperty"     
        return false;
      }

      //Composite Search Parameters types must be filtered out from the first pass
      //and then later added at the very end as they are dependant of the other parameters having been loaded 
      //first.
      if (SearchParam.Type == SearchParamType.Composite)
      {
        return false;
      }

      return true;
    }

    private bool SetSearchParameterServerIndex(string Id)
    {
      string ResourceName = ResourceType.SearchParameter.GetLiteral();
      Parameters Parameters = new Parameters();
      Parameters.Parameter = new List<Parameters.ParameterComponent>();
      var ParameterComponent = new Parameters.ParameterComponent();
      Parameters.Parameter.Add(ParameterComponent);
      ParameterComponent.Name = $"{ResourceName}";
      var Ref = new ResourceReference();
      IRequestMeta RequestMetaTemp = IRequestMetaFactory.CreateRequestMeta().Set($"{ResourceName}/{Id}");
      Ref.Reference = $"{RequestMetaTemp.PyroRequestUri.FhirRequestUri.OriginalString}";
      ParameterComponent.Value = Ref;
      string OperationName = FhirOperationEnum.OperationType.ServerIndexesSet.GetPyroLiteral();
      IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set("");
      try
      {
        IFhirBaseOperationService FhirBaseOperationService = IFhirBaseOperationServiceFactory.CreateFhirBaseOperationService();
        IResourceServiceOutcome ResourceServiceOutcome = IServerSearchParameterOperation.ProcessSet(RequestMeta.PyroRequestUri, RequestMeta.SearchParameterGeneric, Parameters, true);
        if (ResourceServiceOutcome.HttpStatusCode == System.Net.HttpStatusCode.OK)
        {
          return true;
        }
        else
        {
          string OperationOutcomeMessage = string.Empty;
          if (ResourceServiceOutcome.ResourceResult != null && ResourceServiceOutcome.ResourceResult is OperationOutcome OptOut)
          {
            OptOut.Issue.ForEach(x => OperationOutcomeMessage = OperationOutcomeMessage + " " + x.Details.Text);
            string Message = $"Internal Server Error: Failed to Set SearchParameter Server index calling operation ${OperationName} with the SearchParmeter Resource {RequestMetaTemp.PyroRequestUri.FhirRequestUri.OriginalString} with extra detail: {OperationOutcomeMessage}";
            ILog.Error(Message);
            throw new Exception(Message);
          }
          else
          {
            string Message = $"Internal Server Error: Failed to Set SearchParameter Server index calling operation ${OperationName} with the SearchParmeter Resource {RequestMetaTemp.PyroRequestUri.FhirRequestUri.OriginalString}";
            ILog.Error(Message);
            throw new Exception(Message);
          }
        }
      }
      catch (Exception Exec)
      {
        string Message = $"{Exec.Message},  Internal Server Error: Failed to Set SearchParameter Server index calling operation ${OperationName}";
        ILog.Error(Exec, Message);
        throw new Exception(Message);
      }
    }

    private bool AddSearchParameterResourceToServer(SearchParameter SearchParam)
    {
      try
      {
        IResourceTriggerService.TriggersActive = false;
        var RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set($"{SearchParam.TypeName}/{SearchParam.Id}");
        IResourceServiceOutcome ResourceServiceOutcome = IResourceServices.Put(SearchParam.Id, SearchParam, RequestMeta);
        IResourceTriggerService.TriggersActive = true;
        if (ResourceServiceOutcome.SuccessfulTransaction)
        {
          return true;
        }
        else
        {
          string OperationOutcomeMessage = string.Empty;
          if (ResourceServiceOutcome.ResourceResult != null && ResourceServiceOutcome.ResourceResult is OperationOutcome OptOut)
          {
            OptOut.Issue.ForEach(x => OperationOutcomeMessage = OperationOutcomeMessage + " " + x.Details);

            string Message = $"Internal Server Error: SearchParameter Resource from FHIR specification zip file named: {_ZipFileName}, file 'search-parameters.xml' did not commit to the Fhir Server. " +
              $"The PUT failed withHTTP Status: {ResourceServiceOutcome.HttpStatusCode} and the detail: {OperationOutcomeMessage}";
            ILog.Error(Message);
            throw new PyroException(System.Net.HttpStatusCode.InternalServerError, OptOut, Message);
          }
          else
          {
            string Message = $"Internal Server Error: SearchParameter Resource from FHIR specification zip file named: {_ZipFileName}, file 'search-parameters.xml' did not commit to the Fhir Server. " +
              $"The PUT failed withHTTP Status: {ResourceServiceOutcome.HttpStatusCode}";
            ILog.Error(Message);
            throw new Exception(Message);
          }
        }
      }
      catch (Exception Exec)
      {
        string Message = $"Internal Server Error: Could not commit the transaction bundle from the FHIR specification zip file named: {_ZipFileName}, file 'search-parameters.xml' SearchParameter Resource entry the Id of '{SearchParam.Id}'.";
        ILog.Error(Exec, Message);
        throw new Exception(Message);
      }
    }

    private void SetParametersBeforeRunningTaskLoad(Task Task)
    {
      Task.Status = Task.TaskStatus.InProgress;

      foreach (var Out in Task.Output)
      {
        if (Out.Type.Coding.Any(x => x.System == _TaskStatusSystem && x.Code == Task.TaskStatus.Completed.GetLiteral()))
        {
          if (Out.Value is FhirString ResourceId)
          {
            _SearchParameterResourceProcessedIdList.Add(ResourceId.Value);
          }
        }
        else if (Out.Type.Coding.Any(x => x.System == _TaskStatusSystem && x.Code == Task.TaskStatus.InProgress.GetLiteral()))
        {
          if (string.IsNullOrWhiteSpace(_ResourceIdInProgress))
          {
            if (Out.Value is FhirString FileNameString)
            {
              _ResourceIdInProgress = FileNameString.Value;
            }
          }
          else
          {
            throw new Exception($"Internal Server Error: Task can not have more than one FIle in Progress at any one time. Task is {Task.ResourceType.GetLiteral()}/{Task.Id}");
          }
        }
        //Note: we ignore any FileInError as we only collect Task of status == InProgress or Ready.
        // If a user somehow changed a Task status back to InProgress or Ready and yet an old Output is set to Failed the we
        // are to assume they want us to try again, in this case the FileInError and FileInProgress should be the same file.
        // The process will start again at the FileInProgress.
      }
    }

    private void SetParametersInProgressTaskLoad(Task Task)
    {
      Task.Status = Task.TaskStatus.InProgress;

      Task.Output = new List<Task.OutputComponent>();
      //Update Task Completed LIst
      foreach (string FileNameCompleted in _SearchParameterResourceProcessedIdList)
      {
        var FhirStringValue = new FhirString(FileNameCompleted);
        var MyCodableConcept = new CodeableConcept(_TaskStatusSystem, Task.TaskStatus.Completed.GetLiteral(), Task.TaskStatus.Completed.GetLiteral());
        Task.Output.Add(new Task.OutputComponent() { Type = MyCodableConcept, Value = FhirStringValue });
      }

      if (!string.IsNullOrWhiteSpace(_ResourceIdInProgress))
      {
        var FhirStringValue = new FhirString(_ResourceIdInProgress);
        var MyCodableConcept = new CodeableConcept(_TaskStatusSystem, Task.TaskStatus.InProgress.GetLiteral(), Task.TaskStatus.InProgress.GetLiteral());
        Task.Output.Add(new Task.OutputComponent() { Type = MyCodableConcept, Value = FhirStringValue });
      }
    }

    private void SetParametersOnCompletedTaskLoad(Task Task)
    {
      Task.Status = Task.TaskStatus.Completed;
      Task.ExecutionPeriod.EndElement = new FhirDateTime(DateTimeOffset.Now);

      Task.Output = new List<Task.OutputComponent>();
      //Update Task Completed LIst
      foreach (string FileNameCompleted in _SearchParameterResourceProcessedIdList)
      {
        var FhirStringValue = new FhirString(FileNameCompleted);
        var MyCodableConcept = new CodeableConcept(_TaskStatusSystem, Task.TaskStatus.Completed.GetLiteral(), Task.TaskStatus.Completed.GetLiteral());
        Task.Output.Add(new Task.OutputComponent() { Type = MyCodableConcept, Value = FhirStringValue });
      }
    }

    private void SetParametersOnFailedTaskLoad(Task Task)
    {
      Task.Status = Task.TaskStatus.Failed;
      Task.ExecutionPeriod.EndElement = new FhirDateTime(DateTimeOffset.Now);

      Task.Output = new List<Task.OutputComponent>();
      //Update Task Completed LIst
      foreach (string FileNameCompleted in _SearchParameterResourceProcessedIdList)
      {
        var FhirStringValue = new FhirString(FileNameCompleted);
        var MyCodableConcept = new CodeableConcept(_TaskStatusSystem, Task.TaskStatus.Completed.GetLiteral(), Task.TaskStatus.Completed.GetLiteral());
        Task.Output.Add(new Task.OutputComponent() { Type = MyCodableConcept, Value = FhirStringValue });
      }

      //Update Task InProgress
      if (_CurrentTaskStatus == Task.TaskStatus.InProgress && !string.IsNullOrWhiteSpace(_ResourceIdInProgress))
      {
        var FhirStringValue = new FhirString(_ResourceIdInProgress);
        var MyCodableConcept = new CodeableConcept(_TaskStatusSystem, Task.TaskStatus.Failed.GetLiteral(), Task.TaskStatus.Failed.GetLiteral());
        Task.Output.Add(new Task.OutputComponent() { Type = MyCodableConcept, Value = FhirStringValue });
      }

      //Update Task Failed
      if (_CurrentTaskStatus == Task.TaskStatus.Failed && !string.IsNullOrWhiteSpace(_ResourceIdInError) && !string.IsNullOrWhiteSpace(_InErrorMessage))
      {
        var FhirStringValue = new FhirString(_InErrorMessage);
        var MyCodableConcept = new CodeableConcept(_TaskStatusSystem, Task.TaskStatus.Failed.GetLiteral(), Task.TaskStatus.Failed.GetLiteral());
        Task.Output.Add(new Task.OutputComponent() { Type = MyCodableConcept, Value = FhirStringValue });
      }
    }

    private Bundle LoadFromZip()
    {
      Stream FileStream = new MemoryStream(Common.CommonResource.definitions_xml);
      try
      {
        using (ZipArchive Archive = new ZipArchive(FileStream))
        {
          foreach (ZipArchiveEntry Entry in Archive.Entries)
          {
            if (Entry.FullName.Equals("search-parameters.xml", StringComparison.OrdinalIgnoreCase))
            {
              //Pick processing from where it was last left off

              Stream StreamItem = Entry.Open();
              using (StreamItem)
              {
                try
                {
                  var buffer = new MemoryStream();
                  StreamItem.CopyTo(buffer);
                  buffer.Seek(0, SeekOrigin.Begin);
                  System.Xml.XmlReader XmlReader = SerializationUtil.XmlReaderFromStream(buffer);
                  Resource Resource = Common.Tools.FhirResourceSerializationSupport.DeSerializeFromXml(XmlReader);
                  if (Resource is Bundle Bundle)
                  {
                    return Bundle;
                  }
                }
                catch (PyroException PyroExec)
                {
                  string ErrorMessage = $"Internal Server Error: Exception thrown when DeSerializing FHIR resources from the FHIR specification zip file named: {_ZipFileName}. See server logs for more info.";
                  ILog.Error(PyroExec, ErrorMessage);
                }
              }
            }
          }
        }
        return null;
      }
      catch (Exception Exec)
      {
        string ErrorMessage = $"Internal Server Error: Exception thrown when unzipping FHIR specification zip file named: {_ZipFileName}.";
        ILog.Error(Exec, ErrorMessage);
        return null;
      }
    }

  }
}

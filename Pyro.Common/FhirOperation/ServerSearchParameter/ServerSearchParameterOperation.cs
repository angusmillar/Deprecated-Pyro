using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.BackgroundTask.TaskPayload;
using Pyro.Common.Cache;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Enum;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.PyroHealthFhirResource.Tasks;
using Pyro.Common.RequestMetadata;
using Pyro.Common.Search;
using Pyro.Common.Service.ResourceService;
using Pyro.Common.Service.SearchParameters;
using Pyro.Common.Tools.UriSupport;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pyro.Common.FhirOperation.ServerSearchParameter
{
  public class ServerSearchParameterOperation : IServerSearchParameterOperation
  {
    private readonly IResourceServices IResourceServices;
    private readonly IRequestMetaFactory IRequestMetaFactory;
    private readonly IServiceSearchParameterService IServiceSearchParameterService;
    private readonly IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory;
    private readonly IPyroFhirUriFactory IPyroFhirUriFactory;
    private readonly ISearchParameterServiceFactory ISearchParameterServiceFactory;
    private readonly ICacheClear ICacheClear;
    private readonly ISearchParameterIndexing ISearchParameterIndexing;
    private readonly IBackgroundTaskPayload IBackgroundTaskPayload;
    private readonly IServiceFhirTaskQueue IServiceFhirTaskQueue;

    private const string _ParameterName = "ResourceType";
    private SearchParameter TargetSearchParameter;
    private List<DtoServiceSearchParameterHeavy> _DbSearchParamListForResource;

    public ServerSearchParameterOperation(IResourceServices IResourceServices, IRequestMetaFactory IRequestMetaFactory, IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory, IPyroFhirUriFactory IPyroFhirUriFactory, ICacheClear ICacheClear, ISearchParameterServiceFactory ISearchParameterServiceFactory, IServiceSearchParameterService IServiceSearchParameterService, ISearchParameterIndexing ISearchParameterIndexing, IBackgroundTaskPayload IBackgroundTaskPayload, IServiceFhirTaskQueue IServiceFhirTaskQueue)
    {
      this.IResourceServices = IResourceServices;
      this.IRequestMetaFactory = IRequestMetaFactory;
      this.IResourceServiceOutcomeFactory = IResourceServiceOutcomeFactory;
      this.IPyroFhirUriFactory = IPyroFhirUriFactory;
      this.ICacheClear = ICacheClear;
      this.ISearchParameterServiceFactory = ISearchParameterServiceFactory;
      this.IServiceSearchParameterService = IServiceSearchParameterService;
      this.ISearchParameterIndexing = ISearchParameterIndexing;
      this.IBackgroundTaskPayload = IBackgroundTaskPayload;
      this.IServiceFhirTaskQueue = IServiceFhirTaskQueue;
    }

    /// <summary>
    /// This creates a FHIR Task to be processed later to Create the indexes for all un-indexes indexes.
    /// </summary>
    /// <param name="RequestUri"></param>
    /// <param name="SearchParameterGeneric"></param>
    /// <param name="Resource"></param>
    /// <returns></returns>
    public IResourceServiceOutcome ProcessIndex(
      IPyroRequestUri RequestUri,
      ISearchParameterGeneric SearchParameterGeneric,
      Resource Resource)
    {
      if (Resource == null)
        throw new NullReferenceException("Resource cannot be null.");
      if (RequestUri == null)
        throw new NullReferenceException("RequestUri cannot be null.");
      if (SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric cannot be null.");
      if (IResourceServices == null)
        throw new NullReferenceException("IResourceServices cannot be null.");

      IResourceServiceOutcome ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();

      ISearchParameterService SearchService = ISearchParameterServiceFactory.CreateSearchParameterService();
      ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchService.ProcessBaseSearchParameters(SearchParameterGeneric);
      if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
      {
        ResourceServiceOutcome.ResourceResult = SearchParametersServiceOutcome.FhirOperationOutcome;
        ResourceServiceOutcome.HttpStatusCode = SearchParametersServiceOutcome.HttpStatusCode;
        ResourceServiceOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
        return ResourceServiceOutcome;
      }
      ResourceServiceOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;

      //Check there is not already a indexing Task running or ready to run
      //That is a task of Type 'SetSearchParameterDefinitions' with a status of Ready or InProgress.
      //If so error, the user needs to Stop the task before starting a new one. not sure how just yet
      IRequestMeta GetRequest = IRequestMetaFactory
        .CreateRequestMeta().Set(
        $"{ResourceType.Task.GetLiteral()}?code={Common.PyroHealthFhirResource.CodeSystems.PyroTask.System}|{Common.PyroHealthFhirResource.CodeSystems.PyroTask.Codes.SetSearchParameterDefinitions.GetPyroLiteral()}&status={Task.TaskStatus.InProgress.GetLiteral()},{Task.TaskStatus.Ready.GetLiteral()}");
      var GetOutcome = IResourceServices.GetSearch(GetRequest);
      if (GetOutcome.HttpStatusCode == System.Net.HttpStatusCode.OK)
      {
        if (GetOutcome.ResourceResult != null && GetOutcome.ResourceResult is Bundle TaskBundle)
        {
          if (TaskBundle.Total == 1)
          {
            string Message = $"Their is already an indexing Task in a Ready or InProgress state. This task must either be allowed to Complete or must be Cancelled " +
              $"before a new Task can be created.";
            var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Warning, OperationOutcome.IssueType.BusinessRule, Message);
            ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
            ResourceServiceOutcome.ResourceResult = OpOutCome;
            ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Create;
            ResourceServiceOutcome.SuccessfulTransaction = false;
            return ResourceServiceOutcome;
          }
          else if (TaskBundle.Total > 1)
          {
            string Message = $"Internal Server Error: There are multiple indexing Tasks in a Ready or InProgress state. This is not allowed and indicates a server error for investigation.";
            var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Message);
            ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
            ResourceServiceOutcome.ResourceResult = OpOutCome;
            ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Create;
            ResourceServiceOutcome.SuccessfulTransaction = false;
            return ResourceServiceOutcome;
          }
        }
      }


      //No pending Task so generate a new one
      List<DtoServiceSearchParameterHeavy> DbSearchParameterList = IServiceSearchParameterService.GetServiceSearchParametersHeavyByIsIndexed(false);
      //Check their are some to index to create and create a Task is this is the case.
      Task IndexTask = null;
      if (DbSearchParameterList.Count > 0)
      {
        IndexTask = ISearchParameterIndexing.GetResource();
        IndexTask.Id = null;
        IndexTask.Input = new List<Task.ParameterComponent>();
        foreach (var SearchParameter in DbSearchParameterList)
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
          IdComponent.Value = new Hl7.Fhir.Model.Integer() { Value = SearchParameter.Id };
          IndexTask.Input.Add(IdComponent);

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
          ResourceComponent.Value = new Hl7.Fhir.Model.FhirString() { Value = SearchParameter.Resource };
          IndexTask.Input.Add(ResourceComponent);

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
          NameComponent.Value = new Hl7.Fhir.Model.FhirString() { Value = SearchParameter.Name };
          IndexTask.Input.Add(NameComponent);
        }

        //Commit the New Task to the server and return that Task resource in a 
        //Parameters resource response to the operation
        //Create a BackgroundTask to trigger the work to be performed out of band.
        var Request = IRequestMetaFactory.CreateRequestMeta();
        Request.Set(ResourceType.Task, "");
        var PostOutcome = IResourceServices.Post(IndexTask, Request);
        if (PostOutcome.HttpStatusCode == System.Net.HttpStatusCode.Created)
        {
          //Task was committed create Parameters resource to return  
          Parameters Param = new Parameters();
          Param.Parameter = new List<Parameters.ParameterComponent>();
          var Component = new Parameters.ParameterComponent();
          Param.Parameter.Add(Component);
          Component.Name = "BackgroundIndexingTask";
          Component.Resource = PostOutcome.ResourceResult;

          ResourceServiceOutcome.ResourceResult = Param;
          ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;
          ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Create;
          ResourceServiceOutcome.SuccessfulTransaction = true;
          ResourceServiceOutcome.IsDeleted = false;
          ResourceServiceOutcome.RequestUri = RequestUri.FhirRequestUri;
          //Create a BackgroundTask to trigger the work to be performed out of band.
          IBackgroundTaskPayload.TaskId = PostOutcome.ResourceResult.Id;
          IBackgroundTaskPayload.TaskType = BackgroundTaskEnum.BackgroundTaskType.PyroServerIndexing;
          ResourceServiceOutcome.BackgroundTaskList.Add(IBackgroundTaskPayload);

          IServiceFhirTaskQueue.AddFhirTaskQueue(new DtoEntity.DtoFhirTaskQueue()
          {
            TaskFhirId = IBackgroundTaskPayload.TaskId,
            TaskType = IBackgroundTaskPayload.TaskType.GetPyroLiteral(),
            Status = Task.TaskStatus.Ready.GetLiteral()
          });

          return ResourceServiceOutcome;
        }
        else
        {
          string Message = $"Unable to POST a new FHIR Task for a background process to perform indexing.";
          var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Message);
          ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
          ResourceServiceOutcome.ResourceResult = OpOutCome;
          ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Create;
          ResourceServiceOutcome.SuccessfulTransaction = false;
          return ResourceServiceOutcome;
        }
      }
      else
      {
        //There were no un-indexed search parameters be to processed, return operation outcome
        Parameters Param = new Parameters();
        Param.Parameter = new List<Parameters.ParameterComponent>();
        var Component = new Parameters.ParameterComponent();
        Param.Parameter.Add(Component);
        Component.Name = "BackgroundIndexingTask";

        string Message = $"There were no pending Search Parameter indexes to be processed, all indexes are up to date";
        var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Information, OperationOutcome.IssueType.Informational, Message);
        Component.Resource = OpOutCome;
        ResourceServiceOutcome.ResourceResult = Param;
        ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.NotFound;
        ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Create;
        ResourceServiceOutcome.SuccessfulTransaction = true;
        ResourceServiceOutcome.IsDeleted = false;
        ResourceServiceOutcome.RequestUri = RequestUri.FhirRequestUri;
        return ResourceServiceOutcome;
      }
    }


    /// <summary>
    /// Expects a Parameter resource as which have parameters with a name "SearchParameter" and a 
    /// FHIR Reference to a SearchParameter resource in the server
    /// 
    /// This Parameter resource has a list of references to SearchParameter resource that must already be in the 
    /// server. Each will be processed and an index created, yet that index will not be active until it has been
    /// indexed which is done with the method 'ProcessIndex'
    /// </summary>
    /// <param name="RequestUri"></param>
    /// <param name="SearchParameterGeneric"></param>
    /// <param name="Resource"></param>
    /// <param name="FirstTimeStartupBaseParameterOveride"></param>
    /// <returns></returns>
    public IResourceServiceOutcome ProcessSet(
     IPyroRequestUri RequestUri,
     ISearchParameterGeneric SearchParameterGeneric,
     Resource Resource, bool FirstTimeStartupBaseParameterOveride = false)
    {
      if (Resource == null)
        throw new NullReferenceException("Resource cannot be null.");
      if (RequestUri == null)
        throw new NullReferenceException("RequestUri cannot be null.");
      if (SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric cannot be null.");
      if (IResourceServices == null)
        throw new NullReferenceException("ResourceServicescannot be null.");

      IResourceServiceOutcome ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();

      ISearchParameterService SearchServiceRequest = ISearchParameterServiceFactory.CreateSearchParameterService();
      ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchServiceRequest.ProcessBaseSearchParameters(SearchParameterGeneric);
      if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
      {
        ResourceServiceOutcome.ResourceResult = SearchParametersServiceOutcome.FhirOperationOutcome;
        ResourceServiceOutcome.HttpStatusCode = SearchParametersServiceOutcome.HttpStatusCode;
        ResourceServiceOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
        return ResourceServiceOutcome;
      }
      ResourceServiceOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;

      if (Resource != null && Resource is Parameters Parameters)
      {
        if (Parameters.Parameter != null || Parameters.Parameter.Count() != 0)
        {
          Parameters ReturnParametersResource = new Parameters();
          ReturnParametersResource.Parameter = new List<Parameters.ParameterComponent>();

          foreach (var Para in Parameters.Parameter)
          {
            if (Para.Value != null && Para.Value is ResourceReference Ref)
            {
              IPyroFhirUri FhirUri = IPyroFhirUriFactory.CreateFhirRequestUri();
              if (FhirUri.Parse(Ref.Reference))
              {
                if (FhirUri.IsRelativeToServer)
                {
                  if (!FhirUri.IsHistoryReferance)
                  {
                    if (!FhirUri.IsContained)
                    {
                      if (!FhirUri.IsOperation)
                      {
                        if (FhirUri.ResourceType == ResourceType.SearchParameter)
                        {
                          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set($"{ResourceType.SearchParameter.GetLiteral()}/{FhirUri.ResourceId}");
                          IResourceServiceOutcome ResourceServiceOutcomeGetSearchParameterResource = IResourceServices.GetRead(FhirUri.ResourceId, RequestMeta);
                          if (ResourceServiceOutcomeGetSearchParameterResource.HttpStatusCode == System.Net.HttpStatusCode.OK)
                          {
                            TargetSearchParameter = ResourceServiceOutcomeGetSearchParameterResource.ResourceResult as SearchParameter;

                            OperationOutcome OperationOutcomeValidation = ValidateSearchParameterResource(TargetSearchParameter);
                            if (OperationOutcomeValidation == null)
                            {
                              List<DtoServiceSearchParameterHeavy> InboundList = GenerateDbSearchParameterList(TargetSearchParameter);
                              foreach (var InboundItem in InboundList)
                              {
                                _DbSearchParamListForResource = IServiceSearchParameterService.GetServiceSearchParametersHeavyForResource(InboundItem.Resource);
                                if (InboundItem.Resource != ResourceType.Resource.GetLiteral())
                                {
                                  _DbSearchParamListForResource.AddRange(IServiceSearchParameterService.GetServiceSearchParametersHeavyForResource(ResourceType.Resource.GetLiteral()));
                                }
                                if (InboundItem.Type == SearchParamType.Composite)
                                {
                                  EnhanceWithCompositeDetail(InboundItem, TargetSearchParameter);
                                }
                                DtoServiceSearchParameterHeavy CodeAlreadyIndexed = _DbSearchParamListForResource.SingleOrDefault(x => x.Name == TargetSearchParameter.Code);
                                if (CodeAlreadyIndexed != null)
                                {
                                  InboundItem.CreatedDate = CodeAlreadyIndexed.CreatedDate;
                                  InboundItem.CreatedUser = CodeAlreadyIndexed.CreatedUser;

                                  bool AreTargetResourceListEqual = CompaireResourceTargetListsEquality(CodeAlreadyIndexed.TargetResourceTypeList, InboundItem.TargetResourceTypeList);                                  
                                  if (CodeAlreadyIndexed.Expression == InboundItem.Expression &&
                                  CodeAlreadyIndexed.IsIndexed && AreTargetResourceListEqual)
                                  {
                                    //If the Expressions are the same and it is already indexed then just update but no need to re-index
                                    InboundItem.IsIndexed = true;
                                    InboundItem.Id = CodeAlreadyIndexed.Id;
                                    IServiceSearchParameterService.UpdateServiceSearchParametersHeavy(InboundItem);
                                  }
                                  else
                                  {
                                    //The Expression is different or it was not Indexed, either way set IsIndexed to False and update, as it will need re-indexing
                                    InboundItem.IsIndexed = false;
                                    InboundItem.Id = CodeAlreadyIndexed.Id;
                                    IServiceSearchParameterService.UpdateServiceSearchParametersHeavy(InboundItem);
                                  }
                                }
                                else
                                {
                                  if (FirstTimeStartupBaseParameterOveride)
                                  {
                                    //FirstTimeStartupBaseParameterOveride is only when we are loading the SearchParameters for the first time on a clean
                                    //install. In this case IsINdex can be True because no resource have been loaded or can be loaded due to the 
                                    //ServerReadOnlyMode being turned on.
                                    InboundItem.IsIndexed = true;
                                  }
                                  else
                                  {
                                    //This is normal operation where an new SearchParameters added must be indexed.
                                    InboundItem.IsIndexed = false;
                                  }
                                  IServiceSearchParameterService.AddServiceSearchParametersHeavy(InboundItem);
                                }
                              }
                            }
                            else
                            {
                              ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                              ResourceServiceOutcome.ResourceResult = OperationOutcomeValidation;
                              ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
                              ResourceServiceOutcome.SuccessfulTransaction = false;
                              return ResourceServiceOutcome;
                            }
                          }
                          else
                          {
                            var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported, $"No SearchParameter resource found in the server for the ResourceReference: {FhirUri.OriginalString}");
                            ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                            ResourceServiceOutcome.ResourceResult = OpOutCome;
                            ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
                            ResourceServiceOutcome.SuccessfulTransaction = false;
                            return ResourceServiceOutcome;
                          }
                        }
                        else
                        {
                          var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported, $"The Parameters resource's parameter element ResourceReference value must be a reference to a SearchParameter resource, found a reference to a {FhirUri.ResourseName} resource. Value was: {FhirUri.OriginalString}");
                          ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                          ResourceServiceOutcome.ResourceResult = OpOutCome;
                          ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
                          ResourceServiceOutcome.SuccessfulTransaction = false;
                          return ResourceServiceOutcome;
                        }
                      }
                      else
                      {
                        var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported, $"The Parameters resource's parameter element ResourceReference value must not be an $Operation reference, value was: {FhirUri.OriginalString}");
                        ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                        ResourceServiceOutcome.ResourceResult = OpOutCome;
                        ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
                        ResourceServiceOutcome.SuccessfulTransaction = false;
                        return ResourceServiceOutcome;
                      }
                    }
                    else
                    {
                      var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported, $"The Parameters resource's parameter element ResourceReference value must not be a #Contained reference, value was: {FhirUri.OriginalString}");
                      ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                      ResourceServiceOutcome.ResourceResult = OpOutCome;
                      ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
                      ResourceServiceOutcome.SuccessfulTransaction = false;
                      return ResourceServiceOutcome;
                    }
                  }
                  else
                  {
                    var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported, $"The Parameters resource's parameter element ResourceReference value must not be a Version specific reference, value was: {FhirUri.OriginalString}");
                    ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                    ResourceServiceOutcome.ResourceResult = OpOutCome;
                    ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
                    ResourceServiceOutcome.SuccessfulTransaction = false;
                    return ResourceServiceOutcome;
                  }
                }
                else
                {
                  var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported, $"The Parameters resource's parameter element ResourceReference value must be relative to the server, value was: {FhirUri.OriginalString}");
                  ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                  ResourceServiceOutcome.ResourceResult = OpOutCome;
                  ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
                  ResourceServiceOutcome.SuccessfulTransaction = false;
                  return ResourceServiceOutcome;
                }
              }
              else
              {
                var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported, $"The Parameters resource's parameter element ResourceReference value was not able to be parsed, Error message: {FhirUri.ParseErrorMessage}");
                ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                ResourceServiceOutcome.ResourceResult = OpOutCome;
                ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
                ResourceServiceOutcome.SuccessfulTransaction = false;
                return ResourceServiceOutcome;
              }
            }
            else
            {
              var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported, $"The Parameters resource's parameter element either had no value or the value was not a ResourceReference value type.");
              ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
              ResourceServiceOutcome.ResourceResult = OpOutCome;
              ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
              ResourceServiceOutcome.SuccessfulTransaction = false;
              return ResourceServiceOutcome;
            }
          }
          var ReturnParameter = new Parameters.ParameterComponent();
          ReturnParameter.Name = "SearchParameterRegisteredForIndexing";
          ReturnParameter.Resource = TargetSearchParameter;
          ReturnParametersResource.Parameter.Add(ReturnParameter);

          //All good return ParametersResource with the SearchParameter Resource registered.
          ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;
          ResourceServiceOutcome.ResourceResult = ReturnParametersResource;
          ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
          ResourceServiceOutcome.SuccessfulTransaction = true;
          return ResourceServiceOutcome;
        }
        else
        {
          var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported, $"The Parameters resource contains no parameter elements.");
          ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
          ResourceServiceOutcome.ResourceResult = OpOutCome;
          ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
          ResourceServiceOutcome.SuccessfulTransaction = false;
          return ResourceServiceOutcome;
        }
      }
      else
      {
        //The Resource given was not a Parameters resource
        var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported, $"The Resource given on this operation must be a SearchParameter type FHIR resource.");
        ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        ResourceServiceOutcome.ResourceResult = OpOutCome;
        ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
        ResourceServiceOutcome.SuccessfulTransaction = false;
        return ResourceServiceOutcome;
      }
    }

    private bool CompaireResourceTargetListsEquality(List<IServiceSearchParameterTargetResource> ListOne, List<IServiceSearchParameterTargetResource> ListTwo)
    {
      if (ListOne != null && ListTwo != null)
      {
        return ListOne.SequenceEqual(ListTwo);
      }
      else if (ListOne == null && ListTwo == null)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public IResourceServiceOutcome ProcessReport(
      IPyroRequestUri RequestUri,
      ISearchParameterGeneric SearchParameterGeneric,
      Resource Resource)
    {
      throw new NotImplementedException();
    }


    private void EnhanceWithCompositeDetail(DtoServiceSearchParameterHeavy InboundItem, SearchParameter SearchParam)
    {
      if (SearchParam.Component != null && SearchParam.Component.Count > 0)
      {
        int Counter = 0;
        foreach (var Componet in SearchParam.Component)
        {
          var Composite = new DtoServiceSearchParameterComposite();
          Composite.Url = Componet.Definition;
          Composite.Expression = Componet.Expression;
          Composite.SequentialOrder = Counter;
          if (!string.IsNullOrWhiteSpace(Componet.Definition))
          {
            var ChildSearchParameter = _DbSearchParamListForResource.SingleOrDefault(x => x.Url == Componet.Definition);
            if (ChildSearchParameter != null)
            {
              Composite.ChildServiceSearchParameterId = ChildSearchParameter.Id;
            }
            else
            {
              string Message =
                $"Unable to locate one of the SearchParameters referenced in a Composite SearchParametrer type. " +
                $"The Composite SearchParametrer resource id was '{SearchParam.Id}' with a Canonical Url of '{SearchParam.Url}'. " +
                $"Within this SearchParamter resource their is a component/definition/reference to another SearchParamter resource with the Canonical Url of {Componet.Definition}. " +
                $"This SearchParamter resource can not be located by the FHIR Server. " +
                $"In order to load SearchParamters of type Composite you must first ensure " +
                $"all SearchParameter resources that make-up the Composite SearchParameter are loaded first into the FHIR server before the Composite type SearchParamters in loaded.";
              throw new ApplicationException(Message);
            }
          }
          else
          {
            string Message =
              $"A SearchParameter of type Composite that is trying to be loaded where one of its component/definition references to other SearchParametrer resources that make up it's Components does not exist. " +
              $"The SearchParameter has a resource id of '{SearchParam.Id}' with a canonical Url of '{SearchParam.Url}'. " +
              $"A SearchParameter resource of type Composite must reference, at a minimum, one other SearchParameter resource by it's canonical Url and that resource must first be loaded in to the FHIR Server and be referenced in the Composite SearchParameter. ";
            throw new ApplicationException(Message);
          }
          InboundItem.CompositeList.Add(Composite);
          Counter++;
        }
      }
      else
      {
        string Message =
                $"A SearchParameter of type Composite that is trying to be loaded has no component/definition references to other SearchParametrer resources that make up it's Components. " +
                $"The SearchParameter has a resource id of '{SearchParam.Id}' with a canonical Url of '{SearchParam.Url}'. " +
                $"A SearchParameter resource of type Composite must reference, at a minimum, one other SearchParameter resource by it's canonical Url and that resource must first be loaded in to the FHIR Server. ";
        throw new ApplicationException(Message);
      }
    }

    private OperationOutcome ValidateSearchParameterResource(SearchParameter Resource)
    {
      var IssueList = new List<OperationOutcome.IssueComponent>();

      if (string.IsNullOrWhiteSpace(Resource.Code))
      {
        var Issue = new OperationOutcome.IssueComponent();
        Issue.Severity = OperationOutcome.IssueSeverity.Error;
        Issue.Diagnostics = $"The SearchParameter Resource  with the id={Resource.Id} must have a Code element that is not empty.";
        IssueList.Add(Issue);
      }

      if (Resource.Base == null || Resource.Base.Count() == 0)
      {
        var Issue = new OperationOutcome.IssueComponent();
        Issue.Severity = OperationOutcome.IssueSeverity.Error;
        Issue.Diagnostics = $"The SearchParameter Resource  with the id={Resource.Id} must have a least one base element.";
        IssueList.Add(Issue);
      }
      else
      {
        foreach (var Item in Resource.Base)
        {
          if (!Item.HasValue)
          {
            var Issue = new OperationOutcome.IssueComponent();
            Issue.Severity = OperationOutcome.IssueSeverity.Error;
            Issue.Diagnostics = $"The SearchParameter Resource  with the id={Resource.Id} base element was null or perhaps not a known FHIR Resource type.";
            IssueList.Add(Issue);
          }
        }
      }



      if (!Resource.Type.HasValue)
      {
        var Issue = new OperationOutcome.IssueComponent();
        Issue.Severity = OperationOutcome.IssueSeverity.Error;
        Issue.Diagnostics = $"The SearchParameter Resource with the id={Resource.Id} must have a Type element that is not empty.";
        IssueList.Add(Issue);
      }


      if (string.IsNullOrWhiteSpace(Resource.Expression))
      {
        var Issue = new OperationOutcome.IssueComponent();
        Issue.Severity = OperationOutcome.IssueSeverity.Error;
        Issue.Diagnostics = $"The SearchParameter Resource  with the id={Resource.Id} must have an Expression element that is not empty.";
        IssueList.Add(Issue);
      }

      if (!Resource.Status.HasValue)
      {
        var Issue = new OperationOutcome.IssueComponent();
        Issue.Severity = OperationOutcome.IssueSeverity.Error;
        Issue.Diagnostics = $"The SearchParameter Resource  with the id={Resource.Id} must have a Status element that is not empty.";
        IssueList.Add(Issue);
      }

      if (IssueList.Count > 0)
      {
        var OperationOutCome = Common.Tools.FhirOperationOutcomeSupport.Generate(IssueList);
        return OperationOutCome;
      }
      else
      {
        return null;
      }
    }

    private List<DtoServiceSearchParameterHeavy> GenerateDbSearchParameterList(SearchParameter SearchParameterResource)
    {
      var ReturnList = new List<DtoServiceSearchParameterHeavy>();
      foreach (var Base in SearchParameterResource.Base)
      {
        var New = new DtoServiceSearchParameterHeavy();
        if (SearchParameterResource.Description != null)
          New.Description = SearchParameterResource.Description.Value;
        New.Expression = SearchParameterResource.Expression;
        New.Name = SearchParameterResource.Code;
        New.CreatedDate = Pyro.Common.Tools.DateTimeSupport.UTCDateTimeNow();
        New.CreatedUser = Pyro.Common.PyroHealthFhirResource.PyroHealthSystemUser.User;
        New.LastUpdated = Pyro.Common.Tools.DateTimeSupport.UTCDateTimeNow();
        New.LastUpdatedUser = Pyro.Common.PyroHealthFhirResource.PyroHealthSystemUser.User;
        New.Resource = Base.GetLiteral();
        New.SearchParameterResourceId = SearchParameterResource.Id;
        New.SearchParameterResourceVersion = SearchParameterResource.Meta.VersionId;
        New.TargetResourceTypeList = new List<IServiceSearchParameterTargetResource>();
        if (SearchParameterResource.Target != null)
        {
          foreach (var Target in SearchParameterResource.Target)
          {
            if (Target.HasValue)
              New.TargetResourceTypeList.Add(new DtoServiceSearchParameterTargetResource() { ResourceType = Target.Value });
          }
        }
        New.Type = SearchParameterResource.Type.Value;
        New.Url = SearchParameterResource.Url;
        New.XPath = SearchParameterResource.Xpath;
        New.Status = SearchParameterResource.Status.Value;
        New.IsIndexed = false;
        ReturnList.Add(New);
      }
      return ReturnList;
    }



  }
}

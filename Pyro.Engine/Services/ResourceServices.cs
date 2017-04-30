using System;
using System.Collections.Generic;
using System.Linq;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.BusinessEntities.Service;
using Pyro.Common.Enum;
using Pyro.Common.Tools;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;

namespace Pyro.Engine.Services
{
  public abstract class ResourceServices : ResourceServicesBase, IResourceServices
  {
    //Constructor for dependency injection
    public ResourceServices(IUnitOfWork IUnitOfWork)
      : base(IUnitOfWork) { }

    public void BeginTransaction()
    {
      _UnitOfWork.BeginTransaction();
    }

    public void CommitTransaction()
    {
      _UnitOfWork.CommitTransaction();      
    }

    public void RolbackTransaction()
    {
      _UnitOfWork.RollbackTransaction();
    }

    public bool IsTransactional
    {
      get
      {
        return _UnitOfWork.IsTransactional;
      }
    }

    //GET Read   
    // Get: URL/Fhir/Patient/1
    public virtual IResourceServiceOutcome GetRead(IResourceServiceRequestGetRead PyroServiceRequestGetRead)
    {
      IResourceServiceOutcome oServiceOperationOutcome = Common.CommonFactory.GetServiceOperationOutcome();
      oServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;

      // GET by FhirId
      // GET URL/FhirApi/Patient/5    
      ISearchParametersServiceRequest SearchParametersServiceRequest = Common.CommonFactory.GetSearchParametersServiceRequest();
      SearchParametersServiceRequest.SearchParameterGeneric = PyroServiceRequestGetRead.SearchParameterGeneric;
      SearchParametersServiceRequest.SearchParameterServiceType = SearchParameterService.SearchParameterServiceType.Base;
      SearchParametersServiceRequest.ResourceType = null;
      ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchParameterService.ProcessSearchParameters(SearchParametersServiceRequest);
      if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
      {
        oServiceOperationOutcome.SearchParametersServiceOutcome = SearchParametersServiceOutcome;
        return oServiceOperationOutcome;
      }
      SearchParametersServiceOutcome.SearchParameters.PrimaryRootUrlStore = PyroServiceRequestGetRead.FhirRequestUri.PrimaryRootUrlStore;
      oServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;

      GetResourceInstance(
        PyroServiceRequestGetRead.ResourceId,
        PyroServiceRequestGetRead.FhirRequestUri,
        oServiceOperationOutcome,
        PyroServiceRequestGetRead.RequestHeaders);

      oServiceOperationOutcome.SuccessfulTransaction = true;
      return oServiceOperationOutcome;
    }
    
    // GET by Search
    // GET: URL//FhirApi/Patient?family=Smith&given=John            
    public virtual IResourceServiceOutcome GetSearch(IResourceServiceRequestGetSearch PyroServiceRequestGetSearch)
    {
      IResourceServiceOutcome oServiceOperationOutcome = Common.CommonFactory.GetServiceOperationOutcome();
      oServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;

      // GET by Search
      // GET: URL//FhirApi/Patient?family=Smith&given=John           
      ISearchParametersServiceRequest SearchParametersServiceRequest = Common.CommonFactory.GetSearchParametersServiceRequest();      
      SearchParametersServiceRequest.SearchParameterGeneric = PyroServiceRequestGetSearch.SearchParameterGeneric;
      SearchParametersServiceRequest.SearchParameterServiceType = SearchParameterService.SearchParameterServiceType.Base | SearchParameterService.SearchParameterServiceType.Bundle | SearchParameterService.SearchParameterServiceType.Resource;
      SearchParametersServiceRequest.ResourceType = _CurrentResourceType;      
      SearchParametersServiceRequest.CommonServices = this as ICommonServices;
      ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchParameterService.ProcessSearchParameters(SearchParametersServiceRequest);

      if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
      {
        oServiceOperationOutcome.SearchParametersServiceOutcome = SearchParametersServiceOutcome;
        return oServiceOperationOutcome;
      }
      SearchParametersServiceOutcome.SearchParameters.PrimaryRootUrlStore = PyroServiceRequestGetSearch.FhirRequestUri.PrimaryRootUrlStore;

      GetResourcesBySearch(
        PyroServiceRequestGetSearch.FhirRequestUri,
        SearchParametersServiceOutcome,
        oServiceOperationOutcome);

      oServiceOperationOutcome.SuccessfulTransaction = true;
      return oServiceOperationOutcome;
    }

    // GET All history for Id
    // GET URL/FhirApi/Patient/5/_history
    //Read all history
    public virtual IResourceServiceOutcome GetHistory(IResourceServiceRequestGetHistory PyroServiceRequestGetHistory)
    {
      IResourceServiceOutcome oServiceOperationOutcome = Common.CommonFactory.GetServiceOperationOutcome();
      oServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;

      if (string.IsNullOrWhiteSpace(PyroServiceRequestGetHistory.VersionId))
      {
        // GET All history for Id
        // GET URL/FhirApi/Patient/5/_history
        //Read all history
        ISearchParametersServiceRequest SearchParametersServiceRequest = Common.CommonFactory.GetSearchParametersServiceRequest();
        SearchParametersServiceRequest.SearchParameterGeneric = PyroServiceRequestGetHistory.SearchParameterGeneric;
        SearchParametersServiceRequest.SearchParameterServiceType = SearchParameterService.SearchParameterServiceType.Base | SearchParameterService.SearchParameterServiceType.Bundle;
        SearchParametersServiceRequest.ResourceType = null;
        ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchParameterService.ProcessSearchParameters(SearchParametersServiceRequest);

        oServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
        SearchParametersServiceOutcome.SearchParameters.PrimaryRootUrlStore = PyroServiceRequestGetHistory.FhirRequestUri.PrimaryRootUrlStore;

        if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
        {
          oServiceOperationOutcome.SearchParametersServiceOutcome = SearchParametersServiceOutcome;
          return oServiceOperationOutcome;
        }

        GetResourceHistoryInFull(PyroServiceRequestGetHistory.ResourceId,
          PyroServiceRequestGetHistory.FhirRequestUri,
          SearchParametersServiceOutcome,
          oServiceOperationOutcome);

        oServiceOperationOutcome.SuccessfulTransaction = true;
        return oServiceOperationOutcome;
      }
      else
      {
        // GET by FhirId and FhirVId
        // GET URL/FhirApi/Patient/5/_history/2   
        ISearchParametersServiceRequest SearchParametersServiceRequest = Common.CommonFactory.GetSearchParametersServiceRequest();
        SearchParametersServiceRequest.SearchParameterGeneric = PyroServiceRequestGetHistory.SearchParameterGeneric;
        SearchParametersServiceRequest.SearchParameterServiceType = SearchParameterService.SearchParameterServiceType.Base;
        SearchParametersServiceRequest.ResourceType = null;
        ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchParameterService.ProcessSearchParameters(SearchParametersServiceRequest);
        if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
        {
          oServiceOperationOutcome.SearchParametersServiceOutcome = SearchParametersServiceOutcome;
          return oServiceOperationOutcome;
        }

        GetResourceHistoryInstance(
          PyroServiceRequestGetHistory.ResourceId,
          PyroServiceRequestGetHistory.VersionId,
          PyroServiceRequestGetHistory.FhirRequestUri,
          oServiceOperationOutcome);

        oServiceOperationOutcome.SuccessfulTransaction = true;
        return oServiceOperationOutcome;
      }       
    }
    
    // Add (POST)
    // POST: URL/FhirApi/Patient
    public virtual IResourceServiceOutcome Post(IResourceServiceRequestPost PyroServiceRequestPost)
    {
      IResourceServiceOutcome oServiceOperationOutcome = Common.CommonFactory.GetServiceOperationOutcome();

      ISearchParametersServiceRequest SearchParametersServiceRequest = Common.CommonFactory.GetSearchParametersServiceRequest();      
      SearchParametersServiceRequest.SearchParameterGeneric = PyroServiceRequestPost.SearchParameterGeneric;
      SearchParametersServiceRequest.SearchParameterServiceType = SearchParameterService.SearchParameterServiceType.Base;
      SearchParametersServiceRequest.ResourceType = null;
      //var Test = Common.Cache.StaticCacheCommon.GetSearchParameterForResource(this as ICommonServices, PyroServiceRequestPost.Resource.ResourceType.ToString());
      ISearchParametersServiceOutcome SearchParametersServiceOutcomeBase = SearchParameterService.ProcessSearchParameters(SearchParametersServiceRequest);
      if (SearchParametersServiceOutcomeBase.FhirOperationOutcome != null)
      {
        oServiceOperationOutcome.SearchParametersServiceOutcome = SearchParametersServiceOutcomeBase;        
        return oServiceOperationOutcome;
      }
      SearchParametersServiceOutcomeBase.SearchParameters.PrimaryRootUrlStore = PyroServiceRequestPost.FhirRequestUri.PrimaryRootUrlStore;

      if ((PyroServiceRequestPost.RequestHeaders != null) && (!string.IsNullOrWhiteSpace(PyroServiceRequestPost.RequestHeaders.IfNoneExist)))
      {
        IDtoSearchParameterGeneric SearchParameterGenericIfNoneExist = Common.CommonFactory.GetDtoSearchParameterGeneric(PyroServiceRequestPost.RequestHeaders.IfNoneExist);
        ISearchParametersServiceRequest SearchParametersServiceRequestIfNoneExist = Common.CommonFactory.GetSearchParametersServiceRequest();
        SearchParametersServiceRequestIfNoneExist.SearchParameterGeneric = SearchParameterGenericIfNoneExist;
        SearchParametersServiceRequestIfNoneExist.SearchParameterServiceType = SearchParameterService.SearchParameterServiceType.Bundle | SearchParameterService.SearchParameterServiceType.Resource;
        SearchParametersServiceRequestIfNoneExist.ResourceType = _CurrentResourceType;
        SearchParametersServiceRequestIfNoneExist.CommonServices = this as ICommonServices;
        ISearchParametersServiceOutcome SearchParametersServiceOutcomeIfNoneExist = SearchParameterService.ProcessSearchParameters(SearchParametersServiceRequestIfNoneExist);
        if (SearchParametersServiceOutcomeIfNoneExist.FhirOperationOutcome != null)
        {
          oServiceOperationOutcome.SearchParametersServiceOutcome = SearchParametersServiceOutcomeIfNoneExist;
          return oServiceOperationOutcome;
        }
        SearchParametersServiceOutcomeIfNoneExist.SearchParameters.PrimaryRootUrlStore = PyroServiceRequestPost.FhirRequestUri.PrimaryRootUrlStore;

        IDatabaseOperationOutcome DatabaseOperationOutcomeIfNoneExist = _ResourceRepository.GetResourceBySearch(SearchParametersServiceOutcomeIfNoneExist.SearchParameters, false);
        if (DatabaseOperationOutcomeIfNoneExist.SearchTotal == 1)
        {
          //From FHIR Specification: One Match: The server ignore the post and returns 200 OK          
          oServiceOperationOutcome.ResourceResult = null;
          oServiceOperationOutcome.FhirResourceId = DatabaseOperationOutcomeIfNoneExist.ReturnedResourceList[0].FhirId;
          oServiceOperationOutcome.LastModified = DatabaseOperationOutcomeIfNoneExist.ReturnedResourceList[0].Received;
          oServiceOperationOutcome.IsDeleted = DatabaseOperationOutcomeIfNoneExist.ReturnedResourceList[0].IsDeleted;
          oServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Create;
          oServiceOperationOutcome.ResourceVersionNumber = DatabaseOperationOutcomeIfNoneExist.ReturnedResourceList[0].Version;
          oServiceOperationOutcome.RequestUri = PyroServiceRequestPost.FhirRequestUri.FhirUri.Uri;
          oServiceOperationOutcome.ServiceRootUri = PyroServiceRequestPost.FhirRequestUri.FhirUri.ServiceRootUrl;
          oServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcomeBase.SearchParameters.Format;
          oServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;
          oServiceOperationOutcome.SuccessfulTransaction = true;
          return oServiceOperationOutcome;
        }
        else if (DatabaseOperationOutcomeIfNoneExist.SearchTotal > 1)
        {
          //From FHIR Specification: Multiple matches: The server returns a 412 Precondition Failed error 
          //                         indicating the client's criteria were not selective enough
          oServiceOperationOutcome.ResourceResult = null;
          oServiceOperationOutcome.FhirResourceId = string.Empty;
          oServiceOperationOutcome.LastModified = null;
          oServiceOperationOutcome.IsDeleted = null;
          oServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Create;
          oServiceOperationOutcome.ResourceVersionNumber = string.Empty;
          oServiceOperationOutcome.RequestUri = PyroServiceRequestPost.FhirRequestUri.FhirUri.Uri;
          oServiceOperationOutcome.ServiceRootUri = PyroServiceRequestPost.FhirRequestUri.FhirUri.ServiceRootUrl;
          oServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcomeBase.SearchParameters.Format;
          oServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.PreconditionFailed;
          return oServiceOperationOutcome;
        }
      }

      if (!string.IsNullOrWhiteSpace(PyroServiceRequestPost.Resource.Id))
      {
        string Message = string.Format("The create (POST) interaction creates a new resource in a server-assigned location. If the client wishes to have control over the id of a newly submitted resource, it should use the update interaction instead. The Resource provide was found to contain the id: {0}", PyroServiceRequestPost.Resource.Id);
        oServiceOperationOutcome.ResourceValidationOperationOutcome = new Pyro.Engine.Validation.ResourceValidationOperationOutcome();
        oServiceOperationOutcome.ResourceValidationOperationOutcome.FhirOperationOutcome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Required, Message, new List<string>() {"Resource.Id"});
        oServiceOperationOutcome.ResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        return oServiceOperationOutcome;
      }
      //BatchTransaction Operation need to pre assign the id GUID inorder to update referances in the batch
      //That id is then passed into 'ForceId' and is then used for the POST (add), must always be a GUID
      if (!string.IsNullOrWhiteSpace(PyroServiceRequestPost.ForceId))
      {        
        PyroServiceRequestPost.Resource.Id = PyroServiceRequestPost.ForceId;
      }
      //All good commit the resource.
      oServiceOperationOutcome = SetResource(PyroServiceRequestPost.Resource, PyroServiceRequestPost.FhirRequestUri, RestEnum.CrudOperationType.Create);
      oServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcomeBase.SearchParameters.Format;
      oServiceOperationOutcome.SuccessfulTransaction = true;
      return oServiceOperationOutcome;
    }

    //Update (PUT)
    // PUT: URL/FhirApi/Patient/5
    public virtual IResourceServiceOutcome Put(IResourceServiceRequestPut PyroServiceRequestPut)
    {
      IResourceServiceOutcome oServiceOperationOutcome = Common.CommonFactory.GetServiceOperationOutcome();

      ISearchParametersServiceRequest SearchParametersServiceRequest = Common.CommonFactory.GetSearchParametersServiceRequest();
      SearchParametersServiceRequest.SearchParameterGeneric = PyroServiceRequestPut.SearchParameterGeneric;
      SearchParametersServiceRequest.SearchParameterServiceType = SearchParameterService.SearchParameterServiceType.Base;
      SearchParametersServiceRequest.ResourceType = null;
      ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchParameterService.ProcessSearchParameters(SearchParametersServiceRequest);
      if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
      {
        oServiceOperationOutcome.SearchParametersServiceOutcome = SearchParametersServiceOutcome;
        return oServiceOperationOutcome;
      }
      SearchParametersServiceOutcome.SearchParameters.PrimaryRootUrlStore = PyroServiceRequestPut.FhirRequestUri.PrimaryRootUrlStore;

      if (string.IsNullOrWhiteSpace(PyroServiceRequestPut.Resource.Id) || PyroServiceRequestPut.Resource.Id != PyroServiceRequestPut.ResourceId)
      {
        string Message = String.Format("The Resource SHALL contain an id element that has an identical value to the [id] in the URL. The id in the resource was: '{0}' and the [id] in the URL was: '{1}'", PyroServiceRequestPut.Resource.Id, PyroServiceRequestPut.ResourceId);
        oServiceOperationOutcome.ResourceResult = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Required, Message);
        oServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        return oServiceOperationOutcome;
      }

      Interfaces.IResourceValidation Validation = Pyro.Engine.Validation.ResourceValidationFactory.GetValidationInstance(CurrentResourceType);
      IResourceValidationOperationOutcome oResourceValidationOperationOutcome = Validation.Validate(PyroServiceRequestPut.Resource);
      if (oResourceValidationOperationOutcome.HasError)
      {
        oServiceOperationOutcome.ResourceValidationOperationOutcome = oResourceValidationOperationOutcome;
        return oServiceOperationOutcome;
      }
      
      //Create Resource's Meta element if not found and update its last updated property to now
      if (PyroServiceRequestPut.Resource.Meta == null)
        PyroServiceRequestPut.Resource.Meta = new Meta();

      //Check db for existence of this Resource 
      IDatabaseOperationOutcome DatabaseOperationOutcomeGet = _ResourceRepository.GetResourceByFhirID(PyroServiceRequestPut.ResourceId);
      
      if (DatabaseOperationOutcomeGet.ReturnedResourceList != null && DatabaseOperationOutcomeGet.ReturnedResourceList.Count == 1)
      {
        if (!string.IsNullOrWhiteSpace(PyroServiceRequestPut.RequestHeaders.IfMatch) &&
          (PyroServiceRequestPut.RequestHeaders.IfMatch != DatabaseOperationOutcomeGet.ReturnedResourceList[0].Version))
        {
          string Message = $"Version aware update conflict error. HTTP Header 'If-Match' used. The version intended to be updated was: '{PyroServiceRequestPut.RequestHeaders.IfMatch}' the current version found on the server was: '{DatabaseOperationOutcomeGet.ReturnedResourceList[0].Version}'.";
          oServiceOperationOutcome.ResourceResult = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Conflict, Message);
          oServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Update;
          oServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.Conflict;
          return oServiceOperationOutcome;
        }
        else
        {
          //The resource has been found so update its version number based on the older resource              
          PyroServiceRequestPut.Resource.Meta.VersionId = Common.Tools.ResourceVersionNumber.Increment(DatabaseOperationOutcomeGet.ReturnedResourceList[0].Version);
          oServiceOperationOutcome = SetResource(PyroServiceRequestPut.Resource, PyroServiceRequestPut.FhirRequestUri, RestEnum.CrudOperationType.Update);
          oServiceOperationOutcome.SuccessfulTransaction = true;
        }
      }
      else if (DatabaseOperationOutcomeGet.ReturnedResourceList != null && DatabaseOperationOutcomeGet.ReturnedResourceList.Count == 0)
      {
        if (!string.IsNullOrWhiteSpace(PyroServiceRequestPut.RequestHeaders.IfMatch))          
        {
          string Message = $"Version aware update conflict. HTTP Header 'If-Match: {PyroServiceRequestPut.RequestHeaders.IfMatch}' used, and no previous resource can be found in the server.";
          oServiceOperationOutcome.ResourceResult = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Conflict, Message);
          oServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.Conflict;
          return oServiceOperationOutcome;
        }
        else
        {
          //This is a new resource so update its version number as 1 and create
          PyroServiceRequestPut.Resource.Meta.VersionId = Common.Tools.ResourceVersionNumber.FirstVersion();
          oServiceOperationOutcome = SetResource(PyroServiceRequestPut.Resource, PyroServiceRequestPut.FhirRequestUri, RestEnum.CrudOperationType.Create);
          oServiceOperationOutcome.SuccessfulTransaction = true;
        }
      }

      oServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
      return oServiceOperationOutcome;
    }

    //Delete
    // DELETE: URL/FhirApi/Patient/5
    public virtual IResourceServiceOutcome Delete(IResourceServiceRequestDelete PyroServiceRequestDelete)
    {
      IResourceServiceOutcome oServiceOperationOutcome = Common.CommonFactory.GetServiceOperationOutcome();

      ISearchParametersServiceRequest SearchParametersServiceRequest = Common.CommonFactory.GetSearchParametersServiceRequest();
      SearchParametersServiceRequest.SearchParameterGeneric = PyroServiceRequestDelete.SearchParameterGeneric;
      SearchParametersServiceRequest.SearchParameterServiceType = SearchParameterService.SearchParameterServiceType.Base;
      SearchParametersServiceRequest.ResourceType = null;
      ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchParameterService.ProcessSearchParameters(SearchParametersServiceRequest);
      if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
      {
        oServiceOperationOutcome.SearchParametersServiceOutcome = SearchParametersServiceOutcome;
        return oServiceOperationOutcome;
      }
      SearchParametersServiceOutcome.SearchParameters.PrimaryRootUrlStore = PyroServiceRequestDelete.FhirRequestUri.PrimaryRootUrlStore;

      IDatabaseOperationOutcome DatabaseOperationOutcomeGet = _ResourceRepository.GetResourceByFhirID(PyroServiceRequestDelete.ResourceId, false);
      if (DatabaseOperationOutcomeGet.ReturnedResourceList.Count == 1 &&
        DatabaseOperationOutcomeGet.ReturnedResourceList[0].IsDeleted)
      {
        // The resource exists yet is already deleted, 
        //need to return the details about it but not the xml content 
        oServiceOperationOutcome.ResourceResult = null;
        oServiceOperationOutcome.FhirResourceId = PyroServiceRequestDelete.ResourceId;
        oServiceOperationOutcome.LastModified = DatabaseOperationOutcomeGet.ReturnedResourceList[0].Received;
        oServiceOperationOutcome.IsDeleted = DatabaseOperationOutcomeGet.ReturnedResourceList[0].IsDeleted;
        oServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Delete;
        oServiceOperationOutcome.ResourceVersionNumber = DatabaseOperationOutcomeGet.ReturnedResourceList[0].Version;
        oServiceOperationOutcome.RequestUri = null;
        oServiceOperationOutcome.ServiceRootUri = null;
        oServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.NoContent;
      }
      else
      {
        //There is one that is not already deleted or there is none
        //Either case calling the CommitResourceCollectionAsDeleted will return the correct result. 
        ICollection<string> ResourceIdsToBeDeleted = DatabaseOperationOutcomeGet.ReturnedResourceList.Where(x => x.IsDeleted == false).Select(x => x.FhirId).ToArray();
        oServiceOperationOutcome = SetResourceCollectionAsDeleted(ResourceIdsToBeDeleted);
      }

      oServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
      oServiceOperationOutcome.SuccessfulTransaction = true;
      return oServiceOperationOutcome;
    }

    //ConditionalUpdate (PUT)
    //DELETE: URL/FhirApi/Patient?identifier=12345&family=millar&given=angus 
    public virtual IResourceServiceOutcome ConditionalPut(IResourceServiceRequestConditionalPut PyroServiceRequestConditionalPut)
    {
      IResourceServiceOutcome ServiceOperationOutcomeConditionalPut = Common.CommonFactory.GetServiceOperationOutcome();
      // GET: URL//FhirApi/Patient?family=Smith&given=John                        

      ISearchParametersServiceRequest SearchParametersServiceRequest = Common.CommonFactory.GetSearchParametersServiceRequest();
      SearchParametersServiceRequest.SearchParameterGeneric = PyroServiceRequestConditionalPut.SearchParameterGeneric;
      SearchParametersServiceRequest.SearchParameterServiceType = SearchParameterService.SearchParameterServiceType.Base | SearchParameterService.SearchParameterServiceType.Resource;
      SearchParametersServiceRequest.ResourceType = _CurrentResourceType;
      SearchParametersServiceRequest.CommonServices = this as ICommonServices;
      ISearchParametersServiceOutcome SearchParametersServiceOutcomeAll = SearchParameterService.ProcessSearchParameters(SearchParametersServiceRequest);      
      if (SearchParametersServiceOutcomeAll.FhirOperationOutcome != null)
      {
        ServiceOperationOutcomeConditionalPut.SearchParametersServiceOutcome = SearchParametersServiceOutcomeAll;
        return ServiceOperationOutcomeConditionalPut;
      }
      ServiceOperationOutcomeConditionalPut.FormatMimeType = SearchParametersServiceOutcomeAll.SearchParameters.Format;

      SearchParametersServiceOutcomeAll.SearchParameters.PrimaryRootUrlStore = PyroServiceRequestConditionalPut.FhirRequestUri.PrimaryRootUrlStore;

      IDatabaseOperationOutcome DatabaseOperationOutcomeSearch = _ResourceRepository.GetResourceBySearch(SearchParametersServiceOutcomeAll.SearchParameters, false);
      if (DatabaseOperationOutcomeSearch.ReturnedResourceList.Count == 0)
      {
        //No resource found so do a normal Create, first clear any Resource Id that may 
        //be in the resource
        PyroServiceRequestConditionalPut.Resource.Id = string.Empty;
        IResourceServiceRequestPost ServiceRequestSingleCreate = Common.CommonFactory.GetResourceServiceRequestPost(PyroServiceRequestConditionalPut.Resource, PyroServiceRequestConditionalPut.FhirRequestUri, PyroServiceRequestConditionalPut.SearchParameterGeneric);
        ServiceOperationOutcomeConditionalPut = this.Post(ServiceRequestSingleCreate);
        ServiceOperationOutcomeConditionalPut.FormatMimeType = SearchParametersServiceOutcomeAll.SearchParameters.Format;
        //Don't set to true below as the POST above will set the bool based on it's own result
        //oServiceOperationOutcome.SuccessfulTransaction = true;
        return ServiceOperationOutcomeConditionalPut;
      }
      else if (DatabaseOperationOutcomeSearch.ReturnedResourceList.Count == 1)
      {
        if (!string.IsNullOrWhiteSpace(PyroServiceRequestConditionalPut.Resource.Id))
        {
          if (DatabaseOperationOutcomeSearch.ReturnedResourceList[0].FhirId != PyroServiceRequestConditionalPut.Resource.Id)
          {
            string Message = "The single Resource located by the search has a different Resource Id to that which was found in the Resource given. Either, remove the Id from the Resource given or re-evaluate the search parameters.";
            SearchParametersServiceOutcomeAll.FhirOperationOutcome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.BusinessRule, Message);
            ServiceOperationOutcomeConditionalPut.SearchParametersServiceOutcome = SearchParametersServiceOutcomeAll;
            return ServiceOperationOutcomeConditionalPut;
          }
        }
        else
        {
          PyroServiceRequestConditionalPut.Resource.Id = DatabaseOperationOutcomeSearch.ReturnedResourceList[0].FhirId;
        }

        //Create Resource's Meta element if not found and update its last updated property to now
        if (PyroServiceRequestConditionalPut.Resource.Meta == null)
          PyroServiceRequestConditionalPut.Resource.Meta = new Meta();

        //A database resource has been found so update the new resource's version number based on the older resource              
        PyroServiceRequestConditionalPut.Resource.Meta.VersionId = Common.Tools.ResourceVersionNumber.Increment(DatabaseOperationOutcomeSearch.ReturnedResourceList[0].Version);
        ServiceOperationOutcomeConditionalPut = SetResource(PyroServiceRequestConditionalPut.Resource, PyroServiceRequestConditionalPut.FhirRequestUri, RestEnum.CrudOperationType.Update);
        ServiceOperationOutcomeConditionalPut.SuccessfulTransaction = true;
        ServiceOperationOutcomeConditionalPut.FormatMimeType = SearchParametersServiceOutcomeAll.SearchParameters.Format;
        return ServiceOperationOutcomeConditionalPut;
      }
      else 
      {
        //more than one returned so PreconditionFailed.        
        ServiceOperationOutcomeConditionalPut.ResourceResult = null;
        ServiceOperationOutcomeConditionalPut.FhirResourceId = null;
        ServiceOperationOutcomeConditionalPut.LastModified = null;
        ServiceOperationOutcomeConditionalPut.IsDeleted = true;
        ServiceOperationOutcomeConditionalPut.OperationType = RestEnum.CrudOperationType.Update;
        ServiceOperationOutcomeConditionalPut.ResourceVersionNumber = null;
        ServiceOperationOutcomeConditionalPut.RequestUri = null;
        ServiceOperationOutcomeConditionalPut.ServiceRootUri = null;
        ServiceOperationOutcomeConditionalPut.FormatMimeType = SearchParametersServiceOutcomeAll.SearchParameters.Format;
        ServiceOperationOutcomeConditionalPut.HttpStatusCode = System.Net.HttpStatusCode.PreconditionFailed;        
        return ServiceOperationOutcomeConditionalPut;
      }      
    }

    //ConditionalDelete (Delete)
    //DELETE: URL/FhirApi/Patient?identifier=12345&family=millar&given=angus 
    public virtual IResourceServiceOutcome ConditionalDelete(IResourceServiceRequestConditionalDelete PyroServiceRequestConditionalDelete)
    {
      IResourceServiceOutcome ServiceOperationOutcomeConditionalDelete = Common.CommonFactory.GetServiceOperationOutcome();
      // GET: URL//FhirApi/Patient?family=Smith&given=John          
      ISearchParametersServiceRequest SearchParametersServiceRequestBaseOnly = Common.CommonFactory.GetSearchParametersServiceRequest();
      SearchParametersServiceRequestBaseOnly.SearchParameterGeneric = PyroServiceRequestConditionalDelete.SearchParameterGeneric;
      SearchParametersServiceRequestBaseOnly.SearchParameterServiceType = SearchParameterService.SearchParameterServiceType.Base;
      SearchParametersServiceRequestBaseOnly.ResourceType = _CurrentResourceType;
      ISearchParametersServiceOutcome SearchParametersServiceOutcomeBaseOnly = SearchParameterService.ProcessSearchParameters(SearchParametersServiceRequestBaseOnly);

      ISearchParametersServiceRequest SearchParametersServiceRequestAll = Common.CommonFactory.GetSearchParametersServiceRequest();
      SearchParametersServiceRequestAll.SearchParameterGeneric = PyroServiceRequestConditionalDelete.SearchParameterGeneric;
      SearchParametersServiceRequestAll.SearchParameterServiceType = SearchParameterService.SearchParameterServiceType.Base | SearchParameterService.SearchParameterServiceType.Resource;
      SearchParametersServiceRequestAll.ResourceType = _CurrentResourceType;
      SearchParametersServiceRequestAll.CommonServices = this as ICommonServices;
      ISearchParametersServiceOutcome SearchParametersServiceOutcomeAll = SearchParameterService.ProcessSearchParameters(SearchParametersServiceRequestAll);

      if (SearchParametersServiceOutcomeAll.FhirOperationOutcome != null)
      {
        ServiceOperationOutcomeConditionalDelete.SearchParametersServiceOutcome = SearchParametersServiceOutcomeAll;
        return ServiceOperationOutcomeConditionalDelete;
      }

      if ((SearchParametersServiceOutcomeAll.SearchParameters.SearchParametersList.Count - SearchParametersServiceOutcomeBaseOnly.SearchParameters.SearchParametersList.Count) <= 0 ||
        SearchParametersServiceOutcomeAll.SearchParameters.UnspportedSearchParameterList.Count != 0)
      {
        string Message = string.Empty;
        if ((SearchParametersServiceOutcomeAll.SearchParameters.SearchParametersList.Count - SearchParametersServiceOutcomeBaseOnly.SearchParameters.SearchParametersList.Count) <= 0)
        {
          Message = String.Format($"The Conditional Delete operation requires at least one valid Resource search parameter in order to be performed.");
        }
        else if (SearchParametersServiceOutcomeAll.SearchParameters.UnspportedSearchParameterList.Count != 0)
        {
          string UnspportedSearchParameterMessage = string.Empty;
          foreach (var item in SearchParametersServiceOutcomeAll.SearchParameters.UnspportedSearchParameterList)
          {
            UnspportedSearchParameterMessage = UnspportedSearchParameterMessage + $"Parameter: {item.RawParameter}, Reason: {item.ReasonMessage};";
          }
          Message = String.Format($"The Conditional Delete operation requires that all Search parameters are understood. The following supplied  parameters were not understood: {UnspportedSearchParameterMessage}");
        }
        SearchParametersServiceOutcomeAll.FhirOperationOutcome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.BusinessRule, Message);
        SearchParametersServiceOutcomeAll.HttpStatusCode = System.Net.HttpStatusCode.PreconditionFailed;
        ServiceOperationOutcomeConditionalDelete.SearchParametersServiceOutcome = SearchParametersServiceOutcomeAll;
        return ServiceOperationOutcomeConditionalDelete;
      }

      SearchParametersServiceOutcomeAll.SearchParameters.PrimaryRootUrlStore = PyroServiceRequestConditionalDelete.FhirRequestUri.PrimaryRootUrlStore;

      IDatabaseOperationOutcome DatabaseOperationOutcomeSearch = _ResourceRepository.GetResourceBySearch(SearchParametersServiceOutcomeAll.SearchParameters, false);

      //There are zero or many or one to be deleted, note that GetResourceBySearch never returns deleted resource.
      ICollection<string> ResourceIdsToBeDeleted = DatabaseOperationOutcomeSearch.ReturnedResourceList.Select(x => x.FhirId).ToArray();
      ServiceOperationOutcomeConditionalDelete = SetResourceCollectionAsDeleted(ResourceIdsToBeDeleted);
      ServiceOperationOutcomeConditionalDelete.FormatMimeType = SearchParametersServiceOutcomeAll.SearchParameters.Format;
      ServiceOperationOutcomeConditionalDelete.SuccessfulTransaction = true;
      return ServiceOperationOutcomeConditionalDelete;
    }
  }
}

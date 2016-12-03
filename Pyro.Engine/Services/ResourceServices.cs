using System;
using System.Collections.Generic;
using System.Linq;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.BusinessEntities.Service;
using Pyro.Common.Enum;
using Pyro.Common.Tools;
using Hl7.Fhir.Model;

namespace Pyro.Engine.Services
{
  public abstract class ResourceServices : CommonServices, IBaseResourceServices, ICommonServices, IBaseServices
  {
    protected IResourceRepository _ResourceRepository = null;

    //Constructor for dependency injection
    public ResourceServices(IUnitOfWork IUnitOfWork)
      : base(IUnitOfWork) { }

    protected FHIRAllTypes _CurrentResourceType;

    public FHIRAllTypes CurrentResourceType
    {
      get
      {
        return _CurrentResourceType;
      }
    }

    public FHIRAllTypes SetCurrentResourceType
    {
      set
      {
        _CurrentResourceType = value;
      }
    }

    //GET    
    // Get: URL/Fhir/Patient/1
    public virtual IResourceServiceOutcome Get(IResourceServiceRequest PyroServiceRequest)
    {
      IResourceServiceOutcome oPyroServiceOperationOutcome = Common.CommonFactory.GetPyroServiceOperationOutcome();
      oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;

      switch (PyroServiceRequest.ServiceRequestType)
      {
        case ServiceEnums.ServiceRequestType.History:
          {
            if (string.IsNullOrWhiteSpace(PyroServiceRequest.VersionId))
            {
              // GET All history for Id
              // GET URL/FhirApi/Patient/5/_history
              //Read all history
              ISearchParametersServiceOutcome SearchParametersServiceOutcome
                 = SearchParameterService.ProcessSearchParameters(PyroServiceRequest.SearchParameterGeneric,
                                                                  SearchParameterService.SearchParameterServiceType.Base |
                                                                  SearchParameterService.SearchParameterServiceType.Bundle);

              if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
              {
                oPyroServiceOperationOutcome.SearchParametersServiceOutcome = SearchParametersServiceOutcome;
                return oPyroServiceOperationOutcome;
              }
              SearchParametersServiceOutcome.SearchParameters.PrimaryRootUrlStore = PyroServiceRequest.FhirRequestUri.PrimaryRootUrlStore;

              IDatabaseOperationOutcome DatabaseOperationOutcome = _ResourceRepository.GetResourceHistoryByFhirID(PyroServiceRequest.ResourceId, SearchParametersServiceOutcome.SearchParameters);

              oPyroServiceOperationOutcome.ResourceResult = Support.FhirBundleSupport.CreateBundle(DatabaseOperationOutcome.ReturnedResourceList,
                                                                                                   Bundle.BundleType.History,
                                                                                                   PyroServiceRequest.FhirRequestUri,
                                                                                                   DatabaseOperationOutcome.SearchTotal,
                                                                                                   DatabaseOperationOutcome.PagesTotal,
                                                                                                   DatabaseOperationOutcome.PageRequested);
              oPyroServiceOperationOutcome.FhirResourceId = string.Empty;
              oPyroServiceOperationOutcome.LastModified = null;
              oPyroServiceOperationOutcome.IsDeleted = null;
              oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;
              oPyroServiceOperationOutcome.ResourceVersionNumber = string.Empty;
              oPyroServiceOperationOutcome.RequestUri = PyroServiceRequest.FhirRequestUri.FhirUri.Uri;
              oPyroServiceOperationOutcome.ServiceRootUri = PyroServiceRequest.FhirRequestUri.FhirUri.ServiceRootUrl;
              oPyroServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
              oPyroServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;

              return oPyroServiceOperationOutcome;
            }
            else
            {
              // GET by FhirId and FhirVId
              // GET URL/FhirApi/Patient/5/_history/2    
              ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchParameterService.ProcessSearchParameters(PyroServiceRequest.SearchParameterGeneric, SearchParameterService.SearchParameterServiceType.Base);
              if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
              {
                oPyroServiceOperationOutcome.SearchParametersServiceOutcome = SearchParametersServiceOutcome;
                return oPyroServiceOperationOutcome;
              }
              SearchParametersServiceOutcome.SearchParameters.PrimaryRootUrlStore = PyroServiceRequest.FhirRequestUri.PrimaryRootUrlStore;

              IDatabaseOperationOutcome DatabaseOperationOutcome = _ResourceRepository.GetResourceByFhirIDAndVersionNumber(PyroServiceRequest.ResourceId, PyroServiceRequest.VersionId);
              if (DatabaseOperationOutcome.ReturnedResourceList != null && DatabaseOperationOutcome.ReturnedResourceList.Count == 1)
              {
                if (!DatabaseOperationOutcome.ReturnedResourceList[0].IsDeleted)
                  oPyroServiceOperationOutcome.ResourceResult = Support.FhirResourceSerializationSupport.Serialize(DatabaseOperationOutcome.ReturnedResourceList[0].Xml);
                oPyroServiceOperationOutcome.FhirResourceId = DatabaseOperationOutcome.ReturnedResourceList[0].FhirId;
                oPyroServiceOperationOutcome.LastModified = DatabaseOperationOutcome.ReturnedResourceList[0].Received;
                oPyroServiceOperationOutcome.IsDeleted = DatabaseOperationOutcome.ReturnedResourceList[0].IsDeleted;
                oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;
                oPyroServiceOperationOutcome.ResourceVersionNumber = DatabaseOperationOutcome.ReturnedResourceList[0].Version;
                oPyroServiceOperationOutcome.RequestUri = PyroServiceRequest.FhirRequestUri.FhirUri.Uri;
                oPyroServiceOperationOutcome.ServiceRootUri = PyroServiceRequest.FhirRequestUri.FhirUri.ServiceRootUrl;
                oPyroServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
                oPyroServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;
              }
              else
              {
                oPyroServiceOperationOutcome.ResourceResult = null;
                oPyroServiceOperationOutcome.FhirResourceId = string.Empty;
                oPyroServiceOperationOutcome.LastModified = null;
                oPyroServiceOperationOutcome.IsDeleted = null;
                oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;
                oPyroServiceOperationOutcome.ResourceVersionNumber = string.Empty;
                oPyroServiceOperationOutcome.RequestUri = PyroServiceRequest.FhirRequestUri.FhirUri.Uri;
                oPyroServiceOperationOutcome.ServiceRootUri = PyroServiceRequest.FhirRequestUri.FhirUri.ServiceRootUrl;
                oPyroServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
                oPyroServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.NotFound;
              }
              return oPyroServiceOperationOutcome;
            }
          }
        case ServiceEnums.ServiceRequestType.Read:
          {
            // GET by FhirId
            // GET URL/FhirApi/Patient/5    
            ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchParameterService.ProcessSearchParameters(PyroServiceRequest.SearchParameterGeneric, SearchParameterService.SearchParameterServiceType.Base);
            if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
            {
              oPyroServiceOperationOutcome.SearchParametersServiceOutcome = SearchParametersServiceOutcome;
              return oPyroServiceOperationOutcome;
            }
            SearchParametersServiceOutcome.SearchParameters.PrimaryRootUrlStore = PyroServiceRequest.FhirRequestUri.PrimaryRootUrlStore;

            IDatabaseOperationOutcome DatabaseOperationOutcome = _ResourceRepository.GetResourceByFhirID(PyroServiceRequest.ResourceId, true);
            if (DatabaseOperationOutcome.ReturnedResourceList.Count == 1 && !DatabaseOperationOutcome.ReturnedResourceList[0].IsDeleted)
            {
              oPyroServiceOperationOutcome.ResourceResult = Support.FhirResourceSerializationSupport.Serialize(DatabaseOperationOutcome.ReturnedResourceList[0].Xml);
              oPyroServiceOperationOutcome.FhirResourceId = DatabaseOperationOutcome.ReturnedResourceList[0].FhirId;
              oPyroServiceOperationOutcome.LastModified = DatabaseOperationOutcome.ReturnedResourceList[0].Received;
              oPyroServiceOperationOutcome.IsDeleted = DatabaseOperationOutcome.ReturnedResourceList[0].IsDeleted;
              oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;
              oPyroServiceOperationOutcome.ResourceVersionNumber = DatabaseOperationOutcome.ReturnedResourceList[0].Version;
              oPyroServiceOperationOutcome.RequestUri = PyroServiceRequest.FhirRequestUri.FhirUri.Uri;
              oPyroServiceOperationOutcome.ServiceRootUri = PyroServiceRequest.FhirRequestUri.FhirUri.ServiceRootUrl;
              oPyroServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
              oPyroServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;
            }
            else if (DatabaseOperationOutcome.ReturnedResourceList.Count == 1 && DatabaseOperationOutcome.ReturnedResourceList[0].IsDeleted)
            {
              oPyroServiceOperationOutcome.ResourceResult = null;
              oPyroServiceOperationOutcome.FhirResourceId = DatabaseOperationOutcome.ReturnedResourceList[0].FhirId;
              oPyroServiceOperationOutcome.LastModified = DatabaseOperationOutcome.ReturnedResourceList[0].Received;
              oPyroServiceOperationOutcome.IsDeleted = DatabaseOperationOutcome.ReturnedResourceList[0].IsDeleted;
              oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;
              oPyroServiceOperationOutcome.ResourceVersionNumber = DatabaseOperationOutcome.ReturnedResourceList[0].Version;
              oPyroServiceOperationOutcome.RequestUri = PyroServiceRequest.FhirRequestUri.FhirUri.Uri;
              oPyroServiceOperationOutcome.ServiceRootUri = PyroServiceRequest.FhirRequestUri.FhirUri.ServiceRootUrl;
              oPyroServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
              oPyroServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.Gone;
            }
            else
            {
              oPyroServiceOperationOutcome.ResourceResult = null;
              oPyroServiceOperationOutcome.FhirResourceId = null;
              oPyroServiceOperationOutcome.LastModified = null;
              oPyroServiceOperationOutcome.IsDeleted = null;
              oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;
              oPyroServiceOperationOutcome.ResourceVersionNumber = null;
              oPyroServiceOperationOutcome.RequestUri = PyroServiceRequest.FhirRequestUri.FhirUri.Uri;
              oPyroServiceOperationOutcome.ServiceRootUri = PyroServiceRequest.FhirRequestUri.FhirUri.ServiceRootUrl;
              oPyroServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
              oPyroServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.NotFound;
            }
            return oPyroServiceOperationOutcome;
          }
        case ServiceEnums.ServiceRequestType.Search:
          {
            // GET by Search
            // GET: URL//FhirApi/Patient?family=Smith&given=John            
            ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchParameterService.ProcessSearchParameters(PyroServiceRequest.SearchParameterGeneric, SearchParameterService.SearchParameterServiceType.Base | SearchParameterService.SearchParameterServiceType.Bundle | SearchParameterService.SearchParameterServiceType.Resource, _CurrentResourceType);
            if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
            {
              oPyroServiceOperationOutcome.SearchParametersServiceOutcome = SearchParametersServiceOutcome;
              return oPyroServiceOperationOutcome;
            }
            SearchParametersServiceOutcome.SearchParameters.PrimaryRootUrlStore = PyroServiceRequest.FhirRequestUri.PrimaryRootUrlStore;

            IDatabaseOperationOutcome DatabaseOperationOutcome = _ResourceRepository.GetResourceBySearch(SearchParametersServiceOutcome.SearchParameters, true);

            oPyroServiceOperationOutcome.ResourceResult = Support.FhirBundleSupport.CreateBundle(DatabaseOperationOutcome.ReturnedResourceList,
                                                                                                   Bundle.BundleType.Searchset,
                                                                                                   PyroServiceRequest.FhirRequestUri,
                                                                                                   DatabaseOperationOutcome.SearchTotal,
                                                                                                   DatabaseOperationOutcome.PagesTotal,
                                                                                                   DatabaseOperationOutcome.PageRequested);
            oPyroServiceOperationOutcome.FhirResourceId = string.Empty;
            oPyroServiceOperationOutcome.LastModified = null;
            oPyroServiceOperationOutcome.IsDeleted = null;
            oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;
            oPyroServiceOperationOutcome.ResourceVersionNumber = string.Empty;
            oPyroServiceOperationOutcome.RequestUri = PyroServiceRequest.FhirRequestUri.FhirUri.Uri;
            oPyroServiceOperationOutcome.ServiceRootUri = PyroServiceRequest.FhirRequestUri.FhirUri.ServiceRootUrl;
            oPyroServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
            oPyroServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;

            return oPyroServiceOperationOutcome;
          }
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(PyroServiceRequest.ServiceRequestType.ToString(), (int)PyroServiceRequest.ServiceRequestType, typeof(ServiceEnums.ServiceRequestType));
      }
    }

    // Add (POST)
    // POST: URL/FhirApi/Patient
    public virtual IResourceServiceOutcome Post(IResourceServiceRequest PyroServiceRequest)
    {
      IResourceServiceOutcome oPyroServiceOperationOutcome = Common.CommonFactory.GetPyroServiceOperationOutcome();

      ISearchParametersServiceOutcome SearchParametersServiceOutcomeBase = SearchParameterService.ProcessSearchParameters(PyroServiceRequest.SearchParameterGeneric, SearchParameterService.SearchParameterServiceType.Base);
      if (SearchParametersServiceOutcomeBase.FhirOperationOutcome != null)
      {
        oPyroServiceOperationOutcome.SearchParametersServiceOutcome = SearchParametersServiceOutcomeBase;
        return oPyroServiceOperationOutcome;
      }
      SearchParametersServiceOutcomeBase.SearchParameters.PrimaryRootUrlStore = PyroServiceRequest.FhirRequestUri.PrimaryRootUrlStore;

      if ((PyroServiceRequest.RequestHeaders != null) && (!string.IsNullOrWhiteSpace(PyroServiceRequest.RequestHeaders.IfNoneExist)))
      {
        IDtoSearchParameterGeneric SearchParameterGenericIfNoneExist = Common.CommonFactory.GetDtoSearchParameterGeneric(PyroServiceRequest.RequestHeaders.IfNoneExist);
        ISearchParametersServiceOutcome SearchParametersServiceOutcomeIfNoneExist = SearchParameterService.ProcessSearchParameters(SearchParameterGenericIfNoneExist, SearchParameterService.SearchParameterServiceType.Bundle | SearchParameterService.SearchParameterServiceType.Resource, _CurrentResourceType);
        if (SearchParametersServiceOutcomeIfNoneExist.FhirOperationOutcome != null)
        {
          oPyroServiceOperationOutcome.SearchParametersServiceOutcome = SearchParametersServiceOutcomeIfNoneExist;
          return oPyroServiceOperationOutcome;
        }
        SearchParametersServiceOutcomeIfNoneExist.SearchParameters.PrimaryRootUrlStore = PyroServiceRequest.FhirRequestUri.PrimaryRootUrlStore;

        IDatabaseOperationOutcome DatabaseOperationOutcomeIfNoneExist = _ResourceRepository.GetResourceBySearch(SearchParametersServiceOutcomeIfNoneExist.SearchParameters, false);
        if (DatabaseOperationOutcomeIfNoneExist.SearchTotal == 1)
        {
          //From FHIR Specification: One Match: The server ignore the post and returns 200 OK
          oPyroServiceOperationOutcome.ResourceResult = null;
          oPyroServiceOperationOutcome.FhirResourceId = DatabaseOperationOutcomeIfNoneExist.ReturnedResourceList[0].FhirId;
          oPyroServiceOperationOutcome.LastModified = DatabaseOperationOutcomeIfNoneExist.ReturnedResourceList[0].Received;
          oPyroServiceOperationOutcome.IsDeleted = DatabaseOperationOutcomeIfNoneExist.ReturnedResourceList[0].IsDeleted;
          oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Create;
          oPyroServiceOperationOutcome.ResourceVersionNumber = DatabaseOperationOutcomeIfNoneExist.ReturnedResourceList[0].Version;
          oPyroServiceOperationOutcome.RequestUri = PyroServiceRequest.FhirRequestUri.FhirUri.Uri;
          oPyroServiceOperationOutcome.ServiceRootUri = PyroServiceRequest.FhirRequestUri.FhirUri.ServiceRootUrl;
          oPyroServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcomeBase.SearchParameters.Format;
          oPyroServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;
          return oPyroServiceOperationOutcome;
        }
        else if (DatabaseOperationOutcomeIfNoneExist.SearchTotal > 1)
        {
          //From FHIR Specification: Multiple matches: The server returns a 412 Precondition Failed error 
          //                         indicating the client's criteria were not selective enough
          oPyroServiceOperationOutcome.ResourceResult = null;
          oPyroServiceOperationOutcome.FhirResourceId = string.Empty;
          oPyroServiceOperationOutcome.LastModified = null;
          oPyroServiceOperationOutcome.IsDeleted = null;
          oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Create;
          oPyroServiceOperationOutcome.ResourceVersionNumber = string.Empty;
          oPyroServiceOperationOutcome.RequestUri = PyroServiceRequest.FhirRequestUri.FhirUri.Uri;
          oPyroServiceOperationOutcome.ServiceRootUri = PyroServiceRequest.FhirRequestUri.FhirUri.ServiceRootUrl;
          oPyroServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcomeBase.SearchParameters.Format;
          oPyroServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.PreconditionFailed;
          return oPyroServiceOperationOutcome;
        }
      }

      if (!string.IsNullOrWhiteSpace(PyroServiceRequest.Resource.Id))
      {
        string Message = string.Format("The create (POST) interaction creates a new resource in a server-assigned location. If the client wishes to have control over the id of a newly submitted resource, it should use the update interaction instead. The Resource provide was found to contain the id: {0}", PyroServiceRequest.Resource.Id);
        oPyroServiceOperationOutcome.ResourceValidationOperationOutcome.FhirOperationOutcome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Required, Message);
        oPyroServiceOperationOutcome.ResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        return oPyroServiceOperationOutcome;
      }
      //Assign GUID as FHIR id;
      PyroServiceRequest.Resource.Id = Guid.NewGuid().ToString();

      //Validation of resource        
      Interfaces.IResourceValidation Validation = Pyro.Engine.Validation.ResourceValidationFactory.GetValidationInstance(CurrentResourceType);
      IResourceValidationOperationOutcome oResourceValidationOperationOutcome = Validation.Validate(PyroServiceRequest.Resource);
      if (oResourceValidationOperationOutcome.HasError)
      {
        oPyroServiceOperationOutcome.ResourceValidationOperationOutcome = oResourceValidationOperationOutcome;
        return oPyroServiceOperationOutcome;
      }

      if (PyroServiceRequest.Resource.Meta == null)
        PyroServiceRequest.Resource.Meta = new Meta();
      string ResourceVersionNumber = Common.Tools.ResourceVersionNumber.FirstVersion();
      PyroServiceRequest.Resource.Meta.VersionId = ResourceVersionNumber;
      PyroServiceRequest.Resource.Meta.LastUpdated = DateTimeOffset.Now;

      IDatabaseOperationOutcome DatabaseOperationOutcome = _ResourceRepository.AddResource(PyroServiceRequest.Resource, PyroServiceRequest.FhirRequestUri);
      if (DatabaseOperationOutcome.ReturnedResourceList.Count == 1)
      {
        oPyroServiceOperationOutcome.ResourceResult = Support.FhirResourceSerializationSupport.Serialize(DatabaseOperationOutcome.ReturnedResourceList[0].Xml);
        oPyroServiceOperationOutcome.FhirResourceId = DatabaseOperationOutcome.ReturnedResourceList[0].FhirId;
        oPyroServiceOperationOutcome.LastModified = DatabaseOperationOutcome.ReturnedResourceList[0].Received;
        oPyroServiceOperationOutcome.IsDeleted = DatabaseOperationOutcome.ReturnedResourceList[0].IsDeleted;
        oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Create;
        oPyroServiceOperationOutcome.ResourceVersionNumber = DatabaseOperationOutcome.ReturnedResourceList[0].Version;
        oPyroServiceOperationOutcome.RequestUri = PyroServiceRequest.FhirRequestUri.FhirUri.Uri;
        oPyroServiceOperationOutcome.ServiceRootUri = PyroServiceRequest.FhirRequestUri.FhirUri.ServiceRootUrl;
        oPyroServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcomeBase.SearchParameters.Format;
        oPyroServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.Created;
      }
      else
      {
        oPyroServiceOperationOutcome.ResourceResult = null;
        oPyroServiceOperationOutcome.FhirResourceId = string.Empty;
        oPyroServiceOperationOutcome.LastModified = null;
        oPyroServiceOperationOutcome.IsDeleted = null;
        oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Create;
        oPyroServiceOperationOutcome.ResourceVersionNumber = string.Empty;
        oPyroServiceOperationOutcome.RequestUri = PyroServiceRequest.FhirRequestUri.FhirUri.Uri;
        oPyroServiceOperationOutcome.ServiceRootUri = PyroServiceRequest.FhirRequestUri.FhirUri.ServiceRootUrl;
        oPyroServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcomeBase.SearchParameters.Format;
        oPyroServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
      }
      return oPyroServiceOperationOutcome;
    }

    //Update (PUT)
    // PUT: URL/FhirApi/Patient/5
    public virtual IResourceServiceOutcome Put(IResourceServiceRequest PyroServiceRequest)
    {
      IResourceServiceOutcome oPyroServiceOperationOutcome = Common.CommonFactory.GetPyroServiceOperationOutcome();
      ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchParameterService.ProcessSearchParameters(PyroServiceRequest.SearchParameterGeneric, SearchParameterService.SearchParameterServiceType.Base);
      if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
      {
        oPyroServiceOperationOutcome.SearchParametersServiceOutcome = SearchParametersServiceOutcome;
        return oPyroServiceOperationOutcome;
      }
      SearchParametersServiceOutcome.SearchParameters.PrimaryRootUrlStore = PyroServiceRequest.FhirRequestUri.PrimaryRootUrlStore;

      if (string.IsNullOrWhiteSpace(PyroServiceRequest.Resource.Id) || PyroServiceRequest.Resource.Id != PyroServiceRequest.ResourceId)
      {
        string Message = String.Format("The Resource SHALL contain an id element that has an identical value to the [id] in the URL. The id in the resource was: '{0}' and the [id] in the URL was: '{1}'", PyroServiceRequest.Resource.Id, PyroServiceRequest.ResourceId);
        oPyroServiceOperationOutcome.ResourceValidationOperationOutcome.FhirOperationOutcome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Required, Message);
        oPyroServiceOperationOutcome.ResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        return oPyroServiceOperationOutcome;
      }

      Interfaces.IResourceValidation Validation = Pyro.Engine.Validation.ResourceValidationFactory.GetValidationInstance(CurrentResourceType);
      IResourceValidationOperationOutcome oResourceValidationOperationOutcome = Validation.Validate(PyroServiceRequest.Resource);
      if (oResourceValidationOperationOutcome.HasError)
      {
        oPyroServiceOperationOutcome.ResourceValidationOperationOutcome = oResourceValidationOperationOutcome;
        return oPyroServiceOperationOutcome;
      }

      //Create Resource's Meta element if not found and update its last updated property to now
      if (PyroServiceRequest.Resource.Meta == null)
        PyroServiceRequest.Resource.Meta = new Meta();
      PyroServiceRequest.Resource.Meta.LastUpdated = DateTimeOffset.Now;

      //Check db for existence of this Resource 
      IDatabaseOperationOutcome DatabaseOperationOutcomeGet = _ResourceRepository.GetResourceByFhirID(PyroServiceRequest.ResourceId);
      if (DatabaseOperationOutcomeGet.ReturnedResourceList.Count != 0)
      {
        //The resource has been found so update its version number based on the older resource              
        PyroServiceRequest.Resource.Meta.VersionId = Common.Tools.ResourceVersionNumber.Increment(DatabaseOperationOutcomeGet.ReturnedResourceList[0].Version);
        IDatabaseOperationOutcome DatabaseOperationOutcomeUpdate = _ResourceRepository.UpdateResource(PyroServiceRequest.Resource.Meta.VersionId, PyroServiceRequest.Resource, PyroServiceRequest.FhirRequestUri);
        if (DatabaseOperationOutcomeUpdate.ReturnedResourceList != null && DatabaseOperationOutcomeUpdate.ReturnedResourceList.Count == 1)
        {
          oPyroServiceOperationOutcome.ResourceResult = Support.FhirResourceSerializationSupport.Serialize(DatabaseOperationOutcomeUpdate.ReturnedResourceList[0].Xml);
          oPyroServiceOperationOutcome.FhirResourceId = DatabaseOperationOutcomeUpdate.ReturnedResourceList[0].FhirId;
          oPyroServiceOperationOutcome.LastModified = DatabaseOperationOutcomeUpdate.ReturnedResourceList[0].Received;
          oPyroServiceOperationOutcome.IsDeleted = DatabaseOperationOutcomeUpdate.ReturnedResourceList[0].IsDeleted;
          oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Update;
          oPyroServiceOperationOutcome.ResourceVersionNumber = DatabaseOperationOutcomeUpdate.ReturnedResourceList[0].Version;
          oPyroServiceOperationOutcome.RequestUri = PyroServiceRequest.FhirRequestUri.FhirUri.Uri;
          oPyroServiceOperationOutcome.ServiceRootUri = PyroServiceRequest.FhirRequestUri.FhirUri.ServiceRootUrl;
          oPyroServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
          oPyroServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;
        }
        else
        {
          oPyroServiceOperationOutcome.ResourceResult = null;
          oPyroServiceOperationOutcome.FhirResourceId = string.Empty;
          oPyroServiceOperationOutcome.LastModified = null;
          oPyroServiceOperationOutcome.IsDeleted = null;
          oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Update;
          oPyroServiceOperationOutcome.ResourceVersionNumber = string.Empty;
          oPyroServiceOperationOutcome.RequestUri = PyroServiceRequest.FhirRequestUri.FhirUri.Uri;
          oPyroServiceOperationOutcome.ServiceRootUri = PyroServiceRequest.FhirRequestUri.FhirUri.ServiceRootUrl;
          oPyroServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
          oPyroServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        }
      }
      else
      {
        //This is a new resource so update its version number as 1
        PyroServiceRequest.Resource.Meta.VersionId = Common.Tools.ResourceVersionNumber.FirstVersion();
        IDatabaseOperationOutcome DatabaseOperationOutcomeAdd = _ResourceRepository.AddResource(PyroServiceRequest.Resource, PyroServiceRequest.FhirRequestUri);
        if (DatabaseOperationOutcomeAdd.ReturnedResourceList != null && DatabaseOperationOutcomeAdd.ReturnedResourceList.Count == 1)
        {
          oPyroServiceOperationOutcome.ResourceResult = Support.FhirResourceSerializationSupport.Serialize(DatabaseOperationOutcomeAdd.ReturnedResourceList[0].Xml);
          oPyroServiceOperationOutcome.FhirResourceId = DatabaseOperationOutcomeAdd.ReturnedResourceList[0].FhirId;
          oPyroServiceOperationOutcome.LastModified = DatabaseOperationOutcomeAdd.ReturnedResourceList[0].Received;
          oPyroServiceOperationOutcome.IsDeleted = DatabaseOperationOutcomeAdd.ReturnedResourceList[0].IsDeleted;
          oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Create;
          oPyroServiceOperationOutcome.ResourceVersionNumber = DatabaseOperationOutcomeAdd.ReturnedResourceList[0].Version;
          oPyroServiceOperationOutcome.RequestUri = PyroServiceRequest.FhirRequestUri.FhirUri.Uri;
          oPyroServiceOperationOutcome.ServiceRootUri = PyroServiceRequest.FhirRequestUri.FhirUri.ServiceRootUrl;
          oPyroServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
          oPyroServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.Created;
        }
        else
        {
          oPyroServiceOperationOutcome.ResourceResult = null;
          oPyroServiceOperationOutcome.FhirResourceId = string.Empty;
          oPyroServiceOperationOutcome.LastModified = null;
          oPyroServiceOperationOutcome.IsDeleted = null;
          oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Create;
          oPyroServiceOperationOutcome.ResourceVersionNumber = string.Empty;
          oPyroServiceOperationOutcome.RequestUri = PyroServiceRequest.FhirRequestUri.FhirUri.Uri;
          oPyroServiceOperationOutcome.ServiceRootUri = PyroServiceRequest.FhirRequestUri.FhirUri.ServiceRootUrl;
          oPyroServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
          oPyroServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        }
      }
      return oPyroServiceOperationOutcome;
    }

    //Delete
    // DELETE: URL/FhirApi/Patient/5
    public virtual IResourceServiceOutcome Delete(IResourceServiceRequest PyroServiceRequest)
    {
      IResourceServiceOutcome oPyroServiceOperationOutcome = Common.CommonFactory.GetPyroServiceOperationOutcome();
      ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchParameterService.ProcessSearchParameters(PyroServiceRequest.SearchParameterGeneric, SearchParameterService.SearchParameterServiceType.Base);
      if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
      {
        oPyroServiceOperationOutcome.SearchParametersServiceOutcome = SearchParametersServiceOutcome;
        return oPyroServiceOperationOutcome;
      }
      SearchParametersServiceOutcome.SearchParameters.PrimaryRootUrlStore = PyroServiceRequest.FhirRequestUri.PrimaryRootUrlStore;

      IDatabaseOperationOutcome DatabaseOperationOutcomeGet = _ResourceRepository.GetResourceByFhirID(PyroServiceRequest.ResourceId);
      if (DatabaseOperationOutcomeGet.ReturnedResourceList.Count == 1)
      {
        //Resource exists so..
        if (!DatabaseOperationOutcomeGet.ReturnedResourceList[0].IsDeleted)
        {
          string NewResourceVersionNumber = Common.Tools.ResourceVersionNumber.Increment(DatabaseOperationOutcomeGet.ReturnedResourceList[0].Version);
          IDatabaseOperationOutcome DatabaseOperationOutcomeDelete = _ResourceRepository.UpdateResouceAsDeleted(PyroServiceRequest.ResourceId, NewResourceVersionNumber);

          oPyroServiceOperationOutcome.ResourceResult = null;
          oPyroServiceOperationOutcome.FhirResourceId = PyroServiceRequest.ResourceId;
          oPyroServiceOperationOutcome.LastModified = DatabaseOperationOutcomeDelete.ReturnedResourceList[0].Received;
          oPyroServiceOperationOutcome.IsDeleted = true;
          oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Delete;
          oPyroServiceOperationOutcome.ResourceVersionNumber = NewResourceVersionNumber;
          oPyroServiceOperationOutcome.RequestUri = null;
          oPyroServiceOperationOutcome.ServiceRootUri = null;
          oPyroServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
          oPyroServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.NoContent;
        }
        else
        {
          oPyroServiceOperationOutcome.ResourceResult = null;
          oPyroServiceOperationOutcome.FhirResourceId = PyroServiceRequest.ResourceId;
          oPyroServiceOperationOutcome.LastModified = DatabaseOperationOutcomeGet.ReturnedResourceList[0].Received;
          oPyroServiceOperationOutcome.IsDeleted = DatabaseOperationOutcomeGet.ReturnedResourceList[0].IsDeleted;
          oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Delete;
          oPyroServiceOperationOutcome.ResourceVersionNumber = DatabaseOperationOutcomeGet.ReturnedResourceList[0].Version;
          oPyroServiceOperationOutcome.RequestUri = null;
          oPyroServiceOperationOutcome.ServiceRootUri = null;
          oPyroServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
          oPyroServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.NoContent;
        }
      }
      else
      {
        //No resource found at all.
        oPyroServiceOperationOutcome.ResourceResult = null;
        oPyroServiceOperationOutcome.FhirResourceId = null;
        oPyroServiceOperationOutcome.LastModified = null;
        oPyroServiceOperationOutcome.IsDeleted = null;
        oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Delete;
        oPyroServiceOperationOutcome.ResourceVersionNumber = null;
        oPyroServiceOperationOutcome.RequestUri = null;
        oPyroServiceOperationOutcome.ServiceRootUri = null;
        oPyroServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
        oPyroServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.NotFound;
      }
      return oPyroServiceOperationOutcome;
    }

    //ConditionalUpdate (PUT)
    //DELETE: URL/FhirApi/Patient?identifier=12345&family=millar&given=angus 
    public IResourceServiceOutcome ConditionalPut(IResourceServiceRequest PyroServiceRequest)
    {
      IResourceServiceOutcome ServiceOperationOutcomeConditionalPut = Common.CommonFactory.GetPyroServiceOperationOutcome();
      // GET: URL//FhirApi/Patient?family=Smith&given=John                        
      ISearchParametersServiceOutcome SearchParametersServiceOutcomeAll = SearchParameterService.ProcessSearchParameters(PyroServiceRequest.SearchParameterGeneric, SearchParameterService.SearchParameterServiceType.Base | SearchParameterService.SearchParameterServiceType.Resource, _CurrentResourceType);

      if (SearchParametersServiceOutcomeAll.FhirOperationOutcome != null)
      {
        ServiceOperationOutcomeConditionalPut.SearchParametersServiceOutcome = SearchParametersServiceOutcomeAll;
        return ServiceOperationOutcomeConditionalPut;
      }

      SearchParametersServiceOutcomeAll.SearchParameters.PrimaryRootUrlStore = PyroServiceRequest.FhirRequestUri.PrimaryRootUrlStore;

      IDatabaseOperationOutcome DatabaseOperationOutcomeSearch = _ResourceRepository.GetResourceBySearch(SearchParametersServiceOutcomeAll.SearchParameters, false);
      if (DatabaseOperationOutcomeSearch.ReturnedResourceList.Count == 0)
      {
        //No resource found so do a normal Create, first clear any Resource Id that may 
        //be in the resource
        PyroServiceRequest.Resource.Id = string.Empty;

        IResourceServiceRequest ServiceRequestSingleCreate = Common.CommonFactory.GetResourceServiceRequest(ServiceEnums.ServiceRequestType.Create, PyroServiceRequest.Resource, PyroServiceRequest.FhirRequestUri, PyroServiceRequest.SearchParameterGeneric);
        ServiceOperationOutcomeConditionalPut = this.Post(ServiceRequestSingleCreate);
      }
      else if (DatabaseOperationOutcomeSearch.ReturnedResourceList.Count == 1)
      {
        if (!string.IsNullOrWhiteSpace(PyroServiceRequest.Resource.Id))
        {
          if (DatabaseOperationOutcomeSearch.ReturnedResourceList[0].FhirId != PyroServiceRequest.Resource.Id)
          {
            string Message = "The single Resource located by the search has a different Resource Id to that which was found in the Resource given. Either, remove the Id from the Resource given or re-evaluate the search parameters.";
            SearchParametersServiceOutcomeAll.FhirOperationOutcome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.BusinessRule, Message);
            ServiceOperationOutcomeConditionalPut.SearchParametersServiceOutcome = SearchParametersServiceOutcomeAll;
            return ServiceOperationOutcomeConditionalPut;
          }
        }
        else
        {
          PyroServiceRequest.Resource.Id = DatabaseOperationOutcomeSearch.ReturnedResourceList[0].FhirId;
        }

        //Create Resource's Meta element if not found and update its last updated property to now
        if (PyroServiceRequest.Resource.Meta == null)
          PyroServiceRequest.Resource.Meta = new Meta();
        PyroServiceRequest.Resource.Meta.LastUpdated = DateTimeOffset.Now;

        //A database resource has been found so update the new resource's version number based on the older resource              
        PyroServiceRequest.Resource.Meta.VersionId = Common.Tools.ResourceVersionNumber.Increment(DatabaseOperationOutcomeSearch.ReturnedResourceList[0].Version);

        IDatabaseOperationOutcome DatabaseOperationOutcomeUpdate = _ResourceRepository.UpdateResource(PyroServiceRequest.Resource.Meta.VersionId, PyroServiceRequest.Resource, PyroServiceRequest.FhirRequestUri);
        if (DatabaseOperationOutcomeUpdate.ReturnedResourceList != null && DatabaseOperationOutcomeUpdate.ReturnedResourceList.Count == 1)
        {
          ServiceOperationOutcomeConditionalPut.ResourceResult = Support.FhirResourceSerializationSupport.Serialize(DatabaseOperationOutcomeUpdate.ReturnedResourceList[0].Xml);
          ServiceOperationOutcomeConditionalPut.FhirResourceId = DatabaseOperationOutcomeUpdate.ReturnedResourceList[0].FhirId;
          ServiceOperationOutcomeConditionalPut.LastModified = DatabaseOperationOutcomeUpdate.ReturnedResourceList[0].Received;
          ServiceOperationOutcomeConditionalPut.IsDeleted = DatabaseOperationOutcomeUpdate.ReturnedResourceList[0].IsDeleted;
          ServiceOperationOutcomeConditionalPut.OperationType = RestEnum.CrudOperationType.Update;
          ServiceOperationOutcomeConditionalPut.ResourceVersionNumber = DatabaseOperationOutcomeUpdate.ReturnedResourceList[0].Version;
          ServiceOperationOutcomeConditionalPut.RequestUri = PyroServiceRequest.FhirRequestUri.FhirUri.Uri;
          ServiceOperationOutcomeConditionalPut.ServiceRootUri = PyroServiceRequest.FhirRequestUri.FhirUri.ServiceRootUrl;
          ServiceOperationOutcomeConditionalPut.FormatMimeType = SearchParametersServiceOutcomeAll.SearchParameters.Format;
          ServiceOperationOutcomeConditionalPut.HttpStatusCode = System.Net.HttpStatusCode.OK;
        }
        else
        {
          ServiceOperationOutcomeConditionalPut.ResourceResult = null;
          ServiceOperationOutcomeConditionalPut.FhirResourceId = string.Empty;
          ServiceOperationOutcomeConditionalPut.LastModified = null;
          ServiceOperationOutcomeConditionalPut.IsDeleted = null;
          ServiceOperationOutcomeConditionalPut.OperationType = RestEnum.CrudOperationType.Update;
          ServiceOperationOutcomeConditionalPut.ResourceVersionNumber = string.Empty;
          ServiceOperationOutcomeConditionalPut.RequestUri = PyroServiceRequest.FhirRequestUri.FhirUri.Uri;
          ServiceOperationOutcomeConditionalPut.ServiceRootUri = PyroServiceRequest.FhirRequestUri.FhirUri.ServiceRootUrl;
          ServiceOperationOutcomeConditionalPut.FormatMimeType = SearchParametersServiceOutcomeAll.SearchParameters.Format;
          ServiceOperationOutcomeConditionalPut.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        }

      }
      else if (DatabaseOperationOutcomeSearch.ReturnedResourceList.Count > 1)
      {
        //should I return an operationOutcome
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
      }
      return ServiceOperationOutcomeConditionalPut;

    }

    //ConditionalDelete (Delete)
    //DELETE: URL/FhirApi/Patient?identifier=12345&family=millar&given=angus 
    public IResourceServiceOutcome ConditionalDelete(IResourceServiceRequest PyroServiceRequest)
    {
      IResourceServiceOutcome ServiceOperationOutcomeConditionalDelete = Common.CommonFactory.GetPyroServiceOperationOutcome();
      // GET: URL//FhirApi/Patient?family=Smith&given=John          
      ISearchParametersServiceOutcome SearchParametersServiceOutcomeBaseOnly = SearchParameterService.ProcessSearchParameters(PyroServiceRequest.SearchParameterGeneric, SearchParameterService.SearchParameterServiceType.Base, _CurrentResourceType);
      ISearchParametersServiceOutcome SearchParametersServiceOutcomeAll = SearchParameterService.ProcessSearchParameters(PyroServiceRequest.SearchParameterGeneric, SearchParameterService.SearchParameterServiceType.Base | SearchParameterService.SearchParameterServiceType.Resource, _CurrentResourceType);

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

      SearchParametersServiceOutcomeAll.SearchParameters.PrimaryRootUrlStore = PyroServiceRequest.FhirRequestUri.PrimaryRootUrlStore;

      IDatabaseOperationOutcome DatabaseOperationOutcomeSearch = _ResourceRepository.GetResourceBySearch(SearchParametersServiceOutcomeAll.SearchParameters, false);
      if (DatabaseOperationOutcomeSearch.ReturnedResourceList.Count == 0)
      {
        //No resource found at all.        
        ServiceOperationOutcomeConditionalDelete.ResourceResult = null;
        ServiceOperationOutcomeConditionalDelete.FhirResourceId = null;
        ServiceOperationOutcomeConditionalDelete.LastModified = null;
        ServiceOperationOutcomeConditionalDelete.IsDeleted = null;
        ServiceOperationOutcomeConditionalDelete.OperationType = RestEnum.CrudOperationType.Delete;
        ServiceOperationOutcomeConditionalDelete.ResourceVersionNumber = null;
        ServiceOperationOutcomeConditionalDelete.RequestUri = null;
        ServiceOperationOutcomeConditionalDelete.ServiceRootUri = null;
        ServiceOperationOutcomeConditionalDelete.FormatMimeType = SearchParametersServiceOutcomeAll.SearchParameters.Format;
        ServiceOperationOutcomeConditionalDelete.HttpStatusCode = System.Net.HttpStatusCode.NotFound;
      }
      else if (DatabaseOperationOutcomeSearch.ReturnedResourceList.Count == 1)
      {
        IResourceServiceRequest ServiceRequestSingleDelete = Common.CommonFactory.GetResourceServiceRequest(ServiceEnums.ServiceRequestType.Delete, DatabaseOperationOutcomeSearch.ReturnedResourceList[0].FhirId, PyroServiceRequest.FhirRequestUri, PyroServiceRequest.SearchParameterGeneric);
        ServiceOperationOutcomeConditionalDelete = this.Delete(ServiceRequestSingleDelete);
      }
      else if (DatabaseOperationOutcomeSearch.ReturnedResourceList.Count > 1)
      {
        IDatabaseOperationOutcome DatabaseOperationOutcomeDeleteMany = _ResourceRepository.UpdateResouceListAsDeleted(DatabaseOperationOutcomeSearch.ReturnedResourceList.Where(x => x.IsDeleted == false).ToArray());
        ServiceOperationOutcomeConditionalDelete.ResourceResult = null;
        ServiceOperationOutcomeConditionalDelete.FhirResourceId = null;
        ServiceOperationOutcomeConditionalDelete.LastModified = null;
        ServiceOperationOutcomeConditionalDelete.IsDeleted = true;
        ServiceOperationOutcomeConditionalDelete.OperationType = RestEnum.CrudOperationType.Delete;
        ServiceOperationOutcomeConditionalDelete.ResourceVersionNumber = null;
        ServiceOperationOutcomeConditionalDelete.RequestUri = null;
        ServiceOperationOutcomeConditionalDelete.ServiceRootUri = null;
        ServiceOperationOutcomeConditionalDelete.FormatMimeType = SearchParametersServiceOutcomeAll.SearchParameters.Format;
        ServiceOperationOutcomeConditionalDelete.HttpStatusCode = System.Net.HttpStatusCode.NoContent;
      }
      return ServiceOperationOutcomeConditionalDelete;
    }
  }
}

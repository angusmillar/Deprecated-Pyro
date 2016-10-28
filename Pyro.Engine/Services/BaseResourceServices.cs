using System;
using System.Collections.Generic;
using Pyro.Common.Interfaces;
using Pyro.Common.Interfaces.Services;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.BusinessEntities.Search.Validation;
using Pyro.Common.Enum;
using Hl7.Fhir.Model;

namespace Pyro.Engine.Services
{
  public abstract class BaseResourceServices : CommonServices, IBaseResourceServices, ICommonServices, IBaseServices
  {
    protected IResourceRepository _ResourceRepository = null;

    //Constructor for dependency injection
    public BaseResourceServices(IUnitOfWork IUnitOfWork)
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

    //GET Search
    // GET: URL//FhirApi/Patient?family=Smith&given=John
    public virtual IServiceOperationOutcome Get(IPyroServiceRequest PyroServiceRequest)
    {
      IServiceOperationOutcome oPyroServiceOperationOutcome = Common.CommonFactory.GetPyroServiceOperationOutcome();
      SearchParametersValidationOperationOutcome oSearchParametersValidationOperationOutcome = SearchParameterValidator.Validate(_CurrentResourceType, new Common.BusinessEntities.Search.DtoSearchParameterGeneric(PyroServiceRequest.SearchParams));
      if (oSearchParametersValidationOperationOutcome.FhirOperationOutcome != null)
      {
        oPyroServiceOperationOutcome.SearchValidationOperationOutcome = oSearchParametersValidationOperationOutcome;
        return oPyroServiceOperationOutcome;
      }
      oSearchParametersValidationOperationOutcome.SearchParameters.PrimaryRootUrlStore = PyroServiceRequest.FhirRequestUri.PrimaryRootUrlStore;
      oPyroServiceOperationOutcome.OperationType = Pyro.Common.Enum.RestEnum.CrudOperationType.Read;
      oPyroServiceOperationOutcome.RequestUri = PyroServiceRequest.FhirRequestUri.FhirUri.ServiceRootUrl;
      oPyroServiceOperationOutcome.DatabaseOperationOutcome = _ResourceRepository.GetResourceBySearch(oSearchParametersValidationOperationOutcome.SearchParameters);
      return oPyroServiceOperationOutcome;


    }

    // GET by FhirId and FhirVId
    // GET URL/FhirApi/Patient/5    
    public virtual IServiceOperationOutcome Get(string FhirId, string FhirVId)
    {
      IServiceOperationOutcome oPyroServiceOperationOutcome = Common.CommonFactory.GetPyroServiceOperationOutcome();
      oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;
      oPyroServiceOperationOutcome.DatabaseOperationOutcome = _ResourceRepository.GetResourceByFhirIDAndVersionNumber(FhirId, FhirVId);
      return oPyroServiceOperationOutcome;
    }

    // GET by FhirId
    // GET URL/FhirApi/Patient/5    
    public virtual IServiceOperationOutcome Get(string FhirId)
    {
      IServiceOperationOutcome oPyroServiceOperationOutcome = Common.CommonFactory.GetPyroServiceOperationOutcome();
      oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;
      oPyroServiceOperationOutcome.DatabaseOperationOutcome = _ResourceRepository.GetResourceByFhirID(FhirId, true);
      return oPyroServiceOperationOutcome;
    }

    // Add
    // POST: URL/FhirApi/Patient
    public virtual IServiceOperationOutcome Post(IPyroServiceRequest PyroServiceRequest)
    {
      IServiceOperationOutcome oPyroServiceOperationOutcome = Common.CommonFactory.GetPyroServiceOperationOutcome();
      oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Create;
      
      if (!string.IsNullOrWhiteSpace(PyroServiceRequest.Resource.Id))
      {
        var oIssueComponent = new OperationOutcome.IssueComponent();
        oIssueComponent.Severity = OperationOutcome.IssueSeverity.Error;
        oIssueComponent.Code = OperationOutcome.IssueType.Required;
        oIssueComponent.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_INVALID_ID", String.Format("Id not accepted, type"));
        oIssueComponent.Details.Text = String.Format("The create (POST) interaction creates a new resource in a server-assigned location. If the client wishes to have control over the id of a newly submitted resource, it should use the update interaction instead. The Resource provide was found to contain the id: {0}", PyroServiceRequest.Resource.Id);
        oIssueComponent.Diagnostics = oIssueComponent.Details.Text;
        var oOperationOutcome = new OperationOutcome();
        oOperationOutcome.Issue = new List<OperationOutcome.IssueComponent>() { oIssueComponent };
        oPyroServiceOperationOutcome.ResourceValidationOperationOutcome = new Validation.ResourceValidationOperationOutcome();
        oPyroServiceOperationOutcome.ResourceValidationOperationOutcome.FhirOperationOutcome = oOperationOutcome;
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
      string ResourceVersionNumber = Support.ResourceVersionNumber.FirstVersion();
      PyroServiceRequest.Resource.Meta.VersionId = ResourceVersionNumber;
      PyroServiceRequest.Resource.Meta.LastUpdated = DateTimeOffset.Now;
      oPyroServiceOperationOutcome.DatabaseOperationOutcome = _ResourceRepository.AddResource(PyroServiceRequest.Resource, PyroServiceRequest.FhirRequestUri);
      oPyroServiceOperationOutcome.FhirResourceId = oPyroServiceOperationOutcome.DatabaseOperationOutcome.ReturnedResource.FhirId;
      oPyroServiceOperationOutcome.LastModified = oPyroServiceOperationOutcome.DatabaseOperationOutcome.ReturnedResource.Received;
      oPyroServiceOperationOutcome.ResourceVersionNumber = ResourceVersionNumber;
      return oPyroServiceOperationOutcome;
    }

    //Update
    // PUT: URL/FhirApi/Patient/5
    public virtual IServiceOperationOutcome Put(IPyroServiceRequest PyroServiceRequest)
    {
      IServiceOperationOutcome oPyroServiceOperationOutcome = Common.CommonFactory.GetPyroServiceOperationOutcome();
      oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Update;
      if (string.IsNullOrWhiteSpace(PyroServiceRequest.Resource.Id) || PyroServiceRequest.Resource.Id != PyroServiceRequest.ResourceId)
      {
        var oIssueComponent = new OperationOutcome.IssueComponent();
        oIssueComponent.Severity = OperationOutcome.IssueSeverity.Error;
        oIssueComponent.Code = OperationOutcome.IssueType.Required;
        oIssueComponent.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_INVALID_ID", String.Format("Id not accepted, type"));
        oIssueComponent.Details.Text = String.Format("The Resource SHALL contain an id element that has an identical value to the [id] in the URL. The id in the resource was: '{0}' and the [id] in the URL was: '{1}'", PyroServiceRequest.Resource.Id, PyroServiceRequest.ResourceId);
        oIssueComponent.Diagnostics = oIssueComponent.Details.Text;
        var oOperationOutcome = new OperationOutcome();
        oOperationOutcome.Issue = new List<OperationOutcome.IssueComponent>() { oIssueComponent };
        oPyroServiceOperationOutcome.ResourceValidationOperationOutcome = new Validation.ResourceValidationOperationOutcome();
        oPyroServiceOperationOutcome.ResourceValidationOperationOutcome.FhirOperationOutcome = oOperationOutcome;
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
      if (DatabaseOperationOutcomeGet.ReturnedResource != null)
      {
        //The resource has been found so update its version number based on the older resource              
        PyroServiceRequest.Resource.Meta.VersionId = Support.ResourceVersionNumber.Increment(DatabaseOperationOutcomeGet.ReturnedResource.Version);
        IDatabaseOperationOutcome DatabaseOperationOutcomeUpdate = _ResourceRepository.UpdateResource(PyroServiceRequest.Resource.Meta.VersionId, PyroServiceRequest.Resource, PyroServiceRequest.FhirRequestUri);
        oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Update;
        oPyroServiceOperationOutcome.FhirResourceId = PyroServiceRequest.ResourceId;
        oPyroServiceOperationOutcome.LastModified = DatabaseOperationOutcomeUpdate.ReturnedResource.Received;
        oPyroServiceOperationOutcome.ResourceVersionNumber = DatabaseOperationOutcomeUpdate.ReturnedResource.Version;
        oPyroServiceOperationOutcome.DatabaseOperationOutcome = DatabaseOperationOutcomeUpdate;
      }
      else
      {
        //This is a new resource so update its version number as 1
        PyroServiceRequest.Resource.Meta.VersionId = Support.ResourceVersionNumber.FirstVersion();
        IDatabaseOperationOutcome DatabaseOperationOutcomeAdd = _ResourceRepository.AddResource(PyroServiceRequest.Resource, PyroServiceRequest.FhirRequestUri);
        oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Create;
        oPyroServiceOperationOutcome.FhirResourceId = PyroServiceRequest.ResourceId;
        oPyroServiceOperationOutcome.LastModified = DatabaseOperationOutcomeAdd.ReturnedResource.Received;
        oPyroServiceOperationOutcome.ResourceVersionNumber = DatabaseOperationOutcomeAdd.ReturnedResource.Version;
        oPyroServiceOperationOutcome.DatabaseOperationOutcome = DatabaseOperationOutcomeAdd;       
      }
      return oPyroServiceOperationOutcome;
    }

    //Delete
    // DELETE: URL/FhirApi/Patient/5
    public virtual IServiceOperationOutcome Delete(string FhirResourceId)
    {
      IServiceOperationOutcome oPyroServiceOperationOutcome = Common.CommonFactory.GetPyroServiceOperationOutcome();
      oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Delete;
      oPyroServiceOperationOutcome.FhirResourceId = FhirResourceId;
      oPyroServiceOperationOutcome.ResourceVersionNumber = null;
      IDatabaseOperationOutcome DatabaseOperationOutcome = _ResourceRepository.GetResourceByFhirID(FhirResourceId);
      if (DatabaseOperationOutcome.ReturnedResource != null)
      {
        //Resource exists so..
        if (!DatabaseOperationOutcome.ReturnedResource.IsDeleted)
        {
          string NewResourceVersionNumber = Support.ResourceVersionNumber.Increment(DatabaseOperationOutcome.ReturnedResource.Version);
          _ResourceRepository.UpdateResouceAsDeleted(FhirResourceId, NewResourceVersionNumber);
          oPyroServiceOperationOutcome.ResourceVersionNumber = NewResourceVersionNumber;
        }
        else
        {
          oPyroServiceOperationOutcome.ResourceVersionNumber = DatabaseOperationOutcome.ReturnedResource.Version;
        }
      }
      return oPyroServiceOperationOutcome;
    }

  }
}

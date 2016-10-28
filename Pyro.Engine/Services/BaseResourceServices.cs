using System;
using System.Collections.Generic;
using Blaze.Common.Interfaces;
using Blaze.Common.Interfaces.Services;
using Blaze.Common.Interfaces.Repositories;
using Blaze.Common.BusinessEntities.Search.Validation;
using Blaze.Common.Enum;
using Hl7.Fhir.Model;

namespace Blaze.Engine.Services
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
    public virtual IServiceOperationOutcome Get(IBlazeServiceRequest BlazeServiceRequest)
    {
      IServiceOperationOutcome oBlazeServiceOperationOutcome = Common.CommonFactory.GetBlazeServiceOperationOutcome();
      SearchParametersValidationOperationOutcome oSearchParametersValidationOperationOutcome = SearchParameterValidator.Validate(_CurrentResourceType, new Common.BusinessEntities.Search.DtoSearchParameterGeneric(BlazeServiceRequest.SearchParams));
      if (oSearchParametersValidationOperationOutcome.FhirOperationOutcome != null)
      {
        oBlazeServiceOperationOutcome.SearchValidationOperationOutcome = oSearchParametersValidationOperationOutcome;
        return oBlazeServiceOperationOutcome;
      }
      oSearchParametersValidationOperationOutcome.SearchParameters.PrimaryRootUrlStore = BlazeServiceRequest.FhirRequestUri.PrimaryRootUrlStore;
      oBlazeServiceOperationOutcome.OperationType = Blaze.Common.Enum.RestEnum.CrudOperationType.Read;
      oBlazeServiceOperationOutcome.RequestUri = BlazeServiceRequest.FhirRequestUri.FhirUri.ServiceRootUrl;
      oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _ResourceRepository.GetResourceBySearch(oSearchParametersValidationOperationOutcome.SearchParameters);
      return oBlazeServiceOperationOutcome;


    }

    // GET by FhirId and FhirVId
    // GET URL/FhirApi/Patient/5    
    public virtual IServiceOperationOutcome Get(string FhirId, string FhirVId)
    {
      IServiceOperationOutcome oBlazeServiceOperationOutcome = Common.CommonFactory.GetBlazeServiceOperationOutcome();
      oBlazeServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;
      oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _ResourceRepository.GetResourceByFhirIDAndVersionNumber(FhirId, FhirVId);
      return oBlazeServiceOperationOutcome;
    }

    // GET by FhirId
    // GET URL/FhirApi/Patient/5    
    public virtual IServiceOperationOutcome Get(string FhirId)
    {
      IServiceOperationOutcome oBlazeServiceOperationOutcome = Common.CommonFactory.GetBlazeServiceOperationOutcome();
      oBlazeServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;
      oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _ResourceRepository.GetResourceByFhirID(FhirId, true);
      return oBlazeServiceOperationOutcome;
    }

    // Add
    // POST: URL/FhirApi/Patient
    public virtual IServiceOperationOutcome Post(IBlazeServiceRequest BlazeServiceRequest)
    {
      IServiceOperationOutcome oBlazeServiceOperationOutcome = Common.CommonFactory.GetBlazeServiceOperationOutcome();
      oBlazeServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Create;
      
      if (!string.IsNullOrWhiteSpace(BlazeServiceRequest.Resource.Id))
      {
        var oIssueComponent = new OperationOutcome.IssueComponent();
        oIssueComponent.Severity = OperationOutcome.IssueSeverity.Error;
        oIssueComponent.Code = OperationOutcome.IssueType.Required;
        oIssueComponent.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_INVALID_ID", String.Format("Id not accepted, type"));
        oIssueComponent.Details.Text = String.Format("The create (POST) interaction creates a new resource in a server-assigned location. If the client wishes to have control over the id of a newly submitted resource, it should use the update interaction instead. The Resource provide was found to contain the id: {0}", BlazeServiceRequest.Resource.Id);
        oIssueComponent.Diagnostics = oIssueComponent.Details.Text;
        var oOperationOutcome = new OperationOutcome();
        oOperationOutcome.Issue = new List<OperationOutcome.IssueComponent>() { oIssueComponent };
        oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome = new Validation.ResourceValidationOperationOutcome();
        oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome.FhirOperationOutcome = oOperationOutcome;
        oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        return oBlazeServiceOperationOutcome;
      }
      //Assign GUID as FHIR id;
      BlazeServiceRequest.Resource.Id = Guid.NewGuid().ToString();
      
      //Validation of resource        
      Interfaces.IResourceValidation Validation = Blaze.Engine.Validation.ResourceValidationFactory.GetValidationInstance(CurrentResourceType);
      IResourceValidationOperationOutcome oResourceValidationOperationOutcome = Validation.Validate(BlazeServiceRequest.Resource);
      if (oResourceValidationOperationOutcome.HasError)
      {
        oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome = oResourceValidationOperationOutcome;
        return oBlazeServiceOperationOutcome;
      }
      
      if (BlazeServiceRequest.Resource.Meta == null)
        BlazeServiceRequest.Resource.Meta = new Meta();
      string ResourceVersionNumber = Support.ResourceVersionNumber.FirstVersion();
      BlazeServiceRequest.Resource.Meta.VersionId = ResourceVersionNumber;
      BlazeServiceRequest.Resource.Meta.LastUpdated = DateTimeOffset.Now;
      oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _ResourceRepository.AddResource(BlazeServiceRequest.Resource, BlazeServiceRequest.FhirRequestUri);
      oBlazeServiceOperationOutcome.FhirResourceId = oBlazeServiceOperationOutcome.DatabaseOperationOutcome.ReturnedResource.FhirId;
      oBlazeServiceOperationOutcome.LastModified = oBlazeServiceOperationOutcome.DatabaseOperationOutcome.ReturnedResource.Received;
      oBlazeServiceOperationOutcome.ResourceVersionNumber = ResourceVersionNumber;
      return oBlazeServiceOperationOutcome;
    }

    //Update
    // PUT: URL/FhirApi/Patient/5
    public virtual IServiceOperationOutcome Put(IBlazeServiceRequest BlazeServiceRequest)
    {
      IServiceOperationOutcome oBlazeServiceOperationOutcome = Common.CommonFactory.GetBlazeServiceOperationOutcome();
      oBlazeServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Update;
      if (string.IsNullOrWhiteSpace(BlazeServiceRequest.Resource.Id) || BlazeServiceRequest.Resource.Id != BlazeServiceRequest.ResourceId)
      {
        var oIssueComponent = new OperationOutcome.IssueComponent();
        oIssueComponent.Severity = OperationOutcome.IssueSeverity.Error;
        oIssueComponent.Code = OperationOutcome.IssueType.Required;
        oIssueComponent.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_INVALID_ID", String.Format("Id not accepted, type"));
        oIssueComponent.Details.Text = String.Format("The Resource SHALL contain an id element that has an identical value to the [id] in the URL. The id in the resource was: '{0}' and the [id] in the URL was: '{1}'", BlazeServiceRequest.Resource.Id, BlazeServiceRequest.ResourceId);
        oIssueComponent.Diagnostics = oIssueComponent.Details.Text;
        var oOperationOutcome = new OperationOutcome();
        oOperationOutcome.Issue = new List<OperationOutcome.IssueComponent>() { oIssueComponent };
        oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome = new Validation.ResourceValidationOperationOutcome();
        oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome.FhirOperationOutcome = oOperationOutcome;
        oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        return oBlazeServiceOperationOutcome;
      }
      

      Interfaces.IResourceValidation Validation = Blaze.Engine.Validation.ResourceValidationFactory.GetValidationInstance(CurrentResourceType);
      IResourceValidationOperationOutcome oResourceValidationOperationOutcome = Validation.Validate(BlazeServiceRequest.Resource);
      if (oResourceValidationOperationOutcome.HasError)
      {
        oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome = oResourceValidationOperationOutcome;
        return oBlazeServiceOperationOutcome;
      }

      //Create Resource's Meta element if not found and update its last updated property to now
      if (BlazeServiceRequest.Resource.Meta == null)
        BlazeServiceRequest.Resource.Meta = new Meta();
      BlazeServiceRequest.Resource.Meta.LastUpdated = DateTimeOffset.Now;

      //Check db for existence of this Resource 
      IDatabaseOperationOutcome DatabaseOperationOutcomeGet = _ResourceRepository.GetResourceByFhirID(BlazeServiceRequest.ResourceId);
      if (DatabaseOperationOutcomeGet.ReturnedResource != null)
      {
        //The resource has been found so update its version number based on the older resource              
        BlazeServiceRequest.Resource.Meta.VersionId = Support.ResourceVersionNumber.Increment(DatabaseOperationOutcomeGet.ReturnedResource.Version);
        IDatabaseOperationOutcome DatabaseOperationOutcomeUpdate = _ResourceRepository.UpdateResource(BlazeServiceRequest.Resource.Meta.VersionId, BlazeServiceRequest.Resource, BlazeServiceRequest.FhirRequestUri);
        oBlazeServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Update;
        oBlazeServiceOperationOutcome.FhirResourceId = BlazeServiceRequest.ResourceId;
        oBlazeServiceOperationOutcome.LastModified = DatabaseOperationOutcomeUpdate.ReturnedResource.Received;
        oBlazeServiceOperationOutcome.ResourceVersionNumber = DatabaseOperationOutcomeUpdate.ReturnedResource.Version;
        oBlazeServiceOperationOutcome.DatabaseOperationOutcome = DatabaseOperationOutcomeUpdate;
      }
      else
      {
        //This is a new resource so update its version number as 1
        BlazeServiceRequest.Resource.Meta.VersionId = Support.ResourceVersionNumber.FirstVersion();
        IDatabaseOperationOutcome DatabaseOperationOutcomeAdd = _ResourceRepository.AddResource(BlazeServiceRequest.Resource, BlazeServiceRequest.FhirRequestUri);
        oBlazeServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Create;
        oBlazeServiceOperationOutcome.FhirResourceId = BlazeServiceRequest.ResourceId;
        oBlazeServiceOperationOutcome.LastModified = DatabaseOperationOutcomeAdd.ReturnedResource.Received;
        oBlazeServiceOperationOutcome.ResourceVersionNumber = DatabaseOperationOutcomeAdd.ReturnedResource.Version;
        oBlazeServiceOperationOutcome.DatabaseOperationOutcome = DatabaseOperationOutcomeAdd;       
      }
      return oBlazeServiceOperationOutcome;
    }

    //Delete
    // DELETE: URL/FhirApi/Patient/5
    public virtual IServiceOperationOutcome Delete(string FhirResourceId)
    {
      IServiceOperationOutcome oBlazeServiceOperationOutcome = Common.CommonFactory.GetBlazeServiceOperationOutcome();
      oBlazeServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Delete;
      oBlazeServiceOperationOutcome.FhirResourceId = FhirResourceId;
      oBlazeServiceOperationOutcome.ResourceVersionNumber = null;
      IDatabaseOperationOutcome DatabaseOperationOutcome = _ResourceRepository.GetResourceByFhirID(FhirResourceId);
      if (DatabaseOperationOutcome.ReturnedResource != null)
      {
        //Resource exists so..
        if (!DatabaseOperationOutcome.ReturnedResource.IsDeleted)
        {
          string NewResourceVersionNumber = Support.ResourceVersionNumber.Increment(DatabaseOperationOutcome.ReturnedResource.Version);
          _ResourceRepository.UpdateResouceAsDeleted(FhirResourceId, NewResourceVersionNumber);
          oBlazeServiceOperationOutcome.ResourceVersionNumber = NewResourceVersionNumber;
        }
        else
        {
          oBlazeServiceOperationOutcome.ResourceVersionNumber = DatabaseOperationOutcome.ReturnedResource.Version;
        }
      }
      return oBlazeServiceOperationOutcome;
    }

  }
}

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

    protected FHIRDefinedType _CurrentResourceType;

    public FHIRDefinedType CurrentResourceType
    {
      get
      {
        return _CurrentResourceType;
      }
    }

    public FHIRDefinedType SetCurrentResourceType
    {
      set
      {
        _CurrentResourceType = value;
      }
    }

    //GET Search
    // GET: URL//FhirApi/Patient?family=Smith&given=John
    public virtual IBlazeServiceOperationOutcome Get(IBlazeServiceRequest BlazeServiceRequest)
    {      
      var oBlazeServiceOperationOutcome = new Blaze.Engine.Response.BlazeServiceOperationOutcome();
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
    public virtual IBlazeServiceOperationOutcome Get(string FhirId, string FhirVId)
    {
      var oBlazeServiceOperationOutcome = new Blaze.Engine.Response.BlazeServiceOperationOutcome();
      oBlazeServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;
      oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _ResourceRepository.GetResourceByFhirIDAndVersionNumber(FhirId, FhirVId);
      return oBlazeServiceOperationOutcome;
    }

    // GET by FhirId
    // GET URL/FhirApi/Patient/5    
    public virtual IBlazeServiceOperationOutcome Get(string FhirId)
    {
      var oBlazeServiceOperationOutcome = new Blaze.Engine.Response.BlazeServiceOperationOutcome();
      oBlazeServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;
      oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _ResourceRepository.GetResourceByFhirID(FhirId, true);
      return oBlazeServiceOperationOutcome;
    }

    // Add
    // POST: URL/FhirApi/Patient
    public virtual IBlazeServiceOperationOutcome Post(IBlazeServiceRequest BlazeServiceRequest)
    {
      var oBlazeServiceOperationOutcome = new Blaze.Engine.Response.BlazeServiceOperationOutcome();
      oBlazeServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Create;

      //Validation of resource        
      Interfaces.IResourceValidation Validation = Blaze.Engine.Validation.ResourceValidationFactory.GetValidationInstance(CurrentResourceType);
      IResourceValidationOperationOutcome oResourceValidationOperationOutcome = Validation.Validate(BlazeServiceRequest.Resource);
      if (oResourceValidationOperationOutcome.HasError)
      {
        oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome = oResourceValidationOperationOutcome;
        return oBlazeServiceOperationOutcome;
      }

      BlazeServiceRequest.Resource.Id = Guid.NewGuid().ToString();
      if (BlazeServiceRequest.Resource.Meta == null)
        BlazeServiceRequest.Resource.Meta = new Meta();
      string ResourceVersionNumber = "1";
      BlazeServiceRequest.Resource.Meta.VersionId = ResourceVersionNumber;
      BlazeServiceRequest.Resource.Meta.LastUpdated = DateTimeOffset.Now;
      oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _ResourceRepository.AddResource(BlazeServiceRequest.Resource, BlazeServiceRequest.FhirRequestUri);
      oBlazeServiceOperationOutcome.FhirResourceId = oBlazeServiceOperationOutcome.DatabaseOperationOutcome.ResourceMatchingSearch.FhirId;
      oBlazeServiceOperationOutcome.LastModified = oBlazeServiceOperationOutcome.DatabaseOperationOutcome.ResourceMatchingSearch.Received;
      oBlazeServiceOperationOutcome.ResourceVersionNumber = ResourceVersionNumber;
      return oBlazeServiceOperationOutcome;
    }

    //Update
    // PUT: URL/FhirApi/Patient/5
    public virtual IBlazeServiceOperationOutcome Put(IBlazeServiceRequest BlazeServiceRequest)
    {
      var oBlazeServiceOperationOutcome = new Blaze.Engine.Response.BlazeServiceOperationOutcome();
      oBlazeServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Update;
      //var FhirPatientResource = BlazeServiceRequest.Resource as Patient;
      if (String.IsNullOrWhiteSpace(BlazeServiceRequest.Resource.Id) || BlazeServiceRequest.Resource.Id != BlazeServiceRequest.ResourceId)
      {
        var oIssueComponent = new OperationOutcome.IssueComponent();
        oIssueComponent.Severity = OperationOutcome.IssueSeverity.Error;
        oIssueComponent.Code = OperationOutcome.IssueType.Required;
        oIssueComponent.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_INVALID_ID", String.Format("Id not accepted, type"));
        oIssueComponent.Details.Text = String.Format("The {0} resource id value in the resource must be provided and must match the id given in the URL for all PUT requests.\n The id in the resource was: '{1}' and the id in the URL was: '{2}'", CurrentResourceType.ToString(), BlazeServiceRequest.Resource.Id, BlazeServiceRequest.ResourceId);
        oIssueComponent.Diagnostics = oIssueComponent.Details.Text;
        var oOperationOutcome = new OperationOutcome();
        oOperationOutcome.Issue = new List<OperationOutcome.IssueComponent>() { oIssueComponent };
        oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome = new Validation.ResourceValidationOperationOutcome();
        oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome.FhirOperationOutcome = oOperationOutcome;
        oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        return oBlazeServiceOperationOutcome;
      }

      IDatabaseOperationOutcome DatabaseOperationOutcomeGet = _ResourceRepository.GetResourceByFhirID(BlazeServiceRequest.ResourceId);
      if (DatabaseOperationOutcomeGet.ResourceMatchingSearch != null)
      {
        //The resource has been found so update it and return 200 OK        
        if (BlazeServiceRequest.Resource.Meta == null)
          BlazeServiceRequest.Resource.Meta = new Meta();
        string NewResourceVersionNumber = Support.ResourceVersionNumber.Increment(DatabaseOperationOutcomeGet.ResourceMatchingSearch.Version);
        BlazeServiceRequest.Resource.Meta.VersionId = NewResourceVersionNumber;
        BlazeServiceRequest.Resource.Meta.LastUpdated = DateTimeOffset.Now;

        //Validation of resource        
        Interfaces.IResourceValidation Validation = Blaze.Engine.Validation.ResourceValidationFactory.GetValidationInstance(CurrentResourceType);
        IResourceValidationOperationOutcome oResourceValidationOperationOutcome = Validation.Validate(BlazeServiceRequest.Resource);
        if (oResourceValidationOperationOutcome.HasError)
        {
          oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome = oResourceValidationOperationOutcome;
          return oBlazeServiceOperationOutcome;
        }
        IDatabaseOperationOutcome DatabaseOperationOutcomeUpdate = _ResourceRepository.UpdateResource(NewResourceVersionNumber, BlazeServiceRequest.Resource, BlazeServiceRequest.FhirRequestUri);
        oBlazeServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Update;
        oBlazeServiceOperationOutcome.FhirResourceId = BlazeServiceRequest.ResourceId;
        oBlazeServiceOperationOutcome.LastModified = DatabaseOperationOutcomeUpdate.ResourceMatchingSearch.Received;
        oBlazeServiceOperationOutcome.ResourceVersionNumber = DatabaseOperationOutcomeUpdate.ResourceMatchingSearch.Version;
        oBlazeServiceOperationOutcome.DatabaseOperationOutcome = DatabaseOperationOutcomeUpdate;
        return oBlazeServiceOperationOutcome;
      }
      else
      {
        //The resource is not found in the database so add it here and return 201 Created status code
        return this.Post(BlazeServiceRequest);
      }
    }

    //Delete
    // DELETE: URL/FhirApi/Patient/5
    public virtual IBlazeServiceOperationOutcome Delete(string FhirResourceId)
    {
      var oBlazeServiceOperationOutcome = new Blaze.Engine.Response.BlazeServiceOperationOutcome();
      oBlazeServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Delete;
      oBlazeServiceOperationOutcome.FhirResourceId = FhirResourceId;
      oBlazeServiceOperationOutcome.ResourceVersionNumber = null;
      IDatabaseOperationOutcome DatabaseOperationOutcome = _ResourceRepository.GetResourceByFhirID(FhirResourceId);
      if (DatabaseOperationOutcome.ResourceMatchingSearch != null)
      {
        //Resource exists so..
        if (!DatabaseOperationOutcome.ResourceMatchingSearch.IsDeleted)
        {
          string NewResourceVersionNumber = Support.ResourceVersionNumber.Increment(DatabaseOperationOutcome.ResourceMatchingSearch.Version);
          _ResourceRepository.UpdateResouceAsDeleted(FhirResourceId, NewResourceVersionNumber);
          oBlazeServiceOperationOutcome.ResourceVersionNumber = NewResourceVersionNumber;
        }
        else
        {
          oBlazeServiceOperationOutcome.ResourceVersionNumber = DatabaseOperationOutcome.ResourceMatchingSearch.Version;
        }
      }
      return oBlazeServiceOperationOutcome;
    }

  }
}

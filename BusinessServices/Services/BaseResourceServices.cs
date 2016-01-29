using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Hl7.Fhir.Model;
using Blaze.Engine.CustomException;
using System.Web.UI;
using System.IO;
using Dip.Interfaces.Services;
using Dip.Interfaces;
using Blaze.Engine.Response;


namespace Blaze.Engine.Services
{
  public abstract class BaseResourceServices : IBaseResourceServices
  {
    protected readonly IUnitOfWork _UnitOfWork;

     //Constructor for dependency injection
    public BaseResourceServices(IUnitOfWork IUnitOfWork)
    {
      _UnitOfWork = IUnitOfWork;
    }

    // Get By id
    // GET URL/FhirApi/Patient/5    
    public IBlazeServiceOperationOutcome Get(string FhirResourceId)
    {
      var oBlazeServiceOperationOutcome = new Blaze.Engine.Response.BlazeServiceOperationOutcome();
      oBlazeServiceOperationOutcome.OperationType = BusinessEntities.DtoEnums.CrudOperationType.Read;
      oBlazeServiceOperationOutcome.FhirResourceId = FhirResourceId;
      oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _UnitOfWork.PatientRepository.GetCurrentResource(FhirResourceId);
      oBlazeServiceOperationOutcome.DatabaseOperationOutcome.SingleResourceRead = true;
      if (oBlazeServiceOperationOutcome.DatabaseOperationOutcome.ResourceMatchingSearch == null)
      {
        if (_UnitOfWork.PatientRepository.IsCurrentResourceDeleted(FhirResourceId))
        {
          oBlazeServiceOperationOutcome.DatabaseOperationOutcome.RecourceFoundDeleted = true;
          oBlazeServiceOperationOutcome.DatabaseOperationOutcome.DeletedResourceVersionNumber = _UnitOfWork.PatientRepository.LastDeletedResourceVersion(FhirResourceId);
        }
        else
        {
          oBlazeServiceOperationOutcome.DatabaseOperationOutcome.RecourceFoundDeleted = false;
        }
      }
      return oBlazeServiceOperationOutcome;
    }

    //Search
    // GET: URL//FhirApi/Patient&family=Smith&given=John
    public IBlazeServiceOperationOutcome Get(Uri Uri, Hl7.Fhir.Rest.SearchParams searchParameters)
    {
      //List<string> BaseResourceSearchParameters = new List<string>() { "_id", "_lastUpdated", "_tag", "_profile", "_security", "_text", "_content", "_list", "_query" };

      IBlazeServiceOperationOutcome oBlazeServiceOperationOutcome = new Blaze.Engine.Response.BlazeServiceOperationOutcome();
      oBlazeServiceOperationOutcome.OperationType = BusinessEntities.DtoEnums.CrudOperationType.Read;
      //##issues## Do we need to set Uri here or from the caller, does this method need the Uri?
      oBlazeServiceOperationOutcome.RequestUri = Uri;

      //Validate the search Parameters passed in are implemented for this Resource Type      
      Search.SearchTermValidationOperationOutcome oISearchTermValidationOperationOutcome = Search.SearchUriValidator.Validate(ResourceType.Patient, searchParameters);
      if (oISearchTermValidationOperationOutcome.FhirOperationOutcome != null)
      {
        oBlazeServiceOperationOutcome.SearchValidationOperationOutcome = oISearchTermValidationOperationOutcome;
        return oBlazeServiceOperationOutcome;
      }

      //Retrieve the search plan for this Resource Type
      Interfaces.ISearchPlan SearchPlan = Search.SearchPlanNegotiator.GetSearchPlan(ResourceType.Patient, _UnitOfWork);

      //Performed the search with the search plan
      oBlazeServiceOperationOutcome = SearchPlan.Search(oISearchTermValidationOperationOutcome.SearchTerms, oBlazeServiceOperationOutcome);

      return oBlazeServiceOperationOutcome;
    }

    // Add
    // POST: URL/FhirApi/Patient
    public IBlazeServiceOperationOutcome Post(Resource FhirResource)
    {
      var oBlazeServiceOperationOutcome = new Blaze.Engine.Response.BlazeServiceOperationOutcome();
      oBlazeServiceOperationOutcome.OperationType = BusinessEntities.DtoEnums.CrudOperationType.Create;
      var Validation = new Validation.PatientResourceValidation();
      IResourceValidationOperationOutcome oResourceValidationOperationOutcome = Validation.Validate(FhirResource);
      if (oResourceValidationOperationOutcome.HasError)
      {
        oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome = oResourceValidationOperationOutcome;
        return oBlazeServiceOperationOutcome;
      }

      var FhirPatientResource = FhirResource as Patient;

      //Update the resource XML before committing to storage.
      FhirPatientResource.Id = Guid.NewGuid().ToString();
      if (FhirPatientResource.Meta == null)
        FhirPatientResource.Meta = new Meta();
      int ResourceVersionNumber = 1;
      FhirPatientResource.Meta.VersionId = ResourceVersionNumber.ToString();
      FhirPatientResource.Meta.LastUpdated = DateTimeOffset.Now;
      oBlazeServiceOperationOutcome.FhirResourceId = _UnitOfWork.PatientRepository.AddResource(FhirPatientResource);
      oBlazeServiceOperationOutcome.LastModified = FhirPatientResource.Meta.LastUpdated;
      oBlazeServiceOperationOutcome.ResourceVersionNumber = ResourceVersionNumber;
      return oBlazeServiceOperationOutcome;
    }

    //Update
    // PUT: URL/FhirApi/Patient/5
    public IBlazeServiceOperationOutcome Put(string FhirResourceId, Resource FhirResource)
    {
      var oBlazeServiceOperationOutcome = new Blaze.Engine.Response.BlazeServiceOperationOutcome();
      oBlazeServiceOperationOutcome.OperationType = BusinessEntities.DtoEnums.CrudOperationType.Update;
      var FhirPatientResource = FhirResource as Patient;
      if (FhirPatientResource.Id == null || FhirPatientResource.Id == string.Empty || FhirPatientResource.Id != FhirResourceId)
      {
        var oIssueComponent = new OperationOutcome.IssueComponent();
        oIssueComponent.Severity = OperationOutcome.IssueSeverity.Error;
        oIssueComponent.Code = OperationOutcome.IssueType.Required;
        oIssueComponent.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_INVALID_ID", String.Format("Id not accepted, type"));
        oIssueComponent.Details.Text = String.Format("The Patient resource id value in the resource must be provided and must match the id given in the URL for all PUT requests.\n The id in the resource was: '{0}' and the id in the URL was: '{1}'", FhirPatientResource.Id, FhirResourceId);
        oIssueComponent.Diagnostics = oIssueComponent.Details.Text;
        var oOperationOutcome = new OperationOutcome();
        oOperationOutcome.Issue = new List<OperationOutcome.IssueComponent>() { oIssueComponent };
        oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome = new Validation.ResourceValidationOperationOutcome();
        oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome.FhieOperationOutcome = oOperationOutcome;
        oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        return oBlazeServiceOperationOutcome;
      }

      if (_UnitOfWork.PatientRepository.ResourceExists(FhirResourceId))
      {
        //The resource has been found so update it and return 200 OK        
        if (FhirPatientResource.Meta == null)
          FhirPatientResource.Meta = new Meta();
        int NewResourceVersionNumber = _UnitOfWork.PatientRepository.GetResourceCurrentVersion(FhirResourceId) + 1;
        FhirPatientResource.Meta.VersionId = NewResourceVersionNumber.ToString();
        FhirPatientResource.Meta.LastUpdated = DateTimeOffset.Now;

        //Validation of resource        
        var Validation = new Validation.PatientResourceValidation();
        IResourceValidationOperationOutcome oResourceValidationOperationOutcome = Validation.Validate(FhirResource);
        if (oResourceValidationOperationOutcome.HasError)
        {
          oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome = oResourceValidationOperationOutcome;
          return oBlazeServiceOperationOutcome;
        }
        _UnitOfWork.PatientRepository.UpdateResource(NewResourceVersionNumber, FhirPatientResource);
        oBlazeServiceOperationOutcome.OperationType = BusinessEntities.DtoEnums.CrudOperationType.Update;
        oBlazeServiceOperationOutcome.FhirResourceId = FhirResourceId;
        oBlazeServiceOperationOutcome.LastModified = FhirPatientResource.Meta.LastUpdated;
        oBlazeServiceOperationOutcome.ResourceVersionNumber = NewResourceVersionNumber;
        return oBlazeServiceOperationOutcome;
      }
      else
      {
        //The resource is not found in the database so add it here and return 201 Created status code
        return this.Post(FhirResource);
      }
    }

    //Delete
    // DELETE: URL/FhirApi/Patient/5
    public IBlazeServiceOperationOutcome Delete(string FhirResourceId)
    {
      var oBlazeServiceOperationOutcome = new Blaze.Engine.Response.BlazeServiceOperationOutcome();
      oBlazeServiceOperationOutcome.OperationType = BusinessEntities.DtoEnums.CrudOperationType.Delete;
      oBlazeServiceOperationOutcome.FhirResourceId = FhirResourceId;
      oBlazeServiceOperationOutcome.ResourceVersionNumber = 0;
      if (_UnitOfWork.PatientRepository.ResourceExists(FhirResourceId))
      {
        if (!_UnitOfWork.PatientRepository.IsCurrentResourceDeleted(FhirResourceId))
        {
          _UnitOfWork.PatientRepository.UpdateResouceAsDeleted(FhirResourceId);
        }
        oBlazeServiceOperationOutcome.ResourceVersionNumber = _UnitOfWork.PatientRepository.LastDeletedResourceVersion(FhirResourceId);
      }
      return oBlazeServiceOperationOutcome;
    }
  }
}

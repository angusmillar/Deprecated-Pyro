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
using Dip.Interfaces;
using Dip.Interfaces.Services;
using Dip.Interfaces.Repositories;
using Blaze.Engine.Response;
using BusinessEntities;


namespace Blaze.Engine.Services
{
  /// <summary>
  /// This Class is here to handle any unique methods required for Patient resource beyond the basic REST operations.
  /// These might be FHIR operations on the resource such as '$expand' in the ValueSet Resource.
  /// </summary>
  public class PatientResourceServices : BaseResourceServices, IPatientResourceServices, IBaseResourceServices
  {
    public override DtoEnums.SupportedFhirResource CurrentResourceType
    {
      get
      {
        return DtoEnums.SupportedFhirResource.Patient;
      }
    }

    // Add
    // POST: URL/FhirApi/Patient
    public override IBlazeServiceOperationOutcome Post(Resource FhirResource)
    {
      var oBlazeServiceOperationOutcome = new Blaze.Engine.Response.BlazeServiceOperationOutcome();
      oBlazeServiceOperationOutcome.OperationType = BusinessEntities.DtoEnums.CrudOperationType.Create;

      //Validation of resource        
      Interfaces.IResourceValidation Validation = Blaze.Engine.Validation.ResourceValidationFactory.GetValidationInstance(CurrentResourceType);
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
    public override IBlazeServiceOperationOutcome Put(string FhirResourceId, Resource FhirResource)
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
        oIssueComponent.Details.Text = String.Format("The {0} resource id value in the resource must be provided and must match the id given in the URL for all PUT requests.\n The id in the resource was: '{1}' and the id in the URL was: '{2}'", CurrentResourceType.ToString(), FhirPatientResource.Id, FhirResourceId);
        oIssueComponent.Diagnostics = oIssueComponent.Details.Text;
        var oOperationOutcome = new OperationOutcome();
        oOperationOutcome.Issue = new List<OperationOutcome.IssueComponent>() { oIssueComponent };
        oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome = new Validation.ResourceValidationOperationOutcome();
        oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome.FhieOperationOutcome = oOperationOutcome;
        oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        return oBlazeServiceOperationOutcome;
      }

      if (_UnitOfWork.ResourceRepository.ResourceExists(FhirResourceId))
      {
        //Check that the Id given is for the same resource type attempting to be updated.
        DtoEnums.SupportedFhirResource ExsistingResourceTypeForFhirID = _UnitOfWork.ResourceRepository.GetSupportedResourceTypeForFhirResourceId(FhirResourceId);
        if (ExsistingResourceTypeForFhirID == CurrentResourceType)
        {
          //The resource has been found so update it and return 200 OK        
          if (FhirPatientResource.Meta == null)
            FhirPatientResource.Meta = new Meta();
          int NewResourceVersionNumber = _UnitOfWork.ResourceRepository.GetResourceCurrentVersion(FhirResourceId) + 1;
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
          var oIssueComponent = new OperationOutcome.IssueComponent();
          oIssueComponent.Severity = OperationOutcome.IssueSeverity.Fatal;
          oIssueComponent.Code = OperationOutcome.IssueType.Processing;
          oIssueComponent.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_INVALID_ID", String.Format("Id not accepted, type"));
          oIssueComponent.Details.Text = String.Format("The Resource id provided already exists on this server for another resource type. Server has id: '{0}' associated to a Resource of type: '{1}'. You are attempting to update a '{2}' Resource Type with the same Id.", FhirResourceId, ExsistingResourceTypeForFhirID.ToString(), CurrentResourceType.ToString());
          oIssueComponent.Diagnostics = oIssueComponent.Details.Text;
          var oOperationOutcome = new OperationOutcome();
          oOperationOutcome.Issue = new List<OperationOutcome.IssueComponent>() { oIssueComponent };
          oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome = new Validation.ResourceValidationOperationOutcome();
          oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome.FhieOperationOutcome = oOperationOutcome;
          oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
          return oBlazeServiceOperationOutcome;
        }
      }
      else
      {
        //The resource is not found in the database so add it here and return 201 Created status code
        return this.Post(FhirResource);
      }
    }

    //Delete
    //DELETE: URL/FhirApi/Patient/5
    public override IBlazeServiceOperationOutcome Delete(string FhirResourceId)
    {
      var oBlazeServiceOperationOutcome = new Blaze.Engine.Response.BlazeServiceOperationOutcome();
      oBlazeServiceOperationOutcome.OperationType = BusinessEntities.DtoEnums.CrudOperationType.Delete;
      oBlazeServiceOperationOutcome.FhirResourceId = FhirResourceId;
      oBlazeServiceOperationOutcome.ResourceVersionNumber = 0;
      if (_UnitOfWork.ResourceRepository.ResourceExists(FhirResourceId))
      {
        if (!_UnitOfWork.ResourceRepository.IsCurrentResourceDeleted(FhirResourceId))
        {
          _UnitOfWork.PatientRepository.UpdateResouceAsDeleted(FhirResourceId);
        }
        oBlazeServiceOperationOutcome.ResourceVersionNumber = _UnitOfWork.ResourceRepository.LastDeletedResourceVersion(FhirResourceId);
      }
      return oBlazeServiceOperationOutcome;
    }

    //Constructor for dependency injection
    public PatientResourceServices(IUnitOfWork IUnitOfWork)
      : base(IUnitOfWork){}

  }
}

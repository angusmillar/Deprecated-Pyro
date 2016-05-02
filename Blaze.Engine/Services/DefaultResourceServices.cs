using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.Common.Interfaces.Services;
using Blaze.Common.Interfaces.Repositories;
using Blaze.Common.Interfaces;
using Hl7.Fhir.Model;
using Blaze.Common.BusinessEntities.Dto;

namespace Blaze.Engine.Services
{
  public class DefaultResourceServices : BaseResourceServices, IDefaultResourceServices, IBaseResourceServices
  {
    private DtoEnums.SupportedFhirResource _CurrentResourceType;
    public override DtoEnums.SupportedFhirResource CurrentResourceType
    {
      get
      {        
        return _CurrentResourceType;
      }     
    }

    public DtoEnums.SupportedFhirResource SetCurrentResourceType
    {
      set
      {
        _CurrentResourceType = value;
      }
    }

    // Add
    // POST: URL/FhirApi/Patient
    public override IBlazeServiceOperationOutcome Post(IBlazeServiceRequest BlazeServiceRequest)
    {
      //var oBlazeServiceOperationOutcome = new Blaze.Engine.Response.BlazeServiceOperationOutcome();
      //oBlazeServiceOperationOutcome.OperationType = DtoEnums.CrudOperationType.Create;

      ////Validation of resource - Need a validator for default resource       
      //Interfaces.IResourceValidation Validation = Blaze.Engine.Validation.ResourceValidationFactory.GetValidationInstance(CurrentResourceType);
      //IResourceValidationOperationOutcome oResourceValidationOperationOutcome = Validation.Validate(FhirResource);
      //if (oResourceValidationOperationOutcome.HasError)
      //{
      //  oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome = oResourceValidationOperationOutcome;
      //  return oBlazeServiceOperationOutcome;
      //}
      
      

      //Update the resource XML before committing to storage.
      //FhirResource.Id = Guid.NewGuid().ToString();
      //if (FhirResource.Meta == null)
      //  FhirResource.Meta = new Meta();
      //int ResourceVersionNumber = 1;
      //FhirResource.Meta.VersionId = ResourceVersionNumber.ToString();
      //FhirResource.Meta.LastUpdated = DateTimeOffset.Now;
      //oBlazeServiceOperationOutcome.FhirResourceId = _UnitOfWork.ResourceRepository.AddResource(_CurrentResourceType, FhirResource);
      //oBlazeServiceOperationOutcome.LastModified = FhirResource.Meta.LastUpdated;
      //oBlazeServiceOperationOutcome.ResourceVersionNumber = ResourceVersionNumber;
      //return oBlazeServiceOperationOutcome;

      throw new NotImplementedException();
    }

    //Update
    // PUT: URL/FhirApi/Patient/5
    public override IBlazeServiceOperationOutcome Put(IBlazeServiceRequest BlazeServiceRequest)
    {
      //var oBlazeServiceOperationOutcome = new Blaze.Engine.Response.BlazeServiceOperationOutcome();
      //oBlazeServiceOperationOutcome.OperationType = DtoEnums.CrudOperationType.Update;

      //if (FhirResource.Id == null || FhirResource.Id == string.Empty || FhirResource.Id != FhirResourceId)
      //{
      //  var oIssueComponent = new OperationOutcome.IssueComponent();
      //  oIssueComponent.Severity = OperationOutcome.IssueSeverity.Error;
      //  oIssueComponent.Code = OperationOutcome.IssueType.Required;
      //  oIssueComponent.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_INVALID_ID", String.Format("Id not accepted, type"));
      //  oIssueComponent.Details.Text = String.Format("The {0} resource id value in the resource must be provided and must match the id given in the URL for all PUT requests.\n The id in the resource was: '{1}' and the id in the URL was: '{2}'", CurrentResourceType.ToString(), FhirResource.Id, FhirResourceId);
      //  oIssueComponent.Diagnostics = oIssueComponent.Details.Text;
      //  var oOperationOutcome = new OperationOutcome();
      //  oOperationOutcome.Issue = new List<OperationOutcome.IssueComponent>() { oIssueComponent };
      //  oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome = new Validation.ResourceValidationOperationOutcome();
      //  oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome.FhirOperationOutcome = oOperationOutcome;
      //  oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
      //  return oBlazeServiceOperationOutcome;
      //}

      //DtoResource oDtoResourceWithNoXml = _UnitOfWork.ResourceRepository.GetCurrentResourceWithOutXml(FhirResourceId);
      //if (oDtoResourceWithNoXml != null)
      //{
      //  //Check that the Id given is for the same resource type attempting to be updated.        
      //  if (oDtoResourceWithNoXml.FhirResourceType == CurrentResourceType)
      //  {
      //    //The resource has been found so update it and return 200 OK        
      //    if (FhirResource.Meta == null)
      //      FhirResource.Meta = new Meta();
      //    int NewResourceVersionNumber = oDtoResourceWithNoXml.Version + 1;
      //    FhirResource.Meta.VersionId = NewResourceVersionNumber.ToString();
      //    FhirResource.Meta.LastUpdated = DateTimeOffset.Now;

      //    ////Validation of resource - Need a basic validation for Resource default       
      //    //Interfaces.IResourceValidation Validation = Blaze.Engine.Validation.ResourceValidationFactory.GetValidationInstance(CurrentResourceType);
      //    //IResourceValidationOperationOutcome oResourceValidationOperationOutcome = Validation.Validate(FhirResource);
      //    //if (oResourceValidationOperationOutcome.HasError)
      //    //{
      //    //  oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome = oResourceValidationOperationOutcome;
      //    //  return oBlazeServiceOperationOutcome;
      //    //}

      //    _UnitOfWork.ResourceRepository.UpdateResource(NewResourceVersionNumber, FhirResource);
      //    oBlazeServiceOperationOutcome.OperationType = DtoEnums.CrudOperationType.Update;
      //    oBlazeServiceOperationOutcome.FhirResourceId = FhirResourceId;
      //    oBlazeServiceOperationOutcome.LastModified = FhirResource.Meta.LastUpdated;
      //    oBlazeServiceOperationOutcome.ResourceVersionNumber = NewResourceVersionNumber;
      //    return oBlazeServiceOperationOutcome;
      //  }
      //  else
      //  {
      //    var oIssueComponent = new OperationOutcome.IssueComponent();
      //    oIssueComponent.Severity = OperationOutcome.IssueSeverity.Fatal;
      //    oIssueComponent.Code = OperationOutcome.IssueType.Processing;
      //    oIssueComponent.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_INVALID_ID", String.Format("Id not accepted, type"));
      //    oIssueComponent.Details.Text = String.Format("The Resource id provided already exists on this server for another resource type. Server has id: '{0}' associated to a Resource of type: '{1}'. You are attempting to update a '{2}' Resource Type with the same Id.", FhirResourceId, oDtoResourceWithNoXml.FhirResourceType.ToString(), CurrentResourceType.ToString());
      //    oIssueComponent.Diagnostics = oIssueComponent.Details.Text;
      //    var oOperationOutcome = new OperationOutcome();
      //    oOperationOutcome.Issue = new List<OperationOutcome.IssueComponent>() { oIssueComponent };
      //    oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome = new Validation.ResourceValidationOperationOutcome();
      //    oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome.FhirOperationOutcome = oOperationOutcome;
      //    oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
      //    return oBlazeServiceOperationOutcome;
      //  }
      //}
      //else
      //{
      //  //The resource is not found in the database so add it here and return 201 Created status code        
      //  return this.Post(FhirResource);
      //}

      throw new NotImplementedException();

    }

    //Delete
    // DELETE: URL/FhirApi/Patient/5
    public override IBlazeServiceOperationOutcome Delete(string FhirResourceId)
    {
      //var oBlazeServiceOperationOutcome = new Blaze.Engine.Response.BlazeServiceOperationOutcome();
      //oBlazeServiceOperationOutcome.OperationType = DtoEnums.CrudOperationType.Delete;
      //oBlazeServiceOperationOutcome.FhirResourceId = FhirResourceId;
      //oBlazeServiceOperationOutcome.ResourceVersionNumber = 0;
      //if (_UnitOfWork.ResourceRepository.ResourceExists(FhirResourceId))
      //{
      //  DtoEnums.SupportedFhirResource ExsistingResourceTypeForFhirID = _UnitOfWork.ResourceRepository.GetSupportedResourceTypeForFhirResourceId(FhirResourceId);
      //  if (ExsistingResourceTypeForFhirID == this.CurrentResourceType)
      //  {
      //    if (!_UnitOfWork.ResourceRepository.IsCurrentResourceDeleted(FhirResourceId))
      //    {
      //      _UnitOfWork.ResourceRepository.UpdateResouceAsDeleted(FhirResourceId);
      //    }
      //    oBlazeServiceOperationOutcome.ResourceVersionNumber = _UnitOfWork.ResourceRepository.LastDeletedResourceVersion(FhirResourceId);
      //  }
      //  else
      //  {
      //    var oIssueComponent = new OperationOutcome.IssueComponent();
      //    oIssueComponent.Severity = OperationOutcome.IssueSeverity.Fatal;
      //    oIssueComponent.Code = OperationOutcome.IssueType.Processing;
      //    oIssueComponent.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_INVALID_ID", String.Format("Id not accepted, type"));
      //    oIssueComponent.Details.Text = String.Format("The Resource id provided already exists on this server for another resource type. Server has id: '{0}' associated to a Resource of type: '{1}'. You are attempting to delete a '{2}' Resource Type with the same Id.", FhirResourceId, ExsistingResourceTypeForFhirID.ToString(), CurrentResourceType.ToString());
      //    oIssueComponent.Diagnostics = oIssueComponent.Details.Text;
      //    var oOperationOutcome = new OperationOutcome();
      //    oOperationOutcome.Issue = new List<OperationOutcome.IssueComponent>() { oIssueComponent };
      //    oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome = new Validation.ResourceValidationOperationOutcome();
      //    oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome.FhirOperationOutcome = oOperationOutcome;
      //    oBlazeServiceOperationOutcome.ResourceValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
      //    return oBlazeServiceOperationOutcome;
      //  }
      //}
      //return oBlazeServiceOperationOutcome;

      throw new NotImplementedException();
    }

    //Constructor for dependency injection
    public DefaultResourceServices(IUnitOfWork IUnitOfWork)
      : base(IUnitOfWork){}

  }
}

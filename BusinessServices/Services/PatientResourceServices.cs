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



namespace Blaze.Engine.Services
{
  public class PatientResourceServices : Dip.Interfaces.IPatientResourceServices, Dip.Interfaces.IResourceServices
  {
    private readonly Dip.Interfaces.IUnitOfWork _UnitOfWork;

    //Constructor for dependency injection
    public PatientResourceServices(Dip.Interfaces.IUnitOfWork IUnitOfWork)
    {
      _UnitOfWork = IUnitOfWork;
    }

    // Get By id
    // GET URL/FhirApi/Patient/5    
    public Dip.Interfaces.IFhirRestResponse Get(string FhirResourceId)
    {      
      try
      {
        Search.SearchResult oSearchResult = new Search.SearchResult();
        oSearchResult.DbSearchResult = _UnitOfWork.PatientRepository.GetCurrentResource(FhirResourceId);
        if (oSearchResult.DbSearchResult.ResourceMatchingSearch != null)
        {
          return new Response.FhirRestResponse(oSearchResult.HttpStatusCode, oSearchResult.ResourceToReturn());
        }
        else
        {
          if (_UnitOfWork.PatientRepository.IsCurrentResourceDeleted(FhirResourceId))
          {
            int Version = _UnitOfWork.PatientRepository.LastDeletedResourceVersion(FhirResourceId);
            return new Response.FhirRestResponse(System.Net.HttpStatusCode.Gone, Version, String.Format("No Patient resource found for Id: {0}, resource previously deleted.", FhirResourceId));
          }
          else
            return new Response.FhirRestResponse(System.Net.HttpStatusCode.Gone, String.Format("No Patient resource found for Id: {0}", FhirResourceId));
        }
      }
      catch (Exception Exec)
      {
        return new Response.FhirRestResponse(System.Net.HttpStatusCode.InternalServerError, Exec.Message);
      }
    }

    //Search
    // GET: URL//FhirApi/Patient&family=Smith&given=John
    public Dip.Interfaces.IFhirRestResponse Get(Uri Uri, Hl7.Fhir.Rest.SearchParams searchParameters)
    {
      //List<string> BaseResourceSearchParameters = new List<string>() { "_id", "_lastUpdated", "_tag", "_profile", "_security", "_text", "_content", "_list", "_query" };
      
      //Validate the search terms passed in are implemented for this Resource Type
      var oSearchTerm = Search.SearchUriValidator.Validate(ResourceType.Patient, searchParameters);

      if (oSearchTerm.HasError)
      {        
        return new Response.FhirRestResponse(oSearchTerm.HttpStatusCode, oSearchTerm.ResourceToReturn());
      }

      //Retrieve the search plan for this Resource Type
      var SearchPlan = Search.SearchPlanNegotiator.GetSearchPlan(ResourceType.Patient, _UnitOfWork);
      
      //Performed the search with the search plan
      var oSearchResults = SearchPlan.Search(oSearchTerm);
      oSearchResults.RequestUri = Uri;

      //ResourceToReturn dynamical returns a OperationOutcome if error detected or the desired if no errors Resource.
      return new Response.FhirRestResponse(oSearchResults.HttpStatusCode, oSearchResults.ResourceToReturn());
              
    }

    // Add
    // POST: URL/FhirApi/Patient
    public Dip.Interfaces.IFhirRestResponse Post(Resource FhirResource)
    {
      var Validation = new Validation.PatientResourceValidation();
      var oValidationResult = Validation.Validate(FhirResource);
      if (oValidationResult.HasError)
      {
        return new Response.FhirRestResponse(oValidationResult.HttpStatusCode, oValidationResult.ResourceToReturn());
      }

      try
      {
        var FhirPatientResource = FhirResource as Patient;
        
        //Update the resource XML before committing to storage.
        FhirPatientResource.Id = Guid.NewGuid().ToString();
        if (FhirPatientResource.Meta == null)
          FhirPatientResource.Meta = new Meta();
        int Version = 1;
        FhirPatientResource.Meta.VersionId = Version.ToString();
        FhirPatientResource.Meta.LastUpdated = DateTimeOffset.Now;
        string FhirResourceId = _UnitOfWork.PatientRepository.AddResource(FhirPatientResource);
        return new Response.FhirRestResponse(System.Net.HttpStatusCode.OK, FhirResourceId, Version, FhirPatientResource.Meta.LastUpdated);
      }
      catch (Exception Exec)
      {
        return new Response.FhirRestResponse(System.Net.HttpStatusCode.InternalServerError, Exec.Message);
      }
    }

    //Update
    // PUT: URL/FhirApi/Patient/5
    public Dip.Interfaces.IFhirRestResponse Put(string FhirResourceId, Resource FhirResource)
    {
      var FhirPatientResource = FhirResource as Patient;
      if (FhirPatientResource.Id == string.Empty || FhirPatientResource.Id != FhirResourceId)
      {
        var oIssueComponent = new OperationOutcome.IssueComponent();
        oIssueComponent.Severity = OperationOutcome.IssueSeverity.Error;
        oIssueComponent.Code = OperationOutcome.IssueType.Required;
        oIssueComponent.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_INVALID_ID", String.Format("Id not accepted, type"));
        oIssueComponent.Details.Text = String.Format("The Patient resource id value in the resource must be provided and must match the id given in the URL for all PUT requests.\n The id in the resource was: '{0}' and the id in the URL was: '{1}'", FhirPatientResource.Id, FhirResourceId);
        oIssueComponent.Diagnostics = oIssueComponent.Details.Text;
        var oOperationOutcome = new OperationOutcome();
        oOperationOutcome.Issue = new List<OperationOutcome.IssueComponent>() { oIssueComponent };
        throw new BlazeException(System.Net.HttpStatusCode.BadRequest, oOperationOutcome, oIssueComponent.Details.Text);             
      }

      if (_UnitOfWork.PatientRepository.ResourceExists(FhirResourceId))
      {
        //The resource has been found so update it and return 200 OK
        if (FhirPatientResource.Meta == null)
          FhirPatientResource.Meta = new Meta();
        int CurrentResourceVersion = _UnitOfWork.PatientRepository.GetResourceCurrentVersion(FhirResourceId) + 1;
        FhirPatientResource.Meta.VersionId = CurrentResourceVersion.ToString();
        FhirPatientResource.Meta.LastUpdated = DateTimeOffset.Now;
        _UnitOfWork.PatientRepository.UpdateResource(CurrentResourceVersion, FhirPatientResource);
        Response.FhirRestResponse Response = new Engine.Response.FhirRestResponse(System.Net.HttpStatusCode.OK, FhirResourceId, CurrentResourceVersion, FhirPatientResource.Meta.LastUpdated);
        return Response;
      }
      else
      {
        //The resource is not found in the database so add it here and return 201 Created status code
        Dip.Interfaces.IFhirRestResponse Response = this.Post(FhirResource);
        if (Response.StatusCode == System.Net.HttpStatusCode.OK)
        {
          Response.Resource = FhirResource;
          Response.StatusCode = System.Net.HttpStatusCode.Created;
        }
        return Response;
      }
    }

    //Delete
    // DELETE: URL/FhirApi/Patient/5
    public Dip.Interfaces.IFhirRestResponse Delete(string FhirResourceId)
    {
      if (_UnitOfWork.PatientRepository.ResourceExists(FhirResourceId))
      {
        if (!_UnitOfWork.PatientRepository.IsCurrentResourceDeleted(FhirResourceId))
          _UnitOfWork.PatientRepository.UpdateResouceAsDeleted(FhirResourceId);
      }
      return new Response.FhirRestResponse() { StatusCode = System.Net.HttpStatusCode.NoContent, FhirResourceId = FhirResourceId };
    }

  }
}

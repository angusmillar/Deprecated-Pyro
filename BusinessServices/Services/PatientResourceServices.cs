using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Hl7.Fhir.Model;
using DataModel;
using Blaze.Engine.CustomException;

namespace Blaze.Engine.Services
{
  public class PatientResourceServices : Interfaces.IPatientResourceServices, Interfaces.IResourceServices
  {
    private readonly UnitOfWork _UnitOfWork;

    public PatientResourceServices()
    {
      _UnitOfWork = new UnitOfWork();
    }

    public Response.FhirRestResponse Get(string FhirResourceId)
    {
      try
      {
        Patient FhirPatient = _UnitOfWork.PatientRepository.GetCurrentResource(FhirResourceId);
        if (FhirPatient != null)
        {
          return new Response.FhirRestResponse(System.Net.HttpStatusCode.OK, FhirPatient);
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

    public Response.FhirRestResponse Get(Uri uri, Hl7.Fhir.Rest.SearchParams searchParameters)
    {
      List<string> BaseResourceSearchParameters = new List<string>() { "_id", "_lastUpdated", "_tag", "_profile", "_security", "_text", "_content", "_list", "_query" };
      
      //Validate the search terms passed in a implemented for this Resource Type
      var oSearchTerm = Search.SearchUriValidator.Validate(ResourceType.Patient, searchParameters);

      //Retrieve and create the search plan for this Resource Type
      var SearchPlan = Search.SearchPlanNegotiator.GetSearchPlan(ResourceType.Patient, _UnitOfWork);
      
      //Performed the search with the search plan
      var oSearchResults = SearchPlan.Search(oSearchTerm);
      
      if (!oSearchResults.HasError)
      {
        return new Response.FhirRestResponse(System.Net.HttpStatusCode.OK, oSearchResults.FhirBundle);
      }
      else
      {
        //##Issues# need more here, should return a OperationOutcome resource 
        var Sb = new StringBuilder();
        oSearchResults.ErrorMessageList.ForEach(x => Sb.Append(x));
        return new Response.FhirRestResponse(System.Net.HttpStatusCode.Forbidden, Sb.ToString());
      }      
      
    }

    public Response.FhirRestResponse Post(Resource FhirResource)
    {
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

    public Response.FhirRestResponse Put(string FhirResourceId, Resource FhirResource)
    {
      var FhirPatientResource = FhirResource as Patient;
      if (FhirPatientResource.Id == string.Empty || FhirPatientResource.Id != FhirResourceId)
      {
        throw new BlazeException(System.Net.HttpStatusCode.BadRequest,
          String.Format("The Patient resource id value in the resource must be provided and must match the id given in the URL for all PUT requests.\n The id in the resource was: '{0}' and the id in the URL was: '{1}'", FhirPatientResource.Id, FhirResourceId));
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
        Response.FhirRestResponse Response = this.Post(FhirResource);
        if (Response.StatusCode == System.Net.HttpStatusCode.OK)
        {
          Response.Resource = FhirResource;
          Response.StatusCode = System.Net.HttpStatusCode.Created;
        }
        return Response;
      }

    }

    public Response.FhirRestResponse Delete(string FhirResourceId)
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

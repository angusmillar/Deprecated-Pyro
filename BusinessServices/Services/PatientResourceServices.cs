using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Fhir = Hl7.Fhir;
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
        Fhir.Model.Patient FhirPatient = _UnitOfWork.PatientRepository.GetCurrentResource(FhirResourceId);
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

    public Response.FhirRestResponse Get(Uri uri, Fhir.Rest.SearchParams searchParameters)
    {
      //##Issues# this implementation is very basic as a proof of concept. 
      //Need to implement a proper SQL search plan with dynamic search queries 
      try
      {        
        var oSerachDic = searchParameters.Parameters.ToDictionary(x => x.Item1, x => x.Item2);
        

        var test2 = searchParameters.ToParameters();
        var SearchList = Fhir.Model.ModelInfo.SearchParameters;


        List<string> BaseResourceSearchParameters = new List<string>() { "_id", "_lastUpdated", "_tag", "_profile", "_security", "_text", "_content", "_list", "_query" };

          


        var SearchDefinitionList = new List<Fhir.Model.ModelInfo.SearchParamDefinition>();
        
        foreach(var item in searchParameters.Parameters)
        {
          var SearchDefinition = SearchList.SingleOrDefault(x => x.Name == item.Item1 && x.Resource == "Patient");
          if (SearchDefinition != null)
            SearchDefinitionList.Add(SearchDefinition);
          else
          {
            if (BaseResourceSearchParameters.Contains(item.Item1))
            {

            }
            else
            {
              //Check any custom search terms and if not found then
              //return error as search terms is not a FHIR search term
            }

          }
        }


        Fhir.Model.Bundle oBundle = null;

        if (oSerachDic.ContainsKey("family"))
        {
          oBundle = _UnitOfWork.PatientRepository.SearchByFamily(oSerachDic["family"]);          
        }
        else if (oSerachDic.ContainsKey("_id"))
        {
          //Need this to return a list possibly?
         // PatientList = _UnitOfWork.PatientRepository.GetCurrentResource(oSerachDic["_id"]);
        }


        if (oBundle != null)
        {          
          return new Response.FhirRestResponse(System.Net.HttpStatusCode.OK, oBundle);
        }
        else
        {
          //##Issues# need more here, should return a OperationOutcome resource 
          return new Response.FhirRestResponse(System.Net.HttpStatusCode.Forbidden, "No supported search terms found");
        }
      }
      catch (Exception Exec)
      {
        return new Response.FhirRestResponse(System.Net.HttpStatusCode.InternalServerError, Exec.Message);
      }
    }

    public Response.FhirRestResponse Post(Fhir.Model.Resource FhirResource)
    {
      try
      {
        var FhirPatientResource = FhirResource as Fhir.Model.Patient;

        //Update the resource XML before committing to storage.
        FhirPatientResource.Id = Guid.NewGuid().ToString();
        if (FhirPatientResource.Meta == null)
          FhirPatientResource.Meta = new Fhir.Model.Meta();
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

    public Response.FhirRestResponse Put(string FhirResourceId, Fhir.Model.Resource FhirResource)
    {
      var FhirPatientResource = FhirResource as Fhir.Model.Patient;
      if (FhirPatientResource.Id == string.Empty || FhirPatientResource.Id != FhirResourceId)
      {
        throw new BlazeException(System.Net.HttpStatusCode.BadRequest,
          String.Format("The Patient resource id value in the resource must be provided and must match the id given in the URL for all PUT requests.\n The id in the resource was: '{0}' and the id in the URL was: '{1}'", FhirPatientResource.Id, FhirResourceId));
      }


      if (_UnitOfWork.PatientRepository.ResourceExists(FhirResourceId))
      {
        //The resource has been found so update it and return 200 OK
        if (FhirPatientResource.Meta == null)
          FhirPatientResource.Meta = new Fhir.Model.Meta();
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

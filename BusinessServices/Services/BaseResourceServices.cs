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
  public abstract class BaseResourceServices : IBaseResourceServices
  {
    protected readonly IUnitOfWork _UnitOfWork;

    public abstract DtoEnums.SupportedFhirResource CurrentResourceType { get; }

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
      
      oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _UnitOfWork.ResourceRepository.GetCurrentResource(FhirResourceId, CurrentResourceType);
      oBlazeServiceOperationOutcome.DatabaseOperationOutcome.SingleResourceRead = true;
      if (oBlazeServiceOperationOutcome.DatabaseOperationOutcome.ResourceMatchingSearch == null)
      {
        if (_UnitOfWork.ResourceRepository.IsCurrentResourceDeleted(FhirResourceId))
        {
          oBlazeServiceOperationOutcome.DatabaseOperationOutcome.RecourceFoundDeleted = true;
          oBlazeServiceOperationOutcome.DatabaseOperationOutcome.DeletedResourceVersionNumber = _UnitOfWork.ResourceRepository.LastDeletedResourceVersion(FhirResourceId);
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
      Search.SearchTermValidationOperationOutcome oISearchTermValidationOperationOutcome = Search.SearchUriValidator.Validate(CurrentResourceType, searchParameters);
      if (oISearchTermValidationOperationOutcome.FhirOperationOutcome != null)
      {
        oBlazeServiceOperationOutcome.SearchValidationOperationOutcome = oISearchTermValidationOperationOutcome;
        return oBlazeServiceOperationOutcome;
      }

      //Retrieve the search plan for this Blaze supported Resource Type
      Interfaces.ISearchPlan SearchPlan = Search.SearchPlanNegotiator.GetSearchPlan(CurrentResourceType, _UnitOfWork);

      //Performed the search with the search plan
      oBlazeServiceOperationOutcome = SearchPlan.Search(oISearchTermValidationOperationOutcome.SearchTerms, oBlazeServiceOperationOutcome, CurrentResourceType);

      return oBlazeServiceOperationOutcome;
    }

    // Add
    // POST: URL/FhirApi/Patient
    public abstract IBlazeServiceOperationOutcome Post(Resource FhirResource);

    //Update
    // PUT: URL/FhirApi/Patient/5
    public abstract IBlazeServiceOperationOutcome Put(string FhirResourceId, Resource FhirResource);
    
    //Delete
    // DELETE: URL/FhirApi/Patient/5
    public abstract IBlazeServiceOperationOutcome Delete(string FhirResourceId);

  }
}

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
using Blaze.Common.Interfaces;
using Blaze.Common.Interfaces.Services;
using Blaze.Common.Interfaces.Repositories;
using Blaze.Engine.Response;
using Blaze.Common.BusinessEntities.Dto;

namespace Blaze.Engine.Services
{
  public abstract class BaseResourceServices : CommonServices, IBaseResourceServices, ICommonServices, IBaseServices
  {
    public abstract DtoEnums.SupportedFhirResource CurrentResourceType { get; }

    
     //Constructor for dependency injection
    public BaseResourceServices(IUnitOfWork IUnitOfWork)
      : base(IUnitOfWork){}

    // Get By id
    // GET URL/FhirApi/Patient/5    
    public IBlazeServiceOperationOutcome Get(string FhirResourceId)
    {
      var oBlazeServiceOperationOutcome = new Blaze.Engine.Response.BlazeServiceOperationOutcome();
      oBlazeServiceOperationOutcome.OperationType = DtoEnums.CrudOperationType.Read;
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
      throw new NotImplementedException();
    }
    
    //Search
    // GET: URL//FhirApi/Patient&family=Smith&given=John
    public IBlazeServiceOperationOutcome Get(Uri Uri, Hl7.Fhir.Rest.SearchParams searchParameters)
    {
      

      //IBlazeServiceOperationOutcome oBlazeServiceOperationOutcome = new Blaze.Engine.Response.BlazeServiceOperationOutcome();
      //oBlazeServiceOperationOutcome.OperationType = DtoEnums.CrudOperationType.Read;      
      //oBlazeServiceOperationOutcome.RequestUri = Uri;

      ////Validate the search Parameters passed in are implemented for this Resource Type      
      //Search.SearchParametersValidationOperationOutcome oISearchParametersValidationOperationOutcome = Search.SearchUriValidator.Validate(CurrentResourceType, searchParameters);
      //if (oISearchParametersValidationOperationOutcome.FhirOperationOutcome != null)
      //{
      //  oBlazeServiceOperationOutcome.SearchValidationOperationOutcome = oISearchParametersValidationOperationOutcome;
      //  return oBlazeServiceOperationOutcome;
      //}

      ////Retrieve the search plan for this Blaze supported Resource Type
      //Interfaces.ISearchPlan SearchPlan = Search.SearchPlanNegotiator.GetSearchPlan(CurrentResourceType, _UnitOfWork);

      ////Performed the search with the search plan
      //oBlazeServiceOperationOutcome = SearchPlan.Search(oISearchParametersValidationOperationOutcome.SearchParameters, oBlazeServiceOperationOutcome, CurrentResourceType);

      //return oBlazeServiceOperationOutcome;
      throw new NotImplementedException();
    }

    // Add
    // POST: URL/FhirApi/Patient
    public abstract IBlazeServiceOperationOutcome Post(IBlazeServiceRequest BlazeServiceRequest);

    //Update
    // PUT: URL/FhirApi/Patient/5
    public abstract IBlazeServiceOperationOutcome Put(IBlazeServiceRequest BlazeServiceRequest);
    
    //Delete
    // DELETE: URL/FhirApi/Patient/5
    public abstract IBlazeServiceOperationOutcome Delete(string FhirResourceId);

  }
}

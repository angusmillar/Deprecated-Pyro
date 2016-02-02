using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Blaze.Engine.Interfaces;
using Dip.Interfaces;
using Dip.Interfaces.Repositories;
using BusinessEntities;

namespace Blaze.Engine.Search
{
  public static class SearchPlanNegotiator
  {
    public static ISearchPlan GetSearchPlan(DtoEnums.SupportedFhirResource ResourceType, IUnitOfWork UnitOfWork)
    {
      switch (ResourceType)
      {
        case DtoEnums.SupportedFhirResource.Patient:
          return new Search.PatientSearchPlan() { UnitOfWork = UnitOfWork };            
        default:
          return new Search.DefaultResourceSearchPlan() { UnitOfWork = UnitOfWork };                      
      }      
    }
  }
}

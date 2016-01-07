using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Blaze.Engine.Interfaces;
using DataModel;

namespace Blaze.Engine.Search
{
  public static class SearchPlanNegotiator
  {
    public static ISearchPlan GetSearchPlan(ResourceType ResourceType, UnitOfWork UnitOfWork)
    {
      switch (ResourceType)
      {
        case ResourceType.Patient:
          {
            return new Search.PatientSearchPlan() { UnitOfWork = UnitOfWork };            
          }          
        default:
          throw new Blaze.Engine.CustomException.BlazeException(System.Net.HttpStatusCode.Forbidden, "System Error: not SearchPlan has been implemented for ResourceType: " + ResourceType.ToString());                    
      }      
    }
  }
}

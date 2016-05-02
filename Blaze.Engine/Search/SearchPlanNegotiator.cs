using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Blaze.Engine.Interfaces;
using Blaze.Common.Interfaces;
using Blaze.Common.Interfaces.Repositories;
using Blaze.Common.BusinessEntities.Dto;

namespace Blaze.Engine.Search
{
  public static class SearchPlanNegotiator
  {
    public static ISearchPlan GetSearchPlan(DtoEnums.SupportedFhirResource ResourceType, IUnitOfWork UnitOfWork)
    {
      switch (ResourceType)
      {
        default:
          return new Search.DefaultResourceSearchPlan() { UnitOfWork = UnitOfWork };                      
      }      
    }
  }
}

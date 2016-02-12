using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dip.Interfaces;
using BusinessEntities;
using BusinessEntities.Search;

namespace Blaze.Engine.Search
{
  public class ValueSetSearchPlan : SearchPlanBase, Interfaces.ISearchPlan
  {
    public IBlazeServiceOperationOutcome Search(DtoSearchParameters oSearchParameters, IBlazeServiceOperationOutcome oBlazeServiceOperationOutcome, DtoEnums.SupportedFhirResource ResourceType)
    {

      oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _UnitOfWork.ValueSetRepository.Search(oSearchParameters);
      return oBlazeServiceOperationOutcome;
    }
  }
}

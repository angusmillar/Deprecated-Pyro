using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.Engine.Search;
using Blaze.Common.Interfaces;
using Blaze.Common.Interfaces.Repositories;
using Blaze.Common.BusinessEntities.Dto;
using Blaze.Common.BusinessEntities.Search;

namespace Blaze.Engine.Interfaces
{
  public interface ISearchPlan
  {
    IUnitOfWork UnitOfWork { set; }
    IBlazeServiceOperationOutcome Search(DtoSearchParameters oSearchParameters, IBlazeServiceOperationOutcome oBlazeServiceOperationOutcome, DtoEnums.SupportedFhirResource ResourceType);    
  }
}

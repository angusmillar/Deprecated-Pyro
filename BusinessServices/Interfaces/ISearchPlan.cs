using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.Engine.Search;
using Dip.Interfaces;

namespace Blaze.Engine.Interfaces
{
  public interface ISearchPlan
  {
    Dip.Interfaces.IUnitOfWork UnitOfWork { set; }
    IBlazeServiceOperationOutcome Search(SearchTerms oSearchTerms, IBlazeServiceOperationOutcome oBlazeServiceOperationOutcome);    
  }
}

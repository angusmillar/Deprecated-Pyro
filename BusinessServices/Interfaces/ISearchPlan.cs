using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.Engine.Search;

namespace Blaze.Engine.Interfaces
{
  public interface ISearchPlan
  {
    Dip.Interfaces.IUnitOfWork UnitOfWork { set; }    
    SearchResult Search(SearchTerms oSearchTerms);    
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using Blaze.Engine.Search;

namespace Blaze.Engine.Interfaces
{
  public interface ISearchPlan
  {
    UnitOfWork UnitOfWork { set; }
    Uri RequestUri { get; set; }
    SearchResult Search(SearchTerms oSearchTerms);    
  }
}

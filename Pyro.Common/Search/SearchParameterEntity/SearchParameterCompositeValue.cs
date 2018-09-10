using Pyro.Common.Tools.UriSupport;
using System.Collections.Generic;

namespace Pyro.Common.Search.SearchParameterEntity
{
  public class SearchParameterCompositeValue : SearchParameterValueBase
  {
    public List<ISearchParameterBase> SearchParameterBaseList { get; set; }
   
    public SearchParameterCompositeValue()
    {
      this.SearchParameterBaseList = new List<ISearchParameterBase>();      
    }
  }
}

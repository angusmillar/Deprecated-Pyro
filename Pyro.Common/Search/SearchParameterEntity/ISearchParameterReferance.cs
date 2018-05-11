using System.Collections.Generic;
using Pyro.Common.DtoEntity;

namespace Pyro.Common.Search.SearchParameterEntity
{
  public interface ISearchParameterReferance : ISearchParameterBase
  {
    IList<string> AllowedReferanceResourceList { get; set; }
    bool IsChained { get; set; }
    List<SearchParameterReferanceValue> ValueList { get; set; }
  }
}
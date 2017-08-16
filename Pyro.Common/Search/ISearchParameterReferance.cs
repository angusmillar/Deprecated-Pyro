using System.Collections.Generic;
using Pyro.Common.BusinessEntities.Dto;

namespace Pyro.Common.Search
{
  public interface ISearchParameterReferance : ISearchParameterBase
  {
    IList<string> AllowedReferanceResourceList { get; set; }
    List<SearchParameterReferanceValue> ValueList { get; set; }

    //bool TryParseValue(string Values);
    //bool ValidatePrefixes(DtoServiceSearchParameterLight DtoSupportedSearchParameters);
  }
}
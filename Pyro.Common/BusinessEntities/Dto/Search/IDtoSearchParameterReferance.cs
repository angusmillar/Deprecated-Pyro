using System.Collections.Generic;
using Pyro.Common.BusinessEntities.Dto;

namespace Pyro.Common.BusinessEntities.Search
{
  public interface IDtoSearchParameterReferance : IDtoSearchParameterBase
  {
    IList<string> AllowedReferanceResourceList { get; set; }
    List<DtoSearchParameterReferanceValue> ValueList { get; set; }

    //bool TryParseValue(string Values);
    //bool ValidatePrefixes(DtoServiceSearchParameterLight DtoSupportedSearchParameters);
  }
}
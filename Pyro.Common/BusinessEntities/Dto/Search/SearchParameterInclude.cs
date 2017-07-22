using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;

namespace Pyro.Common.BusinessEntities.Dto.Search
{
  public class SearchParameterInclude
  {
    private readonly string _RecurseName = "recurse";
    public FHIRAllTypes SourceResourceType { get; set; }
    public DtoServiceSearchParameterLight SearchParameter { get; set; }
    public FHIRAllTypes? SearchParameterTargetResourceType { get; set; }
    public bool IsRecurse { get; set; }
    public string AsFormatedSearchParameter()
    {
      //example:
      //_include:recurse=SourceResourceType:SearchParameterTargetResourceType
      string result = Hl7.Fhir.Rest.SearchParams.SEARCH_PARAM_INCLUDE;
      if (IsRecurse)
      {
        result += $":{_RecurseName}";
      }
      result += $"={SourceResourceType.GetLiteral()}";
      if (SearchParameter != null)
      {
        result += $":{SearchParameter.Name}";
      }
      if (SearchParameterTargetResourceType.HasValue)
      {
        result += $":{SearchParameterTargetResourceType.GetLiteral()}";
      }
      return result;
    }
  }
}

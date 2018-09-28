using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.Search
{
  public class SearchParameterInclude
  {
    public enum IncludeType { Include, RevInclude };
    public SearchParameterInclude(IncludeType IncludeType)
    {
      this.Type = IncludeType;
    }
    public IncludeType Type { get; private set; }    
    public static string IterateName => "iterate";
    public FHIRAllTypes SourceResourceType { get; set; }
    public List<DtoServiceSearchParameterLight> SearchParameterList { get; set; }
    public FHIRAllTypes? SearchParameterTargetResourceType { get; set; }
    public bool IsIterate { get; set; }

    public string AsFormatedSearchParameter()
    {
      //example:
      //_include:recurse=SourceResourceType:SearchParameterTargetResourceType      
      //_revinclude:recurse=SourceResourceType:SearchParameterTargetResourceType

      string result = string.Empty;
      if (Type == IncludeType.Include)
      {
        result = Hl7.Fhir.Rest.SearchParams.SEARCH_PARAM_INCLUDE;
      }
      else
      {
        result = Hl7.Fhir.Rest.SearchParams.SEARCH_PARAM_REVINCLUDE;
      }

      if (IsIterate)
      {
        result += $":{IterateName}";
      }
      result += $"={SourceResourceType.GetLiteral()}";
      if (SearchParameterList != null && SearchParameterList.Count == 1)
      {
        result += $":{SearchParameterList[0].Name}";
      }
      if (SearchParameterList != null && SearchParameterList.Count > 1)
      {
        result += $":*";
      }
      if (SearchParameterTargetResourceType.HasValue)
      {
        result += $":{SearchParameterTargetResourceType.GetLiteral()}";
      }
      return result;
    }

  }
}

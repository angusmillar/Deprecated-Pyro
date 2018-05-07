using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Enum;
using System.Text.RegularExpressions;
using Pyro.Common.BusinessEntities.Dto;
using Hl7.Fhir.Utility;
using Hl7.Fhir.Model;

namespace Pyro.Common.Search
{
  public abstract class SearchParameterValueWithPrefix : SearchParameterValueBase
  {
    public SearchParameter.SearchComparator? Prefix { get; set; }
    public bool ValidatePreFix(DtoServiceSearchParameterLight DtoSupportedSearchParameters)
    {
      if (this.Prefix.HasValue == false)
      {
        return true;
      }
      else if (Pyro.Common.Tools.SearchParameterTools.GetPrefixListForSearchType(DtoSupportedSearchParameters.Type).Contains(this.Prefix.GetLiteral()))
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public string ParsePrefix(string Value)
    {
      if (Value.Length > 2)
      {
        //Are the first two char Alpha characters 
        if (Regex.IsMatch(Value.Substring(0, 2), @"^[a-zA-Z]+$"))
        {
          var SearchPrefixTypeDictionary = FhirSearchEnum.GetSearchPrefixTypeDictionary();
          if (SearchPrefixTypeDictionary.ContainsKey(Value.Substring(0, 2)))
          {
            this.Prefix = SearchPrefixTypeDictionary[Value.Substring(0, 2)];
            Value = Value.Substring(2);
          }
        }
        else
        {
          this.Prefix = null;
        }
      }
      return Value;
    }
  }
}

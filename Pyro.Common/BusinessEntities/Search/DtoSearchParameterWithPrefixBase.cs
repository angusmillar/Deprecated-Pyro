using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.Common.Enum;
using System.Text.RegularExpressions;

namespace Blaze.Common.BusinessEntities.Search
{
  public abstract class DtoSearchParameterValueWithPrefix : DtoSearchParameterValueBase
  {
    public FhirSearchEnum.SearchPrefixType Prefix { get; set; }
    public bool ValidatePreFix(DtoSupportedSearchParameters DtoSupportedSearchParameters)
    {
      if (DtoSupportedSearchParameters.PrefixList.Contains(this.Prefix) || this.Prefix == FhirSearchEnum.SearchPrefixType.None)
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
      //if (oSearchParameter.DbSearchParameterType == DatabaseEnum.DbIndexType.DateIndex ||
      //  oSearchParameter.DbSearchParameterType == DatabaseEnum.DbIndexType.DatePeriodIndex ||
      //                oSearchParameter.DbSearchParameterType == DatabaseEnum.DbIndexType.NumberIndex ||
      //  oSearchParameter.DbSearchParameterType == DatabaseEnum.DbIndexType.QuantityRangeIndex ||
      //  oSearchParameter.DbSearchParameterType == DatabaseEnum.DbIndexType.QuantityIndex)
      //{
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
          this.Prefix = FhirSearchEnum.SearchPrefixType.None;
        }
      }
      //}
      return Value;
    }
  }
}

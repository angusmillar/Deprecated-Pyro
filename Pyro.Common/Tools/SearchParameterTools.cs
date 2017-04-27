using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.Enum;

namespace Pyro.Common.Tools
{
  public static class SearchParameterTools
  {
    public static List<string> GetPrefixListForSearchType(SearchParamType SearchParamType)
    {
      var ReturnList = new List<string>();
      switch (SearchParamType)
      {
        case SearchParamType.Number:
          ReturnList.Add(SearchParameter.SearchComparator.Ne.GetLiteral());
          ReturnList.Add(SearchParameter.SearchComparator.Eq.GetLiteral());
          ReturnList.Add(SearchParameter.SearchComparator.Gt.GetLiteral());
          ReturnList.Add(SearchParameter.SearchComparator.Ge.GetLiteral());
          ReturnList.Add(SearchParameter.SearchComparator.Lt.GetLiteral());
          ReturnList.Add(SearchParameter.SearchComparator.Le.GetLiteral());
          return ReturnList;
        case SearchParamType.Date:
          ReturnList.Add(SearchParameter.SearchComparator.Ne.GetLiteral());
          ReturnList.Add(SearchParameter.SearchComparator.Eq.GetLiteral());
          ReturnList.Add(SearchParameter.SearchComparator.Gt.GetLiteral());
          ReturnList.Add(SearchParameter.SearchComparator.Ge.GetLiteral());
          ReturnList.Add(SearchParameter.SearchComparator.Lt.GetLiteral());
          ReturnList.Add(SearchParameter.SearchComparator.Le.GetLiteral());
          return ReturnList;
        case SearchParamType.String:
          //Any search parameter that's value is a string will not have prefixes
          return ReturnList;
        case SearchParamType.Token:
          //Any search parameter that's value is a string will not have prefixes
          return ReturnList;
        case SearchParamType.Reference:
          //Any search parameter that's value is a string will not have prefixes
          return ReturnList;
        case SearchParamType.Composite:
          //Any search parameter that's value is a string will not have prefixes
          return ReturnList;
        case SearchParamType.Quantity:
          ReturnList.Add(SearchParameter.SearchComparator.Ne.GetLiteral());
          ReturnList.Add(SearchParameter.SearchComparator.Eq.GetLiteral());
          ReturnList.Add(SearchParameter.SearchComparator.Gt.GetLiteral());
          ReturnList.Add(SearchParameter.SearchComparator.Ge.GetLiteral());
          ReturnList.Add(SearchParameter.SearchComparator.Lt.GetLiteral());
          ReturnList.Add(SearchParameter.SearchComparator.Le.GetLiteral());
          return ReturnList;
        case SearchParamType.Uri:
          //Any search parameter that's value is a string will not have prefixes
          return ReturnList;
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(SearchParamType.GetLiteral(), (int)SearchParamType, typeof(SearchParamType));
      }      
    }



    public static IList<SearchParameter.SearchModifierCode> GetModifiersForSearchType(SearchParamType SearchParamType)
    {
      IList<SearchParameter.SearchModifierCode> ReturnList = new List<SearchParameter.SearchModifierCode>();
      switch (SearchParamType)
      {
        case SearchParamType.Number:
          ReturnList.Add(SearchParameter.SearchModifierCode.Missing);
          return ReturnList;          
        case SearchParamType.Date:
          ReturnList.Add(SearchParameter.SearchModifierCode.Missing);
          return ReturnList;          
        case SearchParamType.String:
          ReturnList.Add(SearchParameter.SearchModifierCode.Missing);
          ReturnList.Add(SearchParameter.SearchModifierCode.Contains);
          ReturnList.Add(SearchParameter.SearchModifierCode.Exact);
          return ReturnList;
        case SearchParamType.Token:
          ReturnList.Add(SearchParameter.SearchModifierCode.Missing);
          //The modifiers below are supported in the spec for token but not 
          //implemented by this server as yet

          //ReturnList.Add(Conformance.SearchModifierCode.Text.ToString());
          //ReturnList.Add(Conformance.SearchModifierCode.In.ToString());
          //ReturnList.Add(Conformance.SearchModifierCode.Below.ToString());
          //ReturnList.Add(Conformance.SearchModifierCode.Above.ToString());
          //ReturnList.Add(Conformance.SearchModifierCode.In.ToString());
          //ReturnList.Add(Conformance.SearchModifierCode.NotIn.ToString());
          return ReturnList;
        case SearchParamType.Reference:
          ReturnList.Add(SearchParameter.SearchModifierCode.Type);
          ReturnList.Add(SearchParameter.SearchModifierCode.Missing);
          return ReturnList;
        case SearchParamType.Composite:
          return ReturnList;
        case SearchParamType.Quantity:
          ReturnList.Add(SearchParameter.SearchModifierCode.Missing);
          return ReturnList;
        case SearchParamType.Uri:
          ReturnList.Add(SearchParameter.SearchModifierCode.Missing);
          ReturnList.Add(SearchParameter.SearchModifierCode.Below);
          ReturnList.Add(SearchParameter.SearchModifierCode.Above);
          ReturnList.Add(SearchParameter.SearchModifierCode.Contains);
          ReturnList.Add(SearchParameter.SearchModifierCode.Exact);
          return ReturnList;
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(SearchParamType.ToString(), (int)SearchParamType, typeof(SearchParamType));
      }
    }
  }
}

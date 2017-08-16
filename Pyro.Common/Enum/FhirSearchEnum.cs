using System;
using System.Collections.Generic;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Search;

namespace Pyro.Common.Enum
{
  public static partial class FhirSearchEnum
  {
    public static Dictionary<string, Hl7.Fhir.Rest.SummaryType> GetSummaryTypeDictionary()
    {
      return new Dictionary<string, Hl7.Fhir.Rest.SummaryType>()
      {
        {Hl7.Fhir.Rest.SummaryType.Count.ToString(), Hl7.Fhir.Rest.SummaryType.Count},
        {Hl7.Fhir.Rest.SummaryType.Data.ToString(), Hl7.Fhir.Rest.SummaryType.Data},
        {Hl7.Fhir.Rest.SummaryType.False.ToString(), Hl7.Fhir.Rest.SummaryType.False},
        {Hl7.Fhir.Rest.SummaryType.Text.ToString(), Hl7.Fhir.Rest.SummaryType.Text},
        {Hl7.Fhir.Rest.SummaryType.True.ToString(), Hl7.Fhir.Rest.SummaryType.True},
      };
    }

    public static Dictionary<string, SearchParameter.SearchComparator> GetSearchPrefixTypeDictionary()
    {
      return new Dictionary<string, SearchParameter.SearchComparator>()
      {
        {SearchParameter.SearchComparator.Ap.GetLiteral(), SearchParameter.SearchComparator.Ap},
        {SearchParameter.SearchComparator.Eb.GetLiteral(), SearchParameter.SearchComparator.Eb},
        {SearchParameter.SearchComparator.Eq.GetLiteral(), SearchParameter.SearchComparator.Eq},
        {SearchParameter.SearchComparator.Gt.GetLiteral(), SearchParameter.SearchComparator.Gt},
        {SearchParameter.SearchComparator.Ge.GetLiteral(), SearchParameter.SearchComparator.Ge},
        {SearchParameter.SearchComparator.Lt.GetLiteral(), SearchParameter.SearchComparator.Lt},
        {SearchParameter.SearchComparator.Le.GetLiteral(), SearchParameter.SearchComparator.Le},
        {SearchParameter.SearchComparator.Ne.GetLiteral(), SearchParameter.SearchComparator.Ne},
        {SearchParameter.SearchComparator.Sa.GetLiteral(), SearchParameter.SearchComparator.Sa}
      };
    }

    public static Dictionary<string, SearchParameter.SearchModifierCode> GetSearchModifierTypeDictionary()
    {
      return new Dictionary<string, SearchParameter.SearchModifierCode>()
      {
        {SearchParameter.SearchModifierCode.Missing.GetLiteral(), SearchParameter.SearchModifierCode.Missing},
        {SearchParameter.SearchModifierCode.Exact.GetLiteral(), SearchParameter.SearchModifierCode.Exact},
        {SearchParameter.SearchModifierCode.Contains.GetLiteral(), SearchParameter.SearchModifierCode.Contains},
        {SearchParameter.SearchModifierCode.Text.GetLiteral(), SearchParameter.SearchModifierCode.Text},
        {SearchParameter.SearchModifierCode.Type.GetLiteral(), SearchParameter.SearchModifierCode.Type},
        {SearchParameter.SearchModifierCode.Below.GetLiteral(), SearchParameter.SearchModifierCode.Below},
        {SearchParameter.SearchModifierCode.Above.GetLiteral(), SearchParameter.SearchModifierCode.Above},
        {SearchParameter.SearchModifierCode.In.GetLiteral(), SearchParameter.SearchModifierCode.In},
        {SearchParameter.SearchModifierCode.NotIn.GetLiteral(), SearchParameter.SearchModifierCode.NotIn}
      };
    }


  }
}

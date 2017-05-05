using System;
using System.Collections.Generic;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.BusinessEntities.Search;

namespace Pyro.Common.Enum
{
  public static partial class FhirSearchEnum
  {    
    public static Dictionary<string, Hl7.Fhir.Rest.SummaryType> GetSummaryTypeDictionary()
    {
      return new Dictionary<string, Hl7.Fhir.Rest.SummaryType>()
      {
        {Hl7.Fhir.Rest.SummaryType.Count.GetPyroLiteral(), Hl7.Fhir.Rest.SummaryType.Count},
        {Hl7.Fhir.Rest.SummaryType.Data.GetPyroLiteral(), Hl7.Fhir.Rest.SummaryType.Data},
        {Hl7.Fhir.Rest.SummaryType.False.GetPyroLiteral(), Hl7.Fhir.Rest.SummaryType.False},
        {Hl7.Fhir.Rest.SummaryType.Text.GetPyroLiteral(), Hl7.Fhir.Rest.SummaryType.Text},
        {Hl7.Fhir.Rest.SummaryType.True.GetPyroLiteral(), Hl7.Fhir.Rest.SummaryType.True},        
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
        {SearchParameter.SearchModifierCode.Missing.GetPyroLiteral(), SearchParameter.SearchModifierCode.Missing},
        {SearchParameter.SearchModifierCode.Exact.GetPyroLiteral(), SearchParameter.SearchModifierCode.Exact},
        {SearchParameter.SearchModifierCode.Contains.GetPyroLiteral(), SearchParameter.SearchModifierCode.Contains},
        {SearchParameter.SearchModifierCode.Text.GetPyroLiteral(), SearchParameter.SearchModifierCode.Text},
        {SearchParameter.SearchModifierCode.Type.GetPyroLiteral(), SearchParameter.SearchModifierCode.Type},
        {SearchParameter.SearchModifierCode.Below.GetPyroLiteral(), SearchParameter.SearchModifierCode.Below},
        {SearchParameter.SearchModifierCode.Above.GetPyroLiteral(), SearchParameter.SearchModifierCode.Above},
        {SearchParameter.SearchModifierCode.In.GetPyroLiteral(), SearchParameter.SearchModifierCode.In},
        {SearchParameter.SearchModifierCode.NotIn.GetPyroLiteral(), SearchParameter.SearchModifierCode.NotIn}
      };
    }


  }
}

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

    //public enum SearchPrefixType
    //{
    //  None,
    //  Equal,
    //  NotEqual,
    //  Greater,
    //  Less,
    //  GreaterOrEqual,
    //  LessOrEqual,
    //  StartsAfter,
    //  EndsBefore,
    //  Approximately
    //}
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

    //public enum SearchModifierType
    //{
    //  None,
    //  Missing,
    //  Exact,
    //  Contains,
    //  Text,
    //  Type,
    //  Below,
    //  Above,
    //  In,
    //  NotIn
    //}

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

    //public static Dictionary<SearchModifierType, Conformance.SearchModifierCode> GetConformanceSearchModifierCodeDictionary()
    //{
    //  return new Dictionary<SearchModifierType, Conformance.SearchModifierCode>()
    //  {
    //    {SearchModifierType.Missing, Conformance.SearchModifierCode.Missing},
    //    {SearchModifierType.Exact, Conformance.SearchModifierCode.Exact},
    //    {SearchModifierType.Contains, Conformance.SearchModifierCode.Contains},
    //    {SearchModifierType.Text, Conformance.SearchModifierCode.Text},
    //    {SearchModifierType.Type, Conformance.SearchModifierCode.Type},
    //    {SearchModifierType.Below, Conformance.SearchModifierCode.Below},
    //    {SearchModifierType.Above, Conformance.SearchModifierCode.Above},
    //    {SearchModifierType.In, Conformance.SearchModifierCode.In},
    //    {SearchModifierType.NotIn, Conformance.SearchModifierCode.NotIn}
    //  };
    //}


    //public static Dictionary<SearchModifierType, SearchParameter.SearchModifierCode> GetConformanceSearchModifierCodeDictionary()
    //{
    //  return new Dictionary<SearchModifierType, SearchParameter.SearchModifierCode>()
    //  {
    //    {SearchModifierType.Missing, SearchParameter.SearchModifierCode.Missing},
    //    {SearchModifierType.Exact, SearchParameter.SearchModifierCode.Exact},
    //    {SearchModifierType.Contains, SearchParameter.SearchModifierCode.Contains},
    //    {SearchModifierType.Text, SearchParameter.SearchModifierCode.Text},
    //    {SearchModifierType.Type, SearchParameter.SearchModifierCode.Type},
    //    {SearchModifierType.Below, SearchParameter.SearchModifierCode.Below},
    //    {SearchModifierType.Above, SearchParameter.SearchModifierCode.Above},
    //    {SearchModifierType.In, SearchParameter.SearchModifierCode.In},
    //    {SearchModifierType.NotIn, SearchParameter.SearchModifierCode.NotIn}
    //  };
    //}

  }
}

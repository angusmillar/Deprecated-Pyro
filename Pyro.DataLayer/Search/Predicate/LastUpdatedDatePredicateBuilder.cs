using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using LinqKit;
using Pyro.Common.Search;
using Pyro.Common.Tools;
using Pyro.DataLayer.DbModel.EntityBase;
using System;
using System.Linq;

namespace Pyro.DataLayer.Search.Predicate
{
  public static class LastUpdatedDatePredicateBuilder<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
      where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
      where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
      where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
      where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
      where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
      where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
      where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
      where ResIndexBaseType : ResourceIndexBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
  {
    public static void Build(PyroSearchParameters DtoSearchParameters, ResourceSearch<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType> Search, ExpressionStarter<ResCurrentType> MainPredicate)
    {
      var LastUpdatedSearchParamerterList = DtoSearchParameters.SearchParametersList.Where(x => x.Resource == FHIRAllTypes.Resource.GetLiteral() && x.Name == "_lastUpdated");
      if (LastUpdatedSearchParamerterList != null)
      {
        ExpressionStarter<ResCurrentType> NewLastUpdatedPredicate = null;
        foreach (var LastUpdatedSearchParameter in LastUpdatedSearchParamerterList)
        {
          if (LastUpdatedSearchParameter is SearchParameterDateTime SearchTypeToken)
          {
            NewLastUpdatedPredicate = LinqKit.PredicateBuilder.New<ResCurrentType>();
            foreach (var SearchValue in SearchTypeToken.ValueList)
            {
              if (!SearchTypeToken.Modifier.HasValue)
              {
                if (SearchValue.Prefix.HasValue == false)
                {
                  NewLastUpdatedPredicate = Equals(Search, NewLastUpdatedPredicate, SearchValue);
                }
                else
                {
                  switch (SearchValue.Prefix)
                  {
                    case SearchParameter.SearchComparator.Eq:
                      NewLastUpdatedPredicate = Equals(Search, NewLastUpdatedPredicate, SearchValue);
                      break;
                    case SearchParameter.SearchComparator.Ne:
                      throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter _lastUpdated.");
                    case SearchParameter.SearchComparator.Gt:
                      var ExpressionGreaterThan = Search.LastUpdatedPropertyGreaterThan(FhirDateTimeSupport.CalculateHighDateTimeForRange(SearchValue.Value, SearchValue.Precision));
                      NewLastUpdatedPredicate = NewLastUpdatedPredicate.Or(ExpressionGreaterThan);
                      break;
                    case SearchParameter.SearchComparator.Lt:
                      var ExpressionLessThan = Search.LastUpdatedPropertyLessThan(SearchValue.Value);
                      NewLastUpdatedPredicate = NewLastUpdatedPredicate.Or(ExpressionLessThan);
                      break;
                    case SearchParameter.SearchComparator.Ge:
                      var ExpressionGreaterThanOrEqualTo = Search.LastUpdatedPropertyGreaterThanOrEqualTo(SearchValue.Value);
                      NewLastUpdatedPredicate = NewLastUpdatedPredicate.Or(ExpressionGreaterThanOrEqualTo);
                      break;
                    case SearchParameter.SearchComparator.Le:
                      var ExpressionLessThanOrEqualTo = Search.LastUpdatedPropertyLessThanOrEqualTo(FhirDateTimeSupport.CalculateHighDateTimeForRange(SearchValue.Value, SearchValue.Precision));
                      NewLastUpdatedPredicate = NewLastUpdatedPredicate.Or(ExpressionLessThanOrEqualTo);
                      break;
                    case SearchParameter.SearchComparator.Sa:
                      throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter _lastUpdated.");
                    case SearchParameter.SearchComparator.Eb:
                      throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter _lastUpdated.");
                    case SearchParameter.SearchComparator.Ap:
                      throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter _lastUpdated.");
                    default:
                      throw new System.ComponentModel.InvalidEnumArgumentException(SearchValue.Prefix.Value.GetLiteral(), (int)SearchValue.Prefix, typeof(SearchParameter.SearchComparator));
                  }
                }
              }
              else
              {
                throw new FormatException($"The search Modifiers are not supported for search parameter _lastUpdated. Found modifier {SearchTypeToken.Modifier.Value.GetLiteral()}");
              }
            }
          }
          MainPredicate.Extend<ResCurrentType>(NewLastUpdatedPredicate, PredicateOperator.And);
        }
        DtoSearchParameters.SearchParametersList.RemoveAll(x => x.Resource == FHIRAllTypes.Resource.GetLiteral() && x.Name == "_lastUpdated");
      }
    }

    private static ExpressionStarter<ResCurrentType> Equals(ResourceSearch<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType> Search, ExpressionStarter<ResCurrentType> NewLastUpdatedPredicate, SearchParameterDateTimeValue SearchValue)
    {
      var ExpressionLow = Search.LastUpdatedPropertyGreaterThanOrEqualTo(SearchValue.Value);
      var ExpressionHigh = Search.LastUpdatedPropertyLessThanOrEqualTo(FhirDateTimeSupport.CalculateHighDateTimeForRange(SearchValue.Value, SearchValue.Precision));
      var Expression = ExpressionLow.And(ExpressionHigh);
      NewLastUpdatedPredicate = NewLastUpdatedPredicate.Or(Expression);
      return NewLastUpdatedPredicate;
    }
  }
}

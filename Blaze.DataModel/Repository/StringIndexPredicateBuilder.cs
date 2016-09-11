using System;
using LinqKit;
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.DataModel.Search;
using Blaze.Common.BusinessEntities.Search;

namespace Blaze.DataModel.Repository
{
  public static class StringIndexPredicateBuilder
  {
    public static ExpressionStarter<T> Build<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterBase SearchItem) where T : ResourceIndexBase
    {
      if (SearchItem is DtoSearchParameterString)
      {
        var SearchTypeString = SearchItem as DtoSearchParameterString;
        foreach (var SearchValue in SearchTypeString.Values)
        {
          switch (SearchTypeString.Modifier)
          {
            case Common.Enum.FhirSearchEnum.SearchModifierType.None:
              if (SearchTypeString.IsDbCollection)
              {
                NewPredicate = NewPredicate.Or(Search.StringCollectionAnyStartsOrEndsWith(SearchTypeString.DbPropertyName, SearchValue));
              }
              else
              {
                NewPredicate = NewPredicate.Or(Search.StringPropertyStartsOrEndsWith(SearchTypeString.DbPropertyName, SearchValue));
              }
              break;
            case Common.Enum.FhirSearchEnum.SearchModifierType.Missing:
              break;
            case Common.Enum.FhirSearchEnum.SearchModifierType.Exact:
              if (SearchTypeString.IsDbCollection)
              {
                NewPredicate = NewPredicate.Or(Search.StringCollectionAnyEqualTo(SearchTypeString.DbPropertyName, SearchValue));
              }
              else
              {
                NewPredicate = NewPredicate.Or(Search.StringPropertyEqualTo(SearchTypeString.DbPropertyName, SearchValue));
              }
              break;
            case Common.Enum.FhirSearchEnum.SearchModifierType.Contains:
              if (SearchTypeString.IsDbCollection)
              {
                NewPredicate = NewPredicate.Or(Search.StringCollectionAnyContains(SearchTypeString.DbPropertyName, SearchValue));
              }
              else
              {
                NewPredicate = NewPredicate.Or(Search.StringPropertyContains(SearchTypeString.DbPropertyName, SearchValue));
              }
              break;
            case Common.Enum.FhirSearchEnum.SearchModifierType.Text:
              throw new FormatException($"The search modifier: {SearchTypeString.Modifier.ToString()} is not supported for search parameter types of string.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.Type:
              throw new FormatException($"The search modifier: {SearchTypeString.Modifier.ToString()} is not supported for search parameter types of string.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.Below:
              throw new FormatException($"The search modifier: {SearchTypeString.Modifier.ToString()} is not supported for search parameter types of string.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.Above:
              throw new FormatException($"The search modifier: {SearchTypeString.Modifier.ToString()} is not supported for search parameter types of string.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.In:
              throw new FormatException($"The search modifier: {SearchTypeString.Modifier.ToString()} is not supported for search parameter types of string.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.NotIn:
              throw new FormatException($"The search modifier: {SearchTypeString.Modifier.ToString()} is not supported for search parameter types of string.");
            default:
              throw new System.ComponentModel.InvalidEnumArgumentException(SearchTypeString.Modifier.ToString(), (int)SearchTypeString.Modifier, typeof(Common.Enum.FhirSearchEnum.SearchModifierType));
          }
        }
      }

      return NewPredicate;
    }
  }
}

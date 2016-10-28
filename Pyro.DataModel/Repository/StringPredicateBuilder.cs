using System;
using LinqKit;
using Pyro.DataModel.DatabaseModel.Base;
using Pyro.DataModel.Search;
using Pyro.Common.BusinessEntities.Search;

namespace Pyro.DataModel.Repository
{
  public static class StringPredicateBuilder
  {
    public static ExpressionStarter<T> Build<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterBase SearchItem) where T : ResourceIndexBase
    {
      if (SearchItem is DtoSearchParameterString)
      {
        var SearchTypeString = SearchItem as DtoSearchParameterString;
        foreach (var SearchValue in SearchTypeString.ValueList)
        {
          switch (SearchTypeString.Modifier)
          {
            case Common.Enum.FhirSearchEnum.SearchModifierType.None:
              if (SearchTypeString.IsDbCollection)
              {
                NewPredicate = NewPredicate.Or(Search.StringCollectionAnyStartsOrEndsWith(SearchTypeString.DbPropertyName, SearchValue.Value));
              }
              else
              {
                NewPredicate = NewPredicate.Or(Search.StringPropertyStartsOrEndsWith(SearchTypeString.DbPropertyName, SearchValue.Value));
              }
              break;
            case Common.Enum.FhirSearchEnum.SearchModifierType.Missing:
              if (SearchTypeString.IsDbCollection)
              {
                if (SearchValue.IsMissing)
                {
                  NewPredicate = NewPredicate.Or(Search.StringCollectionIsNull(SearchTypeString.DbPropertyName));
                }
                else
                {
                  NewPredicate = NewPredicate.Or(Search.StringCollectionIsNotNull(SearchTypeString.DbPropertyName));
                }
              }
              else
              {
                if (SearchValue.IsMissing)
                {
                  NewPredicate = NewPredicate.Or(Search.StringPropertyIsNull(SearchTypeString.DbPropertyName));
                }
                else
                {
                  NewPredicate = NewPredicate.Or(Search.StringPropertyIsNotNull(SearchTypeString.DbPropertyName));
                }
              }
              break;
            case Common.Enum.FhirSearchEnum.SearchModifierType.Exact:
              if (SearchTypeString.IsDbCollection)
              {
                NewPredicate = NewPredicate.Or(Search.StringCollectionAnyEqualTo(SearchTypeString.DbPropertyName, SearchValue.Value));
              }
              else
              {
                NewPredicate = NewPredicate.Or(Search.StringPropertyEqualTo(SearchTypeString.DbPropertyName, SearchValue.Value));
              }
              break;
            case Common.Enum.FhirSearchEnum.SearchModifierType.Contains:
              if (SearchTypeString.IsDbCollection)
              {
                NewPredicate = NewPredicate.Or(Search.StringCollectionAnyContains(SearchTypeString.DbPropertyName, SearchValue.Value));
              }
              else
              {
                NewPredicate = NewPredicate.Or(Search.StringPropertyContains(SearchTypeString.DbPropertyName, SearchValue.Value));
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

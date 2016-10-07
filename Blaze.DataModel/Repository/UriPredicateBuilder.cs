using System;
using LinqKit;
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.DataModel.Search;
using Blaze.Common.BusinessEntities.Search;

namespace Blaze.DataModel.Repository
{
  public static class UriPredicateBuilder
  {
    public static ExpressionStarter<T> Build<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterBase SearchItem) where T : ResourceIndexBase
    {
      if (SearchItem is DtoSearchParameterUri)
      {
        var SearchTypeString = SearchItem as DtoSearchParameterUri;
        foreach (var SearchValue in SearchTypeString.ValueList)
        {
          switch (SearchTypeString.Modifier)
          {
            case Common.Enum.FhirSearchEnum.SearchModifierType.None:
              if (SearchTypeString.IsDbCollection)
              {
                NewPredicate = NewPredicate.Or(Search.UriCollectionAnyEqualTo(SearchTypeString.DbPropertyName, SearchValue.Value.ToString()));
              }
              else
              {
                NewPredicate = NewPredicate.Or(Search.UriPropertyEqualTo(SearchTypeString.DbPropertyName, SearchValue.Value.ToString())); ;
              }
              break;
            case Common.Enum.FhirSearchEnum.SearchModifierType.Missing:
              if (SearchTypeString.IsDbCollection)
              {
                if (SearchValue.IsMissing)
                {
                  NewPredicate = NewPredicate.Or(Search.UriCollectionIsNull(SearchTypeString.DbPropertyName));
                }
                else
                {
                  NewPredicate = NewPredicate.Or(Search.UriCollectionIsNotNull(SearchTypeString.DbPropertyName));
                }
              }
              else
              {
                if (SearchValue.IsMissing)
                {
                  NewPredicate = NewPredicate.Or(Search.UriPropertyIsNull(SearchTypeString.DbPropertyName));
                }
                else
                {
                  NewPredicate = NewPredicate.Or(Search.UriPropertyIsNotNull(SearchTypeString.DbPropertyName));
                }
              }
              break;
            case Common.Enum.FhirSearchEnum.SearchModifierType.Exact:
              if (SearchTypeString.IsDbCollection)
              {
                NewPredicate = NewPredicate.Or(Search.UriCollectionAnyEqualTo(SearchTypeString.DbPropertyName, SearchValue.Value.ToString()));
              }
              else
              {
                NewPredicate = NewPredicate.Or(Search.UriPropertyEqualTo(SearchTypeString.DbPropertyName, SearchValue.Value.ToString())); ;
              }
              break;
            case Common.Enum.FhirSearchEnum.SearchModifierType.Contains:
              if (SearchTypeString.IsDbCollection)
              {
                NewPredicate = NewPredicate.Or(Search.UriCollectionAnyContains(SearchTypeString.DbPropertyName, SearchValue.Value.ToString()));
              }
              else
              {
                NewPredicate = NewPredicate.Or(Search.UriPropertyContains(SearchTypeString.DbPropertyName, SearchValue.Value.ToString()));
              }
              break;
            case Common.Enum.FhirSearchEnum.SearchModifierType.Text:
              throw new FormatException($"The search modifier: {SearchTypeString.Modifier.ToString()} is not supported for search parameter types of string.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.Type:
              throw new FormatException($"The search modifier: {SearchTypeString.Modifier.ToString()} is not supported for search parameter types of string.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.Below:
              if (SearchTypeString.IsDbCollection)
              {
                NewPredicate = NewPredicate.Or(Search.UriCollectionAnyStartsWith(SearchTypeString.DbPropertyName, SearchValue.Value.ToString()));
              }
              else
              {
                NewPredicate = NewPredicate.Or(Search.UriPropertyStartsWith(SearchTypeString.DbPropertyName, SearchValue.Value.ToString()));
              }
              break;
            case Common.Enum.FhirSearchEnum.SearchModifierType.Above:
              if (SearchTypeString.IsDbCollection)
              {
                NewPredicate = NewPredicate.Or(Search.UriCollectionAnyEndsWith(SearchTypeString.DbPropertyName, SearchValue.Value.ToString()));
              }
              else
              {
                NewPredicate = NewPredicate.Or(Search.UriPropertyEndsWith(SearchTypeString.DbPropertyName, SearchValue.Value.ToString()));
              }
              break;
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

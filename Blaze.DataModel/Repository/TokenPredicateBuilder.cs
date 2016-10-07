using System;
using LinqKit;
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.DataModel.Search;
using Blaze.Common.BusinessEntities.Search;

namespace Blaze.DataModel.Repository
{
  public static class TokenPredicateBuilder
  {
    public static ExpressionStarter<T> Build<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterBase SearchItem) where T : ResourceIndexBase
    {
      if (SearchItem is DtoSearchParameterToken)
      {
        var SearchTypeToken = SearchItem as DtoSearchParameterToken;
        foreach (var SearchValue in SearchTypeToken.ValueList)
        {
          switch (SearchTypeToken.Modifier)
          {
            case Common.Enum.FhirSearchEnum.SearchModifierType.None:
              if (SearchTypeToken.IsDbCollection)
              {
                NewPredicate = CollectionEqualToPredicate(Search, NewPredicate, SearchTypeToken, SearchValue);
              }
              else
              {
                NewPredicate = PropertyEqualToPredicate(Search, NewPredicate, SearchTypeToken, SearchValue);
              }
              break;
            case Common.Enum.FhirSearchEnum.SearchModifierType.Missing:
              if (SearchTypeToken.IsDbCollection)
              {
                if (SearchValue.IsMissing)
                {
                  NewPredicate = NewPredicate.Or(Search.TokenCollectionIsNull(SearchTypeToken.DbPropertyName));
                }
                else
                {
                  NewPredicate = NewPredicate.Or(Search.TokenCollectionIsNotNull(SearchTypeToken.DbPropertyName));
                }
              }
              else
              {
                if (SearchValue.IsMissing)
                {
                  NewPredicate = NewPredicate.Or(Search.TokenPropertyIsNull(SearchTypeToken.DbPropertyName));
                }
                else
                {
                  NewPredicate = NewPredicate.Or(Search.TokenPropertyIsNotNull(SearchTypeToken.DbPropertyName));
                }
              }
              break;
            case Common.Enum.FhirSearchEnum.SearchModifierType.Exact:
              throw new FormatException($"The search modifier: {SearchTypeToken.Modifier.ToString()} is not supported for search parameter types of Token.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.Contains:
              throw new FormatException($"The search modifier: {SearchTypeToken.Modifier.ToString()} is not supported for search parameter types of Token.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.Text:
              throw new FormatException($"The search modifier: {SearchTypeToken.Modifier.ToString()} is not supported for search parameter types of Token.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.Type:
              throw new FormatException($"The search modifier: {SearchTypeToken.Modifier.ToString()} is not supported for search parameter types of Token.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.Below:
              throw new FormatException($"The search modifier: {SearchTypeToken.Modifier.ToString()} is not supported for search parameter types of Token.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.Above:
              throw new FormatException($"The search modifier: {SearchTypeToken.Modifier.ToString()} is not supported for search parameter types of Token.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.In:
              throw new FormatException($"The search modifier: {SearchTypeToken.Modifier.ToString()} is not supported for search parameter types of Token.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.NotIn:
              throw new FormatException($"The search modifier: {SearchTypeToken.Modifier.ToString()} is not supported for search parameter types of Token.");
            default:
              throw new System.ComponentModel.InvalidEnumArgumentException(SearchTypeToken.Modifier.ToString(), (int)SearchTypeToken.Modifier, typeof(Common.Enum.FhirSearchEnum.SearchModifierType));
          }
        }
      }

      return NewPredicate;
    }

    private static ExpressionStarter<T> CollectionEqualToPredicate<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterToken SearchTypeToken, DtoSearchParameterTokenValue SearchValue) where T : ResourceIndexBase
    {
      var Expression = Search.TokenCollectionAnyEqualTo(SearchTypeToken.DbPropertyName, SearchValue.Code, SearchValue.System, SearchValue.SearchType);
      NewPredicate = NewPredicate.Or(Expression);
      return NewPredicate;
    }

    private static ExpressionStarter<T> PropertyEqualToPredicate<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterToken SearchTypeToken, DtoSearchParameterTokenValue SearchValue) where T : ResourceIndexBase
    {
      var Expression = Search.TokenPropertyEqualTo(SearchTypeToken.DbPropertyName, SearchValue.Code, SearchValue.System, SearchValue.SearchType);
      NewPredicate = NewPredicate.Or(Expression);
      return NewPredicate;
    }
  }
}

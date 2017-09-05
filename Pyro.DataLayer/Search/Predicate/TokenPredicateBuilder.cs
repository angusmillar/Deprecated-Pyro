using System;
using LinqKit;
using Pyro.DataLayer.DbModel.EntityBase;
using Pyro.Common.Search;
using Hl7.Fhir.Model;

namespace Pyro.DataLayer.Search.Predicate
{
  public static class TokenPredicateBuilder<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
      where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
      where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
      where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
      where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
      where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
      where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
      where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
      where ResIndexBaseType : ResourceIndexBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
  {
    public static ExpressionStarter<ResCurrentType> Build(ResourceSearch<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType> Search, ExpressionStarter<ResCurrentType> NewPredicate, SearchParameterBase SearchItem)
    {
      if (SearchItem is SearchParameterToken)
      {
        var SearchTypeToken = SearchItem as SearchParameterToken;
        foreach (var SearchValue in SearchTypeToken.ValueList)
        {
          if (!SearchTypeToken.Modifier.HasValue)
          {
            NewPredicate = CollectionEqualToPredicate(Search, NewPredicate, SearchTypeToken, SearchValue);
          }
          else
          {
            switch (SearchTypeToken.Modifier)
            {
              case SearchParameter.SearchModifierCode.Missing:
                if (SearchValue.IsMissing)
                {
                  NewPredicate = NewPredicate.Or(Search.SearchParameterIsNull<ResIndexTokenType>(SearchTypeToken.Id));
                }
                else
                {
                  NewPredicate = NewPredicate.Or(Search.SearchParameterIdIsNotNull<ResIndexTokenType>(SearchTypeToken.Id));
                }
                break;
              case SearchParameter.SearchModifierCode.Exact:
                throw new FormatException($"The search modifier: {SearchTypeToken.Modifier.ToString()} is not supported for search parameter types of Token.");
              case SearchParameter.SearchModifierCode.Contains:
                throw new FormatException($"The search modifier: {SearchTypeToken.Modifier.ToString()} is not supported for search parameter types of Token.");
              case SearchParameter.SearchModifierCode.Text:
                throw new FormatException($"The search modifier: {SearchTypeToken.Modifier.ToString()} is not supported for search parameter types of Token.");
              case SearchParameter.SearchModifierCode.Type:
                throw new FormatException($"The search modifier: {SearchTypeToken.Modifier.ToString()} is not supported for search parameter types of Token.");
              case SearchParameter.SearchModifierCode.Below:
                throw new FormatException($"The search modifier: {SearchTypeToken.Modifier.ToString()} is not supported for search parameter types of Token.");
              case SearchParameter.SearchModifierCode.Above:
                throw new FormatException($"The search modifier: {SearchTypeToken.Modifier.ToString()} is not supported for search parameter types of Token.");
              case SearchParameter.SearchModifierCode.In:
                throw new FormatException($"The search modifier: {SearchTypeToken.Modifier.ToString()} is not supported for search parameter types of Token.");
              case SearchParameter.SearchModifierCode.NotIn:
                throw new FormatException($"The search modifier: {SearchTypeToken.Modifier.ToString()} is not supported for search parameter types of Token.");
              default:
                throw new System.ComponentModel.InvalidEnumArgumentException(SearchTypeToken.Modifier.ToString(), (int)SearchTypeToken.Modifier, typeof(SearchParameter.SearchModifierCode));
            }
          }
        }
      }
      return NewPredicate;
    }

    private static ExpressionStarter<ResCurrentType> CollectionEqualToPredicate(ResourceSearch<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType> Search, ExpressionStarter<ResCurrentType> NewPredicate, SearchParameterToken SearchTypeToken, SearchParameterTokenValue SearchValue)
    {
      var Expression = Search.TokenCollectionAnyEqualTo(SearchTypeToken.Id, SearchValue.Code, SearchValue.System, SearchValue.SearchType);
      NewPredicate = NewPredicate.Or(Expression);
      return NewPredicate;
    }

  }
}

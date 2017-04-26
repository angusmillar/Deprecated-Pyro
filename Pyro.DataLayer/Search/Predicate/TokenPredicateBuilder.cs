using System;
using LinqKit;
using Pyro.DataLayer.DbModel.EntityBase;
using Pyro.Common.BusinessEntities.Search;
using Hl7.Fhir.Model;

namespace Pyro.DataLayer.Search.Predicate
{
  public static class TokenPredicateBuilder
  {
    public static ExpressionStarter<T> Build<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterBase SearchItem) 
      where T : ResourceBase
    {
      if (SearchItem is DtoSearchParameterToken)
      {
        var SearchTypeToken = SearchItem as DtoSearchParameterToken;
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
                  NewPredicate = NewPredicate.Or(Search.SearchParameterIsNull(SearchTypeToken.Id));
                }
                else
                {
                  NewPredicate = NewPredicate.Or(Search.SearchParameterIdIsNotNull(SearchTypeToken.Id));
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

    private static ExpressionStarter<T> CollectionEqualToPredicate<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterToken SearchTypeToken, DtoSearchParameterTokenValue SearchValue) 
      where T : ResourceBase
    {
      var Expression = Search.TokenCollectionAnyEqualTo(SearchTypeToken.Id, SearchValue.Code, SearchValue.System, SearchValue.SearchType);
      NewPredicate = NewPredicate.Or(Expression);
      return NewPredicate;
    }

  }
}

using System;
using LinqKit;
using Pyro.DataLayer.DbModel.EntityBase;
using Pyro.Common.BusinessEntities.Search;
using Hl7.Fhir.Model;

namespace Pyro.DataLayer.Search.Predicate
{
  public static class UriPredicateBuilder
  {
    public static ExpressionStarter<T> Build<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterBase SearchItem) 
      where T : ResourceBase
    {
      if (SearchItem is DtoSearchParameterUri)
      {
        var SearchTypeString = SearchItem as DtoSearchParameterUri;
        foreach (var SearchValue in SearchTypeString.ValueList)
        {
          if (!SearchTypeString.Modifier.HasValue)
          {
            NewPredicate = NewPredicate.Or(Search.UriCollectionAnyEqualTo(SearchTypeString.Id, SearchValue.Value.ToString()));           
          }
          else
          {
            switch (SearchTypeString.Modifier)
            {              
              case SearchParameter.SearchModifierCode.Missing:                
                if (SearchValue.IsMissing)
                {
                  NewPredicate = NewPredicate.Or(Search.SearchParameterIsNull(SearchTypeString.Id));
                }
                else
                {
                  NewPredicate = NewPredicate.Or(Search.SearchParameterIdIsNotNull(SearchTypeString.Id));
                }                                
                break;
              case SearchParameter.SearchModifierCode.Exact:
                NewPredicate = NewPredicate.Or(Search.UriCollectionAnyEqualTo(SearchTypeString.Id, SearchValue.Value.ToString()));                
                break;
              case SearchParameter.SearchModifierCode.Contains:
                NewPredicate = NewPredicate.Or(Search.UriCollectionAnyContains(SearchTypeString.Id, SearchValue.Value.ToString()));               
                break;
              case SearchParameter.SearchModifierCode.Text:
                throw new FormatException($"The search modifier: {SearchTypeString.Modifier.ToString()} is not supported for search parameter types of string.");
              case SearchParameter.SearchModifierCode.Type:
                throw new FormatException($"The search modifier: {SearchTypeString.Modifier.ToString()} is not supported for search parameter types of string.");
              case SearchParameter.SearchModifierCode.Below:                
                NewPredicate = NewPredicate.Or(Search.UriCollectionAnyStartsWith(SearchTypeString.Id, SearchValue.Value.ToString()));                
                break;
              case SearchParameter.SearchModifierCode.Above:                
                NewPredicate = NewPredicate.Or(Search.UriCollectionAnyEndsWith(SearchTypeString.Id, SearchValue.Value.ToString()));              
                break;
              case SearchParameter.SearchModifierCode.In:
                throw new FormatException($"The search modifier: {SearchTypeString.Modifier.ToString()} is not supported for search parameter types of string.");
              case SearchParameter.SearchModifierCode.NotIn:
                throw new FormatException($"The search modifier: {SearchTypeString.Modifier.ToString()} is not supported for search parameter types of string.");
              default:
                throw new System.ComponentModel.InvalidEnumArgumentException(SearchTypeString.Modifier.ToString(), (int)SearchTypeString.Modifier, typeof(SearchParameter.SearchModifierCode));
            }
          }
        }
      }
      return NewPredicate;
    }
  }
}

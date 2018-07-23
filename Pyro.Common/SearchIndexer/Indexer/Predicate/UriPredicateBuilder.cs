using System;
using LinqKit;
using Pyro.Common.Tools;
using Pyro.Common.Search;
using Hl7.Fhir.Model;
using Pyro.Common.Search.SearchParameterEntity;

namespace Pyro.Common.SearchIndexer.Indexer.Predicate
{
  public static class UriPredicateBuilder<IResourceIndexed>
  {
    public static ExpressionStarter<IResourceIndexed> Build(Search<IResourceIndexed> Search, ExpressionStarter<IResourceIndexed> NewPredicate, SearchParameterBase SearchItem)
    {
      if (SearchItem is SearchParameterUri)
      {
        var SearchTypeString = SearchItem as SearchParameterUri;
        foreach (var SearchValue in SearchTypeString.ValueList)
        {
          if (!SearchTypeString.Modifier.HasValue)
          {
            NewPredicate = NewPredicate.Or(Search.UriCollectionAnyEqualTo(SearchTypeString.Id, SearchValue.Value.OriginalString.StripHttp().ToLower()));
          }
          else
          {
            switch (SearchTypeString.Modifier)
            {
              case SearchParameter.SearchModifierCode.Missing:
                if (SearchValue.IsMissing)
                {
                  NewPredicate = NewPredicate.Or(Search.SearchParameterIsNull<Index.IUriIndex>(SearchTypeString.Id));
                }
                else
                {
                  NewPredicate = NewPredicate.Or(Search.SearchParameterIdIsNotNull<Index.IUriIndex>(SearchTypeString.Id));
                }
                break;
              case SearchParameter.SearchModifierCode.Exact:
                NewPredicate = NewPredicate.Or(Search.UriCollectionAnyEqualTo(SearchTypeString.Id, SearchValue.Value.OriginalString.StripHttp().ToLower()));
                break;
              case SearchParameter.SearchModifierCode.Contains:
                NewPredicate = NewPredicate.Or(Search.UriCollectionAnyContains(SearchTypeString.Id, SearchValue.Value.OriginalString.StripHttp().ToLower()));
                break;
              case SearchParameter.SearchModifierCode.Text:
                throw new FormatException($"The search modifier: {SearchTypeString.Modifier.ToString()} is not supported for search parameter types of string.");
              case SearchParameter.SearchModifierCode.Type:
                throw new FormatException($"The search modifier: {SearchTypeString.Modifier.ToString()} is not supported for search parameter types of string.");
              case SearchParameter.SearchModifierCode.Below:
                NewPredicate = NewPredicate.Or(Search.UriCollectionAnyStartsWith(SearchTypeString.Id, SearchValue.Value.OriginalString.StripHttp().ToLower()));
                break;
              case SearchParameter.SearchModifierCode.Above:
                NewPredicate = NewPredicate.Or(Search.UriCollectionAnyEndsWith(SearchTypeString.Id, SearchValue.Value.OriginalString.StripHttp().ToLower()));
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

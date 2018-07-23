using System;
using LinqKit;
using Pyro.Common.Search;
using Hl7.Fhir.Model;
using Pyro.Common.Search.SearchParameterEntity;

namespace Pyro.Common.SearchIndexer.Indexer.Predicate
{
  public static class StringPredicateBuilder<IResourceIndexed>
  {
    public static ExpressionStarter<IResourceIndexed> Build(Search<IResourceIndexed> Search, ExpressionStarter<IResourceIndexed> NewPredicate, SearchParameterBase SearchItem)
    {
      if (SearchItem is SearchParameterString)
      {
        var SearchTypeString = SearchItem as SearchParameterString;
        foreach (var SearchValue in SearchTypeString.ValueList)
        {
          if (!SearchTypeString.Modifier.HasValue)
          {
            NewPredicate = NewPredicate.Or(Search.StringCollectionAnyStartsOrEndsWith(SearchTypeString.Id, SearchValue.Value));
          }
          else
          {
            switch (SearchTypeString.Modifier)
            {
              case SearchParameter.SearchModifierCode.Missing:
                if (SearchValue.IsMissing)
                {
                  NewPredicate = NewPredicate.Or(Search.SearchParameterIsNull<Index.IStringIndex>(SearchTypeString.Id));
                }
                else
                {
                  NewPredicate = NewPredicate.Or(Search.SearchParameterIdIsNotNull<Index.IStringIndex>(SearchTypeString.Id));
                }
                break;
              case SearchParameter.SearchModifierCode.Exact:
                NewPredicate = NewPredicate.Or(Search.StringCollectionAnyEqualTo(SearchTypeString.Id, SearchValue.Value));
                break;
              case SearchParameter.SearchModifierCode.Contains:
                NewPredicate = NewPredicate.Or(Search.StringCollectionAnyContains(SearchTypeString.Id, SearchValue.Value));
                break;
              case SearchParameter.SearchModifierCode.Text:
                throw new FormatException($"The search modifier: {SearchTypeString.Modifier.ToString()} is not supported for search parameter types of string.");
              case SearchParameter.SearchModifierCode.Type:
                throw new FormatException($"The search modifier: {SearchTypeString.Modifier.ToString()} is not supported for search parameter types of string.");
              case SearchParameter.SearchModifierCode.Below:
                throw new FormatException($"The search modifier: {SearchTypeString.Modifier.ToString()} is not supported for search parameter types of string.");
              case SearchParameter.SearchModifierCode.Above:
                throw new FormatException($"The search modifier: {SearchTypeString.Modifier.ToString()} is not supported for search parameter types of string.");
              case SearchParameter.SearchModifierCode.In:
                throw new FormatException($"The search modifier: {SearchTypeString.Modifier.ToString()} is not supported for search parameter types of string.");
              case SearchParameter.SearchModifierCode.NotIn:
                throw new FormatException($"The search modifier: {SearchTypeString.Modifier.ToString()} is not supported for search parameter types of string.");
              default:
                throw new System.ComponentModel.InvalidEnumArgumentException(SearchTypeString.Modifier.Value.ToString(), (int)SearchTypeString.Modifier.Value, typeof(Hl7.Fhir.Model.SearchParameter.SearchModifierCode));
            }
          }
        }
      }

      return NewPredicate;
    }
  }
}

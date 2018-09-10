using System;
using LinqKit;
using Pyro.DataLayer.DbModel.EntityBase;
using Pyro.Common.Search;
using Hl7.Fhir.Model;
using Pyro.Common.Search.SearchParameterEntity;
using Pyro.Common.ServiceRoot;

namespace Pyro.DataLayer.Search.Predicate
{
  public static class CompositePredicateBuilder<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
      where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
      where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
      where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
      where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
      where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
      where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()

  {
    public static ExpressionStarter<ResCurrentType> Build(
      ResourceSearchExpressionTrees<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType> Search,      
      ExpressionStarter<ResCurrentType> NewPredicate, 
      SearchParameterBase SearchItem,
      IPrimaryServiceRootCache IPrimaryServiceRootCache)
    {
      if (SearchItem is SearchParameterComposite)
      {
        var SearchTypeComposite = SearchItem as SearchParameterComposite;
        foreach (var SearchValue in SearchTypeComposite.ValueList)
        {
          if (!SearchTypeComposite.Modifier.HasValue)
          {
            NewPredicate = CollectionEqualToPredicate(Search, NewPredicate, SearchTypeComposite, SearchValue, IPrimaryServiceRootCache);
          }
          else
          {
            switch (SearchTypeComposite.Modifier)
            {
              case SearchParameter.SearchModifierCode.Missing:
                throw new FormatException($"The search modifier: {SearchTypeComposite.Modifier.ToString()} is not supported for search parameter types of Composite.");                
              case SearchParameter.SearchModifierCode.Exact:
                throw new FormatException($"The search modifier: {SearchTypeComposite.Modifier.ToString()} is not supported for search parameter types of Composite.");
              case SearchParameter.SearchModifierCode.Contains:
                throw new FormatException($"The search modifier: {SearchTypeComposite.Modifier.ToString()} is not supported for search parameter types of Composite.");
              case SearchParameter.SearchModifierCode.Text:
                throw new FormatException($"The search modifier: {SearchTypeComposite.Modifier.ToString()} is not supported for search parameter types of Composite.");
              case SearchParameter.SearchModifierCode.Type:
                throw new FormatException($"The search modifier: {SearchTypeComposite.Modifier.ToString()} is not supported for search parameter types of Composite.");
              case SearchParameter.SearchModifierCode.Below:
                throw new FormatException($"The search modifier: {SearchTypeComposite.Modifier.ToString()} is not supported for search parameter types of Composite.");
              case SearchParameter.SearchModifierCode.Above:
                throw new FormatException($"The search modifier: {SearchTypeComposite.Modifier.ToString()} is not supported for search parameter types of Composite.");
              case SearchParameter.SearchModifierCode.In:
                throw new FormatException($"The search modifier: {SearchTypeComposite.Modifier.ToString()} is not supported for search parameter types of Composite.");
              case SearchParameter.SearchModifierCode.NotIn:
                throw new FormatException($"The search modifier: {SearchTypeComposite.Modifier.ToString()} is not supported for search parameter types of Composite.");
              default:
                throw new System.ComponentModel.InvalidEnumArgumentException(SearchTypeComposite.Modifier.ToString(), (int)SearchTypeComposite.Modifier, typeof(SearchParameter.SearchModifierCode));
            }
          }
        }
      }
      return NewPredicate;
    }

    private static ExpressionStarter<ResCurrentType> CollectionEqualToPredicate(ResourceSearchExpressionTrees<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType> Search, ExpressionStarter<ResCurrentType> NewPredicate, SearchParameterComposite SearchTypeComposite, SearchParameterCompositeValue SearchValue, IPrimaryServiceRootCache IPrimaryServiceRootCache)
    {
      var _ResourceSearch = new ResourceSearch<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(IPrimaryServiceRootCache);
      var Expression = _ResourceSearch.ANDSearchParameterListPredicateGenerator(SearchValue.SearchParameterBaseList);
      NewPredicate = NewPredicate.Or(Expression);
      return NewPredicate;      
    }

  }
}

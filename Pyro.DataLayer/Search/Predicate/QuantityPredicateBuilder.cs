using System;
using LinqKit;
using Pyro.DataLayer.DbModel.EntityBase;
using Pyro.Common.Search;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;

namespace Pyro.DataLayer.Search.Predicate
{
  public static class QuantityPredicateBuilder<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
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
      if (SearchItem is SearchParameterQuantity)
      {
        var SearchTypeNumber = SearchItem as SearchParameterQuantity;
        foreach (var SearchValue in SearchTypeNumber.ValueList)
        {
          if (SearchTypeNumber.Modifier.HasValue == false)
          {
            if (SearchValue.Prefix.HasValue == false)
            {
              NewPredicate = CollectionEqualToPredicate(Search, NewPredicate, SearchTypeNumber, SearchValue);
            }
            else
            {
              switch (SearchValue.Prefix)
              {
                case SearchParameter.SearchComparator.Eq:
                  NewPredicate = CollectionEqualToPredicate(Search, NewPredicate, SearchTypeNumber, SearchValue);
                  break;
                case SearchParameter.SearchComparator.Ne:
                  NewPredicate = CollectionNotEqualToPredicate(Search, NewPredicate, SearchTypeNumber, SearchValue);
                  break;
                case SearchParameter.SearchComparator.Gt:
                  NewPredicate = NewPredicate.Or(Search.QuantityCollectionAnyGreaterThan(SearchTypeNumber.Id, SearchValue.Value, SearchValue.System, SearchValue.Code));
                  break;
                case SearchParameter.SearchComparator.Lt:
                  NewPredicate = NewPredicate.Or(Search.QuantityCollectionAnyLessThan(SearchTypeNumber.Id, SearchValue.Value, SearchValue.System, SearchValue.Code));
                  break;
                case SearchParameter.SearchComparator.Ge:
                  NewPredicate = NewPredicate.Or(Search.QuantityCollectionAnyGreaterThanOrEqualTo(SearchTypeNumber.Id, SearchValue.Value, SearchValue.System, SearchValue.Code));
                  break;
                case SearchParameter.SearchComparator.Le:
                  NewPredicate = NewPredicate.Or(Search.QuantityCollectionAnyLessThanOrEqualTo(SearchTypeNumber.Id, SearchValue.Value, SearchValue.System, SearchValue.Code));
                  break;
                case SearchParameter.SearchComparator.Sa:
                  throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity.");
                case SearchParameter.SearchComparator.Eb:
                  throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity.");
                case SearchParameter.SearchComparator.Ap:
                  throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity.");
                default:
                  throw new System.ComponentModel.InvalidEnumArgumentException(SearchValue.Prefix.Value.GetLiteral(), (int)SearchValue.Prefix, typeof(SearchParameter.SearchComparator));
              }
            }
          }
          else
          {
            switch (SearchTypeNumber.Modifier)
            {
              case SearchParameter.SearchModifierCode.Missing:
                if (SearchValue.Prefix.HasValue == false)
                {
                  if (SearchValue.IsMissing)
                  {
                    NewPredicate = NewPredicate.Or(Search.SearchParameterIsNull<ResIndexQuantityType>(SearchTypeNumber.Id));
                  }
                  else
                  {
                    NewPredicate = NewPredicate.Or(Search.SearchParameterIdIsNotNull<ResIndexQuantityType>(SearchTypeNumber.Id));
                  }
                }
                else
                {
                  switch (SearchValue.Prefix)
                  {
                    case SearchParameter.SearchComparator.Eq:
                      throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                    case SearchParameter.SearchComparator.Ne:
                      throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                    case SearchParameter.SearchComparator.Gt:
                      throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                    case SearchParameter.SearchComparator.Lt:
                      throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                    case SearchParameter.SearchComparator.Ge:
                      throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                    case SearchParameter.SearchComparator.Le:
                      throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                    case SearchParameter.SearchComparator.Sa:
                      throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                    case SearchParameter.SearchComparator.Eb:
                      throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                    case SearchParameter.SearchComparator.Ap:
                      throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                    default:
                      throw new System.ComponentModel.InvalidEnumArgumentException(SearchValue.Prefix.Value.GetLiteral(), (int)SearchValue.Prefix, typeof(SearchParameter.SearchComparator));
                  }
                }
                break;
              case SearchParameter.SearchModifierCode.Exact:
                throw new FormatException($"The search modifier: {SearchTypeNumber.Modifier.ToString()} is not supported for search parameter types of date.");
              case SearchParameter.SearchModifierCode.Contains:
                throw new FormatException($"The search modifier: {SearchTypeNumber.Modifier.ToString()} is not supported for search parameter types of date.");
              case SearchParameter.SearchModifierCode.Text:
                throw new FormatException($"The search modifier: {SearchTypeNumber.Modifier.ToString()} is not supported for search parameter types of date.");
              case SearchParameter.SearchModifierCode.Type:
                throw new FormatException($"The search modifier: {SearchTypeNumber.Modifier.ToString()} is not supported for search parameter types of date.");
              case SearchParameter.SearchModifierCode.Below:
                throw new FormatException($"The search modifier: {SearchTypeNumber.Modifier.ToString()} is not supported for search parameter types of date.");
              case SearchParameter.SearchModifierCode.Above:
                throw new FormatException($"The search modifier: {SearchTypeNumber.Modifier.ToString()} is not supported for search parameter types of date.");
              case SearchParameter.SearchModifierCode.In:
                throw new FormatException($"The search modifier: {SearchTypeNumber.Modifier.ToString()} is not supported for search parameter types of date.");
              case SearchParameter.SearchModifierCode.NotIn:
                throw new FormatException($"The search modifier: {SearchTypeNumber.Modifier.ToString()} is not supported for search parameter types of date.");
              default:
                throw new System.ComponentModel.InvalidEnumArgumentException(SearchTypeNumber.Modifier.Value.GetLiteral(), (int)SearchTypeNumber.Modifier, typeof(SearchParameter.SearchModifierCode));
            }
          }
        }
      }
      return NewPredicate;
    }

    private static ExpressionStarter<ResCurrentType> CollectionEqualToPredicate(ResourceSearch<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType> Search, ExpressionStarter<ResCurrentType> NewPredicate, SearchParameterQuantity SearchTypeNumber, SearchParameterQuantityValue SearchValue)
    {
      var Expression = Search.QuantityCollectionAnyEqualTo(
         SearchTypeNumber.Id,
         Common.Tools.DecimalSupport.CalculateLowNumber(SearchValue.Value, SearchValue.Scale),
         SearchValue.Value,
         Common.Tools.DecimalSupport.CalculateHighNumber(SearchValue.Value, SearchValue.Scale),
         SearchValue.System,
         SearchValue.Code);

      NewPredicate = NewPredicate.Or(Expression);
      return NewPredicate;
    }

    private static ExpressionStarter<ResCurrentType> CollectionNotEqualToPredicate(ResourceSearch<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType> Search, ExpressionStarter<ResCurrentType> NewPredicate, SearchParameterQuantity SearchTypeNumber, SearchParameterQuantityValue SearchValue)
    {
      var NotEqualTo_Expression = Search.QuantityCollectionAllNotEqualTo(
         SearchTypeNumber.Id,
         Common.Tools.DecimalSupport.CalculateLowNumber(SearchValue.Value, SearchValue.Scale),
         SearchValue.Value,
         Common.Tools.DecimalSupport.CalculateHighNumber(SearchValue.Value, SearchValue.Scale),
         SearchValue.System,
         SearchValue.Code);

      var CollectionNotNull_Expression2 = Search.SearchParameterIdIsNotNull<ResIndexQuantityType>(SearchTypeNumber.Id);

      ExpressionStarter<ResCurrentType> NewAndPredicate = LinqKit.PredicateBuilder.New<ResCurrentType>();
      NewAndPredicate = NewAndPredicate.And(NotEqualTo_Expression);
      NewAndPredicate = NewAndPredicate.And(CollectionNotNull_Expression2);

      NewPredicate = NewPredicate.Or(NewAndPredicate);
      return NewPredicate;
    }
  }
}

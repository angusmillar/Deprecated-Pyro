using System;
using LinqKit;
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.DataModel.Search;
using Blaze.Common.BusinessEntities.Search;

//README:
//There are zero QuantityRange search parameters in STU3 to date, 
//therefore this class has not had its logic implemented as there is nothing to test ag>against.
//I have left it hear as a template for the date it is required, review the QuantityPredicateBuilder class when this class is required
//as the logic is similar but different. Key point is that the Mid search value is not required for QuantityPeriod, you will need to write new 
//expressions tom cater for these QuanitiyPeriod searches.

namespace Blaze.DataModel.Repository
{
  public static class QuantityRangePredicateBuilder
  {
    public static ExpressionStarter<T> Build<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterBase SearchItem) where T : ResourceIndexBase
    {
      if (SearchItem is DtoSearchParameterQuantity)
      {
        var SearchTypeNumber = SearchItem as DtoSearchParameterQuantity;
        foreach (var SearchValue in SearchTypeNumber.ValueList)
        {
          switch (SearchTypeNumber.Modifier)
          {
            case Common.Enum.FhirSearchEnum.SearchModifierType.None:
              if (SearchTypeNumber.IsDbCollection)
              {
                switch (SearchValue.Prefix)
                {
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.None:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Equal:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.NotEqual:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Greater:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Less:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.GreaterOrEqual:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.LessOrEqual:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.StartsAfter:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.EndsBefore:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Approximately:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity.");
                  default:
                    throw new System.ComponentModel.InvalidEnumArgumentException(SearchValue.Prefix.ToString(), (int)SearchValue.Prefix, typeof(Common.Enum.FhirSearchEnum.SearchPrefixType));
                }
              }
              else
              {
                switch (SearchValue.Prefix)
                {
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.None:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Equal:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.NotEqual:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Greater:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Less:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.GreaterOrEqual:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.LessOrEqual:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.StartsAfter:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.EndsBefore:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Approximately:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity.");
                  default:
                    throw new System.ComponentModel.InvalidEnumArgumentException(SearchValue.Prefix.ToString(), (int)SearchValue.Prefix, typeof(Common.Enum.FhirSearchEnum.SearchPrefixType));
                }
              }
            case Common.Enum.FhirSearchEnum.SearchModifierType.Missing:
              if (SearchTypeNumber.IsDbCollection)
              {
                switch (SearchValue.Prefix)
                {
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.None:
                    if (SearchValue.IsMissing)
                    {
                      throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity.");
                    }
                    else
                    {
                      throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity.");
                    }
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Equal:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.NotEqual:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Greater:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Less:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.GreaterOrEqual:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.LessOrEqual:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.StartsAfter:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.EndsBefore:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Approximately:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  default:
                    throw new System.ComponentModel.InvalidEnumArgumentException(SearchValue.Prefix.ToString(), (int)SearchValue.Prefix, typeof(Common.Enum.FhirSearchEnum.SearchPrefixType));
                }
              }
              else
              {
                switch (SearchValue.Prefix)
                {
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.None:
                    if (SearchValue.IsMissing)
                    {
                      throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                    }
                    else
                    {
                      throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                    }
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Equal:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.NotEqual:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Greater:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Less:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.GreaterOrEqual:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.LessOrEqual:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.StartsAfter:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.EndsBefore:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Approximately:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of Quantity with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  default:
                    throw new System.ComponentModel.InvalidEnumArgumentException(SearchValue.Prefix.ToString(), (int)SearchValue.Prefix, typeof(Common.Enum.FhirSearchEnum.SearchPrefixType));
                }
              }
            case Common.Enum.FhirSearchEnum.SearchModifierType.Exact:
              throw new FormatException($"The search modifier: {SearchTypeNumber.Modifier.ToString()} is not supported for search parameter types of Quantity.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.Contains:
              throw new FormatException($"The search modifier: {SearchTypeNumber.Modifier.ToString()} is not supported for search parameter types of Quantity.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.Text:
              throw new FormatException($"The search modifier: {SearchTypeNumber.Modifier.ToString()} is not supported for search parameter types of Quantity.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.Type:
              throw new FormatException($"The search modifier: {SearchTypeNumber.Modifier.ToString()} is not supported for search parameter types of Quantity.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.Below:
              throw new FormatException($"The search modifier: {SearchTypeNumber.Modifier.ToString()} is not supported for search parameter types of Quantity.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.Above:
              throw new FormatException($"The search modifier: {SearchTypeNumber.Modifier.ToString()} is not supported for search parameter types of Quantity.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.In:
              throw new FormatException($"The search modifier: {SearchTypeNumber.Modifier.ToString()} is not supported for search parameter types of Quantity.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.NotIn:
              throw new FormatException($"The search modifier: {SearchTypeNumber.Modifier.ToString()} is not supported for search parameter types of Quantity.");
            default:
              throw new System.ComponentModel.InvalidEnumArgumentException(SearchTypeNumber.Modifier.ToString(), (int)SearchTypeNumber.Modifier, typeof(Common.Enum.FhirSearchEnum.SearchModifierType));
          }
        }
      }

      return NewPredicate;
    }

    //private static ExpressionStarter<T> CollectionEqualToPredicate<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterQuantity SearchTypeNumber, DtoSearchParameterQuantityValue SearchValue) where T : ResourceIndexBase
    //{
    //  var Expression = Search.QuantityRangePropertyEqualTo(
    //     SearchTypeNumber.DbPropertyName,
    //     Common.Tools.DecimalSupport.CalculateLowNumber(SearchValue.Value, SearchValue.Scale),
    //     SearchValue.Value,
    //     Common.Tools.DecimalSupport.CalculateHighNumber(SearchValue.Value, SearchValue.Scale),
    //     SearchValue.System,
    //     SearchValue.Code);

    //  NewPredicate = NewPredicate.Or(Expression);
    //  return NewPredicate;
    //}

    //private static ExpressionStarter<T> CollectionNotEqualToPredicate<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterQuantity SearchTypeNumber, DtoSearchParameterQuantityValue SearchValue) where T : ResourceIndexBase
    //{
    //  var NotEqualTo_Expression = Search.QuantityCollectionAllNotEqualTo(
    //     SearchTypeNumber.DbPropertyName,
    //     Common.Tools.DecimalSupport.CalculateLowNumber(SearchValue.Value, SearchValue.Scale),
    //     SearchValue.Value,
    //     Common.Tools.DecimalSupport.CalculateHighNumber(SearchValue.Value, SearchValue.Scale),
    //     SearchValue.System,
    //     SearchValue.Code);

    //  var CollectionNotNull_Expression2 = Search.QuantityCollectionIsNotNull(SearchTypeNumber.DbPropertyName);

    //  ExpressionStarter<T> NewAndPredicate = LinqKit.PredicateBuilder.New<T>();
    //  NewAndPredicate = NewAndPredicate.And(NotEqualTo_Expression);
    //  NewAndPredicate = NewAndPredicate.And(CollectionNotNull_Expression2);

    //  NewPredicate = NewPredicate.Or(NewAndPredicate);
    //  return NewPredicate;
    //}

    //private static ExpressionStarter<T> PropertyNotEqualToPredicate<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterQuantity SearchTypeNumber, DtoSearchParameterQuantityValue SearchValue) where T : ResourceIndexBase
    //{
    //  var Expression = Search.QuantityPropertyNotEqualTo(SearchTypeNumber.DbPropertyName,
    //     Common.Tools.DecimalSupport.CalculateLowNumber(SearchValue.Value, SearchValue.Scale),
    //     SearchValue.Value,
    //     Common.Tools.DecimalSupport.CalculateHighNumber(SearchValue.Value, SearchValue.Scale),
    //     SearchValue.System,
    //     SearchValue.Code);

    //  NewPredicate = NewPredicate.Or(Expression);
    //  return NewPredicate;
    //}

    //private static ExpressionStarter<T> PropertyEqualToPredicate<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterQuantity SearchTypeNumber, DtoSearchParameterQuantityValue SearchValue) where T : ResourceIndexBase
    //{
    //  var Expression = Search.QuantityPropertyEqualTo(SearchTypeNumber.DbPropertyName,
    //    Common.Tools.DecimalSupport.CalculateLowNumber(SearchValue.Value, SearchValue.Scale),
    //    SearchValue.Value,
    //    Common.Tools.DecimalSupport.CalculateHighNumber(SearchValue.Value, SearchValue.Scale),
    //    SearchValue.System,
    //    SearchValue.Code);

    //  NewPredicate = NewPredicate.Or(Expression);
    //  return NewPredicate;
    //}



  }
}

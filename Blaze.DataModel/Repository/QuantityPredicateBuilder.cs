using System;
using LinqKit;
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.DataModel.Search;
using Blaze.Common.BusinessEntities.Search;

namespace Blaze.DataModel.Repository
{
  public static class QuantityPredicateBuilder
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
                    NewPredicate = CollectionEqualToPredicate(Search, NewPredicate, SearchTypeNumber, SearchValue);
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Equal:
                    NewPredicate = CollectionEqualToPredicate(Search, NewPredicate, SearchTypeNumber, SearchValue);
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.NotEqual:
                    NewPredicate = CollectionNotEqualToPredicate(Search, NewPredicate, SearchTypeNumber, SearchValue);
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Greater:
                    NewPredicate = NewPredicate.Or(Search.QuantityCollectionAnyGreaterThan(SearchTypeNumber.DbPropertyName, SearchValue.Value, SearchValue.System, SearchValue.Code));
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Less:
                    NewPredicate = NewPredicate.Or(Search.QuantityCollectionAnyLessThan(SearchTypeNumber.DbPropertyName, SearchValue.Value, SearchValue.System, SearchValue.Code));
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.GreaterOrEqual:
                    NewPredicate = NewPredicate.Or(Search.QuantityCollectionAnyGreaterThanOrEqualTo(SearchTypeNumber.DbPropertyName, SearchValue.Value, SearchValue.System, SearchValue.Code));
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.LessOrEqual:
                    NewPredicate = NewPredicate.Or(Search.QuantityCollectionAnyLessThanOrEqualTo(SearchTypeNumber.DbPropertyName, SearchValue.Value, SearchValue.System, SearchValue.Code));
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.StartsAfter:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of FhirDateTime.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.EndsBefore:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of FhirDateTime.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Approximately:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of FhirDateTime.");
                  default:
                    throw new System.ComponentModel.InvalidEnumArgumentException(SearchValue.Prefix.ToString(), (int)SearchValue.Prefix, typeof(Common.Enum.FhirSearchEnum.SearchPrefixType));
                }
              }
              else
              {
                switch (SearchValue.Prefix)
                {
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.None:
                    NewPredicate = PropertyEqualToPredicate(Search, NewPredicate, SearchTypeNumber, SearchValue);
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Equal:
                    NewPredicate = PropertyEqualToPredicate(Search, NewPredicate, SearchTypeNumber, SearchValue);
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.NotEqual:
                    NewPredicate = PropertyNotEqualToPredicate(Search, NewPredicate, SearchTypeNumber, SearchValue);
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Greater:
                    NewPredicate = NewPredicate.Or(Search.QuantityPropertyGreaterThan(SearchTypeNumber.DbPropertyName, SearchValue.Value, SearchValue.System, SearchValue.Code));
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Less:
                    NewPredicate = NewPredicate.Or(Search.QuantityPropertyLessThan(SearchTypeNumber.DbPropertyName, SearchValue.Value, SearchValue.System, SearchValue.Code));
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.GreaterOrEqual:
                    NewPredicate = NewPredicate.Or(Search.QuantityPropertyGreaterThanOrEqualTo(SearchTypeNumber.DbPropertyName, SearchValue.Value, SearchValue.System, SearchValue.Code));
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.LessOrEqual:
                    NewPredicate = NewPredicate.Or(Search.QuantityPropertyLessThanOrEqualTo(SearchTypeNumber.DbPropertyName, SearchValue.Value, SearchValue.System, SearchValue.Code));
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.StartsAfter:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of FhirDateTime.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.EndsBefore:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of FhirDateTime.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Approximately:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of FhirDateTime.");
                  default:
                    throw new System.ComponentModel.InvalidEnumArgumentException(SearchValue.Prefix.ToString(), (int)SearchValue.Prefix, typeof(Common.Enum.FhirSearchEnum.SearchPrefixType));
                }
              }
              break;
            case Common.Enum.FhirSearchEnum.SearchModifierType.Missing:
              if (SearchTypeNumber.IsDbCollection)
              {
                switch (SearchValue.Prefix)
                {
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.None:
                    if (SearchValue.IsMissing)
                    {
                      NewPredicate = NewPredicate.Or(Search.QuantityCollectionIsNull(SearchTypeNumber.DbPropertyName));
                    }
                    else
                    {
                      NewPredicate = NewPredicate.Or(Search.QuantityCollectionIsNotNull(SearchTypeNumber.DbPropertyName));
                    }
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Equal:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of FhirDateTime with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.NotEqual:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of FhirDateTime with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Greater:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of FhirDateTime with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Less:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of FhirDateTime with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.GreaterOrEqual:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of FhirDateTime with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.LessOrEqual:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of FhirDateTime with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.StartsAfter:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of FhirDateTime with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.EndsBefore:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of FhirDateTime with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Approximately:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of FhirDateTime with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
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
                      NewPredicate = NewPredicate.Or(Search.QuantityPropertyIsNull(SearchTypeNumber.DbPropertyName));
                    }
                    else
                    {
                      NewPredicate = NewPredicate.Or(Search.QuantityPropertyIsNotNull(SearchTypeNumber.DbPropertyName));
                    }
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Equal:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of date with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.NotEqual:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of date with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Greater:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of date with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Less:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of date with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.GreaterOrEqual:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of date with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.LessOrEqual:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of date with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.StartsAfter:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of date with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.EndsBefore:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of date with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Approximately:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of date with a Modifier of: {SearchTypeNumber.Modifier.ToString()}.");
                  default:
                    throw new System.ComponentModel.InvalidEnumArgumentException(SearchValue.Prefix.ToString(), (int)SearchValue.Prefix, typeof(Common.Enum.FhirSearchEnum.SearchPrefixType));
                }
              }
              break;
            case Common.Enum.FhirSearchEnum.SearchModifierType.Exact:
              throw new FormatException($"The search modifier: {SearchTypeNumber.Modifier.ToString()} is not supported for search parameter types of date.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.Contains:
              throw new FormatException($"The search modifier: {SearchTypeNumber.Modifier.ToString()} is not supported for search parameter types of date.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.Text:
              throw new FormatException($"The search modifier: {SearchTypeNumber.Modifier.ToString()} is not supported for search parameter types of date.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.Type:
              throw new FormatException($"The search modifier: {SearchTypeNumber.Modifier.ToString()} is not supported for search parameter types of date.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.Below:
              throw new FormatException($"The search modifier: {SearchTypeNumber.Modifier.ToString()} is not supported for search parameter types of date.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.Above:
              throw new FormatException($"The search modifier: {SearchTypeNumber.Modifier.ToString()} is not supported for search parameter types of date.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.In:
              throw new FormatException($"The search modifier: {SearchTypeNumber.Modifier.ToString()} is not supported for search parameter types of date.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.NotIn:
              throw new FormatException($"The search modifier: {SearchTypeNumber.Modifier.ToString()} is not supported for search parameter types of date.");
            default:
              throw new System.ComponentModel.InvalidEnumArgumentException(SearchTypeNumber.Modifier.ToString(), (int)SearchTypeNumber.Modifier, typeof(Common.Enum.FhirSearchEnum.SearchModifierType));
          }
        }
      }

      return NewPredicate;
    }

    private static ExpressionStarter<T> CollectionEqualToPredicate<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterQuantity SearchTypeNumber, DtoSearchParameterQuantityValue SearchValue) where T : ResourceIndexBase
    {
      var Expression = Search.QuantityCollectionAnyEqualTo(
         SearchTypeNumber.DbPropertyName,
         Common.Tools.DecimalSupport.CalculateLowNumber(SearchValue.Value, SearchValue.Scale),
         SearchValue.Value,
         Common.Tools.DecimalSupport.CalculateHighNumber(SearchValue.Value, SearchValue.Scale),
         SearchValue.System,
         SearchValue.Code);

      NewPredicate = NewPredicate.Or(Expression);
      return NewPredicate;
    }

    private static ExpressionStarter<T> CollectionNotEqualToPredicate<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterQuantity SearchTypeNumber, DtoSearchParameterQuantityValue SearchValue) where T : ResourceIndexBase
    {
      var NotEqualTo_Expression = Search.QuantityCollectionAllNotEqualTo(
         SearchTypeNumber.DbPropertyName,
         Common.Tools.DecimalSupport.CalculateLowNumber(SearchValue.Value, SearchValue.Scale),
         SearchValue.Value,
         Common.Tools.DecimalSupport.CalculateHighNumber(SearchValue.Value, SearchValue.Scale),
         SearchValue.System,
         SearchValue.Code);

      var CollectionNotNull_Expression2 = Search.QuantityCollectionIsNotNull(SearchTypeNumber.DbPropertyName);

      ExpressionStarter<T> NewAndPredicate = LinqKit.PredicateBuilder.New<T>();
      NewAndPredicate = NewAndPredicate.And(NotEqualTo_Expression);
      NewAndPredicate = NewAndPredicate.And(CollectionNotNull_Expression2);

      NewPredicate = NewPredicate.Or(NewAndPredicate);
      return NewPredicate;
    }

    private static ExpressionStarter<T> PropertyNotEqualToPredicate<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterQuantity SearchTypeNumber, DtoSearchParameterQuantityValue SearchValue) where T : ResourceIndexBase
    {
      var Expression = Search.QuantityPropertyNotEqualTo(SearchTypeNumber.DbPropertyName,
         Common.Tools.DecimalSupport.CalculateLowNumber(SearchValue.Value, SearchValue.Scale),
         SearchValue.Value,
         Common.Tools.DecimalSupport.CalculateHighNumber(SearchValue.Value, SearchValue.Scale),
         SearchValue.System,
         SearchValue.Code);

      NewPredicate = NewPredicate.Or(Expression);
      return NewPredicate;
    }
    
    private static ExpressionStarter<T> PropertyEqualToPredicate<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterQuantity SearchTypeNumber, DtoSearchParameterQuantityValue SearchValue) where T : ResourceIndexBase
    {
      var Expression = Search.QuantityPropertyEqualTo(SearchTypeNumber.DbPropertyName,
        Common.Tools.DecimalSupport.CalculateLowNumber(SearchValue.Value, SearchValue.Scale),
        SearchValue.Value,
        Common.Tools.DecimalSupport.CalculateHighNumber(SearchValue.Value, SearchValue.Scale),
        SearchValue.System,
        SearchValue.Code);

      NewPredicate = NewPredicate.Or(Expression);
      return NewPredicate;
    }



  }
}

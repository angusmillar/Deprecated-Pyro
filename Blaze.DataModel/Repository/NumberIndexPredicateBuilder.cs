using System;
using LinqKit;
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.DataModel.Search;
using Blaze.Common.BusinessEntities.Search;

namespace Blaze.DataModel.Repository
{
  public static class NumberPredicateBuilder
  {
    public static ExpressionStarter<T> Build<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterBase SearchItem) where T : ResourceIndexBase
    {
      if (SearchItem is DtoSearchParameterNumber)
      {
        var SearchTypeNumber = SearchItem as DtoSearchParameterNumber;
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
                    //NewPredicate = CollectionNotEqualToPredicate(Search, NewPredicate, SearchTypeNumber, SearchValue);
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Greater:
                    //NewPredicate = NewPredicate.Or(Search.DateTimePeriodCollectionGreaterThan(SearchTypeNumber.DbPropertyName, SearchValue.Value, CalculateHighDateTimeForRange(SearchValue)));
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Less:
                    //NewPredicate = NewPredicate.Or(Search.DateTimePeriodCollectionLessThan(SearchTypeNumber.DbPropertyName, SearchValue.Value, CalculateHighDateTimeForRange(SearchValue)));
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.GreaterOrEqual:
                    //NewPredicate = NewPredicate.Or(Search.DateTimePeriodCollectionGreaterThanOrEqualTo(SearchTypeNumber.DbPropertyName, SearchValue.Value, CalculateHighDateTimeForRange(SearchValue)));
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.LessOrEqual:
                    ///NewPredicate = NewPredicate.Or(Search.DateTimePeriodCollectionLessThanOrEqualTo(SearchTypeNumber.DbPropertyName, SearchValue.Value, CalculateHighDateTimeForRange(SearchValue)));
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
                    //NewPredicate = PropertyNotEqualToPredicate(Search, NewPredicate, SearchTypeNumber, SearchValue);
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Greater:
                    //NewPredicate = NewPredicate.Or(Search.DateTimePeriodPropertyGreaterThan(SearchTypeNumber.DbPropertyName, SearchValue.Value, CalculateHighDateTimeForRange(SearchValue)));
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Less:
                    //NewPredicate = NewPredicate.Or(Search.DateTimePeriodPropertyLessThan(SearchTypeNumber.DbPropertyName, SearchValue.Value, CalculateHighDateTimeForRange(SearchValue)));
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.GreaterOrEqual:
                    //NewPredicate = NewPredicate.Or(Search.DateTimePeriodPropertyGreaterThanOrEqualTo(SearchTypeNumber.DbPropertyName, SearchValue.Value, CalculateHighDateTimeForRange(SearchValue)));
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.LessOrEqual:
                    //NewPredicate = NewPredicate.Or(Search.DateTimePeriodPropertyLessThanOrEqualTo(SearchTypeNumber.DbPropertyName, SearchValue.Value, CalculateHighDateTimeForRange(SearchValue)));
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
                      //NewPredicate = NewPredicate.Or(Search.DateTimePeriodCollectionIsNull(SearchTypeNumber.DbPropertyName));
                    }
                    else
                    {
                      //NewPredicate = NewPredicate.Or(Search.DateTimePeriodCollectionIsNotNull(SearchTypeNumber.DbPropertyName));
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
                      //NewPredicate = NewPredicate.Or(Search.DateTimePeriodPropertyIsNull(SearchTypeNumber.DbPropertyName));
                    }
                    else
                    {
                      //NewPredicate = NewPredicate.Or(Search.DateTimePeriodPropertyIsNotNull(SearchTypeNumber.DbPropertyName));
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


    //private static ExpressionStarter<T> CollectionNotEqualToPredicate<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterDateTime SearchTypeDateTime, DtoSearchParameterDateTimeValue SearchValue) where T : ResourceIndexBase
    //{
    //  var NotEqualToExpression = Search.DateTimePeriodCollectionAnyNotEqualTo(SearchTypeDateTime.DbPropertyName, SearchValue.Value, CalculateHighDateTimeForRange(SearchValue));
    //  var CollectionIsNullExpression = Search.DateTimePeriodCollectionIsNull(SearchTypeDateTime.DbPropertyName);
    //  NewPredicate = NewPredicate.Or(NotEqualToExpression);
    //  NewPredicate = NewPredicate.Or(CollectionIsNullExpression);
    //  return NewPredicate;
    //}

    //private static ExpressionStarter<T> PropertyNotEqualToPredicate<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterDateTime SearchTypeDateTime, DtoSearchParameterDateTimeValue SearchValue) where T : ResourceIndexBase
    //{
    //  var Expression = Search.DateTimePeriodPropertyNotEqualTo(SearchTypeDateTime.DbPropertyName, SearchValue.Value, CalculateHighNumber(SearchValue));
    //  NewPredicate = NewPredicate.Or(Expression);
    //  return NewPredicate;
    //}


    private static ExpressionStarter<T> CollectionEqualToPredicate<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterNumber SearchTypeNumber, DtoSearchParameterNumberValue SearchValue) where T : ResourceIndexBase
    {
      var Expression = Search.NumberCollectionAnyEqualTo(SearchTypeNumber.DbPropertyName, CalculateLowNumber(SearchValue), CalculateHighNumber(SearchValue));
      NewPredicate = NewPredicate.Or(Expression);
      return NewPredicate;

    }

    private static ExpressionStarter<T> PropertyEqualToPredicate<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterNumber SearchTypeNumber, DtoSearchParameterNumberValue SearchValue) where T : ResourceIndexBase
    {
      var Expression = Search.NumberPropertyEqualTo(SearchTypeNumber.DbPropertyName, CalculateLowNumber(SearchValue), CalculateHighNumber(SearchValue));
      NewPredicate = NewPredicate.Or(Expression);
      return NewPredicate;
    }


    private static decimal CalculateHighNumber(DtoSearchParameterNumberValue SearchValue)
    {
      return Decimal.Add(SearchValue.Value, CalculateNewScale(SearchValue));
    }

    private static decimal CalculateLowNumber(DtoSearchParameterNumberValue SearchValue)
    {
      return Decimal.Subtract(SearchValue.Value, CalculateNewScale(SearchValue));
    }

    private static decimal CalculateNewScale(DtoSearchParameterNumberValue SearchValue)
    {
      double Margin = 5;
      return Convert.ToDecimal(Margin / (Math.Pow(10, SearchValue.Scale + 1)));
    }
  }
}

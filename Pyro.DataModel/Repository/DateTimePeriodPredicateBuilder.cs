using System;
using LinqKit;
using Pyro.DataModel.DatabaseModel.Base;
using Pyro.DataModel.Search;
using Pyro.Common.BusinessEntities.Search;

namespace Pyro.DataModel.Repository
{
  public static class DateTimePeriodPredicateBuilder
  {
    public static ExpressionStarter<T> Build<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterBase SearchItem) where T : ResourceIndexBase
    {
      if (SearchItem is DtoSearchParameterDateTime)
      {
        var SearchTypeDateTime = SearchItem as DtoSearchParameterDateTime;
        foreach (var SearchValue in SearchTypeDateTime.ValueList)
        {
          switch (SearchTypeDateTime.Modifier)
          {
            case Common.Enum.FhirSearchEnum.SearchModifierType.None:
              if (SearchTypeDateTime.IsDbCollection)
              {
                switch (SearchValue.Prefix)
                {
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.None:
                    NewPredicate = CollectionEqualToPredicate(Search, NewPredicate, SearchTypeDateTime, SearchValue);
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Equal:
                    NewPredicate = CollectionEqualToPredicate(Search, NewPredicate, SearchTypeDateTime, SearchValue);
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.NotEqual:
                    NewPredicate = CollectionNotEqualToPredicate(Search, NewPredicate, SearchTypeDateTime, SearchValue);
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Greater:
                    NewPredicate = NewPredicate.Or(Search.DateTimePeriodCollectionGreaterThan(SearchTypeDateTime.DbPropertyName, SearchValue.Value, CalculateHighDateTimeForRange(SearchValue)));
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Less:
                    NewPredicate = NewPredicate.Or(Search.DateTimePeriodCollectionLessThan(SearchTypeDateTime.DbPropertyName, SearchValue.Value, CalculateHighDateTimeForRange(SearchValue)));
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.GreaterOrEqual:
                    NewPredicate = NewPredicate.Or(Search.DateTimePeriodCollectionGreaterThanOrEqualTo(SearchTypeDateTime.DbPropertyName, SearchValue.Value, CalculateHighDateTimeForRange(SearchValue)));
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.LessOrEqual:
                    NewPredicate = NewPredicate.Or(Search.DateTimePeriodCollectionLessThanOrEqualTo(SearchTypeDateTime.DbPropertyName, SearchValue.Value, CalculateHighDateTimeForRange(SearchValue)));
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
                    NewPredicate = PropertyEqualToPredicate(Search, NewPredicate, SearchTypeDateTime, SearchValue);
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Equal:
                    NewPredicate = PropertyEqualToPredicate(Search, NewPredicate, SearchTypeDateTime, SearchValue);
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.NotEqual:
                    NewPredicate = PropertyNotEqualToPredicate(Search, NewPredicate, SearchTypeDateTime, SearchValue);
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Greater:
                    NewPredicate = NewPredicate.Or(Search.DateTimePeriodPropertyGreaterThan(SearchTypeDateTime.DbPropertyName, SearchValue.Value, CalculateHighDateTimeForRange(SearchValue)));
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Less:
                    NewPredicate = NewPredicate.Or(Search.DateTimePeriodPropertyLessThan(SearchTypeDateTime.DbPropertyName, SearchValue.Value, CalculateHighDateTimeForRange(SearchValue)));
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.GreaterOrEqual:
                    NewPredicate = NewPredicate.Or(Search.DateTimePeriodPropertyGreaterThanOrEqualTo(SearchTypeDateTime.DbPropertyName, SearchValue.Value, CalculateHighDateTimeForRange(SearchValue)));
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.LessOrEqual:
                    NewPredicate = NewPredicate.Or(Search.DateTimePeriodPropertyLessThanOrEqualTo(SearchTypeDateTime.DbPropertyName, SearchValue.Value, CalculateHighDateTimeForRange(SearchValue)));
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
              if (SearchTypeDateTime.IsDbCollection)
              {
                switch (SearchValue.Prefix)
                {
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.None:
                    if (SearchValue.IsMissing)
                    {
                      NewPredicate = NewPredicate.Or(Search.DateTimePeriodCollectionIsNull(SearchTypeDateTime.DbPropertyName));
                    }
                    else
                    {
                      NewPredicate = NewPredicate.Or(Search.DateTimePeriodCollectionIsNotNull(SearchTypeDateTime.DbPropertyName));
                    }
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Equal:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of FhirDateTime with a Modifier of: {SearchTypeDateTime.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.NotEqual:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of FhirDateTime with a Modifier of: {SearchTypeDateTime.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Greater:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of FhirDateTime with a Modifier of: {SearchTypeDateTime.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Less:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of FhirDateTime with a Modifier of: {SearchTypeDateTime.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.GreaterOrEqual:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of FhirDateTime with a Modifier of: {SearchTypeDateTime.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.LessOrEqual:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of FhirDateTime with a Modifier of: {SearchTypeDateTime.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.StartsAfter:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of FhirDateTime with a Modifier of: {SearchTypeDateTime.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.EndsBefore:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of FhirDateTime with a Modifier of: {SearchTypeDateTime.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Approximately:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of FhirDateTime with a Modifier of: {SearchTypeDateTime.Modifier.ToString()}.");
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
                      NewPredicate = NewPredicate.Or(Search.DateTimePeriodPropertyIsNull(SearchTypeDateTime.DbPropertyName));
                    }
                    else
                    {
                      NewPredicate = NewPredicate.Or(Search.DateTimePeriodPropertyIsNotNull(SearchTypeDateTime.DbPropertyName));
                    }
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Equal:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of date with a Modifier of: {SearchTypeDateTime.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.NotEqual:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of date with a Modifier of: {SearchTypeDateTime.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Greater:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of date with a Modifier of: {SearchTypeDateTime.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Less:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of date with a Modifier of: {SearchTypeDateTime.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.GreaterOrEqual:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of date with a Modifier of: {SearchTypeDateTime.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.LessOrEqual:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of date with a Modifier of: {SearchTypeDateTime.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.StartsAfter:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of date with a Modifier of: {SearchTypeDateTime.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.EndsBefore:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of date with a Modifier of: {SearchTypeDateTime.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Approximately:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of date with a Modifier of: {SearchTypeDateTime.Modifier.ToString()}.");
                  default:
                    throw new System.ComponentModel.InvalidEnumArgumentException(SearchValue.Prefix.ToString(), (int)SearchValue.Prefix, typeof(Common.Enum.FhirSearchEnum.SearchPrefixType));
                }
              }
              break;
            case Common.Enum.FhirSearchEnum.SearchModifierType.Exact:
              throw new FormatException($"The search modifier: {SearchTypeDateTime.Modifier.ToString()} is not supported for search parameter types of date.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.Contains:
              throw new FormatException($"The search modifier: {SearchTypeDateTime.Modifier.ToString()} is not supported for search parameter types of date.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.Text:
              throw new FormatException($"The search modifier: {SearchTypeDateTime.Modifier.ToString()} is not supported for search parameter types of date.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.Type:
              throw new FormatException($"The search modifier: {SearchTypeDateTime.Modifier.ToString()} is not supported for search parameter types of date.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.Below:
              throw new FormatException($"The search modifier: {SearchTypeDateTime.Modifier.ToString()} is not supported for search parameter types of date.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.Above:
              throw new FormatException($"The search modifier: {SearchTypeDateTime.Modifier.ToString()} is not supported for search parameter types of date.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.In:
              throw new FormatException($"The search modifier: {SearchTypeDateTime.Modifier.ToString()} is not supported for search parameter types of date.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.NotIn:
              throw new FormatException($"The search modifier: {SearchTypeDateTime.Modifier.ToString()} is not supported for search parameter types of date.");
            default:
              throw new System.ComponentModel.InvalidEnumArgumentException(SearchTypeDateTime.Modifier.ToString(), (int)SearchTypeDateTime.Modifier, typeof(Common.Enum.FhirSearchEnum.SearchModifierType));
          }
        }
      }

      return NewPredicate;
    }

    private static ExpressionStarter<T> CollectionEqualToPredicate<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterDateTime SearchTypeDateTime, DtoSearchParameterDateTimeValue SearchValue) where T : ResourceIndexBase
    {
      var Expression = Search.DateTimePeriodCollectionAnyEqualTo(SearchTypeDateTime.DbPropertyName, SearchValue.Value, CalculateHighDateTimeForRange(SearchValue));
      NewPredicate = NewPredicate.Or(Expression);
      return NewPredicate;

    }

    private static ExpressionStarter<T> CollectionNotEqualToPredicate<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterDateTime SearchTypeDateTime, DtoSearchParameterDateTimeValue SearchValue) where T : ResourceIndexBase
    {
      var NotEqualToExpression = Search.DateTimePeriodCollectionAnyNotEqualTo(SearchTypeDateTime.DbPropertyName, SearchValue.Value, CalculateHighDateTimeForRange(SearchValue));
      var CollectionIsNullExpression = Search.DateTimePeriodCollectionIsNull(SearchTypeDateTime.DbPropertyName);
      NewPredicate = NewPredicate.Or(NotEqualToExpression);
      NewPredicate = NewPredicate.Or(CollectionIsNullExpression);
      return NewPredicate;
    }

    private static ExpressionStarter<T> PropertyEqualToPredicate<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterDateTime SearchTypeDateTime, DtoSearchParameterDateTimeValue SearchValue) where T : ResourceIndexBase
    {
      var Expression = Search.DateTimePeriodPropertyEqualTo(SearchTypeDateTime.DbPropertyName, SearchValue.Value, CalculateHighDateTimeForRange(SearchValue));
      NewPredicate = NewPredicate.Or(Expression);
      return NewPredicate;
    }

    private static ExpressionStarter<T> PropertyNotEqualToPredicate<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterDateTime SearchTypeDateTime, DtoSearchParameterDateTimeValue SearchValue) where T : ResourceIndexBase
    {
      var Expression = Search.DateTimePeriodPropertyNotEqualTo(SearchTypeDateTime.DbPropertyName, SearchValue.Value, CalculateHighDateTimeForRange(SearchValue));
      NewPredicate = NewPredicate.Or(Expression);
      return NewPredicate;
    }

    private static DateTimeOffset CalculateHighDateTimeForRange(DtoSearchParameterDateTimeValue SearchValue)
    {
      DateTimeOffset HighDateTime = SearchValue.Value;
      if (SearchValue.Precision == Common.Tools.FhirDateTimeSupport.DateTimePrecision.Year)
      {
        HighDateTime = SearchValue.Value.AddYears(1).AddMilliseconds(-1);
      }
      else if (SearchValue.Precision == Common.Tools.FhirDateTimeSupport.DateTimePrecision.Month)
      {
        HighDateTime = SearchValue.Value.AddMonths(1).AddMilliseconds(-1);
      }
      else if (SearchValue.Precision == Common.Tools.FhirDateTimeSupport.DateTimePrecision.Day)
      {
        HighDateTime = SearchValue.Value.AddDays(1).AddMilliseconds(-1);
      }
      else if (SearchValue.Precision == Common.Tools.FhirDateTimeSupport.DateTimePrecision.HourMin)
      {
        HighDateTime = SearchValue.Value.AddMinutes(1).AddMilliseconds(-1);
      }
      else if (SearchValue.Precision == Common.Tools.FhirDateTimeSupport.DateTimePrecision.Sec)
      {
        HighDateTime = SearchValue.Value.AddSeconds(1).AddMilliseconds(-1);
      }
      else if (SearchValue.Precision == Common.Tools.FhirDateTimeSupport.DateTimePrecision.MilliSec)
      {
        HighDateTime = SearchValue.Value;
      }
      else
      {
        throw new System.ComponentModel.InvalidEnumArgumentException(SearchValue.Precision.ToString(), (int)SearchValue.Precision, typeof(Common.Tools.FhirDateTimeSupport.DateTimePrecision));
      }
      return HighDateTime;
    }
  }
}

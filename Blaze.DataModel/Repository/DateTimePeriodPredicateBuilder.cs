using System;
using LinqKit;
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.DataModel.Search;
using Blaze.Common.BusinessEntities.Search;

namespace Blaze.DataModel.Repository
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
                    //NewPredicate = CollectionEqualToPredicate(Search, NewPredicate, SearchTypeDateTime, SearchValue);
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Equal:
                    //NewPredicate = CollectionEqualToPredicate(Search, NewPredicate, SearchTypeDateTime, SearchValue);
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.NotEqual:
                    //NewPredicate = CollectionNotEqualToPredicate(Search, NewPredicate, SearchTypeDateTime, SearchValue);
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Greater:
                    // NewPredicate = NewPredicate.Or(Search.DateTimeCollectionGreaterThan(SearchTypeDateTime.DbPropertyName, SearchValue.Value));
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Less:
                    // NewPredicate = NewPredicate.Or(Search.DateTimeCollectionLessThan(SearchTypeDateTime.DbPropertyName, SearchValue.Value));
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.GreaterOrEqual:
                    // NewPredicate = NewPredicate.Or(Search.DateTimePropertyGreaterThanOrEqualTo(SearchTypeDateTime.DbPropertyName, SearchValue.Value));
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.LessOrEqual:
                    if (SearchValue.Precision != Common.Tools.FhirDateTimeSupport.DateTimePrecision.MilliSec)
                    {
                      // NewPredicate = NewPredicate.Or(Search.DateTimeCollectionLessThanOrEqualTo(SearchTypeDateTime.DbPropertyName, CalculateHighDateTimeForRange(SearchValue)));
                    }
                    else
                    {
                      //NewPredicate = NewPredicate.Or(Search.DateTimeCollectionLessThanOrEqualTo(SearchTypeDateTime.DbPropertyName, SearchValue.Value));
                    }
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
                    NewPredicate = NewPredicate.Or(Search.DateTimePeriodPropertyGreaterThan(SearchTypeDateTime.DbPropertyName, SearchValue.Value));
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Less:
                    // NewPredicate = NewPredicate.Or(Search.DateTimePropertyLessThan(SearchTypeDateTime.DbPropertyName, SearchValue.Value));
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.GreaterOrEqual:
                    if (SearchValue.Precision != Common.Tools.FhirDateTimeSupport.DateTimePrecision.MilliSec)
                    {
                      NewPredicate = NewPredicate.Or(Search.DateTimePeriodPropertyGreaterThanOrEqualTo(SearchTypeDateTime.DbPropertyName, CalculateHighDateTimeForRange(SearchValue)));
                      NewPredicate = NewPredicate.Or(Search.DateTimePeriodPropertyGreaterThanOrEqualTo(SearchTypeDateTime.DbPropertyName, SearchValue.Value));
                    }
                    else
                    {
                      NewPredicate = NewPredicate.Or(Search.DateTimePeriodPropertyGreaterThanOrEqualTo(SearchTypeDateTime.DbPropertyName, SearchValue.Value));
                    }                    
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.LessOrEqual:
                    if (SearchValue.Precision != Common.Tools.FhirDateTimeSupport.DateTimePrecision.MilliSec)
                    {
                      //NewPredicate = NewPredicate.Or(Search.DateTimePropertyLessThanOrEqualTo(SearchTypeDateTime.DbPropertyName, CalculateHighDateTimeForRange(SearchValue)));
                    }
                    else
                    {
                      // NewPredicate = NewPredicate.Or(Search.DateTimePropertyLessThanOrEqualTo(SearchTypeDateTime.DbPropertyName, SearchValue.Value));
                    }
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
                      // NewPredicate = NewPredicate.Or(Search.DateTimeCollectionIsNull(SearchTypeDateTime.DbPropertyName));
                    }
                    else
                    {
                      //NewPredicate = NewPredicate.Or(Search.DateTimeCollectionIsNotNull(SearchTypeDateTime.DbPropertyName));
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

    //private static ExpressionStarter<T> CollectionEqualToPredicate<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterDateTime SearchTypeDateTime, DtoSearchParameterDateTimeValue SearchValue) where T : ResourceIndexBase
    //{
    //  if (SearchValue.Precision != Common.Tools.FhirDateTimeSupport.DateTimePrecision.MilliSec)
    //  {
    //    DateTimeOffset HighDateTime = CalculateHighDateTimeForRange(SearchValue);
    //    var LowExpression = Search.DateTimeCollectionGreaterThanOrEqualTo(SearchTypeDateTime.DbPropertyName, SearchValue.Value);
    //    var HighExpression = Search.DateTimeCollectionLessThan(SearchTypeDateTime.DbPropertyName, HighDateTime);
    //    var HighAndLowPredicate = LinqKit.PredicateBuilder.And<T>(LowExpression, HighExpression);
    //    NewPredicate = NewPredicate.Or(HighAndLowPredicate);
    //    return NewPredicate;
    //  }
    //  else
    //  {
    //    NewPredicate = NewPredicate.Or(Search.DateTimeCollectionAnyEqualTo(SearchTypeDateTime.DbPropertyName, SearchValue.Value));
    //    return NewPredicate;
    //  }
    //}

    //private static ExpressionStarter<T> CollectionNotEqualToPredicate<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterDateTime SearchTypeDateTime, DtoSearchParameterDateTimeValue SearchValue) where T : ResourceIndexBase
    //{
    //  if (SearchValue.Precision != Common.Tools.FhirDateTimeSupport.DateTimePrecision.MilliSec)
    //  {
    //    DateTimeOffset HighDateTime = CalculateHighDateTimeForRange(SearchValue);
    //    var LowExpression = Search.DateTimeCollectionLessThan(SearchTypeDateTime.DbPropertyName, SearchValue.Value);
    //    var HighExpression = Search.DateTimePropertyGreaterThan(SearchTypeDateTime.DbPropertyName, HighDateTime);
    //    var HighAndLowPredicate = LinqKit.PredicateBuilder.Or<T>(LowExpression, HighExpression);
    //    NewPredicate = NewPredicate.Or(HighAndLowPredicate);
    //    return NewPredicate;
    //  }
    //  else
    //  {
    //    NewPredicate = NewPredicate.Or(Search.DateTimeCollectionAnyNotEqualTo(SearchTypeDateTime.DbPropertyName, SearchValue.Value));
    //    return NewPredicate;
    //  }
    //}

    private static ExpressionStarter<T> PropertyEqualToPredicate<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterDateTime SearchTypeDateTime, DtoSearchParameterDateTimeValue SearchValue) where T : ResourceIndexBase
    {
      if (SearchValue.Precision != Common.Tools.FhirDateTimeSupport.DateTimePrecision.MilliSec)
      {
        DateTimeOffset HighDateTime = CalculateHighDateTimeForRange(SearchValue);
        var LowExpression = Search.DateTimePeriodPropertyEqualTo(SearchTypeDateTime.DbPropertyName, SearchValue.Value);
        var HighExpression = Search.DateTimePeriodPropertyEqualTo(SearchTypeDateTime.DbPropertyName, HighDateTime);
        var HighOrLowPredicate = LinqKit.PredicateBuilder.Or(LowExpression, HighExpression);
        NewPredicate = NewPredicate.Or(HighOrLowPredicate);
        return NewPredicate;
      }
      else
      {
        NewPredicate = NewPredicate.Or(Search.DateTimePeriodPropertyEqualTo(SearchTypeDateTime.DbPropertyName, SearchValue.Value));
        return NewPredicate;
      }
    }

    private static ExpressionStarter<T> PropertyNotEqualToPredicate<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterDateTime SearchTypeDateTime, DtoSearchParameterDateTimeValue SearchValue) where T : ResourceIndexBase
    {
      if (SearchValue.Precision != Common.Tools.FhirDateTimeSupport.DateTimePrecision.MilliSec)
      {
        DateTimeOffset HighDateTime = CalculateHighDateTimeForRange(SearchValue);
        var LowExpression = Search.DateTimePeriodPropertyNotEqualTo(SearchTypeDateTime.DbPropertyName, SearchValue.Value);
        var HighExpression = Search.DateTimePeriodPropertyNotEqualTo(SearchTypeDateTime.DbPropertyName, HighDateTime);
        var HighAndLowPredicate = PredicateBuilder.And(LowExpression, HighExpression);
        NewPredicate = NewPredicate.Or(HighAndLowPredicate);
        return NewPredicate;
      }
      else
      {
        NewPredicate = NewPredicate.Or(Search.DateTimePeriodPropertyNotEqualTo(SearchTypeDateTime.DbPropertyName, SearchValue.Value));
        return NewPredicate;
      }
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
        //Can not set for milliseconds dues to equal being a >= and <. We can't take or add more or less than a single
        //millisecond so we always just return the same value for High as the low. Then due to the equal being a >= and < 
        //operation it will always return false.
        //So if the search is at a millisecond precision then we must just do a straight comparison and not a range comparison, i.e (value == index) .
        throw new Exception("Can not calculate high dateTime value with a precision of milliseconds for index search range equality.");
      }
      else
      {
        throw new System.ComponentModel.InvalidEnumArgumentException(SearchValue.Precision.ToString(), (int)SearchValue.Precision, typeof(Common.Tools.FhirDateTimeSupport.DateTimePrecision));
      }
      return HighDateTime;
    }
  }
}

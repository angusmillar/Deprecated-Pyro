using System;
using LinqKit;
using Pyro.DataModel.DatabaseModel.Base;
using Pyro.DataModel.Search;
using Pyro.Common.BusinessEntities.Search;

namespace Pyro.DataModel.Repository
{
  public static class DatePredicateBuilder
  {
    public static ExpressionStarter<T> Build<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterBase SearchItem) where T : ResourceIndexBase
    {
      if (SearchItem is DtoSearchParameterDate)
      {
        var SearchTypeDate = SearchItem as DtoSearchParameterDate;
        foreach (var SearchValue in SearchTypeDate.ValueList)
        {
          switch (SearchTypeDate.Modifier)
          {
            case Common.Enum.FhirSearchEnum.SearchModifierType.None:
              if (SearchTypeDate.IsDbCollection)
              {
                throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of date as there is no date collection indexes.");
              }
              else
              {
                Common.Tools.FhirTimeSupport.DatePrecision Precision = Common.Tools.FhirTimeSupport.DatePrecision.Year;
                switch (SearchValue.Prefix)
                {
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.None:
                    Precision = Common.Tools.FhirTimeSupport.GetIntegerDatePrecision(SearchValue.Value);
                    NewPredicate = EqualToPredicate(Search, NewPredicate, SearchTypeDate, SearchValue, Precision);
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Equal:
                    Precision = Common.Tools.FhirTimeSupport.GetIntegerDatePrecision(SearchValue.Value);
                    NewPredicate = EqualToPredicate(Search, NewPredicate, SearchTypeDate, SearchValue, Precision);
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.NotEqual:
                    Precision = Common.Tools.FhirTimeSupport.GetIntegerDatePrecision(SearchValue.Value);
                    if (Precision != Common.Tools.FhirTimeSupport.DatePrecision.Day)
                    {
                      var HighDate = Common.Tools.FhirTimeSupport.AddToIntegerDate(SearchValue.Value, 1, Precision);
                      var LowExpression = Search.DatePropertyLessThan(SearchTypeDate.DbPropertyName, SearchValue.Value);
                      var HighExpression = Search.DatePropertyGreaterThan(SearchTypeDate.DbPropertyName, HighDate);
                      var HighAndLowPredicate = LinqKit.PredicateBuilder.Or<T>(LowExpression, HighExpression);
                      NewPredicate = NewPredicate.Or(HighAndLowPredicate);
                    }
                    else
                    {
                      NewPredicate = NewPredicate.Or(Search.DatePropertyNotEqualTo(SearchTypeDate.DbPropertyName, SearchValue.Value));
                    }
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Greater:
                    NewPredicate = NewPredicate.Or(Search.DatePropertyGreaterThan(SearchTypeDate.DbPropertyName, SearchValue.Value));
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Less:
                    NewPredicate = NewPredicate.Or(Search.DatePropertyLessThan(SearchTypeDate.DbPropertyName, SearchValue.Value));
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.GreaterOrEqual:
                    NewPredicate = NewPredicate.Or(Search.DatePropertyGreaterThanOrEqualTo(SearchTypeDate.DbPropertyName, SearchValue.Value));
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.LessOrEqual:
                    Precision = Common.Tools.FhirTimeSupport.GetIntegerDatePrecision(SearchValue.Value);
                    if (Precision != Common.Tools.FhirTimeSupport.DatePrecision.Day)
                    {
                      var HighDate = Common.Tools.FhirTimeSupport.AddToIntegerDate(SearchValue.Value, 1, Precision);
                      NewPredicate = NewPredicate.Or(Search.DatePropertyLessThanOrEqualTo(SearchTypeDate.DbPropertyName, HighDate));
                    }
                    else
                    {                       
                      NewPredicate = NewPredicate.Or(Search.DatePropertyLessThanOrEqualTo(SearchTypeDate.DbPropertyName, SearchValue.Value));
                    }
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.StartsAfter:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of date.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.EndsBefore:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of date.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Approximately:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of date.");
                  default:
                    throw new System.ComponentModel.InvalidEnumArgumentException(SearchValue.Prefix.ToString(), (int)SearchValue.Prefix, typeof(Common.Enum.FhirSearchEnum.SearchPrefixType));
                }
              }
              break;
            case Common.Enum.FhirSearchEnum.SearchModifierType.Missing:
              if (SearchTypeDate.IsDbCollection)
              {
                throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of date as there is no date collection indexes.");
              }
              else
              {
                switch (SearchValue.Prefix)
                {
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.None:
                    if (SearchValue.IsMissing)
                    {
                      NewPredicate = NewPredicate.Or(Search.DatePropertyIsNull(SearchTypeDate.DbPropertyName));
                    }
                    else
                    {
                      NewPredicate = NewPredicate.Or(Search.DatePropertyIsNotNull(SearchTypeDate.DbPropertyName));
                    }
                    break;
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Equal:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of date with a Modifier of: {SearchTypeDate.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.NotEqual:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of date with a Modifier of: {SearchTypeDate.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Greater:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of date with a Modifier of: {SearchTypeDate.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Less:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of date with a Modifier of: {SearchTypeDate.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.GreaterOrEqual:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of date with a Modifier of: {SearchTypeDate.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.LessOrEqual:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of date with a Modifier of: {SearchTypeDate.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.StartsAfter:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of date with a Modifier of: {SearchTypeDate.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.EndsBefore:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of date with a Modifier of: {SearchTypeDate.Modifier.ToString()}.");
                  case Common.Enum.FhirSearchEnum.SearchPrefixType.Approximately:
                    throw new FormatException($"The search prefix: {SearchValue.Prefix.ToString()} is not supported for search parameter types of date with a Modifier of: {SearchTypeDate.Modifier.ToString()}.");
                  default:
                    throw new System.ComponentModel.InvalidEnumArgumentException(SearchValue.Prefix.ToString(), (int)SearchValue.Prefix, typeof(Common.Enum.FhirSearchEnum.SearchPrefixType));
                }
              }
              break;
            case Common.Enum.FhirSearchEnum.SearchModifierType.Exact:
              throw new FormatException($"The search modifier: {SearchTypeDate.Modifier.ToString()} is not supported for search parameter types of date.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.Contains:
              throw new FormatException($"The search modifier: {SearchTypeDate.Modifier.ToString()} is not supported for search parameter types of date.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.Text:
              throw new FormatException($"The search modifier: {SearchTypeDate.Modifier.ToString()} is not supported for search parameter types of date.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.Type:
              throw new FormatException($"The search modifier: {SearchTypeDate.Modifier.ToString()} is not supported for search parameter types of date.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.Below:
              throw new FormatException($"The search modifier: {SearchTypeDate.Modifier.ToString()} is not supported for search parameter types of date.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.Above:
              throw new FormatException($"The search modifier: {SearchTypeDate.Modifier.ToString()} is not supported for search parameter types of date.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.In:
              throw new FormatException($"The search modifier: {SearchTypeDate.Modifier.ToString()} is not supported for search parameter types of date.");
            case Common.Enum.FhirSearchEnum.SearchModifierType.NotIn:
              throw new FormatException($"The search modifier: {SearchTypeDate.Modifier.ToString()} is not supported for search parameter types of date.");
            default:
              throw new System.ComponentModel.InvalidEnumArgumentException(SearchTypeDate.Modifier.ToString(), (int)SearchTypeDate.Modifier, typeof(Common.Enum.FhirSearchEnum.SearchModifierType));
          }
        }
      }

      return NewPredicate;
    }

    private static ExpressionStarter<T> EqualToPredicate<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterDate SearchTypeDate, DtoSearchParameterDateValue SearchValue, Common.Tools.FhirTimeSupport.DatePrecision Precision) where T : ResourceIndexBase
    {
      if (Precision != Common.Tools.FhirTimeSupport.DatePrecision.Day)
      {
        var HighDate = Common.Tools.FhirTimeSupport.AddToIntegerDate(SearchValue.Value, 1, Precision);
        var LowExpression = Search.DatePropertyGreaterThanOrEqualTo(SearchTypeDate.DbPropertyName, SearchValue.Value);
        var HighExpression = Search.DatePropertyLessThan(SearchTypeDate.DbPropertyName, HighDate);
        var HighAndLowPredicate = LinqKit.PredicateBuilder.And<T>(LowExpression, HighExpression);
        NewPredicate = NewPredicate.Or(HighAndLowPredicate);
      }
      else
      {
        NewPredicate = NewPredicate.Or(Search.DatePropertyEqualTo(SearchTypeDate.DbPropertyName, SearchValue.Value));
      }

      return NewPredicate;
    }
  }
}

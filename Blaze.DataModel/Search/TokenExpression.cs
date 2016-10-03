using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.Common.Database;
using Blaze.Common.Tools;
using Blaze.DataModel.DatabaseModel.Base;
using System.Linq.Expressions;
using System.Reflection;

namespace Blaze.DataModel.Search
{
  public static class TokenExpression
  {
    public static Expression MatchCodeOnlyExpression(      
      MemberExpression propertyReferenceCode,
      string SearchValueCode)
    {
      var SearchValueReferenceCode = Expression.Constant(SearchValueCode);
      
      //(x.gender_Code == ValueCode)
      var BinaryExpression_ResourceCode_EqualTo_SearchCode = Expression.Equal(propertyReferenceCode, SearchValueReferenceCode);
      
      //(x.gender_Code == ValueCode) And (x.gender_System == ValueSystem)
      Expression BinaryExpression_Final = BinaryExpression_ResourceCode_EqualTo_SearchCode;

      return BinaryExpression_Final;
    }

    public static Expression MatchSystemOnlyExpression(
      MemberExpression propertyReferenceSystem,
      string SearchValueSystem)
    {
      var SearchValueReferenceSystem = Expression.Constant(SearchValueSystem);

      //(x.gender_System == ValueSystem)
      var BinaryExpression_ResourceSystem_EqualTo_SearchSystem = Expression.Equal(propertyReferenceSystem, SearchValueReferenceSystem);
      
      Expression BinaryExpression_Final = BinaryExpression_ResourceSystem_EqualTo_SearchSystem;
      return BinaryExpression_Final;
    }
    
    public static Expression MatchCodeAndSystemExpression(
      MemberExpression propertyReferenceCode,
      string SearchValueCode,
      MemberExpression propertyReferenceSystem,
      string SearchValueSystem)
    {
      var SearchValueReferenceCode = Expression.Constant(SearchValueCode);
      var SearchValueReferenceSystem = Expression.Constant(SearchValueSystem);      

      //(x.gender_Code == ValueCode)
      var BinaryExpression_ResourceCode_EqualTo_SearchCode = Expression.Equal(propertyReferenceCode, SearchValueReferenceCode);

      //(x.gender_System == ValueSystem)
      var BinaryExpression_ResourceSystem_EqualTo_SearchSystem = Expression.Equal(propertyReferenceSystem, SearchValueReferenceSystem);
      

      //(x.gender_Code == ValueCode) And (x.gender_System == ValueSystem)
      Expression BinaryExpression_Final = Expression.And(BinaryExpression_ResourceCode_EqualTo_SearchCode, BinaryExpression_ResourceSystem_EqualTo_SearchSystem);

      return BinaryExpression_Final;
    }

    public static Expression MatchCodeWithNullSystemExpression(
      MemberExpression propertyReferenceCode,
      string SearchValueCode,
      MemberExpression propertyReferenceSystem)
    {
      var SearchValueReferenceCode = Expression.Constant(SearchValueCode);      
      var ConstantReferenceNull = Expression.Constant(null);

      //(x.gender_Code == ValueCode)
      var BinaryExpression_ResourceCode_EqualTo_SearchCode = Expression.Equal(propertyReferenceCode, SearchValueReferenceCode);

      //(x.gender_System == null)
      var BinaryExpression_ResourceSystem_IsNull = Expression.Equal(propertyReferenceSystem, ConstantReferenceNull);

      //(x.gender_Code == ValueCode) And (x.gender_System == null)
      Expression BinaryExpression_Final = Expression.And(BinaryExpression_ResourceCode_EqualTo_SearchCode, BinaryExpression_ResourceSystem_IsNull);

      return BinaryExpression_Final;
    }

  }


}

// ============== Examples ================================================================================
////(x.date_DateTimeOffsetLow == Null)
//var BinaryExpression_ResourceLow_IsNull = Expression.Equal(propertyReferenceLow, ConstantReferenceNull);

////(x.date_DateTimeOffsetLow != Null)
//var BinaryExpression_ResourceLow_IsNotNull = Expression.NotEqual(propertyReferenceLow, ConstantReferenceNull);

////(x.date_DateTimeOffsetHigh == Null)
//var BinaryExpression_ResourceHigh_IsNull = Expression.Equal(propertyReferenceHigh, ConstantReferenceNull);

////(x.date_DateTimeOffsetHigh != Null)
//var BinaryExpression_ResourceHigh_IsNotNull = Expression.NotEqual(propertyReferenceHigh, ConstantReferenceNull);

////(x.date_DateTimeOffsetLow <= ValueLow)
//var BinaryExpression_ResourceLow_IsLowerThanOrEqual_SearchLow = Expression.LessThanOrEqual(propertyReferenceLow, SearchValueReferenceLow);

////(x.date_DateTimeOffsetLow < ValueLow)
//var BinaryExpression_ResourceLow_IsLowerThan_SearchLow = Expression.LessThan(propertyReferenceLow, SearchValueReferenceLow);

////(x.date_DateTimeOffsetLow >= ValueLow)
//var BinaryExpression_ResourceLow_IsHigherThanOrEqualTo_SearchLow = Expression.GreaterThanOrEqual(propertyReferenceLow, SearchValueReferenceLow);

////(x.date_DateTimeOffsetLow > ValueLow)
//var BinaryExpression_ResourceLow_IsHigherThan_SearchLow = Expression.GreaterThan(propertyReferenceLow, SearchValueReferenceLow);

////(x.date_DateTimeOffsetLow <= ValueHigh)
//var BinaryExpression_ResourceLow_IsLowerThanOrEqualTo_SearchHigh = Expression.LessThanOrEqual(propertyReferenceLow, SearchValueReferenceHigh);

////(x.date_DateTimeOffsetLow < ValueHigh)
//var BinaryExpression_ResourceLow_IsLowerThan_SearchHigh = Expression.LessThan(propertyReferenceLow, SearchValueReferenceHigh);

////(x.date_DateTimeOffsetLow >= ValueHigh)
//var BinaryExpression_ResourceLow_IsHigherThanOrEqualTo_SearchHigh = Expression.GreaterThanOrEqual(propertyReferenceLow, SearchValueReferenceHigh);

////(x.date_DateTimeOffsetLow > ValueHigh)
//var BinaryExpression_ResourceLow_IsHigherThan_SearchHigh = Expression.GreaterThan(propertyReferenceLow, SearchValueReferenceHigh);

////(x.date_DateTimeOffsetHigh <= ValueHigh)
//var BinaryExpression_ResourceHigh_IsLowerThanOrEqualTo_SearchHigh = Expression.LessThanOrEqual(propertyReferenceHigh, SearchValueReferenceHigh);

////(x.date_DateTimeOffsetHigh < ValueHigh)
//var BinaryExpression_ResourceHigh_IsLowerThan_SearchHigh = Expression.LessThan(propertyReferenceHigh, SearchValueReferenceHigh);

////(x.date_DateTimeOffsetHigh >= ValueHigh)
//var BinaryExpression_ResourceHigh_IsHigherThanOrEqualTo_SearchHigh = Expression.GreaterThanOrEqual(propertyReferenceHigh, SearchValueReferenceHigh);

////(x.date_DateTimeOffsetHigh >= ValueHigh)
//var BinaryExpression_ResourceHigh_IsHigherThan_SearchHigh = Expression.GreaterThan(propertyReferenceHigh, SearchValueReferenceHigh);

////(x.date_DateTimeOffsetHigh <= ValueLow)
//var BinaryExpression_ResourceHigh_IsLowerThanOrEqualTo_SearchLow = Expression.LessThanOrEqual(propertyReferenceHigh, SearchValueReferenceLow);

////(x.date_DateTimeOffsetHigh < ValueLow)
//var BinaryExpression_ResourceHigh_IsLowerThan_SearchLow = Expression.LessThan(propertyReferenceHigh, SearchValueReferenceLow);

////(x.date_DateTimeOffsetHigh >= ValueLow)
//var BinaryExpression_ResourceHigh_IsHigherThanOrEqualTo_SearchLow = Expression.GreaterThanOrEqual(propertyReferenceHigh, SearchValueReferenceLow);

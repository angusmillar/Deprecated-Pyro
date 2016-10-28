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
  public static class DateTimePeriodExpression
  {
    public static Expression EqualToExpression(
      string Property,
      MemberExpression propertyReferenceLow,
      ConstantExpression SearchValueReferenceLow,
      MemberExpression propertyReferenceHigh,
      ConstantExpression SearchValueReferenceHigh)
    {
      var ConstantReferenceNull = Expression.Constant(null);

      //(x.date_DateTimeOffsetHigh >= ValueLow)
      var BinaryExpression_ResourceHigh_IsHigherThanOrEqualTo_SearchLow = Expression.GreaterThanOrEqual(propertyReferenceHigh, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetHigh <= ValueHigh)
      var BinaryExpression_ResourceHigh_IsLowerThanOrEqualTo_SearchHigh = Expression.LessThanOrEqual(propertyReferenceHigh, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetHigh >= ValueHigh)
      var BinaryExpression_ResourceHigh_IsHigherThanOrEqualTo_SearchHigh = Expression.GreaterThanOrEqual(propertyReferenceHigh, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetLow <= ValueLow)
      var BinaryExpression_ResourceLow_IsLowerThanOrEqual_SearchLow = Expression.LessThanOrEqual(propertyReferenceLow, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetLow >= ValueLow)
      var BinaryExpression_ResourceLow_IsHigherThanOrEqualTo_SearchLow = Expression.GreaterThanOrEqual(propertyReferenceLow, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetLow <= ValueHigh)
      var BinaryExpression_ResourceLow_IsLowerThanOrEqualTo_SearchHigh = Expression.LessThanOrEqual(propertyReferenceLow, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetHigh == Null)
      var BinaryExpression_ResourceHigh_IsNull = Expression.Equal(propertyReferenceHigh, ConstantReferenceNull);

      //(x.date_DateTimeOffsetLow == Null)
      var BinaryExpression_ResourceLow_IsNull = Expression.Equal(propertyReferenceLow, ConstantReferenceNull);


      //BinaryExpression_A
      //(x.date_DateTimeOffsetHigh >= ValueLow) And (x.date_DateTimeOffsetHigh <= ValueHigh)
      var BinaryExpression_A = Expression.And(BinaryExpression_ResourceHigh_IsHigherThanOrEqualTo_SearchLow, BinaryExpression_ResourceHigh_IsLowerThanOrEqualTo_SearchHigh);

      //BinaryExpression_B
      //(x.date_DateTimeOffsetHigh >= ValueHigh && x.date_DateTimeOffsetLow <= ValueLow)
      var BinaryExpression_B = Expression.And(BinaryExpression_ResourceHigh_IsHigherThanOrEqualTo_SearchHigh, BinaryExpression_ResourceLow_IsLowerThanOrEqual_SearchLow);

      //BinaryExpression_C
      //(x.date_DateTimeOffsetLow >= ValueLow && x.date_DateTimeOffsetLow <= ValueHigh )
      var BinaryExpression_C = Expression.And(BinaryExpression_ResourceLow_IsHigherThanOrEqualTo_SearchLow, BinaryExpression_ResourceLow_IsLowerThanOrEqualTo_SearchHigh);

      //BinaryExpression_D
      //(x.date_DateTimeOffsetLow >= ValueLow && x.date_DateTimeOffsetHigh <= ValueHigh )
      var BinaryExpression_D = Expression.And(BinaryExpression_ResourceLow_IsHigherThanOrEqualTo_SearchLow, BinaryExpression_ResourceHigh_IsLowerThanOrEqualTo_SearchHigh);

      //BinaryExpression_E
      //(x.date_DateTimeOffsetHigh == Null && x.date_DateTimeOffsetLow <= ValueHigh )
      var BinaryExpression_E = Expression.And(BinaryExpression_ResourceHigh_IsNull, BinaryExpression_ResourceLow_IsLowerThanOrEqualTo_SearchHigh);

      //BinaryExpression_F
      //(x.date_DateTimeOffsetLow == Null && x.date_DateTimeOffsetHigh >= ValueLow )
      var BinaryExpression_F = Expression.And(BinaryExpression_ResourceLow_IsNull, BinaryExpression_ResourceHigh_IsHigherThanOrEqualTo_SearchHigh);


      //(BinaryExpression_A Or BinaryExpression_B) 
      var BinaryExpression_AA = Expression.Or(BinaryExpression_A, BinaryExpression_B);
      var BinaryExpression_BB = Expression.Or(BinaryExpression_C, BinaryExpression_D);
      var BinaryExpression_CC = Expression.Or(BinaryExpression_E, BinaryExpression_F);

      Expression BinaryExpression_AAA = Expression.Or(BinaryExpression_AA, BinaryExpression_BB);
      Expression BinaryExpression_Final = Expression.Or(BinaryExpression_AAA, BinaryExpression_CC);
      return BinaryExpression_Final;
    }

    public static Expression NotEqualToExpression(
      string Property,
      MemberExpression propertyReferenceLow,
      ConstantExpression SearchValueReferenceLow,
      MemberExpression propertyReferenceHigh,
      ConstantExpression SearchValueReferenceHigh)
    {
      var ConstantReferenceNull = Expression.Constant(null);

      //(x.date_DateTimeOffsetHigh == Null)
      var BinaryExpression_ResourceHigh_IsNull = Expression.Equal(propertyReferenceHigh, ConstantReferenceNull);

      //(x.date_DateTimeOffsetLow > ValueHigh)
      var BinaryExpression_ResourceLow_IsHigherThan_SearchHigh = Expression.GreaterThan(propertyReferenceLow, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetHigh < ValueLow)
      var BinaryExpression_ResourceHigh_IsLowerThan_SearchLow = Expression.LessThan(propertyReferenceHigh, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetLow == Null)
      var BinaryExpression_ResourceLow_IsNull = Expression.Equal(propertyReferenceLow, ConstantReferenceNull);

      //(x.date_DateTimeOffsetLow > ValueLow)
      var BinaryExpression_ResourceLow_IsHigherThan_SearchLow = Expression.GreaterThan(propertyReferenceLow, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetHigh < ValueHigh)
      var BinaryExpression_ResourceHigh_IsLowerThan_SearchHigh = Expression.LessThan(propertyReferenceHigh, SearchValueReferenceHigh);


      //BinaryExpression_A
      //(x.date_DateTimeOffsetHigh == Null && x.date_DateTimeOffsetLow > ValueHigh)
      var BinaryExpression_A = Expression.And(BinaryExpression_ResourceHigh_IsNull, BinaryExpression_ResourceLow_IsHigherThan_SearchHigh);

      //BinaryExpression_B
      //(x.date_DateTimeOffsetLow == Null && x.date_DateTimeOffsetHigh < ValueLow)
      var BinaryExpression_B = Expression.And(BinaryExpression_ResourceLow_IsNull, BinaryExpression_ResourceHigh_IsLowerThan_SearchLow);


      //BinaryExpression_D
      //(x.date_DateTimeOffsetHigh < ValueLow && x.date_DateTimeOffsetHigh < ValueHigh)
      var BinaryExpression_D = Expression.And(BinaryExpression_ResourceHigh_IsLowerThan_SearchLow, BinaryExpression_ResourceHigh_IsLowerThan_SearchHigh);

      //BinaryExpression_C
      //(x.date_DateTimeOffsetLow > ValueHigh && x.date_DateTimeOffsetLow > ValueLow)
      var BinaryExpression_C = Expression.And(BinaryExpression_ResourceLow_IsHigherThan_SearchHigh, BinaryExpression_ResourceLow_IsHigherThan_SearchLow);


      //(BinaryExpression_A Or BinaryExpression_B) 
      var BinaryExpression_AA = Expression.Or(BinaryExpression_A, BinaryExpression_B);
      var BinaryExpression_BB = Expression.Or(BinaryExpression_C, BinaryExpression_D);
      Expression BinaryExpression_Final = Expression.Or(BinaryExpression_AA, BinaryExpression_BB);

      return BinaryExpression_Final;
    }

    public static Expression GreaterThanOrEqualToExpression(
      string Property,
      MemberExpression propertyReferenceLow,
      ConstantExpression SearchValueReferenceLow,
      MemberExpression propertyReferenceHigh,
      ConstantExpression SearchValueReferenceHigh)
    {
      var ConstantReferenceNull = Expression.Constant(null);

      //(x.date_DateTimeOffsetHigh == Null)
      var BinaryExpression_ResourceHigh_IsNull = Expression.Equal(propertyReferenceHigh, ConstantReferenceNull);

      //(x.date_DateTimeOffsetLow == Null)
      var BinaryExpression_ResourceLow_IsNull = Expression.Equal(propertyReferenceLow, ConstantReferenceNull);


      //(x.date_DateTimeOffsetHigh >= ValueLow)
      var BinaryExpression_ResourceHigh_IsHigherThanOrEqualTo_SearchLow = Expression.GreaterThanOrEqual(propertyReferenceHigh, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetLow != Null)
      var BinaryExpression_ResourceLow_IsNotNull = Expression.NotEqual(propertyReferenceLow, ConstantReferenceNull);

      //(x.date_DateTimeOffsetLow >= ValueLow)
      var BinaryExpression_ResourceLow_IsHigherThanOrEqualTo_SearchLow = Expression.GreaterThanOrEqual(propertyReferenceLow, SearchValueReferenceLow);


      //BinaryExpression_A
      //(x.date_DateTimeOffsetLow == Null && x.date_DateTimeOffsetHigh >= ValueLow)
      var BinaryExpression_A = Expression.And(BinaryExpression_ResourceLow_IsNull, BinaryExpression_ResourceHigh_IsHigherThanOrEqualTo_SearchLow);

      //BinaryExpression_B
      //(x.date_DateTimeOffsetHigh == Null && x.date_DateTimeOffsetLow != Null)
      var BinaryExpression_B = Expression.And(BinaryExpression_ResourceHigh_IsNull, BinaryExpression_ResourceLow_IsNotNull);

      //BinaryExpression_C
      //(x.date_DateTimeOffsetHigh >= ValueHigh)

      //(BinaryExpression_A Or BinaryExpression_B) 
      var BinaryExpression_AA = Expression.Or(BinaryExpression_A, BinaryExpression_B);
      var BinaryExpression_Final = Expression.Or(BinaryExpression_AA, BinaryExpression_ResourceLow_IsHigherThanOrEqualTo_SearchLow);

      return BinaryExpression_Final;
    }

    public static Expression GreaterThanExpression(
      string Property,
      MemberExpression propertyReferenceLow,
      ConstantExpression SearchValueReferenceLow,
      MemberExpression propertyReferenceHigh,
      ConstantExpression SearchValueReferenceHigh)
    {
      ConstantExpression ConstantReferenceNull = Expression.Constant(null);

      //(x.date_DateTimeOffsetHigh == Null)
      var BinaryExpression_ResourceHigh_IsNull = Expression.Equal(propertyReferenceHigh, ConstantReferenceNull);

      //(x.date_DateTimeOffsetLow == Null)
      var BinaryExpression_ResourceLow_IsNull = Expression.Equal(propertyReferenceLow, ConstantReferenceNull);

      //(x.date_DateTimeOffsetLow != Null)
      var BinaryExpression_ResourceLow_IsNotNull = Expression.NotEqual(propertyReferenceLow, ConstantReferenceNull);

      //(x.date_DateTimeOffsetHigh >= ValueHigh)
      var BinaryExpression_ResourceHigh_IsHigherThan_SearchHigh = Expression.GreaterThan(propertyReferenceHigh, SearchValueReferenceHigh);


      //BinaryExpression_A
      //(x.date_DateTimeOffsetLow == Null && x.date_DateTimeOffsetHigh > ValueHigh)
      var BinaryExpression_A = Expression.And(BinaryExpression_ResourceLow_IsNull, BinaryExpression_ResourceHigh_IsHigherThan_SearchHigh);

      //BinaryExpression_B
      //(x.date_DateTimeOffsetHigh == Null && x.date_DateTimeOffsetLow != Null)
      var BinaryExpression_B = Expression.And(BinaryExpression_ResourceHigh_IsNull, BinaryExpression_ResourceLow_IsNotNull);

      //BinaryExpression_C
      //(x.date_DateTimeOffsetHigh > ValueHigh)

      //(BinaryExpression_A Or BinaryExpression_B) 
      var BinaryExpression_AA = Expression.Or(BinaryExpression_A, BinaryExpression_B);
      var BinaryExpression_Final = Expression.Or(BinaryExpression_AA, BinaryExpression_ResourceHigh_IsHigherThan_SearchHigh);

      return BinaryExpression_Final;
    }

    public static Expression LessThanOrEqualToExpression(
      string Property,
      MemberExpression propertyReferenceLow,
      ConstantExpression SearchValueReferenceLow,
      MemberExpression propertyReferenceHigh,
      ConstantExpression SearchValueReferenceHigh)
    {
      var ConstantReferenceNull = Expression.Constant(null);

      //(x.date_DateTimeOffsetHigh == Null)
      var BinaryExpression_ResourceHigh_IsNull = Expression.Equal(propertyReferenceHigh, ConstantReferenceNull);

      //(x.date_DateTimeOffsetLow == Null)
      var BinaryExpression_ResourceLow_IsNull = Expression.Equal(propertyReferenceLow, ConstantReferenceNull);

      //(x.date_DateTimeOffsetHigh <= ValueHigh)
      var BinaryExpression_ResourceHigh_IsLowerThanOrEqualTo_SearchHigh = Expression.LessThanOrEqual(propertyReferenceHigh, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetLow <= ValueHigh)
      var BinaryExpression_ResourceLow_IsLowerThanOrEqualTo_SearchHigh = Expression.LessThanOrEqual(propertyReferenceLow, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetLow <= ValueLow)
      var BinaryExpression_ResourceLow_IsLowerThanOrEqual_SearchLow = Expression.LessThanOrEqual(propertyReferenceLow, SearchValueReferenceLow);


      //BinaryExpression_A
      //(x.date_DateTimeOffsetLow == Null && x.date_DateTimeOffsetHigh <= ValueHigh)
      var BinaryExpression_A = Expression.And(BinaryExpression_ResourceLow_IsNull, BinaryExpression_ResourceHigh_IsLowerThanOrEqualTo_SearchHigh);

      //BinaryExpression_B
      //(x.date_DateTimeOffsetHigh == Null && x.date_DateTimeOffsetLow <= ValueHigh)
      var BinaryExpression_B = Expression.And(BinaryExpression_ResourceHigh_IsNull, BinaryExpression_ResourceLow_IsLowerThanOrEqualTo_SearchHigh);

      //BinaryExpression_C
      //(x.date_DateTimeOffsetLow <= ValueLow)


      //(BinaryExpression_A Or BinaryExpression_B) 
      var BinaryExpression_AA = Expression.Or(BinaryExpression_A, BinaryExpression_B);
      var BinaryExpression_Final = Expression.Or(BinaryExpression_AA, BinaryExpression_ResourceLow_IsLowerThanOrEqual_SearchLow);

      return BinaryExpression_Final;
    }


    public static Expression LessThanExpression(
      string Property,
      MemberExpression propertyReferenceLow,
      ConstantExpression SearchValueReferenceLow,
      MemberExpression propertyReferenceHigh,
      ConstantExpression SearchValueReferenceHigh)
    {
      var ConstantReferenceNull = Expression.Constant(null);

      //(x.date_DateTimeOffsetHigh == Null)
      var BinaryExpression_ResourceHigh_IsNull = Expression.Equal(propertyReferenceHigh, ConstantReferenceNull);

      //(x.date_DateTimeOffsetLow == Null)
      var BinaryExpression_ResourceLow_IsNull = Expression.Equal(propertyReferenceLow, ConstantReferenceNull);

      //(x.date_DateTimeOffsetLow != Null)
      var BinaryExpression_ResourceLow_IsNotNull = Expression.NotEqual(propertyReferenceLow, ConstantReferenceNull);

      //(x.date_DateTimeOffsetHigh < ValueLow)
      var BinaryExpression_ResourceHigh_IsLowerThan_SearchLow = Expression.LessThan(propertyReferenceHigh, SearchValueReferenceLow);


      //BinaryExpression_A
      //(x.date_DateTimeOffsetLow == Null && x.date_DateTimeOffsetHigh < ValueLow)
      var BinaryExpression_A = Expression.And(BinaryExpression_ResourceLow_IsNull, BinaryExpression_ResourceHigh_IsLowerThan_SearchLow);

      //BinaryExpression_B
      //(x.date_DateTimeOffsetHigh < ValueLow)
      var BinaryExpression_B = Expression.And(BinaryExpression_ResourceHigh_IsNull, BinaryExpression_ResourceLow_IsNotNull);


      //(BinaryExpression_A Or BinaryExpression_B) 
      var BinaryExpression_Final = Expression.Or(BinaryExpression_A, BinaryExpression_ResourceHigh_IsLowerThan_SearchLow);

      return BinaryExpression_Final;
    }


  }


}

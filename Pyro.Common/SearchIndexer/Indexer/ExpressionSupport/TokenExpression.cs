using System;
using System.Linq.Expressions;

namespace Pyro.Common.SearchIndexer.Indexer.ExpressionSupport
{
  public static class TokenExpression
  {
    public static Expression MatchCodeOnlyExpression(
      MemberExpression propertyReferenceCode,
      ConstantExpression SearchValueReferenceCode)
    {
      //(x.gender_Code == ValueCode)
      var BinaryExpression_ResourceCode_EqualTo_SearchCode = Expression.Equal(propertyReferenceCode, SearchValueReferenceCode);

      //(x.gender_Code == ValueCode) And (x.gender_System == ValueSystem)
      Expression BinaryExpression_Final = BinaryExpression_ResourceCode_EqualTo_SearchCode;

      return BinaryExpression_Final;
    }

    public static Expression MatchSystemOnlyExpression(
      MemberExpression propertyReferenceSystem,
      ConstantExpression SearchValueReferenceSystem)
    {
      //(x.gender_System == ValueSystem)
      var BinaryExpression_ResourceSystem_EqualTo_SearchSystem = Expression.Equal(propertyReferenceSystem, SearchValueReferenceSystem);

      Expression BinaryExpression_Final = BinaryExpression_ResourceSystem_EqualTo_SearchSystem;
      return BinaryExpression_Final;
    }

    public static Expression MatchCodeAndSystemExpression(
      MemberExpression propertyReferenceCode,
      ConstantExpression SearchValueReferenceCode,
      MemberExpression propertyReferenceSystem,
      ConstantExpression SearchValueReferenceSystem)
    {
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
      ConstantExpression SearchValueReferenceCode,
      MemberExpression propertyReferenceSystem)
    {
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

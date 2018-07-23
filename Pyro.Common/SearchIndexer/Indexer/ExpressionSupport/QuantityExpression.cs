using System.Linq.Expressions;

namespace Pyro.Common.SearchIndexer.Indexer.ExpressionSupport
{
  public static class QuantityExpression
  {
    public static Expression SystemCodeOrUnit_EqualTo_Expression(
      MemberExpression propertyReferenceSystem,
      MemberExpression propertyReferenceCode,
      MemberExpression propertyReferenceUnit,
      ConstantExpression SearchValueReferenceSystem,
      ConstantExpression SearchValueReferenceCode)
    {
      //(x.length_System == SearchSystem)
      var BinaryExpression_ResourceSystem_IsEqualTo_SearchSystem = Expression.Equal(propertyReferenceSystem, SearchValueReferenceSystem);

      //(x.length_Code == SearchCode)
      var BinaryExpression_ResourceCode_IsEqualTo_SearchCode = Expression.Equal(propertyReferenceCode, SearchValueReferenceCode);

      //(x.length_Unit == SearchUnit)
      var BinaryExpression_ResourceUnit_IsEqualTo_SearchCode = Expression.Equal(propertyReferenceUnit, SearchValueReferenceCode);

      Expression SystemCodeOrUnitExpression = null;
      if (string.IsNullOrWhiteSpace((string)SearchValueReferenceSystem.Value))
      {
        //(x.length_Code == SearchCode) Or (x.length_Unit == SearchCode)
        SystemCodeOrUnitExpression = Expression.Or(BinaryExpression_ResourceCode_IsEqualTo_SearchCode, BinaryExpression_ResourceUnit_IsEqualTo_SearchCode);
      }
      else
      {
        //(x.length_System == SearchSystem) And (x.length_Code == SearchCode)
        SystemCodeOrUnitExpression = Expression.And(BinaryExpression_ResourceSystem_IsEqualTo_SearchSystem, BinaryExpression_ResourceCode_IsEqualTo_SearchCode);
      }
      return SystemCodeOrUnitExpression;
    }

    public static Expression SystemCodeOrUnit_NotEqualTo_Expression(
      MemberExpression propertyReferenceSystem,
      MemberExpression propertyReferenceCode,
      MemberExpression propertyReferenceUnit,
      ConstantExpression SearchValueReferenceSystem,
      ConstantExpression SearchValueReferenceCode)
    {
      //(x.length_System == SearchSystem)
      var BinaryExpression_ResourceSystem_IsEqualTo_SearchSystem = Expression.NotEqual(propertyReferenceSystem, SearchValueReferenceSystem);

      //(x.length_Code == SearchCode)
      var BinaryExpression_ResourceCode_IsEqualTo_SearchCode = Expression.NotEqual(propertyReferenceCode, SearchValueReferenceCode);

      //(x.length_Unit == SearchUnit)
      var BinaryExpression_ResourceUnit_IsEqualTo_SearchCode = Expression.NotEqual(propertyReferenceUnit, SearchValueReferenceCode);

      Expression SystemCodeOrUnitExpression = null;
      if (string.IsNullOrWhiteSpace((string)SearchValueReferenceSystem.Value))
      {
        //(x.length_Code != SearchCode) And (x.length_Unit != SearchCode)
        SystemCodeOrUnitExpression = Expression.And(BinaryExpression_ResourceCode_IsEqualTo_SearchCode, BinaryExpression_ResourceUnit_IsEqualTo_SearchCode);
      }
      else
      {
        //(x.length_System != SearchSystem) And (x.length_Code != SearchCode)
        SystemCodeOrUnitExpression = Expression.Or(BinaryExpression_ResourceSystem_IsEqualTo_SearchSystem, BinaryExpression_ResourceCode_IsEqualTo_SearchCode);
      }
      return SystemCodeOrUnitExpression;
    }

    public static Expression SystemCodeOrUnit_IsNotNull_Expression(
     MemberExpression propertyReferenceSystem,
     MemberExpression propertyReferenceCode,
     MemberExpression propertyReferenceUnit)
    {
      var ConstantReferenceNull = Expression.Constant(null);

      //(x.length_System == SearchSystem)
      var BinaryExpression_ResourceSystem_IsNotEqualTo_Null = Expression.NotEqual(propertyReferenceSystem, ConstantReferenceNull);

      //(x.length_Code == SearchCode)
      var BinaryExpression_ResourceCode_IsNotEqualTo_Null = Expression.NotEqual(propertyReferenceCode, ConstantReferenceNull);

      //(x.length_Unit == SearchUnit)
      var BinaryExpression_ResourceUnit_IsNotEqualTo_NUll = Expression.NotEqual(propertyReferenceUnit, ConstantReferenceNull);

      Expression BinaryExpression_A = Expression.And(BinaryExpression_ResourceSystem_IsNotEqualTo_Null, BinaryExpression_ResourceCode_IsNotEqualTo_Null);
      Expression BinaryExpression_Final = Expression.AndAlso(BinaryExpression_A, BinaryExpression_ResourceUnit_IsNotEqualTo_NUll);

      return BinaryExpression_Final;

    }

    public static Expression SystemCodeOrUnit_IsNull_Expression(
      MemberExpression propertyReferenceSystem,
      MemberExpression propertyReferenceCode,
      MemberExpression propertyReferenceUnit)
    {
      var ConstantReferenceNull = Expression.Constant(null);

      //(x.length_System == SearchSystem)
      var BinaryExpression_ResourceSystem_IsNotEqualTo_Null = Expression.Equal(propertyReferenceSystem, ConstantReferenceNull);

      //(x.length_Code == SearchCode)
      var BinaryExpression_ResourceCode_IsNotEqualTo_Null = Expression.Equal(propertyReferenceCode, ConstantReferenceNull);

      //(x.length_Unit == SearchUnit)
      var BinaryExpression_ResourceUnit_IsNotEqualTo_NUll = Expression.Equal(propertyReferenceUnit, ConstantReferenceNull);

      Expression BinaryExpression_A = Expression.And(BinaryExpression_ResourceSystem_IsNotEqualTo_Null, BinaryExpression_ResourceCode_IsNotEqualTo_Null);
      Expression BinaryExpression_Final = Expression.AndAlso(BinaryExpression_A, BinaryExpression_ResourceUnit_IsNotEqualTo_NUll);

      return BinaryExpression_Final;

    }
    
  }

}


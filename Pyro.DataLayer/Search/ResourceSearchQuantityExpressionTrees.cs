using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Database;
using Pyro.Common.Tools;
using Pyro.DataLayer.DbModel.EntityBase;
using System.Linq.Expressions;
using System.Reflection;
using Pyro.Common.Search.SearchParameterEntity;
using Pyro.Common.SearchIndexer.Indexer.ExpressionSupport;

namespace Pyro.DataLayer.Search
{
  public class ResourceSearchQuantityExpressionTrees<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
  {

    ////---- Quantity Index Expressions ------------------------------------------------------    
    private ParameterExpression InnerParameter = null;
    private ParameterExpression IndexListParameter = null;

    private BinaryExpression BinaryExpressionIdEquals = null;

    private MemberExpression propertyReferenceComparator = null;
    private MemberExpression propertyReferenceNumber = null;

    private MemberExpression propertyReferenceSystem = null;
    private MemberExpression propertyReferenceCode = null;
    private MemberExpression propertyReferenceUnit = null;

    private ConstantExpression SearchValueReferenceLow = null;
    private ConstantExpression SearchValueReferenceMid = null;
    private ConstantExpression SearchValueReferenceHigh = null;

    private ConstantExpression SearchValueReferenceSystem = null;
    private ConstantExpression SearchValueReferenceCode = null;

    public void Setup(int Id, decimal LowNumber, decimal MidNumber, decimal HighNumber, string System, string Code)
    {
      InnerParameter = Expression.Parameter(typeof(ResIndexQuantityType), "c");
      IndexListParameter = Expression.Parameter(typeof(ResCurrentType), "x");

      var CommonExpression = new ResourceSearchCommonExpressionTrees<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>();
      BinaryExpressionIdEquals = CommonExpression.SearchParameterIdBinaryExpression(Id, InnerParameter);

      propertyReferenceComparator = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Comparator);
      propertyReferenceNumber = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Quantity);

      propertyReferenceSystem = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.System);
      propertyReferenceCode = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Code);
      propertyReferenceUnit = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Unit);

      SearchValueReferenceLow = Expression.Constant(LowNumber, typeof(decimal?));
      SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal?));
      SearchValueReferenceHigh = Expression.Constant(HighNumber, typeof(decimal?));

      SearchValueReferenceSystem = Expression.Constant(System);
      SearchValueReferenceCode = Expression.Constant(Code);
    }

    private Expression<Func<ResCurrentType, bool>> FinaliseExpression(Expression Final_InnerExpression)
    {
      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, Final_InnerExpression);  
      Expression<Func<ResIndexQuantityType, bool>> InnerFunction = Expression.Lambda<Func<ResIndexQuantityType, bool>>(IdAndExpression, InnerParameter);
      var CommonExpression = new ResourceSearchCommonExpressionTrees<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>();
      MethodCallExpression MethodAnyCall = CommonExpression.IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResCurrentType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResCurrentType, bool>> QuantityCollectionAnyEqualTo(int Id, decimal LowNumber, decimal MidNumber, decimal HighNumber, string System, string Code)
    {
      Setup(Id, LowNumber, MidNumber, HighNumber, System, Code);

      //Build Inner Expression          
      //If the System & Code is null then only search on the value
      if (SearchValueReferenceSystem.Value == null && SearchValueReferenceCode.Value == null)
      {
        Expression EqualToExpression = DecimalExpression.EqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceLow, SearchValueReferenceMid, SearchValueReferenceHigh);
        return FinaliseExpression(EqualToExpression);
      }
      else
      {
        //If only one of them system and code is null then search with them as null which will return notyhing 
        Expression EqualToExpression = DecimalExpression.EqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceLow, SearchValueReferenceMid, SearchValueReferenceHigh);
        Expression SystemCodeOrUnit_EqualTo_Expression = QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(propertyReferenceSystem, propertyReferenceCode, propertyReferenceUnit, SearchValueReferenceSystem, SearchValueReferenceCode);
        Expression Final_InnerExpression = Expression.AndAlso(EqualToExpression, SystemCodeOrUnit_EqualTo_Expression);
        return FinaliseExpression(Final_InnerExpression);
      }      
    }

    public Expression<Func<ResCurrentType, bool>> QuantityCollectionAllNotEqualTo(int Id, decimal LowNumber, decimal MidNumber, decimal HighNumber, string System, string Code)
    {
      Setup(Id, LowNumber, MidNumber, HighNumber, System, Code);

      //Build Inner Expression
      //Non of the values are equal to.      
      if (SearchValueReferenceSystem.Value == null && SearchValueReferenceCode.Value == null)
      {
        Expression NotEqualToExpression = DecimalExpression.NotEqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceLow, SearchValueReferenceMid, SearchValueReferenceHigh);
        return FinaliseExpression(NotEqualToExpression);
      }
      else
      {
        Expression NotEqualToExpression = DecimalExpression.NotEqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceLow, SearchValueReferenceMid, SearchValueReferenceHigh);
        Expression SystemCodeOrUnit_NotEqualTo_Expression = QuantityExpression.SystemCodeOrUnit_NotEqualTo_Expression(propertyReferenceSystem, propertyReferenceCode, propertyReferenceUnit, SearchValueReferenceSystem, SearchValueReferenceCode);
        Expression Final_InnerExpression = Expression.OrElse(NotEqualToExpression, SystemCodeOrUnit_NotEqualTo_Expression);
        return FinaliseExpression(Final_InnerExpression);
      }
    }

    public Expression<Func<ResCurrentType, bool>> QuantityCollectionAnyGreaterThan(int Id, decimal MidNumber, string System, string Code)
    {
      Setup(Id, 0, MidNumber, 0, System, Code);

      //Build Inner Expression      
      if (SearchValueReferenceSystem.Value == null && SearchValueReferenceCode.Value == null)
      {
        Expression GreaterThanExpression = DecimalExpression.GreaterThanExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);
        return FinaliseExpression(GreaterThanExpression);
      }
      else
      {
        Expression GreaterThanExpression = DecimalExpression.GreaterThanExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);
        Expression SystemCodeOrUnit_EqualTo_Expression = QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(propertyReferenceSystem, propertyReferenceCode, propertyReferenceUnit, SearchValueReferenceSystem, SearchValueReferenceCode);
        Expression Final_InnerExpression = Expression.AndAlso(GreaterThanExpression, SystemCodeOrUnit_EqualTo_Expression);
        return FinaliseExpression(Final_InnerExpression);
      }            
    }

    public Expression<Func<ResCurrentType, bool>> QuantityCollectionAnyGreaterThanOrEqualTo(int Id, decimal MidNumber, string System, string Code)
    {
      Setup(Id, 0, MidNumber, 0, System, Code);

      //Build Inner Expression
      if (SearchValueReferenceSystem.Value == null && SearchValueReferenceCode.Value == null)
      {
        Expression GreaterThanOrEqualToExpression = DecimalExpression.GreaterThanOrEqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);
        return FinaliseExpression(GreaterThanOrEqualToExpression);
      }
      else
      {
        Expression GreaterThanOrEqualToExpression = DecimalExpression.GreaterThanOrEqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);
        Expression SystemCodeOrUnit_EqualTo_Expression = QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(propertyReferenceSystem, propertyReferenceCode, propertyReferenceUnit, SearchValueReferenceSystem, SearchValueReferenceCode);
        Expression Final_InnerExpression = Expression.AndAlso(GreaterThanOrEqualToExpression, SystemCodeOrUnit_EqualTo_Expression);
        return FinaliseExpression(Final_InnerExpression);
      }
    }

    public Expression<Func<ResCurrentType, bool>> QuantityCollectionAnyLessThan(int Id, decimal MidNumber, string System, string Code)
    {
      Setup(Id, 0, MidNumber, 0, System, Code);

      //Build Inner Expression
      if (SearchValueReferenceSystem.Value == null && SearchValueReferenceCode.Value == null)
      {
        Expression LessThanExpression = DecimalExpression.LessThanExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);
        return FinaliseExpression(LessThanExpression);
      }
      else
      {
        Expression LessThanExpression = DecimalExpression.LessThanExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);
        Expression SystemCodeOrUnit_EqualTo_Expression = QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(propertyReferenceSystem, propertyReferenceCode, propertyReferenceUnit, SearchValueReferenceSystem, SearchValueReferenceCode);
        Expression Final_InnerExpression = Expression.AndAlso(LessThanExpression, SystemCodeOrUnit_EqualTo_Expression);
        return FinaliseExpression(Final_InnerExpression);
      }      
    }

    public Expression<Func<ResCurrentType, bool>> QuantityCollectionAnyLessThanOrEqualTo(int Id, decimal MidNumber, string System, string Code)
    {
      Setup(Id, 0, MidNumber, 0, System, Code);

      //Build Inner Expression
      if (SearchValueReferenceSystem.Value == null && SearchValueReferenceCode.Value == null)
      {
        Expression LessThanOrEqualToExpression = DecimalExpression.LessThanOrEqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);
        return FinaliseExpression(LessThanOrEqualToExpression);
      }
      else
      {
        Expression LessThanOrEqualToExpression = DecimalExpression.LessThanOrEqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);
        Expression SystemCodeOrUnit_EqualTo_Expression = QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(propertyReferenceSystem, propertyReferenceCode, propertyReferenceUnit, SearchValueReferenceSystem, SearchValueReferenceCode);
        Expression Final_InnerExpression = Expression.AndAlso(LessThanOrEqualToExpression, SystemCodeOrUnit_EqualTo_Expression);
        return FinaliseExpression(Final_InnerExpression);
      }      
    }
    
    ///---- General Index Expressions ------------------------------------------------------

    //private BinaryExpression SearchParameterIdBinaryExpression(int Id, ParameterExpression InnerParameter)
    //{
    //  MemberExpression InnerPropertyId = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.ServiceSearchParameterId);
    //  ConstantExpression InnerValueId = Expression.Constant(Id);
    //  return Expression.Equal(InnerPropertyId, InnerValueId);
    //}

    //private MethodCallExpression IndexListAnyMethodCallExpression<IndexType>(ParameterExpression IndexListParameter, Expression<Func<IndexType, bool>> InnerFunction)
    //    where IndexType : ModelBase
    //{
    //  //var type = typeof(ResCurrentType);
    //  //below is wrong need to reslve correct list because index list no longer exsists
    //  string DbPropertyName = string.Empty;
    //  DbPropertyName = ResolveDbIndexListPropertyName<IndexType>();

    //  MemberExpression IndexListProperty = Expression.Property(IndexListParameter, typeof(ResCurrentType).GetProperty(DbPropertyName));
    //  MethodInfo MethodAny = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(IndexType));
    //  MethodCallExpression MethodAnyCall = Expression.Call(MethodAny, IndexListProperty, InnerFunction);
    //  return MethodAnyCall;
    //}

    //private static string ResolveDbIndexListPropertyName<IndexType>() where IndexType : ModelBase
    //{
    //  string DbPropertyName;
    //  if (typeof(IndexType) == typeof(ResIndexStringType))
    //  {
    //    DbPropertyName = StaticDatabaseInfo.BaseResourceConstatnts.IndexStringList;
    //  }
    //  else if (typeof(IndexType) == typeof(ResIndexTokenType))
    //  {
    //    DbPropertyName = StaticDatabaseInfo.BaseResourceConstatnts.IndexTokenList;
    //  }
    //  else if (typeof(IndexType) == typeof(ResIndexUriType))
    //  {
    //    DbPropertyName = StaticDatabaseInfo.BaseResourceConstatnts.IndexUriList;
    //  }
    //  else if (typeof(IndexType) == typeof(ResIndexReferenceType))
    //  {
    //    DbPropertyName = StaticDatabaseInfo.BaseResourceConstatnts.IndexReferenceList;
    //  }
    //  else if (typeof(IndexType) == typeof(ResIndexQuantityType))
    //  {
    //    DbPropertyName = StaticDatabaseInfo.BaseResourceConstatnts.IndexQuantityList;
    //  }
    //  else if (typeof(IndexType) == typeof(ResIndexDateTimeType))
    //  {
    //    DbPropertyName = StaticDatabaseInfo.BaseResourceConstatnts.IndexDateTimeList;
    //  }
    //  else
    //  {
    //    throw new Exception("Unknown type for resource index list. ");
    //  }

    //  return DbPropertyName;
    //}
  }

}

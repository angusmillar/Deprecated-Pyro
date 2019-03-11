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
  public class ResourceSearchCommonExpressionTrees<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
  {
    
    ///---- General Index Expressions ------------------------------------------------------

    internal BinaryExpression SearchParameterIdBinaryExpression(int Id, ParameterExpression InnerParameter)
    {
      MemberExpression InnerPropertyId = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.ServiceSearchParameterId);
      ConstantExpression InnerValueId = Expression.Constant(Id);
      return Expression.Equal(InnerPropertyId, InnerValueId);
    }

    private Expression<Func<ResIndexReferenceType, bool>> ContainsFhirID(ParameterExpression Param, string[] FhirIdArray)
    {
      //FhirIdArray.Contains(c.ReferenceFhirId)
      MethodInfo methodInfo = typeof(List<string>).GetMethod("Contains", new Type[] { typeof(string) });
      var list = Expression.Constant(FhirIdArray.ToList());
      var value = Expression.Property(Param, StaticDatabaseInfo.BaseResourceIndexConstatnts.ReferenceFhirId);
      var body = Expression.Call(list, methodInfo, value);
      return Expression.Lambda<Func<ResIndexReferenceType, bool>>(body, Param);
    }

    internal MethodCallExpression IndexListAnyMethodCallExpression<IndexType>(ParameterExpression IndexListParameter, Expression<Func<IndexType, bool>> InnerFunction)
        where IndexType : ModelBase
    {
      //var type = typeof(ResCurrentType);
      //below is wrong need to reslve correct list because index list no longer exsists
      string DbPropertyName = string.Empty;
      DbPropertyName = ResolveDbIndexListPropertyName<IndexType>();

      MemberExpression IndexListProperty = Expression.Property(IndexListParameter, typeof(ResCurrentType).GetProperty(DbPropertyName));
      MethodInfo MethodAny = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(IndexType));
      MethodCallExpression MethodAnyCall = Expression.Call(MethodAny, IndexListProperty, InnerFunction);
      return MethodAnyCall;
    }

    public Expression<Func<ResCurrentType, bool>> SearchParameterIdIsNotNull<IndexType>(int Id)
      where IndexType : ModelBase
    {
      //(x => x.IndexList.Any(c => c.ServiceSearchParameterId == Id).Count > 0);      
      return SearchParameterIdNull<IndexType>(Id, false);
    }

    public Expression<Func<ResCurrentType, bool>> SearchParameterIsNull<IndexType>(int Id)
      where IndexType : ModelBase
    {
      //(x => x.IndexList.Any(c => c.ServiceSearchParameterId == Id).Count == 0);      
      return SearchParameterIdNull<IndexType>(Id, true);
    }

    private Expression<Func<ResCurrentType, bool>> SearchParameterIdNull<IndexType>(int Id, bool IsNull)
      where IndexType : ModelBase
    {
      //IsNull = true
      //(x => x.IndexList.Any(c => c.ServiceSearchParameterId == Id) == true);      
      //IsNull = false
      //(x => x.IndexList.Any(c => c.ServiceSearchParameterId == Id) == false);                  
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResCurrentType), "x");
      ParameterExpression InnerParameter = Expression.Parameter(typeof(IndexType), "c");

      BinaryExpression BinaryIdExpression = SearchParameterIdBinaryExpression(Id, InnerParameter);

      Expression<Func<IndexType, bool>> InnerFunction = Expression.Lambda<Func<IndexType, bool>>(BinaryIdExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);

      ConstantExpression constantReference = null;
      if (IsNull)
      {
        constantReference = Expression.Constant(false);
      }
      else
      {
        constantReference = Expression.Constant(true);
      }

      BinaryExpression BinaryExpression = Expression.Equal(MethodAnyCall, constantReference);

      return Expression.Lambda<Func<ResCurrentType, bool>>(BinaryExpression, IndexListParameter);
    }

    private static string ResolveDbIndexListPropertyName<IndexType>() where IndexType : ModelBase
    {
      string DbPropertyName;
      if (typeof(IndexType) == typeof(ResIndexStringType))
      {
        DbPropertyName = StaticDatabaseInfo.BaseResourceConstatnts.IndexStringList;
      }
      else if (typeof(IndexType) == typeof(ResIndexTokenType))
      {
        DbPropertyName = StaticDatabaseInfo.BaseResourceConstatnts.IndexTokenList;
      }
      else if (typeof(IndexType) == typeof(ResIndexUriType))
      {
        DbPropertyName = StaticDatabaseInfo.BaseResourceConstatnts.IndexUriList;
      }
      else if (typeof(IndexType) == typeof(ResIndexReferenceType))
      {
        DbPropertyName = StaticDatabaseInfo.BaseResourceConstatnts.IndexReferenceList;
      }
      else if (typeof(IndexType) == typeof(ResIndexQuantityType))
      {
        DbPropertyName = StaticDatabaseInfo.BaseResourceConstatnts.IndexQuantityList;
      }
      else if (typeof(IndexType) == typeof(ResIndexDateTimeType))
      {
        DbPropertyName = StaticDatabaseInfo.BaseResourceConstatnts.IndexDateTimeList;
      }
      else
      {
        throw new Exception("Unknown type for resource index list. ");
      }

      return DbPropertyName;
    }
  }

}

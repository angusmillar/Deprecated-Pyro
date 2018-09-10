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
  public class ResourceSearchExpressionTrees<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
  {

    ////---- String Property Expressions ------------------------------------------------------
    public Expression<Func<ResCurrentType, bool>> StringCollectionAnyEqualTo(int Id, string Value)
    {
      //(x => x.IndexList.Any(c => c.String.Equals("héllo UPPER") & c.ServiceSearchParameterId == Id);      
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResIndexStringType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResCurrentType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression InnerPropertyString = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.String);
      ConstantExpression InnerValueString = Expression.Constant(StringSupport.ToLowerAndRemoveDiacritics(Value.Trim()));
      MethodInfo MethodEquals = typeof(String).GetMethods().Where(m => m.Name == "Equals" && m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == typeof(String)).Single();
      MethodCallExpression MethodEqualsCall = Expression.Call(InnerPropertyString, MethodEquals, InnerValueString);

      BinaryExpression IdAndExpression = Expression.And(BinaryExpressionIdEquals, MethodEqualsCall);

      Expression<Func<ResIndexStringType, bool>> InnerFunction = Expression.Lambda<Func<ResIndexStringType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResCurrentType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResCurrentType, bool>> StringCollectionAnyStartsOrEndsWith(int Id, string Value)
    {
      //(x => x.IndexList.Any(c => c.String.StartsWith("Mill") & c.ServiceSearchParameterId == Id);
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResIndexStringType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResCurrentType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression InnerPropertyString = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.String);
      ConstantExpression InnerValueString = Expression.Constant(StringSupport.ToLowerAndRemoveDiacritics(Value.Trim()));

      MethodInfo MethodStartsWith = typeof(String).GetMethods().Where(m => m.Name == "StartsWith" && m.GetParameters().Length == 1).Single();
      MethodCallExpression MethodStartsWithCall = Expression.Call(InnerPropertyString, MethodStartsWith, InnerValueString);

      MethodInfo MethodEndsWith = typeof(String).GetMethods().Where(m => m.Name == "EndsWith" && m.GetParameters().Length == 1).Single();
      MethodCallExpression MethodEndsWithCall = Expression.Call(InnerPropertyString, MethodEndsWith, InnerValueString);

      var StartsWithOrEndsWithExpression = Expression.OrElse(MethodStartsWithCall, MethodEndsWithCall);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, StartsWithOrEndsWithExpression);

      Expression<Func<ResIndexStringType, bool>> InnerFunction = Expression.Lambda<Func<ResIndexStringType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      //MethodCallExpression MethodAnyCall = IndexStringListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResCurrentType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResCurrentType, bool>> StringCollectionAnyContains(int Id, string Value)
    {
      //(x => x.IndexList.Any(c => c.String.Contains("Mill") & c.ServiceSearchParameterId == Id);
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResIndexStringType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResCurrentType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression InnerPropertyString = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.String);
      ConstantExpression InnerValueString = Expression.Constant(StringSupport.ToLowerAndRemoveDiacritics(Value.Trim()));

      MethodInfo MethodContains = typeof(String).GetMethods().Where(m => m.Name == "Contains" && m.GetParameters().Length == 1).Single();
      MethodCallExpression MethodContainsCall = Expression.Call(InnerPropertyString, MethodContains, InnerValueString);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, MethodContainsCall);

      Expression<Func<ResIndexStringType, bool>> InnerFunction = Expression.Lambda<Func<ResIndexStringType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      //MethodCallExpression MethodAnyCall = IndexStringListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResCurrentType, bool>>(MethodAnyCall, IndexListParameter);
    }

    ////---- _lastUpdated Property Expressions ------------------------------------------------------

    public Expression<Func<ResCurrentType, bool>> LastUpdatedPropertyGreaterThan(DateTimeOffset Value)
    {
      //(x => x.birthdate_DateTimeOffset > TestDate);
      ParameterExpression MainParameter = Expression.Parameter(typeof(ResCurrentType), "x");
      string DbPropertyName = StaticDatabaseInfo.BaseResourceConstatnts.LastUpdated;
      MemberExpression LastUpdatedProperty = Expression.Property(MainParameter, typeof(ResCurrentType).GetProperty(DbPropertyName));
      var constantReference = Expression.Constant(Value, typeof(DateTimeOffset));
      var BinaryExpression = Expression.GreaterThan(LastUpdatedProperty, constantReference);
      return Expression.Lambda<Func<ResCurrentType, bool>>(BinaryExpression, new[] { MainParameter });
    }

    public Expression<Func<ResCurrentType, bool>> LastUpdatedPropertyGreaterThanOrEqualTo(DateTimeOffset Value)
    {
      //(x => x.birthdate_DateTimeOffset >= TestDate);
      ParameterExpression MainParameter = Expression.Parameter(typeof(ResCurrentType), "x");
      string DbPropertyName = StaticDatabaseInfo.BaseResourceConstatnts.LastUpdated;
      MemberExpression LastUpdatedProperty = Expression.Property(MainParameter, typeof(ResCurrentType).GetProperty(DbPropertyName));
      var constantReference = Expression.Constant(Value, typeof(DateTimeOffset));
      var BinaryExpression = Expression.GreaterThanOrEqual(LastUpdatedProperty, constantReference);
      return Expression.Lambda<Func<ResCurrentType, bool>>(BinaryExpression, new[] { MainParameter });
    }

    public Expression<Func<ResCurrentType, bool>> LastUpdatedPropertyLessThan(DateTimeOffset Value)
    {
      //(x => x.birthdate_DateTimeOffset < TestDate);
      ParameterExpression MainParameter = Expression.Parameter(typeof(ResCurrentType), "x");
      string DbPropertyName = StaticDatabaseInfo.BaseResourceConstatnts.LastUpdated;
      MemberExpression LastUpdatedProperty = Expression.Property(MainParameter, typeof(ResCurrentType).GetProperty(DbPropertyName));
      var constantReference = Expression.Constant(Value, typeof(DateTimeOffset));
      var BinaryExpression = Expression.LessThan(LastUpdatedProperty, constantReference);
      return Expression.Lambda<Func<ResCurrentType, bool>>(BinaryExpression, new[] { MainParameter });
    }

    public Expression<Func<ResCurrentType, bool>> LastUpdatedPropertyLessThanOrEqualTo(DateTimeOffset Value)
    {
      //(x => x.birthdate_DateTimeOffset <= TestDate);
      ParameterExpression MainParameter = Expression.Parameter(typeof(ResCurrentType), "x");
      string DbPropertyName = StaticDatabaseInfo.BaseResourceConstatnts.LastUpdated;
      MemberExpression LastUpdatedProperty = Expression.Property(MainParameter, typeof(ResCurrentType).GetProperty(DbPropertyName));
      var constantReference = Expression.Constant(Value, typeof(DateTimeOffset));
      var BinaryExpression = Expression.LessThanOrEqual(LastUpdatedProperty, constantReference);
      return Expression.Lambda<Func<ResCurrentType, bool>>(BinaryExpression, new[] { MainParameter });
    }

    ////---- NEW DateTime Property Expressions ------------------------------------------------------

    public Expression<Func<ResCurrentType, bool>> DateTimePeriodCollectionAnyEqualTo(int Id, DateTimeOffset? SearchValueLow, DateTimeOffset? SearchValueHigh)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResIndexDateTimeType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResCurrentType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression propertyReferenceLow = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.LowUtcDateTime);
      MemberExpression propertyReferenceHigh = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.HighUtcDateTime);

      ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow?.UtcDateTime, typeof(DateTime?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh?.UtcDateTime, typeof(DateTime?));

      //Build Inner Expression
      Expression EqualToExpression = DateTimePeriodExpression.EqualToExpression(propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, EqualToExpression);

      Expression<Func<ResIndexDateTimeType, bool>> InnerFunction = Expression.Lambda<Func<ResIndexDateTimeType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      //MethodCallExpression MethodAnyCall = IndexDateTimeListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResCurrentType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResCurrentType, bool>> DateTimePeriodCollectionAnyNotEqualTo(int Id, DateTimeOffset? SearchValueLow, DateTimeOffset? SearchValueHigh)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResIndexDateTimeType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResCurrentType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression propertyReferenceLow = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.LowUtcDateTime);
      MemberExpression propertyReferenceHigh = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.HighUtcDateTime);

      ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow?.UtcDateTime, typeof(DateTime?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh?.UtcDateTime, typeof(DateTime?));

      //Build Inner Expression
      Expression NotEqualToExpression = DateTimePeriodExpression.NotEqualToExpression(propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, NotEqualToExpression);

      Expression<Func<ResIndexDateTimeType, bool>> InnerFunction = Expression.Lambda<Func<ResIndexDateTimeType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      //MethodCallExpression MethodAnyCall = IndexDateTimeListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResCurrentType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResCurrentType, bool>> DateTimePeriodCollectionGreaterThanOrEqualTo(int Id, DateTimeOffset? SearchValueLow, DateTimeOffset? SearchValueHigh)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResIndexDateTimeType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResCurrentType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression propertyReferenceLow = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.LowUtcDateTime);
      MemberExpression propertyReferenceHigh = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.HighUtcDateTime);

      ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow?.UtcDateTime, typeof(DateTime?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh?.UtcDateTime, typeof(DateTime?));

      //Build Inner Expression
      Expression GreaterThanOrEqualToExpression = DateTimePeriodExpression.GreaterThanOrEqualToExpression(propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, GreaterThanOrEqualToExpression);

      Expression<Func<ResIndexDateTimeType, bool>> InnerFunction = Expression.Lambda<Func<ResIndexDateTimeType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      //MethodCallExpression MethodAnyCall = IndexDateTimeListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResCurrentType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResCurrentType, bool>> DateTimePeriodCollectionGreaterThan(int Id, DateTimeOffset? SearchValueLow, DateTimeOffset? SearchValueHigh)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResIndexDateTimeType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResCurrentType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression propertyReferenceLow = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.LowUtcDateTime);
      MemberExpression propertyReferenceHigh = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.HighUtcDateTime);

      ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow?.UtcDateTime, typeof(DateTime?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh?.UtcDateTime, typeof(DateTime?));

      //Build Inner Expression
      Expression GreaterThanExpression = DateTimePeriodExpression.GreaterThanExpression(propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, GreaterThanExpression);

      Expression<Func<ResIndexDateTimeType, bool>> InnerFunction = Expression.Lambda<Func<ResIndexDateTimeType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      //MethodCallExpression MethodAnyCall = IndexDateTimeListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResCurrentType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResCurrentType, bool>> DateTimePeriodCollectionLessThan(int Id, DateTimeOffset? SearchValueLow, DateTimeOffset? SearchValueHigh)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResIndexDateTimeType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResCurrentType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression propertyReferenceLow = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.LowUtcDateTime);
      MemberExpression propertyReferenceHigh = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.HighUtcDateTime);

      ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow?.UtcDateTime, typeof(DateTime?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh?.UtcDateTime, typeof(DateTime?));

      //Build Inner Expression
      Expression LessThanExpression = DateTimePeriodExpression.LessThanExpression(propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, LessThanExpression);

      Expression<Func<ResIndexDateTimeType, bool>> InnerFunction = Expression.Lambda<Func<ResIndexDateTimeType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      //MethodCallExpression MethodAnyCall = IndexDateTimeListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResCurrentType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResCurrentType, bool>> DateTimePeriodCollectionLessThanOrEqualTo(int Id, DateTimeOffset? SearchValueLow, DateTimeOffset? SearchValueHigh)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResIndexDateTimeType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResCurrentType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression propertyReferenceLow = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.LowUtcDateTime);
      MemberExpression propertyReferenceHigh = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.HighUtcDateTime);

      ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow?.UtcDateTime, typeof(DateTime?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh?.UtcDateTime, typeof(DateTime?));

      //Build Inner Expression
      Expression LessThanOrEqualToExpression = DateTimePeriodExpression.LessThanOrEqualToExpression(propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, LessThanOrEqualToExpression);

      Expression<Func<ResIndexDateTimeType, bool>> InnerFunction = Expression.Lambda<Func<ResIndexDateTimeType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      //MethodCallExpression MethodAnyCall = IndexDateTimeListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResCurrentType, bool>>(MethodAnyCall, IndexListParameter);
    }



    //////---- OLD DateTime Property Expressions ------------------------------------------------------

    //public Expression<Func<ResCurrentType, bool>> DateTimePeriodCollectionAnyEqualTo(int Id, DateTimeOffset? SearchValueLow, DateTimeOffset? SearchValueHigh)
    //{
    //  ParameterExpression InnerParameter = Expression.Parameter(typeof(ResIndexDateTimeType), "c");
    //  ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResCurrentType), "x");

    //  BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

    //  MemberExpression propertyReferenceLow = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetLow);
    //  MemberExpression propertyReferenceHigh = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetHigh);

    //  ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
    //  ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

    //  //Build Inner Expression
    //  Expression EqualToExpression = DateTimePeriodExpression.EqualToExpression(propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

    //  var IdAndExpression = Expression.And(BinaryExpressionIdEquals, EqualToExpression);

    //  Expression<Func<ResIndexDateTimeType, bool>> InnerFunction = Expression.Lambda<Func<ResIndexDateTimeType, bool>>(IdAndExpression, InnerParameter);

    //  MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
    //  //MethodCallExpression MethodAnyCall = IndexDateTimeListAnyMethodCallExpression(IndexListParameter, InnerFunction);
    //  return Expression.Lambda<Func<ResCurrentType, bool>>(MethodAnyCall, IndexListParameter);
    //}

    //public Expression<Func<ResCurrentType, bool>> DateTimePeriodCollectionAnyNotEqualTo(int Id, DateTimeOffset? SearchValueLow, DateTimeOffset? SearchValueHigh)
    //{
    //  ParameterExpression InnerParameter = Expression.Parameter(typeof(ResIndexDateTimeType), "c");
    //  ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResCurrentType), "x");

    //  BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

    //  MemberExpression propertyReferenceLow = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetLow);
    //  MemberExpression propertyReferenceHigh = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetHigh);

    //  ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
    //  ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

    //  //Build Inner Expression
    //  Expression NotEqualToExpression = DateTimePeriodExpression.NotEqualToExpression(propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

    //  var IdAndExpression = Expression.And(BinaryExpressionIdEquals, NotEqualToExpression);

    //  Expression<Func<ResIndexDateTimeType, bool>> InnerFunction = Expression.Lambda<Func<ResIndexDateTimeType, bool>>(IdAndExpression, InnerParameter);

    //  MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
    //  //MethodCallExpression MethodAnyCall = IndexDateTimeListAnyMethodCallExpression(IndexListParameter, InnerFunction);
    //  return Expression.Lambda<Func<ResCurrentType, bool>>(MethodAnyCall, IndexListParameter);
    //}

    //public Expression<Func<ResCurrentType, bool>> DateTimePeriodCollectionGreaterThanOrEqualTo(int Id, DateTimeOffset? SearchValueLow, DateTimeOffset? SearchValueHigh)
    //{
    //  ParameterExpression InnerParameter = Expression.Parameter(typeof(ResIndexDateTimeType), "c");
    //  ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResCurrentType), "x");

    //  BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

    //  MemberExpression propertyReferenceLow = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetLow);
    //  MemberExpression propertyReferenceHigh = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetHigh);

    //  ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
    //  ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

    //  //Build Inner Expression
    //  Expression GreaterThanOrEqualToExpression = DateTimePeriodExpression.GreaterThanOrEqualToExpression(propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

    //  var IdAndExpression = Expression.And(BinaryExpressionIdEquals, GreaterThanOrEqualToExpression);

    //  Expression<Func<ResIndexDateTimeType, bool>> InnerFunction = Expression.Lambda<Func<ResIndexDateTimeType, bool>>(IdAndExpression, InnerParameter);

    //  MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
    //  //MethodCallExpression MethodAnyCall = IndexDateTimeListAnyMethodCallExpression(IndexListParameter, InnerFunction);
    //  return Expression.Lambda<Func<ResCurrentType, bool>>(MethodAnyCall, IndexListParameter);
    //}

    //public Expression<Func<ResCurrentType, bool>> DateTimePeriodCollectionGreaterThan(int Id, DateTimeOffset? SearchValueLow, DateTimeOffset? SearchValueHigh)
    //{
    //  ParameterExpression InnerParameter = Expression.Parameter(typeof(ResIndexDateTimeType), "c");
    //  ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResCurrentType), "x");

    //  BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

    //  MemberExpression propertyReferenceLow = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetLow);
    //  MemberExpression propertyReferenceHigh = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetHigh);

    //  ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
    //  ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

    //  //Build Inner Expression
    //  Expression GreaterThanExpression = DateTimePeriodExpression.GreaterThanExpression(propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

    //  var IdAndExpression = Expression.And(BinaryExpressionIdEquals, GreaterThanExpression);

    //  Expression<Func<ResIndexDateTimeType, bool>> InnerFunction = Expression.Lambda<Func<ResIndexDateTimeType, bool>>(IdAndExpression, InnerParameter);

    //  MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
    //  //MethodCallExpression MethodAnyCall = IndexDateTimeListAnyMethodCallExpression(IndexListParameter, InnerFunction);
    //  return Expression.Lambda<Func<ResCurrentType, bool>>(MethodAnyCall, IndexListParameter);
    //}

    //public Expression<Func<ResCurrentType, bool>> DateTimePeriodCollectionLessThan(int Id, DateTimeOffset? SearchValueLow, DateTimeOffset? SearchValueHigh)
    //{
    //  ParameterExpression InnerParameter = Expression.Parameter(typeof(ResIndexDateTimeType), "c");
    //  ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResCurrentType), "x");

    //  BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

    //  MemberExpression propertyReferenceLow = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetLow);
    //  MemberExpression propertyReferenceHigh = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetHigh);

    //  ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
    //  ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

    //  //Build Inner Expression
    //  Expression LessThanExpression = DateTimePeriodExpression.LessThanExpression(propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

    //  var IdAndExpression = Expression.And(BinaryExpressionIdEquals, LessThanExpression);

    //  Expression<Func<ResIndexDateTimeType, bool>> InnerFunction = Expression.Lambda<Func<ResIndexDateTimeType, bool>>(IdAndExpression, InnerParameter);

    //  MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
    //  //MethodCallExpression MethodAnyCall = IndexDateTimeListAnyMethodCallExpression(IndexListParameter, InnerFunction);
    //  return Expression.Lambda<Func<ResCurrentType, bool>>(MethodAnyCall, IndexListParameter);
    //}

    //public Expression<Func<ResCurrentType, bool>> DateTimePeriodCollectionLessThanOrEqualTo(int Id, DateTimeOffset? SearchValueLow, DateTimeOffset? SearchValueHigh)
    //{
    //  ParameterExpression InnerParameter = Expression.Parameter(typeof(ResIndexDateTimeType), "c");
    //  ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResCurrentType), "x");

    //  BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

    //  MemberExpression propertyReferenceLow = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetLow);
    //  MemberExpression propertyReferenceHigh = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetHigh);

    //  ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
    //  ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

    //  //Build Inner Expression
    //  Expression LessThanOrEqualToExpression = DateTimePeriodExpression.LessThanOrEqualToExpression(propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

    //  var IdAndExpression = Expression.And(BinaryExpressionIdEquals, LessThanOrEqualToExpression);

    //  Expression<Func<ResIndexDateTimeType, bool>> InnerFunction = Expression.Lambda<Func<ResIndexDateTimeType, bool>>(IdAndExpression, InnerParameter);

    //  MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
    //  //MethodCallExpression MethodAnyCall = IndexDateTimeListAnyMethodCallExpression(IndexListParameter, InnerFunction);
    //  return Expression.Lambda<Func<ResCurrentType, bool>>(MethodAnyCall, IndexListParameter);
    //}

    ////---- Token Property Expressions ------------------------------------------------------

    public Expression<Func<ResCurrentType, bool>> MainResourceFhirIdAny(string FhirId)
    {
      ParameterExpression MainParameter = Expression.Parameter(typeof(ResCurrentType), "x");

      string DbPropertyName = StaticDatabaseInfo.BaseResourceConstatnts.FhirId;
      MemberExpression FhirIdProperty = Expression.Property(MainParameter, typeof(ResCurrentType).GetProperty(DbPropertyName));

      ConstantExpression SearchValueReferenceCode = Expression.Constant(FhirId);
      Expression E_InnerExpression = TokenExpression.MatchCodeOnlyExpression(FhirIdProperty, SearchValueReferenceCode);

      return Expression.Lambda<Func<ResCurrentType, bool>>(E_InnerExpression, new[] { MainParameter });
    }

    public Expression<Func<ResCurrentType, bool>> TokenCollectionAnyEqualTo(int Id, string Code, string System, SearchParameterTokenValue.TokenSearchType TokenSearchType)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResIndexTokenType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResCurrentType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression propertyReferenceCode = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Code);
      MemberExpression propertyReferenceSystem = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.System);

      if (Code != null)
      {
        Code = StringSupport.ToLowerFast(Code);
      }
      if (System != null)
      {
        System = StringSupport.ToLowerFast(System);
      }
      ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);
      ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);

      //Build Inner Expression
      Expression E_InnerExpression = null;
      switch (TokenSearchType)
      {
        case SearchParameterTokenValue.TokenSearchType.None:
          throw new Exception("Server error: DtoSearchParameterTokenValue.TokenSearchType was set to None.");
        case SearchParameterTokenValue.TokenSearchType.MatchCodeOnly:
          E_InnerExpression = TokenExpression.MatchCodeOnlyExpression(propertyReferenceCode, SearchValueReferenceCode);
          break;
        case SearchParameterTokenValue.TokenSearchType.MatchSystemOnly:
          E_InnerExpression = TokenExpression.MatchSystemOnlyExpression(propertyReferenceSystem, SearchValueReferenceSystem);
          break;
        case SearchParameterTokenValue.TokenSearchType.MatchCodeAndSystem:
          E_InnerExpression = TokenExpression.MatchCodeAndSystemExpression(propertyReferenceCode, SearchValueReferenceCode, propertyReferenceSystem, SearchValueReferenceSystem);
          break;
        case SearchParameterTokenValue.TokenSearchType.MatchCodeWithNullSystem:
          E_InnerExpression = TokenExpression.MatchCodeWithNullSystemExpression(propertyReferenceCode, SearchValueReferenceCode, propertyReferenceSystem);
          break;
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(TokenSearchType.ToString(), (int)TokenSearchType, typeof(SearchParameterTokenValue.TokenSearchType));
      }

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, E_InnerExpression);

      Expression<Func<ResIndexTokenType, bool>> InnerFunction = Expression.Lambda<Func<ResIndexTokenType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResCurrentType, bool>>(MethodAnyCall, IndexListParameter);
    }

    ////---- Number Property Expressions ------------------------------------------------------
    public Expression<Func<ResCurrentType, bool>> NumberCollectionAnyEqualTo(int Id, decimal LowNumber, decimal MidNumber, decimal HighNumber)
    {
      return NumberCollectionAllEqual(Id, LowNumber, MidNumber, HighNumber, Hl7.Fhir.Model.SearchParameter.SearchComparator.Eq);
    }

    public Expression<Func<ResCurrentType, bool>> NumberCollectionAllNotEqualTo(int Id, decimal LowNumber, decimal MidNumber, decimal HighNumber)
    {
      return NumberCollectionAllEqual(Id, LowNumber, MidNumber, HighNumber, Hl7.Fhir.Model.SearchParameter.SearchComparator.Ne);
    }

    private Expression<Func<ResCurrentType, bool>> NumberCollectionAllEqual(int Id, decimal LowNumber, decimal MidNumber, decimal HighNumber, Hl7.Fhir.Model.SearchParameter.SearchComparator SearchComparator)
    {
      if (SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Eq || SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Ne)
      {
        ParameterExpression InnerParameter = Expression.Parameter(typeof(ResIndexQuantityType), "c");
        ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResCurrentType), "x");

        BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

        MemberExpression propertyReferenceComparator = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Comparator);
        MemberExpression propertyReferenceNumber = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Quantity);

        ConstantExpression SearchValueReferenceLow = Expression.Constant(LowNumber, typeof(decimal?));
        ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal?));
        ConstantExpression SearchValueReferenceHigh = Expression.Constant(HighNumber, typeof(decimal?));

        Expression EqualToExpression = null;
        if (SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Eq)
        {
          EqualToExpression = DecimalExpression.EqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceLow, SearchValueReferenceMid, SearchValueReferenceHigh);
        }
        else if (SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Ne)
        {
          EqualToExpression = DecimalExpression.NotEqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceLow, SearchValueReferenceMid, SearchValueReferenceHigh);
        }

        var IdAndExpression = Expression.And(BinaryExpressionIdEquals, EqualToExpression);

        Expression<Func<ResIndexQuantityType, bool>> InnerFunction = Expression.Lambda<Func<ResIndexQuantityType, bool>>(IdAndExpression, InnerParameter);

        MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
        return Expression.Lambda<Func<ResCurrentType, bool>>(MethodAnyCall, IndexListParameter);
      }
      else
      {
        throw new FormatException($"SearchParameter.SearchComparator must be Eq or Ne, found: {SearchComparator.ToString()}");
      }
    }

    public Expression<Func<ResCurrentType, bool>> NumberCollectionAnyGreaterThan(int Id, decimal MidNumber)
    {
      return NumberCollectionComparator(Id, MidNumber, Hl7.Fhir.Model.SearchParameter.SearchComparator.Gt);
    }

    public Expression<Func<ResCurrentType, bool>> NumberCollectionAnyGreaterThanOrEqualTo(int Id, decimal MidNumber)
    {
      return NumberCollectionComparator(Id, MidNumber, Hl7.Fhir.Model.SearchParameter.SearchComparator.Ge);
    }

    public Expression<Func<ResCurrentType, bool>> NumberCollectionAnyLessThan(int Id, decimal MidNumber)
    {
      return NumberCollectionComparator(Id, MidNumber, Hl7.Fhir.Model.SearchParameter.SearchComparator.Lt);
    }

    public Expression<Func<ResCurrentType, bool>> NumberCollectionAnyLessThanOrEqualTo(int Id, decimal MidNumber)
    {
      return NumberCollectionComparator(Id, MidNumber, Hl7.Fhir.Model.SearchParameter.SearchComparator.Le);
    }

    private Expression<Func<ResCurrentType, bool>> NumberCollectionComparator(int Id, decimal MidNumber, Hl7.Fhir.Model.SearchParameter.SearchComparator SearchComparator)
    {
      if (SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Gt ||
          SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Ge ||
          SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Lt ||
          SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Le)
      {
        ParameterExpression InnerParameter = Expression.Parameter(typeof(ResIndexQuantityType), "c");
        ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResCurrentType), "x");

        BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

        MemberExpression propertyReferenceComparator = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Comparator);
        MemberExpression propertyReferenceNumber = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Quantity);

        ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal?));

        //Build Inner Expression      
        Expression ComparatorExpression = null;
        if (SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Gt)
        {
          ComparatorExpression = DecimalExpression.GreaterThanExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);
        }
        else if (SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Ge)
        {
          ComparatorExpression = DecimalExpression.GreaterThanOrEqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);
        }
        else if (SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Lt)
        {
          ComparatorExpression = DecimalExpression.LessThanExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);
        }
        else if (SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Le)
        {
          ComparatorExpression = DecimalExpression.LessThanOrEqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);
        }

        var IdAndExpression = Expression.And(BinaryExpressionIdEquals, ComparatorExpression);

        Expression<Func<ResIndexQuantityType, bool>> InnerFunction = Expression.Lambda<Func<ResIndexQuantityType, bool>>(IdAndExpression, InnerParameter);

        MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
        return Expression.Lambda<Func<ResCurrentType, bool>>(MethodAnyCall, IndexListParameter);
      }
      else
      {
        throw new FormatException($"SearchParameter.SearchComparator must be Gt, Ge, Lt or Le, found: {SearchComparator.ToString()}");
      }
    }

    ////---- Quantity Index Expressions ------------------------------------------------------

    public Expression<Func<ResCurrentType, bool>> QuantityCollectionAnyEqualTo(int Id, decimal LowNumber, decimal MidNumber, decimal HighNumber, string System, string Code)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResIndexQuantityType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResCurrentType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression propertyReferenceComparator = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Quantity);
      MemberExpression propertyReferenceSystem = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.System);
      MemberExpression propertyReferenceCode = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Code);
      MemberExpression propertyReferenceUnit = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Unit);

      ConstantExpression SearchValueReferenceLow = Expression.Constant(LowNumber, typeof(decimal?));
      ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(HighNumber, typeof(decimal?));

      ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);
      ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);

      //Build Inner Expression
      Expression EqualToExpression = DecimalExpression.EqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceLow, SearchValueReferenceMid, SearchValueReferenceHigh);
      Expression SystemCodeOrUnit_EqualTo_Expression = QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(propertyReferenceSystem, propertyReferenceCode, propertyReferenceUnit, SearchValueReferenceSystem, SearchValueReferenceCode);
      Expression Final_InnerExpression = Expression.AndAlso(EqualToExpression, SystemCodeOrUnit_EqualTo_Expression);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, Final_InnerExpression);

      Expression<Func<ResIndexQuantityType, bool>> InnerFunction = Expression.Lambda<Func<ResIndexQuantityType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResCurrentType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResCurrentType, bool>> QuantityCollectionAllNotEqualTo(int Id, decimal LowNumber, decimal MidNumber, decimal HighNumber, string System, string Code)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResIndexQuantityType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResCurrentType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression propertyReferenceComparator = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Quantity);
      MemberExpression propertyReferenceSystem = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.System);
      MemberExpression propertyReferenceCode = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Code);
      MemberExpression propertyReferenceUnit = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Unit);

      ConstantExpression SearchValueReferenceLow = Expression.Constant(LowNumber, typeof(decimal?));
      ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(HighNumber, typeof(decimal?));

      ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);
      ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);

      //Build Inner Expression
      //Non of the values are equal to.
      Expression NotEqualToExpression = DecimalExpression.NotEqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceLow, SearchValueReferenceMid, SearchValueReferenceHigh);
      Expression SystemCodeOrUnit_NotEqualTo_Expression = QuantityExpression.SystemCodeOrUnit_NotEqualTo_Expression(propertyReferenceSystem, propertyReferenceCode, propertyReferenceUnit, SearchValueReferenceSystem, SearchValueReferenceCode);
      Expression Final_InnerExpression = Expression.OrElse(NotEqualToExpression, SystemCodeOrUnit_NotEqualTo_Expression);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, Final_InnerExpression);

      Expression<Func<ResIndexQuantityType, bool>> InnerFunction = Expression.Lambda<Func<ResIndexQuantityType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResCurrentType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResCurrentType, bool>> QuantityCollectionAnyGreaterThan(int Id, decimal MidNumber, string System, string Code)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResIndexQuantityType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResCurrentType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression propertyReferenceComparator = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Quantity);
      MemberExpression propertyReferenceSystem = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.System);
      MemberExpression propertyReferenceCode = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Code);
      MemberExpression propertyReferenceUnit = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Unit);

      ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal?));

      ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);
      ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);

      //Build Inner Expression
      Expression GreaterThanExpression = DecimalExpression.GreaterThanExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);
      Expression SystemCodeOrUnit_EqualTo_Expression = QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(propertyReferenceSystem, propertyReferenceCode, propertyReferenceUnit, SearchValueReferenceSystem, SearchValueReferenceCode);
      Expression Final_InnerExpression = Expression.AndAlso(GreaterThanExpression, SystemCodeOrUnit_EqualTo_Expression);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, Final_InnerExpression);

      Expression<Func<ResIndexQuantityType, bool>> InnerFunction = Expression.Lambda<Func<ResIndexQuantityType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResCurrentType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResCurrentType, bool>> QuantityCollectionAnyGreaterThanOrEqualTo(int Id, decimal MidNumber, string System, string Code)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResIndexQuantityType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResCurrentType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression propertyReferenceComparator = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Quantity);
      MemberExpression propertyReferenceSystem = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.System);
      MemberExpression propertyReferenceCode = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Code);
      MemberExpression propertyReferenceUnit = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Unit);

      ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal?));

      ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);
      ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);

      //Build Inner Expression
      Expression GreaterThanOrEqualToExpression = DecimalExpression.GreaterThanOrEqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);
      Expression SystemCodeOrUnit_EqualTo_Expression = QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(propertyReferenceSystem, propertyReferenceCode, propertyReferenceUnit, SearchValueReferenceSystem, SearchValueReferenceCode);
      Expression Final_InnerExpression = Expression.AndAlso(GreaterThanOrEqualToExpression, SystemCodeOrUnit_EqualTo_Expression);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, Final_InnerExpression);

      Expression<Func<ResIndexQuantityType, bool>> InnerFunction = Expression.Lambda<Func<ResIndexQuantityType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResCurrentType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResCurrentType, bool>> QuantityCollectionAnyLessThan(int Id, decimal MidNumber, string System, string Code)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResIndexQuantityType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResCurrentType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression propertyReferenceComparator = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Quantity);
      MemberExpression propertyReferenceSystem = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.System);
      MemberExpression propertyReferenceCode = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Code);
      MemberExpression propertyReferenceUnit = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Unit);

      ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal?));

      ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);
      ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);

      //Build Inner Expression
      Expression LessThanExpression = DecimalExpression.LessThanExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);
      Expression SystemCodeOrUnit_EqualTo_Expression = QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(propertyReferenceSystem, propertyReferenceCode, propertyReferenceUnit, SearchValueReferenceSystem, SearchValueReferenceCode);
      Expression Final_InnerExpression = Expression.AndAlso(LessThanExpression, SystemCodeOrUnit_EqualTo_Expression);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, Final_InnerExpression);

      Expression<Func<ResIndexQuantityType, bool>> InnerFunction = Expression.Lambda<Func<ResIndexQuantityType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResCurrentType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResCurrentType, bool>> QuantityCollectionAnyLessThanOrEqualTo(int Id, decimal MidNumber, string System, string Code)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResIndexQuantityType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResCurrentType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression propertyReferenceComparator = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Quantity);
      MemberExpression propertyReferenceSystem = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.System);
      MemberExpression propertyReferenceCode = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Code);
      MemberExpression propertyReferenceUnit = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Unit);

      ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal?));

      ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);
      ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);

      //Build Inner Expression
      Expression LessThanOrEqualToExpression = DecimalExpression.LessThanOrEqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);
      Expression SystemCodeOrUnit_EqualTo_Expression = QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(propertyReferenceSystem, propertyReferenceCode, propertyReferenceUnit, SearchValueReferenceSystem, SearchValueReferenceCode);
      Expression Final_InnerExpression = Expression.AndAlso(LessThanOrEqualToExpression, SystemCodeOrUnit_EqualTo_Expression);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, Final_InnerExpression);

      Expression<Func<ResIndexQuantityType, bool>> InnerFunction = Expression.Lambda<Func<ResIndexQuantityType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResCurrentType, bool>>(MethodAnyCall, IndexListParameter);
    }

    ////---- Uri Property Expressions ------------------------------------------------------

    public Expression<Func<ResCurrentType, bool>> UriCollectionAnyEqualTo(int Id, string Value)
    {
      //(x => x.IndexList.Any(c => c.String.StartsWith("Mill") & c.ServiceSearchParameterId == Id);
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResIndexUriType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResCurrentType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Uri);
      ConstantExpression InnerValue = Expression.Constant(Value);

      MethodInfo MethodEquals = typeof(string).GetMethods().Where(m => m.Name == "Equals" && m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == typeof(string)).Single();
      MethodCallExpression MethodEqualsCall = Expression.Call(InnerProperty, MethodEquals, InnerValue);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, MethodEqualsCall);

      Expression<Func<ResIndexUriType, bool>> InnerFunction = Expression.Lambda<Func<ResIndexUriType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResCurrentType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResCurrentType, bool>> UriCollectionAnyContains(int Id, string Value)
    {
      //(x => x.IndexList.Any(c => c.String.Contains("myserver.net.au/stu3/api/Patient/1") & c.ServiceSearchParameterId == Id);
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResIndexUriType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResCurrentType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Uri);
      ConstantExpression InnerValue = Expression.Constant(Value);

      MethodInfo MethodContains = typeof(string).GetMethods().Where(m => m.Name == "Contains" && m.GetParameters().Length == 1).Single();

      MethodCallExpression MethodEqualsCall = Expression.Call(InnerProperty, MethodContains, InnerValue);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, MethodEqualsCall);

      Expression<Func<ResIndexUriType, bool>> InnerFunction = Expression.Lambda<Func<ResIndexUriType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResCurrentType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResCurrentType, bool>> UriCollectionAnyStartsWith(int Id, string Value)
    {
      //(x => x.IndexList.Any(c => c.String.StartsWith("myserver.net.au/stu3/api/Patient/1") & c.ServiceSearchParameterId == Id);
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResIndexUriType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResCurrentType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Uri);
      ConstantExpression InnerValue = Expression.Constant(Value);

      MethodInfo MethodStartsWith = typeof(string).GetMethods().Where(m => m.Name == "StartsWith" && m.GetParameters().Length == 1).Single();

      MethodCallExpression MethodEqualsCall = Expression.Call(InnerProperty, MethodStartsWith, InnerValue);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, MethodEqualsCall);

      Expression<Func<ResIndexUriType, bool>> InnerFunction = Expression.Lambda<Func<ResIndexUriType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResCurrentType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResCurrentType, bool>> UriCollectionAnyEndsWith(int Id, string Value)
    {
      //(x => x.IndexList.Any(c => c.String.EndsWith("myserver.net.au/stu3/api/Patient/1") & c.ServiceSearchParameterId == Id);
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResIndexUriType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResCurrentType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Uri);
      ConstantExpression InnerValue = Expression.Constant(Value);

      MethodInfo MethodEndsWith = typeof(string).GetMethods().Where(m => m.Name == "EndsWith" && m.GetParameters().Length == 1).Single();

      MethodCallExpression MethodEqualsCall = Expression.Call(InnerProperty, MethodEndsWith, InnerValue);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, MethodEqualsCall);

      Expression<Func<ResIndexUriType, bool>> InnerFunction = Expression.Lambda<Func<ResIndexUriType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResCurrentType, bool>>(MethodAnyCall, IndexListParameter);
    }

    ////---- Referance Property Expressions ------------------------------------------------------

    public Expression<Func<ResCurrentType, bool>> ReferanceCollectionAnyEqualTo_ByKey(int Id, int ServiceBaseUrlId, string ResourceType, string FhirId, string VersionId)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResIndexReferenceType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResCurrentType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression propertyReferenceServiceBaseUrlId = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.ReferenceServiceBaseUrlId);
      MemberExpression propertyReferenceResourceType = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.ReferenceResourceType);
      MemberExpression propertyReferenceFhirId = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.ReferenceFhirId);
      MemberExpression propertyReferenceVersionId = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.ReferenceVersionId);

      ConstantExpression SearchValueReferenceServiceBaseUrlId = Expression.Constant(ServiceBaseUrlId, typeof(int?));
      ConstantExpression SearchValueReferenceResourceType = Expression.Constant(ResourceType, typeof(string));
      ConstantExpression SearchValueReferenceFhirId = Expression.Constant(FhirId, typeof(string));
      ConstantExpression SearchValueReferenceVersionId = Expression.Constant(VersionId, typeof(string));

      //Build Inner Expression
      Expression BinaryExpression_Final = ReferanceExpression.EqualTo_ByURLStoreKey_Expression(
        propertyReferenceServiceBaseUrlId,
        propertyReferenceResourceType,
        propertyReferenceFhirId,
        propertyReferenceVersionId,
        SearchValueReferenceServiceBaseUrlId,
        SearchValueReferenceResourceType,
        SearchValueReferenceFhirId,
        SearchValueReferenceVersionId);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, BinaryExpression_Final);

      Expression<Func<ResIndexReferenceType, bool>> InnerFunction = Expression.Lambda<Func<ResIndexReferenceType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResCurrentType, bool>>(MethodAnyCall, IndexListParameter);

    }

    public Expression<Func<ResCurrentType, bool>> ReferanceCollectionAnyEqualTo_ByKey_Many_FhirIds(int Id, int ServiceBaseUrlId, string ResourceType, string[] FhirIdArray, string VersionId)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResIndexReferenceType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResCurrentType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression propertyReferenceServiceBaseUrlId = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.ReferenceServiceBaseUrlId);
      MemberExpression propertyReferenceResourceType = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.ReferenceResourceType);
      MemberExpression propertyReferenceFhirId = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.ReferenceFhirId);
      MemberExpression propertyReferenceVersionId = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.ReferenceVersionId);

      ConstantExpression SearchValueReferenceServiceBaseUrlId = Expression.Constant(ServiceBaseUrlId, typeof(int?));
      ConstantExpression SearchValueReferenceResourceType = Expression.Constant(ResourceType, typeof(string));


      ConstantExpression SearchValueReferenceVersionId = Expression.Constant(VersionId, typeof(string));

      //FhirIdArray.Contains(y.ReferenceFhirId)
      Expression<Func<ResIndexReferenceType, bool>> ReferenceFhirIdContainsExpression = ContainsFhirID(InnerParameter, FhirIdArray);



      //Build Inner Expression
      Expression BinaryExpression_Final = ReferanceExpression.EqualTo_ByURLStoreKey_ReferenceFhirIdContains_Expression(
        propertyReferenceServiceBaseUrlId,
        propertyReferenceResourceType,
        propertyReferenceVersionId,
        SearchValueReferenceServiceBaseUrlId,
        SearchValueReferenceResourceType,
        ReferenceFhirIdContainsExpression,
        SearchValueReferenceVersionId);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, BinaryExpression_Final);

      Expression<Func<ResIndexReferenceType, bool>> InnerFunction = Expression.Lambda<Func<ResIndexReferenceType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResCurrentType, bool>>(MethodAnyCall, IndexListParameter);

    }

    public Expression<Func<ResCurrentType, bool>> ReferanceCollectionAnyEqualTo_ByUrlString(int Id, string UrlString, string ResourceType, string FhirId, string VersionId)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResIndexReferenceType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResCurrentType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression propertyReferenceServiceBaseUrlId = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.ReferenceServiceBaseUrlId);
      MemberExpression propertyReferenceResourceType = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.ReferenceResourceType);
      MemberExpression propertyReferenceFhirId = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.ReferenceFhirId);
      MemberExpression propertyReferenceVersionId = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.ReferenceVersionId);
      MemberExpression propertyReferenceUrl = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.ReferenceUrl);
      MemberExpression propertyReferenceServiceRootURL_StoreRootUrl = Expression.Property(propertyReferenceUrl, StaticDatabaseInfo.ServiceBaseUrlConstatnts.Url);

      ConstantExpression SearchValueReferenceUrlString = Expression.Constant(UrlString, typeof(string));
      ConstantExpression SearchValueReferenceResource = Expression.Constant(ResourceType, typeof(string));
      ConstantExpression SearchValueReferenceFhirID = Expression.Constant(FhirId, typeof(string));
      ConstantExpression SearchValueReferenceHistory = Expression.Constant(VersionId, typeof(string));

      //Build Inner Expression
      Expression BinaryExpression_Final = ReferanceExpression.EqualTo_ByURLString_Expression(
        propertyReferenceUrl,
        propertyReferenceServiceRootURL_StoreRootUrl,
        propertyReferenceResourceType,
        propertyReferenceFhirId,
        propertyReferenceVersionId,
        SearchValueReferenceUrlString,
        SearchValueReferenceResource,
        SearchValueReferenceFhirID,
        SearchValueReferenceHistory);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, BinaryExpression_Final);

      Expression<Func<ResIndexReferenceType, bool>> InnerFunction = Expression.Lambda<Func<ResIndexReferenceType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResCurrentType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResCurrentType, bool>> ReferanceCollectionIsNotNull(int Id)
    {
      //(x => x.IndexList.Any(c => c.ServiceSearchParameterId == Id) == false);        
      return SearchParameterIdNull<ResIndexReferenceType>(Id, false);
    }

    public Expression<Func<ResCurrentType, bool>> ReferanceCollectionIsNull(int Id)
    {
      //(x => x.IndexList.Any(c => c.ServiceSearchParameterId == Id) == true);      
      return SearchParameterIdNull<ResIndexReferenceType>(Id, true);
    }

    ////---- QuantityRange Property Expressions ------------------------------------------------------

    ////Not implemented as there are no QuantityRange search parameters as yet in FHIR spec, as of this early STU3 release

    ///---- General Index Expressions ------------------------------------------------------

    private BinaryExpression SearchParameterIdBinaryExpression(int Id, ParameterExpression InnerParameter)
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

    private MethodCallExpression IndexListAnyMethodCallExpression<IndexType>(ParameterExpression IndexListParameter, Expression<Func<IndexType, bool>> InnerFunction)
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

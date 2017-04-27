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

namespace Pyro.DataLayer.Search
{
  public class ResourceSearch<T> where T : ResourceBase
  {
    ////---- String Index Expressions ------------------------------------------------------
    //public Expression<Func<T, bool>> StringPropertyIsNotNull(string Property)
    //{
    //  //(x => x.birthdate_DateTimeOffset != null);
    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.StringIndexConstatnts.String);
    //  var constantReference = Expression.Constant(null);
    //  var BinaryExpression = Expression.NotEqual(propertyReference, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> StringPropertyIsNull(string Property)
    //{
    //  //(x => x.birthdate_DateTimeOffset == null);
    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.StringIndexConstatnts.String);
    //  var constantReference = Expression.Constant(null);
    //  var BinaryExpression = Expression.Equal(propertyReference, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> StringPropertyEqualTo(string Property, string Value)
    //{
    //  //(x => x.FhirId == "a99b5c95-b546-46ee-8992-19a7ca703d4a")
    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReference = Expression.Property(ParameterReferance, Property);
    //  var constantReference = Expression.Constant(StringSupport.ToLowerAndRemoveDiacritics(Value.Trim()));
    //  var BinaryExpression = Expression.Equal(propertyReference, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> StringPropertyStartsWith(string Property, string Value)
    //{
    //  //(x => x.FhirId.StartsWith("a99b5c95-b546-46ee-8992-19a7ca703d4a"))      
    //  MethodInfo MethodStartsWith = typeof(String).GetMethods().Where(m => m.Name == "StartsWith" && m.GetParameters().Length == 1).Single();

    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReference = Expression.Property(ParameterReferance, Property);
    //  var constantReference = Expression.Constant(StringSupport.ToLowerAndRemoveDiacritics(Value.Trim()));
    //  var MethodStartsWithCall = Expression.Call(propertyReference, MethodStartsWith, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(MethodStartsWithCall, ParameterReferance);
    //}

    //public Expression<Func<T, bool>> StringPropertyStartsOrEndsWith(string Property, string Value)
    //{
    //  //(x => x.FhirId.StartsWith("a99b5c95-b546-46ee-8992-19a7ca703d4a"))      
    //  MethodInfo MethodStartsWith = typeof(String).GetMethods().Where(m => m.Name == "StartsWith" && m.GetParameters().Length == 1).Single();
    //  MethodInfo MethodEndsWith = typeof(String).GetMethods().Where(m => m.Name == "EndsWith" && m.GetParameters().Length == 1).Single();

    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReference = Expression.Property(ParameterReferance, Property);
    //  var constantReference = Expression.Constant(StringSupport.ToLowerAndRemoveDiacritics(Value.Trim()));

    //  var MethodStartsWithCall = Expression.Call(propertyReference, MethodStartsWith, constantReference);
    //  var MethodEndsWithCall = Expression.Call(propertyReference, MethodEndsWith, constantReference);
    //  var OrExpression = Expression.OrElse(MethodStartsWithCall, MethodEndsWithCall);

    //  return Expression.Lambda<Func<T, bool>>(OrExpression, ParameterReferance);
    //}

    //public Expression<Func<T, bool>> StringPropertyContains(string Property, string Value)
    //{
    //  //(x => x.FhirId.Contains("d3da-493a-b4f2"))      
    //  MethodInfo MethodContains = typeof(String).GetMethods().Where(m => m.Name == "Contains" && m.GetParameters().Length == 1).Single();

    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReference = Expression.Property(ParameterReferance, Property);
    //  var constantReference = Expression.Constant(StringSupport.ToLowerAndRemoveDiacritics(Value.Trim()));
    //  var MethodContainsCall = Expression.Call(propertyReference, MethodContains, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(MethodContainsCall, ParameterReferance);
    //}

   

    public Expression<Func<T, bool>> StringCollectionAnyEqualTo(int Id, string Value)
    {      
      //(x => x.IndexList.Any(c => c.String.Equals("héllo UPPER") & c.ServiceSearchParameterId == Id);      
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBase), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(T), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression InnerPropertyString = Expression.Property(InnerParameter, StaticDatabaseInfo.DataLayerIndexPropertyConstatnts.BaseResourceIndexConstatnts.String);
      ConstantExpression InnerValueString = Expression.Constant(StringSupport.ToLowerAndRemoveDiacritics(Value.Trim()));
      MethodInfo MethodEquals = typeof(String).GetMethods().Where(m => m.Name == "Equals" && m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == typeof(String)).Single();
      MethodCallExpression MethodEqualsCall = Expression.Call(InnerPropertyString, MethodEquals, InnerValueString);
      
      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, MethodEqualsCall);

      Expression<Func<ResourceIndexBase, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBase, bool>>(IdAndExpression, InnerParameter);
      
      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter,InnerFunction);
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, IndexListParameter);      
    }

    //public Expression<Func<T, bool>> StringCollectionAnyStartsWith(string Property, string Value)
    //{
    //  //(x => x.family_List.Any(c => c.String.StartsWith("Mill")));
    //  var type = typeof(T);
    //  string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

    //  //Inner
    //  MethodInfo MethodStartsWith = typeof(String).GetMethods().Where(m => m.Name == "StartsWith" && m.GetParameters().Length == 1).Single();

    //  ParameterExpression InnerParameter = Expression.Parameter(typeof(StringIndex), "c");
    //  MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.StringIndexConstatnts.String);
    //  ConstantExpression InnerValue = Expression.Constant(StringSupport.ToLowerAndRemoveDiacritics(Value.Trim()));
    //  MethodCallExpression MethodStartsWithCall = Expression.Call(InnerProperty, MethodStartsWith, InnerValue);
    //  Expression<Func<StringIndex, bool>> InnerFunction = Expression.Lambda<Func<StringIndex, bool>>(MethodStartsWithCall, InnerParameter);

    //  //Outer Any
    //  MethodInfo MethodAny = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(StringIndex));

    //  ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
    //  MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
    //  MethodCallExpression MethodAnyCall = Expression.Call(MethodAny, CollectionProperty, InnerFunction);
    //  return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PatientParameter);
    //}

    public Expression<Func<T, bool>> StringCollectionAnyStartsOrEndsWith(int Id, string Value)
    {
      //(x => x.IndexList.Any(c => c.String.StartsWith("Mill") & c.ServiceSearchParameterId == Id);
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBase), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(T), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression InnerPropertyString = Expression.Property(InnerParameter, StaticDatabaseInfo.DataLayerIndexPropertyConstatnts.BaseResourceIndexConstatnts.String);
      ConstantExpression InnerValueString = Expression.Constant(StringSupport.ToLowerAndRemoveDiacritics(Value.Trim()));

      MethodInfo MethodStartsWith = typeof(String).GetMethods().Where(m => m.Name == "StartsWith" && m.GetParameters().Length == 1).Single();
      MethodCallExpression MethodStartsWithCall = Expression.Call(InnerPropertyString, MethodStartsWith, InnerValueString);

      MethodInfo MethodEndsWith = typeof(String).GetMethods().Where(m => m.Name == "EndsWith" && m.GetParameters().Length == 1).Single();
      MethodCallExpression MethodEndsWithCall = Expression.Call(InnerPropertyString, MethodEndsWith, InnerValueString);

      var StartsWithOrEndsWithExpression = Expression.OrElse(MethodStartsWithCall, MethodEndsWithCall);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, StartsWithOrEndsWithExpression);
      
      Expression<Func<ResourceIndexBase, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBase, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, IndexListParameter);      
    }

    public Expression<Func<T, bool>> StringCollectionAnyContains(int Id, string Value)
    {      
      //(x => x.IndexList.Any(c => c.String.Contains("Mill") & c.ServiceSearchParameterId == Id);
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBase), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(T), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression InnerPropertyString = Expression.Property(InnerParameter, StaticDatabaseInfo.DataLayerIndexPropertyConstatnts.BaseResourceIndexConstatnts.String);
      ConstantExpression InnerValueString = Expression.Constant(StringSupport.ToLowerAndRemoveDiacritics(Value.Trim()));

      MethodInfo MethodContains = typeof(String).GetMethods().Where(m => m.Name == "Contains" && m.GetParameters().Length == 1).Single();
      MethodCallExpression MethodContainsCall = Expression.Call(InnerPropertyString, MethodContains, InnerValueString);
      
      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, MethodContainsCall);

      Expression<Func<ResourceIndexBase, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBase, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, IndexListParameter);      
    }

    ////---- Date Index Expressions ------------------------------------------------------
    //public Expression<Func<T, bool>> DatePropertyIsNotNull(string Property)
    //{
    //  //(x => x.birthdate_DateTimeOffset != null);
    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateIndexConstatnts.Date);
    //  var constantReference = Expression.Constant(null);
    //  var BinaryExpression = Expression.NotEqual(propertyReference, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> DatePropertyIsNull(string Property)
    //{
    //  //(x => x.birthdate_DateTimeOffset == null);
    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateIndexConstatnts.Date);
    //  var constantReference = Expression.Constant(null);
    //  var BinaryExpression = Expression.Equal(propertyReference, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> DatePropertyEqualTo(string Property, int Value)
    //{
    //  //(x => x.birthdate_DateTimeOffset == TestDate);
    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateIndexConstatnts.Date);
    //  var constantReference = Expression.Constant(Value, typeof(int?));
    //  var BinaryExpression = Expression.Equal(propertyReference, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> DatePropertyNotEqualTo(string Property, int Value)
    //{
    //  //(x => x.birthdate_DateTimeOffset != TestDate);
    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateIndexConstatnts.Date);
    //  var constantReference = Expression.Constant(Value, typeof(int?));
    //  var BinaryExpression = Expression.NotEqual(propertyReference, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> DatePropertyGreaterThan(string Property, int Value)
    //{
    //  //(x => x.birthdate_DateTimeOffset > TestDate);
    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateIndexConstatnts.Date);
    //  var constantReference = Expression.Constant(Value, typeof(int?));
    //  var BinaryExpression = Expression.GreaterThan(propertyReference, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> DatePropertyGreaterThanOrEqualTo(string Property, int Value)
    //{
    //  //(x => x.birthdate_DateTimeOffset >= TestDate);
    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateIndexConstatnts.Date);
    //  var constantReference = Expression.Constant(Value, typeof(int?));
    //  var BinaryExpression = Expression.GreaterThanOrEqual(propertyReference, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> DatePropertyLessThan(string Property, int Value)
    //{
    //  //(x => x.birthdate_DateTimeOffset < TestDate);
    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateIndexConstatnts.Date);
    //  var constantReference = Expression.Constant(Value, typeof(int?));
    //  var BinaryExpression = Expression.LessThan(propertyReference, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> DatePropertyLessThanOrEqualTo(string Property, int Value)
    //{
    //  //(x => x.birthdate_DateTimeOffset <= TestDate);
    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateIndexConstatnts.Date);
    //  var constantReference = Expression.Constant(Value, typeof(int?));
    //  var BinaryExpression = Expression.LessThanOrEqual(propertyReference, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    //}

    ////---- DateTime Index Expressions ------------------------------------------------------

    //public Expression<Func<T, bool>> DateTimePropertyIsNotNull(string Property)
    //{
    //  //(x => x.birthdate_DateTimeOffset != null);
    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimeIndexConstatnts.DateTimeOffset);
    //  var constantReference = Expression.Constant(null);
    //  var BinaryExpression = Expression.NotEqual(propertyReference, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> DateTimePropertyIsNull(string Property)
    //{
    //  //(x => x.birthdate_DateTimeOffset == null);
    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimeIndexConstatnts.DateTimeOffset);
    //  var constantReference = Expression.Constant(null);
    //  var BinaryExpression = Expression.Equal(propertyReference, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> DateTimePropertyEqualTo(string Property, DateTimeOffset Value)
    //{
    //  //(x => x.birthdate_DateTimeOffset == TestDate);
    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimeIndexConstatnts.DateTimeOffset);
    //  var constantReference = Expression.Constant(Value, typeof(DateTimeOffset?));
    //  var BinaryExpression = Expression.Equal(propertyReference, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> DateTimePropertyNotEqualTo(string Property, DateTimeOffset Value)
    //{
    //  //(x => x.birthdate_DateTimeOffset != TestDate);
    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimeIndexConstatnts.DateTimeOffset);
    //  var constantReference = Expression.Constant(Value, typeof(DateTimeOffset?));
    //  var BinaryExpression = Expression.NotEqual(propertyReference, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> DateTimePropertyGreaterThan(string Property, DateTimeOffset Value)
    //{
    //  //(x => x.birthdate_DateTimeOffset > TestDate);
    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimeIndexConstatnts.DateTimeOffset);
    //  var constantReference = Expression.Constant(Value, typeof(DateTimeOffset?));
    //  var BinaryExpression = Expression.GreaterThan(propertyReference, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> DateTimePropertyGreaterThanOrEqualTo(string Property, DateTimeOffset Value)
    //{
    //  //(x => x.birthdate_DateTimeOffset >= TestDate);
    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimeIndexConstatnts.DateTimeOffset);
    //  var constantReference = Expression.Constant(Value, typeof(DateTimeOffset?));
    //  var BinaryExpression = Expression.GreaterThanOrEqual(propertyReference, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> DateTimePropertyLessThan(string Property, DateTimeOffset Value)
    //{
    //  //(x => x.birthdate_DateTimeOffset < TestDate);
    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimeIndexConstatnts.DateTimeOffset);
    //  var constantReference = Expression.Constant(Value, typeof(DateTimeOffset?));
    //  var BinaryExpression = Expression.LessThan(propertyReference, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> DateTimePropertyLessThanOrEqualTo(string Property, DateTimeOffset Value)
    //{
    //  //(x => x.birthdate_DateTimeOffset <= TestDate);
    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimeIndexConstatnts.DateTimeOffset);
    //  var constantReference = Expression.Constant(Value, typeof(DateTimeOffset?));
    //  var BinaryExpression = Expression.LessThanOrEqual(propertyReference, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> DateTimeCollectionIsNotNull(string Property)
    //{
    //  //(x => x.given_List.Count > 0);
    //  var type = typeof(T);
    //  string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

    //  MethodInfo MethodCount = typeof(Enumerable).GetMethods().Where(m => m.Name == "Count" && m.GetParameters().Length == 1).Single().MakeGenericMethod(typeof(DateTimeIndex));

    //  ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
    //  MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
    //  MethodCallExpression MethodAnyCall = Expression.Call(MethodCount, CollectionProperty);
    //  ConstantExpression constantReference = Expression.Constant(0);
    //  BinaryExpression BinaryExpression = Expression.GreaterThan(MethodAnyCall, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, PatientParameter);
    //}

    //public Expression<Func<T, bool>> DateTimeCollectionIsNull(string Property)
    //{
    //  //(x => x.given_List.Count == 0);
    //  var type = typeof(T);
    //  string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

    //  MethodInfo MethodCount = typeof(Enumerable).GetMethods().Where(m => m.Name == "Count" && m.GetParameters().Length == 1).Single().MakeGenericMethod(typeof(DateTimeIndex));

    //  ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
    //  MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
    //  MethodCallExpression MethodAnyCall = Expression.Call(MethodCount, CollectionProperty);
    //  ConstantExpression constantReference = Expression.Constant(0);
    //  BinaryExpression BinaryExpression = Expression.Equal(MethodAnyCall, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, PatientParameter);
    //}

    //public Expression<Func<T, bool>> DateTimeCollectionAnyEqualTo(string Property, DateTimeOffset Value)
    //{
    //  //(x => x.family_List.Any(c => c.String.Equals("héllo UPPER")))
    //  var type = typeof(T);
    //  string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;
    //  //Inner
    //  MethodInfo MethodEquals = typeof(DateTimeOffset).GetMethods().Where(m => m.Name == "Equals" && m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == typeof(DateTimeOffset)).Single();

    //  ParameterExpression InnerParameter = Expression.Parameter(typeof(DateTimeIndex), "c");
    //  MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimeIndexConstatnts.DateTimeOffset);
    //  ConstantExpression InnerValue = Expression.Constant(Value);
    //  MethodCallExpression MethodEqualsCall = Expression.Call(InnerProperty, MethodEquals, InnerValue);
    //  Expression<Func<DateTimeIndex, bool>> InnerFunction = Expression.Lambda<Func<DateTimeIndex, bool>>(MethodEqualsCall, InnerParameter);

    //  //Outer Any
    //  MethodInfo MethodAny = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(DateTimeIndex));

    //  ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
    //  MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
    //  MethodCallExpression MethodAnyCall = Expression.Call(MethodAny, CollectionProperty, InnerFunction);
    //  return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PatientParameter);
    //}

    //public Expression<Func<T, bool>> DateTimeCollectionAnyNotEqualTo(string Property, DateTimeOffset Value)
    //{
    //  //(x => x. activitydate.Any(c => c.DateTimeOffset != "1995-09-30T10:00:10.123+10:00")))
    //  var type = typeof(T);
    //  string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;
    //  //Inner      
    //  ParameterExpression InnerParameter = Expression.Parameter(typeof(DateTimeIndex), "c");
    //  MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimeIndexConstatnts.DateTimeOffset);
    //  ConstantExpression InnerValue = Expression.Constant(Value);
    //  BinaryExpression InnerBinaryExpression = Expression.NotEqual(InnerProperty, InnerValue);
    //  Expression<Func<DateTimeIndex, bool>> InnerFunction = Expression.Lambda<Func<DateTimeIndex, bool>>(InnerBinaryExpression, InnerParameter);

    //  //Outer Any
    //  MethodInfo MethodAny = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(DateTimeIndex));

    //  ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
    //  MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
    //  MethodCallExpression MethodAnyCall = Expression.Call(MethodAny, CollectionProperty, InnerFunction);
    //  return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PatientParameter);
    //}

    //public Expression<Func<T, bool>> DateTimeCollectionGreaterThanOrEqualTo(string Property, DateTimeOffset Value)
    //{
    //  //(x => x. activitydate.Any(c => c.DateTimeOffset >= "1995-09-30T10:00:10.123+10:00")))
    //  var type = typeof(T);
    //  string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;
    //  //Inner      
    //  ParameterExpression InnerParameter = Expression.Parameter(typeof(DateTimeIndex), "c");
    //  MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimeIndexConstatnts.DateTimeOffset);
    //  ConstantExpression InnerValue = Expression.Constant(Value);
    //  BinaryExpression InnerBinaryExpression = BinaryExpression.GreaterThanOrEqual(InnerProperty, InnerValue);
    //  //MethodCallExpression MethodEqualsCall = Expression.Call(InnerProperty, MethodEquals, InnerValue);
    //  Expression<Func<DateTimeIndex, bool>> InnerFunction = Expression.Lambda<Func<DateTimeIndex, bool>>(InnerBinaryExpression, InnerParameter);

    //  //Outer Any
    //  MethodInfo MethodAny = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(DateTimeIndex));

    //  ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
    //  MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
    //  MethodCallExpression MethodAnyCall = Expression.Call(MethodAny, CollectionProperty, InnerFunction);
    //  return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PatientParameter);
    //}

    //public Expression<Func<T, bool>> DateTimeCollectionGreaterThan(string Property, DateTimeOffset Value)
    //{
    //  //(x => x. activitydate.Any(c => c.DateTimeOffset > "1995-09-30T10:00:10.123+10:00")))
    //  var type = typeof(T);
    //  string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;
    //  //Inner      
    //  ParameterExpression InnerParameter = Expression.Parameter(typeof(DateTimeIndex), "c");
    //  MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimeIndexConstatnts.DateTimeOffset);
    //  ConstantExpression InnerValue = Expression.Constant(Value);
    //  BinaryExpression InnerBinaryExpression = BinaryExpression.GreaterThan(InnerProperty, InnerValue);
    //  //MethodCallExpression MethodEqualsCall = Expression.Call(InnerProperty, MethodEquals, InnerValue);
    //  Expression<Func<DateTimeIndex, bool>> InnerFunction = Expression.Lambda<Func<DateTimeIndex, bool>>(InnerBinaryExpression, InnerParameter);

    //  //Outer Any
    //  MethodInfo MethodAny = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(DateTimeIndex));

    //  ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
    //  MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
    //  MethodCallExpression MethodAnyCall = Expression.Call(MethodAny, CollectionProperty, InnerFunction);
    //  return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PatientParameter);
    //}

    //public Expression<Func<T, bool>> DateTimeCollectionLessThanOrEqualTo(string Property, DateTimeOffset Value)
    //{
    //  //(x => x. activitydate.Any(c => c.DateTimeOffset <= "1995-09-30T10:00:10.123+10:00")))
    //  var type = typeof(T);
    //  string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;
    //  //Inner      
    //  ParameterExpression InnerParameter = Expression.Parameter(typeof(DateTimeIndex), "c");
    //  MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimeIndexConstatnts.DateTimeOffset);
    //  ConstantExpression InnerValue = Expression.Constant(Value);
    //  BinaryExpression InnerBinaryExpression = BinaryExpression.LessThanOrEqual(InnerProperty, InnerValue);
    //  Expression<Func<DateTimeIndex, bool>> InnerFunction = Expression.Lambda<Func<DateTimeIndex, bool>>(InnerBinaryExpression, InnerParameter);

    //  //Outer Any
    //  MethodInfo MethodAny = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(DateTimeIndex));

    //  ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
    //  MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
    //  MethodCallExpression MethodAnyCall = Expression.Call(MethodAny, CollectionProperty, InnerFunction);
    //  return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PatientParameter);
    //}

    //public Expression<Func<T, bool>> DateTimeCollectionLessThan(string Property, DateTimeOffset Value)
    //{
    //  //(x => x. activitydate.Any(c => c.DateTimeOffset < "1995-09-30T10:00:10.123+10:00")))
    //  var type = typeof(T);
    //  string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;
    //  //Inner      
    //  ParameterExpression InnerParameter = Expression.Parameter(typeof(DateTimeIndex), "c");
    //  MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimeIndexConstatnts.DateTimeOffset);
    //  ConstantExpression InnerValue = Expression.Constant(Value);
    //  BinaryExpression InnerBinaryExpression = BinaryExpression.LessThan(InnerProperty, InnerValue);
    //  Expression<Func<DateTimeIndex, bool>> InnerFunction = Expression.Lambda<Func<DateTimeIndex, bool>>(InnerBinaryExpression, InnerParameter);

    //  //Outer Any
    //  MethodInfo MethodAny = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(DateTimeIndex));

    //  ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
    //  MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
    //  MethodCallExpression MethodAnyCall = Expression.Call(MethodAny, CollectionProperty, InnerFunction);
    //  return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PatientParameter);
    //}


    ////---- DateTimePeriod Index Expressions ------------------------------------------------------

    //public Expression<Func<T, bool>> DateTimePeriodPropertyIsNotNull(string Property)
    //{
    //  //(x => x. date_DateTimeOffsetLow != null && date_DateTimeOffsetHigh != null );
    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReferenceLow = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
    //  var propertyReferenceHigh = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);
    //  var constantReference = Expression.Constant(null);
    //  var BinaryExpressionLow = Expression.NotEqual(propertyReferenceLow, constantReference);
    //  var BinaryExpressionHigh = Expression.NotEqual(propertyReferenceLow, constantReference);
    //  var BinaryExpressionAnd = Expression.And(BinaryExpressionLow, BinaryExpressionHigh);

    //  return Expression.Lambda<Func<T, bool>>(BinaryExpressionAnd, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> DateTimePeriodPropertyIsNull(string Property)
    //{
    //  //(x => x. date_DateTimeOffsetLow == null && date_DateTimeOffsetHigh == null );
    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReferenceLow = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
    //  var propertyReferenceHigh = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);
    //  var constantReference = Expression.Constant(null);
    //  var BinaryExpressionLow = Expression.Equal(propertyReferenceLow, constantReference);
    //  var BinaryExpressionHigh = Expression.Equal(propertyReferenceLow, constantReference);
    //  var BinaryExpressionAnd = Expression.And(BinaryExpressionLow, BinaryExpressionHigh);

    //  return Expression.Lambda<Func<T, bool>>(BinaryExpressionAnd, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> DateTimePeriodPropertyEqualTo(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    //{
    //  var ParameterReferance = Expression.Parameter(typeof(T), "x");
    //  MemberExpression propertyReferenceLow = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
    //  MemberExpression propertyReferenceHigh = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);

    //  ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
    //  ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

    //  //Build Expression
    //  Expression BinaryExpression_Final = DateTimePeriodExpression.EqualToExpression(Property, propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> DateTimePeriodPropertyNotEqualTo(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    //{
    //  var ParameterReferance = Expression.Parameter(typeof(T), "x");
    //  MemberExpression propertyReferenceLow = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
    //  MemberExpression propertyReferenceHigh = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);
    //  ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
    //  ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

    //  //Build Expression
    //  Expression BinaryExpression_Final = DateTimePeriodExpression.NotEqualToExpression(Property, propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> DateTimePeriodPropertyGreaterThan(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    //{
    //  var ParameterReferance = Expression.Parameter(typeof(T), "x");
    //  MemberExpression propertyReferenceLow = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
    //  MemberExpression propertyReferenceHigh = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);
    //  ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
    //  ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

    //  //Build Expression
    //  Expression BinaryExpression_Final = DateTimePeriodExpression.GreaterThanExpression(Property, propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> DateTimePeriodPropertyGreaterThanOrEqualTo(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    //{
    //  var ParameterReferance = Expression.Parameter(typeof(T), "x");
    //  MemberExpression propertyReferenceLow = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
    //  MemberExpression propertyReferenceHigh = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);
    //  ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
    //  ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

    //  //Build Expression
    //  Expression BinaryExpression_Final = DateTimePeriodExpression.GreaterThanOrEqualToExpression(Property, propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> DateTimePeriodPropertyLessThan(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    //{
    //  var ParameterReferance = Expression.Parameter(typeof(T), "x");
    //  MemberExpression propertyReferenceLow = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
    //  MemberExpression propertyReferenceHigh = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);
    //  ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
    //  ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

    //  //Build Expression
    //  Expression BinaryExpression_Final = DateTimePeriodExpression.LessThanExpression(Property, propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> DateTimePeriodPropertyLessThanOrEqualTo(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    //{
    //  var ParameterReferance = Expression.Parameter(typeof(T), "x");
    //  MemberExpression propertyReferenceLow = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
    //  MemberExpression propertyReferenceHigh = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);
    //  ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
    //  ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

    //  //Build Expression
    //  Expression BinaryExpression_Final = DateTimePeriodExpression.LessThanOrEqualToExpression(Property, propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    //}


    //public Expression<Func<T, bool>> DateTimePeriodCollectionIsNotNull(string Property)
    //{
    //  //(x => x.date_List.Count > 0);
    //  var type = typeof(T);
    //  string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

    //  MethodInfo MethodCount = typeof(Enumerable).GetMethods().Where(m => m.Name == "Count" && m.GetParameters().Length == 1).Single().MakeGenericMethod(typeof(DateTimeIndex));

    //  ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
    //  MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
    //  MethodCallExpression MethodAnyCall = Expression.Call(MethodCount, CollectionProperty);
    //  ConstantExpression constantReference = Expression.Constant(0);
    //  BinaryExpression BinaryExpression = Expression.GreaterThan(MethodAnyCall, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, PatientParameter);
    //}

    //public Expression<Func<T, bool>> DateTimePeriodCollectionIsNull(string Property)
    //{
    //  //(x => x.date_List.Count == 0);
    //  var type = typeof(T);
    //  string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

    //  MethodInfo MethodCount = typeof(Enumerable).GetMethods().Where(m => m.Name == "Count" && m.GetParameters().Length == 1).Single().MakeGenericMethod(typeof(DateTimePeriodIndex));

    //  ParameterExpression ResourceParameter = Expression.Parameter(typeof(T), "x");
    //  MemberExpression CollectionProperty = Expression.Property(ResourceParameter, typeof(T).GetProperty(DbPropertyName));
    //  MethodCallExpression MethodCountCall = Expression.Call(MethodCount, CollectionProperty);
    //  ConstantExpression constantReference = Expression.Constant(0);
    //  BinaryExpression BinaryExpression = Expression.Equal(MethodCountCall, constantReference);


    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, ResourceParameter);
    //}

    //public Expression<Func<T, bool>> DateTimePeriodCollectionAnyEqualTo(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    //{
    //  string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

    //  //Outer Any Method
    //  MethodInfo ME_Any = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(DateTimePeriodIndex));

    //  //Expression For Any Method
    //  ParameterExpression PE_Inner = Expression.Parameter(typeof(DateTimePeriodIndex), "c");
    //  MemberExpression propertyReferenceLow = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
    //  MemberExpression propertyReferenceHigh = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);

    //  ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
    //  ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

    //  //Build Inner Expression
    //  Expression E_InnerExpression = DateTimePeriodExpression.EqualToExpression(Property, propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

    //  //Wrap Any Method Expression into Function
    //  Expression<Func<DateTimePeriodIndex, bool>> InnerFunction = Expression.Lambda<Func<DateTimePeriodIndex, bool>>(E_InnerExpression, PE_Inner);

    //  ParameterExpression PE_Outer = Expression.Parameter(typeof(T), "x");
    //  MemberExpression ME_CollectionProperty = Expression.Property(PE_Outer, typeof(T).GetProperty(DbPropertyName));

    //  //Call Any Method with Function
    //  MethodCallExpression MethodAnyCall = Expression.Call(ME_Any, ME_CollectionProperty, InnerFunction);

    //  //Wrap final expression into function
    //  return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PE_Outer);
    //}

    //public Expression<Func<T, bool>> DateTimePeriodCollectionAnyNotEqualTo(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    //{
    //  string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

    //  //Outer Any Method
    //  MethodInfo ME_All = typeof(Enumerable).GetMethods().Where(m => m.Name == "All" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(DateTimePeriodIndex));

    //  //Expression For Any Method
    //  ParameterExpression PE_Inner = Expression.Parameter(typeof(DateTimePeriodIndex), "c");
    //  MemberExpression propertyReferenceLow = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
    //  MemberExpression propertyReferenceHigh = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);
    //  ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
    //  ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

    //  //Build Inner Expression
    //  Expression E_InnerExpression = DateTimePeriodExpression.NotEqualToExpression(Property, propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

    //  //Wrap Any Method Expression into Function
    //  Expression<Func<DateTimePeriodIndex, bool>> InnerFunction = Expression.Lambda<Func<DateTimePeriodIndex, bool>>(E_InnerExpression, PE_Inner);

    //  ParameterExpression PE_Outer = Expression.Parameter(typeof(T), "x");
    //  MemberExpression ME_CollectionProperty = Expression.Property(PE_Outer, typeof(T).GetProperty(DbPropertyName));

    //  //Call Any Method with Function
    //  MethodCallExpression MethodAllCall = Expression.Call(ME_All, ME_CollectionProperty, InnerFunction);

    //  //Wrap final expression into function
    //  return Expression.Lambda<Func<T, bool>>(MethodAllCall, PE_Outer);
    //}

    //public Expression<Func<T, bool>> DateTimePeriodCollectionGreaterThanOrEqualTo(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    //{
    //  string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

    //  //Outer Any Method
    //  MethodInfo ME_Any = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(DateTimePeriodIndex));

    //  //Expression For Any Method
    //  ParameterExpression PE_Inner = Expression.Parameter(typeof(DateTimePeriodIndex), "c");
    //  MemberExpression propertyReferenceLow = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
    //  MemberExpression propertyReferenceHigh = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);
    //  ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
    //  ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

    //  //Build Inner Expression
    //  Expression E_InnerExpression = DateTimePeriodExpression.GreaterThanOrEqualToExpression(Property, propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

    //  //Wrap Any Method Expression into Function
    //  Expression<Func<DateTimePeriodIndex, bool>> InnerFunction = Expression.Lambda<Func<DateTimePeriodIndex, bool>>(E_InnerExpression, PE_Inner);

    //  ParameterExpression PE_Outer = Expression.Parameter(typeof(T), "x");
    //  MemberExpression ME_CollectionProperty = Expression.Property(PE_Outer, typeof(T).GetProperty(DbPropertyName));

    //  //Call Any Method with Function
    //  MethodCallExpression MethodAnyCall = Expression.Call(ME_Any, ME_CollectionProperty, InnerFunction);

    //  //Wrap final expression into function
    //  return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PE_Outer);
    //}

    //public Expression<Func<T, bool>> DateTimePeriodCollectionGreaterThan(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    //{
    //  string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

    //  //Outer Any Method
    //  MethodInfo ME_Any = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(DateTimePeriodIndex));

    //  //Expression For Any Method
    //  ParameterExpression PE_Inner = Expression.Parameter(typeof(DateTimePeriodIndex), "c");
    //  MemberExpression propertyReferenceLow = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
    //  MemberExpression propertyReferenceHigh = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);
    //  ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
    //  ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

    //  //Build Inner Expression
    //  Expression E_InnerExpression = DateTimePeriodExpression.GreaterThanExpression(Property, propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

    //  //Wrap Any Method Expression into Function
    //  Expression<Func<DateTimePeriodIndex, bool>> InnerFunction = Expression.Lambda<Func<DateTimePeriodIndex, bool>>(E_InnerExpression, PE_Inner);

    //  ParameterExpression PE_Outer = Expression.Parameter(typeof(T), "x");
    //  MemberExpression ME_CollectionProperty = Expression.Property(PE_Outer, typeof(T).GetProperty(DbPropertyName));

    //  //Call Any Method with Function
    //  MethodCallExpression MethodAnyCall = Expression.Call(ME_Any, ME_CollectionProperty, InnerFunction);

    //  //Wrap final expression into function
    //  return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PE_Outer);
    //}

    //public Expression<Func<T, bool>> DateTimePeriodCollectionLessThan(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    //{
    //  string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

    //  //Outer Any Method
    //  MethodInfo ME_Any = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(DateTimePeriodIndex));

    //  //Expression For Any Method
    //  ParameterExpression PE_Inner = Expression.Parameter(typeof(DateTimePeriodIndex), "c");
    //  MemberExpression propertyReferenceLow = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
    //  MemberExpression propertyReferenceHigh = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);
    //  ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
    //  ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

    //  //Build Inner Expression
    //  Expression E_InnerExpression = DateTimePeriodExpression.LessThanExpression(Property, propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

    //  //Wrap Any Method Expression into Function
    //  Expression<Func<DateTimePeriodIndex, bool>> InnerFunction = Expression.Lambda<Func<DateTimePeriodIndex, bool>>(E_InnerExpression, PE_Inner);

    //  ParameterExpression PE_Outer = Expression.Parameter(typeof(T), "x");
    //  MemberExpression ME_CollectionProperty = Expression.Property(PE_Outer, typeof(T).GetProperty(DbPropertyName));

    //  //Call Any Method with Function
    //  MethodCallExpression MethodAnyCall = Expression.Call(ME_Any, ME_CollectionProperty, InnerFunction);

    //  //Wrap final expression into function
    //  return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PE_Outer);
    //}

    //public Expression<Func<T, bool>> DateTimePeriodCollectionLessThanOrEqualTo(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    //{
    //  string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

    //  //Outer Any Method
    //  MethodInfo ME_Any = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(DateTimePeriodIndex));

    //  //Expression For Any Method
    //  ParameterExpression PE_Inner = Expression.Parameter(typeof(DateTimePeriodIndex), "c");
    //  MemberExpression propertyReferenceLow = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
    //  MemberExpression propertyReferenceHigh = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);
    //  ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
    //  ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

    //  //Build Inner Expression
    //  Expression E_InnerExpression = DateTimePeriodExpression.LessThanOrEqualToExpression(Property, propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

    //  //Wrap Any Method Expression into Function
    //  Expression<Func<DateTimePeriodIndex, bool>> InnerFunction = Expression.Lambda<Func<DateTimePeriodIndex, bool>>(E_InnerExpression, PE_Inner);

    //  ParameterExpression PE_Outer = Expression.Parameter(typeof(T), "x");
    //  MemberExpression ME_CollectionProperty = Expression.Property(PE_Outer, typeof(T).GetProperty(DbPropertyName));

    //  //Call Any Method with Function
    //  MethodCallExpression MethodAnyCall = Expression.Call(ME_Any, ME_CollectionProperty, InnerFunction);

    //  //Wrap final expression into function
    //  return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PE_Outer);
    //}

    ////---- Token Index Expressions ------------------------------------------------------

    //public Expression<Func<T, bool>> TokenPropertyIsNotNull(string Property)
    //{
    //  //(x => x. date_DateTimeOffsetLow != null && date_DateTimeOffsetHigh != null );
    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReferenceSystem = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.TokenIndexConstatnts.System);
    //  var propertyReferenceCode = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.TokenIndexConstatnts.Code);
    //  var constantReference = Expression.Constant(null);
    //  var BinaryExpressionSystem = Expression.NotEqual(propertyReferenceSystem, constantReference);
    //  var BinaryExpressionCode = Expression.NotEqual(propertyReferenceCode, constantReference);
    //  var BinaryExpressionAnd = Expression.Or(BinaryExpressionSystem, BinaryExpressionCode);

    //  return Expression.Lambda<Func<T, bool>>(BinaryExpressionAnd, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> TokenPropertyIsNull(string Property)
    //{
    //  //(x => x. date_DateTimeOffsetLow != null && date_DateTimeOffsetHigh != null );
    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReferenceSystem = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.TokenIndexConstatnts.System);
    //  var propertyReferenceCode = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.TokenIndexConstatnts.Code);
    //  var constantReference = Expression.Constant(null);
    //  var BinaryExpressionSystem = Expression.Equal(propertyReferenceSystem, constantReference);
    //  var BinaryExpressionCode = Expression.Equal(propertyReferenceCode, constantReference);
    //  var BinaryExpressionAnd = Expression.And(BinaryExpressionSystem, BinaryExpressionCode);

    //  return Expression.Lambda<Func<T, bool>>(BinaryExpressionAnd, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> TokenPropertyEqualTo(string Property, string Code, string System, Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType TokenSearchType)
    //{
    //  var ParameterReferance = Expression.Parameter(typeof(T), "x");
    //  MemberExpression propertyReferenceCode = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.TokenIndexConstatnts.Code);
    //  MemberExpression propertyReferenceSystem = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.TokenIndexConstatnts.System);
    //  ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);
    //  ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);

    //  Expression BinaryExpression_Final = null;
    //  switch (TokenSearchType)
    //  {
    //    case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.None:
    //      throw new Exception("Server error: DtoSearchParameterTokenValue.TokenSearchType was set to None.");
    //    case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.MatchCodeOnly:
    //      BinaryExpression_Final = TokenExpression.MatchCodeOnlyExpression(propertyReferenceCode, SearchValueReferenceCode);
    //      break;
    //    case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.MatchSystemOnly:
    //      BinaryExpression_Final = TokenExpression.MatchSystemOnlyExpression(propertyReferenceSystem, SearchValueReferenceSystem);
    //      break;
    //    case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.MatchCodeAndSystem:
    //      BinaryExpression_Final = TokenExpression.MatchCodeAndSystemExpression(propertyReferenceCode, SearchValueReferenceCode, propertyReferenceSystem, SearchValueReferenceSystem);
    //      break;
    //    case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.MatchCodeWithNullSystem:
    //      BinaryExpression_Final = TokenExpression.MatchCodeWithNullSystemExpression(propertyReferenceCode, SearchValueReferenceCode, propertyReferenceSystem);
    //      break;
    //    default:
    //      throw new System.ComponentModel.InvalidEnumArgumentException(TokenSearchType.ToString(), (int)TokenSearchType, typeof(Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType));
    //  }

    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> TokenCollectionIsNotNull(string Property)
    //{
    //  //(x => x.date_List.Count > 0);
    //  var type = typeof(T);
    //  string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

    //  MethodInfo MethodCount = typeof(Enumerable).GetMethods().Where(m => m.Name == "Count" && m.GetParameters().Length == 1).Single().MakeGenericMethod(typeof(TokenIndex));

    //  ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
    //  MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
    //  MethodCallExpression MethodAnyCall = Expression.Call(MethodCount, CollectionProperty);
    //  ConstantExpression constantReference = Expression.Constant(0);
    //  BinaryExpression BinaryExpression = Expression.GreaterThan(MethodAnyCall, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, PatientParameter);
    //}

    //public Expression<Func<T, bool>> TokenCollectionIsNull(string Property)
    //{
    //  //(x => x.date_List.Count == 0);
    //  var type = typeof(T);
    //  string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

    //  MethodInfo MethodCount = typeof(Enumerable).GetMethods().Where(m => m.Name == "Count" && m.GetParameters().Length == 1).Single().MakeGenericMethod(typeof(TokenIndex));

    //  ParameterExpression ResourceParameter = Expression.Parameter(typeof(T), "x");
    //  MemberExpression CollectionProperty = Expression.Property(ResourceParameter, typeof(T).GetProperty(DbPropertyName));
    //  MethodCallExpression MethodCountCall = Expression.Call(MethodCount, CollectionProperty);
    //  ConstantExpression constantReference = Expression.Constant(0);
    //  BinaryExpression BinaryExpression = Expression.Equal(MethodCountCall, constantReference);


    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, ResourceParameter);
    //}

    public Expression<Func<T, bool>> TokenCollectionAnyEqualTo(int Id, string Code, string System, Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType TokenSearchType)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBase), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(T), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression propertyReferenceCode = Expression.Property(InnerParameter, StaticDatabaseInfo.DataLayerIndexPropertyConstatnts.BaseResourceIndexConstatnts.Code);
      MemberExpression propertyReferenceSystem = Expression.Property(InnerParameter, StaticDatabaseInfo.DataLayerIndexPropertyConstatnts.BaseResourceIndexConstatnts.System);
      ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);
      ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);

      //Build Inner Expression
      Expression E_InnerExpression = null;
      switch (TokenSearchType)
      {
        case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.None:
          throw new Exception("Server error: DtoSearchParameterTokenValue.TokenSearchType was set to None.");
        case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.MatchCodeOnly:
          E_InnerExpression = ExpressionSupport.TokenExpression.MatchCodeOnlyExpression(propertyReferenceCode, SearchValueReferenceCode);
          break;
        case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.MatchSystemOnly:
          E_InnerExpression = ExpressionSupport.TokenExpression.MatchSystemOnlyExpression(propertyReferenceSystem, SearchValueReferenceSystem);
          break;
        case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.MatchCodeAndSystem:
          E_InnerExpression = ExpressionSupport.TokenExpression.MatchCodeAndSystemExpression(propertyReferenceCode, SearchValueReferenceCode, propertyReferenceSystem, SearchValueReferenceSystem);
          break;
        case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.MatchCodeWithNullSystem:
          E_InnerExpression = ExpressionSupport.TokenExpression.MatchCodeWithNullSystemExpression(propertyReferenceCode, SearchValueReferenceCode, propertyReferenceSystem);
          break;
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(TokenSearchType.ToString(), (int)TokenSearchType, typeof(Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType));
      }


      

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, E_InnerExpression);

      Expression<Func<ResourceIndexBase, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBase, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, IndexListParameter);



      //string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      ////Outer Any Method
      //MethodInfo ME_Any = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(TokenIndex));

      ////Expression For Any Method
      //ParameterExpression PE_Inner = Expression.Parameter(typeof(TokenIndex), "c");
      //MemberExpression propertyReferenceCode = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.TokenIndexConstatnts.Code);
      //MemberExpression propertyReferenceSystem = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.TokenIndexConstatnts.System);
      //ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);
      //ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);

      ////Build Inner Expression
      //Expression E_InnerExpression = null;
      //switch (TokenSearchType)
      //{
      //  case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.None:
      //    throw new Exception("Server error: DtoSearchParameterTokenValue.TokenSearchType was set to None.");
      //  case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.MatchCodeOnly:
      //    E_InnerExpression = ExpressionSupport.TokenExpression.MatchCodeOnlyExpression(propertyReferenceCode, SearchValueReferenceCode);
      //    break;
      //  case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.MatchSystemOnly:
      //    E_InnerExpression = ExpressionSupport.TokenExpression.MatchSystemOnlyExpression(propertyReferenceSystem, SearchValueReferenceSystem);
      //    break;
      //  case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.MatchCodeAndSystem:
      //    E_InnerExpression = ExpressionSupport.TokenExpression.MatchCodeAndSystemExpression(propertyReferenceCode, SearchValueReferenceCode, propertyReferenceSystem, SearchValueReferenceSystem);
      //    break;
      //  case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.MatchCodeWithNullSystem:
      //    E_InnerExpression = ExpressionSupport.TokenExpression.MatchCodeWithNullSystemExpression(propertyReferenceCode, SearchValueReferenceCode, propertyReferenceSystem);
      //    break;
      //  default:
      //    throw new System.ComponentModel.InvalidEnumArgumentException(TokenSearchType.ToString(), (int)TokenSearchType, typeof(Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType));
      //}

      ////Wrap Any Method Expression into Function
      //Expression<Func<TokenIndex, bool>> InnerFunction = Expression.Lambda<Func<TokenIndex, bool>>(E_InnerExpression, PE_Inner);

      //ParameterExpression PE_Outer = Expression.Parameter(typeof(T), "x");
      //MemberExpression ME_CollectionProperty = Expression.Property(PE_Outer, typeof(T).GetProperty(DbPropertyName));

      ////Call Any Method with Function
      //MethodCallExpression MethodAnyCall = Expression.Call(ME_Any, ME_CollectionProperty, InnerFunction);

      ////Wrap final expression into function
      //return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PE_Outer);
    }

    ////---- Number Index Expressions ------------------------------------------------------
    public Expression<Func<T, bool>> NumberCollectionAnyEqualTo(int Id, decimal LowNumber, decimal MidNumber, decimal HighNumber)
    {
      return NumberCollectionAllEqual(Id, LowNumber, MidNumber, HighNumber, Hl7.Fhir.Model.SearchParameter.SearchComparator.Eq);
    }

    public Expression<Func<T, bool>> NumberCollectionAllNotEqualTo(int Id, decimal LowNumber, decimal MidNumber, decimal HighNumber)
    {
      return NumberCollectionAllEqual(Id, LowNumber, MidNumber, HighNumber, Hl7.Fhir.Model.SearchParameter.SearchComparator.Ne);
    }

    private Expression<Func<T, bool>> NumberCollectionAllEqual(int Id, decimal LowNumber, decimal MidNumber, decimal HighNumber, Hl7.Fhir.Model.SearchParameter.SearchComparator SearchComparator)
    {
      if (SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Eq || SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Ne)
      {
        ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBase), "c");
        ParameterExpression IndexListParameter = Expression.Parameter(typeof(T), "x");

        BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

        MemberExpression propertyReferenceComparator = Expression.Property(InnerParameter, StaticDatabaseInfo.DataLayerIndexPropertyConstatnts.BaseResourceIndexConstatnts.Comparator);
        MemberExpression propertyReferenceNumber = Expression.Property(InnerParameter, StaticDatabaseInfo.DataLayerIndexPropertyConstatnts.BaseResourceIndexConstatnts.Quantity);

        ConstantExpression SearchValueReferenceLow = Expression.Constant(LowNumber, typeof(decimal?));
        ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal?));
        ConstantExpression SearchValueReferenceHigh = Expression.Constant(HighNumber, typeof(decimal?));

        Expression EqualToExpression = null;
        if (SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Eq)
        {
          EqualToExpression = ExpressionSupport.DecimalExpression.EqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceLow, SearchValueReferenceMid, SearchValueReferenceHigh);
        }
        else if (SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Ne)
        {
          EqualToExpression = ExpressionSupport.DecimalExpression.NotEqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceLow, SearchValueReferenceMid, SearchValueReferenceHigh);
        }

        var IdAndExpression = Expression.And(BinaryExpressionIdEquals, EqualToExpression);

        Expression<Func<ResourceIndexBase, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBase, bool>>(IdAndExpression, InnerParameter);

        MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
        return Expression.Lambda<Func<T, bool>>(MethodAnyCall, IndexListParameter);
      }
      else
      {
        throw new FormatException($"SearchParameter.SearchComparator must be Eq or Ne, found: {SearchComparator.ToString()}");
      }
    }
    
    public Expression<Func<T, bool>> NumberCollectionAnyGreaterThan(int Id, decimal MidNumber)
    {
      return NumberCollectionComparator(Id, MidNumber, Hl7.Fhir.Model.SearchParameter.SearchComparator.Gt);
    }

    public Expression<Func<T, bool>> NumberCollectionAnyGreaterThanOrEqualTo(int Id, decimal MidNumber)
    {
      return NumberCollectionComparator(Id, MidNumber, Hl7.Fhir.Model.SearchParameter.SearchComparator.Ge);
    }

    public Expression<Func<T, bool>> NumberCollectionAnyLessThan(int Id, decimal MidNumber)
    {
      return NumberCollectionComparator(Id, MidNumber, Hl7.Fhir.Model.SearchParameter.SearchComparator.Lt);
    }

    public Expression<Func<T, bool>> NumberCollectionAnyLessThanOrEqualTo(int Id, decimal MidNumber)
    {
      return NumberCollectionComparator(Id, MidNumber, Hl7.Fhir.Model.SearchParameter.SearchComparator.Le);
    }

    private Expression<Func<T, bool>> NumberCollectionComparator(int Id, decimal MidNumber, Hl7.Fhir.Model.SearchParameter.SearchComparator SearchComparator)
    {
      if (SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Gt ||
          SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Ge ||
          SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Lt ||
          SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Le)
      {
        ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBase), "c");
        ParameterExpression IndexListParameter = Expression.Parameter(typeof(T), "x");

        BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

        MemberExpression propertyReferenceComparator = Expression.Property(InnerParameter, StaticDatabaseInfo.DataLayerIndexPropertyConstatnts.BaseResourceIndexConstatnts.Comparator);
        MemberExpression propertyReferenceNumber = Expression.Property(InnerParameter, StaticDatabaseInfo.DataLayerIndexPropertyConstatnts.BaseResourceIndexConstatnts.Quantity);

        ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal?));

        //Build Inner Expression      
        Expression ComparatorExpression = null;
        if (SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Gt)
        {
          ComparatorExpression = ExpressionSupport.DecimalExpression.GreaterThanExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);
        }
        else if (SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Ge)
        {
          ComparatorExpression = ExpressionSupport.DecimalExpression.GreaterThanOrEqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);
        }
        else if (SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Lt)
        {
          ComparatorExpression = ExpressionSupport.DecimalExpression.LessThanExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);
        }
        else if (SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Le)
        {
          ComparatorExpression = ExpressionSupport.DecimalExpression.LessThanOrEqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);
        }

        var IdAndExpression = Expression.And(BinaryExpressionIdEquals, ComparatorExpression);

        Expression<Func<ResourceIndexBase, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBase, bool>>(IdAndExpression, InnerParameter);

        MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
        return Expression.Lambda<Func<T, bool>>(MethodAnyCall, IndexListParameter);
      }
      else
      {
        throw new FormatException($"SearchParameter.SearchComparator must be Gt, Ge, Lt or Le, found: {SearchComparator.ToString()}");
      }
    }

    ////---- Quantity Index Expressions ------------------------------------------------------

    //public Expression<Func<T, bool>> QuantityPropertyEqualTo(string Property, decimal LowNumber, decimal MidNumber, decimal HighNumber, string System, string Code)
    //{
    //  var ParameterReferance = Expression.Parameter(typeof(T), "x");
    //  MemberExpression propertyReferenceComparator = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Comparator);
    //  MemberExpression propertyReferenceNumber = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Quantity);

    //  MemberExpression propertyReferenceSystem = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.System);
    //  MemberExpression propertyReferenceCode = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Code);
    //  MemberExpression propertyReferenceUnit = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Unit);

    //  ConstantExpression SearchValueReferenceLow = Expression.Constant(LowNumber, typeof(decimal?));
    //  ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal?));
    //  ConstantExpression SearchValueReferenceHigh = Expression.Constant(HighNumber, typeof(decimal?));

    //  ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);
    //  ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);

    //  Expression BinaryExpression_Number = DecimalExpression.EqualToExpression(
    //    propertyReferenceComparator,
    //    propertyReferenceNumber,
    //    SearchValueReferenceLow,
    //    SearchValueReferenceMid,
    //    SearchValueReferenceHigh);

    //  Expression BinaryExpression_SystemCodeOrUnit = QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(
    //    propertyReferenceSystem,
    //    propertyReferenceCode,
    //    propertyReferenceUnit,
    //    SearchValueReferenceSystem,
    //    SearchValueReferenceCode);

    //  Expression BinaryExpression_Final = Expression.AndAlso(BinaryExpression_Number, BinaryExpression_SystemCodeOrUnit);

    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> QuantityPropertyNotEqualTo(string Property, decimal LowNumber, decimal MidNumber, decimal HighNumber, string System, string Code)
    //{
    //  var ParameterReferance = Expression.Parameter(typeof(T), "x");
    //  MemberExpression propertyReferenceComparator = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Comparator);
    //  MemberExpression propertyReferenceNumber = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Quantity);

    //  MemberExpression propertyReferenceSystem = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.System);
    //  MemberExpression propertyReferenceCode = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Code);
    //  MemberExpression propertyReferenceUnit = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Unit);

    //  ConstantExpression SearchValueReferenceLow = Expression.Constant(LowNumber, typeof(decimal?));
    //  ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal?));
    //  ConstantExpression SearchValueReferenceHigh = Expression.Constant(HighNumber, typeof(decimal?));

    //  ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);
    //  ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);


    //  Expression BinaryExpression_Number = DecimalExpression.NotEqualToExpression(
    //    propertyReferenceComparator,
    //    propertyReferenceNumber,
    //    SearchValueReferenceLow,
    //    SearchValueReferenceMid,
    //    SearchValueReferenceHigh);

    //  Expression BinaryExpression_SystemCodeOrUnit = QuantityExpression.SystemCodeOrUnit_NotEqualTo_Expression(
    //    propertyReferenceSystem,
    //    propertyReferenceCode,
    //    propertyReferenceUnit,
    //    SearchValueReferenceSystem,
    //    SearchValueReferenceCode);

    //  Expression BinaryExpression_Final = Expression.OrElse(BinaryExpression_Number, BinaryExpression_SystemCodeOrUnit);

    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> QuantityPropertyGreaterThan(string Property, decimal MidNumber, string System, string Code)
    //{
    //  var ParameterReferance = Expression.Parameter(typeof(T), "x");
    //  MemberExpression propertyReferenceComparator = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Comparator);
    //  MemberExpression propertyReferenceNumber = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Quantity);

    //  MemberExpression propertyReferenceSystem = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.System);
    //  MemberExpression propertyReferenceCode = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Code);
    //  MemberExpression propertyReferenceUnit = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Unit);

    //  ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal?));

    //  ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);
    //  ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);

    //  Expression BinaryExpression_Number = DecimalExpression.GreaterThanExpression(
    //    propertyReferenceComparator,
    //    propertyReferenceNumber,
    //    SearchValueReferenceMid);

    //  Expression BinaryExpression_SystemCodeOrUnit = QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(
    //    propertyReferenceSystem,
    //    propertyReferenceCode,
    //    propertyReferenceUnit,
    //    SearchValueReferenceSystem,
    //    SearchValueReferenceCode);

    //  Expression BinaryExpression_Final = Expression.AndAlso(BinaryExpression_Number, BinaryExpression_SystemCodeOrUnit);

    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> QuantityPropertyGreaterThanOrEqualTo(string Property, decimal MidNumber, string System, string Code)
    //{
    //  var ParameterReferance = Expression.Parameter(typeof(T), "x");
    //  MemberExpression propertyReferenceComparator = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Comparator);
    //  MemberExpression propertyReferenceNumber = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Quantity);

    //  MemberExpression propertyReferenceSystem = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.System);
    //  MemberExpression propertyReferenceCode = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Code);
    //  MemberExpression propertyReferenceUnit = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Unit);

    //  ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal?));

    //  ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);
    //  ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);

    //  Expression BinaryExpression_Number = DecimalExpression.GreaterThanOrEqualToExpression(
    //    propertyReferenceComparator,
    //    propertyReferenceNumber,
    //    SearchValueReferenceMid);

    //  Expression BinaryExpression_SystemCodeOrUnit = QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(
    //    propertyReferenceSystem,
    //    propertyReferenceCode,
    //    propertyReferenceUnit,
    //    SearchValueReferenceSystem,
    //    SearchValueReferenceCode);

    //  Expression BinaryExpression_Final = Expression.AndAlso(BinaryExpression_Number, BinaryExpression_SystemCodeOrUnit);

    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> QuantityPropertyLessThan(string Property, decimal MidNumber, string System, string Code)
    //{
    //  var ParameterReferance = Expression.Parameter(typeof(T), "x");
    //  MemberExpression propertyReferenceComparator = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Comparator);
    //  MemberExpression propertyReferenceNumber = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Quantity);

    //  MemberExpression propertyReferenceSystem = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.System);
    //  MemberExpression propertyReferenceCode = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Code);
    //  MemberExpression propertyReferenceUnit = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Unit);

    //  ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal?));

    //  ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);
    //  ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);

    //  Expression BinaryExpression_Number = DecimalExpression.LessThanExpression(
    //    propertyReferenceComparator,
    //    propertyReferenceNumber,
    //    SearchValueReferenceMid);

    //  Expression BinaryExpression_SystemCodeOrUnit = QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(
    //    propertyReferenceSystem,
    //    propertyReferenceCode,
    //    propertyReferenceUnit,
    //    SearchValueReferenceSystem,
    //    SearchValueReferenceCode);

    //  Expression BinaryExpression_Final = Expression.AndAlso(BinaryExpression_Number, BinaryExpression_SystemCodeOrUnit);

    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> QuantityPropertyLessThanOrEqualTo(string Property, decimal MidNumber, string System, string Code)
    //{
    //  var ParameterReferance = Expression.Parameter(typeof(T), "x");
    //  MemberExpression propertyReferenceComparator = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Comparator);
    //  MemberExpression propertyReferenceNumber = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Quantity);

    //  MemberExpression propertyReferenceSystem = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.System);
    //  MemberExpression propertyReferenceCode = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Code);
    //  MemberExpression propertyReferenceUnit = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Unit);

    //  ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal?));

    //  ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);
    //  ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);

    //  Expression BinaryExpression_Number = DecimalExpression.LessThanOrEqualToExpression(
    //    propertyReferenceComparator,
    //    propertyReferenceNumber,
    //    SearchValueReferenceMid);

    //  Expression BinaryExpression_SystemCodeOrUnit = QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(
    //    propertyReferenceSystem,
    //    propertyReferenceCode,
    //    propertyReferenceUnit,
    //    SearchValueReferenceSystem,
    //    SearchValueReferenceCode);

    //  Expression BinaryExpression_Final = Expression.AndAlso(BinaryExpression_Number, BinaryExpression_SystemCodeOrUnit);

    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> QuantityPropertyIsNull(string Property)
    //{
    //  var ParameterReferance = Expression.Parameter(typeof(T), "x");
    //  MemberExpression propertyReferenceComparator = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Comparator);
    //  MemberExpression propertyReferenceNumber = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Quantity);

    //  MemberExpression propertyReferenceSystem = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.System);
    //  MemberExpression propertyReferenceCode = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Code);
    //  MemberExpression propertyReferenceUnit = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Unit);

    //  Expression BinaryExpression_Number = DecimalExpression.IsNullExpression(
    //    propertyReferenceComparator,
    //    propertyReferenceNumber);

    //  Expression BinaryExpression_SystemCodeOrUnit = QuantityExpression.SystemCodeOrUnit_IsNull_Expression(
    //    propertyReferenceSystem,
    //    propertyReferenceCode,
    //    propertyReferenceUnit);

    //  Expression BinaryExpression_Final = Expression.AndAlso(BinaryExpression_Number, BinaryExpression_SystemCodeOrUnit);

    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> QuantityPropertyIsNotNull(string Property)
    //{
    //  var ParameterReferance = Expression.Parameter(typeof(T), "x");
    //  MemberExpression propertyReferenceComparator = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Comparator);
    //  MemberExpression propertyReferenceNumber = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Quantity);

    //  MemberExpression propertyReferenceSystem = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.System);
    //  MemberExpression propertyReferenceCode = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Code);
    //  MemberExpression propertyReferenceUnit = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Unit);

    //  Expression BinaryExpression_Number = DecimalExpression.IsNotNullExpression(
    //    propertyReferenceComparator,
    //    propertyReferenceNumber);

    //  Expression BinaryExpression_SystemCodeOrUnit = QuantityExpression.SystemCodeOrUnit_IsNotNull_Expression(
    //    propertyReferenceSystem,
    //    propertyReferenceCode,
    //    propertyReferenceUnit);

    //  Expression BinaryExpression_Final = Expression.OrElse(BinaryExpression_Number, BinaryExpression_SystemCodeOrUnit);

    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    //}


    //public Expression<Func<T, bool>> QuantityCollectionAnyEqualTo(string Property, decimal LowNumber, decimal MidNumber, decimal HighNumber, string System, string Code)
    //{
    //  string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

    //  //Outer Any Method
    //  MethodInfo MI_Any = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(QuantityIndex));

    //  //Expression For Any Method
    //  ParameterExpression PE_Inner = Expression.Parameter(typeof(QuantityIndex), "c");

    //  MemberExpression propertyReferenceComparator = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Comparator);
    //  MemberExpression propertyReferenceNumber = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Quantity);

    //  MemberExpression propertyReferenceSystem = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.System);
    //  MemberExpression propertyReferenceCode = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Code);
    //  MemberExpression propertyReferenceUnit = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Unit);

    //  ConstantExpression SearchValueReferenceLow = Expression.Constant(LowNumber, typeof(decimal));
    //  ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal));
    //  ConstantExpression SearchValueReferenceHigh = Expression.Constant(HighNumber, typeof(decimal));

    //  ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);
    //  ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);

    //  //Build Inner Expression
    //  Expression E_InnerExpression1 = DecimalExpression.EqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceLow, SearchValueReferenceMid, SearchValueReferenceHigh);
    //  Expression E_InnerExpression2 = QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(propertyReferenceSystem, propertyReferenceCode, propertyReferenceUnit, SearchValueReferenceSystem, SearchValueReferenceCode);
    //  Expression E_Final_InnerExpression = Expression.AndAlso(E_InnerExpression1, E_InnerExpression2);

    //  //Wrap Any Method Expression into Function
    //  Expression<Func<QuantityIndex, bool>> InnerFunction = Expression.Lambda<Func<QuantityIndex, bool>>(E_Final_InnerExpression, PE_Inner);

    //  ParameterExpression PE_Outer = Expression.Parameter(typeof(T), "x");
    //  MemberExpression ME_CollectionProperty = Expression.Property(PE_Outer, typeof(T).GetProperty(DbPropertyName));

    //  //Call Any Method with Function
    //  MethodCallExpression MethodAnyCall = Expression.Call(MI_Any, ME_CollectionProperty, InnerFunction);

    //  //Wrap final expression into function
    //  return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PE_Outer);
    //}

    //public Expression<Func<T, bool>> QuantityCollectionAllNotEqualTo(string Property, decimal LowNumber, decimal MidNumber, decimal HighNumber, string System, string Code)
    //{
    //  string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

    //  //Outer Any Method
    //  MethodInfo ME_All = typeof(Enumerable).GetMethods().Where(m => m.Name == "All" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(QuantityIndex));

    //  //Expression For Any Method
    //  ParameterExpression PE_Inner = Expression.Parameter(typeof(QuantityIndex), "c");

    //  //Expression For Any Method
    //  MemberExpression propertyReferenceComparator = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Comparator);
    //  MemberExpression propertyReferenceNumber = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Quantity);

    //  MemberExpression propertyReferenceSystem = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.System);
    //  MemberExpression propertyReferenceCode = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Code);
    //  MemberExpression propertyReferenceUnit = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Unit);

    //  ConstantExpression SearchValueReferenceLow = Expression.Constant(LowNumber, typeof(decimal));
    //  ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal));
    //  ConstantExpression SearchValueReferenceHigh = Expression.Constant(HighNumber, typeof(decimal));

    //  ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);
    //  ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);

    //  //Build Inner Expression
    //  //Non of the values are equal to.
    //  Expression E_InnerExpression1 = DecimalExpression.NotEqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceLow, SearchValueReferenceMid, SearchValueReferenceHigh);
    //  Expression E_InnerExpression2 = QuantityExpression.SystemCodeOrUnit_NotEqualTo_Expression(propertyReferenceSystem, propertyReferenceCode, propertyReferenceUnit, SearchValueReferenceSystem, SearchValueReferenceCode);
    //  Expression E_Final_InnerExpression = Expression.OrElse(E_InnerExpression1, E_InnerExpression2);

    //  //Wrap Any Method Expression into Function
    //  Expression<Func<QuantityIndex, bool>> InnerFunction = Expression.Lambda<Func<QuantityIndex, bool>>(E_Final_InnerExpression, PE_Inner);

    //  ParameterExpression PE_Outer = Expression.Parameter(typeof(T), "x");
    //  MemberExpression ME_CollectionProperty = Expression.Property(PE_Outer, typeof(T).GetProperty(DbPropertyName));

    //  //Call Any Method with Function
    //  MethodCallExpression MethodAllCall = Expression.Call(ME_All, ME_CollectionProperty, InnerFunction);

    //  //Wrap final expression into function
    //  return Expression.Lambda<Func<T, bool>>(MethodAllCall, PE_Outer);
    //}

    //public Expression<Func<T, bool>> QuantityCollectionAnyGreaterThan(string Property, decimal MidNumber, string System, string Code)
    //{
    //  string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

    //  //Outer Any Method
    //  MethodInfo MI_Any = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(QuantityIndex));

    //  //Expression For Any Method
    //  ParameterExpression PE_Inner = Expression.Parameter(typeof(QuantityIndex), "c");

    //  MemberExpression propertyReferenceComparator = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Comparator);
    //  MemberExpression propertyReferenceNumber = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Quantity);

    //  MemberExpression propertyReferenceSystem = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.System);
    //  MemberExpression propertyReferenceCode = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Code);
    //  MemberExpression propertyReferenceUnit = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Unit);

    //  ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal));

    //  ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);
    //  ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);

    //  //Build Inner Expression
    //  Expression E_InnerExpression1 = DecimalExpression.GreaterThanExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);
    //  Expression E_InnerExpression2 = QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(propertyReferenceSystem, propertyReferenceCode, propertyReferenceUnit, SearchValueReferenceSystem, SearchValueReferenceCode);
    //  Expression E_Final_InnerExpression = Expression.AndAlso(E_InnerExpression1, E_InnerExpression2);

    //  //Wrap Any Method Expression into Function
    //  Expression<Func<QuantityIndex, bool>> InnerFunction = Expression.Lambda<Func<QuantityIndex, bool>>(E_Final_InnerExpression, PE_Inner);

    //  ParameterExpression PE_Outer = Expression.Parameter(typeof(T), "x");
    //  MemberExpression ME_CollectionProperty = Expression.Property(PE_Outer, typeof(T).GetProperty(DbPropertyName));

    //  //Call Any Method with Function
    //  MethodCallExpression MethodAnyCall = Expression.Call(MI_Any, ME_CollectionProperty, InnerFunction);

    //  //Wrap final expression into function
    //  return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PE_Outer);
    //}

    //public Expression<Func<T, bool>> QuantityCollectionAnyGreaterThanOrEqualTo(string Property, decimal MidNumber, string System, string Code)
    //{
    //  string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

    //  //Outer Any Method
    //  MethodInfo MI_Any = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(QuantityIndex));

    //  //Expression For Any Method
    //  ParameterExpression PE_Inner = Expression.Parameter(typeof(QuantityIndex), "c");

    //  MemberExpression propertyReferenceComparator = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Comparator);
    //  MemberExpression propertyReferenceNumber = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Quantity);

    //  MemberExpression propertyReferenceSystem = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.System);
    //  MemberExpression propertyReferenceCode = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Code);
    //  MemberExpression propertyReferenceUnit = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Unit);

    //  ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal));

    //  ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);
    //  ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);

    //  //Build Inner Expression
    //  Expression E_InnerExpression1 = DecimalExpression.GreaterThanOrEqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);
    //  Expression E_InnerExpression2 = QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(propertyReferenceSystem, propertyReferenceCode, propertyReferenceUnit, SearchValueReferenceSystem, SearchValueReferenceCode);
    //  Expression E_Final_InnerExpression = Expression.AndAlso(E_InnerExpression1, E_InnerExpression2);

    //  //Wrap Any Method Expression into Function
    //  Expression<Func<QuantityIndex, bool>> InnerFunction = Expression.Lambda<Func<QuantityIndex, bool>>(E_Final_InnerExpression, PE_Inner);

    //  ParameterExpression PE_Outer = Expression.Parameter(typeof(T), "x");
    //  MemberExpression ME_CollectionProperty = Expression.Property(PE_Outer, typeof(T).GetProperty(DbPropertyName));

    //  //Call Any Method with Function
    //  MethodCallExpression MethodAnyCall = Expression.Call(MI_Any, ME_CollectionProperty, InnerFunction);

    //  //Wrap final expression into function
    //  return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PE_Outer);
    //}

    //public Expression<Func<T, bool>> QuantityCollectionAnyLessThan(string Property, decimal MidNumber, string System, string Code)
    //{
    //  string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

    //  //Outer Any Method
    //  MethodInfo MI_Any = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(QuantityIndex));

    //  //Expression For Any Method
    //  ParameterExpression PE_Inner = Expression.Parameter(typeof(QuantityIndex), "c");

    //  MemberExpression propertyReferenceComparator = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Comparator);
    //  MemberExpression propertyReferenceNumber = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Quantity);

    //  MemberExpression propertyReferenceSystem = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.System);
    //  MemberExpression propertyReferenceCode = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Code);
    //  MemberExpression propertyReferenceUnit = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Unit);

    //  ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal));

    //  ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);
    //  ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);

    //  //Build Inner Expression
    //  Expression E_InnerExpression1 = DecimalExpression.LessThanExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);
    //  Expression E_InnerExpression2 = QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(propertyReferenceSystem, propertyReferenceCode, propertyReferenceUnit, SearchValueReferenceSystem, SearchValueReferenceCode);
    //  Expression E_Final_InnerExpression = Expression.AndAlso(E_InnerExpression1, E_InnerExpression2);

    //  //Wrap Any Method Expression into Function
    //  Expression<Func<QuantityIndex, bool>> InnerFunction = Expression.Lambda<Func<QuantityIndex, bool>>(E_Final_InnerExpression, PE_Inner);

    //  ParameterExpression PE_Outer = Expression.Parameter(typeof(T), "x");
    //  MemberExpression ME_CollectionProperty = Expression.Property(PE_Outer, typeof(T).GetProperty(DbPropertyName));

    //  //Call Any Method with Function
    //  MethodCallExpression MethodAnyCall = Expression.Call(MI_Any, ME_CollectionProperty, InnerFunction);

    //  //Wrap final expression into function
    //  return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PE_Outer);
    //}

    //public Expression<Func<T, bool>> QuantityCollectionAnyLessThanOrEqualTo(string Property, decimal MidNumber, string System, string Code)
    //{
    //  string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

    //  //Outer Any Method
    //  MethodInfo MI_Any = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(QuantityIndex));

    //  //Expression For Any Method
    //  ParameterExpression PE_Inner = Expression.Parameter(typeof(QuantityIndex), "c");

    //  MemberExpression propertyReferenceComparator = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Comparator);
    //  MemberExpression propertyReferenceNumber = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Quantity);

    //  MemberExpression propertyReferenceSystem = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.System);
    //  MemberExpression propertyReferenceCode = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Code);
    //  MemberExpression propertyReferenceUnit = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Unit);

    //  ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal));

    //  ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);
    //  ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);

    //  //Build Inner Expression
    //  Expression E_InnerExpression1 = DecimalExpression.LessThanOrEqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);
    //  Expression E_InnerExpression2 = QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(propertyReferenceSystem, propertyReferenceCode, propertyReferenceUnit, SearchValueReferenceSystem, SearchValueReferenceCode);
    //  Expression E_Final_InnerExpression = Expression.AndAlso(E_InnerExpression1, E_InnerExpression2);

    //  //Wrap Any Method Expression into Function
    //  Expression<Func<QuantityIndex, bool>> InnerFunction = Expression.Lambda<Func<QuantityIndex, bool>>(E_Final_InnerExpression, PE_Inner);

    //  ParameterExpression PE_Outer = Expression.Parameter(typeof(T), "x");
    //  MemberExpression ME_CollectionProperty = Expression.Property(PE_Outer, typeof(T).GetProperty(DbPropertyName));

    //  //Call Any Method with Function
    //  MethodCallExpression MethodAnyCall = Expression.Call(MI_Any, ME_CollectionProperty, InnerFunction);

    //  //Wrap final expression into function
    //  return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PE_Outer);
    //}

    //public Expression<Func<T, bool>> QuantityCollectionIsNull(string Property)
    //{
    //  //(x => x.date_List.Count == 0);
    //  var type = typeof(T);
    //  string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

    //  MethodInfo MethodCount = typeof(Enumerable).GetMethods().Where(m => m.Name == "Count" && m.GetParameters().Length == 1).Single().MakeGenericMethod(typeof(QuantityIndex));

    //  ParameterExpression ResourceParameter = Expression.Parameter(typeof(T), "x");
    //  MemberExpression CollectionProperty = Expression.Property(ResourceParameter, typeof(T).GetProperty(DbPropertyName));
    //  MethodCallExpression MethodCountCall = Expression.Call(MethodCount, CollectionProperty);
    //  ConstantExpression constantReference = Expression.Constant(0);
    //  BinaryExpression BinaryExpression = Expression.Equal(MethodCountCall, constantReference);

    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, ResourceParameter);
    //}

    //public Expression<Func<T, bool>> QuantityCollectionIsNotNull(string Property)
    //{
    //  //(x => x.date_List.Count > 0);
    //  var type = typeof(T);
    //  string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

    //  MethodInfo MethodCount = typeof(Enumerable).GetMethods().Where(m => m.Name == "Count" && m.GetParameters().Length == 1).Single().MakeGenericMethod(typeof(QuantityIndex));

    //  ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
    //  MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
    //  MethodCallExpression MethodAnyCall = Expression.Call(MethodCount, CollectionProperty);
    //  ConstantExpression constantReference = Expression.Constant(0);
    //  BinaryExpression BinaryExpression = Expression.GreaterThan(MethodAnyCall, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, PatientParameter);
    //}


    ////---- Uri Index Expressions ------------------------------------------------------

    //public Expression<Func<T, bool>> UriPropertyEqualTo(string Property, string Value)
    //{
    //  //(x => x.Meta.profile == "https://www.megaspin.net/store/default.asp?pid=b-tack-chop-ii")
    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReference = Expression.Property(ParameterReferance, Property);
    //  var constantReference = Expression.Constant(Value);
    //  var BinaryExpression = Expression.Equal(propertyReference, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> UriPropertyIsNotNull(string Property)
    //{
    //  //(x => x.birthdate_DateTimeOffset != null);
    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.UriIndexConstatnts.Uri);
    //  var constantReference = Expression.Constant(null);
    //  var BinaryExpression = Expression.NotEqual(propertyReference, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> UriPropertyIsNull(string Property)
    //{
    //  //(x => x.birthdate_DateTimeOffset == null);
    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.UriIndexConstatnts.Uri);
    //  var constantReference = Expression.Constant(null);
    //  var BinaryExpression = Expression.Equal(propertyReference, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> UriPropertyContains(string Property, string Value)
    //{
    //  MethodInfo MethodContains = typeof(string).GetMethods().Where(m => m.Name == "Contains" && m.GetParameters().Length == 1).Single();

    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReference = Expression.Property(ParameterReferance, Property);
    //  var constantReference = Expression.Constant(Value);
    //  var MethodContainsCall = Expression.Call(propertyReference, MethodContains, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(MethodContainsCall, ParameterReferance);
    //}

    //public Expression<Func<T, bool>> UriPropertyStartsWith(string Property, string Value)
    //{
    //  //(x => x.FhirId.StartsWith("a99b5c95-b546-46ee-8992-19a7ca703d4a"))      
    //  MethodInfo MethodStartsWith = typeof(string).GetMethods().Where(m => m.Name == "StartsWith" && m.GetParameters().Length == 1).Single();

    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReference = Expression.Property(ParameterReferance, Property);
    //  var constantReference = Expression.Constant(Value);
    //  var MethodStartsWithCall = Expression.Call(propertyReference, MethodStartsWith, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(MethodStartsWithCall, ParameterReferance);
    //}

    //public Expression<Func<T, bool>> UriPropertyEndsWith(string Property, string Value)
    //{
    //  //(x => x.FhirId.StartsWith("a99b5c95-b546-46ee-8992-19a7ca703d4a"))      
    //  MethodInfo MethodStartsWith = typeof(string).GetMethods().Where(m => m.Name == "EndsWith" && m.GetParameters().Length == 1).Single();

    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReference = Expression.Property(ParameterReferance, Property);
    //  var constantReference = Expression.Constant(Value);
    //  var MethodStartsWithCall = Expression.Call(propertyReference, MethodStartsWith, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(MethodStartsWithCall, ParameterReferance);
    //}


    public Expression<Func<T, bool>> UriCollectionAnyEqualTo(int Id, string Value)
    {
      //(x => x.IndexList.Any(c => c.String.StartsWith("Mill") & c.ServiceSearchParameterId == Id);
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBase), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(T), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.DataLayerIndexPropertyConstatnts.BaseResourceIndexConstatnts.Uri);
      ConstantExpression InnerValue = Expression.Constant(Value);

      MethodInfo MethodEquals = typeof(string).GetMethods().Where(m => m.Name == "Equals" && m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == typeof(string)).Single();
      MethodCallExpression MethodEqualsCall = Expression.Call(InnerProperty, MethodEquals, InnerValue);
      
      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, MethodEqualsCall);

      Expression<Func<ResourceIndexBase, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBase, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<T, bool>> UriCollectionAnyContains(int Id, string Value)
    {      
      //(x => x.IndexList.Any(c => c.String.Contains("myserver.net.au/stu3/api/Patient/1") & c.ServiceSearchParameterId == Id);
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBase), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(T), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.DataLayerIndexPropertyConstatnts.BaseResourceIndexConstatnts.Uri);
      ConstantExpression InnerValue = Expression.Constant(Value);

      MethodInfo MethodContains = typeof(string).GetMethods().Where(m => m.Name == "Contains" && m.GetParameters().Length == 1).Single();
      
      MethodCallExpression MethodEqualsCall = Expression.Call(InnerProperty, MethodContains, InnerValue);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, MethodEqualsCall);

      Expression<Func<ResourceIndexBase, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBase, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, IndexListParameter);      
    }

    public Expression<Func<T, bool>> UriCollectionAnyStartsWith(int Id, string Value)
    {      
      //(x => x.IndexList.Any(c => c.String.StartsWith("myserver.net.au/stu3/api/Patient/1") & c.ServiceSearchParameterId == Id);
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBase), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(T), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.DataLayerIndexPropertyConstatnts.BaseResourceIndexConstatnts.Uri);
      ConstantExpression InnerValue = Expression.Constant(Value);

      MethodInfo MethodStartsWith = typeof(string).GetMethods().Where(m => m.Name == "StartsWith" && m.GetParameters().Length == 1).Single();
      
      MethodCallExpression MethodEqualsCall = Expression.Call(InnerProperty, MethodStartsWith, InnerValue);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, MethodEqualsCall);

      Expression<Func<ResourceIndexBase, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBase, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, IndexListParameter);      
    }

    public Expression<Func<T, bool>> UriCollectionAnyEndsWith(int Id, string Value)
    {      
      //(x => x.IndexList.Any(c => c.String.EndsWith("myserver.net.au/stu3/api/Patient/1") & c.ServiceSearchParameterId == Id);
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBase), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(T), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.DataLayerIndexPropertyConstatnts.BaseResourceIndexConstatnts.Uri);
      ConstantExpression InnerValue = Expression.Constant(Value);

      MethodInfo MethodEndsWith = typeof(string).GetMethods().Where(m => m.Name == "EndsWith" && m.GetParameters().Length == 1).Single();

      MethodCallExpression MethodEqualsCall = Expression.Call(InnerProperty, MethodEndsWith, InnerValue);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, MethodEqualsCall);

      Expression<Func<ResourceIndexBase, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBase, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, IndexListParameter);      
    }

    //public Expression<Func<T, bool>> UriCollectionIsNull(string Property)
    //{
    //  var type = typeof(T);
    //  string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

    //  MethodInfo MethodCount = typeof(Enumerable).GetMethods().Where(m => m.Name == "Count" && m.GetParameters().Length == 1).Single().MakeGenericMethod(typeof(UriIndex));

    //  ParameterExpression ResourceParameter = Expression.Parameter(typeof(T), "x");
    //  MemberExpression CollectionProperty = Expression.Property(ResourceParameter, typeof(T).GetProperty(DbPropertyName));
    //  MethodCallExpression MethodCountCall = Expression.Call(MethodCount, CollectionProperty);
    //  ConstantExpression constantReference = Expression.Constant(0);
    //  BinaryExpression BinaryExpression = Expression.Equal(MethodCountCall, constantReference);

    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, ResourceParameter);
    //}

    //public Expression<Func<T, bool>> UriCollectionIsNotNull(string Property)
    //{
    //  var type = typeof(T);
    //  string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

    //  MethodInfo MethodCount = typeof(Enumerable).GetMethods().Where(m => m.Name == "Count" && m.GetParameters().Length == 1).Single().MakeGenericMethod(typeof(UriIndex));

    //  ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
    //  MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
    //  MethodCallExpression MethodAnyCall = Expression.Call(MethodCount, CollectionProperty);
    //  ConstantExpression constantReference = Expression.Constant(0);
    //  BinaryExpression BinaryExpression = Expression.GreaterThan(MethodAnyCall, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, PatientParameter);
    //}


    ////---- Referance Index Expressions ------------------------------------------------------

    //public Expression<Func<T, bool>> ReferancePropertyEqualTo_ByKey(string Property, int UrlStoreKey, string Resource, string FhirId, string History)
    //{
    //  var ParameterReferance = Expression.Parameter(typeof(T), "x");
    //  MemberExpression propertyReferenceUrlStoreKey = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.ServiceRootURL_StoreID);
    //  MemberExpression propertyReferenceResource = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.Type);    
    //  MemberExpression propertyReferenceFhirId = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.FhirId);
    //  MemberExpression propertyReferenceHistory = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.VersionId);



    //  ConstantExpression SearchValueReferenceUrlStoreKey = Expression.Constant(UrlStoreKey, typeof(int?));
    //  ConstantExpression SearchValueReferenceResource = Expression.Constant(Resource, typeof(string));
    //  ConstantExpression SearchValueReferenceFhirID = Expression.Constant(FhirId, typeof(string));
    //  ConstantExpression SearchValueReferenceHistory = Expression.Constant(History, typeof(string));


    //  Expression BinaryExpression_Final = ReferanceExpression.EqualTo_ByURLStoreKey_Expression(
    //    propertyReferenceUrlStoreKey,
    //    propertyReferenceResource,
    //    propertyReferenceFhirId,
    //    propertyReferenceHistory,
    //    SearchValueReferenceUrlStoreKey,
    //    SearchValueReferenceResource,
    //    SearchValueReferenceFhirID,
    //    SearchValueReferenceHistory);

    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> ReferancePropertyEqualTo_ByUrlString(string Property, string UrlString, string Resource, string FhirId, string History)
    //{
    //  var ParameterReferance = Expression.Parameter(typeof(T), "x");

    //  MemberExpression propertyReferenceUrl = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.Url);
    //  MemberExpression propertyReferenceServiceRootURL_StoreRootUrl = Expression.Property(propertyReferenceUrl, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.ServiceRootURL_Store.RootUrl);
    //  MemberExpression propertyReferenceResource = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.Type);
    //  MemberExpression propertyReferenceFhirId = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.FhirId);
    //  MemberExpression propertyReferenceHistory = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.VersionId);

    //  ConstantExpression SearchValueReferenceUrlString = Expression.Constant(UrlString, typeof(string));
    //  ConstantExpression SearchValueReferenceResource = Expression.Constant(Resource, typeof(string));
    //  ConstantExpression SearchValueReferenceFhirID = Expression.Constant(FhirId, typeof(string));
    //  ConstantExpression SearchValueReferenceHistory = Expression.Constant(History, typeof(string));


    //  Expression BinaryExpression_Final = ReferanceExpression.EqualTo_ByURLString_Expression(
    //    propertyReferenceUrl,
    //    propertyReferenceServiceRootURL_StoreRootUrl,
    //    propertyReferenceResource,
    //    propertyReferenceFhirId,
    //    propertyReferenceHistory,
    //    SearchValueReferenceUrlString,
    //    SearchValueReferenceResource,
    //    SearchValueReferenceFhirID,
    //    SearchValueReferenceHistory);

    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> ReferancePropertyIsNull(string Property)
    //{
    //  //(x => x.birthdate_DateTimeOffset == null);
    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.FhirId);
    //  var constantReference = Expression.Constant(null);
    //  var BinaryExpression = Expression.Equal(propertyReference, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    //}

    //public Expression<Func<T, bool>> ReferancePropertyIsNotNull(string Property)
    //{
    //  //(x => x.birthdate_DateTimeOffset != null);
    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.FhirId);
    //  var constantReference = Expression.Constant(null);
    //  var BinaryExpression = Expression.NotEqual(propertyReference, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    //}


    public Expression<Func<T, bool>> ReferanceCollectionAnyEqualTo_ByKey(int Id, int ServiceBaseUrlId, string ResourceType, string FhirId, string VersionId)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBase), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(T), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression propertyReferenceServiceBaseUrlId = Expression.Property(InnerParameter, StaticDatabaseInfo.DataLayerIndexPropertyConstatnts.BaseResourceIndexConstatnts.ReferenceServiceBaseUrlId);
      MemberExpression propertyReferenceResourceType = Expression.Property(InnerParameter, StaticDatabaseInfo.DataLayerIndexPropertyConstatnts.BaseResourceIndexConstatnts.ReferenceResourceType);
      MemberExpression propertyReferenceFhirId = Expression.Property(InnerParameter, StaticDatabaseInfo.DataLayerIndexPropertyConstatnts.BaseResourceIndexConstatnts.ReferenceFhirId);
      MemberExpression propertyReferenceVersionId = Expression.Property(InnerParameter, StaticDatabaseInfo.DataLayerIndexPropertyConstatnts.BaseResourceIndexConstatnts.ReferenceVersionId);

      ConstantExpression SearchValueReferenceServiceBaseUrlId = Expression.Constant(ServiceBaseUrlId, typeof(int?));
      ConstantExpression SearchValueReferenceResourceType = Expression.Constant(ResourceType, typeof(string));
      ConstantExpression SearchValueReferenceFhirId = Expression.Constant(FhirId, typeof(string));
      ConstantExpression SearchValueReferenceVersionId = Expression.Constant(VersionId, typeof(string));

      //Build Inner Expression
      Expression BinaryExpression_Final = ExpressionSupport.ReferanceExpression.EqualTo_ByURLStoreKey_Expression(
        propertyReferenceServiceBaseUrlId,
        propertyReferenceResourceType,
        propertyReferenceFhirId,
        propertyReferenceVersionId,
        SearchValueReferenceServiceBaseUrlId,
        SearchValueReferenceResourceType,
        SearchValueReferenceFhirId,
        SearchValueReferenceVersionId);
      
      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, BinaryExpression_Final);

      Expression<Func<ResourceIndexBase, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBase, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, IndexListParameter);

    }

    public Expression<Func<T, bool>> ReferanceCollectionAnyEqualTo_ByUrlString(int Id, string UrlString, string ResourceType, string FhirId, string VersionId)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBase), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(T), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression propertyReferenceServiceBaseUrlId = Expression.Property(InnerParameter, StaticDatabaseInfo.DataLayerIndexPropertyConstatnts.BaseResourceIndexConstatnts.ReferenceServiceBaseUrlId);
      MemberExpression propertyReferenceResourceType = Expression.Property(InnerParameter, StaticDatabaseInfo.DataLayerIndexPropertyConstatnts.BaseResourceIndexConstatnts.ReferenceResourceType);
      MemberExpression propertyReferenceFhirId = Expression.Property(InnerParameter, StaticDatabaseInfo.DataLayerIndexPropertyConstatnts.BaseResourceIndexConstatnts.ReferenceFhirId);
      MemberExpression propertyReferenceVersionId = Expression.Property(InnerParameter, StaticDatabaseInfo.DataLayerIndexPropertyConstatnts.BaseResourceIndexConstatnts.ReferenceVersionId);
      MemberExpression propertyReferenceUrl = Expression.Property(InnerParameter, StaticDatabaseInfo.DataLayerIndexPropertyConstatnts.BaseResourceIndexConstatnts.ReferenceUrl);
      MemberExpression propertyReferenceServiceRootURL_StoreRootUrl = Expression.Property(propertyReferenceUrl, StaticDatabaseInfo.DataLayerIndexPropertyConstatnts.ServiceBaseUrlConstatnts.Url);

      ConstantExpression SearchValueReferenceUrlString = Expression.Constant(UrlString, typeof(string));
      ConstantExpression SearchValueReferenceResource = Expression.Constant(ResourceType, typeof(string));
      ConstantExpression SearchValueReferenceFhirID = Expression.Constant(FhirId, typeof(string));
      ConstantExpression SearchValueReferenceHistory = Expression.Constant(VersionId, typeof(string));

      //Build Inner Expression
      Expression BinaryExpression_Final = ExpressionSupport.ReferanceExpression.EqualTo_ByURLString_Expression(
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

      Expression<Func<ResourceIndexBase, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBase, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<T, bool>> ReferanceCollectionIsNotNull(int Id)
    {
      //(x => x.IndexList.Any(c => c.ServiceSearchParameterId == Id) == false);      
      return SearchParameterIdNull(Id, false);
    }

    public Expression<Func<T, bool>> ReferanceCollectionIsNull(int Id)
    {
      //(x => x.IndexList.Any(c => c.ServiceSearchParameterId == Id) == true);      
      return SearchParameterIdNull(Id, true);
    }

   

    ////---- QuantityRange Index Expressions ------------------------------------------------------

    ////Not implemented as there are no QuantityRange search parameters as yet in FHIR spec, as of this early STU3 release


    ///---- General Index Expressions ------------------------------------------------------

    private BinaryExpression SearchParameterIdBinaryExpression(int Id, ParameterExpression InnerParameter)
    {
      MemberExpression InnerPropertyId = Expression.Property(InnerParameter, StaticDatabaseInfo.DataLayerIndexPropertyConstatnts.BaseResourceIndexConstatnts.ServiceSearchParameterId);
      ConstantExpression InnerValueId = Expression.Constant(Id);
      return Expression.Equal(InnerPropertyId, InnerValueId);
    }

    private MethodCallExpression IndexListAnyMethodCallExpression(ParameterExpression IndexListParameter, Expression<Func<ResourceIndexBase, bool>> InnerFunction)
    {
      var type = typeof(T);
      string DbPropertyName = StaticDatabaseInfo.DataLayerIndexPropertyConstatnts.BaseResourceConstatnts.IndexList;
      //ParameterExpression IndexListParameter = Expression.Parameter(typeof(T), "x");
      MemberExpression IndexListProperty = Expression.Property(IndexListParameter, typeof(T).GetProperty(DbPropertyName));
      MethodInfo MethodAny = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(ResourceIndexBase));
      MethodCallExpression MethodAnyCall = Expression.Call(MethodAny, IndexListProperty, InnerFunction);
      return MethodAnyCall;
    }

    public Expression<Func<T, bool>> SearchParameterIdIsNotNull(int Id)
    {
      //(x => x.IndexList.Any(c => c.ServiceSearchParameterId == Id).Count > 0);      
      return SearchParameterIdNull(Id, false);
    }

    public Expression<Func<T, bool>> SearchParameterIsNull(int Id)
    {
      //(x => x.IndexList.Any(c => c.ServiceSearchParameterId == Id).Count == 0);      
      return SearchParameterIdNull(Id, true);
    }

    private Expression<Func<T, bool>> SearchParameterIdNull(int Id, bool IsNull)
    {
      //IsNull = true
      //(x => x.IndexList.Any(c => c.ServiceSearchParameterId == Id) == true);      
      //IsNull = false
      //(x => x.IndexList.Any(c => c.ServiceSearchParameterId == Id) == false);                  
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(T), "x");      
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBase), "c");

      BinaryExpression BinaryIdExpression = SearchParameterIdBinaryExpression(Id, InnerParameter);

      Expression<Func<ResourceIndexBase, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBase, bool>>(BinaryIdExpression, InnerParameter);
      
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
      
      return Expression.Lambda<Func<T, bool>>(BinaryExpression, IndexListParameter);
    }
  }

}

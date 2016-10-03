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
  public class ResourceSearch<T> where T : ResourceIndexBase
  {
    //---- String Index Expressions ------------------------------------------------------
    public Expression<Func<T, bool>> StringPropertyIsNotNull(string Property)
    {
      //(x => x.birthdate_DateTimeOffset != null);
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.StringIndexConstatnts.String);
      var constantReference = Expression.Constant(null);
      var BinaryExpression = Expression.NotEqual(propertyReference, constantReference);
      return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> StringPropertyIsNull(string Property)
    {
      //(x => x.birthdate_DateTimeOffset == null);
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.StringIndexConstatnts.String);
      var constantReference = Expression.Constant(null);
      var BinaryExpression = Expression.Equal(propertyReference, constantReference);
      return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> StringPropertyEqualTo(string Property, string Value)
    {
      //(x => x.FhirId == "a99b5c95-b546-46ee-8992-19a7ca703d4a")
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReference = Expression.Property(ParameterReferance, Property);
      var constantReference = Expression.Constant(StringSupport.ToLowerAndRemoveDiacritics(Value.Trim()));
      var BinaryExpression = Expression.Equal(propertyReference, constantReference);
      return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> StringPropertyStartsWith(string Property, string Value)
    {
      //(x => x.FhirId.StartsWith("a99b5c95-b546-46ee-8992-19a7ca703d4a"))      
      MethodInfo MethodStartsWith = typeof(String).GetMethods().Where(m => m.Name == "StartsWith" && m.GetParameters().Length == 1).Single();

      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReference = Expression.Property(ParameterReferance, Property);
      var constantReference = Expression.Constant(StringSupport.ToLowerAndRemoveDiacritics(Value.Trim()));
      var MethodStartsWithCall = Expression.Call(propertyReference, MethodStartsWith, constantReference);
      return Expression.Lambda<Func<T, bool>>(MethodStartsWithCall, ParameterReferance);
    }

    public Expression<Func<T, bool>> StringPropertyStartsOrEndsWith(string Property, string Value)
    {
      //(x => x.FhirId.StartsWith("a99b5c95-b546-46ee-8992-19a7ca703d4a"))      
      MethodInfo MethodStartsWith = typeof(String).GetMethods().Where(m => m.Name == "StartsWith" && m.GetParameters().Length == 1).Single();
      MethodInfo MethodEndsWith = typeof(String).GetMethods().Where(m => m.Name == "EndsWith" && m.GetParameters().Length == 1).Single();

      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReference = Expression.Property(ParameterReferance, Property);
      var constantReference = Expression.Constant(StringSupport.ToLowerAndRemoveDiacritics(Value.Trim()));

      var MethodStartsWithCall = Expression.Call(propertyReference, MethodStartsWith, constantReference);
      var MethodEndsWithCall = Expression.Call(propertyReference, MethodEndsWith, constantReference);
      var OrExpression = Expression.OrElse(MethodStartsWithCall, MethodEndsWithCall);

      return Expression.Lambda<Func<T, bool>>(OrExpression, ParameterReferance);
    }

    public Expression<Func<T, bool>> StringPropertyContains(string Property, string Value)
    {
      //(x => x.FhirId.Contains("d3da-493a-b4f2"))      
      MethodInfo MethodContains = typeof(String).GetMethods().Where(m => m.Name == "Contains" && m.GetParameters().Length == 1).Single();

      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReference = Expression.Property(ParameterReferance, Property);
      var constantReference = Expression.Constant(StringSupport.ToLowerAndRemoveDiacritics(Value.Trim()));
      var MethodContainsCall = Expression.Call(propertyReference, MethodContains, constantReference);
      return Expression.Lambda<Func<T, bool>>(MethodContainsCall, ParameterReferance);
    }

    public Expression<Func<T, bool>> StringCollectionIsNotNull(string Property)
    {
      //(x => x.given_List.Count > 0);
      var type = typeof(T);
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      MethodInfo MethodCount = typeof(Enumerable).GetMethods().Where(m => m.Name == "Count" && m.GetParameters().Length == 1).Single().MakeGenericMethod(typeof(StringIndex));

      ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
      MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
      MethodCallExpression MethodAnyCall = Expression.Call(MethodCount, CollectionProperty);
      ConstantExpression constantReference = Expression.Constant(0);
      BinaryExpression BinaryExpression = Expression.GreaterThan(MethodAnyCall, constantReference);
      return Expression.Lambda<Func<T, bool>>(BinaryExpression, PatientParameter);
    }

    public Expression<Func<T, bool>> StringCollectionIsNull(string Property)
    {
      //(x => x.given_List.Count == 0);
      var type = typeof(T);
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      MethodInfo MethodCount = typeof(Enumerable).GetMethods().Where(m => m.Name == "Count" && m.GetParameters().Length == 1).Single().MakeGenericMethod(typeof(StringIndex));

      ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
      MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
      MethodCallExpression MethodAnyCall = Expression.Call(MethodCount, CollectionProperty);
      ConstantExpression constantReference = Expression.Constant(0);
      BinaryExpression BinaryExpression = Expression.Equal(MethodAnyCall, constantReference);
      return Expression.Lambda<Func<T, bool>>(BinaryExpression, PatientParameter);
    }

    public Expression<Func<T, bool>> StringCollectionAnyEqualTo(string Property, string Value)
    {
      //(x => x.family_List.Any(c => c.String.Equals("héllo UPPER")))
      var type = typeof(T);
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;
      //Inner
      MethodInfo MethodEquals = typeof(String).GetMethods().Where(m => m.Name == "Equals" && m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == typeof(String)).Single();

      ParameterExpression InnerParameter = Expression.Parameter(typeof(StringIndex), "c");
      MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.StringIndexConstatnts.String);
      ConstantExpression InnerValue = Expression.Constant(StringSupport.ToLowerAndRemoveDiacritics(Value.Trim()));
      //ConstantExpression InnerStringComparison = Expression.Constant(StringComparison.Ordinal);
      MethodCallExpression MethodEqualsCall = Expression.Call(InnerProperty, MethodEquals, InnerValue);
      Expression<Func<StringIndex, bool>> InnerFunction = Expression.Lambda<Func<StringIndex, bool>>(MethodEqualsCall, InnerParameter);

      //Outer Any
      MethodInfo MethodAny = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(StringIndex));

      ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
      MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
      MethodCallExpression MethodAnyCall = Expression.Call(MethodAny, CollectionProperty, InnerFunction);
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PatientParameter);
    }

    public Expression<Func<T, bool>> StringCollectionAnyStartsWith(string Property, string Value)
    {
      //(x => x.family_List.Any(c => c.String.StartsWith("Mill")));
      var type = typeof(T);
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      //Inner
      MethodInfo MethodStartsWith = typeof(String).GetMethods().Where(m => m.Name == "StartsWith" && m.GetParameters().Length == 1).Single();

      ParameterExpression InnerParameter = Expression.Parameter(typeof(StringIndex), "c");
      MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.StringIndexConstatnts.String);
      ConstantExpression InnerValue = Expression.Constant(StringSupport.ToLowerAndRemoveDiacritics(Value.Trim()));
      MethodCallExpression MethodStartsWithCall = Expression.Call(InnerProperty, MethodStartsWith, InnerValue);
      Expression<Func<StringIndex, bool>> InnerFunction = Expression.Lambda<Func<StringIndex, bool>>(MethodStartsWithCall, InnerParameter);

      //Outer Any
      MethodInfo MethodAny = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(StringIndex));

      ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
      MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
      MethodCallExpression MethodAnyCall = Expression.Call(MethodAny, CollectionProperty, InnerFunction);
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PatientParameter);
    }

    public Expression<Func<T, bool>> StringCollectionAnyStartsOrEndsWith(string Property, string Value)
    {
      //(x => x.family_List.Any(c => c.String.StartsWith("Mill")));
      var type = typeof(T);
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      //Inner
      MethodInfo MethodStartsWith = typeof(String).GetMethods().Where(m => m.Name == "StartsWith" && m.GetParameters().Length == 1).Single();
      MethodInfo MethodEndsWith = typeof(String).GetMethods().Where(m => m.Name == "EndsWith" && m.GetParameters().Length == 1).Single();

      ParameterExpression InnerParameter = Expression.Parameter(typeof(StringIndex), "c");
      MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.StringIndexConstatnts.String);
      ConstantExpression InnerValue = Expression.Constant(StringSupport.ToLowerAndRemoveDiacritics(Value.Trim()));

      MethodCallExpression MethodStartsWithCall = Expression.Call(InnerProperty, MethodStartsWith, InnerValue);
      MethodCallExpression MethodEndsWithCall = Expression.Call(InnerProperty, MethodEndsWith, InnerValue);

      var OrExpression = Expression.OrElse(MethodStartsWithCall, MethodEndsWithCall);
      Expression<Func<StringIndex, bool>> InnerFunction = Expression.Lambda<Func<StringIndex, bool>>(OrExpression, InnerParameter);

      //Outer Any
      MethodInfo MethodAny = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(StringIndex));

      ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
      MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
      MethodCallExpression MethodAnyCall = Expression.Call(MethodAny, CollectionProperty, InnerFunction);
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PatientParameter);
    }

    public Expression<Func<T, bool>> StringCollectionAnyContains(string Property, string Value)
    {
      //(x => x.family_List.Any(c => c.String.Contains("Mill")));
      var type = typeof(T);
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      //Inner
      MethodInfo MethodContains = typeof(String).GetMethods().Where(m => m.Name == "Contains" && m.GetParameters().Length == 1).Single();

      ParameterExpression InnerParameter = Expression.Parameter(typeof(StringIndex), "c");
      MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.StringIndexConstatnts.String);
      ConstantExpression InnerValue = Expression.Constant(StringSupport.ToLowerAndRemoveDiacritics(Value.Trim()));
      MethodCallExpression MethodContainsCall = Expression.Call(InnerProperty, MethodContains, InnerValue);
      Expression<Func<StringIndex, bool>> InnerFunction = Expression.Lambda<Func<StringIndex, bool>>(MethodContainsCall, InnerParameter);

      //Outer Any
      MethodInfo MethodAny = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(StringIndex));

      ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
      MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
      MethodCallExpression MethodAnyCall = Expression.Call(MethodAny, CollectionProperty, InnerFunction);
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PatientParameter);
    }

    //---- Date Index Expressions ------------------------------------------------------
    public Expression<Func<T, bool>> DatePropertyIsNotNull(string Property)
    {
      //(x => x.birthdate_DateTimeOffset != null);
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateIndexConstatnts.Date);
      var constantReference = Expression.Constant(null);
      var BinaryExpression = Expression.NotEqual(propertyReference, constantReference);
      return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DatePropertyIsNull(string Property)
    {
      //(x => x.birthdate_DateTimeOffset == null);
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateIndexConstatnts.Date);
      var constantReference = Expression.Constant(null);
      var BinaryExpression = Expression.Equal(propertyReference, constantReference);
      return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DatePropertyEqualTo(string Property, int Value)
    {
      //(x => x.birthdate_DateTimeOffset == TestDate);
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateIndexConstatnts.Date);
      var constantReference = Expression.Constant(Value, typeof(int?));
      var BinaryExpression = Expression.Equal(propertyReference, constantReference);
      return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DatePropertyNotEqualTo(string Property, int Value)
    {
      //(x => x.birthdate_DateTimeOffset != TestDate);
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateIndexConstatnts.Date);
      var constantReference = Expression.Constant(Value, typeof(int?));
      var BinaryExpression = Expression.NotEqual(propertyReference, constantReference);
      return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DatePropertyGreaterThan(string Property, int Value)
    {
      //(x => x.birthdate_DateTimeOffset > TestDate);
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateIndexConstatnts.Date);
      var constantReference = Expression.Constant(Value, typeof(int?));
      var BinaryExpression = Expression.GreaterThan(propertyReference, constantReference);
      return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DatePropertyGreaterThanOrEqualTo(string Property, int Value)
    {
      //(x => x.birthdate_DateTimeOffset >= TestDate);
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateIndexConstatnts.Date);
      var constantReference = Expression.Constant(Value, typeof(int?));
      var BinaryExpression = Expression.GreaterThanOrEqual(propertyReference, constantReference);
      return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DatePropertyLessThan(string Property, int Value)
    {
      //(x => x.birthdate_DateTimeOffset < TestDate);
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateIndexConstatnts.Date);
      var constantReference = Expression.Constant(Value, typeof(int?));
      var BinaryExpression = Expression.LessThan(propertyReference, constantReference);
      return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DatePropertyLessThanOrEqualTo(string Property, int Value)
    {
      //(x => x.birthdate_DateTimeOffset <= TestDate);
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateIndexConstatnts.Date);
      var constantReference = Expression.Constant(Value, typeof(int?));
      var BinaryExpression = Expression.LessThanOrEqual(propertyReference, constantReference);
      return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    }

    //---- DateTime Index Expressions ------------------------------------------------------

    public Expression<Func<T, bool>> DateTimePropertyIsNotNull(string Property)
    {
      //(x => x.birthdate_DateTimeOffset != null);
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimeIndexConstatnts.DateTimeOffset);
      var constantReference = Expression.Constant(null);
      var BinaryExpression = Expression.NotEqual(propertyReference, constantReference);
      return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DateTimePropertyIsNull(string Property)
    {
      //(x => x.birthdate_DateTimeOffset == null);
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimeIndexConstatnts.DateTimeOffset);
      var constantReference = Expression.Constant(null);
      var BinaryExpression = Expression.Equal(propertyReference, constantReference);
      return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DateTimePropertyEqualTo(string Property, DateTimeOffset Value)
    {
      //(x => x.birthdate_DateTimeOffset == TestDate);
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimeIndexConstatnts.DateTimeOffset);
      var constantReference = Expression.Constant(Value, typeof(DateTimeOffset?));
      var BinaryExpression = Expression.Equal(propertyReference, constantReference);
      return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DateTimePropertyNotEqualTo(string Property, DateTimeOffset Value)
    {
      //(x => x.birthdate_DateTimeOffset != TestDate);
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimeIndexConstatnts.DateTimeOffset);
      var constantReference = Expression.Constant(Value, typeof(DateTimeOffset?));
      var BinaryExpression = Expression.NotEqual(propertyReference, constantReference);
      return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DateTimePropertyGreaterThan(string Property, DateTimeOffset Value)
    {
      //(x => x.birthdate_DateTimeOffset > TestDate);
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimeIndexConstatnts.DateTimeOffset);
      var constantReference = Expression.Constant(Value, typeof(DateTimeOffset?));
      var BinaryExpression = Expression.GreaterThan(propertyReference, constantReference);
      return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DateTimePropertyGreaterThanOrEqualTo(string Property, DateTimeOffset Value)
    {
      //(x => x.birthdate_DateTimeOffset >= TestDate);
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimeIndexConstatnts.DateTimeOffset);
      var constantReference = Expression.Constant(Value, typeof(DateTimeOffset?));
      var BinaryExpression = Expression.GreaterThanOrEqual(propertyReference, constantReference);
      return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DateTimePropertyLessThan(string Property, DateTimeOffset Value)
    {
      //(x => x.birthdate_DateTimeOffset < TestDate);
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimeIndexConstatnts.DateTimeOffset);
      var constantReference = Expression.Constant(Value, typeof(DateTimeOffset?));
      var BinaryExpression = Expression.LessThan(propertyReference, constantReference);
      return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DateTimePropertyLessThanOrEqualTo(string Property, DateTimeOffset Value)
    {
      //(x => x.birthdate_DateTimeOffset <= TestDate);
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimeIndexConstatnts.DateTimeOffset);
      var constantReference = Expression.Constant(Value, typeof(DateTimeOffset?));
      var BinaryExpression = Expression.LessThanOrEqual(propertyReference, constantReference);
      return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DateTimeCollectionIsNotNull(string Property)
    {
      //(x => x.given_List.Count > 0);
      var type = typeof(T);
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      MethodInfo MethodCount = typeof(Enumerable).GetMethods().Where(m => m.Name == "Count" && m.GetParameters().Length == 1).Single().MakeGenericMethod(typeof(DateTimeIndex));

      ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
      MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
      MethodCallExpression MethodAnyCall = Expression.Call(MethodCount, CollectionProperty);
      ConstantExpression constantReference = Expression.Constant(0);
      BinaryExpression BinaryExpression = Expression.GreaterThan(MethodAnyCall, constantReference);
      return Expression.Lambda<Func<T, bool>>(BinaryExpression, PatientParameter);
    }

    public Expression<Func<T, bool>> DateTimeCollectionIsNull(string Property)
    {
      //(x => x.given_List.Count == 0);
      var type = typeof(T);
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      MethodInfo MethodCount = typeof(Enumerable).GetMethods().Where(m => m.Name == "Count" && m.GetParameters().Length == 1).Single().MakeGenericMethod(typeof(DateTimeIndex));

      ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
      MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
      MethodCallExpression MethodAnyCall = Expression.Call(MethodCount, CollectionProperty);
      ConstantExpression constantReference = Expression.Constant(0);
      BinaryExpression BinaryExpression = Expression.Equal(MethodAnyCall, constantReference);
      return Expression.Lambda<Func<T, bool>>(BinaryExpression, PatientParameter);
    }

    public Expression<Func<T, bool>> DateTimeCollectionAnyEqualTo(string Property, DateTimeOffset Value)
    {
      //(x => x.family_List.Any(c => c.String.Equals("héllo UPPER")))
      var type = typeof(T);
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;
      //Inner
      MethodInfo MethodEquals = typeof(DateTimeOffset).GetMethods().Where(m => m.Name == "Equals" && m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == typeof(DateTimeOffset)).Single();

      ParameterExpression InnerParameter = Expression.Parameter(typeof(DateTimeIndex), "c");
      MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimeIndexConstatnts.DateTimeOffset);
      ConstantExpression InnerValue = Expression.Constant(Value);
      MethodCallExpression MethodEqualsCall = Expression.Call(InnerProperty, MethodEquals, InnerValue);
      Expression<Func<DateTimeIndex, bool>> InnerFunction = Expression.Lambda<Func<DateTimeIndex, bool>>(MethodEqualsCall, InnerParameter);

      //Outer Any
      MethodInfo MethodAny = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(DateTimeIndex));

      ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
      MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
      MethodCallExpression MethodAnyCall = Expression.Call(MethodAny, CollectionProperty, InnerFunction);
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PatientParameter);
    }

    public Expression<Func<T, bool>> DateTimeCollectionAnyNotEqualTo(string Property, DateTimeOffset Value)
    {
      //(x => x. activitydate.Any(c => c.DateTimeOffset != "1995-09-30T10:00:10.123+10:00")))
      var type = typeof(T);
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;
      //Inner      
      ParameterExpression InnerParameter = Expression.Parameter(typeof(DateTimeIndex), "c");
      MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimeIndexConstatnts.DateTimeOffset);
      ConstantExpression InnerValue = Expression.Constant(Value);
      BinaryExpression InnerBinaryExpression = Expression.NotEqual(InnerProperty, InnerValue);
      Expression<Func<DateTimeIndex, bool>> InnerFunction = Expression.Lambda<Func<DateTimeIndex, bool>>(InnerBinaryExpression, InnerParameter);

      //Outer Any
      MethodInfo MethodAny = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(DateTimeIndex));

      ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
      MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
      MethodCallExpression MethodAnyCall = Expression.Call(MethodAny, CollectionProperty, InnerFunction);
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PatientParameter);
    }

    public Expression<Func<T, bool>> DateTimeCollectionGreaterThanOrEqualTo(string Property, DateTimeOffset Value)
    {
      //(x => x. activitydate.Any(c => c.DateTimeOffset >= "1995-09-30T10:00:10.123+10:00")))
      var type = typeof(T);
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;
      //Inner      
      ParameterExpression InnerParameter = Expression.Parameter(typeof(DateTimeIndex), "c");
      MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimeIndexConstatnts.DateTimeOffset);
      ConstantExpression InnerValue = Expression.Constant(Value);
      BinaryExpression InnerBinaryExpression = BinaryExpression.GreaterThanOrEqual(InnerProperty, InnerValue);
      //MethodCallExpression MethodEqualsCall = Expression.Call(InnerProperty, MethodEquals, InnerValue);
      Expression<Func<DateTimeIndex, bool>> InnerFunction = Expression.Lambda<Func<DateTimeIndex, bool>>(InnerBinaryExpression, InnerParameter);

      //Outer Any
      MethodInfo MethodAny = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(DateTimeIndex));

      ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
      MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
      MethodCallExpression MethodAnyCall = Expression.Call(MethodAny, CollectionProperty, InnerFunction);
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PatientParameter);
    }

    public Expression<Func<T, bool>> DateTimeCollectionGreaterThan(string Property, DateTimeOffset Value)
    {
      //(x => x. activitydate.Any(c => c.DateTimeOffset > "1995-09-30T10:00:10.123+10:00")))
      var type = typeof(T);
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;
      //Inner      
      ParameterExpression InnerParameter = Expression.Parameter(typeof(DateTimeIndex), "c");
      MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimeIndexConstatnts.DateTimeOffset);
      ConstantExpression InnerValue = Expression.Constant(Value);
      BinaryExpression InnerBinaryExpression = BinaryExpression.GreaterThan(InnerProperty, InnerValue);
      //MethodCallExpression MethodEqualsCall = Expression.Call(InnerProperty, MethodEquals, InnerValue);
      Expression<Func<DateTimeIndex, bool>> InnerFunction = Expression.Lambda<Func<DateTimeIndex, bool>>(InnerBinaryExpression, InnerParameter);

      //Outer Any
      MethodInfo MethodAny = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(DateTimeIndex));

      ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
      MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
      MethodCallExpression MethodAnyCall = Expression.Call(MethodAny, CollectionProperty, InnerFunction);
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PatientParameter);
    }

    public Expression<Func<T, bool>> DateTimeCollectionLessThanOrEqualTo(string Property, DateTimeOffset Value)
    {
      //(x => x. activitydate.Any(c => c.DateTimeOffset <= "1995-09-30T10:00:10.123+10:00")))
      var type = typeof(T);
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;
      //Inner      
      ParameterExpression InnerParameter = Expression.Parameter(typeof(DateTimeIndex), "c");
      MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimeIndexConstatnts.DateTimeOffset);
      ConstantExpression InnerValue = Expression.Constant(Value);
      BinaryExpression InnerBinaryExpression = BinaryExpression.LessThanOrEqual(InnerProperty, InnerValue);
      Expression<Func<DateTimeIndex, bool>> InnerFunction = Expression.Lambda<Func<DateTimeIndex, bool>>(InnerBinaryExpression, InnerParameter);

      //Outer Any
      MethodInfo MethodAny = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(DateTimeIndex));

      ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
      MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
      MethodCallExpression MethodAnyCall = Expression.Call(MethodAny, CollectionProperty, InnerFunction);
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PatientParameter);
    }

    public Expression<Func<T, bool>> DateTimeCollectionLessThan(string Property, DateTimeOffset Value)
    {
      //(x => x. activitydate.Any(c => c.DateTimeOffset < "1995-09-30T10:00:10.123+10:00")))
      var type = typeof(T);
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;
      //Inner      
      ParameterExpression InnerParameter = Expression.Parameter(typeof(DateTimeIndex), "c");
      MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimeIndexConstatnts.DateTimeOffset);
      ConstantExpression InnerValue = Expression.Constant(Value);
      BinaryExpression InnerBinaryExpression = BinaryExpression.LessThan(InnerProperty, InnerValue);
      Expression<Func<DateTimeIndex, bool>> InnerFunction = Expression.Lambda<Func<DateTimeIndex, bool>>(InnerBinaryExpression, InnerParameter);

      //Outer Any
      MethodInfo MethodAny = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(DateTimeIndex));

      ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
      MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
      MethodCallExpression MethodAnyCall = Expression.Call(MethodAny, CollectionProperty, InnerFunction);
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PatientParameter);
    }


    //---- DateTimePeriod Index Expressions ------------------------------------------------------

    public Expression<Func<T, bool>> DateTimePeriodPropertyIsNotNull(string Property)
    {
      //(x => x. date_DateTimeOffsetLow != null && date_DateTimeOffsetHigh != null );
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReferenceLow = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
      var propertyReferenceHigh = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);
      var constantReference = Expression.Constant(null);
      var BinaryExpressionLow = Expression.NotEqual(propertyReferenceLow, constantReference);
      var BinaryExpressionHigh = Expression.NotEqual(propertyReferenceLow, constantReference);
      var BinaryExpressionAnd = Expression.And(BinaryExpressionLow, BinaryExpressionHigh);

      return Expression.Lambda<Func<T, bool>>(BinaryExpressionAnd, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DateTimePeriodPropertyIsNull(string Property)
    {
      //(x => x. date_DateTimeOffsetLow == null && date_DateTimeOffsetHigh == null );
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReferenceLow = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
      var propertyReferenceHigh = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);
      var constantReference = Expression.Constant(null);
      var BinaryExpressionLow = Expression.Equal(propertyReferenceLow, constantReference);
      var BinaryExpressionHigh = Expression.Equal(propertyReferenceLow, constantReference);
      var BinaryExpressionAnd = Expression.And(BinaryExpressionLow, BinaryExpressionHigh);

      return Expression.Lambda<Func<T, bool>>(BinaryExpressionAnd, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DateTimePeriodPropertyEqualTo(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {
      var ParameterReferance = Expression.Parameter(typeof(T), "x");
      MemberExpression propertyReferenceLow = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
      MemberExpression propertyReferenceHigh = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);

      //Build Expression
      Expression BinaryExpression_Final = DateTimePeriodExpression.EqualToExpression(Property, propertyReferenceLow, SearchValueLow, propertyReferenceHigh, SearchValueHigh);

      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DateTimePeriodPropertyNotEqualTo(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {
      var ParameterReferance = Expression.Parameter(typeof(T), "x");
      MemberExpression propertyReferenceLow = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
      MemberExpression propertyReferenceHigh = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);

      //Build Expression
      Expression BinaryExpression_Final = DateTimePeriodExpression.NotEqualToExpression(Property, propertyReferenceLow, SearchValueLow, propertyReferenceHigh, SearchValueHigh);

      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DateTimePeriodPropertyGreaterThan(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {
      var ParameterReferance = Expression.Parameter(typeof(T), "x");
      MemberExpression propertyReferenceLow = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
      MemberExpression propertyReferenceHigh = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);

      //Build Expression
      Expression BinaryExpression_Final = DateTimePeriodExpression.GreaterThanExpression(Property, propertyReferenceLow, SearchValueLow, propertyReferenceHigh, SearchValueHigh);

      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DateTimePeriodPropertyGreaterThanOrEqualTo(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {
      var ParameterReferance = Expression.Parameter(typeof(T), "x");
      MemberExpression propertyReferenceLow = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
      MemberExpression propertyReferenceHigh = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);

      //Build Expression
      Expression BinaryExpression_Final = DateTimePeriodExpression.GreaterThanOrEqualToExpression(Property, propertyReferenceLow, SearchValueLow, propertyReferenceHigh, SearchValueHigh);

      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DateTimePeriodPropertyLessThan(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {
      var ParameterReferance = Expression.Parameter(typeof(T), "x");
      MemberExpression propertyReferenceLow = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
      MemberExpression propertyReferenceHigh = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);

      //Build Expression
      Expression BinaryExpression_Final = DateTimePeriodExpression.LessThanExpression(Property, propertyReferenceLow, SearchValueLow, propertyReferenceHigh, SearchValueHigh);

      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DateTimePeriodPropertyLessThanOrEqualTo(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {
      var ParameterReferance = Expression.Parameter(typeof(T), "x");
      MemberExpression propertyReferenceLow = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
      MemberExpression propertyReferenceHigh = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);

      //Build Expression
      Expression BinaryExpression_Final = DateTimePeriodExpression.LessThanOrEqualToExpression(Property, propertyReferenceLow, SearchValueLow, propertyReferenceHigh, SearchValueHigh);

      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }


    public Expression<Func<T, bool>> DateTimePeriodCollectionIsNotNull(string Property)
    {
      //(x => x.date_List.Count > 0);
      var type = typeof(T);
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      MethodInfo MethodCount = typeof(Enumerable).GetMethods().Where(m => m.Name == "Count" && m.GetParameters().Length == 1).Single().MakeGenericMethod(typeof(DateTimeIndex));

      ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
      MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
      MethodCallExpression MethodAnyCall = Expression.Call(MethodCount, CollectionProperty);
      ConstantExpression constantReference = Expression.Constant(0);
      BinaryExpression BinaryExpression = Expression.GreaterThan(MethodAnyCall, constantReference);
      return Expression.Lambda<Func<T, bool>>(BinaryExpression, PatientParameter);
    }

    public Expression<Func<T, bool>> DateTimePeriodCollectionIsNull(string Property)
    {
      //(x => x.date_List.Count == 0);
      var type = typeof(T);
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      MethodInfo MethodCount = typeof(Enumerable).GetMethods().Where(m => m.Name == "Count" && m.GetParameters().Length == 1).Single().MakeGenericMethod(typeof(DateTimePeriodIndex));

      ParameterExpression ResourceParameter = Expression.Parameter(typeof(T), "x");
      MemberExpression CollectionProperty = Expression.Property(ResourceParameter, typeof(T).GetProperty(DbPropertyName));
      MethodCallExpression MethodCountCall = Expression.Call(MethodCount, CollectionProperty);
      ConstantExpression constantReference = Expression.Constant(0);
      BinaryExpression BinaryExpression = Expression.Equal(MethodCountCall, constantReference);


      return Expression.Lambda<Func<T, bool>>(BinaryExpression, ResourceParameter);
    }

    public Expression<Func<T, bool>> DateTimePeriodCollectionAnyEqualTo(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      //Outer Any Method
      MethodInfo ME_Any = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(DateTimePeriodIndex));

      //Expression For Any Method
      ParameterExpression PE_Inner = Expression.Parameter(typeof(DateTimePeriodIndex), "c");
      MemberExpression propertyReferenceLow = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
      MemberExpression propertyReferenceHigh = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);

      //Build Inner Expression
      Expression E_InnerExpression = DateTimePeriodExpression.EqualToExpression(Property, propertyReferenceLow, SearchValueLow, propertyReferenceHigh, SearchValueHigh);

      //Wrap Any Method Expression into Function
      Expression<Func<DateTimePeriodIndex, bool>> InnerFunction = Expression.Lambda<Func<DateTimePeriodIndex, bool>>(E_InnerExpression, PE_Inner);

      ParameterExpression PE_Outer = Expression.Parameter(typeof(T), "x");
      MemberExpression ME_CollectionProperty = Expression.Property(PE_Outer, typeof(T).GetProperty(DbPropertyName));

      //Call Any Method with Function
      MethodCallExpression MethodAnyCall = Expression.Call(ME_Any, ME_CollectionProperty, InnerFunction);

      //Wrap final expression into function
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PE_Outer);
    }

    public Expression<Func<T, bool>> DateTimePeriodCollectionAnyNotEqualTo(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      //Outer Any Method
      MethodInfo ME_All = typeof(Enumerable).GetMethods().Where(m => m.Name == "All" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(DateTimePeriodIndex));

      //Expression For Any Method
      ParameterExpression PE_Inner = Expression.Parameter(typeof(DateTimePeriodIndex), "c");
      MemberExpression propertyReferenceLow = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
      MemberExpression propertyReferenceHigh = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);

      //Build Inner Expression
      Expression E_InnerExpression = DateTimePeriodExpression.NotEqualToExpression(Property, propertyReferenceLow, SearchValueLow, propertyReferenceHigh, SearchValueHigh);

      //Wrap Any Method Expression into Function
      Expression<Func<DateTimePeriodIndex, bool>> InnerFunction = Expression.Lambda<Func<DateTimePeriodIndex, bool>>(E_InnerExpression, PE_Inner);

      ParameterExpression PE_Outer = Expression.Parameter(typeof(T), "x");
      MemberExpression ME_CollectionProperty = Expression.Property(PE_Outer, typeof(T).GetProperty(DbPropertyName));

      //Call Any Method with Function
      MethodCallExpression MethodAllCall = Expression.Call(ME_All, ME_CollectionProperty, InnerFunction);

      //Wrap final expression into function
      return Expression.Lambda<Func<T, bool>>(MethodAllCall, PE_Outer);
    }

    public Expression<Func<T, bool>> DateTimePeriodCollectionGreaterThanOrEqualTo(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      //Outer Any Method
      MethodInfo ME_Any = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(DateTimePeriodIndex));

      //Expression For Any Method
      ParameterExpression PE_Inner = Expression.Parameter(typeof(DateTimePeriodIndex), "c");
      MemberExpression propertyReferenceLow = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
      MemberExpression propertyReferenceHigh = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);

      //Build Inner Expression
      Expression E_InnerExpression = DateTimePeriodExpression.GreaterThanOrEqualToExpression(Property, propertyReferenceLow, SearchValueLow, propertyReferenceHigh, SearchValueHigh);

      //Wrap Any Method Expression into Function
      Expression<Func<DateTimePeriodIndex, bool>> InnerFunction = Expression.Lambda<Func<DateTimePeriodIndex, bool>>(E_InnerExpression, PE_Inner);

      ParameterExpression PE_Outer = Expression.Parameter(typeof(T), "x");
      MemberExpression ME_CollectionProperty = Expression.Property(PE_Outer, typeof(T).GetProperty(DbPropertyName));

      //Call Any Method with Function
      MethodCallExpression MethodAnyCall = Expression.Call(ME_Any, ME_CollectionProperty, InnerFunction);

      //Wrap final expression into function
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PE_Outer);
    }

    public Expression<Func<T, bool>> DateTimePeriodCollectionGreaterThan(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      //Outer Any Method
      MethodInfo ME_Any = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(DateTimePeriodIndex));

      //Expression For Any Method
      ParameterExpression PE_Inner = Expression.Parameter(typeof(DateTimePeriodIndex), "c");
      MemberExpression propertyReferenceLow = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
      MemberExpression propertyReferenceHigh = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);

      //Build Inner Expression
      Expression E_InnerExpression = DateTimePeriodExpression.GreaterThanExpression(Property, propertyReferenceLow, SearchValueLow, propertyReferenceHigh, SearchValueHigh);

      //Wrap Any Method Expression into Function
      Expression<Func<DateTimePeriodIndex, bool>> InnerFunction = Expression.Lambda<Func<DateTimePeriodIndex, bool>>(E_InnerExpression, PE_Inner);

      ParameterExpression PE_Outer = Expression.Parameter(typeof(T), "x");
      MemberExpression ME_CollectionProperty = Expression.Property(PE_Outer, typeof(T).GetProperty(DbPropertyName));

      //Call Any Method with Function
      MethodCallExpression MethodAnyCall = Expression.Call(ME_Any, ME_CollectionProperty, InnerFunction);

      //Wrap final expression into function
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PE_Outer);
    }

    public Expression<Func<T, bool>> DateTimePeriodCollectionLessThan(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      //Outer Any Method
      MethodInfo ME_Any = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(DateTimePeriodIndex));

      //Expression For Any Method
      ParameterExpression PE_Inner = Expression.Parameter(typeof(DateTimePeriodIndex), "c");
      MemberExpression propertyReferenceLow = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
      MemberExpression propertyReferenceHigh = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);

      //Build Inner Expression
      Expression E_InnerExpression = DateTimePeriodExpression.LessThanExpression(Property, propertyReferenceLow, SearchValueLow, propertyReferenceHigh, SearchValueHigh);

      //Wrap Any Method Expression into Function
      Expression<Func<DateTimePeriodIndex, bool>> InnerFunction = Expression.Lambda<Func<DateTimePeriodIndex, bool>>(E_InnerExpression, PE_Inner);

      ParameterExpression PE_Outer = Expression.Parameter(typeof(T), "x");
      MemberExpression ME_CollectionProperty = Expression.Property(PE_Outer, typeof(T).GetProperty(DbPropertyName));

      //Call Any Method with Function
      MethodCallExpression MethodAnyCall = Expression.Call(ME_Any, ME_CollectionProperty, InnerFunction);

      //Wrap final expression into function
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PE_Outer);
    }

    public Expression<Func<T, bool>> DateTimePeriodCollectionLessThanOrEqualTo(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      //Outer Any Method
      MethodInfo ME_Any = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(DateTimePeriodIndex));

      //Expression For Any Method
      ParameterExpression PE_Inner = Expression.Parameter(typeof(DateTimePeriodIndex), "c");
      MemberExpression propertyReferenceLow = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
      MemberExpression propertyReferenceHigh = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);

      //Build Inner Expression
      Expression E_InnerExpression = DateTimePeriodExpression.LessThanOrEqualToExpression(Property, propertyReferenceLow, SearchValueLow, propertyReferenceHigh, SearchValueHigh);

      //Wrap Any Method Expression into Function
      Expression<Func<DateTimePeriodIndex, bool>> InnerFunction = Expression.Lambda<Func<DateTimePeriodIndex, bool>>(E_InnerExpression, PE_Inner);

      ParameterExpression PE_Outer = Expression.Parameter(typeof(T), "x");
      MemberExpression ME_CollectionProperty = Expression.Property(PE_Outer, typeof(T).GetProperty(DbPropertyName));

      //Call Any Method with Function
      MethodCallExpression MethodAnyCall = Expression.Call(ME_Any, ME_CollectionProperty, InnerFunction);

      //Wrap final expression into function
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PE_Outer);
    }

    //---- Token Index Expressions ------------------------------------------------------

    public Expression<Func<T, bool>> TokenPropertyIsNotNull(string Property)
    {
      //(x => x. date_DateTimeOffsetLow != null && date_DateTimeOffsetHigh != null );
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReferenceSystem = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.TokenIndexConstatnts.System);
      var propertyReferenceCode = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.TokenIndexConstatnts.Code);
      var constantReference = Expression.Constant(null);
      var BinaryExpressionSystem = Expression.NotEqual(propertyReferenceSystem, constantReference);
      var BinaryExpressionCode = Expression.NotEqual(propertyReferenceCode, constantReference);
      var BinaryExpressionAnd = Expression.Or(BinaryExpressionSystem, BinaryExpressionCode);

      return Expression.Lambda<Func<T, bool>>(BinaryExpressionAnd, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> TokenPropertyIsNull(string Property)
    {
      //(x => x. date_DateTimeOffsetLow != null && date_DateTimeOffsetHigh != null );
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReferenceSystem = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.TokenIndexConstatnts.System);
      var propertyReferenceCode = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.TokenIndexConstatnts.Code);
      var constantReference = Expression.Constant(null);
      var BinaryExpressionSystem = Expression.Equal(propertyReferenceSystem, constantReference);
      var BinaryExpressionCode = Expression.Equal(propertyReferenceCode, constantReference);
      var BinaryExpressionAnd = Expression.And(BinaryExpressionSystem, BinaryExpressionCode);

      return Expression.Lambda<Func<T, bool>>(BinaryExpressionAnd, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> TokenPropertyEqualTo(string Property, string Code, string System, Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType TokenSearchType)
    {
      var ParameterReferance = Expression.Parameter(typeof(T), "x");
      MemberExpression propertyReferenceCode = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.TokenIndexConstatnts.Code);
      MemberExpression propertyReferenceSystem = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.TokenIndexConstatnts.System);

      Expression BinaryExpression_Final = null;
      switch (TokenSearchType)
      {
        case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.None:
          throw new Exception("Server error: DtoSearchParameterTokenValue.TokenSearchType was set to None.");
        case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.MatchCodeOnly:
          BinaryExpression_Final = TokenExpression.MatchCodeOnlyExpression(propertyReferenceCode, Code);
          break;
        case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.MatchSystemOnly:
          BinaryExpression_Final = TokenExpression.MatchSystemOnlyExpression(propertyReferenceSystem, System);
          break;
        case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.MatchCodeAndSystem:
          BinaryExpression_Final = TokenExpression.MatchCodeAndSystemExpression(propertyReferenceCode, Code, propertyReferenceSystem, System);
          break;
        case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.MatchCodeWithNullSystem:
          BinaryExpression_Final = TokenExpression.MatchCodeWithNullSystemExpression(propertyReferenceCode, Code, propertyReferenceSystem);
          break;
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(TokenSearchType.ToString(), (int)TokenSearchType, typeof(Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType));
      }

      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> TokenCollectionIsNotNull(string Property)
    {
      //(x => x.date_List.Count > 0);
      var type = typeof(T);
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      MethodInfo MethodCount = typeof(Enumerable).GetMethods().Where(m => m.Name == "Count" && m.GetParameters().Length == 1).Single().MakeGenericMethod(typeof(TokenIndex));

      ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
      MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
      MethodCallExpression MethodAnyCall = Expression.Call(MethodCount, CollectionProperty);
      ConstantExpression constantReference = Expression.Constant(0);
      BinaryExpression BinaryExpression = Expression.GreaterThan(MethodAnyCall, constantReference);
      return Expression.Lambda<Func<T, bool>>(BinaryExpression, PatientParameter);
    }

    public Expression<Func<T, bool>> TokenCollectionIsNull(string Property)
    {
      //(x => x.date_List.Count == 0);
      var type = typeof(T);
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      MethodInfo MethodCount = typeof(Enumerable).GetMethods().Where(m => m.Name == "Count" && m.GetParameters().Length == 1).Single().MakeGenericMethod(typeof(TokenIndex));

      ParameterExpression ResourceParameter = Expression.Parameter(typeof(T), "x");
      MemberExpression CollectionProperty = Expression.Property(ResourceParameter, typeof(T).GetProperty(DbPropertyName));
      MethodCallExpression MethodCountCall = Expression.Call(MethodCount, CollectionProperty);
      ConstantExpression constantReference = Expression.Constant(0);
      BinaryExpression BinaryExpression = Expression.Equal(MethodCountCall, constantReference);


      return Expression.Lambda<Func<T, bool>>(BinaryExpression, ResourceParameter);
    }

    public Expression<Func<T, bool>> TokenCollectionAnyEqualTo(string Property, string Code, string System, Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType TokenSearchType)
    {
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      //Outer Any Method
      MethodInfo ME_Any = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(TokenIndex));

      //Expression For Any Method
      ParameterExpression PE_Inner = Expression.Parameter(typeof(TokenIndex), "c");
      MemberExpression propertyReferenceCode = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.TokenIndexConstatnts.Code);
      MemberExpression propertyReferenceSystem = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.TokenIndexConstatnts.System);

      //Build Inner Expression
      Expression E_InnerExpression = null;
      switch (TokenSearchType)
      {
        case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.None:
          throw new Exception("Server error: DtoSearchParameterTokenValue.TokenSearchType was set to None.");
        case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.MatchCodeOnly:
          E_InnerExpression = TokenExpression.MatchCodeOnlyExpression(propertyReferenceCode, Code);
          break;
        case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.MatchSystemOnly:
          E_InnerExpression = TokenExpression.MatchCodeOnlyExpression(propertyReferenceSystem, System);
          break;
        case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.MatchCodeAndSystem:
          E_InnerExpression = TokenExpression.MatchCodeAndSystemExpression(propertyReferenceCode, Code, propertyReferenceSystem, System);
          break;
        case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.MatchCodeWithNullSystem:
          E_InnerExpression = TokenExpression.MatchCodeWithNullSystemExpression(propertyReferenceCode, Code, propertyReferenceSystem);
          break;
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(TokenSearchType.ToString(), (int)TokenSearchType, typeof(Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType));
      }

      //Wrap Any Method Expression into Function
      Expression<Func<TokenIndex, bool>> InnerFunction = Expression.Lambda<Func<TokenIndex, bool>>(E_InnerExpression, PE_Inner);

      ParameterExpression PE_Outer = Expression.Parameter(typeof(T), "x");
      MemberExpression ME_CollectionProperty = Expression.Property(PE_Outer, typeof(T).GetProperty(DbPropertyName));

      //Call Any Method with Function
      MethodCallExpression MethodAnyCall = Expression.Call(ME_Any, ME_CollectionProperty, InnerFunction);

      //Wrap final expression into function
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PE_Outer);
    }

    //---- Number Index Expressions ------------------------------------------------------

    public Expression<Func<T, bool>> NumberPropertyIsNotNull(string Property)
    {
      //(x => x. X_Number != null || X_Comparator != null );
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReferenceComparator = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Comparator);
      var propertyReferenceNumber = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Number);
      var constantReference = Expression.Constant(null);
      var BinaryExpressionComparator = Expression.NotEqual(propertyReferenceComparator, constantReference);
      var BinaryExpressionNumber = Expression.NotEqual(propertyReferenceNumber, constantReference);
      var BinaryExpressionAnd = Expression.Or(BinaryExpressionComparator, BinaryExpressionNumber);

      return Expression.Lambda<Func<T, bool>>(BinaryExpressionAnd, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> NumberPropertyIsNull(string Property)
    {
      //(x => x. X_Number == null && X_Comparator == null );
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReferenceComparator = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Comparator);
      var propertyReferenceNumber = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Number);
      var constantReference = Expression.Constant(null);
      var BinaryExpressionComparator = Expression.Equal(propertyReferenceComparator, constantReference);
      var BinaryExpressionNumber = Expression.Equal(propertyReferenceNumber, constantReference);
      var BinaryExpressionAnd = Expression.And(BinaryExpressionComparator, BinaryExpressionNumber);

      return Expression.Lambda<Func<T, bool>>(BinaryExpressionAnd, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> NumberPropertyEqualTo(string Property, decimal LowNumber, decimal MidNumber, decimal HighNumber)
    {
      var ParameterReferance = Expression.Parameter(typeof(T), "x");
      MemberExpression propertyReferenceComparator = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Number);

      Expression BinaryExpression_Final = NumberExpression.EqualToExpression(propertyReferenceComparator, propertyReferenceNumber, LowNumber, MidNumber, HighNumber);

      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> NumberPropertyNotEqualTo(string Property, decimal LowNumber, decimal MidNumber, decimal HighNumber)
    {
      var ParameterReferance = Expression.Parameter(typeof(T), "x");
      MemberExpression propertyReferenceComparator = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Number);

      Expression BinaryExpression_Final = NumberExpression.NotEqualToExpression(propertyReferenceComparator, propertyReferenceNumber, LowNumber, MidNumber, HighNumber);

      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> NumberPropertyGreaterThan(string Property, decimal MidNumber)
    {
      var ParameterReferance = Expression.Parameter(typeof(T), "x");
      MemberExpression propertyReferenceComparator = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Number);

      Expression BinaryExpression_Final = NumberExpression.GreaterThanExpression(propertyReferenceComparator, propertyReferenceNumber, MidNumber);

      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> NumberPropertyGreaterThanOrEqualTo(string Property, decimal MidNumber)
    {
      var ParameterReferance = Expression.Parameter(typeof(T), "x");
      MemberExpression propertyReferenceComparator = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Number);

      Expression BinaryExpression_Final = NumberExpression.GreaterThanOrEqualToExpression(propertyReferenceComparator, propertyReferenceNumber, MidNumber);

      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }


    public Expression<Func<T, bool>> NumberCollectionAnyEqualTo(string Property, decimal LowNumber, decimal MidNumber, decimal HighNumber)
    {
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      //Outer Any Method
      MethodInfo ME_Any = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(TokenIndex));

      //Expression For Any Method
      ParameterExpression PE_Inner = Expression.Parameter(typeof(NumberIndex), "c");
      MemberExpression propertyReferenceComparator = Expression.Property(PE_Inner, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(PE_Inner, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Number);

      //Build Inner Expression
      Expression E_InnerExpression = NumberExpression.EqualToExpression(propertyReferenceComparator, propertyReferenceNumber, LowNumber, MidNumber, HighNumber);

      //Wrap Any Method Expression into Function
      Expression<Func<NumberIndex, bool>> InnerFunction = Expression.Lambda<Func<NumberIndex, bool>>(E_InnerExpression, PE_Inner);

      ParameterExpression PE_Outer = Expression.Parameter(typeof(T), "x");
      MemberExpression ME_CollectionProperty = Expression.Property(PE_Outer, typeof(T).GetProperty(DbPropertyName));

      //Call Any Method with Function
      MethodCallExpression MethodAnyCall = Expression.Call(ME_Any, ME_CollectionProperty, InnerFunction);

      //Wrap final expression into function
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PE_Outer);
    }

    public Expression<Func<T, bool>> NumberCollectionAllNotEqualTo(string Property, decimal LowNumber, decimal MidNumber, decimal HighNumber)
    {
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      //Outer Any Method
      MethodInfo ME_All = typeof(Enumerable).GetMethods().Where(m => m.Name == "All" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(DateTimePeriodIndex));

      //Expression For Any Method
      ParameterExpression PE_Inner = Expression.Parameter(typeof(NumberIndex), "c");
      MemberExpression propertyReferenceComparator = Expression.Property(PE_Inner, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(PE_Inner, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Number);

      //Build Inner Expression
      Expression E_InnerExpression = NumberExpression.NotEqualToExpression(propertyReferenceComparator, propertyReferenceNumber, LowNumber, MidNumber, HighNumber);

      //Wrap Any Method Expression into Function
      Expression<Func<NumberIndex, bool>> InnerFunction = Expression.Lambda<Func<NumberIndex, bool>>(E_InnerExpression, PE_Inner);

      ParameterExpression PE_Outer = Expression.Parameter(typeof(T), "x");
      MemberExpression ME_CollectionProperty = Expression.Property(PE_Outer, typeof(T).GetProperty(DbPropertyName));

      //Call Any Method with Function
      MethodCallExpression MethodAllCall = Expression.Call(ME_All, ME_CollectionProperty, InnerFunction);

      //Wrap final expression into function
      return Expression.Lambda<Func<T, bool>>(MethodAllCall, PE_Outer);
    }

    public Expression<Func<T, bool>> NumberCollectionAnyGreaterThan(string Property, decimal MidNumber)
    {
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      //Outer Any Method
      MethodInfo ME_Any = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(TokenIndex));

      //Expression For Any Method
      ParameterExpression PE_Inner = Expression.Parameter(typeof(NumberIndex), "c");
      MemberExpression propertyReferenceComparator = Expression.Property(PE_Inner, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(PE_Inner, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Number);

      //Build Inner Expression
      Expression E_InnerExpression = NumberExpression.GreaterThanExpression(propertyReferenceComparator, propertyReferenceNumber, MidNumber);

      //Wrap Any Method Expression into Function
      Expression<Func<NumberIndex, bool>> InnerFunction = Expression.Lambda<Func<NumberIndex, bool>>(E_InnerExpression, PE_Inner);

      ParameterExpression PE_Outer = Expression.Parameter(typeof(T), "x");
      MemberExpression ME_CollectionProperty = Expression.Property(PE_Outer, typeof(T).GetProperty(DbPropertyName));

      //Call Any Method with Function
      MethodCallExpression MethodAnyCall = Expression.Call(ME_Any, ME_CollectionProperty, InnerFunction);

      //Wrap final expression into function
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PE_Outer);
    }

    public Expression<Func<T, bool>> NumberCollectionAnyGreaterThanOrEqualTo(string Property, decimal MidNumber)
    {
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      //Outer Any Method
      MethodInfo ME_Any = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(TokenIndex));

      //Expression For Any Method
      ParameterExpression PE_Inner = Expression.Parameter(typeof(NumberIndex), "c");
      MemberExpression propertyReferenceComparator = Expression.Property(PE_Inner, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(PE_Inner, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Number);

      //Build Inner Expression
      Expression E_InnerExpression = NumberExpression.GreaterThanOrEqualToExpression(propertyReferenceComparator, propertyReferenceNumber, MidNumber);

      //Wrap Any Method Expression into Function
      Expression<Func<NumberIndex, bool>> InnerFunction = Expression.Lambda<Func<NumberIndex, bool>>(E_InnerExpression, PE_Inner);

      ParameterExpression PE_Outer = Expression.Parameter(typeof(T), "x");
      MemberExpression ME_CollectionProperty = Expression.Property(PE_Outer, typeof(T).GetProperty(DbPropertyName));

      //Call Any Method with Function
      MethodCallExpression MethodAnyCall = Expression.Call(ME_Any, ME_CollectionProperty, InnerFunction);

      //Wrap final expression into function
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PE_Outer);
    }

    public Expression<Func<T, bool>> NumberCollectionIsNotNull(string Property)
    {
      //(x => x.date_List.Count > 0);
      var type = typeof(T);
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      MethodInfo MethodCount = typeof(Enumerable).GetMethods().Where(m => m.Name == "Count" && m.GetParameters().Length == 1).Single().MakeGenericMethod(typeof(TokenIndex));

      ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
      MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
      MethodCallExpression MethodAnyCall = Expression.Call(MethodCount, CollectionProperty);
      ConstantExpression constantReference = Expression.Constant(0);
      BinaryExpression BinaryExpression = Expression.GreaterThan(MethodAnyCall, constantReference);
      return Expression.Lambda<Func<T, bool>>(BinaryExpression, PatientParameter);
    }

    public Expression<Func<T, bool>> NumberCollectionIsNull(string Property)
    {
      //(x => x.date_List.Count == 0);
      var type = typeof(T);
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      MethodInfo MethodCount = typeof(Enumerable).GetMethods().Where(m => m.Name == "Count" && m.GetParameters().Length == 1).Single().MakeGenericMethod(typeof(TokenIndex));

      ParameterExpression ResourceParameter = Expression.Parameter(typeof(T), "x");
      MemberExpression CollectionProperty = Expression.Property(ResourceParameter, typeof(T).GetProperty(DbPropertyName));
      MethodCallExpression MethodCountCall = Expression.Call(MethodCount, CollectionProperty);
      ConstantExpression constantReference = Expression.Constant(0);
      BinaryExpression BinaryExpression = Expression.Equal(MethodCountCall, constantReference);


      return Expression.Lambda<Func<T, bool>>(BinaryExpression, ResourceParameter);
    }


  }

}

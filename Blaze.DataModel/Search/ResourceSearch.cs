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

      ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

      //Build Expression
      Expression BinaryExpression_Final = DateTimePeriodExpression.EqualToExpression(Property, propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DateTimePeriodPropertyNotEqualTo(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {
      var ParameterReferance = Expression.Parameter(typeof(T), "x");
      MemberExpression propertyReferenceLow = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
      MemberExpression propertyReferenceHigh = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);
      ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

      //Build Expression
      Expression BinaryExpression_Final = DateTimePeriodExpression.NotEqualToExpression(Property, propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DateTimePeriodPropertyGreaterThan(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {
      var ParameterReferance = Expression.Parameter(typeof(T), "x");
      MemberExpression propertyReferenceLow = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
      MemberExpression propertyReferenceHigh = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);
      ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

      //Build Expression
      Expression BinaryExpression_Final = DateTimePeriodExpression.GreaterThanExpression(Property, propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DateTimePeriodPropertyGreaterThanOrEqualTo(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {
      var ParameterReferance = Expression.Parameter(typeof(T), "x");
      MemberExpression propertyReferenceLow = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
      MemberExpression propertyReferenceHigh = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);
      ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

      //Build Expression
      Expression BinaryExpression_Final = DateTimePeriodExpression.GreaterThanOrEqualToExpression(Property, propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DateTimePeriodPropertyLessThan(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {
      var ParameterReferance = Expression.Parameter(typeof(T), "x");
      MemberExpression propertyReferenceLow = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
      MemberExpression propertyReferenceHigh = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);
      ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

      //Build Expression
      Expression BinaryExpression_Final = DateTimePeriodExpression.LessThanExpression(Property, propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DateTimePeriodPropertyLessThanOrEqualTo(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {
      var ParameterReferance = Expression.Parameter(typeof(T), "x");
      MemberExpression propertyReferenceLow = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
      MemberExpression propertyReferenceHigh = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);
      ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

      //Build Expression
      Expression BinaryExpression_Final = DateTimePeriodExpression.LessThanOrEqualToExpression(Property, propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

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

      ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

      //Build Inner Expression
      Expression E_InnerExpression = DateTimePeriodExpression.EqualToExpression(Property, propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

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
      ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

      //Build Inner Expression
      Expression E_InnerExpression = DateTimePeriodExpression.NotEqualToExpression(Property, propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

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
      ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

      //Build Inner Expression
      Expression E_InnerExpression = DateTimePeriodExpression.GreaterThanOrEqualToExpression(Property, propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

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
      ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

      //Build Inner Expression
      Expression E_InnerExpression = DateTimePeriodExpression.GreaterThanExpression(Property, propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

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
      ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

      //Build Inner Expression
      Expression E_InnerExpression = DateTimePeriodExpression.LessThanExpression(Property, propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

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
      ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

      //Build Inner Expression
      Expression E_InnerExpression = DateTimePeriodExpression.LessThanOrEqualToExpression(Property, propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

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
      ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);
      ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);

      Expression BinaryExpression_Final = null;
      switch (TokenSearchType)
      {
        case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.None:
          throw new Exception("Server error: DtoSearchParameterTokenValue.TokenSearchType was set to None.");
        case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.MatchCodeOnly:
          BinaryExpression_Final = TokenExpression.MatchCodeOnlyExpression(propertyReferenceCode, SearchValueReferenceCode);
          break;
        case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.MatchSystemOnly:
          BinaryExpression_Final = TokenExpression.MatchSystemOnlyExpression(propertyReferenceSystem, SearchValueReferenceSystem);
          break;
        case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.MatchCodeAndSystem:
          BinaryExpression_Final = TokenExpression.MatchCodeAndSystemExpression(propertyReferenceCode, SearchValueReferenceCode, propertyReferenceSystem, SearchValueReferenceSystem);
          break;
        case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.MatchCodeWithNullSystem:
          BinaryExpression_Final = TokenExpression.MatchCodeWithNullSystemExpression(propertyReferenceCode, SearchValueReferenceCode, propertyReferenceSystem);
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
      ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);
      ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);

      //Build Inner Expression
      Expression E_InnerExpression = null;
      switch (TokenSearchType)
      {
        case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.None:
          throw new Exception("Server error: DtoSearchParameterTokenValue.TokenSearchType was set to None.");
        case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.MatchCodeOnly:
          E_InnerExpression = TokenExpression.MatchCodeOnlyExpression(propertyReferenceCode, SearchValueReferenceCode);
          break;
        case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.MatchSystemOnly:
          E_InnerExpression = TokenExpression.MatchSystemOnlyExpression(propertyReferenceSystem, SearchValueReferenceSystem);
          break;
        case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.MatchCodeAndSystem:
          E_InnerExpression = TokenExpression.MatchCodeAndSystemExpression(propertyReferenceCode, SearchValueReferenceCode, propertyReferenceSystem, SearchValueReferenceSystem);
          break;
        case Common.BusinessEntities.Search.DtoSearchParameterTokenValue.TokenSearchType.MatchCodeWithNullSystem:
          E_InnerExpression = TokenExpression.MatchCodeWithNullSystemExpression(propertyReferenceCode, SearchValueReferenceCode, propertyReferenceSystem);
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

    public Expression<Func<T, bool>> NumberPropertyEqualTo(string Property, decimal LowNumber, decimal MidNumber, decimal HighNumber)
    {
      var ParameterReferance = Expression.Parameter(typeof(T), "x");
      MemberExpression propertyReferenceComparator = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Quantity);
      ConstantExpression SearchValueReferenceLow = Expression.Constant(LowNumber, typeof(decimal?));
      ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(HighNumber, typeof(decimal?));

      Expression BinaryExpression_Final = DecimalExpression.EqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceLow, SearchValueReferenceMid, SearchValueReferenceHigh);

      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> NumberPropertyNotEqualTo(string Property, decimal LowNumber, decimal MidNumber, decimal HighNumber)
    {
      var ParameterReferance = Expression.Parameter(typeof(T), "x");
      MemberExpression propertyReferenceComparator = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Quantity);
      ConstantExpression SearchValueReferenceLow = Expression.Constant(LowNumber, typeof(decimal?));
      ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(HighNumber, typeof(decimal?));

      Expression BinaryExpression_Final = DecimalExpression.NotEqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceLow, SearchValueReferenceMid, SearchValueReferenceHigh);

      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> NumberPropertyGreaterThan(string Property, decimal MidNumber)
    {
      var ParameterReferance = Expression.Parameter(typeof(T), "x");
      MemberExpression propertyReferenceComparator = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Quantity);
      ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal?));

      Expression BinaryExpression_Final = DecimalExpression.GreaterThanExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);

      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> NumberPropertyGreaterThanOrEqualTo(string Property, decimal MidNumber)
    {
      var ParameterReferance = Expression.Parameter(typeof(T), "x");
      MemberExpression propertyReferenceComparator = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Quantity);
      ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal?));

      Expression BinaryExpression_Final = DecimalExpression.GreaterThanOrEqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);

      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> NumberPropertyLessThan(string Property, decimal MidNumber)
    {
      var ParameterReferance = Expression.Parameter(typeof(T), "x");
      MemberExpression propertyReferenceComparator = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Quantity);
      ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal?));

      Expression BinaryExpression_Final = DecimalExpression.LessThanExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);

      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> NumberPropertyLessThanOrEqualTo(string Property, decimal MidNumber)
    {
      var ParameterReferance = Expression.Parameter(typeof(T), "x");
      MemberExpression propertyReferenceComparator = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Quantity);
      ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal?));

      Expression BinaryExpression_Final = DecimalExpression.LessThanOrEqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);

      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> NumberPropertyIsNotNull(string Property)
    {
      //(x => x. X_Number == null && X_Comparator == null );
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReferenceComparator = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Comparator);
      var propertyReferenceNumber = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Quantity);
      var FinalExpression = DecimalExpression.IsNotNullExpression(propertyReferenceComparator, propertyReferenceNumber);
      return Expression.Lambda<Func<T, bool>>(FinalExpression, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> NumberPropertyIsNull(string Property)
    {
      //(x => x. X_Number == null && X_Comparator == null );
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReferenceComparator = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Comparator);
      var propertyReferenceNumber = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Quantity);
      var FinalExpression = DecimalExpression.IsNullExpression(propertyReferenceComparator, propertyReferenceNumber);
      return Expression.Lambda<Func<T, bool>>(FinalExpression, new[] { ParameterReferance });
    }


    public Expression<Func<T, bool>> NumberCollectionAnyEqualTo(string Property, decimal LowNumber, decimal MidNumber, decimal HighNumber)
    {
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      //Outer Any Method
      MethodInfo ME_Any = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(NumberIndex));

      //Expression For Any Method
      ParameterExpression PE_Inner = Expression.Parameter(typeof(NumberIndex), "c");
      MemberExpression propertyReferenceComparator = Expression.Property(PE_Inner, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(PE_Inner, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Quantity);

      ConstantExpression SearchValueReferenceLow = Expression.Constant(LowNumber, typeof(decimal));
      ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(HighNumber, typeof(decimal));

      //Build Inner Expression
      Expression E_InnerExpression = DecimalExpression.EqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceLow, SearchValueReferenceMid, SearchValueReferenceHigh);

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
      MethodInfo ME_All = typeof(Enumerable).GetMethods().Where(m => m.Name == "All" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(NumberIndex));

      //Expression For Any Method
      ParameterExpression PE_Inner = Expression.Parameter(typeof(NumberIndex), "c");
      MemberExpression propertyReferenceComparator = Expression.Property(PE_Inner, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(PE_Inner, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Quantity);

      ConstantExpression SearchValueReferenceLow = Expression.Constant(LowNumber, typeof(decimal));
      ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(HighNumber, typeof(decimal));

      //Build Inner Expression
      Expression E_InnerExpression = DecimalExpression.NotEqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceLow, SearchValueReferenceMid, SearchValueReferenceHigh);

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
      MemberExpression propertyReferenceNumber = Expression.Property(PE_Inner, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Quantity);
      ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal));
      //Build Inner Expression
      Expression E_InnerExpression = DecimalExpression.GreaterThanExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);

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
      MethodInfo ME_Any = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(NumberIndex));

      //Expression For Any Method
      ParameterExpression PE_Inner = Expression.Parameter(typeof(NumberIndex), "c");
      MemberExpression propertyReferenceComparator = Expression.Property(PE_Inner, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(PE_Inner, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Quantity);
      ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal));
      //Build Inner Expression
      Expression E_InnerExpression = DecimalExpression.GreaterThanOrEqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);

      //Wrap Any Method Expression into Function
      Expression<Func<NumberIndex, bool>> InnerFunction = Expression.Lambda<Func<NumberIndex, bool>>(E_InnerExpression, PE_Inner);

      ParameterExpression PE_Outer = Expression.Parameter(typeof(T), "x");
      MemberExpression ME_CollectionProperty = Expression.Property(PE_Outer, typeof(T).GetProperty(DbPropertyName));

      //Call Any Method with Function
      MethodCallExpression MethodAnyCall = Expression.Call(ME_Any, ME_CollectionProperty, InnerFunction);

      //Wrap final expression into function
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PE_Outer);
    }

    public Expression<Func<T, bool>> NumberCollectionAnyLessThan(string Property, decimal MidNumber)
    {
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      //Outer Any Method
      MethodInfo ME_Any = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(NumberIndex));

      //Expression For Any Method
      ParameterExpression PE_Inner = Expression.Parameter(typeof(NumberIndex), "c");
      MemberExpression propertyReferenceComparator = Expression.Property(PE_Inner, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(PE_Inner, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Quantity);
      ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal));

      //Build Inner Expression
      Expression E_InnerExpression = DecimalExpression.LessThanExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);

      //Wrap Any Method Expression into Function
      Expression<Func<NumberIndex, bool>> InnerFunction = Expression.Lambda<Func<NumberIndex, bool>>(E_InnerExpression, PE_Inner);

      ParameterExpression PE_Outer = Expression.Parameter(typeof(T), "x");
      MemberExpression ME_CollectionProperty = Expression.Property(PE_Outer, typeof(T).GetProperty(DbPropertyName));

      //Call Any Method with Function
      MethodCallExpression MethodAnyCall = Expression.Call(ME_Any, ME_CollectionProperty, InnerFunction);

      //Wrap final expression into function
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PE_Outer);
    }

    public Expression<Func<T, bool>> NumberCollectionAnyLessThanOrEqualTo(string Property, decimal MidNumber)
    {
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      //Outer Any Method
      MethodInfo ME_Any = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(NumberIndex));

      //Expression For Any Method
      ParameterExpression PE_Inner = Expression.Parameter(typeof(NumberIndex), "c");
      MemberExpression propertyReferenceComparator = Expression.Property(PE_Inner, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(PE_Inner, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Quantity);
      ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal));

      //Build Inner Expression
      Expression E_InnerExpression = DecimalExpression.LessThanOrEqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);

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

      MethodInfo MethodCount = typeof(Enumerable).GetMethods().Where(m => m.Name == "Count" && m.GetParameters().Length == 1).Single().MakeGenericMethod(typeof(NumberIndex));

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

      MethodInfo MethodCount = typeof(Enumerable).GetMethods().Where(m => m.Name == "Count" && m.GetParameters().Length == 1).Single().MakeGenericMethod(typeof(NumberIndex));

      ParameterExpression ResourceParameter = Expression.Parameter(typeof(T), "x");
      MemberExpression CollectionProperty = Expression.Property(ResourceParameter, typeof(T).GetProperty(DbPropertyName));
      MethodCallExpression MethodCountCall = Expression.Call(MethodCount, CollectionProperty);
      ConstantExpression constantReference = Expression.Constant(0);
      BinaryExpression BinaryExpression = Expression.Equal(MethodCountCall, constantReference);


      return Expression.Lambda<Func<T, bool>>(BinaryExpression, ResourceParameter);
    }

    //---- Quantity Index Expressions ------------------------------------------------------

    public Expression<Func<T, bool>> QuantityPropertyEqualTo(string Property, decimal LowNumber, decimal MidNumber, decimal HighNumber, string System, string Code)
    {
      var ParameterReferance = Expression.Parameter(typeof(T), "x");
      MemberExpression propertyReferenceComparator = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Quantity);

      MemberExpression propertyReferenceSystem = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.System);
      MemberExpression propertyReferenceCode = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Code);
      MemberExpression propertyReferenceUnit = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Unit);

      ConstantExpression SearchValueReferenceLow = Expression.Constant(LowNumber, typeof(decimal?));
      ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(HighNumber, typeof(decimal?));

      ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);
      ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);

      Expression BinaryExpression_Number = DecimalExpression.EqualToExpression(
        propertyReferenceComparator,
        propertyReferenceNumber,
        SearchValueReferenceLow,
        SearchValueReferenceMid,
        SearchValueReferenceHigh);

      Expression BinaryExpression_SystemCodeOrUnit = QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(
        propertyReferenceSystem,
        propertyReferenceCode,
        propertyReferenceUnit,
        SearchValueReferenceSystem,
        SearchValueReferenceCode);

      Expression BinaryExpression_Final = Expression.AndAlso(BinaryExpression_Number, BinaryExpression_SystemCodeOrUnit);

      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> QuantityPropertyNotEqualTo(string Property, decimal LowNumber, decimal MidNumber, decimal HighNumber, string System, string Code)
    {
      var ParameterReferance = Expression.Parameter(typeof(T), "x");
      MemberExpression propertyReferenceComparator = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Quantity);

      MemberExpression propertyReferenceSystem = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.System);
      MemberExpression propertyReferenceCode = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Code);
      MemberExpression propertyReferenceUnit = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Unit);

      ConstantExpression SearchValueReferenceLow = Expression.Constant(LowNumber, typeof(decimal?));
      ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(HighNumber, typeof(decimal?));

      ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);
      ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);


      Expression BinaryExpression_Number = DecimalExpression.NotEqualToExpression(
        propertyReferenceComparator,
        propertyReferenceNumber,
        SearchValueReferenceLow,
        SearchValueReferenceMid,
        SearchValueReferenceHigh);

      Expression BinaryExpression_SystemCodeOrUnit = QuantityExpression.SystemCodeOrUnit_NotEqualTo_Expression(
        propertyReferenceSystem,
        propertyReferenceCode,
        propertyReferenceUnit,
        SearchValueReferenceSystem,
        SearchValueReferenceCode);

      Expression BinaryExpression_Final = Expression.OrElse(BinaryExpression_Number, BinaryExpression_SystemCodeOrUnit);

      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> QuantityPropertyGreaterThan(string Property, decimal MidNumber, string System, string Code)
    {
      var ParameterReferance = Expression.Parameter(typeof(T), "x");
      MemberExpression propertyReferenceComparator = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Quantity);

      MemberExpression propertyReferenceSystem = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.System);
      MemberExpression propertyReferenceCode = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Code);
      MemberExpression propertyReferenceUnit = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Unit);

      ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal?));

      ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);
      ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);

      Expression BinaryExpression_Number = DecimalExpression.GreaterThanExpression(
        propertyReferenceComparator,
        propertyReferenceNumber,
        SearchValueReferenceMid);

      Expression BinaryExpression_SystemCodeOrUnit = QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(
        propertyReferenceSystem,
        propertyReferenceCode,
        propertyReferenceUnit,
        SearchValueReferenceSystem,
        SearchValueReferenceCode);

      Expression BinaryExpression_Final = Expression.AndAlso(BinaryExpression_Number, BinaryExpression_SystemCodeOrUnit);

      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> QuantityPropertyGreaterThanOrEqualTo(string Property, decimal MidNumber, string System, string Code)
    {
      var ParameterReferance = Expression.Parameter(typeof(T), "x");
      MemberExpression propertyReferenceComparator = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Quantity);

      MemberExpression propertyReferenceSystem = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.System);
      MemberExpression propertyReferenceCode = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Code);
      MemberExpression propertyReferenceUnit = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Unit);

      ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal?));

      ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);
      ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);

      Expression BinaryExpression_Number = DecimalExpression.GreaterThanOrEqualToExpression(
        propertyReferenceComparator,
        propertyReferenceNumber,
        SearchValueReferenceMid);

      Expression BinaryExpression_SystemCodeOrUnit = QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(
        propertyReferenceSystem,
        propertyReferenceCode,
        propertyReferenceUnit,
        SearchValueReferenceSystem,
        SearchValueReferenceCode);

      Expression BinaryExpression_Final = Expression.AndAlso(BinaryExpression_Number, BinaryExpression_SystemCodeOrUnit);

      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> QuantityPropertyLessThan(string Property, decimal MidNumber, string System, string Code)
    {
      var ParameterReferance = Expression.Parameter(typeof(T), "x");
      MemberExpression propertyReferenceComparator = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Quantity);

      MemberExpression propertyReferenceSystem = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.System);
      MemberExpression propertyReferenceCode = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Code);
      MemberExpression propertyReferenceUnit = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Unit);

      ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal?));

      ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);
      ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);

      Expression BinaryExpression_Number = DecimalExpression.LessThanExpression(
        propertyReferenceComparator,
        propertyReferenceNumber,
        SearchValueReferenceMid);

      Expression BinaryExpression_SystemCodeOrUnit = QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(
        propertyReferenceSystem,
        propertyReferenceCode,
        propertyReferenceUnit,
        SearchValueReferenceSystem,
        SearchValueReferenceCode);

      Expression BinaryExpression_Final = Expression.AndAlso(BinaryExpression_Number, BinaryExpression_SystemCodeOrUnit);

      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> QuantityPropertyLessThanOrEqualTo(string Property, decimal MidNumber, string System, string Code)
    {
      var ParameterReferance = Expression.Parameter(typeof(T), "x");
      MemberExpression propertyReferenceComparator = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Quantity);

      MemberExpression propertyReferenceSystem = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.System);
      MemberExpression propertyReferenceCode = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Code);
      MemberExpression propertyReferenceUnit = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Unit);

      ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal?));

      ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);
      ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);

      Expression BinaryExpression_Number = DecimalExpression.LessThanOrEqualToExpression(
        propertyReferenceComparator,
        propertyReferenceNumber,
        SearchValueReferenceMid);

      Expression BinaryExpression_SystemCodeOrUnit = QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(
        propertyReferenceSystem,
        propertyReferenceCode,
        propertyReferenceUnit,
        SearchValueReferenceSystem,
        SearchValueReferenceCode);

      Expression BinaryExpression_Final = Expression.AndAlso(BinaryExpression_Number, BinaryExpression_SystemCodeOrUnit);

      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> QuantityPropertyIsNull(string Property)
    {
      var ParameterReferance = Expression.Parameter(typeof(T), "x");
      MemberExpression propertyReferenceComparator = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Quantity);

      MemberExpression propertyReferenceSystem = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.System);
      MemberExpression propertyReferenceCode = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Code);
      MemberExpression propertyReferenceUnit = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Unit);

      Expression BinaryExpression_Number = DecimalExpression.IsNullExpression(
        propertyReferenceComparator,
        propertyReferenceNumber);

      Expression BinaryExpression_SystemCodeOrUnit = QuantityExpression.SystemCodeOrUnit_IsNull_Expression(
        propertyReferenceSystem,
        propertyReferenceCode,
        propertyReferenceUnit);

      Expression BinaryExpression_Final = Expression.AndAlso(BinaryExpression_Number, BinaryExpression_SystemCodeOrUnit);

      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> QuantityPropertyIsNotNull(string Property)
    {
      var ParameterReferance = Expression.Parameter(typeof(T), "x");
      MemberExpression propertyReferenceComparator = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Quantity);

      MemberExpression propertyReferenceSystem = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.System);
      MemberExpression propertyReferenceCode = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Code);
      MemberExpression propertyReferenceUnit = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Unit);

      Expression BinaryExpression_Number = DecimalExpression.IsNotNullExpression(
        propertyReferenceComparator,
        propertyReferenceNumber);

      Expression BinaryExpression_SystemCodeOrUnit = QuantityExpression.SystemCodeOrUnit_IsNotNull_Expression(
        propertyReferenceSystem,
        propertyReferenceCode,
        propertyReferenceUnit);

      Expression BinaryExpression_Final = Expression.OrElse(BinaryExpression_Number, BinaryExpression_SystemCodeOrUnit);

      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }


    public Expression<Func<T, bool>> QuantityCollectionAnyEqualTo(string Property, decimal LowNumber, decimal MidNumber, decimal HighNumber, string System, string Code)
    {
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      //Outer Any Method
      MethodInfo MI_Any = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(QuantityIndex));

      //Expression For Any Method
      ParameterExpression PE_Inner = Expression.Parameter(typeof(QuantityIndex), "c");

      MemberExpression propertyReferenceComparator = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Quantity);

      MemberExpression propertyReferenceSystem = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.System);
      MemberExpression propertyReferenceCode = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Code);
      MemberExpression propertyReferenceUnit = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Unit);

      ConstantExpression SearchValueReferenceLow = Expression.Constant(LowNumber, typeof(decimal));
      ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(HighNumber, typeof(decimal));

      ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);
      ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);

      //Build Inner Expression
      Expression E_InnerExpression1 = DecimalExpression.EqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceLow, SearchValueReferenceMid, SearchValueReferenceHigh);
      Expression E_InnerExpression2 = QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(propertyReferenceSystem, propertyReferenceCode, propertyReferenceUnit, SearchValueReferenceSystem, SearchValueReferenceCode);
      Expression E_Final_InnerExpression = Expression.AndAlso(E_InnerExpression1, E_InnerExpression2);

      //Wrap Any Method Expression into Function
      Expression<Func<QuantityIndex, bool>> InnerFunction = Expression.Lambda<Func<QuantityIndex, bool>>(E_Final_InnerExpression, PE_Inner);

      ParameterExpression PE_Outer = Expression.Parameter(typeof(T), "x");
      MemberExpression ME_CollectionProperty = Expression.Property(PE_Outer, typeof(T).GetProperty(DbPropertyName));

      //Call Any Method with Function
      MethodCallExpression MethodAnyCall = Expression.Call(MI_Any, ME_CollectionProperty, InnerFunction);

      //Wrap final expression into function
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PE_Outer);
    }

    public Expression<Func<T, bool>> QuantityCollectionAllNotEqualTo(string Property, decimal LowNumber, decimal MidNumber, decimal HighNumber, string System, string Code)
    {
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      //Outer Any Method
      MethodInfo ME_All = typeof(Enumerable).GetMethods().Where(m => m.Name == "All" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(QuantityIndex));

      //Expression For Any Method
      ParameterExpression PE_Inner = Expression.Parameter(typeof(QuantityIndex), "c");

      //Expression For Any Method
      MemberExpression propertyReferenceComparator = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Quantity);

      MemberExpression propertyReferenceSystem = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.System);
      MemberExpression propertyReferenceCode = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Code);
      MemberExpression propertyReferenceUnit = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Unit);

      ConstantExpression SearchValueReferenceLow = Expression.Constant(LowNumber, typeof(decimal));
      ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(HighNumber, typeof(decimal));

      ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);
      ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);

      //Build Inner Expression
      //Non of the values are equal to.
      Expression E_InnerExpression1 = DecimalExpression.NotEqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceLow, SearchValueReferenceMid, SearchValueReferenceHigh);
      Expression E_InnerExpression2 = QuantityExpression.SystemCodeOrUnit_NotEqualTo_Expression(propertyReferenceSystem, propertyReferenceCode, propertyReferenceUnit, SearchValueReferenceSystem, SearchValueReferenceCode);
      Expression E_Final_InnerExpression = Expression.OrElse(E_InnerExpression1, E_InnerExpression2);

      //Wrap Any Method Expression into Function
      Expression<Func<QuantityIndex, bool>> InnerFunction = Expression.Lambda<Func<QuantityIndex, bool>>(E_Final_InnerExpression, PE_Inner);

      ParameterExpression PE_Outer = Expression.Parameter(typeof(T), "x");
      MemberExpression ME_CollectionProperty = Expression.Property(PE_Outer, typeof(T).GetProperty(DbPropertyName));

      //Call Any Method with Function
      MethodCallExpression MethodAllCall = Expression.Call(ME_All, ME_CollectionProperty, InnerFunction);

      //Wrap final expression into function
      return Expression.Lambda<Func<T, bool>>(MethodAllCall, PE_Outer);
    }

    public Expression<Func<T, bool>> QuantityCollectionAnyGreaterThan(string Property, decimal MidNumber, string System, string Code)
    {
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      //Outer Any Method
      MethodInfo MI_Any = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(QuantityIndex));

      //Expression For Any Method
      ParameterExpression PE_Inner = Expression.Parameter(typeof(QuantityIndex), "c");

      MemberExpression propertyReferenceComparator = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Quantity);

      MemberExpression propertyReferenceSystem = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.System);
      MemberExpression propertyReferenceCode = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Code);
      MemberExpression propertyReferenceUnit = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Unit);

      ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal));

      ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);
      ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);

      //Build Inner Expression
      Expression E_InnerExpression1 = DecimalExpression.GreaterThanExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);
      Expression E_InnerExpression2 = QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(propertyReferenceSystem, propertyReferenceCode, propertyReferenceUnit, SearchValueReferenceSystem, SearchValueReferenceCode);
      Expression E_Final_InnerExpression = Expression.AndAlso(E_InnerExpression1, E_InnerExpression2);

      //Wrap Any Method Expression into Function
      Expression<Func<QuantityIndex, bool>> InnerFunction = Expression.Lambda<Func<QuantityIndex, bool>>(E_Final_InnerExpression, PE_Inner);

      ParameterExpression PE_Outer = Expression.Parameter(typeof(T), "x");
      MemberExpression ME_CollectionProperty = Expression.Property(PE_Outer, typeof(T).GetProperty(DbPropertyName));

      //Call Any Method with Function
      MethodCallExpression MethodAnyCall = Expression.Call(MI_Any, ME_CollectionProperty, InnerFunction);

      //Wrap final expression into function
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PE_Outer);
    }

    public Expression<Func<T, bool>> QuantityCollectionAnyGreaterThanOrEqualTo(string Property, decimal MidNumber, string System, string Code)
    {
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      //Outer Any Method
      MethodInfo MI_Any = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(QuantityIndex));

      //Expression For Any Method
      ParameterExpression PE_Inner = Expression.Parameter(typeof(QuantityIndex), "c");

      MemberExpression propertyReferenceComparator = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Quantity);

      MemberExpression propertyReferenceSystem = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.System);
      MemberExpression propertyReferenceCode = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Code);
      MemberExpression propertyReferenceUnit = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Unit);

      ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal));

      ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);
      ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);

      //Build Inner Expression
      Expression E_InnerExpression1 = DecimalExpression.GreaterThanOrEqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);
      Expression E_InnerExpression2 = QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(propertyReferenceSystem, propertyReferenceCode, propertyReferenceUnit, SearchValueReferenceSystem, SearchValueReferenceCode);
      Expression E_Final_InnerExpression = Expression.AndAlso(E_InnerExpression1, E_InnerExpression2);

      //Wrap Any Method Expression into Function
      Expression<Func<QuantityIndex, bool>> InnerFunction = Expression.Lambda<Func<QuantityIndex, bool>>(E_Final_InnerExpression, PE_Inner);

      ParameterExpression PE_Outer = Expression.Parameter(typeof(T), "x");
      MemberExpression ME_CollectionProperty = Expression.Property(PE_Outer, typeof(T).GetProperty(DbPropertyName));

      //Call Any Method with Function
      MethodCallExpression MethodAnyCall = Expression.Call(MI_Any, ME_CollectionProperty, InnerFunction);

      //Wrap final expression into function
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PE_Outer);
    }

    public Expression<Func<T, bool>> QuantityCollectionAnyLessThan(string Property, decimal MidNumber, string System, string Code)
    {
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      //Outer Any Method
      MethodInfo MI_Any = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(QuantityIndex));

      //Expression For Any Method
      ParameterExpression PE_Inner = Expression.Parameter(typeof(QuantityIndex), "c");

      MemberExpression propertyReferenceComparator = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Quantity);

      MemberExpression propertyReferenceSystem = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.System);
      MemberExpression propertyReferenceCode = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Code);
      MemberExpression propertyReferenceUnit = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Unit);

      ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal));

      ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);
      ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);

      //Build Inner Expression
      Expression E_InnerExpression1 = DecimalExpression.LessThanExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);
      Expression E_InnerExpression2 = QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(propertyReferenceSystem, propertyReferenceCode, propertyReferenceUnit, SearchValueReferenceSystem, SearchValueReferenceCode);
      Expression E_Final_InnerExpression = Expression.AndAlso(E_InnerExpression1, E_InnerExpression2);

      //Wrap Any Method Expression into Function
      Expression<Func<QuantityIndex, bool>> InnerFunction = Expression.Lambda<Func<QuantityIndex, bool>>(E_Final_InnerExpression, PE_Inner);

      ParameterExpression PE_Outer = Expression.Parameter(typeof(T), "x");
      MemberExpression ME_CollectionProperty = Expression.Property(PE_Outer, typeof(T).GetProperty(DbPropertyName));

      //Call Any Method with Function
      MethodCallExpression MethodAnyCall = Expression.Call(MI_Any, ME_CollectionProperty, InnerFunction);

      //Wrap final expression into function
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PE_Outer);
    }

    public Expression<Func<T, bool>> QuantityCollectionAnyLessThanOrEqualTo(string Property, decimal MidNumber, string System, string Code)
    {
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      //Outer Any Method
      MethodInfo MI_Any = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(QuantityIndex));

      //Expression For Any Method
      ParameterExpression PE_Inner = Expression.Parameter(typeof(QuantityIndex), "c");

      MemberExpression propertyReferenceComparator = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Comparator);
      MemberExpression propertyReferenceNumber = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Quantity);

      MemberExpression propertyReferenceSystem = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.System);
      MemberExpression propertyReferenceCode = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Code);
      MemberExpression propertyReferenceUnit = Expression.Property(PE_Inner, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Unit);

      ConstantExpression SearchValueReferenceMid = Expression.Constant(MidNumber, typeof(decimal));

      ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);
      ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);

      //Build Inner Expression
      Expression E_InnerExpression1 = DecimalExpression.LessThanOrEqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);
      Expression E_InnerExpression2 = QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(propertyReferenceSystem, propertyReferenceCode, propertyReferenceUnit, SearchValueReferenceSystem, SearchValueReferenceCode);
      Expression E_Final_InnerExpression = Expression.AndAlso(E_InnerExpression1, E_InnerExpression2);

      //Wrap Any Method Expression into Function
      Expression<Func<QuantityIndex, bool>> InnerFunction = Expression.Lambda<Func<QuantityIndex, bool>>(E_Final_InnerExpression, PE_Inner);

      ParameterExpression PE_Outer = Expression.Parameter(typeof(T), "x");
      MemberExpression ME_CollectionProperty = Expression.Property(PE_Outer, typeof(T).GetProperty(DbPropertyName));

      //Call Any Method with Function
      MethodCallExpression MethodAnyCall = Expression.Call(MI_Any, ME_CollectionProperty, InnerFunction);

      //Wrap final expression into function
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PE_Outer);
    }

    public Expression<Func<T, bool>> QuantityCollectionIsNull(string Property)
    {
      //(x => x.date_List.Count == 0);
      var type = typeof(T);
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      MethodInfo MethodCount = typeof(Enumerable).GetMethods().Where(m => m.Name == "Count" && m.GetParameters().Length == 1).Single().MakeGenericMethod(typeof(QuantityIndex));

      ParameterExpression ResourceParameter = Expression.Parameter(typeof(T), "x");
      MemberExpression CollectionProperty = Expression.Property(ResourceParameter, typeof(T).GetProperty(DbPropertyName));
      MethodCallExpression MethodCountCall = Expression.Call(MethodCount, CollectionProperty);
      ConstantExpression constantReference = Expression.Constant(0);
      BinaryExpression BinaryExpression = Expression.Equal(MethodCountCall, constantReference);

      return Expression.Lambda<Func<T, bool>>(BinaryExpression, ResourceParameter);
    }

    public Expression<Func<T, bool>> QuantityCollectionIsNotNull(string Property)
    {
      //(x => x.date_List.Count > 0);
      var type = typeof(T);
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      MethodInfo MethodCount = typeof(Enumerable).GetMethods().Where(m => m.Name == "Count" && m.GetParameters().Length == 1).Single().MakeGenericMethod(typeof(QuantityIndex));

      ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
      MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
      MethodCallExpression MethodAnyCall = Expression.Call(MethodCount, CollectionProperty);
      ConstantExpression constantReference = Expression.Constant(0);
      BinaryExpression BinaryExpression = Expression.GreaterThan(MethodAnyCall, constantReference);
      return Expression.Lambda<Func<T, bool>>(BinaryExpression, PatientParameter);
    }

    
    //---- Uri Index Expressions ------------------------------------------------------

    public Expression<Func<T, bool>> UriPropertyEqualTo(string Property, string Value)
    {
      //(x => x.Meta.profile == "https://www.megaspin.net/store/default.asp?pid=b-tack-chop-ii")
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReference = Expression.Property(ParameterReferance, Property);
      var constantReference = Expression.Constant(Value);
      var BinaryExpression = Expression.Equal(propertyReference, constantReference);
      return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> UriPropertyIsNotNull(string Property)
    {
      //(x => x.birthdate_DateTimeOffset != null);
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.UriIndexConstatnts.Uri);
      var constantReference = Expression.Constant(null);
      var BinaryExpression = Expression.NotEqual(propertyReference, constantReference);
      return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> UriPropertyIsNull(string Property)
    {
      //(x => x.birthdate_DateTimeOffset == null);
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReference = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.UriIndexConstatnts.Uri);
      var constantReference = Expression.Constant(null);
      var BinaryExpression = Expression.Equal(propertyReference, constantReference);
      return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> UriPropertyContains(string Property, string Value)
    {
      MethodInfo MethodContains = typeof(string).GetMethods().Where(m => m.Name == "Contains" && m.GetParameters().Length == 1).Single();

      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReference = Expression.Property(ParameterReferance, Property);
      var constantReference = Expression.Constant(Value);
      var MethodContainsCall = Expression.Call(propertyReference, MethodContains, constantReference);
      return Expression.Lambda<Func<T, bool>>(MethodContainsCall, ParameterReferance);
    }

    public Expression<Func<T, bool>> UriPropertyStartsWith(string Property, string Value)
    {
      //(x => x.FhirId.StartsWith("a99b5c95-b546-46ee-8992-19a7ca703d4a"))      
      MethodInfo MethodStartsWith = typeof(string).GetMethods().Where(m => m.Name == "StartsWith" && m.GetParameters().Length == 1).Single();

      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReference = Expression.Property(ParameterReferance, Property);
      var constantReference = Expression.Constant(Value);
      var MethodStartsWithCall = Expression.Call(propertyReference, MethodStartsWith, constantReference);
      return Expression.Lambda<Func<T, bool>>(MethodStartsWithCall, ParameterReferance);
    }

    public Expression<Func<T, bool>> UriPropertyEndsWith(string Property, string Value)
    {
      //(x => x.FhirId.StartsWith("a99b5c95-b546-46ee-8992-19a7ca703d4a"))      
      MethodInfo MethodStartsWith = typeof(string).GetMethods().Where(m => m.Name == "EndsWith" && m.GetParameters().Length == 1).Single();

      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReference = Expression.Property(ParameterReferance, Property);
      var constantReference = Expression.Constant(Value);
      var MethodStartsWithCall = Expression.Call(propertyReference, MethodStartsWith, constantReference);
      return Expression.Lambda<Func<T, bool>>(MethodStartsWithCall, ParameterReferance);
    }


    public Expression<Func<T, bool>> UriCollectionAnyEqualTo(string Property, string Value)
    {
      var type = typeof(T);
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;
      //Inner
      MethodInfo MethodEquals = typeof(string).GetMethods().Where(m => m.Name == "Equals" && m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == typeof(string)).Single();

      ParameterExpression InnerParameter = Expression.Parameter(typeof(UriIndex), "c");
      MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.UriIndexConstatnts.Uri);
      ConstantExpression InnerValue = Expression.Constant(Value);

      MethodCallExpression MethodEqualsCall = Expression.Call(InnerProperty, MethodEquals, InnerValue);
      Expression<Func<UriIndex, bool>> InnerFunction = Expression.Lambda<Func<UriIndex, bool>>(MethodEqualsCall, InnerParameter);

      //Outer Any
      MethodInfo MethodAny = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(UriIndex));

      ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
      MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
      MethodCallExpression MethodAnyCall = Expression.Call(MethodAny, CollectionProperty, InnerFunction);
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PatientParameter);
    }

    public Expression<Func<T, bool>> UriCollectionAnyContains(string Property, string Value)
    {
      //(x => x.family_List.Any(c => c.String.Contains("Mill")));
      var type = typeof(T);
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      //Inner
      MethodInfo MethodContains = typeof(string).GetMethods().Where(m => m.Name == "Contains" && m.GetParameters().Length == 1).Single();

      ParameterExpression InnerParameter = Expression.Parameter(typeof(UriIndex), "c");
      MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.UriIndexConstatnts.Uri);
      ConstantExpression InnerValue = Expression.Constant(Value);
      MethodCallExpression MethodContainsCall = Expression.Call(InnerProperty, MethodContains, InnerValue);
      Expression<Func<UriIndex, bool>> InnerFunction = Expression.Lambda<Func<UriIndex, bool>>(MethodContainsCall, InnerParameter);

      //Outer Any
      MethodInfo MethodAny = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(UriIndex));

      ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
      MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
      MethodCallExpression MethodAnyCall = Expression.Call(MethodAny, CollectionProperty, InnerFunction);
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PatientParameter);
    }

    public Expression<Func<T, bool>> UriCollectionAnyStartsWith(string Property, string Value)
    {
      //(x => x.family_List.Any(c => c.String.StartsWith("Mill")));
      var type = typeof(T);
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      //Inner
      MethodInfo MethodStartsWith = typeof(string).GetMethods().Where(m => m.Name == "StartsWith" && m.GetParameters().Length == 1).Single();

      ParameterExpression InnerParameter = Expression.Parameter(typeof(UriIndex), "c");
      MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.UriIndexConstatnts.Uri);
      ConstantExpression InnerValue = Expression.Constant(Value);
      MethodCallExpression MethodStartsWithCall = Expression.Call(InnerProperty, MethodStartsWith, InnerValue);
      Expression<Func<UriIndex, bool>> InnerFunction = Expression.Lambda<Func<UriIndex, bool>>(MethodStartsWithCall, InnerParameter);

      //Outer Any
      MethodInfo MethodAny = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(UriIndex));

      ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
      MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
      MethodCallExpression MethodAnyCall = Expression.Call(MethodAny, CollectionProperty, InnerFunction);
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PatientParameter);
    }

    public Expression<Func<T, bool>> UriCollectionAnyEndsWith(string Property, string Value)
    {
      //(x => x.family_List.Any(c => c.String.StartsWith("Mill")));
      var type = typeof(T);
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      //Inner
      MethodInfo MethodEndsWith = typeof(string).GetMethods().Where(m => m.Name == "EndsWith" && m.GetParameters().Length == 1).Single();

      ParameterExpression InnerParameter = Expression.Parameter(typeof(UriIndex), "c");
      MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.UriIndexConstatnts.Uri);
      ConstantExpression InnerValue = Expression.Constant(Value);
      MethodCallExpression MethodStartsWithCall = Expression.Call(InnerProperty, MethodEndsWith, InnerValue);
      Expression<Func<UriIndex, bool>> InnerFunction = Expression.Lambda<Func<UriIndex, bool>>(MethodStartsWithCall, InnerParameter);

      //Outer Any
      MethodInfo MethodAny = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(UriIndex));

      ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
      MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
      MethodCallExpression MethodAnyCall = Expression.Call(MethodAny, CollectionProperty, InnerFunction);
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PatientParameter);
    }

    public Expression<Func<T, bool>> UriCollectionIsNull(string Property)
    {
      var type = typeof(T);
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      MethodInfo MethodCount = typeof(Enumerable).GetMethods().Where(m => m.Name == "Count" && m.GetParameters().Length == 1).Single().MakeGenericMethod(typeof(UriIndex));

      ParameterExpression ResourceParameter = Expression.Parameter(typeof(T), "x");
      MemberExpression CollectionProperty = Expression.Property(ResourceParameter, typeof(T).GetProperty(DbPropertyName));
      MethodCallExpression MethodCountCall = Expression.Call(MethodCount, CollectionProperty);
      ConstantExpression constantReference = Expression.Constant(0);
      BinaryExpression BinaryExpression = Expression.Equal(MethodCountCall, constantReference);

      return Expression.Lambda<Func<T, bool>>(BinaryExpression, ResourceParameter);
    }

    public Expression<Func<T, bool>> UriCollectionIsNotNull(string Property)
    {
      var type = typeof(T);
      string DbPropertyName = Property + StaticDatabaseInfo.ListPostfixText;

      MethodInfo MethodCount = typeof(Enumerable).GetMethods().Where(m => m.Name == "Count" && m.GetParameters().Length == 1).Single().MakeGenericMethod(typeof(UriIndex));

      ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
      MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
      MethodCallExpression MethodAnyCall = Expression.Call(MethodCount, CollectionProperty);
      ConstantExpression constantReference = Expression.Constant(0);
      BinaryExpression BinaryExpression = Expression.GreaterThan(MethodAnyCall, constantReference);
      return Expression.Lambda<Func<T, bool>>(BinaryExpression, PatientParameter);
    }


    //---- Referance Index Expressions ------------------------------------------------------

    public Expression<Func<T, bool>> ReferancePropertyEqualTo_ByKey(string Property, int UrlStoreKey, string Resource, string FhirId, string History)
    {
      var ParameterReferance = Expression.Parameter(typeof(T), "x");
      MemberExpression propertyReferenceUrlStoreKey = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.ServiceRootURL_StoreID);
      MemberExpression propertyReferenceResource = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.Type);    
      MemberExpression propertyReferenceFhirId = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.FhirId);
      MemberExpression propertyReferenceHistory = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.VersionId);

      

      ConstantExpression SearchValueReferenceUrlStoreKey = Expression.Constant(UrlStoreKey, typeof(int?));
      ConstantExpression SearchValueReferenceResource = Expression.Constant(Resource, typeof(string));
      ConstantExpression SearchValueReferenceFhirID = Expression.Constant(FhirId, typeof(string));
      ConstantExpression SearchValueReferenceHistory = Expression.Constant(History, typeof(string));


      Expression BinaryExpression_Final = ReferanceExpression.EqualTo_ByURLStoreKey_Expression(
        propertyReferenceUrlStoreKey,
        propertyReferenceResource,
        propertyReferenceFhirId,
        propertyReferenceHistory,
        SearchValueReferenceUrlStoreKey,
        SearchValueReferenceResource,
        SearchValueReferenceFhirID,
        SearchValueReferenceHistory);

      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> ReferancePropertyEqualTo_ByUrlString(string Property, string UrlString, string Resource, string FhirId, string History)
    {
      var ParameterReferance = Expression.Parameter(typeof(T), "x");


      //-------------------------------------------------------------------------------
      //(x => x.organization_Url.RootUrl == "www.bla.com");
      //ParameterExpression InnerParameter = Expression.Parameter(typeof(DatabaseModel.ServiceRootURL_Store), "c");
      //MemberExpression InnerPropertUrl = Expression.Property(InnerParameter, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.UriIndexConstatnts.Uri);

      



      //var ParameterReferanceServiceRootURL_Store = Expression.Parameter(typeof(Blaze.DataModel.DatabaseModel.ServiceRootURL_Store), "v");


      //-------------------------------------------------------------------------------------------------

      MemberExpression propertyReferenceUrl = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.Url);
      MemberExpression propertyReferenceServiceRootURL_StoreRootUrl = Expression.Property(propertyReferenceUrl, StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.ServiceRootURL_Store.RootUrl);
      MemberExpression propertyReferenceResource = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.Type);
      MemberExpression propertyReferenceFhirId = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.FhirId);
      MemberExpression propertyReferenceHistory = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.VersionId);



      ConstantExpression SearchValueReferenceUrlString = Expression.Constant(UrlString, typeof(string));
      ConstantExpression SearchValueReferenceResource = Expression.Constant(Resource, typeof(string));
      ConstantExpression SearchValueReferenceFhirID = Expression.Constant(FhirId, typeof(string));
      ConstantExpression SearchValueReferenceHistory = Expression.Constant(History, typeof(string));


      Expression BinaryExpression_Final = ReferanceExpression.EqualTo_ByURLString_Expression(
        propertyReferenceUrl,
        propertyReferenceServiceRootURL_StoreRootUrl,
        propertyReferenceResource,
        propertyReferenceFhirId,
        propertyReferenceHistory,
        SearchValueReferenceUrlString,
        SearchValueReferenceResource,
        SearchValueReferenceFhirID,
        SearchValueReferenceHistory);



      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }


    //---- QuantityRange Index Expressions ------------------------------------------------------

    //Not implemented as there are no QuantityRange search parameters as yet in FHIR spec, as of this early STU3 release

  }

}

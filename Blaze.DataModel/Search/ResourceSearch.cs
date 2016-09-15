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

    //---- Token Index Expressions ------------------------------------------------------

    public Expression<Func<T, bool>> TokenPropertyEqualTo(string Property, Common.BusinessEntities.Search.DtoSearchParameterToken.TokenValue TokenValue)
    {
      //MyPredicate = MyPredicate.Or(x => x.active_Code == "Code" && x.active_System == "System");
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");

      if (string.IsNullOrWhiteSpace(TokenValue.System))
      {
        var CodePropertyReference = Expression.Property(ParameterReferance, "gender_Code");
        var CodeConstantReference = Expression.Constant(StringSupport.ToLowerAndRemoveDiacritics(TokenValue.Code.Trim()));
        var CodeBinaryExpression = Expression.Equal(CodePropertyReference, CodeConstantReference);
        return Expression.Lambda<Func<T, bool>>(CodeBinaryExpression, new[] { ParameterReferance });

      }
      else
      {
        var CodePropertyReference = Expression.Property(ParameterReferance, "gender_Code");
        var CodeConstantReference = Expression.Constant(StringSupport.ToLowerAndRemoveDiacritics(TokenValue.Code.Trim()));
        var CodeBinaryExpression = Expression.Equal(CodePropertyReference, CodeConstantReference);

        var SystemPropertyReference = Expression.Property(ParameterReferance, "gender_System");
        var SystemConstantReference = Expression.Constant(StringSupport.ToLowerAndRemoveDiacritics(TokenValue.Code.Trim()));
        var SystemBinaryExpression = Expression.Equal(SystemPropertyReference, SystemConstantReference);

        var CodeAndSystemExpression = Expression.And(CodeBinaryExpression, SystemBinaryExpression);

        return Expression.Lambda<Func<T, bool>>(CodeAndSystemExpression, new[] { ParameterReferance });

      }

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

    public Expression<Func<T, bool>> DateTimePeriodPropertyEqualTo(string Property, DateTimeOffset Value)
    {
      //(x => x. date_DateTimeOffsetLow <= Value && date_DateTimeOffsetHigh >= Value );
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReferenceLow = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
      var propertyReferenceHigh = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);
      var constantReference = Expression.Constant(Value, typeof(DateTimeOffset?));
      var BinaryExpressionLow = Expression.LessThanOrEqual(propertyReferenceLow, constantReference);
      var BinaryExpressionHigh = Expression.GreaterThanOrEqual(propertyReferenceHigh, constantReference);
      var BinaryExpressionAnd = Expression.And(BinaryExpressionLow, BinaryExpressionHigh);
      return Expression.Lambda<Func<T, bool>>(BinaryExpressionAnd, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DateTimePeriodPropertyNotEqualTo(string Property, DateTimeOffset Value)
    {
      //(x => x. date_DateTimeOffsetLow > Value || date_DateTimeOffsetHigh < Value );
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReferenceLow = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
      var propertyReferenceHigh = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);
      var constantReference = Expression.Constant(Value, typeof(DateTimeOffset?));
      var BinaryExpressionLow = Expression.GreaterThan(propertyReferenceLow, constantReference);
      var BinaryExpressionHigh = Expression.LessThan(propertyReferenceHigh, constantReference);
      var BinaryExpressionOr = Expression.Or(BinaryExpressionLow, BinaryExpressionHigh);
      return Expression.Lambda<Func<T, bool>>(BinaryExpressionOr, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DateTimePeriodPropertyGreaterThan(string Property, DateTimeOffset Value)
    {
      //(x => x.date_DateTimeOffsetHigh < Value || x.date_DateTimeOffsetHigh == null && x.date_DateTimeOffsetLow > Value  );
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReferenceLow = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
      var propertyReferenceHigh = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);
      var constantReferenceValue = Expression.Constant(Value, typeof(DateTimeOffset?));
      //var constantReferenceNull = Expression.Constant(null);

      //var BinaryExpressionNotNull = Expression.NotEqual(propertyReferenceHigh, constantReferenceNull);
      var BinaryExpressionLow = Expression.GreaterThan(propertyReferenceLow, constantReferenceValue);
      var BinaryExpressionHigh = Expression.GreaterThan(propertyReferenceHigh, constantReferenceValue);

      var BinaryExpressionOr = Expression.Or(BinaryExpressionLow, BinaryExpressionHigh);

      return Expression.Lambda<Func<T, bool>>(BinaryExpressionOr, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DateTimePeriodPropertyGreaterThanOrEqualTo(string Property, DateTimeOffset Value)
    {
      //(x => x.date_DateTimeOffsetLow >= Value || x.date_DateTimeOffsetHigh >= Value  );
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReferenceLow = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
      var propertyReferenceHigh = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);
      var constantReferenceValue = Expression.Constant(Value, typeof(DateTimeOffset?));

      var BinaryExpressionLow = Expression.GreaterThanOrEqual(propertyReferenceLow, constantReferenceValue);
      var BinaryExpressionHigh = Expression.GreaterThanOrEqual(propertyReferenceHigh, constantReferenceValue);


      var BinaryExpressionOr = Expression.Or(BinaryExpressionLow, BinaryExpressionHigh);

      return Expression.Lambda<Func<T, bool>>(BinaryExpressionOr, new[] { ParameterReferance });
    }
  }
}

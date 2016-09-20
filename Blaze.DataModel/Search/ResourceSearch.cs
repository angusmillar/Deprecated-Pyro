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

    public Expression<Func<T, bool>> DateTimePeriodPropertyEqualTo(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {
      var ParameterReferance = Expression.Parameter(typeof(T), "x");
      MemberExpression propertyReferenceLow = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
      MemberExpression propertyReferenceHigh = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);

      //Build Inner Expression
      Expression BinaryExpression_Final = DateTimePeriodEqualToExpression(Property, propertyReferenceLow, SearchValueLow, propertyReferenceHigh, SearchValueHigh);
      
      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DateTimePeriodPropertyNotEqualTo(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {
      //(x => x. date_DateTimeOffsetLow > Value || date_DateTimeOffsetHigh < Value );
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");

      var propertyReferenceLow = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
      var propertyReferenceHigh = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);

      var SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
      var SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));
      var ConstantReferenceNull = Expression.Constant(null);

      //(x.date_DateTimeOffsetLow == Null)
      var BinaryExpression_ResourceLow_IsNull = Expression.Equal(propertyReferenceLow, ConstantReferenceNull);

      //(x.date_DateTimeOffsetLow != Null)
      var BinaryExpression_ResourceLow_IsNotNull = Expression.NotEqual(propertyReferenceLow, ConstantReferenceNull);

      //(x.date_DateTimeOffsetHigh == Null)
      var BinaryExpression_ResourceHigh_IsNull = Expression.Equal(propertyReferenceHigh, ConstantReferenceNull);

      //(x.date_DateTimeOffsetHigh != Null)
      var BinaryExpression_ResourceHigh_IsNotNull = Expression.NotEqual(propertyReferenceHigh, ConstantReferenceNull);

      //(x.date_DateTimeOffsetLow <= ValueLow)
      var BinaryExpression_ResourceLow_IsLowerThanOrEqual_SearchLow = Expression.LessThanOrEqual(propertyReferenceLow, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetLow < ValueLow)
      var BinaryExpression_ResourceLow_IsLowerThan_SearchLow = Expression.LessThan(propertyReferenceLow, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetLow >= ValueLow)
      var BinaryExpression_ResourceLow_IsHigherThanOrEqualTo_SearchLow = Expression.GreaterThanOrEqual(propertyReferenceLow, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetLow > ValueLow)
      var BinaryExpression_ResourceLow_IsHigherThan_SearchLow = Expression.GreaterThan(propertyReferenceLow, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetLow <= ValueHigh)
      var BinaryExpression_ResourceLow_IsLowerThanOrEqualTo_SearchHigh = Expression.LessThanOrEqual(propertyReferenceLow, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetLow < ValueHigh)
      var BinaryExpression_ResourceLow_IsLowerThan_SearchHigh = Expression.LessThan(propertyReferenceLow, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetLow >= ValueHigh)
      var BinaryExpression_ResourceLow_IsHigherThanOrEqualTo_SearchHigh = Expression.GreaterThanOrEqual(propertyReferenceLow, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetLow > ValueHigh)
      var BinaryExpression_ResourceLow_IsHigherThan_SearchHigh = Expression.GreaterThan(propertyReferenceLow, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetHigh <= ValueHigh)
      var BinaryExpression_ResourceHigh_IsLowerThanOrEqualTo_SearchHigh = Expression.LessThanOrEqual(propertyReferenceHigh, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetHigh < ValueHigh)
      var BinaryExpression_ResourceHigh_IsLowerThan_SearchHigh = Expression.LessThan(propertyReferenceHigh, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetHigh >= ValueHigh)
      var BinaryExpression_ResourceHigh_IsHigherThanOrEqualTo_SearchHigh = Expression.GreaterThanOrEqual(propertyReferenceHigh, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetHigh >= ValueHigh)
      var BinaryExpression_ResourceHigh_IsHigherThan_SearchHigh = Expression.GreaterThan(propertyReferenceHigh, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetHigh <= ValueLow)
      var BinaryExpression_ResourceHigh_IsLowerThanOrEqualTo_SearchLow = Expression.LessThanOrEqual(propertyReferenceHigh, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetHigh < ValueLow)
      var BinaryExpression_ResourceHigh_IsLowerThan_SearchLow = Expression.LessThan(propertyReferenceHigh, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetHigh >= ValueLow)
      var BinaryExpression_ResourceHigh_IsHigherThanOrEqualTo_SearchLow = Expression.GreaterThanOrEqual(propertyReferenceHigh, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetHigh > ValueLow)
      var BinaryExpression_ResourceHigh_IsHigherThan_SearchLow = Expression.GreaterThan(propertyReferenceHigh, SearchValueReferenceLow);

      //BinaryExpression_A
      //(x.date_DateTimeOffsetHigh == Null && x.date_DateTimeOffsetLow > ValueHigh)
      var BinaryExpression_A = Expression.And(BinaryExpression_ResourceHigh_IsNull, BinaryExpression_ResourceLow_IsHigherThan_SearchHigh);

      //BinaryExpression_B
      //(x.date_DateTimeOffsetLow == Null && x.date_DateTimeOffsetHigh < ValueLow)
      var BinaryExpression_B = Expression.And(BinaryExpression_ResourceHigh_IsNull, BinaryExpression_ResourceLow_IsHigherThan_SearchHigh);

      //BinaryExpression_C
      //(x.date_DateTimeOffsetLow > ValueHigh || x.date_DateTimeOffsetHigh < ValueLow)
      var BinaryExpression_C = Expression.Or(BinaryExpression_ResourceLow_IsHigherThan_SearchHigh, BinaryExpression_ResourceHigh_IsLowerThan_SearchLow);

      //BinaryExpression_D
      //(x.date_DateTimeOffsetLow == Null && x.date_DateTimeOffsetHigh == Null)
      var BinaryExpression_D = Expression.Add(BinaryExpression_ResourceLow_IsNull, BinaryExpression_ResourceHigh_IsNull);


      //(BinaryExpression_A Or BinaryExpression_B) 
      var BinaryExpression_AA = Expression.Or(BinaryExpression_A, BinaryExpression_B);
      var BinaryExpression_BB = Expression.Or(BinaryExpression_C, BinaryExpression_D);

      var BinaryExpression_Final = Expression.Or(BinaryExpression_AA, BinaryExpression_BB);


      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DateTimePeriodPropertyGreaterThan(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");

      var propertyReferenceLow = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
      var propertyReferenceHigh = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);

      var SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
      var SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));
      var ConstantReferenceNull = Expression.Constant(null);

      //(x.date_DateTimeOffsetLow == Null)
      var BinaryExpression_ResourceLow_IsNull = Expression.Equal(propertyReferenceLow, ConstantReferenceNull);

      //(x.date_DateTimeOffsetLow != Null)
      var BinaryExpression_ResourceLow_IsNotNull = Expression.NotEqual(propertyReferenceLow, ConstantReferenceNull);

      //(x.date_DateTimeOffsetHigh == Null)
      var BinaryExpression_ResourceHigh_IsNull = Expression.Equal(propertyReferenceHigh, ConstantReferenceNull);

      //(x.date_DateTimeOffsetHigh != Null)
      var BinaryExpression_ResourceHigh_IsNotNull = Expression.NotEqual(propertyReferenceHigh, ConstantReferenceNull);

      //(x.date_DateTimeOffsetLow <= ValueLow)
      var BinaryExpression_ResourceLow_IsLowerThanOrEqual_SearchLow = Expression.LessThanOrEqual(propertyReferenceLow, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetLow < ValueLow)
      var BinaryExpression_ResourceLow_IsLowerThan_SearchLow = Expression.LessThan(propertyReferenceLow, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetLow >= ValueLow)
      var BinaryExpression_ResourceLow_IsHigherThanOrEqualTo_SearchLow = Expression.GreaterThanOrEqual(propertyReferenceLow, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetLow > ValueLow)
      var BinaryExpression_ResourceLow_IsHigherThan_SearchLow = Expression.GreaterThan(propertyReferenceLow, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetLow <= ValueHigh)
      var BinaryExpression_ResourceLow_IsLowerThanOrEqualTo_SearchHigh = Expression.LessThanOrEqual(propertyReferenceLow, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetLow < ValueHigh)
      var BinaryExpression_ResourceLow_IsLowerThan_SearchHigh = Expression.LessThan(propertyReferenceLow, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetLow >= ValueHigh)
      var BinaryExpression_ResourceLow_IsHigherThanOrEqualTo_SearchHigh = Expression.GreaterThanOrEqual(propertyReferenceLow, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetLow > ValueHigh)
      var BinaryExpression_ResourceLow_IsHigherThan_SearchHigh = Expression.GreaterThan(propertyReferenceLow, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetHigh <= ValueHigh)
      var BinaryExpression_ResourceHigh_IsLowerThanOrEqualTo_SearchHigh = Expression.LessThanOrEqual(propertyReferenceHigh, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetHigh < ValueHigh)
      var BinaryExpression_ResourceHigh_IsLowerThan_SearchHigh = Expression.LessThan(propertyReferenceHigh, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetHigh >= ValueHigh)
      var BinaryExpression_ResourceHigh_IsHigherThanOrEqualTo_SearchHigh = Expression.GreaterThanOrEqual(propertyReferenceHigh, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetHigh >= ValueHigh)
      var BinaryExpression_ResourceHigh_IsHigherThan_SearchHigh = Expression.GreaterThan(propertyReferenceHigh, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetHigh <= ValueLow)
      var BinaryExpression_ResourceHigh_IsLowerThanOrEqualTo_SearchLow = Expression.LessThanOrEqual(propertyReferenceHigh, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetHigh < ValueLow)
      var BinaryExpression_ResourceHigh_IsLowerThan_SearchLow = Expression.LessThan(propertyReferenceHigh, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetHigh >= ValueLow)
      var BinaryExpression_ResourceHigh_IsHigherThanOrEqualTo_SearchLow = Expression.GreaterThanOrEqual(propertyReferenceHigh, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetHigh > ValueLow)
      var BinaryExpression_ResourceHigh_IsHigherThan_SearchLow = Expression.GreaterThan(propertyReferenceHigh, SearchValueReferenceLow);

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

      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DateTimePeriodPropertyGreaterThanOrEqualTo(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");

      var propertyReferenceLow = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
      var propertyReferenceHigh = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);

      var SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
      var SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));
      var ConstantReferenceNull = Expression.Constant(null);

      //(x.date_DateTimeOffsetLow == Null)
      var BinaryExpression_ResourceLow_IsNull = Expression.Equal(propertyReferenceLow, ConstantReferenceNull);

      //(x.date_DateTimeOffsetLow != Null)
      var BinaryExpression_ResourceLow_IsNotNull = Expression.NotEqual(propertyReferenceLow, ConstantReferenceNull);


      //(x.date_DateTimeOffsetHigh == Null)
      var BinaryExpression_ResourceHigh_IsNull = Expression.Equal(propertyReferenceHigh, ConstantReferenceNull);

      //(x.date_DateTimeOffsetHigh != Null)
      var BinaryExpression_ResourceHigh_IsNotNull = Expression.NotEqual(propertyReferenceHigh, ConstantReferenceNull);


      //(x.date_DateTimeOffsetLow <= ValueLow)
      var BinaryExpression_ResourceLow_IsLowerThanOrEqual_SearchLow = Expression.LessThanOrEqual(propertyReferenceLow, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetLow < ValueLow)
      var BinaryExpression_ResourceLow_IsLowerThan_SearchLow = Expression.LessThan(propertyReferenceLow, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetLow >= ValueLow)
      var BinaryExpression_ResourceLow_IsHigherThanOrEqualTo_SearchLow = Expression.GreaterThanOrEqual(propertyReferenceLow, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetLow > ValueLow)
      var BinaryExpression_ResourceLow_IsHigherThan_SearchLow = Expression.GreaterThan(propertyReferenceLow, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetLow <= ValueHigh)
      var BinaryExpression_ResourceLow_IsLowerThanOrEqualTo_SearchHigh = Expression.LessThanOrEqual(propertyReferenceLow, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetLow < ValueHigh)
      var BinaryExpression_ResourceLow_IsLowerThan_SearchHigh = Expression.LessThan(propertyReferenceLow, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetLow >= ValueHigh)
      var BinaryExpression_ResourceLow_IsHigherThanOrEqualTo_SearchHigh = Expression.GreaterThanOrEqual(propertyReferenceLow, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetLow > ValueHigh)
      var BinaryExpression_ResourceLow_IsHigherThan_SearchHigh = Expression.GreaterThan(propertyReferenceLow, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetHigh <= ValueHigh)
      var BinaryExpression_ResourceHigh_IsLowerThanOrEqualTo_SearchHigh = Expression.LessThanOrEqual(propertyReferenceHigh, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetHigh < ValueHigh)
      var BinaryExpression_ResourceHigh_IsLowerThan_SearchHigh = Expression.LessThan(propertyReferenceHigh, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetHigh >= ValueHigh)
      var BinaryExpression_ResourceHigh_IsHigherThanOrEqualTo_SearchHigh = Expression.GreaterThanOrEqual(propertyReferenceHigh, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetHigh >= ValueHigh)
      var BinaryExpression_ResourceHigh_IsHigherThan_SearchHigh = Expression.GreaterThan(propertyReferenceHigh, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetHigh <= ValueLow)
      var BinaryExpression_ResourceHigh_IsLowerThanOrEqualTo_SearchLow = Expression.LessThanOrEqual(propertyReferenceHigh, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetHigh < ValueLow)
      var BinaryExpression_ResourceHigh_IsLowerThan_SearchLow = Expression.LessThan(propertyReferenceHigh, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetHigh >= ValueLow)
      var BinaryExpression_ResourceHigh_IsHigherThanOrEqualTo_SearchLow = Expression.GreaterThanOrEqual(propertyReferenceHigh, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetHigh > ValueLow)
      var BinaryExpression_ResourceHigh_IsHigherThan_SearchLow = Expression.GreaterThan(propertyReferenceHigh, SearchValueReferenceLow);


      //BinaryExpression_A
      //(x.date_DateTimeOffsetLow == Null && x.date_DateTimeOffsetHigh >= ValueLow)
      var BinaryExpression_A = Expression.And(BinaryExpression_ResourceLow_IsNull, BinaryExpression_ResourceHigh_IsHigherThanOrEqualTo_SearchLow);

      //BinaryExpression_B
      //(x.date_DateTimeOffsetHigh == Null && x.date_DateTimeOffsetLow != Null)
      var BinaryExpression_B = Expression.And(BinaryExpression_ResourceHigh_IsNull, BinaryExpression_ResourceLow_IsNotNull);

      //BinaryExpression_C
      //(x.date_DateTimeOffsetLow >= ValueLow)


      //(BinaryExpression_A Or BinaryExpression_B) 
      var BinaryExpression_AA = Expression.Or(BinaryExpression_A, BinaryExpression_B);
      var BinaryExpression_Final = Expression.Or(BinaryExpression_AA, BinaryExpression_ResourceLow_IsHigherThanOrEqualTo_SearchLow);

      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DateTimePeriodPropertyLessThan(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");

      var propertyReferenceLow = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
      var propertyReferenceHigh = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);

      var SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
      var SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));
      var ConstantReferenceNull = Expression.Constant(null);

      //(x.date_DateTimeOffsetLow == Null)
      var BinaryExpression_ResourceLow_IsNull = Expression.Equal(propertyReferenceLow, ConstantReferenceNull);

      //(x.date_DateTimeOffsetLow != Null)
      var BinaryExpression_ResourceLow_IsNotNull = Expression.NotEqual(propertyReferenceLow, ConstantReferenceNull);


      //(x.date_DateTimeOffsetHigh == Null)
      var BinaryExpression_ResourceHigh_IsNull = Expression.Equal(propertyReferenceHigh, ConstantReferenceNull);

      //(x.date_DateTimeOffsetHigh != Null)
      var BinaryExpression_ResourceHigh_IsNotNull = Expression.NotEqual(propertyReferenceHigh, ConstantReferenceNull);


      //(x.date_DateTimeOffsetLow <= ValueLow)
      var BinaryExpression_ResourceLow_IsLowerThanOrEqual_SearchLow = Expression.LessThanOrEqual(propertyReferenceLow, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetLow < ValueLow)
      var BinaryExpression_ResourceLow_IsLowerThan_SearchLow = Expression.LessThan(propertyReferenceLow, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetLow >= ValueLow)
      var BinaryExpression_ResourceLow_IsHigherThanOrEqualTo_SearchLow = Expression.GreaterThanOrEqual(propertyReferenceLow, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetLow > ValueLow)
      var BinaryExpression_ResourceLow_IsHigherThan_SearchLow = Expression.GreaterThan(propertyReferenceLow, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetLow <= ValueHigh)
      var BinaryExpression_ResourceLow_IsLowerThanOrEqualTo_SearchHigh = Expression.LessThanOrEqual(propertyReferenceLow, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetLow < ValueHigh)
      var BinaryExpression_ResourceLow_IsLowerThan_SearchHigh = Expression.LessThan(propertyReferenceLow, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetLow >= ValueHigh)
      var BinaryExpression_ResourceLow_IsHigherThanOrEqualTo_SearchHigh = Expression.GreaterThanOrEqual(propertyReferenceLow, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetLow > ValueHigh)
      var BinaryExpression_ResourceLow_IsHigherThan_SearchHigh = Expression.GreaterThan(propertyReferenceLow, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetHigh <= ValueHigh)
      var BinaryExpression_ResourceHigh_IsLowerThanOrEqualTo_SearchHigh = Expression.LessThanOrEqual(propertyReferenceHigh, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetHigh < ValueHigh)
      var BinaryExpression_ResourceHigh_IsLowerThan_SearchHigh = Expression.LessThan(propertyReferenceHigh, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetHigh >= ValueHigh)
      var BinaryExpression_ResourceHigh_IsHigherThanOrEqualTo_SearchHigh = Expression.GreaterThanOrEqual(propertyReferenceHigh, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetHigh >= ValueHigh)
      var BinaryExpression_ResourceHigh_IsHigherThan_SearchHigh = Expression.GreaterThan(propertyReferenceHigh, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetHigh <= ValueLow)
      var BinaryExpression_ResourceHigh_IsLowerThanOrEqualTo_SearchLow = Expression.LessThanOrEqual(propertyReferenceHigh, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetHigh < ValueLow)
      var BinaryExpression_ResourceHigh_IsLowerThan_SearchLow = Expression.LessThan(propertyReferenceHigh, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetHigh >= ValueLow)
      var BinaryExpression_ResourceHigh_IsHigherThanOrEqualTo_SearchLow = Expression.GreaterThanOrEqual(propertyReferenceHigh, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetHigh > ValueLow)
      var BinaryExpression_ResourceHigh_IsHigherThan_SearchLow = Expression.GreaterThan(propertyReferenceHigh, SearchValueReferenceLow);


      //BinaryExpression_A
      //(x.date_DateTimeOffsetLow == Null && x.date_DateTimeOffsetHigh < ValueLow)
      var BinaryExpression_A = Expression.And(BinaryExpression_ResourceLow_IsNull, BinaryExpression_ResourceHigh_IsLowerThan_SearchLow);

      //BinaryExpression_B
      //(x.date_DateTimeOffsetHigh < ValueLow)
      var BinaryExpression_B = Expression.And(BinaryExpression_ResourceHigh_IsNull, BinaryExpression_ResourceLow_IsNotNull);


      //(BinaryExpression_A Or BinaryExpression_B) 
      var BinaryExpression_Final = Expression.Or(BinaryExpression_A, BinaryExpression_ResourceHigh_IsLowerThan_SearchLow);

      return Expression.Lambda<Func<T, bool>>(BinaryExpression_Final, new[] { ParameterReferance });
    }

    public Expression<Func<T, bool>> DateTimePeriodPropertyLessThanOrEqualTo(string Property, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {

      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");

      var propertyReferenceLow = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
      var propertyReferenceHigh = Expression.Property(ParameterReferance, Property + "_" + StaticDatabaseInfo.DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);

      var SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
      var SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));
      var ConstantReferenceNull = Expression.Constant(null);

      //(x.date_DateTimeOffsetLow == Null)
      var BinaryExpression_ResourceLow_IsNull = Expression.Equal(propertyReferenceLow, ConstantReferenceNull);

      //(x.date_DateTimeOffsetLow != Null)
      var BinaryExpression_ResourceLow_IsNotNull = Expression.NotEqual(propertyReferenceLow, ConstantReferenceNull);


      //(x.date_DateTimeOffsetHigh == Null)
      var BinaryExpression_ResourceHigh_IsNull = Expression.Equal(propertyReferenceHigh, ConstantReferenceNull);

      //(x.date_DateTimeOffsetHigh != Null)
      var BinaryExpression_ResourceHigh_IsNotNull = Expression.NotEqual(propertyReferenceHigh, ConstantReferenceNull);


      //(x.date_DateTimeOffsetLow <= ValueLow)
      var BinaryExpression_ResourceLow_IsLowerThanOrEqual_SearchLow = Expression.LessThanOrEqual(propertyReferenceLow, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetLow < ValueLow)
      var BinaryExpression_ResourceLow_IsLowerThan_SearchLow = Expression.LessThan(propertyReferenceLow, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetLow >= ValueLow)
      var BinaryExpression_ResourceLow_IsHigherThanOrEqualTo_SearchLow = Expression.GreaterThanOrEqual(propertyReferenceLow, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetLow > ValueLow)
      var BinaryExpression_ResourceLow_IsHigherThan_SearchLow = Expression.GreaterThan(propertyReferenceLow, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetLow <= ValueHigh)
      var BinaryExpression_ResourceLow_IsLowerThanOrEqualTo_SearchHigh = Expression.LessThanOrEqual(propertyReferenceLow, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetLow < ValueHigh)
      var BinaryExpression_ResourceLow_IsLowerThan_SearchHigh = Expression.LessThan(propertyReferenceLow, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetLow >= ValueHigh)
      var BinaryExpression_ResourceLow_IsHigherThanOrEqualTo_SearchHigh = Expression.GreaterThanOrEqual(propertyReferenceLow, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetLow > ValueHigh)
      var BinaryExpression_ResourceLow_IsHigherThan_SearchHigh = Expression.GreaterThan(propertyReferenceLow, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetHigh <= ValueHigh)
      var BinaryExpression_ResourceHigh_IsLowerThanOrEqualTo_SearchHigh = Expression.LessThanOrEqual(propertyReferenceHigh, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetHigh < ValueHigh)
      var BinaryExpression_ResourceHigh_IsLowerThan_SearchHigh = Expression.LessThan(propertyReferenceHigh, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetHigh >= ValueHigh)
      var BinaryExpression_ResourceHigh_IsHigherThanOrEqualTo_SearchHigh = Expression.GreaterThanOrEqual(propertyReferenceHigh, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetHigh >= ValueHigh)
      var BinaryExpression_ResourceHigh_IsHigherThan_SearchHigh = Expression.GreaterThan(propertyReferenceHigh, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetHigh <= ValueLow)
      var BinaryExpression_ResourceHigh_IsLowerThanOrEqualTo_SearchLow = Expression.LessThanOrEqual(propertyReferenceHigh, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetHigh < ValueLow)
      var BinaryExpression_ResourceHigh_IsLowerThan_SearchLow = Expression.LessThan(propertyReferenceHigh, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetHigh >= ValueLow)
      var BinaryExpression_ResourceHigh_IsHigherThanOrEqualTo_SearchLow = Expression.GreaterThanOrEqual(propertyReferenceHigh, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetHigh > ValueLow)
      var BinaryExpression_ResourceHigh_IsHigherThan_SearchLow = Expression.GreaterThan(propertyReferenceHigh, SearchValueReferenceLow);


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

      MethodInfo MethodCount = typeof(Enumerable).GetMethods().Where(m => m.Name == "Count" && m.GetParameters().Length == 1).Single().MakeGenericMethod(typeof(DateTimeIndex));

      ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
      MemberExpression CollectionProperty = Expression.Property(PatientParameter, typeof(T).GetProperty(DbPropertyName));
      MethodCallExpression MethodAnyCall = Expression.Call(MethodCount, CollectionProperty);
      ConstantExpression constantReference = Expression.Constant(0);
      BinaryExpression BinaryExpression = Expression.Equal(MethodAnyCall, constantReference);
      return Expression.Lambda<Func<T, bool>>(BinaryExpression, PatientParameter);
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
      Expression E_InnerExpression = DateTimePeriodEqualToExpression(Property, propertyReferenceLow, SearchValueLow, propertyReferenceHigh, SearchValueHigh);

      //Wrap Any Method Expression into Function
      Expression<Func<DateTimePeriodIndex, bool>> InnerFunction = Expression.Lambda<Func<DateTimePeriodIndex, bool>>(E_InnerExpression, PE_Inner);

      ParameterExpression PE_Outer = Expression.Parameter(typeof(T), "x");
      MemberExpression ME_CollectionProperty = Expression.Property(PE_Outer, typeof(T).GetProperty(DbPropertyName));

      //Call Any Method with Function
      MethodCallExpression MethodAnyCall = Expression.Call(ME_Any, ME_CollectionProperty, InnerFunction);

      //Wrap final expression into function
      return Expression.Lambda<Func<T, bool>>(MethodAnyCall, PE_Outer);
    }


    private static Expression DateTimePeriodEqualToExpression(
      string Property, 
      MemberExpression propertyReferenceLow,
      DateTimeOffset SearchValueLow,
      MemberExpression propertyReferenceHigh,
      DateTimeOffset SearchValueHigh)
    {
      
      var SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
      var SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));
      var ConstantReferenceNull = Expression.Constant(null);

      //(x.date_DateTimeOffsetLow == Null)
      var BinaryExpression_ResourceLow_IsNull = Expression.Equal(propertyReferenceLow, ConstantReferenceNull);

      //(x.date_DateTimeOffsetLow != Null)
      var BinaryExpression_ResourceLow_IsNotNull = Expression.NotEqual(propertyReferenceLow, ConstantReferenceNull);

      //(x.date_DateTimeOffsetHigh == Null)
      var BinaryExpression_ResourceHigh_IsNull = Expression.Equal(propertyReferenceHigh, ConstantReferenceNull);

      //(x.date_DateTimeOffsetHigh != Null)
      var BinaryExpression_ResourceHigh_IsNotNull = Expression.NotEqual(propertyReferenceHigh, ConstantReferenceNull);

      //(x.date_DateTimeOffsetLow <= ValueLow)
      var BinaryExpression_ResourceLow_IsLowerThanOrEqual_SearchLow = Expression.LessThanOrEqual(propertyReferenceLow, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetLow < ValueLow)
      var BinaryExpression_ResourceLow_IsLowerThan_SearchLow = Expression.LessThan(propertyReferenceLow, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetLow >= ValueLow)
      var BinaryExpression_ResourceLow_IsHigherThanOrEqualTo_SearchLow = Expression.GreaterThanOrEqual(propertyReferenceLow, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetLow > ValueLow)
      var BinaryExpression_ResourceLow_IsHigherThan_SearchLow = Expression.GreaterThan(propertyReferenceLow, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetLow <= ValueHigh)
      var BinaryExpression_ResourceLow_IsLowerThanOrEqualTo_SearchHigh = Expression.LessThanOrEqual(propertyReferenceLow, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetLow < ValueHigh)
      var BinaryExpression_ResourceLow_IsLowerThan_SearchHigh = Expression.LessThan(propertyReferenceLow, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetLow >= ValueHigh)
      var BinaryExpression_ResourceLow_IsHigherThanOrEqualTo_SearchHigh = Expression.GreaterThanOrEqual(propertyReferenceLow, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetLow > ValueHigh)
      var BinaryExpression_ResourceLow_IsHigherThan_SearchHigh = Expression.GreaterThan(propertyReferenceLow, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetHigh <= ValueHigh)
      var BinaryExpression_ResourceHigh_IsLowerThanOrEqualTo_SearchHigh = Expression.LessThanOrEqual(propertyReferenceHigh, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetHigh < ValueHigh)
      var BinaryExpression_ResourceHigh_IsLowerThan_SearchHigh = Expression.LessThan(propertyReferenceHigh, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetHigh >= ValueHigh)
      var BinaryExpression_ResourceHigh_IsHigherThanOrEqualTo_SearchHigh = Expression.GreaterThanOrEqual(propertyReferenceHigh, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetHigh >= ValueHigh)
      var BinaryExpression_ResourceHigh_IsHigherThan_SearchHigh = Expression.GreaterThan(propertyReferenceHigh, SearchValueReferenceHigh);

      //(x.date_DateTimeOffsetHigh <= ValueLow)
      var BinaryExpression_ResourceHigh_IsLowerThanOrEqualTo_SearchLow = Expression.LessThanOrEqual(propertyReferenceHigh, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetHigh < ValueLow)
      var BinaryExpression_ResourceHigh_IsLowerThan_SearchLow = Expression.LessThan(propertyReferenceHigh, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetHigh >= ValueLow)
      var BinaryExpression_ResourceHigh_IsHigherThanOrEqualTo_SearchLow = Expression.GreaterThanOrEqual(propertyReferenceHigh, SearchValueReferenceLow);

      //(x.date_DateTimeOffsetHigh > ValueLow)
      var BinaryExpression_ResourceHigh_IsHigherThan_SearchLow = Expression.GreaterThan(propertyReferenceHigh, SearchValueReferenceLow);




      //BinaryExpression_A
      //(x.date_DateTimeOffsetHigh == Null && x.date_DateTimeOffsetLow <= ValueHigh)
      var BinaryExpression_A = Expression.And(BinaryExpression_ResourceHigh_IsNull, BinaryExpression_ResourceLow_IsLowerThanOrEqualTo_SearchHigh);

      //BinaryExpression_B
      //(x.date_DateTimeOffsetLow == Null && x.date_DateTimeOffsetHigh >= ValueLow)
      var BinaryExpression_B = Expression.And(BinaryExpression_ResourceHigh_IsNull, BinaryExpression_ResourceHigh_IsHigherThanOrEqualTo_SearchLow);

      //BinaryExpression_C
      //(x.date_DateTimeOffsetLow >= ValueLow && x.date_DateTimeOffsetLow <= ValueHigh )
      var BinaryExpression_C = Expression.And(BinaryExpression_ResourceLow_IsHigherThanOrEqualTo_SearchLow, BinaryExpression_ResourceLow_IsLowerThanOrEqualTo_SearchHigh);

      //BinaryExpression_D
      //(x.date_DateTimeOffsetHigh >= ValueLow && x.date_DateTimeOffsetHigh <= ValueHigh )
      var BinaryExpression_D = Expression.And(BinaryExpression_ResourceHigh_IsHigherThanOrEqualTo_SearchLow, BinaryExpression_ResourceHigh_IsLowerThanOrEqualTo_SearchHigh);


      //(BinaryExpression_A Or BinaryExpression_B) Or (BinaryExpression_C Or BinaryExpression_D)
      var BinaryExpression_AA = Expression.Or(BinaryExpression_A, BinaryExpression_B);
      var BinaryExpression_BB = Expression.Or(BinaryExpression_C, BinaryExpression_D);




      Expression BinaryExpression_Final = Expression.Or(BinaryExpression_AA, BinaryExpression_BB);
      return BinaryExpression_Final;
    }


  }

}

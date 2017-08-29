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
  public class ResourceSearch<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
  {

    public Expression<Func<ResourceCurrentBaseType, bool>> StringCollectionAnyEqualTo(int Id, string Value)
    {
      //(x => x.IndexList.Any(c => c.String.Equals("héllo UPPER") & c.ServiceSearchParameterId == Id);      
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexStringType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResourceCurrentBaseType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression InnerPropertyString = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.String);
      ConstantExpression InnerValueString = Expression.Constant(StringSupport.ToLowerAndRemoveDiacritics(Value.Trim()));
      MethodInfo MethodEquals = typeof(String).GetMethods().Where(m => m.Name == "Equals" && m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == typeof(String)).Single();
      MethodCallExpression MethodEqualsCall = Expression.Call(InnerPropertyString, MethodEquals, InnerValueString);

      BinaryExpression IdAndExpression = Expression.And(BinaryExpressionIdEquals, MethodEqualsCall);

      Expression<Func<ResourceIndexStringType, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexStringType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexStringListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResourceCurrentBaseType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResourceCurrentBaseType, bool>> StringCollectionAnyStartsOrEndsWith(int Id, string Value)
    {
      //(x => x.IndexList.Any(c => c.String.StartsWith("Mill") & c.ServiceSearchParameterId == Id);
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexStringType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResourceCurrentBaseType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression InnerPropertyString = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.String);
      ConstantExpression InnerValueString = Expression.Constant(StringSupport.ToLowerAndRemoveDiacritics(Value.Trim()));

      MethodInfo MethodStartsWith = typeof(String).GetMethods().Where(m => m.Name == "StartsWith" && m.GetParameters().Length == 1).Single();
      MethodCallExpression MethodStartsWithCall = Expression.Call(InnerPropertyString, MethodStartsWith, InnerValueString);

      MethodInfo MethodEndsWith = typeof(String).GetMethods().Where(m => m.Name == "EndsWith" && m.GetParameters().Length == 1).Single();
      MethodCallExpression MethodEndsWithCall = Expression.Call(InnerPropertyString, MethodEndsWith, InnerValueString);

      var StartsWithOrEndsWithExpression = Expression.OrElse(MethodStartsWithCall, MethodEndsWithCall);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, StartsWithOrEndsWithExpression);

      Expression<Func<ResourceIndexStringType, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexStringType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexStringListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResourceCurrentBaseType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResourceCurrentBaseType, bool>> StringCollectionAnyContains(int Id, string Value)
    {
      //(x => x.IndexList.Any(c => c.String.Contains("Mill") & c.ServiceSearchParameterId == Id);
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexStringType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResourceCurrentBaseType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression InnerPropertyString = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.String);
      ConstantExpression InnerValueString = Expression.Constant(StringSupport.ToLowerAndRemoveDiacritics(Value.Trim()));

      MethodInfo MethodContains = typeof(String).GetMethods().Where(m => m.Name == "Contains" && m.GetParameters().Length == 1).Single();
      MethodCallExpression MethodContainsCall = Expression.Call(InnerPropertyString, MethodContains, InnerValueString);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, MethodContainsCall);

      Expression<Func<ResourceIndexStringType, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexStringType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexStringListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResourceCurrentBaseType, bool>>(MethodAnyCall, IndexListParameter);
    }

    ////---- _lastUpdated Property Expressions ------------------------------------------------------

    public Expression<Func<ResourceCurrentBaseType, bool>> LastUpdatedPropertyGreaterThan(DateTimeOffset Value)
    {
      //(x => x.birthdate_DateTimeOffset > TestDate);
      ParameterExpression MainParameter = Expression.Parameter(typeof(ResourceCurrentBaseType), "x");
      string DbPropertyName = StaticDatabaseInfo.BaseResourceConstatnts.LastUpdated;
      MemberExpression LastUpdatedProperty = Expression.Property(MainParameter, typeof(ResourceCurrentBaseType).GetProperty(DbPropertyName));
      var constantReference = Expression.Constant(Value, typeof(DateTimeOffset));
      var BinaryExpression = Expression.GreaterThan(LastUpdatedProperty, constantReference);
      return Expression.Lambda<Func<ResourceCurrentBaseType, bool>>(BinaryExpression, new[] { MainParameter });
    }

    public Expression<Func<ResourceCurrentBaseType, bool>> LastUpdatedPropertyGreaterThanOrEqualTo(DateTimeOffset Value)
    {
      //(x => x.birthdate_DateTimeOffset >= TestDate);
      ParameterExpression MainParameter = Expression.Parameter(typeof(ResourceCurrentBaseType), "x");
      string DbPropertyName = StaticDatabaseInfo.BaseResourceConstatnts.LastUpdated;
      MemberExpression LastUpdatedProperty = Expression.Property(MainParameter, typeof(ResourceCurrentBaseType).GetProperty(DbPropertyName));
      var constantReference = Expression.Constant(Value, typeof(DateTimeOffset));
      var BinaryExpression = Expression.GreaterThanOrEqual(LastUpdatedProperty, constantReference);
      return Expression.Lambda<Func<ResourceCurrentBaseType, bool>>(BinaryExpression, new[] { MainParameter });
    }

    public Expression<Func<ResourceCurrentBaseType, bool>> LastUpdatedPropertyLessThan(DateTimeOffset Value)
    {
      //(x => x.birthdate_DateTimeOffset < TestDate);
      ParameterExpression MainParameter = Expression.Parameter(typeof(ResourceCurrentBaseType), "x");
      string DbPropertyName = StaticDatabaseInfo.BaseResourceConstatnts.LastUpdated;
      MemberExpression LastUpdatedProperty = Expression.Property(MainParameter, typeof(ResourceCurrentBaseType).GetProperty(DbPropertyName));
      var constantReference = Expression.Constant(Value, typeof(DateTimeOffset));
      var BinaryExpression = Expression.LessThan(LastUpdatedProperty, constantReference);
      return Expression.Lambda<Func<ResourceCurrentBaseType, bool>>(BinaryExpression, new[] { MainParameter });
    }

    public Expression<Func<ResourceCurrentBaseType, bool>> LastUpdatedPropertyLessThanOrEqualTo(DateTimeOffset Value)
    {
      //(x => x.birthdate_DateTimeOffset <= TestDate);
      ParameterExpression MainParameter = Expression.Parameter(typeof(ResourceCurrentBaseType), "x");
      string DbPropertyName = StaticDatabaseInfo.BaseResourceConstatnts.LastUpdated;
      MemberExpression LastUpdatedProperty = Expression.Property(MainParameter, typeof(ResourceCurrentBaseType).GetProperty(DbPropertyName));
      var constantReference = Expression.Constant(Value, typeof(DateTimeOffset));
      var BinaryExpression = Expression.LessThanOrEqual(LastUpdatedProperty, constantReference);
      return Expression.Lambda<Func<ResourceCurrentBaseType, bool>>(BinaryExpression, new[] { MainParameter });
    }

    public Expression<Func<ResourceCurrentBaseType, bool>> DateTimePeriodCollectionAnyEqualTo(int Id, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBaseType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResourceCurrentBaseType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression propertyReferenceLow = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetLow);
      MemberExpression propertyReferenceHigh = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetHigh);

      ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

      //Build Inner Expression
      Expression EqualToExpression = ExpressionSupport.DateTimePeriodExpression.EqualToExpression(propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, EqualToExpression);

      Expression<Func<ResourceIndexBaseType, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBaseType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResourceCurrentBaseType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResourceCurrentBaseType, bool>> DateTimePeriodCollectionAnyNotEqualTo(int Id, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBaseType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResourceCurrentBaseType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression propertyReferenceLow = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetLow);
      MemberExpression propertyReferenceHigh = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetHigh);

      ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

      //Build Inner Expression
      Expression NotEqualToExpression = ExpressionSupport.DateTimePeriodExpression.NotEqualToExpression(propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, NotEqualToExpression);

      Expression<Func<ResourceIndexBaseType, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBaseType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResourceCurrentBaseType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResourceCurrentBaseType, bool>> DateTimePeriodCollectionGreaterThanOrEqualTo(int Id, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBaseType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResourceCurrentBaseType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression propertyReferenceLow = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetLow);
      MemberExpression propertyReferenceHigh = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetHigh);

      ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

      //Build Inner Expression
      Expression GreaterThanOrEqualToExpression = ExpressionSupport.DateTimePeriodExpression.GreaterThanOrEqualToExpression(propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, GreaterThanOrEqualToExpression);

      Expression<Func<ResourceIndexBaseType, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBaseType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResourceCurrentBaseType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResourceCurrentBaseType, bool>> DateTimePeriodCollectionGreaterThan(int Id, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBaseType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResourceCurrentBaseType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression propertyReferenceLow = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetLow);
      MemberExpression propertyReferenceHigh = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetHigh);

      ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

      //Build Inner Expression
      Expression GreaterThanExpression = ExpressionSupport.DateTimePeriodExpression.GreaterThanExpression(propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, GreaterThanExpression);

      Expression<Func<ResourceIndexBaseType, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBaseType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResourceCurrentBaseType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResourceCurrentBaseType, bool>> DateTimePeriodCollectionLessThan(int Id, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBaseType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResourceCurrentBaseType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression propertyReferenceLow = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetLow);
      MemberExpression propertyReferenceHigh = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetHigh);

      ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

      //Build Inner Expression
      Expression LessThanExpression = ExpressionSupport.DateTimePeriodExpression.LessThanExpression(propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, LessThanExpression);

      Expression<Func<ResourceIndexBaseType, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBaseType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResourceCurrentBaseType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResourceCurrentBaseType, bool>> DateTimePeriodCollectionLessThanOrEqualTo(int Id, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBaseType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResourceCurrentBaseType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression propertyReferenceLow = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetLow);
      MemberExpression propertyReferenceHigh = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetHigh);

      ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

      //Build Inner Expression
      Expression LessThanOrEqualToExpression = ExpressionSupport.DateTimePeriodExpression.LessThanOrEqualToExpression(propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, LessThanOrEqualToExpression);

      Expression<Func<ResourceIndexBaseType, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBaseType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResourceCurrentBaseType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResourceCurrentBaseType, bool>> TokenMainAnyEqualTo(string Code)
    {
      ParameterExpression MainParameter = Expression.Parameter(typeof(ResourceCurrentBaseType), "x");

      string DbPropertyName = StaticDatabaseInfo.BaseResourceConstatnts.FhirId;
      MemberExpression FhirIdProperty = Expression.Property(MainParameter, typeof(ResourceCurrentBaseType).GetProperty(DbPropertyName));

      ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);
      Expression E_InnerExpression = ExpressionSupport.TokenExpression.MatchCodeOnlyExpression(FhirIdProperty, SearchValueReferenceCode);

      return Expression.Lambda<Func<ResourceCurrentBaseType, bool>>(E_InnerExpression, new[] { MainParameter });
    }

    public Expression<Func<ResourceCurrentBaseType, bool>> TokenCollectionAnyEqualTo(int Id, string Code, string System, Common.Search.SearchParameterTokenValue.TokenSearchType TokenSearchType)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBaseType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResourceCurrentBaseType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression propertyReferenceCode = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Code);
      MemberExpression propertyReferenceSystem = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.System);
      ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);
      ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);

      //Build Inner Expression
      Expression E_InnerExpression = null;
      switch (TokenSearchType)
      {
        case Common.Search.SearchParameterTokenValue.TokenSearchType.None:
          throw new Exception("Server error: DtoSearchParameterTokenValue.TokenSearchType was set to None.");
        case Common.Search.SearchParameterTokenValue.TokenSearchType.MatchCodeOnly:
          E_InnerExpression = ExpressionSupport.TokenExpression.MatchCodeOnlyExpression(propertyReferenceCode, SearchValueReferenceCode);
          break;
        case Common.Search.SearchParameterTokenValue.TokenSearchType.MatchSystemOnly:
          E_InnerExpression = ExpressionSupport.TokenExpression.MatchSystemOnlyExpression(propertyReferenceSystem, SearchValueReferenceSystem);
          break;
        case Common.Search.SearchParameterTokenValue.TokenSearchType.MatchCodeAndSystem:
          E_InnerExpression = ExpressionSupport.TokenExpression.MatchCodeAndSystemExpression(propertyReferenceCode, SearchValueReferenceCode, propertyReferenceSystem, SearchValueReferenceSystem);
          break;
        case Common.Search.SearchParameterTokenValue.TokenSearchType.MatchCodeWithNullSystem:
          E_InnerExpression = ExpressionSupport.TokenExpression.MatchCodeWithNullSystemExpression(propertyReferenceCode, SearchValueReferenceCode, propertyReferenceSystem);
          break;
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(TokenSearchType.ToString(), (int)TokenSearchType, typeof(Common.Search.SearchParameterTokenValue.TokenSearchType));
      }

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, E_InnerExpression);

      Expression<Func<ResourceIndexBaseType, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBaseType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResourceCurrentBaseType, bool>>(MethodAnyCall, IndexListParameter);
    }

    ////---- Number Index Expressions ------------------------------------------------------
    public Expression<Func<ResourceCurrentBaseType, bool>> NumberCollectionAnyEqualTo(int Id, decimal LowNumber, decimal MidNumber, decimal HighNumber)
    {
      return NumberCollectionAllEqual(Id, LowNumber, MidNumber, HighNumber, Hl7.Fhir.Model.SearchParameter.SearchComparator.Eq);
    }

    public Expression<Func<ResourceCurrentBaseType, bool>> NumberCollectionAllNotEqualTo(int Id, decimal LowNumber, decimal MidNumber, decimal HighNumber)
    {
      return NumberCollectionAllEqual(Id, LowNumber, MidNumber, HighNumber, Hl7.Fhir.Model.SearchParameter.SearchComparator.Ne);
    }

    private Expression<Func<ResourceCurrentBaseType, bool>> NumberCollectionAllEqual(int Id, decimal LowNumber, decimal MidNumber, decimal HighNumber, Hl7.Fhir.Model.SearchParameter.SearchComparator SearchComparator)
    {
      if (SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Eq || SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Ne)
      {
        ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBaseType), "c");
        ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResourceCurrentBaseType), "x");

        BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

        MemberExpression propertyReferenceComparator = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Comparator);
        MemberExpression propertyReferenceNumber = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Quantity);

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

        Expression<Func<ResourceIndexBaseType, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBaseType, bool>>(IdAndExpression, InnerParameter);

        MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
        return Expression.Lambda<Func<ResourceCurrentBaseType, bool>>(MethodAnyCall, IndexListParameter);
      }
      else
      {
        throw new FormatException($"SearchParameter.SearchComparator must be Eq or Ne, found: {SearchComparator.ToString()}");
      }
    }

    public Expression<Func<ResourceCurrentBaseType, bool>> NumberCollectionAnyGreaterThan(int Id, decimal MidNumber)
    {
      return NumberCollectionComparator(Id, MidNumber, Hl7.Fhir.Model.SearchParameter.SearchComparator.Gt);
    }

    public Expression<Func<ResourceCurrentBaseType, bool>> NumberCollectionAnyGreaterThanOrEqualTo(int Id, decimal MidNumber)
    {
      return NumberCollectionComparator(Id, MidNumber, Hl7.Fhir.Model.SearchParameter.SearchComparator.Ge);
    }

    public Expression<Func<ResourceCurrentBaseType, bool>> NumberCollectionAnyLessThan(int Id, decimal MidNumber)
    {
      return NumberCollectionComparator(Id, MidNumber, Hl7.Fhir.Model.SearchParameter.SearchComparator.Lt);
    }

    public Expression<Func<ResourceCurrentBaseType, bool>> NumberCollectionAnyLessThanOrEqualTo(int Id, decimal MidNumber)
    {
      return NumberCollectionComparator(Id, MidNumber, Hl7.Fhir.Model.SearchParameter.SearchComparator.Le);
    }

    private Expression<Func<ResourceCurrentBaseType, bool>> NumberCollectionComparator(int Id, decimal MidNumber, Hl7.Fhir.Model.SearchParameter.SearchComparator SearchComparator)
    {
      if (SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Gt ||
          SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Ge ||
          SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Lt ||
          SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Le)
      {
        ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBaseType), "c");
        ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResourceCurrentBaseType), "x");

        BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

        MemberExpression propertyReferenceComparator = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Comparator);
        MemberExpression propertyReferenceNumber = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Quantity);

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

        Expression<Func<ResourceIndexBaseType, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBaseType, bool>>(IdAndExpression, InnerParameter);

        MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
        return Expression.Lambda<Func<ResourceCurrentBaseType, bool>>(MethodAnyCall, IndexListParameter);
      }
      else
      {
        throw new FormatException($"SearchParameter.SearchComparator must be Gt, Ge, Lt or Le, found: {SearchComparator.ToString()}");
      }
    }

    ////---- Quantity Index Expressions ------------------------------------------------------

    public Expression<Func<ResourceCurrentBaseType, bool>> QuantityCollectionAnyEqualTo(int Id, decimal LowNumber, decimal MidNumber, decimal HighNumber, string System, string Code)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBaseType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResourceCurrentBaseType), "x");

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
      Expression EqualToExpression = ExpressionSupport.DecimalExpression.EqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceLow, SearchValueReferenceMid, SearchValueReferenceHigh);
      Expression SystemCodeOrUnit_EqualTo_Expression = ExpressionSupport.QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(propertyReferenceSystem, propertyReferenceCode, propertyReferenceUnit, SearchValueReferenceSystem, SearchValueReferenceCode);
      Expression Final_InnerExpression = Expression.AndAlso(EqualToExpression, SystemCodeOrUnit_EqualTo_Expression);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, Final_InnerExpression);

      Expression<Func<ResourceIndexBaseType, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBaseType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResourceCurrentBaseType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResourceCurrentBaseType, bool>> QuantityCollectionAllNotEqualTo(int Id, decimal LowNumber, decimal MidNumber, decimal HighNumber, string System, string Code)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBaseType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResourceCurrentBaseType), "x");

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
      Expression NotEqualToExpression = ExpressionSupport.DecimalExpression.NotEqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceLow, SearchValueReferenceMid, SearchValueReferenceHigh);
      Expression SystemCodeOrUnit_NotEqualTo_Expression = ExpressionSupport.QuantityExpression.SystemCodeOrUnit_NotEqualTo_Expression(propertyReferenceSystem, propertyReferenceCode, propertyReferenceUnit, SearchValueReferenceSystem, SearchValueReferenceCode);
      Expression Final_InnerExpression = Expression.OrElse(NotEqualToExpression, SystemCodeOrUnit_NotEqualTo_Expression);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, Final_InnerExpression);

      Expression<Func<ResourceIndexBaseType, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBaseType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResourceCurrentBaseType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResourceCurrentBaseType, bool>> QuantityCollectionAnyGreaterThan(int Id, decimal MidNumber, string System, string Code)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBaseType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResourceCurrentBaseType), "x");

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
      Expression GreaterThanExpression = ExpressionSupport.DecimalExpression.GreaterThanExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);
      Expression SystemCodeOrUnit_EqualTo_Expression = ExpressionSupport.QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(propertyReferenceSystem, propertyReferenceCode, propertyReferenceUnit, SearchValueReferenceSystem, SearchValueReferenceCode);
      Expression Final_InnerExpression = Expression.AndAlso(GreaterThanExpression, SystemCodeOrUnit_EqualTo_Expression);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, Final_InnerExpression);

      Expression<Func<ResourceIndexBaseType, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBaseType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResourceCurrentBaseType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResourceCurrentBaseType, bool>> QuantityCollectionAnyGreaterThanOrEqualTo(int Id, decimal MidNumber, string System, string Code)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBaseType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResourceCurrentBaseType), "x");

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
      Expression GreaterThanOrEqualToExpression = ExpressionSupport.DecimalExpression.GreaterThanOrEqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);
      Expression SystemCodeOrUnit_EqualTo_Expression = ExpressionSupport.QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(propertyReferenceSystem, propertyReferenceCode, propertyReferenceUnit, SearchValueReferenceSystem, SearchValueReferenceCode);
      Expression Final_InnerExpression = Expression.AndAlso(GreaterThanOrEqualToExpression, SystemCodeOrUnit_EqualTo_Expression);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, Final_InnerExpression);

      Expression<Func<ResourceIndexBaseType, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBaseType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResourceCurrentBaseType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResourceCurrentBaseType, bool>> QuantityCollectionAnyLessThan(int Id, decimal MidNumber, string System, string Code)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBaseType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResourceCurrentBaseType), "x");

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
      Expression LessThanExpression = ExpressionSupport.DecimalExpression.LessThanExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);
      Expression SystemCodeOrUnit_EqualTo_Expression = ExpressionSupport.QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(propertyReferenceSystem, propertyReferenceCode, propertyReferenceUnit, SearchValueReferenceSystem, SearchValueReferenceCode);
      Expression Final_InnerExpression = Expression.AndAlso(LessThanExpression, SystemCodeOrUnit_EqualTo_Expression);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, Final_InnerExpression);

      Expression<Func<ResourceIndexBaseType, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBaseType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResourceCurrentBaseType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResourceCurrentBaseType, bool>> QuantityCollectionAnyLessThanOrEqualTo(int Id, decimal MidNumber, string System, string Code)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBaseType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResourceCurrentBaseType), "x");

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
      Expression LessThanOrEqualToExpression = ExpressionSupport.DecimalExpression.LessThanOrEqualToExpression(propertyReferenceComparator, propertyReferenceNumber, SearchValueReferenceMid);
      Expression SystemCodeOrUnit_EqualTo_Expression = ExpressionSupport.QuantityExpression.SystemCodeOrUnit_EqualTo_Expression(propertyReferenceSystem, propertyReferenceCode, propertyReferenceUnit, SearchValueReferenceSystem, SearchValueReferenceCode);
      Expression Final_InnerExpression = Expression.AndAlso(LessThanOrEqualToExpression, SystemCodeOrUnit_EqualTo_Expression);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, Final_InnerExpression);

      Expression<Func<ResourceIndexBaseType, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBaseType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResourceCurrentBaseType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResourceCurrentBaseType, bool>> UriCollectionAnyEqualTo(int Id, string Value)
    {
      //(x => x.IndexList.Any(c => c.String.StartsWith("Mill") & c.ServiceSearchParameterId == Id);
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBaseType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResourceCurrentBaseType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Uri);
      ConstantExpression InnerValue = Expression.Constant(Value);

      MethodInfo MethodEquals = typeof(string).GetMethods().Where(m => m.Name == "Equals" && m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == typeof(string)).Single();
      MethodCallExpression MethodEqualsCall = Expression.Call(InnerProperty, MethodEquals, InnerValue);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, MethodEqualsCall);

      Expression<Func<ResourceIndexBaseType, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBaseType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResourceCurrentBaseType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResourceCurrentBaseType, bool>> UriCollectionAnyContains(int Id, string Value)
    {
      //(x => x.IndexList.Any(c => c.String.Contains("myserver.net.au/stu3/api/Patient/1") & c.ServiceSearchParameterId == Id);
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBaseType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResourceCurrentBaseType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Uri);
      ConstantExpression InnerValue = Expression.Constant(Value);

      MethodInfo MethodContains = typeof(string).GetMethods().Where(m => m.Name == "Contains" && m.GetParameters().Length == 1).Single();

      MethodCallExpression MethodEqualsCall = Expression.Call(InnerProperty, MethodContains, InnerValue);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, MethodEqualsCall);

      Expression<Func<ResourceIndexBaseType, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBaseType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResourceCurrentBaseType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResourceCurrentBaseType, bool>> UriCollectionAnyStartsWith(int Id, string Value)
    {
      //(x => x.IndexList.Any(c => c.String.StartsWith("myserver.net.au/stu3/api/Patient/1") & c.ServiceSearchParameterId == Id);
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBaseType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResourceCurrentBaseType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Uri);
      ConstantExpression InnerValue = Expression.Constant(Value);

      MethodInfo MethodStartsWith = typeof(string).GetMethods().Where(m => m.Name == "StartsWith" && m.GetParameters().Length == 1).Single();

      MethodCallExpression MethodEqualsCall = Expression.Call(InnerProperty, MethodStartsWith, InnerValue);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, MethodEqualsCall);

      Expression<Func<ResourceIndexBaseType, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBaseType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResourceCurrentBaseType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResourceCurrentBaseType, bool>> UriCollectionAnyEndsWith(int Id, string Value)
    {
      //(x => x.IndexList.Any(c => c.String.EndsWith("myserver.net.au/stu3/api/Patient/1") & c.ServiceSearchParameterId == Id);
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBaseType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResourceCurrentBaseType), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Uri);
      ConstantExpression InnerValue = Expression.Constant(Value);

      MethodInfo MethodEndsWith = typeof(string).GetMethods().Where(m => m.Name == "EndsWith" && m.GetParameters().Length == 1).Single();

      MethodCallExpression MethodEqualsCall = Expression.Call(InnerProperty, MethodEndsWith, InnerValue);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, MethodEqualsCall);

      Expression<Func<ResourceIndexBaseType, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBaseType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResourceCurrentBaseType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResourceCurrentBaseType, bool>> ReferanceCollectionAnyEqualTo_ByKey(int Id, int ServiceBaseUrlId, string ResourceType, string FhirId, string VersionId)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBaseType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResourceCurrentBaseType), "x");

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

      Expression<Func<ResourceIndexBaseType, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBaseType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResourceCurrentBaseType, bool>>(MethodAnyCall, IndexListParameter);

    }

    public Expression<Func<ResourceCurrentBaseType, bool>> ReferanceCollectionAnyEqualTo_ByUrlString(int Id, string UrlString, string ResourceType, string FhirId, string VersionId)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBaseType), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResourceCurrentBaseType), "x");

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

      Expression<Func<ResourceIndexBaseType, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBaseType, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<ResourceCurrentBaseType, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<ResourceCurrentBaseType, bool>> ReferanceCollectionIsNotNull(int Id)
    {
      //(x => x.IndexList.Any(c => c.ServiceSearchParameterId == Id) == false);      
      return SearchParameterIdNull(Id, false);
    }

    public Expression<Func<ResourceCurrentBaseType, bool>> ReferanceCollectionIsNull(int Id)
    {
      //(x => x.IndexList.Any(c => c.ServiceSearchParameterId == Id) == true);      
      return SearchParameterIdNull(Id, true);
    }

    ////---- QuantityRange Index Expressions ------------------------------------------------------

    ////Not implemented as there are no QuantityRange search parameters as yet in FHIR spec, as of this early STU3 release


    ///---- General Index Expressions ------------------------------------------------------

    private BinaryExpression SearchParameterIdBinaryExpression(int Id, ParameterExpression InnerParameter)
    {
      MemberExpression InnerPropertyId = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.ServiceSearchParameterId);
      ConstantExpression InnerValueId = Expression.Constant(Id);
      return Expression.Equal(InnerPropertyId, InnerValueId);
    }

    private MethodCallExpression IndexListAnyMethodCallExpression(ParameterExpression IndexListParameter, Expression<Func<ResourceIndexBaseType, bool>> InnerFunction)
    {
      var type = typeof(ResourceCurrentBaseType);
      string DbPropertyName = StaticDatabaseInfo.BaseResourceConstatnts.IndexList;
      MemberExpression IndexListProperty = Expression.Property(IndexListParameter, typeof(ResourceCurrentBaseType).GetProperty(DbPropertyName));
      MethodInfo MethodAny = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(ResourceIndexBaseType));
      MethodCallExpression MethodAnyCall = Expression.Call(MethodAny, IndexListProperty, InnerFunction);
      return MethodAnyCall;
    }

    private MethodCallExpression IndexStringListAnyMethodCallExpression(ParameterExpression IndexListParameter, Expression<Func<ResourceIndexStringType, bool>> InnerFunction)
    {
      var type = typeof(ResourceCurrentBaseType);
      string DbPropertyName = StaticDatabaseInfo.BaseResourceConstatnts.IndexStringList;
      MemberExpression IndexListProperty = Expression.Property(IndexListParameter, typeof(ResourceCurrentBaseType).GetProperty(DbPropertyName));
      MethodInfo MethodAny = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(ResourceIndexStringType));
      MethodCallExpression MethodAnyCall = Expression.Call(MethodAny, IndexListProperty, InnerFunction);
      return MethodAnyCall;
    }


    public Expression<Func<ResourceCurrentBaseType, bool>> SearchParameterIdIsNotNull(int Id)
    {
      //(x => x.IndexList.Any(c => c.ServiceSearchParameterId == Id).Count > 0);      
      return SearchParameterIdNull(Id, false);
    }

    public Expression<Func<ResourceCurrentBaseType, bool>> SearchParameterIsNull(int Id)
    {
      //(x => x.IndexList.Any(c => c.ServiceSearchParameterId == Id).Count == 0);      
      return SearchParameterIdNull(Id, true);
    }

    private Expression<Func<ResourceCurrentBaseType, bool>> SearchParameterIdNull(int Id, bool IsNull)
    {
      //IsNull = true
      //(x => x.IndexList.Any(c => c.ServiceSearchParameterId == Id) == true);      
      //IsNull = false
      //(x => x.IndexList.Any(c => c.ServiceSearchParameterId == Id) == false);                  
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(ResourceCurrentBaseType), "x");
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ResourceIndexBaseType), "c");

      BinaryExpression BinaryIdExpression = SearchParameterIdBinaryExpression(Id, InnerParameter);

      Expression<Func<ResourceIndexBaseType, bool>> InnerFunction = Expression.Lambda<Func<ResourceIndexBaseType, bool>>(BinaryIdExpression, InnerParameter);

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

      return Expression.Lambda<Func<ResourceCurrentBaseType, bool>>(BinaryExpression, IndexListParameter);
    }
  }

}

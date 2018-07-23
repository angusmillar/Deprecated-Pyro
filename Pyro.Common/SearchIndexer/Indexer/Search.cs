using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Database;
using Pyro.Common.Tools;
using System.Linq.Expressions;
using System.Reflection;
using Pyro.Common.Search.SearchParameterEntity;
using Pyro.Common.SearchIndexer.Index;

namespace Pyro.Common.SearchIndexer.Indexer
{
  public class Search<IResourceIndexed>
  {

    ////---- String Property Expressions ------------------------------------------------------
    public Expression<Func<IResourceIndexed, bool>> StringCollectionAnyEqualTo(int Id, string Value)
    {      
      ParameterExpression InnerParameter = Expression.Parameter(typeof(IStringIndex), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(IResourceIndexed), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression InnerPropertyString = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.String);
      ConstantExpression InnerValueString = Expression.Constant(StringSupport.ToLowerAndRemoveDiacritics(Value.Trim()));
      MethodInfo MethodEquals = typeof(String).GetMethods().Where(m => m.Name == "Equals" && m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == typeof(String)).Single();
      MethodCallExpression MethodEqualsCall = Expression.Call(InnerPropertyString, MethodEquals, InnerValueString);

      BinaryExpression IdAndExpression = Expression.And(BinaryExpressionIdEquals, MethodEqualsCall);

      Expression<Func<IStringIndex, bool>> InnerFunction = Expression.Lambda<Func<IStringIndex, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<IResourceIndexed, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<IResourceIndexed, bool>> StringCollectionAnyStartsOrEndsWith(int Id, string Value)
    {
      //(x => x.IndexList.Any(c => c.String.StartsWith("Mill") & c.ServiceSearchParameterId == Id);
      ParameterExpression InnerParameter = Expression.Parameter(typeof(IStringIndex), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(IResourceIndexed), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression InnerPropertyString = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.String);
      ConstantExpression InnerValueString = Expression.Constant(StringSupport.ToLowerAndRemoveDiacritics(Value.Trim()));

      MethodInfo MethodStartsWith = typeof(String).GetMethods().Where(m => m.Name == "StartsWith" && m.GetParameters().Length == 1).Single();
      MethodCallExpression MethodStartsWithCall = Expression.Call(InnerPropertyString, MethodStartsWith, InnerValueString);

      MethodInfo MethodEndsWith = typeof(String).GetMethods().Where(m => m.Name == "EndsWith" && m.GetParameters().Length == 1).Single();
      MethodCallExpression MethodEndsWithCall = Expression.Call(InnerPropertyString, MethodEndsWith, InnerValueString);

      var StartsWithOrEndsWithExpression = Expression.OrElse(MethodStartsWithCall, MethodEndsWithCall);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, StartsWithOrEndsWithExpression);

      Expression<Func<IStringIndex, bool>> InnerFunction = Expression.Lambda<Func<IStringIndex, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      //MethodCallExpression MethodAnyCall = IndexStringListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<IResourceIndexed, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<IResourceIndexed, bool>> StringCollectionAnyContains(int Id, string Value)
    {
      //(x => x.IndexList.Any(c => c.String.Contains("Mill") & c.ServiceSearchParameterId == Id);
      ParameterExpression InnerParameter = Expression.Parameter(typeof(IStringIndex), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(IResourceIndexed), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression InnerPropertyString = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.String);
      ConstantExpression InnerValueString = Expression.Constant(StringSupport.ToLowerAndRemoveDiacritics(Value.Trim()));

      MethodInfo MethodContains = typeof(String).GetMethods().Where(m => m.Name == "Contains" && m.GetParameters().Length == 1).Single();
      MethodCallExpression MethodContainsCall = Expression.Call(InnerPropertyString, MethodContains, InnerValueString);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, MethodContainsCall);

      Expression<Func<IStringIndex, bool>> InnerFunction = Expression.Lambda<Func<IStringIndex, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      //MethodCallExpression MethodAnyCall = IndexStringListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<IResourceIndexed, bool>>(MethodAnyCall, IndexListParameter);
    }

    ////---- _lastUpdated Property Expressions ------------------------------------------------------

    public Expression<Func<IResourceIndexed, bool>> LastUpdatedPropertyGreaterThan(DateTimeOffset Value)
    {
      //(x => x.birthdate_DateTimeOffset > TestDate);
      ParameterExpression MainParameter = Expression.Parameter(typeof(IResourceIndexed), "x");
      string DbPropertyName = StaticDatabaseInfo.BaseResourceConstatnts.LastUpdated;
      MemberExpression LastUpdatedProperty = Expression.Property(MainParameter, typeof(IResourceIndexed).GetProperty(DbPropertyName));
      var constantReference = Expression.Constant(Value, typeof(DateTimeOffset));
      var BinaryExpression = Expression.GreaterThan(LastUpdatedProperty, constantReference);
      return Expression.Lambda<Func<IResourceIndexed, bool>>(BinaryExpression, new[] { MainParameter });
    }

    public Expression<Func<IResourceIndexed, bool>> LastUpdatedPropertyGreaterThanOrEqualTo(DateTimeOffset Value)
    {
      //(x => x.birthdate_DateTimeOffset >= TestDate);
      ParameterExpression MainParameter = Expression.Parameter(typeof(IResourceIndexed), "x");
      string DbPropertyName = StaticDatabaseInfo.BaseResourceConstatnts.LastUpdated;
      MemberExpression LastUpdatedProperty = Expression.Property(MainParameter, typeof(IResourceIndexed).GetProperty(DbPropertyName));
      var constantReference = Expression.Constant(Value, typeof(DateTimeOffset));
      var BinaryExpression = Expression.GreaterThanOrEqual(LastUpdatedProperty, constantReference);
      return Expression.Lambda<Func<IResourceIndexed, bool>>(BinaryExpression, new[] { MainParameter });
    }

    public Expression<Func<IResourceIndexed, bool>> LastUpdatedPropertyLessThan(DateTimeOffset Value)
    {
      //(x => x.birthdate_DateTimeOffset < TestDate);
      ParameterExpression MainParameter = Expression.Parameter(typeof(IResourceIndexed), "x");
      string DbPropertyName = StaticDatabaseInfo.BaseResourceConstatnts.LastUpdated;
      MemberExpression LastUpdatedProperty = Expression.Property(MainParameter, typeof(IResourceIndexed).GetProperty(DbPropertyName));
      var constantReference = Expression.Constant(Value, typeof(DateTimeOffset));
      var BinaryExpression = Expression.LessThan(LastUpdatedProperty, constantReference);
      return Expression.Lambda<Func<IResourceIndexed, bool>>(BinaryExpression, new[] { MainParameter });
    }

    public Expression<Func<IResourceIndexed, bool>> LastUpdatedPropertyLessThanOrEqualTo(DateTimeOffset Value)
    {
      //(x => x.birthdate_DateTimeOffset <= TestDate);
      ParameterExpression MainParameter = Expression.Parameter(typeof(IResourceIndexed), "x");
      string DbPropertyName = StaticDatabaseInfo.BaseResourceConstatnts.LastUpdated;
      MemberExpression LastUpdatedProperty = Expression.Property(MainParameter, typeof(IResourceIndexed).GetProperty(DbPropertyName));
      var constantReference = Expression.Constant(Value, typeof(DateTimeOffset));
      var BinaryExpression = Expression.LessThanOrEqual(LastUpdatedProperty, constantReference);
      return Expression.Lambda<Func<IResourceIndexed, bool>>(BinaryExpression, new[] { MainParameter });
    }

    ////---- DateTime Property Expressions ------------------------------------------------------

    public Expression<Func<IResourceIndexed, bool>> DateTimePeriodCollectionAnyEqualTo(int Id, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(Pyro.Common.SearchIndexer.Index.IDateTimeIndex), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(IResourceIndexed), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression propertyReferenceLow = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetLow);
      MemberExpression propertyReferenceHigh = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetHigh);

      ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

      //Build Inner Expression
      Expression EqualToExpression = ExpressionSupport.DateTimePeriodExpression.EqualToExpression(propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, EqualToExpression);

      Expression<Func<Pyro.Common.SearchIndexer.Index.IDateTimeIndex, bool>> InnerFunction = Expression.Lambda<Func<Pyro.Common.SearchIndexer.Index.IDateTimeIndex, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      //MethodCallExpression MethodAnyCall = IndexDateTimeListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<IResourceIndexed, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<IResourceIndexed, bool>> DateTimePeriodCollectionAnyNotEqualTo(int Id, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(Pyro.Common.SearchIndexer.Index.IDateTimeIndex), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(IResourceIndexed), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression propertyReferenceLow = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetLow);
      MemberExpression propertyReferenceHigh = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetHigh);

      ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

      //Build Inner Expression
      Expression NotEqualToExpression = ExpressionSupport.DateTimePeriodExpression.NotEqualToExpression(propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, NotEqualToExpression);

      Expression<Func<Pyro.Common.SearchIndexer.Index.IDateTimeIndex, bool>> InnerFunction = Expression.Lambda<Func<Pyro.Common.SearchIndexer.Index.IDateTimeIndex, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      //MethodCallExpression MethodAnyCall = IndexDateTimeListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<IResourceIndexed, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<IResourceIndexed, bool>> DateTimePeriodCollectionGreaterThanOrEqualTo(int Id, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(Pyro.Common.SearchIndexer.Index.IDateTimeIndex), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(IResourceIndexed), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression propertyReferenceLow = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetLow);
      MemberExpression propertyReferenceHigh = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetHigh);

      ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

      //Build Inner Expression
      Expression GreaterThanOrEqualToExpression = ExpressionSupport.DateTimePeriodExpression.GreaterThanOrEqualToExpression(propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, GreaterThanOrEqualToExpression);

      Expression<Func<Pyro.Common.SearchIndexer.Index.IDateTimeIndex, bool>> InnerFunction = Expression.Lambda<Func<Pyro.Common.SearchIndexer.Index.IDateTimeIndex, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      //MethodCallExpression MethodAnyCall = IndexDateTimeListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<IResourceIndexed, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<IResourceIndexed, bool>> DateTimePeriodCollectionGreaterThan(int Id, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(Pyro.Common.SearchIndexer.Index.IDateTimeIndex), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(IResourceIndexed), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression propertyReferenceLow = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetLow);
      MemberExpression propertyReferenceHigh = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetHigh);

      ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

      //Build Inner Expression
      Expression GreaterThanExpression = ExpressionSupport.DateTimePeriodExpression.GreaterThanExpression(propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, GreaterThanExpression);

      Expression<Func<Pyro.Common.SearchIndexer.Index.IDateTimeIndex, bool>> InnerFunction = Expression.Lambda<Func<Pyro.Common.SearchIndexer.Index.IDateTimeIndex, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      //MethodCallExpression MethodAnyCall = IndexDateTimeListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<IResourceIndexed, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<IResourceIndexed, bool>> DateTimePeriodCollectionLessThan(int Id, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(Pyro.Common.SearchIndexer.Index.IDateTimeIndex), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(IResourceIndexed), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression propertyReferenceLow = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetLow);
      MemberExpression propertyReferenceHigh = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetHigh);

      ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

      //Build Inner Expression
      Expression LessThanExpression = ExpressionSupport.DateTimePeriodExpression.LessThanExpression(propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, LessThanExpression);

      Expression<Func<Pyro.Common.SearchIndexer.Index.IDateTimeIndex, bool>> InnerFunction = Expression.Lambda<Func<Pyro.Common.SearchIndexer.Index.IDateTimeIndex, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      //MethodCallExpression MethodAnyCall = IndexDateTimeListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<IResourceIndexed, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<IResourceIndexed, bool>> DateTimePeriodCollectionLessThanOrEqualTo(int Id, DateTimeOffset SearchValueLow, DateTimeOffset SearchValueHigh)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(Pyro.Common.SearchIndexer.Index.IDateTimeIndex), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(IResourceIndexed), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression propertyReferenceLow = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetLow);
      MemberExpression propertyReferenceHigh = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetHigh);

      ConstantExpression SearchValueReferenceLow = Expression.Constant(SearchValueLow, typeof(DateTimeOffset?));
      ConstantExpression SearchValueReferenceHigh = Expression.Constant(SearchValueHigh, typeof(DateTimeOffset?));

      //Build Inner Expression
      Expression LessThanOrEqualToExpression = ExpressionSupport.DateTimePeriodExpression.LessThanOrEqualToExpression(propertyReferenceLow, SearchValueReferenceLow, propertyReferenceHigh, SearchValueReferenceHigh);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, LessThanOrEqualToExpression);

      Expression<Func<Pyro.Common.SearchIndexer.Index.IDateTimeIndex, bool>> InnerFunction = Expression.Lambda<Func<Pyro.Common.SearchIndexer.Index.IDateTimeIndex, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      //MethodCallExpression MethodAnyCall = IndexDateTimeListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<IResourceIndexed, bool>>(MethodAnyCall, IndexListParameter);
    }

    ////---- Token Property Expressions ------------------------------------------------------

    public Expression<Func<IResourceIndexed, bool>> TokenMainAnyEqualTo(string Code)
    {
      ParameterExpression MainParameter = Expression.Parameter(typeof(IResourceIndexed), "x");

      string DbPropertyName = StaticDatabaseInfo.BaseResourceConstatnts.FhirId;
      MemberExpression FhirIdProperty = Expression.Property(MainParameter, typeof(IResourceIndexed).GetProperty(DbPropertyName));

      ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);
      Expression E_InnerExpression = ExpressionSupport.TokenExpression.MatchCodeOnlyExpression(FhirIdProperty, SearchValueReferenceCode);

      return Expression.Lambda<Func<IResourceIndexed, bool>>(E_InnerExpression, new[] { MainParameter });
    }

    public Expression<Func<IResourceIndexed, bool>> TokenCollectionAnyEqualTo(int Id, string Code, string System, SearchParameterTokenValue.TokenSearchType TokenSearchType)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(ITokenIndex), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(IResourceIndexed), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression propertyReferenceCode = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Code);
      MemberExpression propertyReferenceSystem = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.System);
      ConstantExpression SearchValueReferenceCode = Expression.Constant(Code);
      ConstantExpression SearchValueReferenceSystem = Expression.Constant(System);

      //Build Inner Expression
      Expression E_InnerExpression = null;
      switch (TokenSearchType)
      {
        case SearchParameterTokenValue.TokenSearchType.None:
          throw new Exception("Server error: DtoSearchParameterTokenValue.TokenSearchType was set to None.");
        case SearchParameterTokenValue.TokenSearchType.MatchCodeOnly:
          E_InnerExpression = ExpressionSupport.TokenExpression.MatchCodeOnlyExpression(propertyReferenceCode, SearchValueReferenceCode);
          break;
        case SearchParameterTokenValue.TokenSearchType.MatchSystemOnly:
          E_InnerExpression = ExpressionSupport.TokenExpression.MatchSystemOnlyExpression(propertyReferenceSystem, SearchValueReferenceSystem);
          break;
        case SearchParameterTokenValue.TokenSearchType.MatchCodeAndSystem:
          E_InnerExpression = ExpressionSupport.TokenExpression.MatchCodeAndSystemExpression(propertyReferenceCode, SearchValueReferenceCode, propertyReferenceSystem, SearchValueReferenceSystem);
          break;
        case SearchParameterTokenValue.TokenSearchType.MatchCodeWithNullSystem:
          E_InnerExpression = ExpressionSupport.TokenExpression.MatchCodeWithNullSystemExpression(propertyReferenceCode, SearchValueReferenceCode, propertyReferenceSystem);
          break;
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(TokenSearchType.ToString(), (int)TokenSearchType, typeof(SearchParameterTokenValue.TokenSearchType));
      }

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, E_InnerExpression);

      Expression<Func<ITokenIndex, bool>> InnerFunction = Expression.Lambda<Func<ITokenIndex, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<IResourceIndexed, bool>>(MethodAnyCall, IndexListParameter);
    }

    ////---- Number Property Expressions ------------------------------------------------------
    public Expression<Func<IResourceIndexed, bool>> NumberCollectionAnyEqualTo(int Id, decimal LowNumber, decimal MidNumber, decimal HighNumber)
    {
      return NumberCollectionAllEqual(Id, LowNumber, MidNumber, HighNumber, Hl7.Fhir.Model.SearchParameter.SearchComparator.Eq);
    }

    public Expression<Func<IResourceIndexed, bool>> NumberCollectionAllNotEqualTo(int Id, decimal LowNumber, decimal MidNumber, decimal HighNumber)
    {
      return NumberCollectionAllEqual(Id, LowNumber, MidNumber, HighNumber, Hl7.Fhir.Model.SearchParameter.SearchComparator.Ne);
    }

    private Expression<Func<IResourceIndexed, bool>> NumberCollectionAllEqual(int Id, decimal LowNumber, decimal MidNumber, decimal HighNumber, Hl7.Fhir.Model.SearchParameter.SearchComparator SearchComparator)
    {
      if (SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Eq || SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Ne)
      {
        ParameterExpression InnerParameter = Expression.Parameter(typeof(IQuantityIndex), "c");
        ParameterExpression IndexListParameter = Expression.Parameter(typeof(IResourceIndexed), "x");

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

        Expression<Func<IQuantityIndex, bool>> InnerFunction = Expression.Lambda<Func<IQuantityIndex, bool>>(IdAndExpression, InnerParameter);

        MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
        return Expression.Lambda<Func<IResourceIndexed, bool>>(MethodAnyCall, IndexListParameter);
      }
      else
      {
        throw new FormatException($"SearchParameter.SearchComparator must be Eq or Ne, found: {SearchComparator.ToString()}");
      }
    }

    public Expression<Func<IResourceIndexed, bool>> NumberCollectionAnyGreaterThan(int Id, decimal MidNumber)
    {
      return NumberCollectionComparator(Id, MidNumber, Hl7.Fhir.Model.SearchParameter.SearchComparator.Gt);
    }

    public Expression<Func<IResourceIndexed, bool>> NumberCollectionAnyGreaterThanOrEqualTo(int Id, decimal MidNumber)
    {
      return NumberCollectionComparator(Id, MidNumber, Hl7.Fhir.Model.SearchParameter.SearchComparator.Ge);
    }

    public Expression<Func<IResourceIndexed, bool>> NumberCollectionAnyLessThan(int Id, decimal MidNumber)
    {
      return NumberCollectionComparator(Id, MidNumber, Hl7.Fhir.Model.SearchParameter.SearchComparator.Lt);
    }

    public Expression<Func<IResourceIndexed, bool>> NumberCollectionAnyLessThanOrEqualTo(int Id, decimal MidNumber)
    {
      return NumberCollectionComparator(Id, MidNumber, Hl7.Fhir.Model.SearchParameter.SearchComparator.Le);
    }

    private Expression<Func<IResourceIndexed, bool>> NumberCollectionComparator(int Id, decimal MidNumber, Hl7.Fhir.Model.SearchParameter.SearchComparator SearchComparator)
    {
      if (SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Gt ||
          SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Ge ||
          SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Lt ||
          SearchComparator == Hl7.Fhir.Model.SearchParameter.SearchComparator.Le)
      {
        ParameterExpression InnerParameter = Expression.Parameter(typeof(IQuantityIndex), "c");
        ParameterExpression IndexListParameter = Expression.Parameter(typeof(IResourceIndexed), "x");

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

        Expression<Func<IQuantityIndex, bool>> InnerFunction = Expression.Lambda<Func<IQuantityIndex, bool>>(IdAndExpression, InnerParameter);

        MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
        return Expression.Lambda<Func<IResourceIndexed, bool>>(MethodAnyCall, IndexListParameter);
      }
      else
      {
        throw new FormatException($"SearchParameter.SearchComparator must be Gt, Ge, Lt or Le, found: {SearchComparator.ToString()}");
      }
    }

    ////---- Quantity Index Expressions ------------------------------------------------------

    public Expression<Func<IResourceIndexed, bool>> QuantityCollectionAnyEqualTo(int Id, decimal LowNumber, decimal MidNumber, decimal HighNumber, string System, string Code)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(IQuantityIndex), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(IResourceIndexed), "x");

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

      Expression<Func<IQuantityIndex, bool>> InnerFunction = Expression.Lambda<Func<IQuantityIndex, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<IResourceIndexed, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<IResourceIndexed, bool>> QuantityCollectionAllNotEqualTo(int Id, decimal LowNumber, decimal MidNumber, decimal HighNumber, string System, string Code)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(IQuantityIndex), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(IResourceIndexed), "x");

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

      Expression<Func<IQuantityIndex, bool>> InnerFunction = Expression.Lambda<Func<IQuantityIndex, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<IResourceIndexed, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<IResourceIndexed, bool>> QuantityCollectionAnyGreaterThan(int Id, decimal MidNumber, string System, string Code)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(IQuantityIndex), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(IResourceIndexed), "x");

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

      Expression<Func<IQuantityIndex, bool>> InnerFunction = Expression.Lambda<Func<IQuantityIndex, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<IResourceIndexed, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<IResourceIndexed, bool>> QuantityCollectionAnyGreaterThanOrEqualTo(int Id, decimal MidNumber, string System, string Code)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(IQuantityIndex), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(IResourceIndexed), "x");

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

      Expression<Func<IQuantityIndex, bool>> InnerFunction = Expression.Lambda<Func<IQuantityIndex, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<IResourceIndexed, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<IResourceIndexed, bool>> QuantityCollectionAnyLessThan(int Id, decimal MidNumber, string System, string Code)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(IQuantityIndex), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(IResourceIndexed), "x");

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

      Expression<Func<IQuantityIndex, bool>> InnerFunction = Expression.Lambda<Func<IQuantityIndex, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<IResourceIndexed, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<IResourceIndexed, bool>> QuantityCollectionAnyLessThanOrEqualTo(int Id, decimal MidNumber, string System, string Code)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(IQuantityIndex), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(IResourceIndexed), "x");

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

      Expression<Func<IQuantityIndex, bool>> InnerFunction = Expression.Lambda<Func<IQuantityIndex, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<IResourceIndexed, bool>>(MethodAnyCall, IndexListParameter);
    }

    ////---- Uri Property Expressions ------------------------------------------------------

    public Expression<Func<IResourceIndexed, bool>> UriCollectionAnyEqualTo(int Id, string Value)
    {
      //(x => x.IndexList.Any(c => c.String.StartsWith("Mill") & c.ServiceSearchParameterId == Id);
      ParameterExpression InnerParameter = Expression.Parameter(typeof(IUriIndex), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(IResourceIndexed), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Uri);
      ConstantExpression InnerValue = Expression.Constant(Value);

      MethodInfo MethodEquals = typeof(string).GetMethods().Where(m => m.Name == "Equals" && m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == typeof(string)).Single();
      MethodCallExpression MethodEqualsCall = Expression.Call(InnerProperty, MethodEquals, InnerValue);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, MethodEqualsCall);

      Expression<Func<IUriIndex, bool>> InnerFunction = Expression.Lambda<Func<IUriIndex, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<IResourceIndexed, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<IResourceIndexed, bool>> UriCollectionAnyContains(int Id, string Value)
    {
      //(x => x.IndexList.Any(c => c.String.Contains("myserver.net.au/stu3/api/Patient/1") & c.ServiceSearchParameterId == Id);
      ParameterExpression InnerParameter = Expression.Parameter(typeof(IUriIndex), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(IResourceIndexed), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Uri);
      ConstantExpression InnerValue = Expression.Constant(Value);

      MethodInfo MethodContains = typeof(string).GetMethods().Where(m => m.Name == "Contains" && m.GetParameters().Length == 1).Single();

      MethodCallExpression MethodEqualsCall = Expression.Call(InnerProperty, MethodContains, InnerValue);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, MethodEqualsCall);

      Expression<Func<IUriIndex, bool>> InnerFunction = Expression.Lambda<Func<IUriIndex, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<IResourceIndexed, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<IResourceIndexed, bool>> UriCollectionAnyStartsWith(int Id, string Value)
    {
      //(x => x.IndexList.Any(c => c.String.StartsWith("myserver.net.au/stu3/api/Patient/1") & c.ServiceSearchParameterId == Id);
      ParameterExpression InnerParameter = Expression.Parameter(typeof(IUriIndex), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(IResourceIndexed), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Uri);
      ConstantExpression InnerValue = Expression.Constant(Value);

      MethodInfo MethodStartsWith = typeof(string).GetMethods().Where(m => m.Name == "StartsWith" && m.GetParameters().Length == 1).Single();

      MethodCallExpression MethodEqualsCall = Expression.Call(InnerProperty, MethodStartsWith, InnerValue);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, MethodEqualsCall);

      Expression<Func<IUriIndex, bool>> InnerFunction = Expression.Lambda<Func<IUriIndex, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<IResourceIndexed, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<IResourceIndexed, bool>> UriCollectionAnyEndsWith(int Id, string Value)
    {
      //(x => x.IndexList.Any(c => c.String.EndsWith("myserver.net.au/stu3/api/Patient/1") & c.ServiceSearchParameterId == Id);
      ParameterExpression InnerParameter = Expression.Parameter(typeof(IUriIndex), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(IResourceIndexed), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression InnerProperty = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.Uri);
      ConstantExpression InnerValue = Expression.Constant(Value);

      MethodInfo MethodEndsWith = typeof(string).GetMethods().Where(m => m.Name == "EndsWith" && m.GetParameters().Length == 1).Single();

      MethodCallExpression MethodEqualsCall = Expression.Call(InnerProperty, MethodEndsWith, InnerValue);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, MethodEqualsCall);

      Expression<Func<IUriIndex, bool>> InnerFunction = Expression.Lambda<Func<IUriIndex, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<IResourceIndexed, bool>>(MethodAnyCall, IndexListParameter);
    }

    ////---- Referance Property Expressions ------------------------------------------------------

    public Expression<Func<IResourceIndexed, bool>> ReferanceCollectionAnyEqualTo_ByKey(int Id, int ServiceBaseUrlId, string ResourceType, string FhirId, string VersionId)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(IReferenceIndex), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(IResourceIndexed), "x");

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

      Expression<Func<IReferenceIndex, bool>> InnerFunction = Expression.Lambda<Func<IReferenceIndex, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<IResourceIndexed, bool>>(MethodAnyCall, IndexListParameter);

    }

    public Expression<Func<IResourceIndexed, bool>> ReferanceCollectionAnyEqualTo_ByKey_Many_FhirIds(int Id, int ServiceBaseUrlId, string ResourceType, string[] FhirIdArray, string VersionId)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(IReferenceIndex), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(IResourceIndexed), "x");

      BinaryExpression BinaryExpressionIdEquals = SearchParameterIdBinaryExpression(Id, InnerParameter);

      MemberExpression propertyReferenceServiceBaseUrlId = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.ReferenceServiceBaseUrlId);
      MemberExpression propertyReferenceResourceType = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.ReferenceResourceType);
      MemberExpression propertyReferenceFhirId = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.ReferenceFhirId);
      MemberExpression propertyReferenceVersionId = Expression.Property(InnerParameter, StaticDatabaseInfo.BaseResourceIndexConstatnts.ReferenceVersionId);

      ConstantExpression SearchValueReferenceServiceBaseUrlId = Expression.Constant(ServiceBaseUrlId, typeof(int?));
      ConstantExpression SearchValueReferenceResourceType = Expression.Constant(ResourceType, typeof(string));


      ConstantExpression SearchValueReferenceVersionId = Expression.Constant(VersionId, typeof(string));

      //FhirIdArray.Contains(y.ReferenceFhirId)
      Expression<Func<IReferenceIndex, bool>> ReferenceFhirIdContainsExpression = ContainsFhirID(InnerParameter, FhirIdArray);



      //Build Inner Expression
      Expression BinaryExpression_Final = ExpressionSupport.ReferanceExpression.EqualTo_ByURLStoreKey_ReferenceFhirIdContains_Expression(
        propertyReferenceServiceBaseUrlId,
        propertyReferenceResourceType,
        propertyReferenceVersionId,
        SearchValueReferenceServiceBaseUrlId,
        SearchValueReferenceResourceType,
        ReferenceFhirIdContainsExpression,
        SearchValueReferenceVersionId);

      var IdAndExpression = Expression.And(BinaryExpressionIdEquals, BinaryExpression_Final);

      Expression<Func<IReferenceIndex, bool>> InnerFunction = Expression.Lambda<Func<IReferenceIndex, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<IResourceIndexed, bool>>(MethodAnyCall, IndexListParameter);

    }

    public Expression<Func<IResourceIndexed, bool>> ReferanceCollectionAnyEqualTo_ByUrlString(int Id, string UrlString, string ResourceType, string FhirId, string VersionId)
    {
      ParameterExpression InnerParameter = Expression.Parameter(typeof(IReferenceIndex), "c");
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(IResourceIndexed), "x");

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

      Expression<Func<IReferenceIndex, bool>> InnerFunction = Expression.Lambda<Func<IReferenceIndex, bool>>(IdAndExpression, InnerParameter);

      MethodCallExpression MethodAnyCall = IndexListAnyMethodCallExpression(IndexListParameter, InnerFunction);
      return Expression.Lambda<Func<IResourceIndexed, bool>>(MethodAnyCall, IndexListParameter);
    }

    public Expression<Func<IResourceIndexed, bool>> ReferanceCollectionIsNotNull(int Id)
    {
      //(x => x.IndexList.Any(c => c.ServiceSearchParameterId == Id) == false);      
      return SearchParameterIdNull<Index.IReferenceIndex>(Id, false);
    }

    public Expression<Func<IResourceIndexed, bool>> ReferanceCollectionIsNull(int Id)
    {
      //(x => x.IndexList.Any(c => c.ServiceSearchParameterId == Id) == true);      
      return SearchParameterIdNull<Index.IReferenceIndex>(Id, true);
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

    private Expression<Func<IReferenceIndex, bool>> ContainsFhirID(ParameterExpression Param, string[] FhirIdArray)
    {
      //FhirIdArray.Contains(c.ReferenceFhirId)
      MethodInfo methodInfo = typeof(List<string>).GetMethod("Contains", new Type[] { typeof(string) });
      var list = Expression.Constant(FhirIdArray.ToList());
      var value = Expression.Property(Param, StaticDatabaseInfo.BaseResourceIndexConstatnts.ReferenceFhirId);
      var body = Expression.Call(list, methodInfo, value);
      return Expression.Lambda<Func<IReferenceIndex, bool>>(body, Param);
    }

    private MethodCallExpression IndexListAnyMethodCallExpression<IndexType>(ParameterExpression IndexListParameter, Expression<Func<IndexType, bool>> InnerFunction)
        where IndexType : IIndexBase
    {
      //var type = typeof(IResourceIndexed);
      //below is wrong need to reslve correct list because index list no longer exsists
      string DbPropertyName = string.Empty;
      DbPropertyName = ResolveDbIndexListPropertyName<IndexType>();

      MemberExpression IndexListProperty = Expression.Property(IndexListParameter, typeof(IResourceIndexed).GetProperty(DbPropertyName));
      MethodInfo MethodAny = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(IndexType));
      MethodCallExpression MethodAnyCall = Expression.Call(MethodAny, IndexListProperty, InnerFunction);
      return MethodAnyCall;
    }

    public Expression<Func<IResourceIndexed, bool>> SearchParameterIdIsNotNull<IndexType>(int Id)
      where IndexType : IIndexBase
    {
      //(x => x.IndexList.Any(c => c.ServiceSearchParameterId == Id).Count > 0);      
      return SearchParameterIdNull<IndexType>(Id, false);
    }

    public Expression<Func<IResourceIndexed, bool>> SearchParameterIsNull<IndexType>(int Id)
      where IndexType : IIndexBase
    {
      //(x => x.IndexList.Any(c => c.ServiceSearchParameterId == Id).Count == 0);      
      return SearchParameterIdNull<IndexType>(Id, true);
    }

    private Expression<Func<IResourceIndexed, bool>> SearchParameterIdNull<IndexType>(int Id, bool IsNull)
      where IndexType : IIndexBase
    {
      //IsNull = true
      //(x => x.IndexList.Any(c => c.ServiceSearchParameterId == Id) == true);      
      //IsNull = false
      //(x => x.IndexList.Any(c => c.ServiceSearchParameterId == Id) == false);                  
      ParameterExpression IndexListParameter = Expression.Parameter(typeof(IResourceIndexed), "x");
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

      return Expression.Lambda<Func<IResourceIndexed, bool>>(BinaryExpression, IndexListParameter);
    }

    private static string ResolveDbIndexListPropertyName<IndexType>() where IndexType : IIndexBase
    {
      string DbPropertyName;
      if (typeof(IndexType) == typeof(IStringIndex))
      {
        DbPropertyName = StaticDatabaseInfo.BaseResourceConstatnts.IndexStringList;
      }
      else if (typeof(IndexType) == typeof(ITokenIndex))
      {
        DbPropertyName = StaticDatabaseInfo.BaseResourceConstatnts.IndexTokenList;
      }
      else if (typeof(IndexType) == typeof(IUriIndex))
      {
        DbPropertyName = StaticDatabaseInfo.BaseResourceConstatnts.IndexUriList;
      }
      else if (typeof(IndexType) == typeof(IReferenceIndex))
      {
        DbPropertyName = StaticDatabaseInfo.BaseResourceConstatnts.IndexReferenceList;
      }
      else if (typeof(IndexType) == typeof(IQuantityIndex))
      {
        DbPropertyName = StaticDatabaseInfo.BaseResourceConstatnts.IndexQuantityList;
      }
      else if (typeof(IndexType) == typeof(Pyro.Common.SearchIndexer.Index.IDateTimeIndex))
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

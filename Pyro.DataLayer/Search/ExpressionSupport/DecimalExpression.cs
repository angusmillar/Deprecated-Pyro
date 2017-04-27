using System.Linq.Expressions;

namespace Pyro.DataLayer.Search.ExpressionSupport
{
  public static class DecimalExpression
  {
    public static Expression EqualToExpression(
      MemberExpression propertyReferenceComparator,
      MemberExpression propertyReferenceNumber,
      ConstantExpression SearchValueReferenceLow,
      ConstantExpression SearchValueReferenceMid,
      ConstantExpression SearchValueReferenceHigh)
    {

      var ConstantReferenceNull = Expression.Constant(null);
      var ConstantReferanceGreaterThanOrEqualTo = Expression.Constant(Hl7.Fhir.Model.Quantity.QuantityComparator.GreaterOrEqual, typeof(Hl7.Fhir.Model.Quantity.QuantityComparator?));
      var ConstantReferanceGreaterThan = Expression.Constant(Hl7.Fhir.Model.Quantity.QuantityComparator.GreaterThan, typeof(Hl7.Fhir.Model.Quantity.QuantityComparator?));
      var ConstantReferanceLessThanOrEqualTo = Expression.Constant(Hl7.Fhir.Model.Quantity.QuantityComparator.LessOrEqual, typeof(Hl7.Fhir.Model.Quantity.QuantityComparator?));
      var ConstantReferanceLessThan = Expression.Constant(Hl7.Fhir.Model.Quantity.QuantityComparator.LessThan, typeof(Hl7.Fhir.Model.Quantity.QuantityComparator?));

      //(x.length_Comparator == null)
      var BinaryExpression_ResourceComparator_IsEqualTo_Equal = Expression.Equal(propertyReferenceComparator, ConstantReferenceNull);

      //(x.length_Comparator == GreaterThanOrEqualTo)
      var BinaryExpression_ResourceComparator_IsEqualTo_GreaterThanOrEqualTo = Expression.Equal(propertyReferenceComparator, ConstantReferanceGreaterThanOrEqualTo);

      //(x.length_Comparator == GreaterThan)
      var BinaryExpression_ResourceComparator_IsEqualTo_GreaterThan = Expression.Equal(propertyReferenceComparator, ConstantReferanceGreaterThan);

      //(x.length_Comparator == LessThanOrEqualTo)
      var BinaryExpression_ResourceComparator_IsEqualTo_LessThanOrEqualTo = Expression.Equal(propertyReferenceComparator, ConstantReferanceLessThanOrEqualTo);

      //(x.length_Comparator == LessThan)
      var BinaryExpression_ResourceComparator_IsEqualTo_LessThan = Expression.Equal(propertyReferenceComparator, ConstantReferanceLessThan);

      //(x.length_Number >= ValueLow)
      var BinaryExpression_ResourceNumber_IsHigherThanOrEqualTo_SearchLow = Expression.GreaterThanOrEqual(propertyReferenceNumber, SearchValueReferenceLow);

      //(x.length_Number >= ValueMid)
      var BinaryExpression_ResourceNumber_IsHigherThanOrEqualTo_SearchMid = Expression.GreaterThanOrEqual(propertyReferenceNumber, SearchValueReferenceMid);

      //(x.length_Number > ValueMid)
      var BinaryExpression_ResourceNumber_IsHigherThan_SearchMid = Expression.GreaterThan(propertyReferenceNumber, SearchValueReferenceMid);

      //(x.length_Number <= ValueHigh)
      var BinaryExpression_ResourceNumber_IsLowerThanOrEqualTo_SearchHigh = Expression.LessThanOrEqual(propertyReferenceNumber, SearchValueReferenceHigh);

      //(x.length_Number <= ValueMid)
      var BinaryExpression_ResourceNumber_IsLowerThanOrEqualTo_SearchMid = Expression.LessThanOrEqual(propertyReferenceNumber, SearchValueReferenceMid);

      //(x.length_Number < ValueMid)
      var BinaryExpression_ResourceNumber_IsLowerThan_SearchMid = Expression.LessThan(propertyReferenceNumber, SearchValueReferenceMid);


      //(x.length_Number >= ValueLow) And (x.length_Number <= ValueHigh) And (x.length_Comparator == null)
      var BinaryExpression_A = Expression.And(BinaryExpression_ResourceNumber_IsHigherThanOrEqualTo_SearchLow, BinaryExpression_ResourceNumber_IsLowerThanOrEqualTo_SearchHigh);
      var BinaryExpression_Final_A = Expression.And(BinaryExpression_A, BinaryExpression_ResourceComparator_IsEqualTo_Equal);

      //(x.length_Number <= ValueMid && x.length_Comparator == GreaterThanOrEqualTo)
      var BinaryExpression_Final_B = Expression.And(BinaryExpression_ResourceNumber_IsLowerThanOrEqualTo_SearchMid, BinaryExpression_ResourceComparator_IsEqualTo_GreaterThanOrEqualTo);

      //(x.length_Number >= ValueMid && x.length_Comparator == LessThanOrEqualTo)
      var BinaryExpression_Final_C = Expression.And(BinaryExpression_ResourceNumber_IsHigherThanOrEqualTo_SearchMid, BinaryExpression_ResourceComparator_IsEqualTo_LessThanOrEqualTo);

      //(x.length_Number > ValueMid && x.length_Comparator == LessThan)
      var BinaryExpression_Final_D = Expression.And(BinaryExpression_ResourceNumber_IsHigherThan_SearchMid, BinaryExpression_ResourceComparator_IsEqualTo_LessThan);

      //(x.length_Number < ValueMid && x.length_Comparator == GreaterThan)
      var BinaryExpression_Final_E = Expression.And(BinaryExpression_ResourceNumber_IsLowerThan_SearchMid, BinaryExpression_ResourceComparator_IsEqualTo_GreaterThan);

      var BinaryExpression_Final_AB = Expression.Or(BinaryExpression_Final_A, BinaryExpression_Final_B);
      var BinaryExpression_Final_CD = Expression.Or(BinaryExpression_Final_C, BinaryExpression_Final_D);
      var BinaryExpression_Final_ABCD = Expression.Or(BinaryExpression_Final_AB, BinaryExpression_Final_CD);
      var BinaryExpression_Final_ABCDE = Expression.Or(BinaryExpression_Final_ABCD, BinaryExpression_Final_E);

      return BinaryExpression_Final_ABCDE;
    }

    public static Expression NotEqualToExpression(
      MemberExpression propertyReferenceComparator,
      MemberExpression propertyReferenceNumber,
      ConstantExpression SearchValueReferenceLow,
      ConstantExpression SearchValueReferenceMid,
      ConstantExpression SearchValueReferenceHigh)
    {

      var ConstantReferenceNull = Expression.Constant(null);
      var ConstantReferanceGreaterThanOrEqualTo = Expression.Constant(Hl7.Fhir.Model.Quantity.QuantityComparator.GreaterOrEqual, typeof(Hl7.Fhir.Model.Quantity.QuantityComparator?));
      var ConstantReferanceGreaterThan = Expression.Constant(Hl7.Fhir.Model.Quantity.QuantityComparator.GreaterThan, typeof(Hl7.Fhir.Model.Quantity.QuantityComparator?));
      var ConstantReferanceLessThanOrEqualTo = Expression.Constant(Hl7.Fhir.Model.Quantity.QuantityComparator.LessOrEqual, typeof(Hl7.Fhir.Model.Quantity.QuantityComparator?));
      var ConstantReferanceLessThan = Expression.Constant(Hl7.Fhir.Model.Quantity.QuantityComparator.LessThan, typeof(Hl7.Fhir.Model.Quantity.QuantityComparator?));

      //(x.length_Comparator == null)
      var BinaryExpression_ResourceComparator_IsEqualTo_Equal = Expression.Equal(propertyReferenceComparator, ConstantReferenceNull);

      //(x.length_Comparator == GreaterThanOrEqualTo)
      var BinaryExpression_ResourceComparator_IsEqualTo_GreaterThanOrEqualTo = Expression.Equal(propertyReferenceComparator, ConstantReferanceGreaterThanOrEqualTo);

      //(x.length_Comparator == GreaterThan)
      var BinaryExpression_ResourceComparator_IsEqualTo_GreaterThan = Expression.Equal(propertyReferenceComparator, ConstantReferanceGreaterThan);

      //(x.length_Comparator == LessThanOrEqualTo)
      var BinaryExpression_ResourceComparator_IsEqualTo_LessThanOrEqualTo = Expression.Equal(propertyReferenceComparator, ConstantReferanceLessThanOrEqualTo);

      //(x.length_Comparator == LessThan)
      var BinaryExpression_ResourceComparator_IsEqualTo_LessThan = Expression.Equal(propertyReferenceComparator, ConstantReferanceLessThan);

      //(x.length_Number <= ValueMid)
      var BinaryExpression_ResourceNumber_IsLowerThanOrEqualTo_SearchMid = Expression.LessThanOrEqual(propertyReferenceNumber, SearchValueReferenceMid);

      //(x.length_Number < ValueLow)
      var BinaryExpression_ResourceNumber_IsLowerThan_SearchLow = Expression.LessThan(propertyReferenceNumber, SearchValueReferenceLow);

      //(x.length_Number < ValueMid)
      var BinaryExpression_ResourceNumber_IsLowerThan_SearchMid = Expression.LessThan(propertyReferenceNumber, SearchValueReferenceMid);

      //(x.length_Number >= ValueMid)
      var BinaryExpression_ResourceNumber_IsHigherThanOrEqualTo_SearchMid = Expression.GreaterThanOrEqual(propertyReferenceNumber, SearchValueReferenceMid);

      //(x.length_Number > ValueHigh)
      var BinaryExpression_ResourceNumber_IsHigherThan_SearchHigh = Expression.GreaterThan(propertyReferenceNumber, SearchValueReferenceHigh);

      //(x.length_Number > ValueMid)
      var BinaryExpression_ResourceNumber_IsHigherThan_SearchMid = Expression.GreaterThan(propertyReferenceNumber, SearchValueReferenceMid);


      //(x.length_Number < ValueLow) or (x.length_Number > ValueHigh) And (x.length_Comparator == null)
      var BinaryExpression_A = Expression.Or(BinaryExpression_ResourceNumber_IsLowerThan_SearchLow, BinaryExpression_ResourceNumber_IsHigherThan_SearchHigh);
      var BinaryExpression_Final_A = Expression.And(BinaryExpression_A, BinaryExpression_ResourceComparator_IsEqualTo_Equal);

      //(x.length_Number > ValueHigh && x.length_Comparator == GreaterThanOrEqualTo)
      var BinaryExpression_Final_B = Expression.And(BinaryExpression_ResourceNumber_IsHigherThan_SearchMid, BinaryExpression_ResourceComparator_IsEqualTo_GreaterThanOrEqualTo);

      //(x.length_Number >= ValueHigh && x.length_Comparator == GreaterThan)
      var BinaryExpression_Final_C = Expression.And(BinaryExpression_ResourceNumber_IsHigherThanOrEqualTo_SearchMid, BinaryExpression_ResourceComparator_IsEqualTo_GreaterThan);

      //(x.length_Number < ValueLow && x.length_Comparator == LessThanOrEqualTo)
      var BinaryExpression_Final_D = Expression.And(BinaryExpression_ResourceNumber_IsLowerThan_SearchMid, BinaryExpression_ResourceComparator_IsEqualTo_LessThanOrEqualTo);

      //(x.length_Number <= ValueLow && x.length_Comparator == LessThan)
      var BinaryExpression_Final_E = Expression.And(BinaryExpression_ResourceNumber_IsLowerThanOrEqualTo_SearchMid, BinaryExpression_ResourceComparator_IsEqualTo_LessThan);


      var BinaryExpression_Final_AB = Expression.Or(BinaryExpression_Final_A, BinaryExpression_Final_B);
      var BinaryExpression_Final_CD = Expression.Or(BinaryExpression_Final_C, BinaryExpression_Final_D);
      var BinaryExpression_Final_ABCD = Expression.Or(BinaryExpression_Final_AB, BinaryExpression_Final_CD);
      var BinaryExpression_Final_ABCDE = Expression.Or(BinaryExpression_Final_ABCD, BinaryExpression_Final_E);

      return BinaryExpression_Final_ABCDE;
    }

    public static Expression GreaterThanExpression(
      MemberExpression propertyReferenceComparator,
      MemberExpression propertyReferenceNumber,
      ConstantExpression SearchValueReferenceMid)
    {
      var ConstantReferenceNull = Expression.Constant(null);
      var ConstantReferanceGreaterThanOrEqualTo = Expression.Constant(Hl7.Fhir.Model.Quantity.QuantityComparator.GreaterOrEqual, typeof(Hl7.Fhir.Model.Quantity.QuantityComparator?));
      var ConstantReferanceGreaterThan = Expression.Constant(Hl7.Fhir.Model.Quantity.QuantityComparator.GreaterThan, typeof(Hl7.Fhir.Model.Quantity.QuantityComparator?));
      var ConstantReferanceLessThanOrEqualTo = Expression.Constant(Hl7.Fhir.Model.Quantity.QuantityComparator.LessOrEqual, typeof(Hl7.Fhir.Model.Quantity.QuantityComparator?));
      var ConstantReferanceLessThan = Expression.Constant(Hl7.Fhir.Model.Quantity.QuantityComparator.LessThan, typeof(Hl7.Fhir.Model.Quantity.QuantityComparator?));

      //(x.length_Comparator == null)
      var BinaryExpression_ResourceComparator_IsEqualTo_Equal = Expression.Equal(propertyReferenceComparator, ConstantReferenceNull);

      //(x.length_Comparator == GreaterThanOrEqualTo)
      var BinaryExpression_ResourceComparator_IsEqualTo_GreaterThanOrEqualTo = Expression.Equal(propertyReferenceComparator, ConstantReferanceGreaterThanOrEqualTo);

      //(x.length_Comparator == GreaterThan)
      var BinaryExpression_ResourceComparator_IsEqualTo_GreaterThan = Expression.Equal(propertyReferenceComparator, ConstantReferanceGreaterThan);

      //(x.length_Comparator == LessThanOrEqualTo)
      var BinaryExpression_ResourceComparator_IsEqualTo_LessThanOrEqualTo = Expression.Equal(propertyReferenceComparator, ConstantReferanceLessThanOrEqualTo);

      //(x.length_Comparator == LessThan)
      var BinaryExpression_ResourceComparator_IsEqualTo_LessThan = Expression.Equal(propertyReferenceComparator, ConstantReferanceLessThan);

      //(x.length_Number > ValueMid)
      var BinaryExpression_ResourceNumber_IsHigherThan_SearchMid = Expression.GreaterThan(propertyReferenceNumber, SearchValueReferenceMid);

      //(x.length_Number >= ValueMid)
      //var BinaryExpression_ResourceNumber_IsHigherThanOrEqualTo_SearchMid = Expression.GreaterThanOrEqual(propertyReferenceNumber, SearchValueReferenceMid);


      //(x.length_Number > ValueMid) And (x.length_Comparator == null)
      var BinaryExpression_Final_A = Expression.And(BinaryExpression_ResourceNumber_IsHigherThan_SearchMid, BinaryExpression_ResourceComparator_IsEqualTo_Equal);

      //(x.length_Comparator == GreaterThanOrEqualTo) or (x.length_Comparator == GreaterThan)
      var BinaryExpression_Final_B = Expression.Or(BinaryExpression_ResourceComparator_IsEqualTo_GreaterThanOrEqualTo, BinaryExpression_ResourceComparator_IsEqualTo_GreaterThan);

      //(x.length_Number > ValueMid && x.length_Comparator == LessThanOrEqualTo)
      var BinaryExpression_Final_C = Expression.And(BinaryExpression_ResourceNumber_IsHigherThan_SearchMid, BinaryExpression_ResourceComparator_IsEqualTo_LessThanOrEqualTo);

      //(x.length_Number > ValueMid && x.length_Comparator == LessThan)
      var BinaryExpression_Final_D = Expression.And(BinaryExpression_ResourceNumber_IsHigherThan_SearchMid, BinaryExpression_ResourceComparator_IsEqualTo_LessThan);


      var BinaryExpression_Final_AB = Expression.Or(BinaryExpression_Final_A, BinaryExpression_Final_B);
      var BinaryExpression_Final_CD = Expression.Or(BinaryExpression_Final_C, BinaryExpression_Final_D);
      var BinaryExpression_Final_ABCD = Expression.Or(BinaryExpression_Final_AB, BinaryExpression_Final_CD);

      return BinaryExpression_Final_ABCD;
    }

    public static Expression GreaterThanOrEqualToExpression(
      MemberExpression propertyReferenceComparator,
      MemberExpression propertyReferenceNumber,
      ConstantExpression SearchValueReferenceMid)
    {
      var ConstantReferenceNull = Expression.Constant(null);
      var ConstantReferanceGreaterThanOrEqualTo = Expression.Constant(Hl7.Fhir.Model.Quantity.QuantityComparator.GreaterOrEqual, typeof(Hl7.Fhir.Model.Quantity.QuantityComparator?));
      var ConstantReferanceGreaterThan = Expression.Constant(Hl7.Fhir.Model.Quantity.QuantityComparator.GreaterThan, typeof(Hl7.Fhir.Model.Quantity.QuantityComparator?));
      var ConstantReferanceLessThanOrEqualTo = Expression.Constant(Hl7.Fhir.Model.Quantity.QuantityComparator.LessOrEqual, typeof(Hl7.Fhir.Model.Quantity.QuantityComparator?));
      var ConstantReferanceLessThan = Expression.Constant(Hl7.Fhir.Model.Quantity.QuantityComparator.LessThan, typeof(Hl7.Fhir.Model.Quantity.QuantityComparator?));

      //(x.length_Comparator == null)
      var BinaryExpression_ResourceComparator_IsEqualTo_Equal = Expression.Equal(propertyReferenceComparator, ConstantReferenceNull);

      //(x.length_Comparator == GreaterThanOrEqualTo)
      var BinaryExpression_ResourceComparator_IsEqualTo_GreaterThanOrEqualTo = Expression.Equal(propertyReferenceComparator, ConstantReferanceGreaterThanOrEqualTo);

      //(x.length_Comparator == GreaterThan)
      var BinaryExpression_ResourceComparator_IsEqualTo_GreaterThan = Expression.Equal(propertyReferenceComparator, ConstantReferanceGreaterThan);

      //(x.length_Comparator == LessThanOrEqualTo)
      var BinaryExpression_ResourceComparator_IsEqualTo_LessThanOrEqualTo = Expression.Equal(propertyReferenceComparator, ConstantReferanceLessThanOrEqualTo);

      //(x.length_Comparator == LessThan)
      var BinaryExpression_ResourceComparator_IsEqualTo_LessThan = Expression.Equal(propertyReferenceComparator, ConstantReferanceLessThan);

      //(x.length_Number >= ValueMid)
      var BinaryExpression_ResourceNumber_IsHigherThanOrEqualTo_SearchMid = Expression.GreaterThanOrEqual(propertyReferenceNumber, SearchValueReferenceMid);


      //(x.length_Number > ValueMid)
      var BinaryExpression_ResourceNumber_IsHigherThan_SearchMid = Expression.GreaterThan(propertyReferenceNumber, SearchValueReferenceMid);


      //(x.length_Number >= ValueMid) And (x.length_Comparator == null)
      var BinaryExpression_Final_A = Expression.And(BinaryExpression_ResourceNumber_IsHigherThanOrEqualTo_SearchMid, BinaryExpression_ResourceComparator_IsEqualTo_Equal);

      //(x.length_Comparator == GreaterThanOrEqualTo) or (x.length_Comparator == GreaterThan)
      var BinaryExpression_Final_B = Expression.Or(BinaryExpression_ResourceComparator_IsEqualTo_GreaterThanOrEqualTo, BinaryExpression_ResourceComparator_IsEqualTo_GreaterThan);

      //(x.length_Number >= ValueMid && x.length_Comparator == LessThanOrEqualTo)
      var BinaryExpression_Final_C = Expression.And(BinaryExpression_ResourceNumber_IsHigherThanOrEqualTo_SearchMid, BinaryExpression_ResourceComparator_IsEqualTo_LessThanOrEqualTo);

      //(x.length_Number > ValueMid && x.length_Comparator == LessThan)
      var BinaryExpression_Final_D = Expression.And(BinaryExpression_ResourceNumber_IsHigherThan_SearchMid, BinaryExpression_ResourceComparator_IsEqualTo_LessThan);

      var BinaryExpression_Final_AB = Expression.Or(BinaryExpression_Final_A, BinaryExpression_Final_B);
      var BinaryExpression_Final_CD = Expression.Or(BinaryExpression_Final_C, BinaryExpression_Final_D);
      var BinaryExpression_Final_ABCD = Expression.Or(BinaryExpression_Final_AB, BinaryExpression_Final_CD);

      return BinaryExpression_Final_ABCD;
    }

    public static Expression LessThanExpression(
      MemberExpression propertyReferenceComparator,
      MemberExpression propertyReferenceNumber,
      ConstantExpression SearchValueReferenceMid)
    {
      var ConstantReferenceNull = Expression.Constant(null);
      var ConstantReferanceGreaterThanOrEqualTo = Expression.Constant(Hl7.Fhir.Model.Quantity.QuantityComparator.GreaterOrEqual, typeof(Hl7.Fhir.Model.Quantity.QuantityComparator?));
      var ConstantReferanceGreaterThan = Expression.Constant(Hl7.Fhir.Model.Quantity.QuantityComparator.GreaterThan, typeof(Hl7.Fhir.Model.Quantity.QuantityComparator?));
      var ConstantReferanceLessThanOrEqualTo = Expression.Constant(Hl7.Fhir.Model.Quantity.QuantityComparator.LessOrEqual, typeof(Hl7.Fhir.Model.Quantity.QuantityComparator?));
      var ConstantReferanceLessThan = Expression.Constant(Hl7.Fhir.Model.Quantity.QuantityComparator.LessThan, typeof(Hl7.Fhir.Model.Quantity.QuantityComparator?));

      //(x.length_Comparator == null)
      var BinaryExpression_ResourceComparator_IsEqualTo_Equal = Expression.Equal(propertyReferenceComparator, ConstantReferenceNull);

      //(x.length_Comparator == GreaterThanOrEqualTo)
      var BinaryExpression_ResourceComparator_IsEqualTo_GreaterThanOrEqualTo = Expression.Equal(propertyReferenceComparator, ConstantReferanceGreaterThanOrEqualTo);

      //(x.length_Comparator == GreaterThan)
      var BinaryExpression_ResourceComparator_IsEqualTo_GreaterThan = Expression.Equal(propertyReferenceComparator, ConstantReferanceGreaterThan);

      //(x.length_Comparator == LessThanOrEqualTo)
      var BinaryExpression_ResourceComparator_IsEqualTo_LessThanOrEqualTo = Expression.Equal(propertyReferenceComparator, ConstantReferanceLessThanOrEqualTo);

      //(x.length_Comparator == LessThan)
      var BinaryExpression_ResourceComparator_IsEqualTo_LessThan = Expression.Equal(propertyReferenceComparator, ConstantReferanceLessThan);

      //(x.length_Number < ValueMid)
      var BinaryExpression_ResourceNumber_IsLowerThan_SearchMid = Expression.LessThan(propertyReferenceNumber, SearchValueReferenceMid);

      //(x.length_Number <= ValueMid)
      var BinaryExpression_ResourceNumber_IsLowerThanOrEqualTo_SearchMid = Expression.LessThanOrEqual(propertyReferenceNumber, SearchValueReferenceMid);



      //(x.length_Number < ValueMid) And (x.length_Comparator == null)
      var BinaryExpression_Final_A = Expression.And(BinaryExpression_ResourceNumber_IsLowerThan_SearchMid, BinaryExpression_ResourceComparator_IsEqualTo_Equal);

      //(x.length_Comparator == LessThanOrEqualTo) or (x.length_Comparator == LessThan)
      var BinaryExpression_Final_B = Expression.Or(BinaryExpression_ResourceComparator_IsEqualTo_LessThanOrEqualTo, BinaryExpression_ResourceComparator_IsEqualTo_LessThan);

      //(x.length_Number < ValueMid && x.length_Comparator == GreaterThanOrEqualTo)
      var BinaryExpression_Final_C = Expression.And(BinaryExpression_ResourceNumber_IsLowerThan_SearchMid, BinaryExpression_ResourceComparator_IsEqualTo_GreaterThanOrEqualTo);

      //(x.length_Number < ValueMid && x.length_Comparator == GreaterThan)
      var BinaryExpression_Final_D = Expression.And(BinaryExpression_ResourceNumber_IsLowerThan_SearchMid, BinaryExpression_ResourceComparator_IsEqualTo_GreaterThan);


      var BinaryExpression_Final_AB = Expression.Or(BinaryExpression_Final_A, BinaryExpression_Final_B);
      var BinaryExpression_Final_CD = Expression.Or(BinaryExpression_Final_C, BinaryExpression_Final_D);
      var BinaryExpression_Final_ABCD = Expression.Or(BinaryExpression_Final_AB, BinaryExpression_Final_CD);

      return BinaryExpression_Final_ABCD;
    }

    public static Expression LessThanOrEqualToExpression(
      MemberExpression propertyReferenceComparator,
      MemberExpression propertyReferenceNumber,
      ConstantExpression SearchValueReferenceMid)
    {
      var ConstantReferenceNull = Expression.Constant(null);
      var ConstantReferanceGreaterThanOrEqualTo = Expression.Constant(Hl7.Fhir.Model.Quantity.QuantityComparator.GreaterOrEqual, typeof(Hl7.Fhir.Model.Quantity.QuantityComparator?));
      var ConstantReferanceGreaterThan = Expression.Constant(Hl7.Fhir.Model.Quantity.QuantityComparator.GreaterThan, typeof(Hl7.Fhir.Model.Quantity.QuantityComparator?));
      var ConstantReferanceLessThanOrEqualTo = Expression.Constant(Hl7.Fhir.Model.Quantity.QuantityComparator.LessOrEqual, typeof(Hl7.Fhir.Model.Quantity.QuantityComparator?));
      var ConstantReferanceLessThan = Expression.Constant(Hl7.Fhir.Model.Quantity.QuantityComparator.LessThan, typeof(Hl7.Fhir.Model.Quantity.QuantityComparator?));

      //(x.length_Comparator == null)
      var BinaryExpression_ResourceComparator_IsEqualTo_Equal = Expression.Equal(propertyReferenceComparator, ConstantReferenceNull);

      //(x.length_Comparator == GreaterThanOrEqualTo)
      var BinaryExpression_ResourceComparator_IsEqualTo_GreaterThanOrEqualTo = Expression.Equal(propertyReferenceComparator, ConstantReferanceGreaterThanOrEqualTo);

      //(x.length_Comparator == GreaterThan)
      var BinaryExpression_ResourceComparator_IsEqualTo_GreaterThan = Expression.Equal(propertyReferenceComparator, ConstantReferanceGreaterThan);

      //(x.length_Comparator == LessThanOrEqualTo)
      var BinaryExpression_ResourceComparator_IsEqualTo_LessThanOrEqualTo = Expression.Equal(propertyReferenceComparator, ConstantReferanceLessThanOrEqualTo);

      //(x.length_Comparator == LessThan)
      var BinaryExpression_ResourceComparator_IsEqualTo_LessThan = Expression.Equal(propertyReferenceComparator, ConstantReferanceLessThan);

      //(x.length_Number <= ValueMid)
      var BinaryExpression_ResourceNumber_IsLessThanOrEqualTo_SearchMid = Expression.LessThanOrEqual(propertyReferenceNumber, SearchValueReferenceMid);


      //(x.length_Number < ValueMid)
      var BinaryExpression_ResourceNumber_IsLessThan_SearchMid = Expression.LessThan(propertyReferenceNumber, SearchValueReferenceMid);


      //(x.length_Number <= ValueMid) And (x.length_Comparator == null)
      var BinaryExpression_Final_A = Expression.And(BinaryExpression_ResourceNumber_IsLessThanOrEqualTo_SearchMid, BinaryExpression_ResourceComparator_IsEqualTo_Equal);

      //(x.length_Comparator == LessThanOrEqualTo) or (x.length_Comparator == LessThan)
      var BinaryExpression_Final_B = Expression.Or(BinaryExpression_ResourceComparator_IsEqualTo_LessThanOrEqualTo, BinaryExpression_ResourceComparator_IsEqualTo_LessThan);

      //(x.length_Number <= ValueMid && x.length_Comparator == GreaterThanOrEqualTo)
      var BinaryExpression_Final_C = Expression.And(BinaryExpression_ResourceNumber_IsLessThanOrEqualTo_SearchMid, BinaryExpression_ResourceComparator_IsEqualTo_GreaterThanOrEqualTo);

      //(x.length_Number < ValueMid && x.length_Comparator == GreaterThan)
      var BinaryExpression_Final_D = Expression.And(BinaryExpression_ResourceNumber_IsLessThan_SearchMid, BinaryExpression_ResourceComparator_IsEqualTo_GreaterThan);

      var BinaryExpression_Final_AB = Expression.Or(BinaryExpression_Final_A, BinaryExpression_Final_B);
      var BinaryExpression_Final_CD = Expression.Or(BinaryExpression_Final_C, BinaryExpression_Final_D);
      var BinaryExpression_Final_ABCD = Expression.Or(BinaryExpression_Final_AB, BinaryExpression_Final_CD);

      return BinaryExpression_Final_ABCD;
    }

    public static Expression IsNullExpression(
      MemberExpression propertyReferenceComparator,
      MemberExpression propertyReferenceNumber)
    {
      var ConstantReferenceNull = Expression.Constant(null);

      //(x.length_Number == null)
      var BinaryExpression_ResourceNumber_IsEqualTo_Null = Expression.Equal(propertyReferenceNumber, ConstantReferenceNull);

      Expression BinaryExpression_Final = BinaryExpression_ResourceNumber_IsEqualTo_Null;

      return BinaryExpression_Final;
    }

    public static Expression IsNotNullExpression(
      MemberExpression propertyReferenceComparator,
      MemberExpression propertyReferenceNumber)
    {
      var ConstantReferenceNull = Expression.Constant(null);

      //(x.length_Number == null)
      var BinaryExpression_ResourceNumber_IsEqualTo_NotNull = Expression.NotEqual(propertyReferenceNumber, ConstantReferenceNull);

      Expression BinaryExpression_Final = BinaryExpression_ResourceNumber_IsEqualTo_NotNull;

      return BinaryExpression_Final;
    }



  }

}


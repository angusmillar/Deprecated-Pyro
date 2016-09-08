using System;
using NUnit.Framework;
using Blaze.DataModel.IndexSetter;
using Blaze.DataModel.DatabaseModel.Base;
using Hl7.Fhir.Model;
using NUnit.Framework.Constraints;

namespace Blaze.Test.IndexSetters
{
  [TestFixture]
  class Test_DateTime_IndexSetters
  {
    [Test]
    public void Test_Date_DateIndexSetter_GoodFormat()
    {
      //Arrange
      var Date = new Date("1974-12-25");
      DateTimeIndex Index = new DateTimeIndex();

      //Act
      IndexSetterFactory.Create(typeof(DateTimeIndex)).Set(Date, Index);

      //Assert
      Assert.AreEqual(new DateTimeOffset(1974, 12, 25, 00, 00, 00, TimeZoneInfo.Local.GetUtcOffset(DateTime.Now)), Index.DateTimeOffset);
    }

    [Test]
    public void Test_Date_DateIndexSetter_GoodFormat_MonthYearOnly()
    {
      //Arrange
      var Date = new Date("1974-12");
      DateTimeIndex Index = new DateTimeIndex();

      //Act
      IndexSetterFactory.Create(typeof(DateTimeIndex)).Set(Date, Index);

      //Assert
      Assert.AreEqual(new DateTimeOffset(1974, 12, 01, 00, 00, 00, TimeZoneInfo.Local.GetUtcOffset(DateTime.Now)), Index.DateTimeOffset);
    }

    [Test]
    public void Test_Date_DateIndexSetter_GoodFormat_YearOnly()
    {
      //Arrange
      var Date = new Date("1974");
      DateTimeIndex Index = new DateTimeIndex();

      //Act
      IndexSetterFactory.Create(typeof(DateTimeIndex)).Set(Date, Index);

      //Assert
      Assert.AreEqual(new DateTimeOffset(1974, 01, 01, 00, 00, 00, TimeZoneInfo.Local.GetUtcOffset(DateTime.Now)), Index.DateTimeOffset);
    }

    [Test]
    public void Test_Date_DateIndexSetter_BadFormat()
    {

      //Arrange
      var Date = new Date("25-12-1974");
      DateTimeIndex Index = new DateTimeIndex();

      //Act
      ActualValueDelegate<DateTimeIndex> testDelegate = () => IndexSetterFactory.Create(typeof(DateTimeIndex)).Set(Date, Index) as DateTimeIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<FormatException>());

    }


    [Test]
    public void Test_FhirDateTime_DateIndexSetter_GoodFormat()
    {
      //Arrange
      var FhirDateTime = new FhirDateTime("1974-12-25T14:35:45-05:00");
      DateTimeIndex Index = new DateTimeIndex();
      //Act
      IndexSetterFactory.Create(typeof(DateTimeIndex)).Set(FhirDateTime, Index);

      //Assert
      Assert.AreEqual(new DateTimeOffset(1974, 12, 25, 14, 35, 45, new TimeSpan(-05, 00, 00)), Index.DateTimeOffset);
    }


    [Test]
    public void Test_FhirDateTime_DateIndexSetter_BadFormat_NoTimeZone()
    {
      //Arrange
      var FhirDateTime = new FhirDateTime("1974-12-25T14:35:45:00");
      DateTimeIndex Index = new DateTimeIndex();

      //Act
      ActualValueDelegate<DateTimeIndex> testDelegate = () => IndexSetterFactory.Create(typeof(DateTimeIndex)).Set(FhirDateTime, Index) as DateTimeIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<FormatException>());
    }

    [Test]
    public void Test_FhirDateTime_DateIndexSetter_BadFormat_NoSecs()
    {
      //Arrange
      var FhirDateTime = new FhirDateTime("1974-12-25T14:35-05:00");
      DateTimeIndex Index = new DateTimeIndex();

      //Act
      ActualValueDelegate<DateTimeIndex> testDelegate = () => IndexSetterFactory.Create(typeof(DateTimeIndex)).Set(FhirDateTime, Index) as DateTimeIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<FormatException>());
    }

    [Test]
    public void Test_FhirString_DateIndexSetter_DateTime_GoodFormat()
    {
      //Arrange
      var FhirString = new FhirString("1974-12-25T14:35:45-05:00");
      DateTimeIndex Index = new DateTimeIndex();

      //Act
      IndexSetterFactory.Create(typeof(DateTimeIndex)).Set(FhirString, Index);

      //Assert
      Assert.AreEqual(new DateTimeOffset(1974, 12, 25, 14, 35, 45, new TimeSpan(-05, 00, 00)), Index.DateTimeOffset);
    }

    [Test]
    public void Test_FhirString_DateIndexSetter_DateTime_GoodFormat_With_MilliSecs()
    {
      //Arrange
      var FhirString = new FhirString("1974-12-25T14:35:45.123-05:00");
      DateTimeIndex Index = new DateTimeIndex();

      //Act
      IndexSetterFactory.Create(typeof(DateTimeIndex)).Set(FhirString, Index);

      //Assert
      Assert.AreEqual(new DateTimeOffset(1974, 12, 25, 14, 35, 45, 123 , new TimeSpan(-05, 00, 00)), Index.DateTimeOffset);
    }

    [Test]
    public void Test_FhirString_DateIndexSetter_DateTime_GoodFormat_MonthOnly_NoTimeZone()
    {
      //Arrange
      var FhirString = new FhirString("1974-12");
      DateTimeIndex Index = new DateTimeIndex();

      //Act
      IndexSetterFactory.Create(typeof(DateTimeIndex)).Set(FhirString, Index);

      //Assert
      Assert.AreEqual(new DateTimeOffset(1974, 12, 1, 00, 00, 00, TimeZoneInfo.Local.GetUtcOffset(DateTime.Now)), Index.DateTimeOffset);
    }

    [Test]
    public void Test_FhirString_DateIndexSetter_Date_GoodFormat()
    {
      //Arrange
      var FhirString = new FhirString("1974-12-25");
      DateTimeIndex Index = new DateTimeIndex();

      //Act
      IndexSetterFactory.Create(typeof(DateTimeIndex)).Set(FhirString, Index);

      //Assert
      Assert.AreEqual(new DateTimeOffset(1974, 12, 25, 00, 00, 00, TimeZoneInfo.Local.GetUtcOffset(DateTime.Now)), Index.DateTimeOffset);
    }


    [Test]
    public void Test_FhirString_DateIndexSetter_BadErrorFormat()
    {
      //Arrange
      var FhirString = new FhirString("1974XX-12-25T14:3554:45-05:00");
      DateTimeIndex DateIndex = new DateTimeIndex();


      //Act
      DateIndex = IndexSetterFactory.Create(typeof(DateTimeIndex)).Set(FhirString, DateIndex) as DateTimeIndex;

      //Assert
      Assert.IsNull(DateIndex);

    }

    [Test]
    public void Test_FhirString_DateIndexSetter_BadFormat_NoTimeZone()
    {
      //Arrange
      var FhirString = new FhirString("1974-12-25T14:35:45");
      DateTimeIndex DateIndex = new DateTimeIndex();


      //Act
      DateIndex = IndexSetterFactory.Create(typeof(DateTimeIndex)).Set(FhirString, DateIndex) as DateTimeIndex;

      //Assert
      Assert.IsNull(DateIndex);

    }

    [Test]
    public void Test_FhirString_DateIndexSetter_BadFormat_NoSecs()
    {
      //Arrange
      var FhirString = new FhirString("1974-12-25T14:35-05:00");
      DateTimeIndex DateIndex = new DateTimeIndex();


      //Act
      DateIndex = IndexSetterFactory.Create(typeof(DateTimeIndex)).Set(FhirString, DateIndex) as DateTimeIndex;

      //Assert
      Assert.IsNull(DateIndex);

    }

    [Test]
    public void Test_Instant_DateIndexSetter_GoodFormat()
    {
      //Arrange
      var Instant = new Instant(new DateTimeOffset(1974, 12, 25, 14, 35, 45, new TimeSpan(-05, 00, 00)));
      DateTimeIndex Index = new DateTimeIndex();

      //Act
      IndexSetterFactory.Create(typeof(DateTimeIndex)).Set(Instant, Index);

      //Assert
      Assert.AreEqual(new DateTimeOffset(1974, 12, 25, 14, 35, 45, new TimeSpan(-05, 00, 00)), Index.DateTimeOffset);
    }

    [Test]
    public void Test_Instant_DateIndexSetter_InstantValue_IsNull()
    {
      //Arrange
      var Instant = new Instant(null);
      DateTimeIndex Index = new DateTimeIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(DateTimeIndex)).Set(Instant, Index) as DateTimeIndex;

      //Assert
      Assert.IsNull(Index);
    }

    [Test]
    public void Test_Instant_DateIndexSetter_Instant_IsNull()
    {
      //Arrange
      Instant Instant = null;
      DateTimeIndex Index = new DateTimeIndex();

      //Act
      ActualValueDelegate<DateTimeIndex> testDelegate = () => IndexSetterFactory.Create(typeof(DateTimeIndex)).Set(Instant, Index) as DateTimeIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<ArgumentNullException>());
    }



  }
}

using System;
using NUnit.Framework;
using Blaze.Common.Tools;
using Hl7.Fhir.Model;
using NUnit.Framework.Constraints;

namespace Blaze.Test.IndexSetters
{
  [TestFixture]
  class Test_FhirDateTimeSupport
  {
    [Test]
    public void Test_FhirDateTimeTo_DateTimeOffset_YearMonthDayHourMinSecMilli_AndTimeZoneMinus()
    {
      //Arrange
      string FhirDateTime = "1974-12-25T12:35:15.123-03:00";
      DateTimeOffset Expected = new DateTimeOffset(1974, 12, 25, 12, 35, 15, 123, new TimeSpan(-3,0,0));

      //Act
      FhirDateTimeSupport Result = new FhirDateTimeSupport(FhirDateTime);

      //Assert
      Assert.AreEqual(Expected, Result.Value);
      Assert.IsTrue(Result.IsValid);
      Assert.AreEqual(FhirDateTimeSupport.DateTimePrecision.MilliSec, Result.Precision);
    }

    [Test]
    public void Test_FhirDateTimeTo_DateTimeOffset_YearMonthDayHourMinSecMilli()
    {
      //Arrange
      string FhirDateTime = "1974-12-25T12:35:15.123";
      DateTimeOffset Expected = new DateTimeOffset(1974, 12, 25, 12, 35, 15, 123, TimeZoneInfo.Local.GetUtcOffset(DateTime.Now));

      //Act
      FhirDateTimeSupport Result = new FhirDateTimeSupport(FhirDateTime);

      //Assert
      Assert.AreEqual(Expected, Result.Value);
      Assert.IsTrue(Result.IsValid);
      Assert.AreEqual(FhirDateTimeSupport.DateTimePrecision.MilliSec, Result.Precision);
    }

    [Test]
    public void Test_FhirDateTimeTo_DateTimeOffset_YearMonthDayHourMinSec()
    {
      //Arrange
      string FhirDateTime = "1974-12-25T12:35:15";
      DateTimeOffset Expected = new DateTimeOffset(1974, 12, 25, 12, 35, 15, TimeZoneInfo.Local.GetUtcOffset(DateTime.Now));

      //Act
      FhirDateTimeSupport Result = new FhirDateTimeSupport(FhirDateTime);

      //Assert
      Assert.AreEqual(Expected, Result.Value);
      Assert.IsTrue(Result.IsValid);
      Assert.AreEqual(FhirDateTimeSupport.DateTimePrecision.Sec, Result.Precision);
    }

    [Test]
    public void Test_FhirDateTimeTo_DateTimeOffset_YearMonthDayHourMinSec_TimeZone()
    {
      //Arrange
      string FhirDateTime = "1974-12-25T12:35:15+02:00";
      DateTimeOffset Expected = new DateTimeOffset(1974, 12, 25, 12, 35, 15, new TimeSpan(2,0,0));

      //Act
      FhirDateTimeSupport Result = new FhirDateTimeSupport(FhirDateTime);

      //Assert
      Assert.AreEqual(Expected, Result.Value);
      Assert.IsTrue(Result.IsValid);
      Assert.AreEqual(FhirDateTimeSupport.DateTimePrecision.Sec, Result.Precision);
    }

    [Test]
    public void Test_FhirDateTimeTo_DateTimeOffset_YearMonthDayHourMin()
    {
      //Arrange
      string FhirDateTime = "1974-12-25T12:35";
      DateTimeOffset Expected = new DateTimeOffset(1974, 12, 25, 12, 35, 0, TimeZoneInfo.Local.GetUtcOffset(DateTime.Now));

      //Act
      FhirDateTimeSupport Result = new FhirDateTimeSupport(FhirDateTime);

      //Assert
      Assert.AreEqual(Expected, Result.Value);
      Assert.IsTrue(Result.IsValid);
      Assert.AreEqual(FhirDateTimeSupport.DateTimePrecision.HourMin, Result.Precision);
    }

    [Test]
    public void Test_FhirDateTimeTo_DateTimeOffset_YearMonthDayHourMin_TimeZone()
    {
      //Arrange
      string FhirDateTime = "1974-12-25T12:35-04:00";
      DateTimeOffset Expected = new DateTimeOffset(1974, 12, 25, 12, 35, 0, new TimeSpan(-4,0,0));

      //Act
      FhirDateTimeSupport Result = new FhirDateTimeSupport(FhirDateTime);

      //Assert
      Assert.AreEqual(Expected, Result.Value);
      Assert.IsTrue(Result.IsValid);
      Assert.AreEqual(FhirDateTimeSupport.DateTimePrecision.HourMin, Result.Precision);
    }


    [Test]
    public void Test_FhirDateTimeTo_DateTimeOffset_YearMonthDay()
    {
      //Arrange
      string FhirDateTime = "1974-12-25";
      DateTimeOffset Expected = new DateTimeOffset(1974, 12, 25, 0, 0, 0, TimeZoneInfo.Local.GetUtcOffset(DateTime.Now));

      //Act
      FhirDateTimeSupport Result = new FhirDateTimeSupport(FhirDateTime);

      //Assert
      Assert.AreEqual(Expected, Result.Value);
      Assert.IsTrue(Result.IsValid);
      Assert.AreEqual(FhirDateTimeSupport.DateTimePrecision.Day, Result.Precision);
    }

    [Test]
    public void Test_FhirDateTimeTo_DateTimeOffset_Year()
    {
      //Arrange
      string FhirDateTime = "1974";
      DateTimeOffset Expected = new DateTimeOffset(1974, 1, 1, 0, 0, 0, TimeZoneInfo.Local.GetUtcOffset(DateTime.Now));

      //Act
      FhirDateTimeSupport Result = new FhirDateTimeSupport(FhirDateTime);

      //Assert
      Assert.AreEqual(Expected, Result.Value);
      Assert.IsTrue(Result.IsValid);
      Assert.AreEqual(FhirDateTimeSupport.DateTimePrecision.Year, Result.Precision);
    }

    [Test]
    public void Test_FhirDateTimeTo_DateTimeOffset_Month()
    {
      //Arrange
      string FhirDateTime = "1974-09";
      DateTimeOffset Expected = new DateTimeOffset(1974, 9, 1, 0, 0, 0, TimeZoneInfo.Local.GetUtcOffset(DateTime.Now));

      //Act
      FhirDateTimeSupport Result = new FhirDateTimeSupport(FhirDateTime);

      //Assert
      Assert.AreEqual(Expected, Result.Value);
      Assert.IsTrue(Result.IsValid);
      Assert.AreEqual(FhirDateTimeSupport.DateTimePrecision.Month, Result.Precision);
    }


    [Test]
    public void Test_FhirDateTimeTo_DateTimeOffset_Month_BadFormat()
    {
      //Arrange
      string FhirDateTime = "197X-09";
      DateTimeOffset Expected = new DateTimeOffset(1974, 9, 1, 0, 0, 0, TimeZoneInfo.Local.GetUtcOffset(DateTime.Now));

      //Act
      FhirDateTimeSupport Result = new FhirDateTimeSupport(FhirDateTime);

      //Assert
      Assert.IsFalse(Result.Value.HasValue);
      Assert.IsFalse(Result.IsValid);
    }

    [Test]
    public void Test_FhirDateTimeTo_DateTimeOffset_Year_BadFormat()
    {
      //Arrange
      string FhirDateTime = "1t74";
      DateTimeOffset Expected = new DateTimeOffset(1974, 1, 1, 0, 0, 0, TimeZoneInfo.Local.GetUtcOffset(DateTime.Now));

      //Act
      FhirDateTimeSupport Result = new FhirDateTimeSupport(FhirDateTime);

      //Assert
      Assert.IsFalse(Result.Value.HasValue);
      Assert.IsFalse(Result.IsValid);
    }

    [Test]
    public void Test_FhirDateTimeTo_DateTimeOffset_YearMonthDay_BadFormat()
    {
      //Arrange
      string FhirDateTime = "1974-12-38";
      DateTimeOffset Expected = new DateTimeOffset(1974, 12, 25, 0, 0, 0, TimeZoneInfo.Local.GetUtcOffset(DateTime.Now));

      //Act
      FhirDateTimeSupport Result = new FhirDateTimeSupport(FhirDateTime);

      //Assert
      Assert.IsFalse(Result.Value.HasValue);
      Assert.IsFalse(Result.IsValid);
    }

    [Test]
    public void Test_FhirDateTimeTo_DateTimeOffset_YearMonthDayHourMin_TimeZone_BadFormat()
    {
      //Arrange
      string FhirDateTime = "1974-12-25T12:35-40:00";
      DateTimeOffset Expected = new DateTimeOffset(1974, 12, 25, 12, 35, 0, new TimeSpan(-4, 0, 0));

      //Act
      FhirDateTimeSupport Result = new FhirDateTimeSupport(FhirDateTime);

      //Assert
      Assert.IsFalse(Result.Value.HasValue);
      Assert.IsFalse(Result.IsValid);
    }

    [Test]
    public void Test_FhirDateTimeTo_DateTimeOffset_YearMonthDayHourMinSecMilli_AndTimeZoneMinus_BadFormat()
    {
      //Arrange
      string FhirDateTime = "1974-12-25T12:35:70.123-03:00";
      DateTimeOffset Expected = new DateTimeOffset(1974, 12, 25, 12, 35, 15, 123, new TimeSpan(-3, 0, 0));

      //Act
      FhirDateTimeSupport Result = new FhirDateTimeSupport(FhirDateTime);

      //Assert
      Assert.IsFalse(Result.Value.HasValue);
      Assert.IsFalse(Result.IsValid);
    }
  }
}

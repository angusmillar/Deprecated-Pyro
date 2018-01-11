using System;
using NUnit.Framework;
using Pyro.Common.Tools;
using Hl7.Fhir.Model;
using NUnit.Framework.Constraints;

namespace Pyro.Test.IndexSetters
{
  [TestFixture]
  [Category("Tools")]
  class Test_DateTimeSupport
  {
    private int TimeZoneTestRunningWithin = 8;
    [Test]
    public void Test_FhirDateOfYearToIndex()
    {
      //Arrange
      var FhirDate = new Date("1974");
      DateTimeOffset ExpectedLow = new DateTimeOffset(1974, 01, 01, 00, 00, 00, 0, new TimeSpan(TimeZoneTestRunningWithin, 0, 0));
      DateTimeOffset ExpectedHigh = new DateTimeOffset(1974, 12, 31, 23, 59, 59, 999, new TimeSpan(TimeZoneTestRunningWithin, 0, 0));

      //Act
      DateTimeIndex Result = DateTimeIndexSupport.GetDateTimeIndex(FhirDate);

      //Assert
      Assert.AreEqual(ExpectedLow, Result.Low);
      Assert.AreEqual(ExpectedHigh, Result.High);
    }

    [Test]
    public void Test_FhirDateOfYearMonthToIndex()
    {
      //Arrange
      var FhirDate = new Date("1974-02");
      DateTimeOffset ExpectedLow = new DateTimeOffset(1974, 02, 01, 00, 00, 00, 0, new TimeSpan(TimeZoneTestRunningWithin, 0, 0));
      DateTimeOffset ExpectedHigh = new DateTimeOffset(1974, 02, 28, 23, 59, 59, 999, new TimeSpan(TimeZoneTestRunningWithin, 0, 0));

      //Act
      DateTimeIndex Result = DateTimeIndexSupport.GetDateTimeIndex(FhirDate);

      //Assert
      Assert.AreEqual(ExpectedLow, Result.Low);
      Assert.AreEqual(ExpectedHigh, Result.High);
    }

    [Test]
    public void Test_FhirDateOfYearMonthDayToIndex()
    {
      //Arrange
      var FhirDate = new Date("1974-02-01");

      DateTimeOffset ExpectedLow = new DateTimeOffset(1974, 02, 01, 00, 00, 00, 0, new TimeSpan(TimeZoneTestRunningWithin, 0, 0));
      DateTimeOffset ExpectedHigh = new DateTimeOffset(1974, 02, 01, 23, 59, 59, 999, new TimeSpan(TimeZoneTestRunningWithin, 0, 0));

      //Act
      DateTimeIndex Result = DateTimeIndexSupport.GetDateTimeIndex(FhirDate);

      //Assert
      Assert.AreEqual(ExpectedLow, Result.Low);
      Assert.AreEqual(ExpectedHigh, Result.High);
    }

    [Test]
    public void Test_FhirDateTimeOfYearMonthDayHrMinSecToIndex()
    {
      //Arrange
      var FhirDate = new FhirDateTime("1974-02-01T12:38:10+10:00");
      DateTimeOffset ExpectedLow = new DateTimeOffset(1974, 02, 01, 12, 38, 10, 0, new TimeSpan(10, 0, 0));
      DateTimeOffset ExpectedHigh = new DateTimeOffset(1974, 02, 01, 12, 38, 10, 999, new TimeSpan(10, 0, 0));

      //Act
      DateTimeIndex Result = DateTimeIndexSupport.GetDateTimeIndex(FhirDate);

      //Assert
      Assert.AreEqual(ExpectedLow, Result.Low);
      Assert.AreEqual(ExpectedHigh, Result.High);
    }

    [Test]
    public void Test_InstantOfYearMonthDayHrMinSecOneMiliSecToIndex()
    {
      //Arrange
      var FhirDate = new Instant(new DateTimeOffset(1974, 02, 01, 12, 38, 10, 4, new TimeSpan(10, 0, 0)));

      DateTimeOffset ExpectedLow = new DateTimeOffset(1974, 02, 01, 12, 38, 10, 4, new TimeSpan(10, 0, 0));
      DateTimeOffset ExpectedHigh = new DateTimeOffset(1974, 02, 01, 12, 38, 10, 5, new TimeSpan(10, 0, 0));

      //Act
      DateTimeIndex Result = DateTimeIndexSupport.GetDateTimeIndex(FhirDate);

      //Assert
      Assert.AreEqual(ExpectedLow, Result.Low);
      Assert.AreEqual(ExpectedHigh, Result.High);
    }

    [Test]
    public void Test_InstantOfYearMonthDayHrMinSecTwoMiliSecToIndex()
    {
      //Arrange
      var FhirDate = new Instant(new DateTimeOffset(1974, 02, 01, 12, 38, 10, 22, new TimeSpan(10, 0, 0)));

      DateTimeOffset ExpectedLow = new DateTimeOffset(1974, 02, 01, 12, 38, 10, 22, new TimeSpan(10, 0, 0));
      DateTimeOffset ExpectedHigh = new DateTimeOffset(1974, 02, 01, 12, 38, 10, 23, new TimeSpan(10, 0, 0));

      //Act
      DateTimeIndex Result = DateTimeIndexSupport.GetDateTimeIndex(FhirDate);

      //Assert
      Assert.AreEqual(ExpectedLow, Result.Low);
      Assert.AreEqual(ExpectedHigh, Result.High);
    }

    [Test]
    public void Test_InstantOfYearMonthDayHrMinSecThreeMiliSecToIndex()
    {
      //Arrange
      var FhirDate = new Instant(new DateTimeOffset(1974, 02, 01, 12, 38, 10, 222, new TimeSpan(10, 0, 0)));

      DateTimeOffset ExpectedLow = new DateTimeOffset(1974, 02, 01, 12, 38, 10, 222, new TimeSpan(10, 0, 0));
      DateTimeOffset ExpectedHigh = new DateTimeOffset(1974, 02, 01, 12, 38, 10, 223, new TimeSpan(10, 0, 0));

      //Act
      DateTimeIndex Result = DateTimeIndexSupport.GetDateTimeIndex(FhirDate);

      //Assert
      Assert.AreEqual(ExpectedLow, Result.Low);
      Assert.AreEqual(ExpectedHigh, Result.High);
    }

    [Test]
    public void Test_PeriodStartAndEndToIndex()
    {
      //Arrange
      var Period = new Period(new FhirDateTime("1974-02-01T12:38:10+10:00"), new FhirDateTime("1974-02-01T12:38:20+10:00"));

      DateTimeOffset? ExpectedLow = new DateTimeOffset(1974, 02, 01, 12, 38, 10, new TimeSpan(10, 0, 0));
      DateTimeOffset? ExpectedHigh = new DateTimeOffset(1974, 02, 01, 12, 38, 20, new TimeSpan(10, 0, 0));

      //Act
      DateTimeIndex Result = DateTimeIndexSupport.GetDateTimeIndex(Period);

      //Assert
      Assert.AreEqual(ExpectedLow, Result.Low);
      Assert.AreEqual(ExpectedHigh, Result.High);
    }

    [Test]
    public void Test_PeriodStartOnlyToIndex()
    {
      //Arrange
      var Period = new Period();
      Period.StartElement = new FhirDateTime("1974-02-01T12:38:10+10:00");

      DateTimeOffset? ExpectedLow = new DateTimeOffset(1974, 02, 01, 12, 38, 10, new TimeSpan(10, 0, 0));
      DateTimeOffset? ExpectedHigh = null;

      //Act
      DateTimeIndex Result = DateTimeIndexSupport.GetDateTimeIndex(Period);

      //Assert
      Assert.AreEqual(ExpectedLow, Result.Low);
      Assert.AreEqual(ExpectedHigh, Result.High);
    }

    [Test]
    public void Test_PeriodEndOnlyToIndex()
    {
      //Arrange
      var Period = new Period();
      Period.EndElement = new FhirDateTime("1974-02-01T12:38:20+10:00");

      DateTimeOffset? ExpectedLow = null;
      DateTimeOffset? ExpectedHigh = new DateTimeOffset(1974, 02, 01, 12, 38, 20, new TimeSpan(10, 0, 0));

      //Act
      DateTimeIndex Result = DateTimeIndexSupport.GetDateTimeIndex(Period);

      //Assert
      Assert.AreEqual(ExpectedLow, Result.Low);
      Assert.AreEqual(ExpectedHigh, Result.High);
    }

    [Test]
    public void Test_PeriodNoStartOrEndOnlyToIndex()
    {
      //Arrange
      var Period = new Period();

      DateTimeOffset? ExpectedLow = null;
      DateTimeOffset? ExpectedHigh = null;

      //Act
      DateTimeIndex Result = DateTimeIndexSupport.GetDateTimeIndex(Period);

      //Assert
      Assert.AreEqual(ExpectedLow, Result.Low);
      Assert.AreEqual(ExpectedHigh, Result.High);
    }

    [Test]
    public void Test_TimingToIndex_Test1()
    {
      //Arrange
      var Timing = new Timing();

      DateTimeOffset? ExpectedLow = new DateTimeOffset(1974, 12, 25, 10, 00, 00, new TimeSpan(-5, 00, 00));
      DateTimeOffset? ExpectedHigh = new DateTimeOffset(1974, 12, 26, 11, 10, 00, new TimeSpan(-5, 00, 00));

      Timing.EventElement = new System.Collections.Generic.List<FhirDateTime>();
      var EventStart1 = new FhirDateTime(new DateTimeOffset(1974, 12, 26, 11, 00, 00, new TimeSpan(-5, 00, 00)));
      var EventStart2 = new FhirDateTime(ExpectedLow.Value);

      Timing.EventElement.Add(EventStart1);
      Timing.EventElement.Add(EventStart2);

      Timing.Repeat = new Timing.RepeatComponent();
      Timing.Repeat.Duration = new decimal(10.0);
      Timing.Repeat.DurationUnit = Timing.UnitsOfTime.Min;

      //Act
      DateTimeIndex Result = DateTimeIndexSupport.GetDateTimeIndex(Timing);

      //Assert
      Assert.AreEqual(ExpectedLow, Result.Low);
      Assert.AreEqual(ExpectedHigh, Result.High);
    }

    [Test]
    public void Test_TimingToIndex_Test2()
    {
      //Arrange
      var Timing = new Timing();

      DateTimeOffset? ExpectedLow = new DateTimeOffset(1974, 12, 25, 10, 00, 00, new TimeSpan(-5, 00, 00));

      Timing.EventElement = new System.Collections.Generic.List<FhirDateTime>();
      var EventStart1 = new FhirDateTime(new DateTimeOffset(1974, 12, 26, 11, 00, 00, new TimeSpan(-5, 00, 00)));
      var EventStart2 = new FhirDateTime(ExpectedLow.Value);

      Timing.EventElement.Add(EventStart1);
      Timing.EventElement.Add(EventStart2);

      //Act
      DateTimeIndex Result = DateTimeIndexSupport.GetDateTimeIndex(Timing);

      //Assert
      Assert.AreEqual(ExpectedLow, Result.Low);
      Assert.IsNull(Result.High);
    }

    [Test]
    public void Test_TimingToIndex_Test3()
    {
      //Arrange
      var Timing = new Timing();

      DateTimeOffset? ExpectedLow = new DateTimeOffset(1974, 12, 25, 10, 00, 00, new TimeSpan(-5, 00, 00));
      DateTimeOffset? ExpectedHigh = new DateTimeOffset(1974, 12, 26, 11, 10, 00, new TimeSpan(-5, 00, 00));

      Timing.EventElement = new System.Collections.Generic.List<FhirDateTime>();

      Timing.Repeat = new Timing.RepeatComponent();
      Timing.Repeat.Duration = new decimal(10.0);
      Timing.Repeat.DurationUnit = Timing.UnitsOfTime.Min;

      //Act
      DateTimeIndex Result = DateTimeIndexSupport.GetDateTimeIndex(Timing);

      //Assert
      Assert.IsNull(Result.Low);
      Assert.IsNull(Result.High);
    }

  }
}

using System;
using NUnit.Framework;
using Pyro.DataModel.IndexSetter;
using Pyro.DataModel.DatabaseModel.Base;
using Hl7.Fhir.Model;
using NUnit.Framework.Constraints;

namespace Pyro.Test.IndexSetters
{
  [TestFixture]
  class Test_DateTimePeriod_IndexSetters
  {
    [Test]
    public void Test_Period_DateTimePeriodIndexSetter_GoodFormat()
    {
      //Arrange
      var Period = new Period();
      var LowDateTimeOffSet = new DateTimeOffset(1974, 12, 25, 10, 35, 45, new TimeSpan(-5, 00, 00));
      var HighDateTimeOffSet = new DateTimeOffset(1974, 12, 25, 11, 35, 45, new TimeSpan(-5, 00, 00));
      Period.Start = "1974-12-25T10:35:45-05:00";
      Period.End = "1974-12-25T11:35:45-05:00";
      DateTimePeriodIndex Index = new DateTimePeriodIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(DateTimePeriodIndex)).Set(Period, Index) as DateTimePeriodIndex;

      //Assert
      Assert.AreEqual(Index.DateTimeOffsetLow, LowDateTimeOffSet);
      Assert.AreEqual(Index.DateTimeOffsetHigh, HighDateTimeOffSet);
    }

    [Test]
    public void Test_Period_DateTimePeriodIndexSetter_LowIsNull()
    {
      //Arrange
      var Period = new Period();
      var HighDateTimeOffSet = new DateTimeOffset(1974, 12, 25, 11, 35, 45, new TimeSpan(-5, 00, 00));
      Period.StartElement = null;
      Period.End = "1974-12-25T11:35:45-05:00";
      DateTimePeriodIndex Index = new DateTimePeriodIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(DateTimePeriodIndex)).Set(Period, Index) as DateTimePeriodIndex;

      //Assert
      Assert.IsNull(Index.DateTimeOffsetLow);
      Assert.AreEqual(Index.DateTimeOffsetHigh, HighDateTimeOffSet);
    }

    [Test]
    public void Test_Period_DateTimePeriodIndexSetter_HighIsNull()
    {
      //Arrange
      var Period = new Period();
      var LowDateTimeOffSet = new DateTimeOffset(1974, 12, 25, 10, 35, 45, new TimeSpan(-5, 00, 00));

      Period.Start = "1974-12-25T10:35:45-05:00";
      Period.EndElement = null;
      DateTimePeriodIndex Index = new DateTimePeriodIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(DateTimePeriodIndex)).Set(Period, Index) as DateTimePeriodIndex;

      //Assert      
      Assert.AreEqual(Index.DateTimeOffsetLow, LowDateTimeOffSet);
      Assert.IsNull(Index.DateTimeOffsetHigh);
    }


    [Test]
    public void Test_Period_DateTimePeriodIndexSetter_LowAndHighAreNull()
    {
      //Arrange
      var Period = new Period();
      var LowDateTimeOffSet = new DateTimeOffset(1974, 12, 25, 10, 35, 45, new TimeSpan(-5, 00, 00));

      Period.StartElement = null;
      Period.EndElement = null;
      DateTimePeriodIndex Index = new DateTimePeriodIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(DateTimePeriodIndex)).Set(Period, Index) as DateTimePeriodIndex;

      //Assert            
      Assert.IsNull(Index);
    }


    [Test]
    public void Test_Period_DateTimePeriodIndexSetter_NullReferance()
    {
      //Arrange      
      Period Period = null;
      DateTimePeriodIndex Index = new DateTimePeriodIndex();

      //Act      
      ActualValueDelegate<DateTimePeriodIndex> testDelegate = () => IndexSetterFactory.Create(typeof(DateTimePeriodIndex)).Set(Period, Index) as DateTimePeriodIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<ArgumentNullException>());
    }


    [Test]
    public void Test_Period_DateTimePeriodIndexSetter_BadLowFormat()
    {
      //Arrange
      var Period = new Period();
      var LowDateTimeOffSet = new DateTimeOffset(1974, 12, 25, 10, 35, 45, new TimeSpan(-5, 00, 00));
      var HighDateTimeOffSet = new DateTimeOffset(1974, 12, 25, 11, 35, 45, new TimeSpan(-5, 00, 00));
      Period.Start = "1974-12-25TXXX10:35:45-05:00";
      Period.End = "1974-12-25T11:35:45-05:00";
      DateTimePeriodIndex Index = new DateTimePeriodIndex();

      //Act      
      ActualValueDelegate<DateTimePeriodIndex> testDelegate = () => IndexSetterFactory.Create(typeof(DateTimePeriodIndex)).Set(Period, Index) as DateTimePeriodIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<FormatException>());
    }

    [Test]
    public void Test_Period_DateTimePeriodIndexSetter_BadHighStringFormat()
    {
      //Arrange
      var Period = new Period();
      var LowDateTimeOffSet = new DateTimeOffset(1974, 12, 25, 10, 35, 45, new TimeSpan(-5, 00, 00));
      var HighDateTimeOffSet = new DateTimeOffset(1974, 12, 25, 11, 35, 45, new TimeSpan(-5, 00, 00));
      Period.Start = "1974-12-25T10:35:45-05:00";
      Period.End = "1974-12-25T11XXX:35:45-05:00";
      DateTimePeriodIndex Index = new DateTimePeriodIndex();

      //Act      
      ActualValueDelegate<DateTimePeriodIndex> testDelegate = () => IndexSetterFactory.Create(typeof(DateTimePeriodIndex)).Set(Period, Index) as DateTimePeriodIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<FormatException>());
    }

    [Test]
    public void Test_Period_DateTimePeriodIndexSetter_BadStringFormat()
    {
      //Arrange
      var Period = new Period();
      Period.Start = "1974-12-25XXXT10:35:45-05:00";
      Period.End = "1974-12-25T11XXX:35:45-05:00";
      DateTimePeriodIndex Index = new DateTimePeriodIndex();

      //Act
      ActualValueDelegate<DateTimePeriodIndex> testDelegate = () => IndexSetterFactory.Create(typeof(DateTimePeriodIndex)).Set(Period, Index) as DateTimePeriodIndex; ;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<FormatException>());
    }

    [Test]
    public void Test_Timing_DateTimePeriodIndexSetter_GoodFormat()
    {
      //Arrange
      var Timing = new Timing();
      DateTimePeriodIndex Index = new DateTimePeriodIndex();

      var LowDate = new DateTimeOffset(1974, 12, 25, 10, 00, 00, new TimeSpan(-5, 00, 00));
      var HighDate = new DateTimeOffset(1974, 12, 26, 11, 10, 00, new TimeSpan(-5, 00, 00));

      Timing.EventElement = new System.Collections.Generic.List<FhirDateTime>();
      var EventStart1 = new FhirDateTime(new DateTimeOffset(1974, 12, 26, 11, 00, 00, new TimeSpan(-5, 00, 00)));
      var EventStart2 = new FhirDateTime(LowDate);

      Timing.EventElement.Add(EventStart1);
      Timing.EventElement.Add(EventStart2);


      Timing.Repeat = new Timing.RepeatComponent();
      Timing.Repeat.Duration = new decimal(10.0);
      Timing.Repeat.DurationUnit = Timing.UnitsOfTime.Min;

      //Calculation (ToDo: This still needs review)
      //2min Duration + last EventStartdate (11:00am) = 11:20am 26/12/1974


      //Act
      Index = IndexSetterFactory.Create(typeof(DateTimePeriodIndex)).Set(Timing, Index) as DateTimePeriodIndex;

      //Assert      
      Assert.AreEqual(Index.DateTimeOffsetLow, LowDate);
      Assert.AreEqual(Index.DateTimeOffsetHigh, HighDate);
    }

    [Test]
    public void Test_Timing_DateTimePeriodIndexSetter_HighIsNull()
    {
      //Arrange
      var Timing = new Timing();
      DateTimePeriodIndex Index = new DateTimePeriodIndex();

      var LowDate = new DateTimeOffset(1974, 12, 25, 10, 00, 00, new TimeSpan(-5, 00, 00));
      var HighDate = new DateTimeOffset(1974, 12, 26, 11, 10, 00, new TimeSpan(-5, 00, 00));

      Timing.EventElement = new System.Collections.Generic.List<FhirDateTime>();
      var EventStart1 = new FhirDateTime(new DateTimeOffset(1974, 12, 26, 11, 00, 00, new TimeSpan(-5, 00, 00)));
      var EventStart2 = new FhirDateTime(LowDate);

      Timing.EventElement.Add(EventStart1);
      Timing.EventElement.Add(EventStart2);

      //Act
      Index = IndexSetterFactory.Create(typeof(DateTimePeriodIndex)).Set(Timing, Index) as DateTimePeriodIndex;

      //Assert      
      Assert.AreEqual(Index.DateTimeOffsetLow, LowDate);
      Assert.IsNull(Index.DateTimeOffsetHigh);
    }

    [Test]
    public void Test_Timing_DateTimePeriodIndexSetter_NoLowDate()
    {
      //Arrange
      var Timing = new Timing();
      DateTimePeriodIndex Index = new DateTimePeriodIndex();

      Timing.EventElement = new System.Collections.Generic.List<FhirDateTime>();

      Timing.Repeat = new Timing.RepeatComponent();
      Timing.Repeat.Duration = new decimal(10.0);
      Timing.Repeat.DurationUnit = Timing.UnitsOfTime.Min;

      //Act
      Index = IndexSetterFactory.Create(typeof(DateTimePeriodIndex)).Set(Timing, Index) as DateTimePeriodIndex;

      //Assert            
      Assert.IsNull(Index);
    }

    [Test]
    public void Test_Timing_DateTimePeriodIndexSetter_TimingIsNull()
    {
      //Arrange
      Timing Timing = null;
      DateTimePeriodIndex Index = new DateTimePeriodIndex();

      //Act      
      ActualValueDelegate<DateTimePeriodIndex> testDelegate = () => IndexSetterFactory.Create(typeof(DateTimePeriodIndex)).Set(Timing, Index) as DateTimePeriodIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<ArgumentNullException>());
    }

    [Test]
    public void Test_FhirString_DateTimePeriodIndexSetter_GoodFormat_NoRange()
    {
      //Arrange
      var FhirString = new FhirString();
      var DateTimeOffSet = new DateTimeOffset(1974, 12, 25, 10, 35, 45, new TimeSpan(-5, 00, 00));
      
      FhirString.Value = "1974-12-25T10:35:45-05:00";
      
      DateTimePeriodIndex Index = new DateTimePeriodIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(DateTimePeriodIndex)).Set(FhirString, Index) as DateTimePeriodIndex;

      //Assert
      Assert.AreEqual(Index.DateTimeOffsetLow, DateTimeOffSet);
      Assert.AreEqual(Index.DateTimeOffsetHigh, DateTimeOffSet);

    }

    [Test]
    public void Test_FhirString_DateTimePeriodIndexSetter_BadFormat()
    {
      //Arrange
      var FhirString = new FhirString();
      var DateTimeOffSet = new DateTimeOffset(1974, 12, 25, 10, 35, 45, new TimeSpan(-5, 00, 00));

      FhirString.Value = "1974-12-25T25:35:45-05:00";

      DateTimePeriodIndex Index = new DateTimePeriodIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(DateTimePeriodIndex)).Set(FhirString, Index) as DateTimePeriodIndex;

      //Assert
      Assert.IsNull(Index);      
    }


    [Test]
    public void Test_FhirString_DateTimePeriodIndexSetter_GoodFormat_WithRange_FormatOne()
    {
      //Arrange
      var FhirString = new FhirString();
      var DateTimeOffSetLow = new DateTimeOffset(1974, 12, 25, 10, 35, 45, new TimeSpan(-5, 00, 00));
      var DateTimeOffSetHigh = new DateTimeOffset(1974, 12, 25, 11, 00, 45, new TimeSpan(-5, 00, 00));

      FhirString.Value = "1974-12-25T10:35:45-05:00 - 1974-12-25T11:00:45-05:00";

      DateTimePeriodIndex Index = new DateTimePeriodIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(DateTimePeriodIndex)).Set(FhirString, Index) as DateTimePeriodIndex;

      //Assert
      Assert.AreEqual(Index.DateTimeOffsetLow, DateTimeOffSetLow);
      Assert.AreEqual(Index.DateTimeOffsetHigh, DateTimeOffSetHigh);

    }

    [Test]
    public void Test_FhirString_DateTimePeriodIndexSetter_GoodFormat_WithRange_FormatTwo()
    {
      //Arrange
      var FhirString = new FhirString();
      var DateTimeOffSetLow = new DateTimeOffset(1974, 12, 25, 10, 35, 45, new TimeSpan(-5, 00, 00));
      var DateTimeOffSetHigh = new DateTimeOffset(1974, 12, 25, 11, 00, 45, new TimeSpan(-5, 00, 00));

      FhirString.Value = "1974-12-25T10:35:45-05:00 1974-12-25T11:00:45-05:00";

      DateTimePeriodIndex Index = new DateTimePeriodIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(DateTimePeriodIndex)).Set(FhirString, Index) as DateTimePeriodIndex;

      //Assert
      Assert.AreEqual(Index.DateTimeOffsetLow, DateTimeOffSetLow);
      Assert.AreEqual(Index.DateTimeOffsetHigh, DateTimeOffSetHigh);

    }

    [Test]
    public void Test_FhirString_DateTimePeriodIndexSetter_BadFormat_WithRange()
    {
      //Arrange
      var FhirString = new FhirString();
      var DateTimeOffSetLow = new DateTimeOffset(1974, 12, 25, 10, 35, 45, new TimeSpan(-5, 00, 00));
      var DateTimeOffSetHigh = new DateTimeOffset(1974, 12, 25, 10, 35, 45, new TimeSpan(-5, 00, 00));

      FhirString.Value = "1974-12-25T10:35:45-05:00 to 1974-12-25T11:00:45-05:00";

      DateTimePeriodIndex Index = new DateTimePeriodIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(DateTimePeriodIndex)).Set(FhirString, Index) as DateTimePeriodIndex;

      //Assert
      Assert.IsNull(Index);      

    }

    [Test]
    public void Test_FhirDateTime_DateTimePeriodIndexSetter_GoodFormat_NoRange()
    {
      //Arrange
      
      var DateTimeOffSet = new DateTimeOffset(1974, 12, 25, 10, 35, 45, new TimeSpan(-5, 00, 00));
      var FhirDateTime = new FhirDateTime(DateTimeOffSet);
      
      DateTimePeriodIndex Index = new DateTimePeriodIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(DateTimePeriodIndex)).Set(FhirDateTime, Index) as DateTimePeriodIndex;

      //Assert
      Assert.AreEqual(Index.DateTimeOffsetLow, DateTimeOffSet);
      Assert.AreEqual(Index.DateTimeOffsetHigh, DateTimeOffSet);

    }


  }
}

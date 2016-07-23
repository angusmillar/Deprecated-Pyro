using System;
using NUnit.Framework;
using Blaze.DataModel.IndexSetter;
using Blaze.DataModel.DatabaseModel.Base;
using Hl7.Fhir.Model;
using NUnit.Framework.Constraints;

namespace Blaze.Test.IndexSetters
{
  [TestFixture]
  class Test_Date_IndexSetters
  {
    [Test]
    public void Test_Date_DateIndexSetter_GoodFormat()
    {
      //Arrange
      var Date = new Date("1974-12-25");
      DateIndex Index = new DateIndex();

      //Act
      IndexSetterFactory.Create(typeof(DateIndex)).Set(Date, Index);

      //Assert
      Assert.AreEqual(new DateTimeOffset(1974, 12, 25, 00, 00, 00, new TimeSpan()), Index.DateTimeOffset);
    }

    [Test]
    public void Test_Date_DateIndexSetter_BadFormat()
    {

      //Arrange
      var Date = new Date("25-12-1974");
      DateIndex Index = new DateIndex();

      //Act
      ActualValueDelegate<DateIndex> testDelegate = () => IndexSetterFactory.Create(typeof(DateIndex)).Set(Date, Index) as DateIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<FormatException>());

    }


    [Test]
    public void Test_FhirDateTime_DateIndexSetter_GoodFormat()
    {
      //Arrange
      var FhirDateTime = new FhirDateTime("1974-12-25T14:35:45-05:00");
      DateIndex Index = new DateIndex();
      //Act
      IndexSetterFactory.Create(typeof(DateIndex)).Set(FhirDateTime, Index);

      //Assert
      Assert.AreEqual(new DateTimeOffset(1974, 12, 25, 14, 35, 45, new TimeSpan(-05, 00, 00)), Index.DateTimeOffset);
    }

    [Test]
    public void Test_FhirDateTime_DateIndexSetter_BadFormat()
    {
      ////Arrange
      //var FhirDateTime = new FhirDateTime("1974-12-25T14:3554:45-05:00");

      ////Act
      //ActualValueDelegate<DateIndex> testDelegate = () => IndexSetterFactory.Create(typeof(DateIndex)).Set(FhirDateTime) as DateIndex;

      ////Assert
      //Assert.That(testDelegate, Throws.TypeOf<FormatException>());

    }


    [Test]
    public void Test_FhirString_DateIndexSetter_DateTime_GoodFormat()
    {
      //Arrange
      var FhirString = new FhirString("1974-12-25T14:35:45-05:00");
      DateIndex Index = new DateIndex();

      //Act
      IndexSetterFactory.Create(typeof(DateIndex)).Set(FhirString, Index);

      //Assert
      Assert.AreEqual(new DateTimeOffset(1974, 12, 25, 14, 35, 45, new TimeSpan(-05, 00, 00)), Index.DateTimeOffset);
    }

    [Test]
    public void Test_FhirString_DateIndexSetter_Date_GoodFormat()
    {
      //Arrange
      var FhirString = new FhirString("1974-12-25");
      DateIndex Index = new DateIndex();

      //Act
      IndexSetterFactory.Create(typeof(DateIndex)).Set(FhirString, Index);

      //Assert
      Assert.AreEqual(new DateTimeOffset(1974, 12, 25, 00, 00, 00, new TimeSpan(0)), Index.DateTimeOffset);
    }

    [Test]
    public void Test_FhirString_DateIndexSetter_BadFormat()
    {
      //Arrange
      var FhirString = new FhirString("1974XX-12-25T14:3554:45-05:00");
      DateIndex DateIndex = new DateIndex();


      //Act
      DateIndex = IndexSetterFactory.Create(typeof(DateIndex)).Set(FhirString, DateIndex) as DateIndex;

      //Assert
      Assert.IsNull(DateIndex);

    }

    [Test]
    public void Test_Instant_DateIndexSetter_GoodFormat()
    {
      //Arrange
      var Instant = new Instant(new DateTimeOffset(1974, 12, 25, 14, 35, 45, new TimeSpan(-05, 00, 00)));
      DateIndex Index = new DateIndex();

      //Act
      IndexSetterFactory.Create(typeof(DateIndex)).Set(Instant, Index);

      //Assert
      Assert.AreEqual(new DateTimeOffset(1974, 12, 25, 14, 35, 45, new TimeSpan(-05, 00, 00)), Index.DateTimeOffset);
    }

    [Test]
    public void Test_Instant_DateIndexSetter_IsNull()
    {
      //Arrange
      var Instant = new Instant(null);
      DateIndex Index = new DateIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(DateIndex)).Set(Instant, Index) as DateIndex;

      //Assert
      Assert.IsNull(Index);

    }



  }
}

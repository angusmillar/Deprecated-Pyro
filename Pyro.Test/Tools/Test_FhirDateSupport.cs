using System;
using NUnit.Framework;
using Pyro.Common.Tools;
using Hl7.Fhir.Model;
using NUnit.Framework.Constraints;

namespace Pyro.Test.IndexSetters
{
  [TestFixture]
  [Category("Tools")]
  class Test_FhirDateSupport
  {
    [Test]
    public void Test_FhirDateToDateIntegerYearMonthDay()
    {
      //Arrange
      var FhirDate = new Date("1974-12-25");
      int Expected = 19741225;


      //Act
      int? Result = FhirTimeSupport.ConvertDateToInteger(FhirDate);

      //Assert
      Assert.AreEqual(Expected, Result.Value);
    }

    [Test]
    public void Test_FhirDateToDateIntegerYearMonth()
    {
      //Arrange
      var FhirDate = new Date("1974-12");
      int Expected = 19741200;


      //Act
      int? Result = FhirTimeSupport.ConvertDateToInteger(FhirDate);

      //Assert
      Assert.AreEqual(Expected, Result.Value);
    }

    [Test]
    public void Test_FhirDateToDateIntegerYear()
    {
      //Arrange
      var FhirDate = new Date("1974");
      int Expected = 19740000;


      //Act
      int? Result = FhirTimeSupport.ConvertDateToInteger(FhirDate);

      //Assert
      Assert.AreEqual(Expected, Result.Value);
    }


    [Test]
    public void Test_DateTimeToDateIntegerYearMonthDay()
    {
      //Arrange
      var FhirDate = new DateTime(1974, 12, 25);
      int Expected = 19741225;

      //Act
      int? Result = FhirTimeSupport.ConvertDateToInteger(FhirDate, FhirTimeSupport.DatePrecision.Day);

      //Assert
      Assert.AreEqual(Expected, Result.Value);
    }

    [Test]
    public void Test_DateTimeToDateIntegerYearMonth()
    {
      //Arrange
      var FhirDate = new DateTime(1974, 12, 1);
      int Expected = 19741200;

      //Act
      int? Result = FhirTimeSupport.ConvertDateToInteger(FhirDate, FhirTimeSupport.DatePrecision.Month);

      //Assert
      Assert.AreEqual(Expected, Result.Value);
    }

    [Test]
    public void Test_DateTimeToDateIntegerYear()
    {
      //Arrange
      var FhirDate = new DateTime(1974, 1, 1);
      int Expected = 19740000;

      //Act
      int? Result = FhirTimeSupport.ConvertDateToInteger(FhirDate, FhirTimeSupport.DatePrecision.Year);

      //Assert
      Assert.AreEqual(Expected, Result.Value);
    }

    [Test]
    public void Test_DatePrecision_Year()
    {
      //Arrange
      int DateInt = 19740000;
      FhirTimeSupport.DatePrecision Expected = FhirTimeSupport.DatePrecision.Year;

      //Act
      FhirTimeSupport.DatePrecision Result = FhirTimeSupport.GetIntegerDatePrecision(DateInt);

      //Assert
      Assert.AreEqual(Expected, Result);
    }

    [Test]
    public void Test_DatePrecision_Month()
    {
      //Arrange
      int DateInt = 19740900;
      FhirTimeSupport.DatePrecision Expected = FhirTimeSupport.DatePrecision.Month;

      //Act
      FhirTimeSupport.DatePrecision Result = FhirTimeSupport.GetIntegerDatePrecision(DateInt);

      //Assert
      Assert.AreEqual(Expected, Result);
    }

    [Test]
    public void Test_DatePrecision_Day()
    {
      //Arrange
      int DateInt = 19740930;
      FhirTimeSupport.DatePrecision Expected = FhirTimeSupport.DatePrecision.Day;

      //Act
      FhirTimeSupport.DatePrecision Result = FhirTimeSupport.GetIntegerDatePrecision(DateInt);

      //Assert
      Assert.AreEqual(Expected, Result);
    }


    [Test]
    public void Test_AddDay_To_FullDateInteger()
    {
      //Arrange
      int DateInt = 19740930;
      int Expected = 19741001;

      //Act
      int Result = FhirTimeSupport.AddToIntegerDate(DateInt, 1, FhirTimeSupport.DatePrecision.Day);

      //Assert
      Assert.AreEqual(Expected, Result);
    }

    [Test]
    public void Test_AddMonth_To_FullDateInteger()
    {
      //Arrange
      int DateInt = 19740930;
      int Expected = 19741030;

      //Act
      int Result = FhirTimeSupport.AddToIntegerDate(DateInt, 1, FhirTimeSupport.DatePrecision.Month);

      //Assert
      Assert.AreEqual(Expected, Result);
    }

    [Test]
    public void Test_AddYear_To_FullDateInteger()
    {
      //Arrange
      int DateInt = 19740930;
      int Expected = 19750930;

      //Act
      int Result = FhirTimeSupport.AddToIntegerDate(DateInt, 1, FhirTimeSupport.DatePrecision.Year);

      //Assert
      Assert.AreEqual(Expected, Result);
    }


    [Test]
    public void Test_AddDay_To_MonthDateInteger()
    {
      //Arrange
      int DateInt = 19740900;
      int Expected = 19741000;

      //Act
      int Result = FhirTimeSupport.AddToIntegerDate(DateInt, 31, FhirTimeSupport.DatePrecision.Day);

      //Assert
      Assert.AreEqual(Expected, Result);
    }

    [Test]
    public void Test_AddMonth_To_MonthDateInteger()
    {
      //Arrange
      int DateInt = 19740900;
      int Expected = 19750100;

      //Act
      int Result = FhirTimeSupport.AddToIntegerDate(DateInt, 4, FhirTimeSupport.DatePrecision.Month);

      //Assert
      Assert.AreEqual(Expected, Result);
    }

    [Test]
    public void Test_AddYear_To_MonthDateInteger()
    {
      //Arrange
      int DateInt = 19740900;
      int Expected = 19750900;

      //Act
      int Result = FhirTimeSupport.AddToIntegerDate(DateInt, 1, FhirTimeSupport.DatePrecision.Year);

      //Assert
      Assert.AreEqual(Expected, Result);
    }



  }
}

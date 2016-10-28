using System;
using NUnit.Framework;
using Pyro.DataModel.IndexSetter;
using Pyro.DataModel.DatabaseModel.Base;
using Hl7.Fhir.Model;
using NUnit.Framework.Constraints;

namespace Pyro.Test.IndexSetters
{
  [TestFixture]
  class Test_Date_IndexSetters
  {
    [Test]
    public void Test_Date_DateIndexSetter_GoodFormat_FullDate()
    {
      //Arrange
      var Date = new Date("1974-12-25");
      DateIndex Index = new DateIndex();

      //Act
      IndexSetterFactory.Create(typeof(DateIndex)).Set(Date, Index);

      //Assert
      Assert.AreEqual(19741225, Index.Date);
    }

    [Test]
    public void Test_Date_DateIndexSetter_GoodFormat_YearMonth()
    {
      //Arrange
      var Date = new Date("1974-12");
      DateIndex Index = new DateIndex();

      //Act
      IndexSetterFactory.Create(typeof(DateIndex)).Set(Date, Index);

      //Assert
      Assert.AreEqual(19741200, Index.Date);
    }

    [Test]
    public void Test_Date_DateIndexSetter_GoodFormat_Year()
    {
      //Arrange
      var Date = new Date("1974");
      DateIndex Index = new DateIndex();

      //Act
      IndexSetterFactory.Create(typeof(DateIndex)).Set(Date, Index);

      //Assert
      Assert.AreEqual(19740000, Index.Date);
    }

    [Test]
    public void Test_Date_DateIndexSetter_BadFormat_SyntaxError()
    {
      //Arrange
      var Date = new Date("197X-12-25");
      DateIndex Index = new DateIndex();

      //Act
      ActualValueDelegate<DateIndex> testDelegate = () => IndexSetterFactory.Create(typeof(DateIndex)).Set(Date, Index) as DateIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<FormatException>());

    }    

    [Test]
    public void Test_Date_DateIndexSetter_BadFormat_SemanticError()
    {
      //Arrange
      var Date = new Date("1974-25-25");
      DateIndex Index = new DateIndex();

      //Act
      ActualValueDelegate<DateIndex> testDelegate = () => IndexSetterFactory.Create(typeof(DateIndex)).Set(Date, Index) as DateIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<FormatException>());

    }

  }
}

using System;
using NUnit.Framework;
using Pyro.DataModel.IndexSetter;
using Pyro.DataModel.DatabaseModel.Base;
using Hl7.Fhir.Model;
using NUnit.Framework.Constraints;

namespace Pyro.Test.IndexSetters
{
  [TestFixture]
  [Category("IndexSetters")]
  class Test_Number_IndexSetter
  {
    [Test]
    public void Test_Duration_NumberIndexSetter_GoodFormat()
    {
      //Arrange
      decimal Value = 10.5M;
      var Comparator = Quantity.QuantityComparator.GreaterOrEqual;
      var Duration = new Duration();
      Duration.Value = Value;
      Duration.Comparator = Comparator;
      NumberIndex Index = new NumberIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(NumberIndex)).Set(Duration, Index) as NumberIndex;

      //Assert
      Assert.AreEqual(Index.Quantity, Value);
      Assert.AreEqual(Index.Comparator, Comparator);
    }

    [Test]
    public void Test_Duration_NumberIndexSetter_GoodFormatNoComparator()
    {
      //Arrange
      decimal Value = 123.500M;
      var Duration = new Duration();
      Duration.Value = Value;

      NumberIndex Index = new NumberIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(NumberIndex)).Set(Duration, Index) as NumberIndex;

      //Assert
      Assert.AreEqual(Index.Quantity, Value);
      Assert.IsNull(Index.Comparator);
    }

    [Test]
    public void Test_Duration_NumberIndexSetter_NoNumberValue()
    {
      //Arrange      
      var Comparator = Quantity.QuantityComparator.GreaterOrEqual;
      var Duration = new Duration();
      Duration.Comparator = Comparator;
      NumberIndex Index = new NumberIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(NumberIndex)).Set(Duration, Index) as NumberIndex;

      //Assert      
      Assert.IsNull(Index);
    }

    [Test]
    public void Test_Duration_NumberIndexSetter_DurationIsNull()
    {
      //Arrange            
      Duration Duration = null;
      NumberIndex Index = new NumberIndex();

      //Act
      ActualValueDelegate<NumberIndex> testDelegate = () => IndexSetterFactory.Create(typeof(NumberIndex)).Set(Duration, Index) as NumberIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<ArgumentNullException>());
    }

    [Test]
    public void Test_Integer_NumberIndexSetter_GoodFormat()
    {
      //Arrange
      int Value = 13;
      var Integer = new Integer();
      Integer.Value = Value;

      NumberIndex Index = new NumberIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(NumberIndex)).Set(Integer, Index) as NumberIndex;

      //Assert
      Assert.AreEqual(Index.Quantity, Value);
      Assert.IsNull(Index.Comparator);
    }

    [Test]
    public void Test_Integer_NumberIndexSetter_Value_IsNull()
    {
      //Arrange      
      var Integer = new Integer();
      Integer.Value = null;

      NumberIndex Index = new NumberIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(NumberIndex)).Set(Integer, Index) as NumberIndex;

      //Assert
      Assert.IsNull(Index);
    }

    [Test]
    public void Test_Integer_NumberIndexSetter_Integer_IsNull()
    {
      //Arrange      
      Integer Integer = null;
      NumberIndex Index = new NumberIndex();

      //Act
      ActualValueDelegate<NumberIndex> testDelegate = () => IndexSetterFactory.Create(typeof(NumberIndex)).Set(Integer, Index) as NumberIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<ArgumentNullException>());
    }

    [Test]
    public void Test_PositiveInt_NumberIndexSetter_GoodFormat()
    {
      //Arrange
      int Value = 13;
      var PositiveInt = new PositiveInt();
      PositiveInt.Value = Value;

      NumberIndex Index = new NumberIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(NumberIndex)).Set(PositiveInt, Index) as NumberIndex;

      //Assert
      Assert.AreEqual(Index.Quantity, Value);
      Assert.IsNull(Index.Comparator);
    }

    [Test]
    public void Test_PositiveInt_NumberIndexSetter_BadFormat()
    {
      //Arrange
      int Value = -13;
      var PositiveInt = new PositiveInt();
      PositiveInt.Value = Value;

      NumberIndex Index = new NumberIndex();

      //Act
      ActualValueDelegate<NumberIndex> testDelegate = () => IndexSetterFactory.Create(typeof(NumberIndex)).Set(PositiveInt, Index) as NumberIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<FormatException>());
    }

    [Test]
    public void Test_PositiveInt_NumberIndexSetter_PositiveInt_IsNull()
    {
      //Arrange      
      PositiveInt PositiveInt = null;

      NumberIndex Index = new NumberIndex();

      //Act
      ActualValueDelegate<NumberIndex> testDelegate = () => IndexSetterFactory.Create(typeof(NumberIndex)).Set(PositiveInt, Index) as NumberIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<ArgumentNullException>());
    }

    public void Test_PositiveInt_NumberIndexSetter_Value_IsNull()
    {
      //Arrange
      var PositiveInt = new PositiveInt();
      PositiveInt.Value = null;

      NumberIndex Index = new NumberIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(NumberIndex)).Set(PositiveInt, Index) as NumberIndex;

      //Assert      
      Assert.IsNull(Index);
    }


  }
}

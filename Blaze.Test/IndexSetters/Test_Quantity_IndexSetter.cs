using System;
using NUnit.Framework;
using Blaze.DataModel.IndexSetter;
using Blaze.DataModel.DatabaseModel.Base;
using Hl7.Fhir.Model;
using NUnit.Framework.Constraints;

namespace Blaze.Test.IndexSetters
{
  [TestFixture]
  class Test_Quantity_IndexSetter
  {
    [Test]
    public void Test_Quantity_NumberIndexSetter_GoodFormat()
    {
      //Arrange
      decimal Value = 10.5M;
      var Comparator = Hl7.Fhir.Model.Quantity.QuantityComparator.GreaterOrEqual;
      var Code = "ABC";
      var System = "www.SomeCodeSystem.com";
      var Quantity = new Quantity();
      Quantity.Value = Value;
      Quantity.Comparator = Comparator;
      Quantity.Code = Code;
      Quantity.System = System;
      QuantityIndex Index = new QuantityIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(QuantityIndex)).Set(Quantity, Index) as QuantityIndex;

      //Assert
      Assert.AreEqual(Index.Quantity, Value);
      Assert.AreEqual(Index.Comparator, Comparator);
      Assert.AreEqual(Index.Code, Code);
      Assert.AreEqual(Index.System, System);
    }

    [Test]
    public void Test_Quantity_NumberIndexSetter_Code_IsNull()
    {
      //Arrange
      decimal Value = 10.5M;
      var Comparator = Hl7.Fhir.Model.Quantity.QuantityComparator.GreaterOrEqual;      
      var System = "www.SomeCodeSystem.com";
      var Quantity = new Quantity();
      Quantity.Value = Value;
      Quantity.Comparator = Comparator;
      Quantity.Code = null;
      Quantity.System = System;
      QuantityIndex Index = new QuantityIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(QuantityIndex)).Set(Quantity, Index) as QuantityIndex;

      //Assert
      Assert.AreEqual(Index.Quantity, Value);
      Assert.AreEqual(Index.Comparator, Comparator);
      Assert.IsNull(Index.Code);
      Assert.AreEqual(Index.System, System);
    }

    [Test]
    public void Test_Quantity_NumberIndexSetter_System_IsNull()
    {
      //Arrange
      decimal Value = 10.5M;
      var Comparator = Hl7.Fhir.Model.Quantity.QuantityComparator.GreaterOrEqual;       
      var Quantity = new Quantity();
      Quantity.Value = Value;
      Quantity.Comparator = Comparator;
      Quantity.Code = null;
      Quantity.System = null;
      QuantityIndex Index = new QuantityIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(QuantityIndex)).Set(Quantity, Index) as QuantityIndex;

      //Assert
      Assert.AreEqual(Index.Quantity, Value);
      Assert.AreEqual(Index.Comparator, Comparator);
      Assert.IsNull(Index.Code);
      Assert.IsNull(Index.System);
    }

    [Test]
    public void Test_Quantity_NumberIndexSetter_Comparator_IsNull()
    {
      //Arrange
      decimal Value = 10.5M;      
      var Code = "ABC";
      var System = "www.SomeCodeSystem.com";
      var Quantity = new Quantity();
      Quantity.Value = Value;
      Quantity.Comparator = null;
      Quantity.Code = Code;
      Quantity.System = System;
      QuantityIndex Index = new QuantityIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(QuantityIndex)).Set(Quantity, Index) as QuantityIndex;

      //Assert
      Assert.AreEqual(Index.Quantity, Value);
      Assert.IsNull(Index.Comparator);
      Assert.AreEqual(Index.Code, Code);
      Assert.AreEqual(Index.System, System);
    }

    [Test]
    public void Test_Quantity_NumberIndexSetter_Value_IsNull()
    {
      //Arrange
      var Comparator = Hl7.Fhir.Model.Quantity.QuantityComparator.GreaterOrEqual;
      var Code = "ABC";
      var System = "www.SomeCodeSystem.com";
      var Quantity = new Quantity();
      Quantity.Value = null;
      Quantity.Comparator = Comparator;
      Quantity.Code = Code;
      Quantity.System = System;
      QuantityIndex Index = new QuantityIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(QuantityIndex)).Set(Quantity, Index) as QuantityIndex;

      //Assert
      Assert.IsNull(Index);
    }

    [Test]
    public void Test_Quantity_NumberIndexSetter_Quantity_IsNull()
    {
      //Arrange
      Quantity Quantity = null;
      QuantityIndex Index = new QuantityIndex();

      //Act      
      ActualValueDelegate<QuantityIndex> testDelegate = () => IndexSetterFactory.Create(typeof(QuantityIndex)).Set(Quantity, Index) as QuantityIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<ArgumentNullException>());
    }


    [Test]
    public void Test_SimpleQuantity_NumberIndexSetter_GoodFormat()
    {
      //Arrange
      decimal Value = 145.523M;      
      var Code = "ABC";
      var System = "www.SomeCodeSystem.com";
      var Quantity = new SimpleQuantity();
      Quantity.Value = Value;      
      Quantity.Code = Code;
      Quantity.System = System;
      QuantityIndex Index = new QuantityIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(QuantityIndex)).Set(Quantity, Index) as QuantityIndex;

      //Assert
      Assert.AreEqual(Index.Quantity, Value);
      Assert.IsNull(Index.Comparator);
      Assert.AreEqual(Index.Code, Code);
      Assert.AreEqual(Index.System, System);
    }

    [Test]
    public void Test_SimpleQuantity_NumberIndexSetter_Comparator_IsSet()
    {
      //Arrange
      decimal Value = 145.523M;
      var Comparator = Hl7.Fhir.Model.Quantity.QuantityComparator.GreaterOrEqual;
      var Code = "ABC";
      var System = "www.SomeCodeSystem.com";
      var Quantity = new SimpleQuantity();
      Quantity.Value = Value;
      Quantity.Code = Code;
      Quantity.System = System;
      Quantity.Comparator = Comparator;
      QuantityIndex Index = new QuantityIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(QuantityIndex)).Set(Quantity, Index) as QuantityIndex;

      //Assert
      Assert.AreEqual(Index.Quantity, Value);
      Assert.IsNull(Index.Comparator);
      Assert.AreEqual(Index.Code, Code);
      Assert.AreEqual(Index.System, System);
    }

    [Test]
    public void Test_SimpleQuantity_NumberIndexSetter_Comparator_Code_IsNull()
    {
      //Arrange
      decimal Value = 145.523M;           
      var System = "www.SomeCodeSystem.com";
      var Quantity = new SimpleQuantity();
      Quantity.Value = Value;
      Quantity.Code = null;
      Quantity.System = System;
     
      QuantityIndex Index = new QuantityIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(QuantityIndex)).Set(Quantity, Index) as QuantityIndex;

      //Assert
      Assert.AreEqual(Index.Quantity, Value);
      Assert.IsNull(Index.Comparator);
      Assert.IsNull(Index.Code);
      Assert.AreEqual(Index.System, System);
    }

    [Test]
    public void Test_SimpleQuantity_NumberIndexSetter_Comparator_System_IsNull()
    {
      //Arrange
      decimal Value = 145.523M;
      var Code = "ABC";      
      var Quantity = new SimpleQuantity();
      Quantity.Value = Value;
      Quantity.Code = Code;
      Quantity.System = null;

      QuantityIndex Index = new QuantityIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(QuantityIndex)).Set(Quantity, Index) as QuantityIndex;

      //Assert
      Assert.AreEqual(Index.Quantity, Value);
      Assert.IsNull(Index.Comparator);
      Assert.AreEqual(Index.Code, Code);
      Assert.IsNull(Index.System);
    }


    [Test]
    public void Test_Money_NumberIndexSetter_GoodFormat()
    {
      //Arrange
      decimal Value = 110.35M;
      var Code = "ABC";
      var System = "www.SomeCodeSystem.com";
      var Money = new Money();
      Money.Value = Value;
      Money.Code = Code;
      Money.System = System;
      QuantityIndex Index = new QuantityIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(QuantityIndex)).Set(Money, Index) as QuantityIndex;

      //Assert
      Assert.AreEqual(Index.Quantity, Value);
      Assert.IsNull(Index.Comparator);
      Assert.AreEqual(Index.Code, Code);
      Assert.AreEqual(Index.System, System);
    }

    [Test]
    public void Test_Money_NumberIndexSetter_Comparator_Code_IsNull()
    {
      //Arrange
      decimal Value = 145.523M;
      var System = "www.SomeCodeSystem.com";
      var Money = new Money();
      Money.Value = Value;
      Money.Code = null;
      Money.System = System;

      QuantityIndex Index = new QuantityIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(QuantityIndex)).Set(Money, Index) as QuantityIndex;

      //Assert
      Assert.AreEqual(Index.Quantity, Value);
      Assert.IsNull(Index.Comparator);
      Assert.IsNull(Index.Code);
      Assert.AreEqual(Index.System, System);
    }

    [Test]
    public void Test_Money_NumberIndexSetter_Comparator_System_IsNull()
    {
      //Arrange
      decimal Value = 145.523M;
      var Code = "ABC";
      var Money = new Money();
      Money.Value = Value;
      Money.Code = Code;
      Money.System = null;

      QuantityIndex Index = new QuantityIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(QuantityIndex)).Set(Money, Index) as QuantityIndex;

      //Assert
      Assert.AreEqual(Index.Quantity, Value);
      Assert.IsNull(Index.Comparator);
      Assert.AreEqual(Index.Code, Code);
      Assert.IsNull(Index.System);
    }
  }
}

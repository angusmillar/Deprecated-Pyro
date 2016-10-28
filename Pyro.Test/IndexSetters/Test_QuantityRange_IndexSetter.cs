using System;
using NUnit.Framework;
using Pyro.DataModel.IndexSetter;
using Pyro.DataModel.DatabaseModel.Base;
using Hl7.Fhir.Model;
using NUnit.Framework.Constraints;

namespace Pyro.Test.IndexSetters
{
  [TestFixture]
  class Test_QuantityRange_IndexSetter
  {
    [Test]
    public void Test_Range_NumberIndexSetter_GoodFormat()
    {
      //Arrange
      decimal ValueLow = 10.5M;
      decimal ValueHigh = 20.5M;      
      var Code = "ABC";
      var System = "www.SomeCodeSystem.com";
      
      var QuantityLow = new SimpleQuantity();
      QuantityLow.Value = ValueLow;      
      QuantityLow.Code = Code;
      QuantityLow.System = System;

      var QuantityHigh = new SimpleQuantity();
      QuantityHigh.Value = ValueHigh;      
      QuantityHigh.Code = Code;
      QuantityHigh.System = System;

      var Range = new Range();
      Range.Low = QuantityLow;
      Range.High = QuantityHigh;

      QuantityRangeIndex Index = new QuantityRangeIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(QuantityRangeIndex)).Set(Range, Index) as QuantityRangeIndex;

      //Assert
      Assert.AreEqual(Index.QuantityLow, ValueLow);
      Assert.AreEqual(Index.QuantityHigh, ValueHigh);
      Assert.IsNull(Index.ComparatorLow);
      Assert.IsNull(Index.ComparatorHigh);
      Assert.AreEqual(Index.CodeLow, Code);
      Assert.AreEqual(Index.CodeHigh, Code);
      Assert.AreEqual(Index.SystemLow, System);
      Assert.AreEqual(Index.SystemHigh, System);
    }

    [Test]
    public void Test_Range_NumberIndexSetter_LowValue_IsNull()
    {
      //Arrange
      //decimal ValueLow = 10.5M;
      decimal ValueHigh = 20.5M;
      var Code = "ABC";
      var System = "www.SomeCodeSystem.com";

      var QuantityLow = new SimpleQuantity();
      QuantityLow.Value = null;
      QuantityLow.Code = Code;
      QuantityLow.System = System;

      var QuantityHigh = new SimpleQuantity();
      QuantityHigh.Value = ValueHigh;
      QuantityHigh.Code = Code;
      QuantityHigh.System = System;

      var Range = new Range();
      Range.Low = QuantityLow;
      Range.High = QuantityHigh;

      QuantityRangeIndex Index = new QuantityRangeIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(QuantityRangeIndex)).Set(Range, Index) as QuantityRangeIndex;

      //Assert
      Assert.IsNull(Index);
    }


    [Test]
    public void Test_Range_NumberIndexSetter_HighValue_IsNull()
    {
      //Arrange
      decimal ValueLow = 10.5M;
      //decimal ValueHigh = 20.5M;
      var Code = "ABC";
      var System = "www.SomeCodeSystem.com";

      var QuantityLow = new SimpleQuantity();
      QuantityLow.Value = ValueLow;
      QuantityLow.Code = Code;
      QuantityLow.System = System;

      var QuantityHigh = new SimpleQuantity();
      QuantityHigh.Value = null;
      QuantityHigh.Code = Code;
      QuantityHigh.System = System;

      var Range = new Range();
      Range.Low = QuantityLow;
      Range.High = QuantityHigh;

      QuantityRangeIndex Index = new QuantityRangeIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(QuantityRangeIndex)).Set(Range, Index) as QuantityRangeIndex;


      //Assert
      Assert.IsNull(Index);
    }

    [Test]
    public void Test_Range_NumberIndexSetter_Range_IsNull()
    {
      //Arrange      
      Range Range = null;

      QuantityRangeIndex Index = new QuantityRangeIndex();

      //Act      
      ActualValueDelegate<QuantityRangeIndex> testDelegate = () => IndexSetterFactory.Create(typeof(QuantityRangeIndex)).Set(Range, Index) as QuantityRangeIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<ArgumentNullException>());
    }

  }
}

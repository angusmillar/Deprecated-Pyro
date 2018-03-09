using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pyro.Identifiers.Australian.MedicareProviderNumber;

namespace Pyro.Identifiers.Test
{
  [TestClass]
  public class Test_MedicareProviderNumber
  {
    [TestMethod]
    [TestCategory("Medicare Provider Number")]
    public void Test_ValidMedicareProviderNumber()
    {
      string Number = "2940675Y";
      IMedicareProviderNumberParser Parser = new MedicareProviderNumberParser();
      IMedicareProviderNumber MedicareProviderNumber;
      Assert.IsTrue(Parser.TryParse(Number, out MedicareProviderNumber));
      Assert.AreEqual(Number, MedicareProviderNumber.Value);
      Assert.AreEqual("294067", MedicareProviderNumber.Stem);
      Assert.AreEqual("5", MedicareProviderNumber.LocationCharacter);
      Assert.AreEqual("Y", MedicareProviderNumber.CheckCharacter);        
    }

    [TestMethod]
    [TestCategory("Medicare Provider Number")]
    public void Test_InValidMedicareProviderNumber()
    {
      string Number = "2940975Y";
      IMedicareProviderNumberParser Parser = new MedicareProviderNumberParser();
      IMedicareProviderNumber MedicareProviderNumber;
      Assert.IsFalse(Parser.TryParse(Number, out MedicareProviderNumber));
    }

    [TestMethod]
    [TestCategory("Medicare Provider Number")]
    public void Test_MedicareProviderNumberGeneration()
    {
      IMedicareProviderNumberGenerator MedicareProviderNumberGenerator = new MedicareProviderNumberGenerator();
      IMedicareProviderNumberParser Parser = new MedicareProviderNumberParser();
      
      for (int i = 0; i < 100000; i++)
      {
        IMedicareProviderNumber MedicareProviderNumber;
        Assert.IsTrue(Parser.TryParse(MedicareProviderNumberGenerator.Generate(), out MedicareProviderNumber));
      }
    }

  }
}

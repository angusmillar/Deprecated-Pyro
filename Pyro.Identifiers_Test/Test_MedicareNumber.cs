using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pyro.Identifiers.Australian.MedicareNumber;

namespace Pyro.Identifiers.Test
{
  [TestClass]
  
  public class Test_MedicareNumber
  {
    [TestMethod]
    [TestCategory("Medicare Number")]
    public void Test_ValidMedicareNumberWithIrn()
    {
      string MedicareNumber = "6140523093";
      string Irn = "1";

      IMedicareNumberParser Parser = new MedicareNumberParser();
      IMedicareNumber MedNum;      
      Assert.IsTrue(Parser.TryParse(MedicareNumber + Irn, out MedNum));
      Assert.AreEqual(MedicareNumber, MedNum.Value);
      Assert.AreEqual(Irn, MedNum.IRN);
      Assert.AreEqual("9", MedNum.Checksum);
      Assert.AreEqual("3", MedNum.IssueNumber);
      
    }

    [TestMethod]
    [TestCategory("Medicare Number")]
    public void Test_ValidMedicareNumberNoIrn()
    {
      string MedicareNumber = "6140523093";
      IMedicareNumberParser Parser = new MedicareNumberParser();
      IMedicareNumber MedNum;
      Assert.IsTrue(Parser.TryParse(MedicareNumber, out MedNum));
      Assert.AreEqual(MedicareNumber, MedNum.Value);
      Assert.AreEqual(string.Empty, MedNum.IRN);
      Assert.AreEqual("9", MedNum.Checksum);
      Assert.AreEqual("3", MedNum.IssueNumber);
    }

    [TestMethod]
    [TestCategory("Medicare Number")]
    public void Test_NonValidMedicareNumber()
    {
      string MedicareNumber = "614dsf4393";
      IMedicareNumberParser Parser = new MedicareNumberParser();
      IMedicareNumber MedNum;
      Assert.IsFalse(Parser.TryParse(MedicareNumber, out MedNum));
     
    }

    [TestMethod]
    [TestCategory("Medicare Number")]
    public void Test_MedicareNumberGenerationWithNoIRNStaticMethod()
    {
      IMedicareMedicareNumberGenerator MedicareMedicareNumberGenerator = new MedicareMedicareNumberGenerator();

      for (int i = 0; i < 100000; i++)
      {
        string MedicareNumberNoIrn = MedicareMedicareNumberGenerator.Generate(false);
        IMedicareNumberParser Parser = new MedicareNumberParser();
        IMedicareNumber MedNum;
        Assert.IsTrue(Parser.TryParse(MedicareNumberNoIrn, out MedNum));        
      }
    }

    [TestMethod]
    [TestCategory("Medicare Number")]
    public void Test_MedicareNumberGenerationWithIRNStaticMethod()
    {
      MedicareMedicareNumberGenerator MedicareMedicareNumberGenerator = new MedicareMedicareNumberGenerator();
      for (int i = 0; i < 100000; i++)
      {
        string MedicareNumberNoIrn = MedicareMedicareNumberGenerator.Generate(true);
        IMedicareNumberParser Parser = new MedicareNumberParser();
        IMedicareNumber MedNum;
        Assert.IsTrue(Parser.TryParse(MedicareNumberNoIrn, out MedNum));        
      }
    }
  }
}

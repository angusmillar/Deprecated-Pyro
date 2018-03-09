using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pyro.Identifiers.Australian.NationalHealthcareIdentifier;
using Pyro.Identifiers.Support.StandardsInformation.Australian;

namespace Pyro.Identifiers.Test
{
  [TestClass]
  public class Test_NationalHealthcareIdentifier
  {
    [TestMethod]
    [TestCategory("IHI Number")]
    public void Test_IHI_IsValid_True()
    {
      string Value = "8003608333428779";
      IIndividualHealthcareIdentifier IHI;
      IIndividualHealthcareIdentifierParser Parser = new IndividualHealthcareIdentifierParser();
      Assert.IsTrue(Parser.TryParse(Value, out IHI));
      Assert.AreEqual("80", IHI.IndustryCode);
      Assert.AreEqual("036", IHI.CountryCode);
      Assert.AreEqual("0", IHI.NumberIssuerCode);
      Assert.AreEqual("833342877", IHI.UniqueReference);
      Assert.AreEqual("9", IHI.CheckDigit);
      Assert.AreEqual(Value, IHI.Value);
    }

    [TestMethod]
    [TestCategory("HPI-I Number")]
    public void Test_HPI_I_IsValid_True()
    {
      string Value = "8003610001218573";
      IHealthcareProviderIdentifierIndividual HPII;
      IHealthcareProviderIdentifierIndividualParser Parser = new HealthcareProviderIdentifierIndividualParser();
      Assert.IsTrue(Parser.TryParse(Value, out HPII));
      Assert.AreEqual("80", HPII.IndustryCode);
      Assert.AreEqual("036", HPII.CountryCode);
      Assert.AreEqual("1", HPII.NumberIssuerCode);
      Assert.AreEqual("000121857", HPII.UniqueReference);
      Assert.AreEqual("3", HPII.CheckDigit);
      Assert.AreEqual(Value, HPII.Value);

    }


    [TestMethod]
    [TestCategory("HPI-I Number")]
    public void Test_HPI_I_IsValid_CheckDigit_Fasle()
    {
      string Value = "8003610001218577";
      IHealthcareProviderIdentifierIndividual HPII;
      IHealthcareProviderIdentifierIndividualParser Parser = new HealthcareProviderIdentifierIndividualParser();
      Assert.IsFalse(Parser.TryParse(Value, out HPII));      
    }

    [TestMethod]
    [TestCategory("IHI Number")]
    public void Test_IHI_IsValid_False()
    {
      //037 should be 036 
      string Value = "8003708333428779";
      IIndividualHealthcareIdentifier IHI;
      IIndividualHealthcareIdentifierParser Parser = new IndividualHealthcareIdentifierParser();
      Assert.IsFalse(Parser.TryParse(Value, out IHI));
    }


    [TestMethod]
    [TestCategory("HPI-O Number")]
    public void Test_IHI_HealthcareIdentifierType_IsHPI_O_True()
    {
      string Value = "8003626499446203";
      IHealthcareProviderIdentifierOrganisation HPIO;
      IHealthcareProviderIdentifierOrganisationParser Parser = new HealthcareProviderIdentifierOrganisationParser();
      Assert.IsTrue(Parser.TryParse(Value, out HPIO));
      Assert.AreEqual("80", HPIO.IndustryCode);
      Assert.AreEqual("036", HPIO.CountryCode);
      Assert.AreEqual("2", HPIO.NumberIssuerCode);
      Assert.AreEqual("649944620", HPIO.UniqueReference);
      Assert.AreEqual("3", HPIO.CheckDigit);
      Assert.AreEqual(Value, HPIO.Value);
    }



    [TestMethod]
    [TestCategory("IHI Number")]
    public void Test_GenerateRandomIHI()
    {
      IIndividualHealthcareIdentifierGenerator Generator = new IndividualHealthcareIdentifierGenerator();
      string NewRandom = Generator.Generate();
      IIndividualHealthcareIdentifier IHI;
      IIndividualHealthcareIdentifierParser Parser = new IndividualHealthcareIdentifierParser();
      Assert.IsTrue(Parser.TryParse(NewRandom, out IHI));
    }

    [TestMethod]
    [TestCategory("HPI-I Number")]
    public void Test_GenerateRandomHPI_I()
    {
      IHealthcareProviderIdentifierIndividualGenerator Generator = new HealthcareProviderIdentifierIndividualGenerator();
      string NewRandom = Generator.Generate();
      IHealthcareProviderIdentifierIndividual HPII;
      IHealthcareProviderIdentifierIndividualParser Parser = new HealthcareProviderIdentifierIndividualParser();
      Assert.IsTrue(Parser.TryParse(NewRandom, out HPII));
    }

    [TestMethod]
    [TestCategory("HPI-O Number")]
    public void Test_GenerateRandomHPI_O()
    {
      IHealthcareProviderIdentifierOrganisationGenerator Generator = new HealthcareProviderIdentifierOrganisationGenerator();
      string NewRandom = Generator.Generate();
      IHealthcareProviderIdentifierOrganisation HPIO;
      IHealthcareProviderIdentifierOrganisationParser Parser = new HealthcareProviderIdentifierOrganisationParser();
      Assert.IsTrue(Parser.TryParse(NewRandom, out HPIO));
    }



    [TestMethod]
    [TestCategory("OID For National Identifiers")]
    public void Test_ValueWithRootOID_ReturnsCorrect()
    {            
      NationalHealthcareIdentifierInfo Info = new NationalHealthcareIdentifierInfo();
      string RootOid = "1.2.36.1.2001.1003.0";
      Assert.AreEqual(RootOid, Info.RootHealthcareIdentifierOid);
    }
    
  }
}

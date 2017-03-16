using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using NUnit.Framework;
using Hl7.Fhir.Model;


namespace Pyro.Test.IntergrationTest
{
  [TestFixture]
  [Category("IntergrationTest")]
  class Test_BundleTransactions
  {
    private System.IDisposable Server;

    [SetUp]
    public void Setup()
    {

      Server = StaticTestData.StartupServer();
    }

    [TearDown]
    public void TearDown()
    {
      Server.Dispose();
    }

    [Test]
    public void Test_TransactionOne()
    {

      Hl7.Fhir.Rest.FhirClient clientFhir = new Hl7.Fhir.Rest.FhirClient(StaticTestData.FhirEndpoint(), false);
      clientFhir.Timeout = 1000 * 1000; // give the call a while to execute (particularly while debugging).

      string PatientResourceId = Guid.NewGuid().ToString();

      //Add a Patient resource by Update
      Patient PatientOne = new Patient();
      PatientOne.Id = PatientResourceId;
      PatientOne.Name.Add(HumanName.ForFamily("TestPatient").WithGiven("Test"));
      PatientOne.BirthDateElement = new Date("1979-09-30");
      PatientOne.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, "1"));
      PatientOne.Gender = AdministrativeGender.Unknown;

      Bundle Bundle = new Bundle();
      Bundle.Id = Guid.NewGuid().ToString();
      Bundle.Type = Bundle.BundleType.Transaction;
      Bundle.Entry = new List<Bundle.EntryComponent>();
      var PatientEntry = new Bundle.EntryComponent();
      Bundle.Entry.Add(PatientEntry);
      PatientEntry.Request = new Bundle.RequestComponent();
      PatientEntry.Request.Method = Bundle.HTTPVerb.POST;
      PatientEntry.FullUrl = $"urn:uuid:{PatientResourceId}";
      PatientEntry.Resource = PatientOne;

      Bundle TransactionResult = null;
      try
      {
        TransactionResult = clientFhir.Transaction(Bundle);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on resource Create: " + Exec.Message);
      }

    }
  }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using NUnit.Framework;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Utility;

namespace Pyro.Test.IntergrationTest
{
  [TestFixture]
  [Parallelizable(ParallelScope.None)]
  [Category("IntergrationTest")]
  class Test_IncludesAndRevIncludes
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
    public void Test_IncludesSimple()
    {

      Hl7.Fhir.Rest.FhirClient clientFhir = new Hl7.Fhir.Rest.FhirClient(StaticTestData.FhirEndpoint(), false);
      clientFhir.Timeout = 1000 * 720; // give the call a while to execute (particularly while debugging).

      // Add a Patient to Link to a Observation below  ================================
      string PatientResourceId = string.Empty;

      //Add a Patient resource by Update
      Patient PatientOne = new Patient();
      PatientOne.Name.Add(HumanName.ForFamily("TestPatient").WithGiven("Test"));
      PatientOne.BirthDateElement = new Date("1979-09-30");
      string PatientOneMRNIdentifer = Guid.NewGuid().ToString();
      PatientOne.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, PatientOneMRNIdentifer));
      PatientOne.Gender = AdministrativeGender.Unknown;

      Patient PatientResult = null;
      try
      {
        PatientResult = clientFhir.Create(PatientOne);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on resource Create: " + Exec.Message);
      }
      Assert.NotNull(PatientResult, "Resource created but returned resource is null");
      PatientResourceId = PatientResult.Id;


      // Add a Observation Lined to the Patient above ================================      
      string ObservationOneResourceId = string.Empty;

      //Create a Observation resource by Update
      Observation ObsResourceOne = new Observation();
      ObsResourceOne.Status = ObservationStatus.Final;
      ObsResourceOne.Code = new CodeableConcept("http://somesystem.net/ObSystem", "HB");
      string ObservationOneIdentifer = Guid.NewGuid().ToString();
      ObsResourceOne.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, ObservationOneIdentifer));
      ObsResourceOne.Subject = new ResourceReference($"{ResourceType.Patient.GetLiteral()}/{PatientResourceId}");
      Observation ObservationOneResult = null;
      try
      {
        ObservationOneResult = clientFhir.Create(ObsResourceOne);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on resource Create: " + Exec.Message);
      }
      Assert.NotNull(ObservationOneResult, "Resource created but returned resource is null");
      ObservationOneResourceId = ObservationOneResult.Id;
      ObservationOneResult = null;

      //Get Patient and use _include to get the Observation resource linked ====================
      Bundle BundleResult = null;
      try
      {
        //PatientOneResourceId
        var SearchParam = new SearchParams();
        SearchParam.Add("identifier", $"{StaticTestData.TestIdentiferSystem}|{ObservationOneIdentifer}");
        SearchParam.Add(SearchParams.SEARCH_PARAM_INCLUDE, $"{ResourceType.Observation.GetLiteral()}:subject:{ResourceType.Patient.GetLiteral()}");
        BundleResult = clientFhir.Search<Observation>(SearchParam);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on resource Search: " + Exec.Message);
      }
      Assert.NotNull(BundleResult, "Resource Search returned resource of null");
      Assert.AreEqual(BundleResult.Entry.Count, 2, "BundleResult.Entry.Count should be 2, the Observation and the include Patient");
      Assert.AreEqual(BundleResult.Entry[0].Resource.Id, ObservationOneResourceId, "Observation id incorrect.");
      Assert.AreEqual(BundleResult.Entry[0].Resource.ResourceType, ResourceType.Observation, "Incorrect Resource type should be Observation.");
      Assert.AreEqual(BundleResult.Entry[1].Resource.Id, PatientResourceId, "Patient id incorrect.");
      Assert.AreEqual(BundleResult.Entry[1].Resource.ResourceType, ResourceType.Patient, "Incorrect Resource type should be Patient.");


      //--- Clean Up ---------------------------------------------------------
      //Clean up by deleting all Test Patients
      SearchParams sp = new SearchParams().Where($"identifier={StaticTestData.TestIdentiferSystem}|");
      try
      {
        clientFhir.Delete(ResourceType.Patient.GetLiteral(), sp);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on conditional delete of resource Patient: " + Exec.Message);
      }

      //Clean up by deleting all Test Patients
      sp = new SearchParams().Where($"identifier={StaticTestData.TestIdentiferSystem}|");
      try
      {
        clientFhir.Delete(ResourceType.Observation.GetLiteral(), sp);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on conditional delete of resource Patient: " + Exec.Message);
      }
    }

  }

}

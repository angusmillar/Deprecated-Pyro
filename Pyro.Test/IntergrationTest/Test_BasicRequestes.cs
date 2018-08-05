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
  class Test_BasicRequestes
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
    public void Test_CRUD()
    {

      Hl7.Fhir.Rest.FhirClient clientFhir = new Hl7.Fhir.Rest.FhirClient(StaticTestData.FhirEndpoint(), false);
      clientFhir.Timeout = 1000 * 720; // give the call a while to execute (particularly while debugging).

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
      Assert.NotNull(PatientResult, "Resource create by Updated returned resource of null");
      PatientResourceId = PatientResult.Id;
      PatientResult = null;

      //Get the Added resource by Id
      try
      {
        //PatientOneResourceId
        PatientResult = (Patient)clientFhir.Get($"{StaticTestData.FhirEndpoint()}/Patient/{PatientResourceId}");
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on resource Get: " + Exec.Message);
      }
      Assert.NotNull(PatientResult, "Resource Get returned resource of null");
      Assert.AreEqual(PatientResourceId, PatientResult.Id, "Resource created by Updated has incorrect Resource Id");
      Assert.AreEqual(AdministrativeGender.Unknown, PatientResult.Gender, "Patient gender does not match.");

      //Update
      PatientResult.Gender = AdministrativeGender.Male;
      try
      {
        clientFhir.Update(PatientResult);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on resource Get: " + Exec.Message);
      }
      PatientResult = null;

      //Get the Added resource by Id
      try
      {
        PatientResult = (Patient)clientFhir.Get($"{StaticTestData.FhirEndpoint()}/Patient/{PatientResourceId}");
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on resource Get: " + Exec.Message);
      }
      Assert.NotNull(PatientResult, "Resource Get returned resource of null");
      Assert.AreEqual(AdministrativeGender.Male, PatientResult.Gender, "Patient gender does not match.");

      //Delete Resource
      try
      {
        clientFhir.Delete($"Patient/{PatientResourceId}");
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on resource Get: " + Exec.Message);
      }

      //Get the Added resource by Id
      try
      {
        var Result = clientFhir.Get($"{StaticTestData.FhirEndpoint()}/Patient/{PatientResourceId}");
      }
      catch (Hl7.Fhir.Rest.FhirOperationException OpExec)
      {
        Assert.AreEqual(OpExec.Status, System.Net.HttpStatusCode.Gone, "Final Get did not return Http Status of Gone.");
      }

    }

    [Test]
    public void Test_CaseSensitive_FHIR_Id()
    {
      Hl7.Fhir.Rest.FhirClient clientFhir = new Hl7.Fhir.Rest.FhirClient(StaticTestData.FhirEndpoint(), false);
      clientFhir.Timeout = 1000 * 720; // give the call a while to execute (particularly while debugging).
      
      //Add a Patient resource by Update
      Patient PatientOne = new Patient();
      string PatientOneResourceId = Guid.NewGuid().ToString().ToLower();
      PatientOne.Id = PatientOneResourceId;
      string PatientOneFamilyName = "TestPatientOne";
      PatientOne.Name.Add(HumanName.ForFamily(PatientOneFamilyName).WithGiven("Test"));
      PatientOne.BirthDateElement = new Date("1979-09-30");
      string PatientOneMRNIdentifer = Guid.NewGuid().ToString();
      PatientOne.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, PatientOneMRNIdentifer));
      PatientOne.Gender = AdministrativeGender.Unknown;

      Patient PatientResult = null;
      try
      {
        PatientResult = clientFhir.Update(PatientOne);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on resource Create: " + Exec.Message);
      }
      Assert.NotNull(PatientResult, "Resource create by Updated returned resource of null");      
      PatientResult = null;


      //Add a Patient resource by Update
      Patient PatientTwo = new Patient();
      string PatientTwoResourceId = PatientOneResourceId.ToUpper();
      PatientTwo.Id = PatientTwoResourceId;
      string PatientTwoFamilyName = "TestPatientTwo";
      PatientTwo.Name.Add(HumanName.ForFamily(PatientTwoFamilyName).WithGiven("Test"));
      PatientTwo.BirthDateElement = new Date("1979-09-30");
      string PatientTwoMRNIdentifer = Guid.NewGuid().ToString();
      PatientTwo.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, PatientOneMRNIdentifer));
      PatientTwo.Gender = AdministrativeGender.Unknown;

      PatientResult = null;
      try
      {
        PatientResult = clientFhir.Update(PatientTwo);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on resource Create: " + Exec.Message);
      }
      Assert.NotNull(PatientResult, "Resource create by Updated returned resource of null");      
      PatientResult = null;

      Bundle SearchResult = null;
      try
      {
        SearchResult = clientFhir.SearchById<Patient>(PatientOneResourceId);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on resource Create: " + Exec.Message);
      }
      Assert.AreEqual(1, SearchResult.Entry.Count);
      Assert.AreEqual(PatientOneFamilyName, (SearchResult.Entry[0].Resource as Patient).Name[0].Family);

      SearchResult = null;
      try
      {
        SearchResult = clientFhir.SearchById<Patient>(PatientTwoResourceId);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on resource Create: " + Exec.Message);
      }
      Assert.AreEqual(1, SearchResult.Entry.Count);
      Assert.AreEqual(PatientTwoFamilyName, (SearchResult.Entry[0].Resource as Patient).Name[0].Family);

      //--- Clean Up ---------------------------------------------------------
      //Clean up by deleting all Test Patients
      SearchParams sp = new SearchParams().Where($"identifier={StaticTestData.TestIdentiferSystem}|");
      try
      {
        clientFhir.Delete("Patient", sp);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on conditional delete of resource Patient: " + Exec.Message);
      }

    }

    [Test]
    public void Test_DateRanges()
    {
      CleanUpByIdentifier(ResourceType.Observation);

      Hl7.Fhir.Rest.FhirClient clientFhir = new Hl7.Fhir.Rest.FhirClient(StaticTestData.FhirEndpoint(), false);
      clientFhir.Timeout = 1000 * 720; // give the call a while to execute (particularly while debugging).

      //Add an Observation one with an Effective Period 10:00 AM to 11:00 AM 
      FhirDateTime ObsOneEffectiveStart = new FhirDateTime(new DateTimeOffset(2018, 08, 5, 10, 00, 00, new TimeSpan(8, 0, 0)));
      FhirDateTime ObsOneEffectiveEnd = new FhirDateTime(new DateTimeOffset(2018, 08, 5, 11, 00, 00, new TimeSpan(8, 0, 0)));
      string ObsOneResourceId = string.Empty;
      Observation ObsOne = new Observation();      
      ObsOne.Identifier = new List<Identifier>(){
         new Identifier()
         {
            System = StaticTestData.TestIdentiferSystem,
            Value = Common.Tools.FhirGuid.FhirGuid.NewFhirGuid()
         }
      };
      ObsOne.Code = new CodeableConcept();
      ObsOne.Code.Coding = new List<Coding>();
      ObsOne.Code.Coding.Add(new Coding()
      {
        System = "http:/mytestcodesystem.com/system",
        Code = "ObsOne"
      });
      var EffectiveObsOnePeriod = new Period();
      EffectiveObsOnePeriod.StartElement = ObsOneEffectiveStart;
      EffectiveObsOnePeriod.EndElement = ObsOneEffectiveEnd;
      ObsOne.Effective = EffectiveObsOnePeriod;

      Observation ObsOneResult = null;
      try
      {
        ObsOneResult = clientFhir.Create(ObsOne);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on resource Create: " + Exec.Message);
      }
      Assert.NotNull(ObsOneResult, "Resource create by Updated returned resource of null");
      ObsOneResourceId = ObsOneResult.Id;
      ObsOneResult = null;

      //Add an Observation one with an Effective Period 10:30 AM to 11:30 AM 
      FhirDateTime ObsTwoEffectiveStart = new FhirDateTime(new DateTimeOffset(2018, 08, 5, 10, 30, 00, new TimeSpan(8, 0, 0)));
      FhirDateTime ObsTwoEffectiveEnd = new FhirDateTime(new DateTimeOffset(2018, 08, 5, 11, 30, 00, new TimeSpan(8, 0, 0)));
      string ObsTwoResourceId = string.Empty;
      Observation ObsTwo = new Observation();
      ObsTwo.Identifier = new List<Identifier>(){
         new Identifier()
         {
            System = StaticTestData.TestIdentiferSystem,
            Value = Common.Tools.FhirGuid.FhirGuid.NewFhirGuid()
         }
      };
      ObsTwo.Code = new CodeableConcept();
      ObsTwo.Code.Coding = new List<Coding>();
      ObsTwo.Code.Coding.Add(new Coding()
      {
        System = "http:/mytestcodesystem.com/system",
        Code = "ObsTwo"
      });
      var EffectiveObsTwoPeriod = new Period();
      EffectiveObsTwoPeriod.StartElement = ObsTwoEffectiveStart;
      EffectiveObsTwoPeriod.EndElement = ObsTwoEffectiveEnd;
      ObsTwo.Effective = EffectiveObsTwoPeriod;

      Observation ObsTwoResult = null;
      try
      {
        ObsTwoResult = clientFhir.Create(ObsTwo);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on resource Create: " + Exec.Message);
      }
      Assert.NotNull(ObsTwoResult, "Resource create by Updated returned resource of null");
      ObsTwoResourceId = ObsTwoResult.Id;
      ObsTwoResult = null;

      //Assert
      var SearchParam = new SearchParams();
      try
      {
        SearchParam.Add("identifier", $"{StaticTestData.TestIdentiferSystem}|");
        SearchParam.Add("date", "gt2018-08-05T11:00:00+08:00");
        clientFhir.PreferredParameterHandling = SearchParameterHandling.Strict;
        Bundle BundleResult = clientFhir.Search<Observation>(SearchParam);

        Assert.IsNotNull(BundleResult);
        Assert.IsNotNull(BundleResult.Entry);
        Assert.AreEqual(1, BundleResult.Entry.Count);
        Assert.AreEqual(ObsTwoResourceId, BundleResult.Entry[0].Resource.Id);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on resource Search: " + Exec.Message);
      }


      CleanUpByIdentifier(ResourceType.Observation);

    }

    private void CleanUpByIdentifier(ResourceType ResourceType)
    {
      // give the call a while to execute (particularly while debugging).
      Hl7.Fhir.Rest.FhirClient clientFhir = new Hl7.Fhir.Rest.FhirClient(StaticTestData.FhirEndpoint(), false);
      clientFhir.Timeout = 1000 * 1000;

      //--- Clean Up ---------------------------------------------------------
      //Clean up by deleting all Test Patients

      SearchParams sp = new SearchParams().Where($"identifier={StaticTestData.TestIdentiferSystem}|");
      try
      {
        clientFhir.Delete(ResourceType.GetLiteral(), sp);
      }
      catch (Exception Exec)
      {
        Assert.True(false, $"Exception thrown on clean up delete of resource {ResourceType.GetLiteral()}: " + Exec.Message);
      }

    }
  }

}

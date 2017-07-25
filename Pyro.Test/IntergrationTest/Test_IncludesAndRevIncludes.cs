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
  [Category("A IntergrationTest Includes")]
  class Test_IncludesAndRevIncludes
  {
    private System.IDisposable Server;
    private Hl7.Fhir.Rest.FhirClient clientFhir;
    private string ObservationOneIdentifer = string.Empty;
    private string ObservationOneResourceId = string.Empty;
    private string PatientResourceId = string.Empty;
    private string OrganizationOneIdentifer = string.Empty;
    private string OrganizationOneId = string.Empty;

    [SetUp]
    public void Setup()
    {
      Server = StaticTestData.StartupServer();

      clientFhir = new Hl7.Fhir.Rest.FhirClient(StaticTestData.FhirEndpoint(), false);
      clientFhir.Timeout = 1000 * 720; // give the call a while to execute (particularly while debugging).

      //As a summary this Set up creates an Observation linked to a Patient as the 'subject' and an Organization as the 'performer'
      //Observation
      //--> Patient
      //--> Organization

      // Add a Patient to Link to a Observation below  ================================

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

      //Add a Organization resource by Update
      Organization OrganizationOne = new Organization();
      OrganizationOne.Name = "OrganizationOne Testing Facility";
      OrganizationOneIdentifer = Guid.NewGuid().ToString();
      OrganizationOne.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, PatientOneMRNIdentifer));


      Organization OrganizationOneResult = null;
      try
      {
        OrganizationOneResult = clientFhir.Create(OrganizationOne);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on resource Create: " + Exec.Message);
      }
      Assert.NotNull(PatientResult, "Resource created but returned resource is null");
      OrganizationOneId = OrganizationOneResult.Id;


      // Add a Observation Lined to the Patient above ================================      

      Observation ObsResourceOne = new Observation();
      ObsResourceOne.Status = ObservationStatus.Final;
      ObsResourceOne.Code = new CodeableConcept("http://somesystem.net/ObSystem", "HB");
      ObservationOneIdentifer = Guid.NewGuid().ToString();
      ObsResourceOne.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, ObservationOneIdentifer));
      ObsResourceOne.Subject = new ResourceReference($"{ResourceType.Patient.GetLiteral()}/{PatientResourceId}");
      ObsResourceOne.Performer = new List<ResourceReference>() { new ResourceReference($"{ResourceType.Organization.GetLiteral()}/{OrganizationOneId}") };
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

    }

    [TearDown]
    public void TearDown()
    {
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

      //Clean up by deleting all Test Organization
      sp = new SearchParams().Where($"identifier={StaticTestData.TestIdentiferSystem}|");
      try
      {
        clientFhir.Delete(ResourceType.Organization.GetLiteral(), sp);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on conditional delete of resource Patient: " + Exec.Message);
      }

      Server.Dispose();
    }

    [Test]
    public void Test_Include_Simple()
    {
      //Get Observation and use _include to get the Patient resource that is linked as subject ====================
      Bundle BundleResult = null;
      var SearchParam = new SearchParams();
      try
      {
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
    }

    [Test]
    public void Test_Includes_Simple_NoTarget()
    {
      //Get Observation and use _include to get the Patient resource that is linked as subject and as patient
      //we should only get one Patient resource instance as they are the same instance with two search parameters to the same Resource====================
      Bundle BundleResult = null;
      var SearchParam = new SearchParams();
      try
      {
        SearchParam.Add("identifier", $"{StaticTestData.TestIdentiferSystem}|{ObservationOneIdentifer}");
        SearchParam.Add(SearchParams.SEARCH_PARAM_INCLUDE, $"{ResourceType.Observation.GetLiteral()}:subject:{ResourceType.Patient.GetLiteral()}");
        SearchParam.Add(SearchParams.SEARCH_PARAM_INCLUDE, $"{ResourceType.Observation.GetLiteral()}:patient");
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

    }

    [Test]
    public void Test_Includes_Patient_Org_NoTarget_()
    {
      //Get Observation and use _include to get the Patient resource that is linked as subject and as patient search parameters
      //Also get via include the performer search parameter Orginization resource 
      //we should only get one Patient resource instance as they are the same instance with two search parameters to the same Resource
      // and one Orginization resource for the performer parameter, so 3 in total====================
      Bundle BundleResult = null;
      var SearchParam = new SearchParams();
      try
      {
        SearchParam.Add("identifier", $"{StaticTestData.TestIdentiferSystem}|{ObservationOneIdentifer}");
        SearchParam.Add(SearchParams.SEARCH_PARAM_INCLUDE, $"{ResourceType.Observation.GetLiteral()}:subject:{ResourceType.Patient.GetLiteral()}");
        SearchParam.Add(SearchParams.SEARCH_PARAM_INCLUDE, $"{ResourceType.Observation.GetLiteral()}:patient");
        SearchParam.Add(SearchParams.SEARCH_PARAM_INCLUDE, $"{ResourceType.Observation.GetLiteral()}:performer:{ResourceType.Organization.GetLiteral()}");
        BundleResult = clientFhir.Search<Observation>(SearchParam);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on resource Search: " + Exec.Message);
      }
      Assert.NotNull(BundleResult, "Resource Search returned resource of null");
      Assert.AreEqual(BundleResult.Entry.Count, 3, "BundleResult.Entry.Count should be 2, the Observation and the include Patient");
      Assert.AreEqual(BundleResult.Entry[0].Resource.Id, ObservationOneResourceId, "Observation id incorrect.");
      Assert.AreEqual(BundleResult.Entry[0].Resource.ResourceType, ResourceType.Observation, "Incorrect Resource type should be Observation.");
      Assert.AreEqual(BundleResult.Entry[1].Resource.Id, PatientResourceId, "Patient id incorrect.");
      Assert.AreEqual(BundleResult.Entry[1].Resource.ResourceType, ResourceType.Patient, "Incorrect Resource type should be Patient.");
      Assert.AreEqual(BundleResult.Entry[2].Resource.Id, OrganizationOneId, "Organization id incorrect.");
      Assert.AreEqual(BundleResult.Entry[2].Resource.ResourceType, ResourceType.Organization, "Incorrect Resource type should be Patient.");
    }

    [Test]
    public void Test_Includes_Patient_Org_SpecifyTarget()
    {
      //Same as above but this time we don't specify the target resource for the include, we should still get the same result
      //Get Observation and use _include to get the Patient resource that is linked as subject and as patient search parameters
      //Also get via include the performer search parameter Orginization resource 
      //we should only get one Patient resource instance as they are the same instance with two search parameters to the same Resource
      // and one Orginization resource for the performer parameter, so 3 in total
      // this also test working around a syntax error on the callers part with ':' left with no target resource, i.e '_include=Patient:subject:'
      //=====================================================================================================
      Bundle BundleResult = null;
      var SearchParam = new SearchParams();
      try
      {
        SearchParam.Add("identifier", $"{StaticTestData.TestIdentiferSystem}|{ObservationOneIdentifer}");
        SearchParam.Add(SearchParams.SEARCH_PARAM_INCLUDE, $"{ResourceType.Observation.GetLiteral()}:subject:");
        SearchParam.Add(SearchParams.SEARCH_PARAM_INCLUDE, $"{ResourceType.Observation.GetLiteral()}:patient");
        SearchParam.Add(SearchParams.SEARCH_PARAM_INCLUDE, $"{ResourceType.Observation.GetLiteral()}:performer");
        BundleResult = clientFhir.Search<Observation>(SearchParam);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on resource Search: " + Exec.Message);
      }
      Assert.NotNull(BundleResult, "Resource Search returned resource of null");
      Assert.AreEqual(BundleResult.Entry.Count, 3, "BundleResult.Entry.Count should be 2, the Observation and the include Patient");
      Assert.AreEqual(BundleResult.Entry[0].Resource.Id, ObservationOneResourceId, "Observation id incorrect.");
      Assert.AreEqual(BundleResult.Entry[0].Resource.ResourceType, ResourceType.Observation, "Incorrect Resource type should be Observation.");
      Assert.AreEqual(BundleResult.Entry[1].Resource.Id, PatientResourceId, "Patient id incorrect.");
      Assert.AreEqual(BundleResult.Entry[1].Resource.ResourceType, ResourceType.Patient, "Incorrect Resource type should be Patient.");
      Assert.AreEqual(BundleResult.Entry[2].Resource.Id, OrganizationOneId, "Organization id incorrect.");
      Assert.AreEqual(BundleResult.Entry[2].Resource.ResourceType, ResourceType.Organization, "Incorrect Resource type should be Patient.");
    }

    [Test]
    public void Test_Includes_StarAll()
    {

      //Get All reference types for the ScourceResource _include=Observation:*
      //=====================================================================================================
      Bundle BundleResult = null;
      var SearchParam = new SearchParams();
      try
      {
        SearchParam.Add("identifier", $"{StaticTestData.TestIdentiferSystem}|{ObservationOneIdentifer}");
        SearchParam.Add(SearchParams.SEARCH_PARAM_INCLUDE, $"{ResourceType.Observation.GetLiteral()}:*");
        BundleResult = clientFhir.Search<Observation>(SearchParam);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on resource Search: " + Exec.Message);
      }
      Assert.NotNull(BundleResult, "Resource Search returned resource of null");
      Assert.AreEqual(BundleResult.Entry.Count, 3, "BundleResult.Entry.Count should be 2, the Observation and the include Patient");
      Assert.AreEqual(BundleResult.Entry[0].Resource.Id, ObservationOneResourceId, "Observation id incorrect.");
      Assert.AreEqual(BundleResult.Entry[0].Resource.ResourceType, ResourceType.Observation, "Incorrect Resource type should be Observation.");
      Assert.AreEqual(BundleResult.Entry[1].Resource.Id, PatientResourceId, "Patient id incorrect.");
      Assert.AreEqual(BundleResult.Entry[1].Resource.ResourceType, ResourceType.Patient, "Incorrect Resource type should be Patient.");
      Assert.AreEqual(BundleResult.Entry[2].Resource.Id, OrganizationOneId, "Organization id incorrect.");
      Assert.AreEqual(BundleResult.Entry[2].Resource.ResourceType, ResourceType.Organization, "Incorrect Resource type should be Patient.");
    }

    [Test]
    public void Test_Includes_WhereResourceNotFound()
    {

      //Get Observation and use _include to get the Location resource which does not exist for the observation 
      //So we should only get the Observation ====================
      Bundle BundleResult = null;
      var SearchParam = new SearchParams();
      try
      {
        SearchParam.Add("identifier", $"{StaticTestData.TestIdentiferSystem}|{ObservationOneIdentifer}");
        SearchParam.Add(SearchParams.SEARCH_PARAM_INCLUDE, $"{ResourceType.Observation.GetLiteral()}:subject:{ResourceType.Location.GetLiteral()}");
        BundleResult = clientFhir.Search<Observation>(SearchParam);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on resource Search: " + Exec.Message);
      }
      Assert.NotNull(BundleResult, "Resource Search returned resource of null");
      Assert.AreEqual(BundleResult.Entry.Count, 1, "BundleResult.Entry.Count should be 1, the Observation and no include of Locaton");
      Assert.AreEqual(BundleResult.Entry[0].Resource.Id, ObservationOneResourceId, "Observation id incorrect.");
      Assert.AreEqual(BundleResult.Entry[0].Resource.ResourceType, ResourceType.Observation, "Incorrect Resource type should be Observation.");




    }

  }

}

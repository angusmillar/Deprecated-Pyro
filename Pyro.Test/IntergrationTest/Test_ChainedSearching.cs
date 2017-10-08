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
  [Category("A IntergrationTest Chained Searching")]
  class Test_ChainedSearching
  {
    private System.IDisposable Server;
    private Hl7.Fhir.Rest.FhirClient clientFhir;

    private string ObservationOneIdentifer = string.Empty;
    private string ObservationOneResourceId = string.Empty;

    private string ObservationTwoIdentifer = string.Empty;
    private string ObservationTwoResourceId = string.Empty;

    private string ObservationThreeIdentifer = string.Empty;
    private string ObservationThreeResourceId = string.Empty;

    private string PatientResourceId = string.Empty;
    private string PatientOneMRNIdentifer = string.Empty;
    private string PatientOneFamily = "TestPatientChain";

    private string OrganizationOneIdentifer = string.Empty;
    private string OrganizationOneResourceId = string.Empty;
    private string OrganizationOneName = "OrganizationOne Testing Facility";

    private string EndpointOneIdentifer = string.Empty;
    private string EndpointOneResourceId = string.Empty;
    private string EndpointOneName = "AcmeEndpoint";


    [SetUp]
    public void Setup()
    {
      Server = StaticTestData.StartupServer();

      clientFhir = new Hl7.Fhir.Rest.FhirClient(StaticTestData.FhirEndpoint(), false);
      clientFhir.Timeout = 1000 * 720; // give the call a while to execute (particularly while debugging).

      //This Set up creates an Observation linked to a Patient as the 'subject' and an Organization as the 'performer'
      // Observation1
      //           --> Patient
      //           --> Organization - > Endpoint
      //           --> Observation2
      //                           ----> Observation3

      //Add a Endpoint resource 
      Endpoint EndpointOnex = new Endpoint();
      EndpointOnex.Name = EndpointOneName;
      EndpointOneIdentifer = Guid.NewGuid().ToString();
      EndpointOnex.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, EndpointOneIdentifer));
      Endpoint EndPointOneResult = null;
      try
      {
        EndPointOneResult = clientFhir.Create(EndpointOnex);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on resource Create: " + Exec.Message);
      }
      Assert.NotNull(EndPointOneResult, "Resource created but returned resource is null");
      EndpointOneResourceId = EndPointOneResult.Id;

      //Add a Endpoint resource 
      Endpoint EndpointTwo = new Endpoint();
      EndpointTwo.Name = EndpointOneName;
      string EndpointTwoIdentifer = Guid.NewGuid().ToString();
      EndpointTwo.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, EndpointTwoIdentifer));
      Endpoint EndPointTwoResult = null;
      try
      {
        EndPointTwoResult = clientFhir.Create(EndpointTwo);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on resource Create: " + Exec.Message);
      }
      Assert.NotNull(EndPointTwoResult, "Resource created but returned resource is null");
      string EndpointTwoResourceId = EndPointTwoResult.Id;




      //Add a Organization resource by Update
      Organization OrganizationOne = new Organization();
      OrganizationOne.Name = OrganizationOneName;
      OrganizationOneIdentifer = Guid.NewGuid().ToString();
      OrganizationOne.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, OrganizationOneIdentifer));
      OrganizationOne.Endpoint = new List<ResourceReference>() { new ResourceReference($"{ResourceType.Endpoint.GetLiteral()}/{EndpointOneResourceId}") };
      Organization OrganizationOneResult = null;
      try
      {
        OrganizationOneResult = clientFhir.Create(OrganizationOne);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on resource Create: " + Exec.Message);
      }
      Assert.NotNull(OrganizationOneResult, "Resource created but returned resource is null");
      OrganizationOneResourceId = OrganizationOneResult.Id;

      //Patient where Obs.performer -> Org.name 
      // Add a Patient to Link to a Observation below  ================================

      Patient PatientOne = new Patient();
      PatientOne.Name.Add(HumanName.ForFamily(PatientOneFamily).WithGiven("Test"));
      PatientOne.BirthDateElement = new Date("1979-09-30");
      PatientOneMRNIdentifer = Guid.NewGuid().ToString();
      PatientOne.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, PatientOneMRNIdentifer));
      PatientOne.Gender = AdministrativeGender.Unknown;
      PatientOne.ManagingOrganization = new ResourceReference($"{ResourceType.Organization.GetLiteral()}/{OrganizationOneResourceId}");
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


      //Here we set up 3 observations linked in a chain Obs1 -> Obs2 - > Obs3 to test recursive includes

      // Add Observation 3 Linked to no other observation
      // This is to test recursive includes 
      Observation ObsResourceThree = new Observation();
      ObsResourceThree.Status = ObservationStatus.Final;
      ObsResourceThree.Code = new CodeableConcept("http://somesystem.net/ObSystem", "WCC");
      ObservationThreeIdentifer = Guid.NewGuid().ToString();
      ObsResourceThree.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, ObservationTwoIdentifer));
      ObsResourceThree.Subject = new ResourceReference($"{ResourceType.Patient.GetLiteral()}/{PatientResourceId}");
      ObsResourceThree.Performer = new List<ResourceReference>() { new ResourceReference($"{ResourceType.Organization.GetLiteral()}/{OrganizationOneResourceId}") };
      Observation ObservationThreeResult = null;
      try
      {
        ObservationThreeResult = clientFhir.Create(ObsResourceThree);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on Observation resource two create: " + Exec.Message);
      }
      Assert.NotNull(ObservationThreeResult, "Resource created but returned resource is null");
      ObservationThreeResourceId = ObservationThreeResult.Id;
      ObservationThreeResult = null;


      // Add Observation 2 Linked to the Observation3 above and Patient above
      // This is to test recursive includes 
      Observation ObsResourceTwo = new Observation();
      ObsResourceTwo.Status = ObservationStatus.Final;
      ObsResourceTwo.Code = new CodeableConcept("http://somesystem.net/ObSystem", "WCC");
      ObservationTwoIdentifer = Guid.NewGuid().ToString();
      ObsResourceTwo.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, ObservationTwoIdentifer));
      ObsResourceTwo.Subject = new ResourceReference($"{ResourceType.Patient.GetLiteral()}/{PatientResourceId}");
      ObsResourceTwo.Performer = new List<ResourceReference>() { new ResourceReference($"{ResourceType.Organization.GetLiteral()}/{OrganizationOneResourceId}") };
      ObsResourceTwo.Related = new List<Observation.RelatedComponent>();
      var RelatedArtifact2 = new Observation.RelatedComponent();
      RelatedArtifact2.Target = new ResourceReference($"{ResourceType.Observation.GetLiteral()}/{ObservationThreeResourceId}");
      ObsResourceTwo.Related.Add(RelatedArtifact2);
      Observation ObservationTwoResult = null;
      try
      {
        ObservationTwoResult = clientFhir.Create(ObsResourceTwo);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on Observation resource two create: " + Exec.Message);
      }
      Assert.NotNull(ObservationTwoResult, "Resource created but returned resource is null");
      ObservationTwoResourceId = ObservationTwoResult.Id;
      ObservationTwoResult = null;

      // Add Observation1 linked to Observation 2 above and the Patient above ================================      
      Observation ObsResourceOne = new Observation();
      ObsResourceOne.Status = ObservationStatus.Final;
      ObsResourceOne.Code = new CodeableConcept("http://somesystem.net/ObSystem", "HB");
      ObservationOneIdentifer = Guid.NewGuid().ToString();
      ObsResourceOne.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, ObservationOneIdentifer));
      ObsResourceOne.Subject = new ResourceReference($"{ResourceType.Patient.GetLiteral()}/{PatientResourceId}");
      ObsResourceOne.Performer = new List<ResourceReference>() { new ResourceReference($"{ResourceType.Organization.GetLiteral()}/{OrganizationOneResourceId}") };
      ObsResourceOne.Related = new List<Observation.RelatedComponent>();
      var RelatedArtifact1 = new Observation.RelatedComponent();
      RelatedArtifact1.Target = new ResourceReference($"{ResourceType.Observation.GetLiteral()}/{ObservationTwoResourceId}");
      ObsResourceOne.Related.Add(RelatedArtifact1);
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

    [Test]
    public void Test_Chain_Simple()
    {
      //Get Observation resources where Patient family name is TestPatientChain 
      //i.e subject.family=TestPatientChain ====================
      Bundle BundleResult = null;
      var SearchParam = new SearchParams();
      try
      {
        SearchParam.Add("subject:Patient.family", PatientOneFamily);
        BundleResult = clientFhir.Search<Observation>(SearchParam);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on resource Search: " + Exec.Message);
      }
      Assert.NotNull(BundleResult, "Resource Search returned resource of null");
      Assert.AreEqual(BundleResult.Entry.Count, 3, "BundleResult.Entry.Count should be 3, Observation resources");
      Assert.AreEqual(BundleResult.Entry[0].Resource.Id, ObservationThreeResourceId, "Entry[0].Resource.Id not correct");
      Assert.AreEqual(BundleResult.Entry[1].Resource.Id, ObservationTwoResourceId, "Entry[0].Resource.Id not correct");
      Assert.AreEqual(BundleResult.Entry[2].Resource.Id, ObservationOneResourceId, "Entry[0].Resource.Id not correct");
    }

    [Test]
    public void Test_Chain_X2()
    {
      //Get Observation resources where Patient's ManagingOrginisation's name = OrganizationOneName      
      Bundle BundleResult = null;
      var SearchParam = new SearchParams();
      try
      {
        SearchParam.Add("subject:Patient.organization.name", OrganizationOneName);
        BundleResult = clientFhir.Search<Observation>(SearchParam);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on resource Search: " + Exec.Message);
      }
      Assert.NotNull(BundleResult, "Resource Search returned resource of null");
      Assert.AreEqual(BundleResult.Entry.Count, 3, "BundleResult.Entry.Count should be 3, Observation resources");
      Assert.AreEqual(BundleResult.Entry[0].Resource.Id, ObservationThreeResourceId, "Entry[0].Resource.Id not correct");
      Assert.AreEqual(BundleResult.Entry[1].Resource.Id, ObservationTwoResourceId, "Entry[0].Resource.Id not correct");
      Assert.AreEqual(BundleResult.Entry[2].Resource.Id, ObservationOneResourceId, "Entry[0].Resource.Id not correct");
    }

    [Test]
    public void Test_Chain_X3()
    {
      //Get Observation resources where Patient's ManagingOrginisation's Endpoint name = EndpointOneName            
      Bundle BundleResult = null;
      var SearchParam = new SearchParams();
      try
      {
        SearchParam.Add("subject:Patient.organization.endpoint.name", EndpointOneName);
        BundleResult = clientFhir.Search<Observation>(SearchParam);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on resource Search: " + Exec.Message);
      }
      Assert.NotNull(BundleResult, "Resource Search returned resource of null");
      Assert.AreEqual(BundleResult.Entry.Count, 3, "BundleResult.Entry.Count should be 3, Observation resources");
      Assert.AreEqual(BundleResult.Entry[0].Resource.Id, ObservationThreeResourceId, "Entry[0].Resource.Id not correct");
      Assert.AreEqual(BundleResult.Entry[1].Resource.Id, ObservationTwoResourceId, "Entry[0].Resource.Id not correct");
      Assert.AreEqual(BundleResult.Entry[2].Resource.Id, ObservationOneResourceId, "Entry[0].Resource.Id not correct");
    }

    [Test]
    public void Test_Chain_X3_NegativeTest()
    {
      //Get Observation resources where Patient's ManagingOrginisation's Endpoint name = XXXX which will fail
      //Also search on identifier which is true yet due to the above failing we are to get zero resource returned      
      Bundle BundleResult = null;
      var SearchParam = new SearchParams();
      try
      {
        SearchParam.Add("subject:Patient.organization.endpoint.name", "XXXX");
        SearchParam.Add("identifier", $"{StaticTestData.TestIdentiferSystem}|{ObservationOneIdentifer}");
        BundleResult = clientFhir.Search<Observation>(SearchParam);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on resource Search: " + Exec.Message);
      }
      Assert.NotNull(BundleResult, "Resource Search returned resource of null");
      Assert.AreEqual(BundleResult.Entry.Count, 0, "BundleResult.Entry.Count should be 0, Observation resources");
    }


    [TearDown]
    public void TearDown()
    {
      //--- Clean Up ---------------------------------------------------------
      //Clean up by deleting all Test Endpoint
      SearchParams sp = new SearchParams().Where($"identifier={StaticTestData.TestIdentiferSystem}|");
      try
      {
        clientFhir.Delete(ResourceType.Endpoint.GetLiteral(), sp);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on conditional delete of resource Endpoint: " + Exec.Message);
      }

      //Clean up by deleting all Test Patients
      sp = new SearchParams().Where($"identifier={StaticTestData.TestIdentiferSystem}|");
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
  }

}

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

    [Test]
    public void Test_TransBundleIfNoneExsists()
    {
      CleanUpByIdentifier(ResourceType.Patient);
      CleanUpByIdentifier(ResourceType.Observation);

      Hl7.Fhir.Rest.FhirClient clientFhir = new Hl7.Fhir.Rest.FhirClient(StaticTestData.FhirEndpoint(), false);
      clientFhir.Timeout = 1000 * 1000; // give the call a while to execute (particularly while debugging).

      //Test If-None-Exsists within a bundle transaction where their is a link from 
      //one resource Observation to a Patient resource that by an identifier Reference.
      //So the idea is that the Observation resource identifier Reference is updated
      //with the servers true Id for the Patient resource which already exsists in the server. 
      //The Patient resource in the bundle is not actualy commited as it already exsist.
      //So the test is as follows:
      //1. Add as a POST (Create) patient one as setup so it is in the server
      //2. POST a transaction bundle which has the same Pateint one resource marked as 'IfNoneExsists'
      //   and an Observation resource with a identifier Reference to Patient one. I will also add 
      //   another Patient Two and Observation two resource that also have a identifier Reference link between
      //   them selves and IfNoneExists for the Patient two, yet in this case the Patient resource 
      //   will not exists, so will be commited.
      //3. The outcome should be:
      //   - Patient One - OK (indicating it is already in the server, and has the same Fhir id as the step 1 PUT)
      //   - ObservationOne - Created (referance updated Patient One Fhir Id)
      //   - Patient Two - Created (Assigned a new Fhir ID)
      //   - Observation Two - Created (referance updated Patient One Fhir Id)


      //Arrange ------------------------------------------------------------

      //Patient One Setup
      string PatientOneMRNIdentifer = Guid.NewGuid().ToString();      
      Patient PatientOne = StaticTestData.CreateTestPatient(PatientOneMRNIdentifer);

      Patient PatientCreateResult = null;
      try
      {
        //POST Patent One as Setup
        PatientCreateResult = clientFhir.Create(PatientOne);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on PUT Patient One setup: " + Exec.Message);
      }
      //Get the Fhir Id Assiged to patient One to assert later
      string PatientOneFhirId = PatientCreateResult.Id;

      Observation ObservationOne = new Observation();
      ObservationOne.Subject = new ResourceReference($"{ResourceType.Patient.GetLiteral()}?identifier={PatientOneMRNIdentifer}");
      ObservationOne.Identifier = new List<Identifier>(){
         new Identifier()
         {
            System = StaticTestData.TestIdentiferSystem,
            Value = Common.Tools.FhirGuid.FhirGuid.NewFhirGuid()
         }
      };
      ObservationOne.Code = new CodeableConcept();
      ObservationOne.Code.Coding = new List<Coding>();
      ObservationOne.Code.Coding.Add(new Coding(){
        System = "http:/mytestcodesystem.com/system",
        Code = "ObsOne"
      });
      
      //Patient Two Setup
      string PatientTwoMRNIdentifer = Guid.NewGuid().ToString();
      Patient PatientTwo = StaticTestData.CreateTestPatient(PatientTwoMRNIdentifer);

      Observation ObservationTwo = new Observation();
      ObservationTwo.Subject = new ResourceReference($"{ResourceType.Patient.GetLiteral()}?identifier={PatientTwoMRNIdentifer}");
      ObservationTwo.Identifier = new List<Identifier>(){
         new Identifier()
         {
            System = StaticTestData.TestIdentiferSystem,
            Value = Common.Tools.FhirGuid.FhirGuid.NewFhirGuid()
         }
      };
      ObservationTwo.Code = new CodeableConcept();
      ObservationTwo.Code.Coding = new List<Coding>();
      ObservationTwo.Code.Coding.Add(new Coding()
      {
        System = "http:/mytestcodesystem.com/system",
        Code = "ObsTwo"
      });

      //Now setup Transaction bundle
      Bundle TransBundleIfNoneExsists = new Bundle();
      TransBundleIfNoneExsists.Id = Guid.NewGuid().ToString();
      TransBundleIfNoneExsists.Type = Bundle.BundleType.Transaction;
      TransBundleIfNoneExsists.Entry = new List<Bundle.EntryComponent>();
      
      //Patient One Entry
      var PatientOneEntry = new Bundle.EntryComponent();
      TransBundleIfNoneExsists.Entry.Add(PatientOneEntry);
      PatientOneEntry.FullUrl = CreateFullUrlUUID(Guid.NewGuid().ToString());
      PatientOneEntry.Resource = PatientOne;
      PatientOneEntry.Request = new Bundle.RequestComponent();
      PatientOneEntry.Request.Method = Bundle.HTTPVerb.POST;
      PatientOneEntry.Request.Url = ResourceType.Patient.GetLiteral();
      PatientOneEntry.Request.IfNoneExist = $"identifier={PatientOneMRNIdentifer}";

      //Observation One Entry
      //Patient One Entry
      var ObservationOneEntry = new Bundle.EntryComponent();
      TransBundleIfNoneExsists.Entry.Add(ObservationOneEntry);
      ObservationOneEntry.FullUrl = CreateFullUrlUUID(Guid.NewGuid().ToString());
      ObservationOneEntry.Resource = ObservationOne;
      ObservationOneEntry.Request = new Bundle.RequestComponent();
      ObservationOneEntry.Request.Method = Bundle.HTTPVerb.POST;
      ObservationOneEntry.Request.Url = ResourceType.Observation.GetLiteral();

      //Patient Two Entry
      var PatientTwoEntry = new Bundle.EntryComponent();
      TransBundleIfNoneExsists.Entry.Add(PatientTwoEntry);
      PatientTwoEntry.FullUrl = CreateFullUrlUUID(Guid.NewGuid().ToString());
      PatientTwoEntry.Resource = PatientTwo;
      PatientTwoEntry.Request = new Bundle.RequestComponent();
      PatientTwoEntry.Request.Method = Bundle.HTTPVerb.POST;
      PatientTwoEntry.Request.Url = ResourceType.Patient.GetLiteral();
      PatientTwoEntry.Request.IfNoneExist = $"identifier={PatientTwoMRNIdentifer}";

      //Observation One Entry
      //Patient One Entry
      var ObservationTwoEntry = new Bundle.EntryComponent();
      TransBundleIfNoneExsists.Entry.Add(ObservationTwoEntry);
      ObservationTwoEntry.FullUrl = CreateFullUrlUUID(Guid.NewGuid().ToString());
      ObservationTwoEntry.Resource = ObservationTwo;
      ObservationTwoEntry.Request = new Bundle.RequestComponent();
      ObservationTwoEntry.Request.Method = Bundle.HTTPVerb.POST;
      ObservationTwoEntry.Request.Url = ResourceType.Observation.GetLiteral();

      //Act -------------------------------------------------------------------
      Bundle TransactionResult = null;
      try
      {
        TransactionResult = clientFhir.Transaction(TransBundleIfNoneExsists);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on POST Transaction bundle if-none-exsists: " + Exec.Message);
      }

      //Assert ---------------------------------------------------------------
      Assert.True(TransactionResult.Type == Bundle.BundleType.TransactionResponse);
      Assert.AreEqual(TransactionResult.Entry.Count, 4);
      
      //Patient One
      Assert.AreEqual(TransactionResult.Entry[0].Resource.ResourceType, ResourceType.Patient);
      //Assert.AreSame(TransactionResult.Entry[0].Resource.Id, PatientOneFhirId);
      Assert.AreEqual(TransactionResult.Entry[0].Response.Status, "200 OK");
      Assert.AreEqual(TransactionResult.Entry[0].Response.Etag, "W/\"1\"");
      
      //Observation One
      Assert.AreEqual(TransactionResult.Entry[1].Resource.ResourceType, ResourceType.Observation);      
      Assert.AreEqual(TransactionResult.Entry[1].Response.Status, "201 Created");
      Assert.AreEqual(TransactionResult.Entry[1].Response.Etag, "W/\"1\"");
      if (TransactionResult.Entry[1].Resource is Observation ObsOneResult)
      {
        Assert.AreEqual(ObsOneResult.Code.Coding[0].Code, "ObsOne");
        Assert.AreEqual(ObsOneResult.Subject.Reference, $"{ResourceType.Patient.GetLiteral()}/{PatientOneFhirId}");
      }
      else
      {
        Assert.True(false, "Entry[1] shoudl have been a Observation resource");
      }

      //Patient Two
      Assert.AreEqual(TransactionResult.Entry[2].Resource.ResourceType, ResourceType.Patient);      
      Assert.AreEqual(TransactionResult.Entry[2].Response.Status, "201 Created");
      Assert.AreEqual(TransactionResult.Entry[2].Response.Etag, "W/\"1\"");
      string PatientTwoFhirId = string.Empty;
      if (TransactionResult.Entry[2].Resource is Patient PatTwoResult)
      {
        Assert.AreEqual(PatTwoResult.Identifier[0].Value, PatientTwoMRNIdentifer);
        PatientTwoFhirId = PatTwoResult.Id;
      }
      else
      {
        Assert.True(false, "Entry[2] should have been a Patient resource");
      }

      //Observation Two
      Assert.AreEqual(TransactionResult.Entry[3].Resource.ResourceType, ResourceType.Observation);
      Assert.AreEqual(TransactionResult.Entry[3].Response.Status, "201 Created");
      Assert.AreEqual(TransactionResult.Entry[3].Response.Etag, "W/\"1\"");
      if (TransactionResult.Entry[3].Resource is Observation ObsTwoResult)
      {
        Assert.AreEqual(ObsTwoResult.Code.Coding[0].Code, "ObsTwo");
        Assert.AreEqual(ObsTwoResult.Subject.Reference, $"{ResourceType.Patient.GetLiteral()}/{PatientTwoFhirId}");
      }
      else
      {
        Assert.True(false, "Entry[3] should have been a Observation resource");
      }

      CleanUpByIdentifier(ResourceType.Patient);
      CleanUpByIdentifier(ResourceType.Observation);
    }

    [Test]
    public void Test_BundleTransaction()
    {

      Hl7.Fhir.Rest.FhirClient clientFhir = new Hl7.Fhir.Rest.FhirClient(StaticTestData.FhirEndpoint(), false);
      clientFhir.Timeout = 1000 * 1000; // give the call a while to execute (particularly while debugging).

      //------------------------------------------------------------------------------------------------------
      //Transaction Bundle 1 (Create) ---------------------------------------------------------------------------------
      //------------------------------------------------------------------------------------------------------

      Bundle TransBundle = new Bundle();
      TransBundle.Id = Guid.NewGuid().ToString();
      TransBundle.Type = Bundle.BundleType.Transaction;
      TransBundle.Entry = new List<Bundle.EntryComponent>();
      string PatientOneMRNIdentifer = Guid.NewGuid().ToString();
      string OrganizationOneMRNIdentifer = Guid.NewGuid().ToString();

      //Add a Patient resource by Create
      Patient PatientOne = StaticTestData.CreateTestPatient(PatientOneMRNIdentifer);
      string OrgOneResourceIdFulUrl = CreateFullUrlUUID(Guid.NewGuid().ToString());
      PatientOne.ManagingOrganization = new ResourceReference()
      {
        Reference = OrgOneResourceIdFulUrl
      };

      var PatientEntry = new Bundle.EntryComponent();
      TransBundle.Entry.Add(PatientEntry);
      PatientEntry.Resource = PatientOne;
      PatientEntry.Request = new Bundle.RequestComponent();
      PatientEntry.Request.Method = Bundle.HTTPVerb.POST;
      string PatientResourceIdFulUrl = CreateFullUrlUUID(Guid.NewGuid().ToString());
      PatientEntry.FullUrl = PatientResourceIdFulUrl;
      PatientEntry.Resource = PatientOne;
      PatientEntry.Request = new Bundle.RequestComponent();
      PatientEntry.Request.Method = Bundle.HTTPVerb.POST;
      PatientEntry.Request.Url = "Patient";

      //Add a Organization resource by Create
      Organization OrganizationOne = new Organization();
      OrganizationOne.Name = "Test OrganizationOne";
      OrganizationOne.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, OrganizationOneMRNIdentifer));

      var OrganizationOneEntry = new Bundle.EntryComponent();
      TransBundle.Entry.Add(OrganizationOneEntry);
      OrganizationOneEntry.Resource = OrganizationOne;
      OrganizationOneEntry.Request = new Bundle.RequestComponent();
      OrganizationOneEntry.Request.Method = Bundle.HTTPVerb.POST;            
      OrganizationOneEntry.FullUrl = OrgOneResourceIdFulUrl;

      OrganizationOneEntry.Resource = OrganizationOne;
      OrganizationOneEntry.Request = new Bundle.RequestComponent();
      OrganizationOneEntry.Request.Method = Bundle.HTTPVerb.POST;
      OrganizationOneEntry.Request.Url = "Organization";


      Bundle TransactionResult = null;
      try
      {
        TransactionResult = clientFhir.Transaction(TransBundle);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on POST Transaction bundle: " + Exec.Message);
      }
      
      Assert.True(TransactionResult.Type == Bundle.BundleType.TransactionResponse);      
      Assert.IsTrue(TransactionResult.Entry[0].Response.Status.Contains(System.Net.HttpStatusCode.Created.ToString()));
      Assert.IsTrue(TransactionResult.Entry[1].Response.Status.Contains(System.Net.HttpStatusCode.Created.ToString()));
      Patient TransactionResultPatient = TransactionResult.Entry[0].Resource as Patient;
      Organization TransactionResultOrganization = TransactionResult.Entry[1].Resource as Organization;
      string PatientOneResourceId = TransactionResult.Entry[0].Resource.Id;
      string OrgOneResourceId = TransactionResult.Entry[1].Resource.Id;


      //Check that the referance in the Patient to the Organization has been updated.
      Assert.AreEqual(TransactionResultPatient.ManagingOrganization.Reference, $"Organization/{TransactionResultOrganization.Id}");

      //Check the Response Etag matches the resource Version number
      string PatientResourceVersionNumber = TransactionResultPatient.VersionId;
      Assert.AreEqual(Common.Tools.HttpHeaderSupport.GetEntityTagHeaderValueFromVersion(PatientResourceVersionNumber).Tag , Common.Tools.HttpHeaderSupport.GetETagEntityTagHeaderValueFromETagString(TransactionResult.Entry[0].Response.Etag).Tag);

      //Check that the FullURL of the entry is correct aginst the returned Resource 
      string PatientFullUrlExpected = $"{StaticTestData.FhirEndpoint()}/Patient/{PatientOneResourceId}";
      Assert.AreEqual(PatientFullUrlExpected, TransactionResult.Entry[0].FullUrl);

      //------------------------------------------------------------------------------------------------------
      //Transaction Bundle 2 (Update) ------------------------------------------------------------------------
      //------------------------------------------------------------------------------------------------------
      
      TransBundle.Id = Guid.NewGuid().ToString();
      TransBundle.Entry.Clear();
      //Patient      
      PatientOne.Id = PatientOneResourceId;
      PatientOne.Name.Clear();
      string PatientFamilyName = "TestPatientUpdate";
      PatientOne.Name.Add(HumanName.ForFamily(PatientFamilyName).WithGiven("TestUpdate"));
      //PatientOne.BirthDateElement = new Date("1979-09-30");
      //PatientOne.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, PatientOneMRNIdentifer));
      //PatientOne.Gender = AdministrativeGender.Unknown;

      PatientEntry = new Bundle.EntryComponent();
      TransBundle.Entry.Add(PatientEntry);
      PatientResourceIdFulUrl = $"{StaticTestData.FhirEndpoint()}/Patient/{PatientOneResourceId}";
      PatientEntry.FullUrl = PatientResourceIdFulUrl;      
      PatientEntry.Resource = PatientOne;
      PatientEntry.Request = new Bundle.RequestComponent();
      PatientEntry.Request.Method = Bundle.HTTPVerb.PUT;
      PatientEntry.Request.Url = $"Patient/{PatientOneResourceId}";

      //Organization      
      OrganizationOne.Id = OrgOneResourceId;
      OrganizationOne.Name = "Test OrganizationOne Updated";
      //OrganizationOne.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, OrganizationOneMRNIdentifer));

      OrganizationOneEntry = new Bundle.EntryComponent();
      TransBundle.Entry.Add(OrganizationOneEntry);
      OrgOneResourceIdFulUrl = $"{StaticTestData.FhirEndpoint()}/Organization/{OrgOneResourceId}";
      OrganizationOneEntry.FullUrl = OrgOneResourceIdFulUrl;         
      OrganizationOneEntry.Resource = OrganizationOne;
      OrganizationOneEntry.Request = new Bundle.RequestComponent();
      OrganizationOneEntry.Request.Method = Bundle.HTTPVerb.PUT;
      OrganizationOneEntry.Request.Url = $"Organization/{OrgOneResourceId}";

      TransactionResult = null;
      try
      {
        TransactionResult = clientFhir.Transaction(TransBundle);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on PUT Transaction bundle: " + Exec.Message);
      }
      Assert.IsTrue(TransactionResult.Entry[0].Response.Status.Contains(System.Net.HttpStatusCode.OK.ToString()));
      Assert.IsTrue(TransactionResult.Entry[1].Response.Status.Contains(System.Net.HttpStatusCode.OK.ToString()));

      TransactionResultPatient = TransactionResult.Entry[0].Resource as Patient;
      TransactionResultOrganization = TransactionResult.Entry[1].Resource as Organization;

      //Check the family name was updated in the returned resource
      Assert.AreEqual(PatientFamilyName, TransactionResultPatient.Name[0].Family);

      //------------------------------------------------------------------------------------------------------
      //Transaction Bundle 3 (GET) ------------------------------------------------------------------------
      //------------------------------------------------------------------------------------------------------
      TransBundle.Id = Guid.NewGuid().ToString();
      TransBundle.Entry.Clear();

      PatientEntry = new Bundle.EntryComponent();
      TransBundle.Entry.Add(PatientEntry);
      PatientEntry.Request = new Bundle.RequestComponent();
      PatientEntry.Request.Method = Bundle.HTTPVerb.GET;
      PatientEntry.Request.Url = $"Patient/{TransactionResultPatient.Id}";

      OrganizationOneEntry = new Bundle.EntryComponent();
      TransBundle.Entry.Add(OrganizationOneEntry);
      OrganizationOneEntry.Request = new Bundle.RequestComponent();
      OrganizationOneEntry.Request.Method = Bundle.HTTPVerb.GET;
      OrganizationOneEntry.Request.Url = $"Organization/{TransactionResultOrganization.Id}";

      TransactionResult = null;
      try
      {
        TransactionResult = clientFhir.Transaction(TransBundle);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on GET Transaction bundle" + Exec.Message);
      }
      Assert.IsTrue(TransactionResult.Entry[0].Response.Status.Contains(System.Net.HttpStatusCode.OK.ToString()));
      Assert.IsTrue(TransactionResult.Entry[1].Response.Status.Contains(System.Net.HttpStatusCode.OK.ToString()));

      TransactionResultPatient = TransactionResult.Entry[0].Resource as Patient;
      TransactionResultOrganization = TransactionResult.Entry[1].Resource as Organization;

      //------------------------------------------------------------------------------------------------------
      //Transaction Bundle 4 Search (GET) ------------------------------------------------------------------------
      //------------------------------------------------------------------------------------------------------
      TransBundle.Id = Guid.NewGuid().ToString();
      TransBundle.Entry.Clear();

      PatientEntry = new Bundle.EntryComponent();
      TransBundle.Entry.Add(PatientEntry);
      PatientEntry.Request = new Bundle.RequestComponent();
      PatientEntry.Request.Method = Bundle.HTTPVerb.GET;
      PatientEntry.Request.Url = $"Patient?identifier={StaticTestData.TestIdentiferSystem}|{PatientOneMRNIdentifer}";

      OrganizationOneEntry = new Bundle.EntryComponent();
      TransBundle.Entry.Add(OrganizationOneEntry);
      OrganizationOneEntry.Request = new Bundle.RequestComponent();
      OrganizationOneEntry.Request.Method = Bundle.HTTPVerb.GET;
      OrganizationOneEntry.Request.Url = $"Organization?identifier={StaticTestData.TestIdentiferSystem}|{OrganizationOneMRNIdentifer}";

      TransactionResult = null;
      try
      {
        TransactionResult = clientFhir.Transaction(TransBundle);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on GET Transaction bundle" + Exec.Message);
      }
      Assert.IsTrue(TransactionResult.Entry[0].Response.Status.Contains(System.Net.HttpStatusCode.OK.ToString()));
      Assert.IsTrue(TransactionResult.Entry[1].Response.Status.Contains(System.Net.HttpStatusCode.OK.ToString()));

      Bundle TransactionResultSearchPatientOneBundle = TransactionResult.Entry[0].Resource as Bundle;
      Bundle TransactionResultOrganizationSearchBundle = TransactionResult.Entry[1].Resource as Bundle;

      //Check we only got one back in the search bundle
      Assert.AreEqual(TransactionResultSearchPatientOneBundle.Entry.Count, 1);
      Assert.AreEqual(TransactionResultOrganizationSearchBundle.Entry.Count, 1);

      //Check that each we got back were the two we added.
      Assert.AreEqual(TransactionResultSearchPatientOneBundle.Entry[0].Resource.Id, PatientOneResourceId);
      Assert.AreEqual(TransactionResultOrganizationSearchBundle.Entry[0].Resource.Id, OrgOneResourceId);

      //------------------------------------------------------------------------------------------------------
      //Transaction Bundle 5 If-Match (GET) --------------------------------------------------------------------
      //------------------------------------------------------------------------------------------------------
      TransBundle.Id = Guid.NewGuid().ToString();
      TransBundle.Entry.Clear();

      PatientEntry = new Bundle.EntryComponent();
      TransBundle.Entry.Add(PatientEntry);
      PatientEntry.Request = new Bundle.RequestComponent();
      PatientEntry.Request.Method = Bundle.HTTPVerb.GET;
      PatientEntry.Request.Url = $"Patient?identifier={StaticTestData.TestIdentiferSystem}|{PatientOneMRNIdentifer}";
      PatientEntry.Request.IfMatch = Common.Tools.HttpHeaderSupport.GetETagString(TransactionResultSearchPatientOneBundle.Entry[0].Resource.VersionId);

      OrganizationOneEntry = new Bundle.EntryComponent();
      TransBundle.Entry.Add(OrganizationOneEntry);
      OrganizationOneEntry.Request = new Bundle.RequestComponent();
      OrganizationOneEntry.Request.Method = Bundle.HTTPVerb.GET;
      OrganizationOneEntry.Request.Url = $"Organization?identifier={StaticTestData.TestIdentiferSystem}|{OrganizationOneMRNIdentifer}";
      OrganizationOneEntry.Request.IfMatch = Common.Tools.HttpHeaderSupport.GetETagString(TransactionResultOrganizationSearchBundle.Entry[0].Resource.VersionId);

      TransactionResult = null;
      try
      {
        TransactionResult = clientFhir.Transaction(TransBundle);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on GET Transaction bundle" + Exec.Message);
      }
      Assert.IsTrue(TransactionResult.Entry[0].Response.Status.Contains(System.Net.HttpStatusCode.OK.ToString()));
      Assert.IsTrue(TransactionResult.Entry[1].Response.Status.Contains(System.Net.HttpStatusCode.OK.ToString()));

      TransactionResultSearchPatientOneBundle = TransactionResult.Entry[0].Resource as Bundle;
      TransactionResultOrganizationSearchBundle = TransactionResult.Entry[1].Resource as Bundle;

      //Check we only got one back in the search bundle
      Assert.AreEqual(TransactionResultSearchPatientOneBundle.Entry.Count, 1);
      Assert.AreEqual(TransactionResultOrganizationSearchBundle.Entry.Count, 1);


      //------------------------------------------------------------------------------------------------------
      //Transaction Bundle 6 If-Match (DELETE) --------------------------------------------------------------------
      //------------------------------------------------------------------------------------------------------
      TransBundle.Id = Guid.NewGuid().ToString();
      TransBundle.Entry.Clear();

      PatientEntry = new Bundle.EntryComponent();
      TransBundle.Entry.Add(PatientEntry);
      PatientEntry.Request = new Bundle.RequestComponent();
      PatientEntry.Request.Method = Bundle.HTTPVerb.DELETE;
      PatientEntry.Request.Url = $"Patient?identifier={StaticTestData.TestIdentiferSystem}|{PatientOneMRNIdentifer}";
      PatientEntry.Request.IfMatch = Common.Tools.HttpHeaderSupport.GetETagString(TransactionResultSearchPatientOneBundle.Entry[0].Resource.VersionId);

      OrganizationOneEntry = new Bundle.EntryComponent();
      TransBundle.Entry.Add(OrganizationOneEntry);
      OrganizationOneEntry.Request = new Bundle.RequestComponent();
      OrganizationOneEntry.Request.Method = Bundle.HTTPVerb.DELETE;
      OrganizationOneEntry.Request.Url = $"Organization?identifier={StaticTestData.TestIdentiferSystem}|{OrganizationOneMRNIdentifer}";
      OrganizationOneEntry.Request.IfMatch = Common.Tools.HttpHeaderSupport.GetETagString(TransactionResultOrganizationSearchBundle.Entry[0].Resource.VersionId);

      TransactionResult = null;
      try
      {
        TransactionResult = clientFhir.Transaction(TransBundle);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on GET Transaction bundle" + Exec.Message);
      }
      Assert.IsTrue(TransactionResult.Entry[0].Response.Status.Contains(System.Net.HttpStatusCode.NoContent.ToString()));
      Assert.IsTrue(TransactionResult.Entry[1].Response.Status.Contains(System.Net.HttpStatusCode.NoContent.ToString()));

      CleanUpByIdentifier(ResourceType.Patient);
      CleanUpByIdentifier(ResourceType.Organization);
      
    }
    
    private static string CreateFullUrlUUID(string OrgOneResourceIdFulUrl)
    {
      return $"urn:uuid:{OrgOneResourceIdFulUrl}";
    }
  }

}

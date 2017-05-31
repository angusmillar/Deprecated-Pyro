using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using NUnit.Framework;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;


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
      Patient PatientOne = new Patient();
      PatientOne.Name.Add(HumanName.ForFamily("TestPatient").WithGiven("Test"));
      PatientOne.BirthDateElement = new Date("1979-09-30");
      PatientOne.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, PatientOneMRNIdentifer));
      PatientOne.Gender = AdministrativeGender.Unknown;
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


      //--- Clean Up ---------------------------------------------------------
      //Clean up by deleting all Test Patients
      SearchParams sp = new SearchParams().Where("identifier=http://TestingSystem.org/id|");
      try
      {
        clientFhir.Delete("Patient", sp);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on conditional delete of resource Patient: " + Exec.Message);
      }

      //Clean up by deleting all Test Organization
      sp = new SearchParams().Where("identifier=http://TestingSystem.org/id|");
      try
      {
        clientFhir.Delete("Organization", sp);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on conditional delete of resource Organization: " + Exec.Message);
      }

    }

    private static string CreateFullUrlUUID(string OrgOneResourceIdFulUrl)
    {
      return $"urn:uuid:{OrgOneResourceIdFulUrl}";
    }
  }

}

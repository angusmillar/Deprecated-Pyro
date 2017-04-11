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

      //------------------------------------------------------------------------------------------------------
      //Transaction Bundle 1 (Create) ---------------------------------------------------------------------------------
      //------------------------------------------------------------------------------------------------------

      Bundle TransBundle = new Bundle();
      TransBundle.Id = Guid.NewGuid().ToString();
      TransBundle.Type = Bundle.BundleType.Transaction;
      TransBundle.Entry = new List<Bundle.EntryComponent>();

      //Add a Patient resource by Create
      Patient PatientOne = new Patient();
      PatientOne.Name.Add(HumanName.ForFamily("TestPatient").WithGiven("Test"));
      PatientOne.BirthDateElement = new Date("1979-09-30");
      PatientOne.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, "1"));
      PatientOne.Gender = AdministrativeGender.Unknown;

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
      OrganizationOne.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, "OrgOne"));

      var OrganizationOneEntry = new Bundle.EntryComponent();
      TransBundle.Entry.Add(OrganizationOneEntry);
      OrganizationOneEntry.Resource = OrganizationOne;
      OrganizationOneEntry.Request = new Bundle.RequestComponent();
      OrganizationOneEntry.Request.Method = Bundle.HTTPVerb.POST;
      string OrgOneResourceIdFulUrl = CreateFullUrlUUID(Guid.NewGuid().ToString());      
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
        Assert.True(false, "Exception thrown on resource Create: " + Exec.Message);
      }

      Assert.IsTrue(TransactionResult.Entry[0].Response.Status.Contains(System.Net.HttpStatusCode.Created.ToString()));
      Assert.IsTrue(TransactionResult.Entry[1].Response.Status.Contains(System.Net.HttpStatusCode.Created.ToString()));

      //------------------------------------------------------------------------------------------------------
      //Transaction Bundle 2 (Update) ------------------------------------------------------------------------
      //------------------------------------------------------------------------------------------------------

      string PatientOneResourceId = TransactionResult.Entry[0].Resource.Id;
      string OrgOneResourceId = TransactionResult.Entry[1].Resource.Id;

      TransBundle.Id = Guid.NewGuid().ToString();
      TransBundle.Entry.Clear();
      //Patient
      PatientOne.Name.Clear();
      PatientOne.Id = PatientOneResourceId;
      PatientOne.Name.Add(HumanName.ForFamily("TestPatientUpdate").WithGiven("TestUpdate"));
      PatientOne.BirthDateElement = new Date("1979-09-30");
      PatientOne.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, "1"));
      PatientOne.Gender = AdministrativeGender.Unknown;

      PatientEntry = new Bundle.EntryComponent();
      TransBundle.Entry.Add(PatientEntry);
      PatientResourceIdFulUrl = $"{StaticTestData.FhirEndpoint()}/Patient/{PatientOneResourceId}";
      PatientEntry.FullUrl = PatientResourceIdFulUrl;      
      PatientEntry.Resource = PatientOne;
      PatientEntry.Request = new Bundle.RequestComponent();
      PatientEntry.Request.Method = Bundle.HTTPVerb.PUT;
      PatientEntry.Request.Url = $"Patient/{PatientOneResourceId}";

      //Organization
      OrganizationOne = new Organization();
      OrganizationOne.Id = OrgOneResourceId;
      OrganizationOne.Name = "Test OrganizationOne Updated";
      OrganizationOne.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, "OrgOne"));

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
        Assert.True(false, "Exception thrown on resource Create: " + Exec.Message);
      }
      Assert.IsTrue(TransactionResult.Entry[0].Response.Status.Contains(System.Net.HttpStatusCode.OK.ToString()));
      Assert.IsTrue(TransactionResult.Entry[1].Response.Status.Contains(System.Net.HttpStatusCode.OK.ToString()));



    }

    private static string CreateFullUrlUUID(string OrgOneResourceIdFulUrl)
    {
      return $"urn:uuid:{OrgOneResourceIdFulUrl}";
    }
  }

}

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
  class Test_BasicRequestes
  {
    private string ServerEndPoint = string.Empty;
    private string FhirEndpoint = string.Empty;
    private System.IDisposable Server;

    [SetUp]
    public void Setup()
    {
      System.Threading.Thread.Sleep(1000 * 3);
      string LocalHost = "http://localhost";
      ServerEndPoint = $"{LocalHost}:{Pyro.Common.Web.StaticWebInfo.TestingPort}";
      FhirEndpoint = $"{LocalHost}:{Pyro.Common.Web.StaticWebInfo.TestingPort}/{Pyro.Common.Web.StaticWebInfo.ServiceRoute}";
      Server = WebApp.Start<TestStartup>(ServerEndPoint);
    }

    [TearDown]
    public void TearDown()
    {
      Server.Dispose();
    }

    [Test]
    public void Test_CRUD()
    {
      Hl7.Fhir.Rest.FhirClient clientFhir = new Hl7.Fhir.Rest.FhirClient(FhirEndpoint, false);
      clientFhir.Timeout = 1000 * 480; // give the call a while to execute (particularly while debugging).

      string PatientResourceId = string.Empty;

      //Add a Patient resource by Update
      Patient PatientOne = new Patient();
      PatientOne.Name.Add(HumanName.ForFamily("TestPatient").WithGiven("Test"));
      PatientOne.BirthDateElement = new Date("1979-09-30");
      PatientOne.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, "1"));
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
        PatientResult = (Patient)clientFhir.Get($"{FhirEndpoint}/Patient/{PatientResourceId}");
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
        PatientResult = (Patient)clientFhir.Get($"{FhirEndpoint}/Patient/{PatientResourceId}");
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
        var Result = clientFhir.Get($"{FhirEndpoint}/Patient/{PatientResourceId}");
      }
      catch (Hl7.Fhir.Rest.FhirOperationException OpExec)
      {
        Assert.AreEqual(OpExec.Status, System.Net.HttpStatusCode.Gone, "Final Get did not return Http Status of Gone.");
      }

    }
  }

}

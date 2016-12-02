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
  class Test_ConditionalRequests
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
    public void Test_ConditionalUpdate()
    {
      Hl7.Fhir.Rest.FhirClient clientFhir = new Hl7.Fhir.Rest.FhirClient(FhirEndpoint, false);
      clientFhir.Timeout = 1000 * 480; // give the call a while to execute (particularly while debugging).

      // Prepare 3 test patients
      Patient p1 = new Patient();
      p1.Id = "TestPat1";
      p1.Name.Add(HumanName.ForFamily("Postlethwaite").WithGiven("Brian"));
      p1.BirthDateElement = new Date("1970-01");
      p1.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, "1"));
      var r1 = clientFhir.Update(p1);

      Patient p2 = new Patient();
      p2.Id = "TestPat2";
      p2.Name.Add(HumanName.ForFamily("Portlethwhite").WithGiven("Brian"));
      p2.BirthDateElement = new Date("1970-01");
      p2.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, "1"));
      var r2 = clientFhir.Update(p2);

      Patient p3 = new Patient();
      p3.Id = "TestPat3";
      p3.Name.Add(HumanName.ForFamily("Dole").WithGiven("Bob"));
      p3.BirthDateElement = new Date("1957-01");
      p3.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, "1"));
      var r3 = clientFhir.Update(p3);


      // Test the conditional update now
      // Try to update Bob Doles data
      Patient p3a = new Patient();
      p3a.Name.Add(HumanName.ForFamily("Dole").WithGiven("Bob"));
      p3a.BirthDateElement = new Date("1957-01-12");
      p3a.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, "1"));
      SearchParams sp = new SearchParams().Where("name=Dole").Where("birthDate=1957-01");
      var r3a = clientFhir.Update(p3a, sp);

      Assert.AreEqual("TestPat3", r3a.Id, "pat3 should have been updated (not a new one created)");
      Assert.AreEqual("1957-01-12", r3a.BirthDate, "Birth date should have been updated");

      // Try to update Brian's data (which has multuple rows!)
      Patient p1a = new Patient();
      p1a.Name.Add(HumanName.ForFamily("Postlethwaite").WithGiven("Brian"));
      p1a.BirthDateElement = new Date("1970-02");
      p1a.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, "1"));
      sp = new SearchParams().Where("identifier=1");
      try
      {
        var r1a = clientFhir.Update(p1a, sp);
        Assert.Fail("This identifier is used multiple times, the conditional update should have failed");
      }
      catch (FhirOperationException ex)
      {
        Assert.AreEqual(System.Net.HttpStatusCode.PreconditionFailed, ex.Status, "Expected failure of the update due to a pre-condition check");
      }

      // Try to update Bob Doles data with incorrect id
      Patient p3b = new Patient();
      p3b.Id = "NotTheCorrectId";
      p3b.Name.Add(HumanName.ForFamily("Dole").WithGiven("Bob"));
      p3b.BirthDateElement = new Date("1957-01-01");
      p3b.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, "1"));
      try
      {
        var r3b = clientFhir.Update(p3b, sp);
        Assert.Fail("This identifier given in the resource Update does not match the Id in the resource located by search.");
      }
      catch (FhirOperationException ex)
      {
        Assert.AreEqual(System.Net.HttpStatusCode.PreconditionFailed, ex.Status, "Expected failure of the update due to a pre-condition check");
      }

      // Try to update New Patient resource where search returns zero hits and Resource is created occurs
      Patient p4 = new Patient();
      p4.Name.Add(HumanName.ForFamily("Dole4").WithGiven("John"));
      p4.BirthDateElement = new Date("1957-01-01");
      p4.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, "2"));
      sp = new SearchParams().Where("identifier=http://TestingSystem.org/id|2");
      Patient r4 = null;

      r4 = clientFhir.Update(p4, sp);

      //Clean up by deleting all resources created while also testing Conditional Delete many
      sp = new SearchParams().Where("identifier=http://TestingSystem.org/id|");
      try
      {
        clientFhir.Delete("Patient", sp);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on conditional delete of resource G: " + Exec.Message);
      }

    }
  }

}

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
  class Test_ConditionalRequests
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
      //Hl7.Fhir.Rest.FhirClient clientFhir = new Hl7.Fhir.Rest.FhirClient(StaticTestData.FhirEndpoint(), false);
      //clientFhir.Timeout = 1000 * 720; // give the call a while to execute (particularly while debugging).

      ////Clean up by deleting all resources created while also testing Conditional Delete many
      //SearchParams sp = new SearchParams().Where("identifier=http://TestingSystem.org/id|");
      //try
      //{
      //  clientFhir.Delete("Patient", sp);
      //}
      //catch (Exception Exec)
      //{
      //  Assert.True(false, "Exception thrown on conditional delete of resource G: " + Exec.Message);
      //}

      Server.Dispose();
    }

    [Test]
    [NonParallelizable]
    public void Test_ConditionalUpdate()
    {
      Hl7.Fhir.Rest.FhirClient clientFhir = new Hl7.Fhir.Rest.FhirClient(StaticTestData.FhirEndpoint(), false);
      clientFhir.Timeout = 1000 * 720; // give the call a while to execute (particularly while debugging).

      // Prepare 3 test patients
      Patient p1 = new Patient();
      string TestPat1 = Guid.NewGuid().ToString();
      p1.Id = TestPat1;
      p1.Name.Add(HumanName.ForFamily("Postlethwaite").WithGiven("Brian"));
      p1.BirthDateElement = new Date("1970-01");
      p1.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, "1"));
      var r1 = clientFhir.Update(p1);

      Patient p2 = new Patient();
      string TestPat2 = Guid.NewGuid().ToString();
      p2.Id = TestPat2;
      p2.Name.Add(HumanName.ForFamily("Portlethwhite").WithGiven("Brian"));
      p2.BirthDateElement = new Date("1970-01");
      p2.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, "1"));
      var r2 = clientFhir.Update(p2);

      Patient p3 = new Patient();
      string TestPat3 = Guid.NewGuid().ToString();
      p3.Id = TestPat3;
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
      SearchParams sp = new SearchParams().Where("name=Dole").Where("birthdate=1957-01");
      var r3a = clientFhir.Update(p3a, sp);

      Assert.AreEqual(TestPat3, r3a.Id, "pat3 should have been updated (not a new one created)");
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

      try
      {
        r4 = clientFhir.Update(p4, sp);
      }
      catch (FhirOperationException ex)
      {
        Assert.True(false, "Update p4 failed" + ex.Message);
      }


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

    [Test]
    [NonParallelizable]
    public void Test_ConditionalCreate()
    {
      Hl7.Fhir.Rest.FhirClient clientFhir = new Hl7.Fhir.Rest.FhirClient(StaticTestData.FhirEndpoint(), false);
      clientFhir.Timeout = 1000 * 600; // give the call a while to execute (particularly while debugging).
      string TempResourceVersion = string.Empty;
      string TempResourceId = string.Empty;

      //Best to have this clean up here as things can get out of 
      //synch with the database when debugging.
      //We always need a clean db to start run.
      var sp = new SearchParams().Where("identifier=http://TestingSystem.org/id|");
      try
      {
        clientFhir.Delete("Patient", sp);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on conditional delete of resource G: " + Exec.Message);
      }


      // Prepare test patient
      Patient PatientOne = new Patient();
      PatientOne.Name.Add(HumanName.ForFamily("FhirMan").WithGiven("Sam"));
      PatientOne.BirthDateElement = new Date("1970-01");
      PatientOne.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, "5"));

      SearchParams SearchParams = new SearchParams().Where("identifier=5");
      try
      {
        var ResultOne = clientFhir.Create(PatientOne, SearchParams);
        TempResourceId = ResultOne.Id;
        TempResourceVersion = ResultOne.VersionId;
      }
      catch (FhirOperationException execOper)
      {
        Assert.Fail("Exception was thrown on Condition Create, message was: " + execOper.Message);
      }

      try
      {
        //This will return status OK but does not commit the resource and therefore
        //does not increment the resource version number
        clientFhir.Create(PatientOne, SearchParams);
      }
      catch (FhirOperationException execOper)
      {
        Assert.Fail("Exception was thrown on Condition Create, message was: " + execOper.Message);
      }

      try
      {
        //This will return status OK but does not commit the resource and therefore
        //does not increment the resource version number
        var PatientResult = (Patient)clientFhir.Get($"{StaticTestData.FhirEndpoint()}/Patient/{TempResourceId}");
        Assert.AreEqual(TempResourceVersion, PatientResult.VersionId, "The Version Id was not correct post Conditional Create when Resource was found.");
      }
      catch (FhirOperationException execOper)
      {
        Assert.Fail("Exception was thrown on Condition Create get operation, message was: " + execOper.Message);
      }


      // Create another Patient with the same name 
      Patient PatientTwo = new Patient();
      PatientTwo.Name.Add(HumanName.ForFamily("FhirMan").WithGiven("Sam"));
      PatientTwo.BirthDateElement = new Date("1970-01");
      PatientTwo.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, "6"));
      try
      {
        var ResultTwo = clientFhir.Create(PatientTwo);
      }
      catch (FhirOperationException execOper)
      {
        Assert.Fail("Exception was thrown on Condition Create, message was: " + execOper.Message);
      }

      //Now try an Create another again with a search on the Name
      //This should fail as it will resolve to many resource
      Patient PatientThree = new Patient();
      PatientThree.Name.Add(HumanName.ForFamily("FhirMan").WithGiven("Sam"));
      PatientThree.BirthDateElement = new Date("1970-01");
      PatientThree.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, "7"));
      SearchParams = new SearchParams().Where("family=FhirMan").Where("given=Sam");
      try
      {
        var ResultThree = clientFhir.Create(PatientTwo, SearchParams);
        Assert.IsNull(ResultThree, "ResultThree should be null as the ConditionaCreate search parameters should find many resource");
      }
      catch (FhirOperationException execOper)
      {
        Assert.AreEqual(System.Net.HttpStatusCode.PreconditionFailed, execOper.Status, "Did not get Http status 412 when resolving against many resources on ConditionalCreate");
      }



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

    [Test]
    [NonParallelizable]
    public void Test_ConditionalRead()
    {
      Hl7.Fhir.Rest.FhirClient clientFhir = new Hl7.Fhir.Rest.FhirClient(StaticTestData.FhirEndpoint(), false);
      clientFhir.Timeout = 1000 * 720; // give the call a while to execute (particularly while debugging).

      string PatientOneId = string.Empty;
      string PatientOneVersion = string.Empty;
      DateTimeOffset? PatientOneModified = null;

      // Prepare 3 test patients
      Patient PatientOne = new Patient();

      string TestPat1 = Guid.NewGuid().ToString();
      PatientOne.Id = TestPat1;
      PatientOne.Name.Add(HumanName.ForFamily("FhirMan").WithGiven("Sam"));
      PatientOne.BirthDateElement = new Date("1970-01");
      PatientOne.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, "6"));

      Patient ResultOne = null;
      try
      {
        ResultOne = clientFhir.Update(PatientOne);
        PatientOneId = ResultOne.Id;
        PatientOneVersion = ResultOne.VersionId;
        PatientOneModified = ResultOne.Meta.LastUpdated;
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on resource Get: " + Exec.Message);
      }


      Patient PatientTwo = null;
      try
      {
        //Resource has not changed so should return a 304 Not Modified
        PatientTwo = clientFhir.Read<Patient>($"{StaticTestData.FhirEndpoint()}/Patient/{PatientOneId}", PatientOneVersion, PatientOneModified);
        Assert.Fail("Conditional Read is expected to throw an exception due to bug in FHIR .NET API");
      }
      catch (FhirOperationException ExecOp)
      {
        //Catch the error and check it is a 304 http status.
        Assert.True(true, "FhirOperationException should be thrown on resource Read: " + ExecOp.Message);
        Assert.IsTrue(ExecOp.Status.IsRedirection());
      }

      PatientTwo = null;
      PatientOneModified = PatientOneModified.Value.AddMinutes(-1);
      try
      {
        //If-Modified-Since has been pushed back 1 min so we should get a resource back this time
        PatientTwo = clientFhir.Read<Patient>($"{StaticTestData.FhirEndpoint()}/Patient/{PatientOneId}", PatientOneVersion, PatientOneModified);
        Assert.NotNull(PatientTwo, "Not Resource returned when 1 min subtracted from last-modified on Conditional Read.");
        //reset the PatientOneModified
        PatientOneModified = PatientTwo.Meta.LastUpdated;
      }
      catch (FhirOperationException ExecOp)
      {
        Assert.True(false, "FhirOperationException thrown on resource Read: " + ExecOp.Message);
        Assert.IsTrue(ExecOp.Status.IsRedirection());
      }

      PatientTwo = null;
      PatientOneVersion = "xxxxx";
      try
      {
        //If-None-Match version has been set to not match so we should get a resource back this time
        PatientTwo = clientFhir.Read<Patient>($"{StaticTestData.FhirEndpoint()}/Patient/{PatientOneId}", PatientOneVersion, PatientOneModified);
        Assert.NotNull(PatientTwo, "Not Resource returned when Resource Version did not match active resource Version on Conditional Read.");
      }
      catch (FhirOperationException ExecOp)
      {
        Assert.True(false, "FhirOperationException thrown on resource Read: " + ExecOp.Message);
      }

      //Clean up by deleting all Test Patients
      var sp = new SearchParams().Where("identifier=" + StaticTestData.TestIdentiferSystem + "|");
      try
      {
        clientFhir.Delete("Patient", sp);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on conditional delete of resource G: " + Exec.Message);
      }


    }

    [Test]
    [NonParallelizable]
    public void Test_PUT_IfMatch()
    {
      Hl7.Fhir.Rest.FhirClient clientFhir = new Hl7.Fhir.Rest.FhirClient(StaticTestData.FhirEndpoint(), false);
      clientFhir.Timeout = 1000 * 720; // give the call a while to execute (particularly while debugging).

      //Best to have this clean up here as things can get out of 
      //synch with the database when debugging.
      //We always need a clean db to start run.
      var sp = new SearchParams().Where("identifier=http://TestingSystem.org/id|");
      try
      {
        clientFhir.Delete("Patient", sp);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on conditional delete of resource G: " + Exec.Message);
      }

      string PatientOneId = string.Empty;
      string PatientOneVersion = string.Empty;
      DateTimeOffset? PatientOneModified = null;

      // Prepare Patient
      Patient PatientOne = new Patient();
      string TestPatIfMatch = Guid.NewGuid().ToString();
      PatientOne.Id = TestPatIfMatch;
      PatientOne.Name.Add(HumanName.ForFamily("IfMatch0").WithGiven("Test0"));
      PatientOne.BirthDateElement = new Date("1970-01");
      PatientOne.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, "AF28B8ED-B81A-41D4-96DE-9012ED1868BD"));

      Patient ResultOne = null;
      try
      {
        ResultOne = clientFhir.Update(PatientOne);
        PatientOneId = ResultOne.Id;
        PatientOneVersion = ResultOne.VersionId;
        PatientOneModified = ResultOne.Meta.LastUpdated;
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on resource Get: " + Exec.Message);
      }

      ResultOne.Name.Clear();
      ResultOne.Name.Add(HumanName.ForFamily("IfMatch1").WithGiven("Test1"));

      Patient ResultTwo = null;
      try
      {
        //Perform a Version aware update that should be successfully. This uses "if-match" HTTP Header.
        ResultTwo = clientFhir.Update(ResultOne, true);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on resource Get: " + Exec.Message);
      }

      //Increment the last returned resource's version by one and then attempt a version aware update.
      //This should fail with a HTTP Error '409 Conflict'
      ResultTwo.VersionId = (Convert.ToInt32(ResultTwo.VersionId) + 1).ToString();
      Patient ResultThree = null;
      try
      {
        ResultThree = clientFhir.Update(ResultTwo, true);
      }
      catch (FhirOperationException execOper)
      {
        Assert.AreEqual(System.Net.HttpStatusCode.Conflict, execOper.Status, "Did not get Http status 409 Conflict on incorrect Version aware update.");
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on Version aware update: " + Exec.Message);
      }

      //Clean up by deleting all Test Patients
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

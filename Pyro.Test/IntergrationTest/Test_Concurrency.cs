using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using NUnit.Framework;
//using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Utility;



namespace Pyro.Test.IntergrationTest
{
  [Category("Concurrency")]
  class Test_Concurrency
  {
    private System.IDisposable Server;

    [SetUp]
    public void Setup()
    {
      Server = StaticTestData.StartupServer();
    }

    [Test]
    public void Test_ConcurrencyOne()
    {
      List<Task> TaskList = new List<Task>();
      for (int i = 0; i < 10; i++)
      {
        TaskList.Add(Task.Factory.StartNew(() => PutPatient()));
      }
      
      Task.WaitAll(TaskList.ToArray());
      //Console.WriteLine("All threads complete");
      
    }

    private static void PutPatient()
    {
      Hl7.Fhir.Rest.FhirClient clientFhir = new Hl7.Fhir.Rest.FhirClient(StaticTestData.FhirEndpoint(), false);
      //Hl7.Fhir.Rest.FhirClient clientFhir = new Hl7.Fhir.Rest.FhirClient("https://stu3.test.pyrohealth.net/fhir", false);
      clientFhir.Timeout = 1000 * 720; // give the call a while to execute (particularly while debugging).
      //clientFhir.Timeout = 30000; // give the call a while to execute (particularly while debugging).
      Hl7.Fhir.Model.Patient Pat = new Hl7.Fhir.Model.Patient();
      //Pat.Id = Guid.NewGuid().ToString();
      Pat.Name = new List<Hl7.Fhir.Model.HumanName>()
      {
       new Hl7.Fhir.Model.HumanName()
       {
         Family = "millar104"
       }
      };
      var response = clientFhir.Create<Hl7.Fhir.Model.Patient>(Pat);
      string PatientResourceId = response.Id;
      Assert.AreEqual("1", response.VersionId);

      Pat.Id = PatientResourceId;
      Pat.Name[0].Family = "millar105";

      response = clientFhir.Update<Hl7.Fhir.Model.Patient>(Pat);
      Assert.AreEqual("2", response.VersionId);

      var PatientResult = (Hl7.Fhir.Model.Patient)clientFhir.Get($"{StaticTestData.FhirEndpoint()}/{PatientResourceId}");

      Assert.AreEqual(Hl7.Fhir.Model.ResourceType.Patient, PatientResult.ResourceType);
      
    }
  }
}

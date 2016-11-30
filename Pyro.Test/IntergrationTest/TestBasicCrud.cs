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
  class TestBasicCrud
  {    
    private string ServerEndPoint = string.Empty;    
    private string FhirEndpoint = string.Empty;

    [SetUp]
    public void Setup()
    {
      string LocalHost = "http://localhost";
      ServerEndPoint = $"{LocalHost}:{Pyro.Common.Web.StaticWebInfo.TestingPort}";
      FhirEndpoint = $"{LocalHost}:{Pyro.Common.Web.StaticWebInfo.TestingPort}/{Pyro.Common.Web.StaticWebInfo.ServiceRoute}";
    }

    [Test]
    public void TestCreate()
    {
      //Startup the server
      using (WebApp.Start<Pyro.Web.Startup>(ServerEndPoint))
      {
        
        Hl7.Fhir.Rest.FhirClient clientFhir = new Hl7.Fhir.Rest.FhirClient(FhirEndpoint, false);
        clientFhir.Timeout = 1000 * 480; // give the call a while to execute (particularly while debugging).
        
        string PatientOneResourceId = "IntergrationTest1";

        //Add a Patient resource by Update
        Patient PatientOne = new Patient();
        PatientOne.Id = PatientOneResourceId;
        PatientOne.Name.Add(HumanName.ForFamily("TestPatient").WithGiven("Test"));        
        PatientOne.Identifier.Add(new Identifier("http://example.org/abn", "1"));

        Patient PatientOneResourceResult = null;
        try
        {
          PatientOneResourceResult = clientFhir.Update(PatientOne);          
        }
        catch (Exception Exec)
        {
          Assert.True(false, "Exception thrown on resource Create: " + Exec.Message);          
        }
        Assert.NotNull(PatientOneResourceResult, "Resource create by Updated returned resource of null");
        Assert.AreEqual(PatientOneResourceId, PatientOneResourceResult.Id, "Resource created by Updated has incorrect Resource Id");

        //Get the Added resource by Id
        Patient PatientTwoResourceResult = null;
        try
        {
          //PatientOneResourceId
          PatientTwoResourceResult = (Patient)clientFhir.Get($"{FhirEndpoint}/Patient/{PatientOneResourceId}");
          //var r1 = clientFhir.Get("http://localhost:8888/test/stu3/fhir/Patient/Angus");
        }
        catch (Exception Exec)
        {
          Assert.True(false, "Exception thrown on resource Get: " + Exec.Message);
        }
        Assert.NotNull(PatientTwoResourceResult, "Resource create by Updated returned resource of null");
        Assert.AreEqual(PatientOneResourceId, PatientTwoResourceResult.Id, "Resource created by Updated has incorrect Resource Id");


      }
    }

    [Test]
    public void TestGetById()
    {
      //Startup the server
      using (WebApp.Start<Pyro.Web.Startup>(ServerEndPoint))
      {        
        
        Hl7.Fhir.Rest.FhirClient clientFhir = new Hl7.Fhir.Rest.FhirClient(FhirEndpoint, false);
        clientFhir.Timeout = 1000 * 480; // give the call a while to execute (particularly while debugging).
        
        try
        {
          
          var r1 = clientFhir.Get("http://localhost:8888/test/stu3/fhir/Patient/Angus");
        }
        catch(Exception Exec)
        {
          string Messsage = Exec.Message;
        }

        
        
      }


    }



    

  }
}

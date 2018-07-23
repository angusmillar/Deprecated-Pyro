using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Microsoft.Owin.Hosting;

namespace Pyro.Test.IntergrationTest
{
  public static class StaticTestData
  {
    public static string TestIdentiferSystem = "http://TestingSystem.org/id";
    private static string LocalHost = "http://localhost";

    public static System.IDisposable StartupServer()
    {
      System.Threading.Thread.Sleep(1000 * 3);
      Uri FhirEndpointUri = new Uri(Pyro.Common.Global.WebConfigProperties.ServiceBaseURL());
      string ServerEndPoint = $"{FhirEndpointUri.Scheme}://{FhirEndpointUri.Authority}";
      string FhirEndpoint = $"{ServerEndPoint}/{Pyro.Common.Web.StaticWebInfo.ServiceRoute}";
      return WebApp.Start<TestStartup>(ServerEndPoint);
    }

    public static string ServerEndPoint()
    {
      return $"{LocalHost}:{Pyro.Common.Web.StaticWebInfo.TestingPort}";
    }

    public static string FhirEndpoint()
    {
      return $"{ServerEndPoint()}/{Pyro.Common.Web.StaticWebInfo.ServiceRoute}";
    }

    public static Patient CreateTestPatient(string Mrn = "", string FhirId = "")
    {
      string PatientMRNIdentifer = Mrn;
      if (string.IsNullOrWhiteSpace(PatientMRNIdentifer))
        PatientMRNIdentifer = Guid.NewGuid().ToString();
      
      //Add a Patient resource by Create
      Patient Pat = new Patient();
      if (!string.IsNullOrWhiteSpace(FhirId))
        Pat.Id = FhirId;
      Pat.Name.Add(HumanName.ForFamily("TestPatient").WithGiven("Test"));
      Pat.BirthDateElement = new Date("1979-09-30");
      Pat.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, PatientMRNIdentifer));
      Pat.Gender = AdministrativeGender.Unknown;
      return Pat;
    }

  }
}

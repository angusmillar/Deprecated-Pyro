using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
      var Cache = new Pyro.Common.Cache.CacheCommon();
      Uri FhirEndpointUri = new Uri(Cache.WebConfigServiceBaseURL());
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

  }
}

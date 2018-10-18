using Pyro.Common.Global;
using Pyro.Common.Logging;
using System;

namespace Pyro.Common.BackgroundTask.TaskService.FhirApiDiscovery
{
  public class FhirApiDiscoveryService : IFhirApiDiscoveryService
  {
    private readonly IGlobalProperties IGlobalProperties;
    private readonly ILog ILog;

    public FhirApiDiscoveryService(ILog ILog, IGlobalProperties IGlobalProperties)
    {
      this.IGlobalProperties = IGlobalProperties;      
      this.ILog = ILog;
    }


    public string Run()
    {
      //return "localhost:8888";
      //"https://stu3.test.pyrohealth.net/fhir"
      
      string ServiceBaseURL = this.IGlobalProperties.ServiceBaseURL;
        
      if (!string.IsNullOrWhiteSpace(ServiceBaseURL))
      {
        //examples: 
        //localhost:8888/fhir
        //stu3.test.pyrohealth.net/fhir

        if (ServiceBaseURL.EndsWith($"/{Pyro.Common.Web.StaticWebInfo.ServiceRoute}"))
        {
          return ServiceBaseURL.Substring(0, ServiceBaseURL.Length - (Pyro.Common.Web.StaticWebInfo.ServiceRoute.Length + 1));
        }
        else
        {
          string message = $"The Pyro FHIR Server database 'ServiceConfiguraton' table parameter 'ServiceBaseURL' does not conform to what was expected, it should end with '{Pyro.Common.Web.StaticWebInfo.ServiceRoute}'. " +
                           "If this message is seen then perhaps the administrator of the Pyro FHIR Server has modified its web.config file command 'ServiceBaseURL' incorrectly by not ending the URL with '/fhir'. ";
          
          var Exec = new FormatException(message);
          ILog.Fatal(Exec, $"Failed to match the 'ServiceConfiguraton' table parameter 'ServiceBaseURL' of '{Pyro.Common.Web.StaticWebInfo.ServiceRoute}' with what was expected in code. It must end with '/{Common.Web.StaticWebInfo.ServiceRoute}'");
          throw Exec;
        }

      }
      else
      {
        throw new Exception("ServiceBaseURL was empty or null.");
      }
      
    }
  }
}

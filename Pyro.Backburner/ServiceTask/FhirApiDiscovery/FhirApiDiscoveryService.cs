using Pyro.Backburner.Tools;
using Pyro.Common.BackgroundTask.Task;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.RequestMetadata;
using Pyro.Common.Service.ResourceService;
using System;
using System.Data.Entity;
using Pyro.Common.Logging;
using Pyro.Common.ServiceRoot;
using Pyro.Common.Global;

namespace Pyro.Backburner.ServiceTask.FhirApiDiscovery
{
  public class FhirApiDiscoveryService : IFhirApiDiscoveryService
  {
    //private readonly IUnitOfWork IUnitOfWork;
    //private readonly IResourceServices IResourceApiServices;    
    //private readonly IRequestMetaFactory IRequestMetaFactory;
    //private readonly IPrimaryServiceRootCache IPrimaryServiceRootCache;
    private readonly IGlobalProperties IGlobalProperties;
    private readonly ILog ILog;

    public FhirApiDiscoveryService(ILog ILog, IGlobalProperties IGlobalProperties)
    {
      this.IGlobalProperties = IGlobalProperties;
      //this.IPrimaryServiceRootCache = IPrimaryServiceRootCache;
      this.ILog = ILog;
    }


    public string Run()
    {
      //return "localhost:8888";
      //"https://stu3.test.pyrohealth.net/fhir"
      
      //if (this.IGlobalProperties is IDbGlobalPropertiesRefresh DbGlobalPropertiesRefresh)
      //{
      //  DbGlobalPropertiesRefresh.RefreashFromDatabase();
      //}

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






      //IDtoRootUrlStore RootUrlStore = IPrimaryServiceRootCache.GetPrimaryRootUrlFromDatabase();
      //if (RootUrlStore != null)
      //{
      //  //examples: 
      //  //localhost:8888/fhir
      //  //stu3.test.pyrohealth.net/fhir

      //  if (RootUrlStore.Url.EndsWith($"/{Pyro.Common.Web.StaticWebInfo.ServiceRoute}"))
      //  {
      //    return RootUrlStore.Url.Substring(0, RootUrlStore.Url.Length - (Pyro.Common.Web.StaticWebInfo.ServiceRoute.Length + 1));
      //  }
      //  else
      //  {
      //    string message = $"The database ServiceRoute does not conform to what was expected, it should end with what ever StaticWebInfo.ServiceRoute is set to, which was is '{Pyro.Common.Web.StaticWebInfo.ServiceRoute}'. " +
      //                     "If this failes possiably we have updated the Pyro server code base by changing StaticWebInfo.ServiceRoute and then deployed to an exsisting " +
      //                     "database where the primary ServiceBaseUrl contains the older referanced StaticWebInfo.ServiceRoute as this service is obtaining the primary ServiceBaseUrl " +
      //                     "from the Pyro service database table named _ServiceBaseUrl. If so then the Pyro Server is now configured incorrectly and it's web.config file and database " +
      //                     $"entry need to be corrected. The Db ServiceBaseUrl was {RootUrlStore.Url} and yet the trailing segment expected from the StaticWebInfo.ServiceRoute code was {Pyro.Common.Web.StaticWebInfo.ServiceRoute}";          
      //    var Exec = new FormatException(message);
      //    ILog.Fatal(Exec, $"Failed to match database ServiceBaseUrl with what was expected in code. It must end with {Common.Web.StaticWebInfo.ServiceRoute}");
      //    throw Exec;
      //  }

      //}
      //else
      //{
      //  throw new Exception("Failed");
      //}

    }
  }
}

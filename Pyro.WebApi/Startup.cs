using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
//using System.Web.Mvc;
//using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.AspNet.SignalR;
using System.Threading;

[assembly: OwinStartup(typeof(Pyro.WebApi.Startup))]

namespace Pyro.WebApi
{
  public partial class Startup
  {
    public static HttpConfiguration HttpConfiguration { get; private set; }    
    protected RouteCollection _RouteCollection = RouteTable.Routes;
    public void Configuration(IAppBuilder app)
    {
      RegisterSignalRHubs(app);

      app.Use(async (environment, next) =>
      {
        var QueryString = environment.Environment["owin.RequestQueryString"] as string;
        var HttpMethod = environment.Environment["owin.RequestMethod"] as string;
        string RequestRoot = $"{environment.Request.Uri.Scheme}://{environment.Request.Uri.Authority}{environment.Request.Uri.AbsolutePath}";
        IHeaderDictionary HeaderDic = environment.Request.Headers;

        Console.WriteLine("----------------------------------- Request -----------------------------------");
        Console.WriteLine("");
        Console.WriteLine($"Received : {DateTimeOffset.Now.ToString()}");
        Console.WriteLine($"Method   : {HttpMethod}");
        Console.WriteLine($"Request  : {RequestRoot}");
        if (!string.IsNullOrWhiteSpace(QueryString))
          Console.WriteLine($"Query    : {QueryString}");
        Console.WriteLine("");
        Console.WriteLine("----------------------------------- Headers -----------------------------------");
        Console.WriteLine("");
        foreach (var Head in HeaderDic)
        {
          Console.WriteLine($"{Head.Key.PadRight(16, ' ')}: {string.Join(",", Head.Value)}");
        }
        Console.WriteLine("");
        Console.WriteLine("-------------------------------------------------------------------------------");
        Console.WriteLine("");
        await next();
        Console.WriteLine("----------------------------------- Response ----------------------------------");
        Console.WriteLine($"Response : {environment.Response.StatusCode} : {environment.Response.ReasonPhrase}");
        Console.WriteLine("-------------------------------------------------------------------------------");
      });

      HttpConfiguration = new HttpConfiguration();

      App_Start.SimpleInjectorWebApiInitializer.Initialize(HttpConfiguration);

      var IFhirExceptionFilter = (Pyro.Common.Exceptions.IFhirExceptionFilter)HttpConfiguration.DependencyResolver.GetService(typeof(Pyro.Common.Exceptions.IFhirExceptionFilter));
      HttpConfiguration.Filters.Add(IFhirExceptionFilter);

      
      Console.Title = "Pyro.ConsoleServer";

      //Warn up the database and show some warm messages while Synchronizeing the Database and Web.config file.
      WarmUpDatabaseAndSychWebConfiguration();      
      
      WebApiConfig.Register(HttpConfiguration);

      //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

      //BundleConfig.RegisterBundles(BundleTable.Bundles);
      ConfigureAuth(app);

      app.UseWebApi(HttpConfiguration);
    }

    //Warn up the database and show some warm messages while Synchronizeing the Database and Web.config file.
    private static void WarmUpDatabaseAndSychWebConfiguration()
    {
      var WarmUpMessages = new Pyro.Common.ProductText.PyroWarmUpMessages();
      WarmUpMessages.Start();
      System.Threading.Tasks.Task<bool> TaskResults = System.Threading.Tasks.Task<bool>.Factory.StartNew(() =>
      {
        try
        {
          using (HttpConfiguration.DependencyResolver.BeginScope())
          {
            Pyro.Common.Interfaces.Repositories.IUnitOfWork UnitOfWork = (Pyro.Common.Interfaces.Repositories.IUnitOfWork)HttpConfiguration.DependencyResolver.GetService(typeof(Pyro.Common.Interfaces.Repositories.IUnitOfWork));
            Pyro.Common.Global.IGlobalProperties GlobalProperties = (Pyro.Common.Global.IGlobalProperties)HttpConfiguration.DependencyResolver.GetService(typeof(Pyro.Common.Global.IGlobalProperties));
            Pyro.Common.Interfaces.Service.IServiceConfigurationService ServiceConfigurationService = (Pyro.Common.Interfaces.Service.IServiceConfigurationService)HttpConfiguration.DependencyResolver.GetService(typeof(Pyro.Common.Interfaces.Service.IServiceConfigurationService));
            bool WasUpdated = false;
            using (System.Data.Entity.DbContextTransaction Transaction = UnitOfWork.BeginTransaction())
            {
              try
              {
                WasUpdated = ServiceConfigurationService.SynchronizeServiceConfigrationWithGlobalProperties(GlobalProperties);
                if (WasUpdated)
                {
                  Pyro.Common.Logging.Logger.Log.Info("GlobalProperties were updated in ServiceConfiguration db table");
                }
                Transaction.Commit();
                return WasUpdated;
              }
              catch (Exception Exec)
              {
                Transaction.Rollback();
                Pyro.Common.Logging.Logger.Log.Error(Exec, $"Could not synch ServiceConfiguration with Web.config file.");
                throw Exec;
              }
            }
          }
        }
        catch (Exception Exec)
        {
          Pyro.Common.Logging.Logger.Log.Error(Exec, "SynchronizeServiceConfigrationWithGlobalProperties failed.");
          throw Exec;
        }
        //End of Task Thread.
      });

      try
      {
        //Here we are catching any exceptions that occured inside the Task thread above.
        TaskResults.Wait();
        bool Result = TaskResults.Result;
      }
      catch (Exception Exec)
      {
        string ExecMessage = "Server error: Unable to Synchronize database ServiceConfiguration table with Web.Config file. This is likely to be due to the FHIR server database connection being unavailable.";
        Pyro.Common.Logging.Logger.Log.Fatal(Exec, ExecMessage);
        throw new Exception(ExecMessage, Exec);
      }
      WarmUpMessages.Stop();
      Console.Clear();
    }

    //Register the SignalR Hubs for notification messaging to background service.
    private void RegisterSignalRHubs(IAppBuilder app)
    {
      var hubConfiguration = new HubConfiguration
      {
        EnableDetailedErrors = true,
        EnableJavaScriptProxies = false
      };
      app.MapSignalR(hubConfiguration);

    }



  }
}

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
      int RequestCounter = 1;
      app.Use(async (environment, next) =>
      {
        //Note: Console.IsOutputRedirected is true in IIS, check becasue if you fiddel with the console buffer while in IIS you get an exception.
        if (!Console.IsOutputRedirected)
        {
          var QueryString = environment.Environment["owin.RequestQueryString"] as string;
          var HttpMethod = environment.Environment["owin.RequestMethod"] as string;
          string RequestRoot = $"{environment.Request.Uri.Scheme}://{environment.Request.Uri.Authority}{environment.Request.Uri.AbsolutePath}";
          IHeaderDictionary HeaderDic = environment.Request.Headers;
          Console.Clear();
          Console.ResetColor();
          Console.ForegroundColor = ConsoleColor.Cyan;
          Console.WriteLine($"----------------------------------- Request ({RequestCounter.ToString().PadLeft(4, '0')}) ----------------------------");
          Console.WriteLine("");
          Console.ForegroundColor = ConsoleColor.Cyan;
          Console.Write($"Received : ");
          Console.ForegroundColor = ConsoleColor.White;
          Console.WriteLine($"{DateTimeOffset.Now.ToString()}");
          Console.ForegroundColor = ConsoleColor.Cyan;
          Console.Write($"Method   : ");
          Console.ForegroundColor = ConsoleColor.White;
          Console.WriteLine($"{HttpMethod}");
          Console.ForegroundColor = ConsoleColor.Cyan;
          Console.Write($"Request  : ");
          Console.ForegroundColor = ConsoleColor.White;
          Console.WriteLine($"{RequestRoot}");
          if (!string.IsNullOrWhiteSpace(QueryString))
          {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"Query    : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{QueryString}");
          }
          Console.WriteLine("");
          Console.ForegroundColor = ConsoleColor.Cyan;
          Console.WriteLine("----------------------------------- Headers -----------------------------------");
          Console.WriteLine("");
          foreach (var Head in HeaderDic)
          {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{Head.Key.PadRight(16, ' ')}: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{string.Join(",", Head.Value)}");
            Console.ForegroundColor = ConsoleColor.Cyan;
          }
          Console.WriteLine("");
          Console.ForegroundColor = ConsoleColor.Cyan;
          Console.WriteLine("-------------------------------------------------------------------------------");
          Console.ForegroundColor = ConsoleColor.White;
          Console.WriteLine("");
        }
        await next();
        if (!Console.IsOutputRedirected)
        {
          Console.ForegroundColor = ConsoleColor.Magenta;
          Console.WriteLine($"----------------------------------- Response ({RequestCounter.ToString().PadLeft(4, '0')}) ---------------------------");
          Console.ForegroundColor = ConsoleColor.Cyan;
          Console.Write($"Response : ");
          Console.ForegroundColor = GetResponseColor(environment.Response.StatusCode);
          Console.WriteLine($" {environment.Response.StatusCode} : {environment.Response.ReasonPhrase}");
          Console.ForegroundColor = ConsoleColor.Magenta;
          Console.WriteLine("-------------------------------------------------------------------------------");
          Console.ResetColor();
        }
        RequestCounter++;
      });

      HttpConfiguration = new HttpConfiguration();

      App_Start.SimpleInjectorWebApiInitializer.Initialize(HttpConfiguration);

      var IFhirExceptionFilter = (Pyro.Common.Exceptions.IFhirExceptionFilter)HttpConfiguration.DependencyResolver.GetService(typeof(Pyro.Common.Exceptions.IFhirExceptionFilter));
      HttpConfiguration.Filters.Add(IFhirExceptionFilter);

      if (!Console.IsOutputRedirected)
      {
        Console.Title = "Pyro.ConsoleServer";
      }
      //Warn up the database and show some warm messages while Synchronizeing the Database and Web.config file.
      WarmUpDatabaseAndSychWebConfiguration();

      WebApiConfig.Register(HttpConfiguration);

      ConfigureAuth(app);

      app.UseWebApi(HttpConfiguration);
    }

    private ConsoleColor GetResponseColor(int StatusCode)
    {
      if (StatusCode > 0 && StatusCode < 200)
        return ConsoleColor.Cyan;
      if (StatusCode >= 200 && StatusCode < 300)
        return ConsoleColor.Green;
      if (StatusCode >= 300 && StatusCode < 400)
        return ConsoleColor.Magenta;
      if (StatusCode >= 400 && StatusCode < 500)
        return ConsoleColor.Yellow;
      if (StatusCode >= 500 && StatusCode < 600)
        return ConsoleColor.Red;
      else
        return ConsoleColor.Cyan;
    }

    //Warn up the database and show some warm messages while Synchronizeing the Database and Web.config file.
    private static void WarmUpDatabaseAndSychWebConfiguration()
    {
      var WarmUpMessages = new Pyro.Common.ProductText.PyroWarmUpMessages();
      if (!Console.IsOutputRedirected)
      {
        WarmUpMessages.Start("Pyro FHIR Server", $"Version: {System.Diagnostics.FileVersionInfo.GetVersionInfo(typeof(Pyro.Common.Global.GlobalProperties).Assembly.Location).ProductVersion}");
      }


      System.Threading.Tasks.Task<bool> SynchronizeTaskResults = System.Threading.Tasks.Task<bool>.Factory.StartNew(() =>
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
        SynchronizeTaskResults.Wait();
        bool Result = SynchronizeTaskResults.Result;
      }
      catch (Exception Exec)
      {
        string ExecMessage = "Internal Server Error: Unable to Synchronize database ServiceConfiguration table with Web.Config file. This is likely to be due to the FHIR server database connection being unavailable.";
        Pyro.Common.Logging.Logger.Log.Fatal(Exec, ExecMessage);
        throw new Exception(ExecMessage, Exec);
      }



      System.Threading.Tasks.Task<bool> SeedTaskResults = System.Threading.Tasks.Task<bool>.Factory.StartNew(() =>
      {
        using (HttpConfiguration.DependencyResolver.BeginScope())
        {
          Pyro.Engine.Services.ResourceSeed.IResourceSeedingService ResourceSeedingService = (Pyro.Engine.Services.ResourceSeed.IResourceSeedingService)HttpConfiguration.DependencyResolver.GetService(typeof(Pyro.Engine.Services.ResourceSeed.IResourceSeedingService));
          Pyro.Common.Interfaces.Repositories.IUnitOfWork UnitOfWork = (Pyro.Common.Interfaces.Repositories.IUnitOfWork)HttpConfiguration.DependencyResolver.GetService(typeof(Pyro.Common.Interfaces.Repositories.IUnitOfWork));
          try
          {
            ResourceSeedingService.Process();
            return true;
          }
          catch (Exception Exec)
          {
            Pyro.Common.Logging.Logger.Log.Error(Exec, $"IResourceSeedingService thrown Exception on Pyro server startup.");
            throw Exec;
          }
        }
        //End of Task Thread.
      });

      try
      {
        //Here we are catching any exceptions that occured inside the Task thread above.
        SeedTaskResults.Wait();
        bool Result = SeedTaskResults.Result;
      }
      catch (Exception Exec)
      {
        string ExecMessage = "Internal Server Error: Unable to Seed or chack Seed resources on startup. This is likely to be due to the FHIR server database connection being unavailable.";
        Pyro.Common.Logging.Logger.Log.Fatal(Exec, ExecMessage);
        throw new Exception(ExecMessage, Exec);
      }
      

      if (!Console.IsOutputRedirected)
      {
        WarmUpMessages.Stop();
        Console.Clear();
      }
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

using System;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Web.Routing;
using Microsoft.AspNet.SignalR;

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
        //Note: Console.IsOutputRedirected is true in IIS, check because if you fiddle with the console buffer while in IIS you get an exception.
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

    

    //Warn up the database and show some warm messages while Synchronizeing the Database and Web.config file.
    private static void WarmUpDatabaseAndSychWebConfiguration()
    {
      var WarmUpMessages = new Pyro.Common.ProductText.PyroWarmUpMessages();
      if (!Console.IsOutputRedirected)
      {
        WarmUpMessages.Start("Pyro FHIR Server", $"Version: {System.Diagnostics.FileVersionInfo.GetVersionInfo(typeof(Pyro.Common.Global.GlobalProperties).Assembly.Location).ProductVersion}");
      }

      //Check that we did not leave the Migration switch on for production.
      if (!System.Diagnostics.Debugger.IsAttached && Common.Database.StaticDatabaseInfo.DatabaseCreateSwitches.DevelopmentOnlyGenerateMigrations)
      {
        string Message = "Oh no, the developer has left a development only setting of 'DevelopmentOnlyGenerateMigrations' as True and this code appears to be running outside of the development environment. " +
          "Unfortunately this is not allowed and the server will not be able to start-up. Please contact your system administrator.";
        Pyro.Common.Logging.Logger.Log.Fatal(Message);
        throw new System.ApplicationException(Message);
      }

      Pyro.Common.Logging.Logger.Log.Info("********************************************************************************");
      Pyro.Common.Logging.Logger.Log.Info("             -=# The Pyro FHIR Server is starting up. #=-                       ");
      Pyro.Common.Logging.Logger.Log.Info("********************************************************************************");
      //Check the database migrations are up-to-date with the application 
      Pyro.Common.Logging.Logger.Log.Info("Server start-up: Check the Database Migrations are run.");
      if (App_Start.StartupPyroDatabaseMigrationCheck.RunTask(HttpConfiguration))
      {
        Pyro.Common.Logging.Logger.Log.Info("Server start-up: Database is up-to-date.");
      }
      else
      {
        if (!Console.IsOutputRedirected)
        {
          WarmUpMessages.Stop();
          Console.Clear();
        }
        string Message = "Database upgrade is required. Please consider running the Pyro.DbManager to upgrade your database.";
        Console.WriteLine();        
        Console.WriteLine("Database upgrade is required.");
        Console.WriteLine();
        Console.WriteLine("Please consider running the Pyro.DbManager to upgrade your database.");
        Console.WriteLine();
        Console.WriteLine("The application must now exit, press any key.");        
        Console.ReadKey();
        Pyro.Common.Logging.Logger.Log.Fatal(Message);
        throw new Exception(Message);
      }

      //Synch the Web Configuration file 
      Pyro.Common.Logging.Logger.Log.Info("Server start-up: Synchronise the web.config file to database table ServiceConfiguration.");
      App_Start.StartupPyroConfirgrationSynch.RunTask(HttpConfiguration);

      //Synch the Web Configuration file 
      Pyro.Common.Logging.Logger.Log.Info("Server start-up: Reset Pyro.Backburner connection records.");
      App_Start.StartupBackburnerClearConnections.RunTask(HttpConfiguration);

      //Check seeded FHIR Resource and update if required      
      Pyro.Common.Logging.Logger.Log.Info("Server start-up: Seed reference FHIR resources as required.");
      App_Start.StartupPyroResourceSeeding.RunTask(HttpConfiguration);

      //Check for any FHIR start-up task to process on start-up
      //NOTE: This Task runs asynchronous, it does not stop the server from starting. 
      Pyro.Common.Logging.Logger.Log.Info("Server start-up: Run pending FHIR Tasks.");
      App_Start.StartupPyroTaskRunner.RunTask(HttpConfiguration);      

      if (!Console.IsOutputRedirected)
      {
        WarmUpMessages.Stop();
        Console.Clear();
      }
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

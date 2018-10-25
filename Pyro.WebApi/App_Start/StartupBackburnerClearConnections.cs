using System;
using System.Web.Http;
using System.Threading.Tasks;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.Service;

namespace Pyro.WebApi.App_Start
{
  public static class StartupBackburnerClearConnections
  {
    public static bool RunTask(HttpConfiguration HttpConfiguration)
    {
      Task<bool> StartupBackburnerClearConnectionsTaskResults = Task<bool>.Factory.StartNew(() =>
      {
        try
        {
          using (HttpConfiguration.DependencyResolver.BeginScope())
          {
            IServiceFhirTaskWorkerManager IServiceFhirTaskWorkerManager = (IServiceFhirTaskWorkerManager)HttpConfiguration.DependencyResolver.GetService(typeof(IServiceFhirTaskWorkerManager));
            IServiceFhirTaskWorkerManager.PyroServerStartup();            
            return true;
          }
        }
        catch (Exception Exec)
        {
          Pyro.Common.Logging.Logger.Log.Error(Exec, "StartupBackburnerClearConections failed.");
          throw Exec;
        }
        //End of Task Thread.
      });

      try
      {
        //Here we are catching any exceptions that occurred inside the Task thread above.
        StartupBackburnerClearConnectionsTaskResults.Wait();
        return StartupBackburnerClearConnectionsTaskResults.Result;        
      }
      catch (Exception Exec)
      {
        string ExecMessage = "Internal Server Error: Start-up Backburner Clear Connections Check failed!.";
        Console.WriteLine();
        Console.WriteLine(ExecMessage);
        if (Exec.InnerException != null)
          Console.WriteLine(Exec.InnerException.Message);
        Console.ReadKey();
        Pyro.Common.Logging.Logger.Log.Fatal(Exec, ExecMessage);
        throw new Exception(ExecMessage, Exec);
      }
    }
  }
}
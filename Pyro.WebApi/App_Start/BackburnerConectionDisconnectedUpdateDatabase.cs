using System;
using System.Web.Http;
using System.Threading.Tasks;
using Pyro.Common.Interfaces.Service;
using System.Web.Http.Dependencies;
using SimpleInjector.Lifestyles;

namespace Pyro.WebApi.App_Start
{
  public static class BackburnerConectionDisconnectedUpdateDatabase
  {
    public static bool RunTask(IDependencyResolver DependencyResolver, string ConnectionId)
    {
      Task<bool> ConectionUpdateTaskResults = Task<bool>.Factory.StartNew(() =>
      {
        try
        {
          using (DependencyResolver.BeginScope())
          {
            IServiceFhirTaskWorkerManager IServiceFhirTaskWorkerManager = (IServiceFhirTaskWorkerManager)DependencyResolver.GetService(typeof(IServiceFhirTaskWorkerManager));            
            IServiceFhirTaskWorkerManager.WorkerDisconnected(ConnectionId);              
            return true;
          }
        }
        catch (Exception Exec)
        {
          Pyro.Common.Logging.Logger.Log.Error(Exec, "BackburnerConectionDisconnectedUpdateDatabase failed.");
          throw Exec;
        }
        //End of Task Thread.
      });

      try
      {
        //Here we are catching any exceptions that occurred inside the Task thread above.
        ConectionUpdateTaskResults.Wait();
        return ConectionUpdateTaskResults.Result;        
      }
      catch (Exception Exec)
      {
        string ExecMessage = "Internal Server Error: Start-up Pyro Database Migration Check failed!.";
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
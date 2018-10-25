using System;
using System.Threading.Tasks;
using Pyro.Common.Interfaces.Service;
using SimpleInjector.Lifestyles;

namespace Pyro.Backburner.App_Start
{
  public static class BackburnerConectionConnectedUpdateDatabase
  {
    public static bool RunTask(SimpleInjector.Container Container, string ConnectionId)
    {
      Task<bool> ConectionUpdateTaskResults = Task<bool>.Factory.StartNew(() =>
      {
        try
        {
          using (AsyncScopedLifestyle.BeginScope(Container))          
          {
            IServiceFhirTaskWorkerManager IServiceFhirTaskWorkerManager = Container.GetInstance<IServiceFhirTaskWorkerManager>();
            IServiceFhirTaskWorkerManager.WorkerConnected(ConnectionId);
            return true;
          }
        }
        catch (Exception Exec)
        {
          Pyro.Common.Logging.Logger.Log.Error(Exec, "BackburnerConectionConnectedUpdateDatabase failed.");
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
using System;
using System.Web.Http;
using System.Threading.Tasks;
using Pyro.Common.Interfaces.Service;
using System.Web.Http.Dependencies;
using SimpleInjector.Lifestyles;

namespace Pyro.WebApi.App_Start
{
  public static class BackburnerConectionIdUpdate
  {
    public static bool RunTask(IDependencyResolver DependencyResolver, string ConnectionId, bool IsConnected)
    {
      Task<bool> BackburnerConectionIdUpdateTaskResults = Task<bool>.Factory.StartNew(() =>
      {
        try
        {
          using (DependencyResolver.BeginScope())
          {            
            IServiceBackburnerConnection IServiceBackburnerConnection = (IServiceBackburnerConnection)DependencyResolver.GetService(typeof(IServiceBackburnerConnection));
            if (IsConnected)
            {
              IServiceBackburnerConnection.AddConnectionAsConnected(ConnectionId);
            }
            else
            {
              IServiceBackburnerConnection.UpdateAsDisconnected(ConnectionId);
            }
            return true;
          }
        }
        catch (Exception Exec)
        {
          Pyro.Common.Logging.Logger.Log.Error(Exec, "BackburnerConectionIdUpdate failed.");
          throw Exec;
        }
        //End of Task Thread.
      });

      try
      {
        //Here we are catching any exceptions that occurred inside the Task thread above.
        BackburnerConectionIdUpdateTaskResults.Wait();
        return BackburnerConectionIdUpdateTaskResults.Result;        
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
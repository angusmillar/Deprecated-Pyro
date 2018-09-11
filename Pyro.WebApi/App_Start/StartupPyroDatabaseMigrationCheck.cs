using System;
using System.Web.Http;
using Pyro.Common.Interfaces.Repositories;

namespace Pyro.WebApi.App_Start
{
  public static class StartupPyroDatabaseMigrationCheck
  {
    public static bool RunTask(HttpConfiguration HttpConfiguration)
    {
      System.Threading.Tasks.Task<bool> MigrationCheckTaskResults = System.Threading.Tasks.Task<bool>.Factory.StartNew(() =>
      {
        try
        {
          using (HttpConfiguration.DependencyResolver.BeginScope())
          {
            IMigrationHistoryRepository IMigrationHistoryRepository = (IMigrationHistoryRepository)HttpConfiguration.DependencyResolver.GetService(typeof(IMigrationHistoryRepository));
            return IMigrationHistoryRepository.CheckMigrationsPerformed();           
          }
        }
        catch (Exception Exec)
        {
          Pyro.Common.Logging.Logger.Log.Error(Exec, "StartupPyroDatabaseMigrationCheck failed.");
          throw Exec;
        }
        //End of Task Thread.
      });

      try
      {
        //Here we are catching any exceptions that occurred inside the Task thread above.
        MigrationCheckTaskResults.Wait();
        return MigrationCheckTaskResults.Result;        
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
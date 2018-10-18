using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Pyro.WebApi.App_Start
{
  public static class StartupPyroResourceSeeding
  {
    public static void RunTask(HttpConfiguration HttpConfiguration)
    {
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
        string ExecMessage = "Internal Server Error: Unable to seed resources or check seeded resources on startup. This is likely to be due to the FHIR server database connection being unavailable.";
        Pyro.Common.Logging.Logger.Log.Fatal(Exec, ExecMessage);
        throw new Exception(ExecMessage, Exec);
      }
    }
  }
}
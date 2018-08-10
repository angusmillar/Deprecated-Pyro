using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Pyro.WebApi.App_Start
{
  public static class StartupPyroConfirgrationSynch
  {
    public static void RunTask(HttpConfiguration HttpConfiguration)
    {      
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
                  Pyro.Common.Logging.Logger.Log.Info("GlobalProperties from web.config file were updated in the database table ServiceConfiguration.");
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
          Pyro.Common.Logging.Logger.Log.Error(Exec, "Synchronize Service Configration With GlobalProperties failed.");
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
    }
  }
}
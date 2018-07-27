using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Pyro.WebApi.App_Start
{
  public static class StarupPyroTaskRunner
  {
    public static void RunTask(HttpConfiguration HttpConfiguration)
    {
      System.Threading.Tasks.Task<bool> TaskRunnerTask = System.Threading.Tasks.Task<bool>.Factory.StartNew(() =>
      {
        using (HttpConfiguration.DependencyResolver.BeginScope())
        {          
          Pyro.Engine.Services.FhirTasks.ITaskRunner ITaskRunner = (Pyro.Engine.Services.FhirTasks.ITaskRunner)HttpConfiguration.DependencyResolver.GetService(typeof(Pyro.Engine.Services.FhirTasks.ITaskRunner));          
          try
          {
            //Only run Task of type ServerStartupTask
            var IdentifierTypesToRun = new List<Common.PyroHealthInformation.CodeSystems.PyroFhirServer.Codes>()
            {
               Common.PyroHealthInformation.CodeSystems.PyroFhirServer.Codes.ServerStartupTask
            };                         
            ITaskRunner.Run(IdentifierTypesToRun);
            return true;
          }
          catch (Exception Exec)
          {
            Pyro.Common.Logging.Logger.Log.Error(Exec, $"StarupPyroTaskRunner thrown Exception on Pyro server startup.");
            throw Exec;
          }
        }
        //End of Task Thread.
      });

      try
      {
        // This code and specifically the line 'SeedTaskResults.Wait()' and 'Result = SeedTaskResults.Result' are commented out
        // so that this task does not stop the FHIR server from being operational while waiting for this task
        //This task is to run in the background untill completd. The task recoveres and picks up from where it finished.
        //You can do a GET: [base]/Task/Load-Fhir-Specification-Definitions to monitor it's progress. It can take upto an hour 
        //to complete. It primary use is to load all the FHIR specification resources into the server.

        //Here we are catching any exceptions that occured inside the Task thread above.
        //SeedTaskResults.Wait();
        // Result = SeedTaskResults.Result;
      }
      catch (Exception Exec)
      {
        string ExecMessage = "Internal Server Error: Problem in runnnig the Server statup Task runner.";
        Pyro.Common.Logging.Logger.Log.Fatal(Exec, ExecMessage);
        throw new Exception(ExecMessage, Exec);
      }
    }
  }
}
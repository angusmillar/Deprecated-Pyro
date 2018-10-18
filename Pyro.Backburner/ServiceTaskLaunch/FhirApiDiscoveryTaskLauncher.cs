using System.Threading.Tasks;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using Pyro.Common.BackgroundTask.TaskService.FhirApiDiscovery;
using Pyro.Common.Tools;
using System;

namespace Pyro.Backburner.ServiceTaskLaunch
{
  public class FhirApiDiscoveryTaskLauncher : BaseTaskLauncher
  {
    private readonly Container Container;

    /// <summary>
    /// The name of the task used to display on console, when run as a console application
    /// </summary>
    public string TaskName { get { return "Fhir Api Discovery Service"; } }

    /// <summary>
    /// Container must be passed in inorder to beable to create a new 
    /// Container instance per Thread/Task    
    /// </summary>
    /// <param name="Container"></param>
    public FhirApiDiscoveryTaskLauncher(Container Container)
    {
      this.Container = Container;
    }

    /// <summary>
    /// Launches the service as a Task on it's own thread
    /// Creates new Dependancy Injection instance for each thread/Task
    /// </summary>
    /// <param name="TaskPayloadHiServiceIHISearch"></param>
    public string Launch()
    {
      
      ConsoleSupport.TimeStampWriteLine("Launched FhirApiDiscoveryTaskLauncher" );
      var TaskResults = Task.Factory.StartNew(() =>
      {        
        try
        {
          using (AsyncScopedLifestyle.BeginScope(Container))
          {           
            return this.Container.GetInstance<IFhirApiDiscoveryService>().Run();
          }
        }
        catch (Exception Exec)
        {
          Pyro.Common.Logging.Logger.Log.Error(Exec, "FhirApiDiscoveryTaskLauncher threw uncaught exception in Task/Thread.");
        }
        return "FailedReturn";
      });
      
      return TaskResults.Result;
    }
  }

}

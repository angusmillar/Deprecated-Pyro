using System.Threading.Tasks;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using Pyro.Common.BackgroundTask.TaskPayload;
using Pyro.Common.BackgroundTask.TaskService.HiService;
using Pyro.Common.Tools;
using System;

namespace Pyro.Backburner.ServiceTaskLaunch
{
  public class IhiSearchServiceTaskLauncher
  {
    private readonly Container Container;

    /// <summary>
    /// The name of the task used to display on console, when run as a console application
    /// </summary>
    public string TaskName { get { return "IHI Search Service"; } }

    /// <summary>
    /// Container must be passed in inorder to beable to create a new 
    /// Container instance per Thread/Task    
    /// </summary>
    /// <param name="Container"></param>
    public IhiSearchServiceTaskLauncher(Container Container)
    {
      this.Container = Container;
    }

    /// <summary>
    /// Launches the service as a Task on it's own thread
    /// Creates new Dependancy Injection instance for each thread/Task
    /// </summary>
    /// <param name="TaskPayloadHiServiceIHISearch"></param>
    public void Launch(ITaskPayloadHiServiceIHISearch TaskPayloadHiServiceIHISearch)
    {
      ConsoleSupport.TimeStampWriteLine(BackgroundTaskLogMessageSupport.TaskReceived(TaskPayloadHiServiceIHISearch));
      Task.Factory.StartNew(() =>
      {
        try
        {
          using (AsyncScopedLifestyle.BeginScope(Container))
          {
            this.Container.GetInstance<IIhiSearchService>().Run(TaskPayloadHiServiceIHISearch);
          }
        }
        catch (Exception Exec)
        {
          Pyro.Common.Logging.Logger.Log.Error(Exec, "IhiSearchServiceTaskLauncher threw uncaught exception in Task/Thread.");
        }
      });    
    }
  }

}

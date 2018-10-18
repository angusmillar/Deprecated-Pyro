//using System.Threading.Tasks;
//using SimpleInjector;
//using SimpleInjector.Lifestyles;
//using Pyro.Common.BackgroundTask.TaskPayload;
//using Pyro.Common.BackgroundTask.TaskService.Indexer;
//using Pyro.Common.Tools;
//using System;

//namespace Pyro.Backburner.ServiceTaskLaunch
//{
//  public class IndexerServiceTaskLauncher : BaseTaskLauncher
//  {
//    private readonly Container Container;

//    /// <summary>
//    /// The name of the task used to display on console, when run as a console application
//    /// </summary>
//    public string TaskName { get { return "Search Parameter Indexer Service "; } }

//    /// <summary>
//    /// Container must be passed in in order to be able to create a new 
//    /// Container instance per Thread/Task    
//    /// </summary>
//    /// <param name="Container"></param>
//    public IndexerServiceTaskLauncher(Container Container)
//    {
//      this.Container = Container;
//    }

//    /// <summary>
//    /// Launches the service as a Task on it's own thread
//    /// Creates new Dependency Injection instance for each thread/Task
//    /// </summary>
//    /// <param name="TaskPayloadPyroServerIndexing"></param>
//    public void Launch(ITaskPayloadPyroServerIndexing TaskPayloadPyroServerIndexing, string ConnectionId)
//    {
//      ConsoleSupport.TimeStampWriteLine(BackgroundTaskLogMessageSupport.TaskReceived(TaskPayloadPyroServerIndexing));
//      Task.Factory.StartNew(() =>
//      {        
//        DelayLaunch();
//        try
//        {
//          using (AsyncScopedLifestyle.BeginScope(Container))
//          {
//            this.Container.GetInstance<IIndexerService>().Run(TaskPayloadPyroServerIndexing, ConnectionId);
//          }
//        }
//        catch (Exception Exec)
//        {
//          Pyro.Common.Logging.Logger.Log.Error(Exec, "IndexerServiceTaskLauncher  uncaught exception in Task/Thread.");
//        }
//      });    
//    }
//  }

//}

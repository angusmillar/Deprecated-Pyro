using Pyro.Common.BackgroundTask.TaskPayload;
using Pyro.Common.BackgroundTask.TaskService.Indexer;
using SimpleInjector.Lifestyles;
using System;
using System.Threading.Tasks;

namespace Pyro.Common.CompositionRoot.Concrete
{
  public class IndexerTaskFactory : IIndexerTaskFactory
  {
    private readonly SimpleInjector.Container Container;

    public IndexerTaskFactory(SimpleInjector.Container Container)
    {
      this.Container = Container;
    }

    public void Create(ITaskPayloadPyroServerIndexing TaskPayload, string ConnectionId)
    {
      Task.Factory.StartNew(() =>
      {
        int MaxNumber = 30000;
        Random Ran = new Random(Guid.NewGuid().GetHashCode());
        int DelayInt = Ran.Next(0, MaxNumber);
        Logging.Logger.Log.Info($"Indexer Task ConnectionId: {ConnectionId} Delay: {DelayInt.ToString()}");
        Task.Delay(DelayInt).Wait();
        Logging.Logger.Log.Info($"Indexer Task ConnectionId: {ConnectionId} Delay: {DelayInt.ToString()}");

        try
        {
          using (AsyncScopedLifestyle.BeginScope(Container))
          {
            this.Container.GetInstance<IIndexerService>().Run(TaskPayload, ConnectionId);
          }
        }
        catch (Exception Exec)
        {
          Logging.Logger.Log.Error(Exec, "IndexerTaskFactory uncaught exception in Task/Thread.");
        }
      });
    }


  }
}
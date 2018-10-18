using Pyro.Common.BackgroundTask.TaskPayload;

namespace Pyro.Common.BackgroundTask.TaskService.Indexer
{
  public interface IIndexerService
  {
    void Run(ITaskPayloadPyroServerIndexing TaskPayloadPyroServerIndexing, string ConnectionId);
  }
}
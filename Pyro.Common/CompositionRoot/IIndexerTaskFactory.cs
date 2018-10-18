using Pyro.Common.BackgroundTask.TaskPayload;

namespace Pyro.Common.CompositionRoot
{
  public interface IIndexerTaskFactory
  {
    void Create(ITaskPayloadPyroServerIndexing TaskPayload, string ConnectionId);
  }
}
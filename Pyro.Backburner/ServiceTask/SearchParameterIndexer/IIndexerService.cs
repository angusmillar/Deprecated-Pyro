using Pyro.Common.BackgroundTask.Task;

namespace Pyro.Backburner.ServiceTask.SearchParameterIndexer
{
  public interface IIndexerService
  {
    void Run(ITaskPayloadPyroServerIndexing TaskPayloadPyroServerIndexing);
  }
}
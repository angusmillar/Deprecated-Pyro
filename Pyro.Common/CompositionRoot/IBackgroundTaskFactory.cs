using Pyro.Common.BackgroundTask.TaskPayload;
using System.Threading;

namespace Pyro.Common.CompositionRoot
{
  public interface IBackgroundTaskFactory
  {
    void Create(IBackgroundTaskPayload TaskPayload, string ConnectionId, CancellationTokenSource CancellationToken);
  }
}
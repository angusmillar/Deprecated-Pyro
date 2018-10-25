using Pyro.Common.BackgroundTask.TaskPayload;
using System.Threading;

namespace Pyro.Common.BackgroundTask.TaskService
{
  public interface IBackgroundTaskService
  {
    void Run(IBackgroundTaskPayload BackgroundTaskPayload, string ConnectionId, CancellationTokenSource CancellationToken);
  }
}

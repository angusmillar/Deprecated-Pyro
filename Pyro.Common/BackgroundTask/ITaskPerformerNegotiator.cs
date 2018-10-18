using Pyro.Common.BackgroundTask.TaskPayload;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace Pyro.Common.BackgroundTask
{
  public interface ITaskPerformerNegotiator
  {
    bool SendToBackburner(IEnumerable<IBackgroundTaskPayloadBase> TaskPayloadList, IDependencyResolver DependencyResolver);
  }
}
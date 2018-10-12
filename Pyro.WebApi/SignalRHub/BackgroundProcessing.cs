using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pyro.Common.BackgroundTask;
using Pyro.Common.BackgroundTask.Task;

namespace Pyro.WebApi.SignalRHub
{
  public static class BackgroundProcessing
  {
    
    public static void SendTaskList(IEnumerable<IBackgroundTaskPayloadBase> TaskPayloadList)
    {
      if (TaskPayloadList != null && TaskPayloadList.Count() != 0)
      {
        Broadcaster Broadcaster = Pyro.WebApi.SignalRHub.Broadcaster.Instance;
        foreach (IBackgroundTaskPayloadBase TaskPayload in TaskPayloadList)
        {
          if (TaskPayload is  ITaskPayloadHiServiceIHISearch TaskPayloadHiServiceIHISearch)
          {                          
            Broadcaster.HiServiceResolveIHI(TaskPayloadHiServiceIHISearch);
          }
          if (TaskPayload is ITaskPayloadPyroServerIndexing TaskPayloadPyroServerIndexing)
          {
            Broadcaster.PyroServerIndexing(TaskPayloadPyroServerIndexing);
          }
        }
      }
    }
  }
}
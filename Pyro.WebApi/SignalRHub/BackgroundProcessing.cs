using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Pyro.Common.BackgroundTask;
using Pyro.Common.BackgroundTask.TaskPayload;

namespace Pyro.WebApi.SignalRHub
{
  public static class BackgroundProcessing
  {
    
    public static void SendTaskList(IEnumerable<IBackgroundTaskPayload> TaskPayloadList, ITaskPerformerNegotiator ITaskPerformerNegotiator, IDependencyResolver DependencyResolver)
    {
      if (TaskPayloadList != null && TaskPayloadList.Count() != 0)
      {
        //This checks if we have any Pyro.Backburner instances connected and if not it launches a separate thread in the FHIR server to perform the task
        //Yet, if there are Pyro.Backburner connected then it does nothing and returns True, which indicates this logic should broadcast to the Pyro.Backburner clients  
        if (ITaskPerformerNegotiator.SendToBackburner(TaskPayloadList, DependencyResolver))
        {
          Broadcaster Broadcaster = SignalRHub.Broadcaster.Instance;
          foreach (IBackgroundTaskPayload TaskPayload in TaskPayloadList)
          {
            Broadcaster.BackgroundTask(TaskPayload);            
          }
        }        
      }
    }
  }
}
using Pyro.Common.BackgroundTask.TaskPayload;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Enum;
using Pyro.Common.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;

namespace Pyro.Common.BackgroundTask
{
  public class TaskPerformerNegotiator : ITaskPerformerNegotiator
  {
    private readonly IServiceBackburnerConnection IServiceBackburnerConnection;
    private readonly IBackgroundTaskFactory IBackgroundTaskFactory;
    public TaskPerformerNegotiator(IServiceBackburnerConnection IServiceBackburnerConnection, IBackgroundTaskFactory IBackgroundTaskFactory)    
    {
      this.IServiceBackburnerConnection = IServiceBackburnerConnection;
      this.IBackgroundTaskFactory = IBackgroundTaskFactory;
    }

    public bool SendToBackburner(IEnumerable<IBackgroundTaskPayload> TaskPayloadList, IDependencyResolver DependencyResolver)
    {
      if (TaskPayloadList.Count() == 0)
      {
        // if the list is empty then nothing to do so don't send it anywhere, return false
        return false;
      }
        

      if (IServiceBackburnerConnection.ConnectedCount() > 0)
      {
        //If there are connected Pyro.Backburner instances then return True to inform caller to send the task to these remote
        //instances.
        return true;
      }
      else
      {
        //this CancellationToken need to somehow link into the IIS shut-down event as it will never cancel from here!! 
        var CancellationToken = new System.Threading.CancellationTokenSource();        
        // Temporary Unique for this Pyro.Backburner instance Connection ID for start - up task running 
        string StartUpConnectionId = $"{PyroHealthFhirResource.CodeSystems.PyroHealth.Codes.PyroFhirServer.GetPyroLiteral()}_{Tools.FhirGuid.FhirGuid.NewFhirGuid()}";
        //If the ConnectedCount == 0 then we must spawn a Task/thread and perform the Task on the Pyro Server, IBackgroundTaskFactory does this for us 
        foreach (IBackgroundTaskPayload TaskPayload in TaskPayloadList)
        {
          IBackgroundTaskFactory.Create(TaskPayload, StartUpConnectionId, CancellationToken);
        }
        return false;
      }
    }

    
  }
}

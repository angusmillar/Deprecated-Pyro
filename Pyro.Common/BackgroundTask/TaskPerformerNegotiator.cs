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
    private readonly IIndexerTaskFactory IIndexerTaskFactory;
    public TaskPerformerNegotiator(IServiceBackburnerConnection IServiceBackburnerConnection, IIndexerTaskFactory IIndexerTaskFactory)    
    {
      this.IServiceBackburnerConnection = IServiceBackburnerConnection;
      this.IIndexerTaskFactory = IIndexerTaskFactory;
    }

    public bool SendToBackburner(IEnumerable<IBackgroundTaskPayloadBase> TaskPayloadList, IDependencyResolver DependencyResolver)
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
        //If the ConnectedCount == 0 then we must spawn a Task/thread and perform the Task on the Pyro Server 
        foreach (IBackgroundTaskPayloadBase TaskPayload in TaskPayloadList)
        {
          if (TaskPayload is ITaskPayloadHiServiceIHISearch TaskPayloadHiServiceIHISearch)
          {
            //Broadcaster.HiServiceResolveIHI(TaskPayloadHiServiceIHISearch);            
          }
          else if (TaskPayload is ITaskPayloadPyroServerIndexing TaskPayloadPyroServerIndexing)
          {
            IIndexerTaskFactory.Create(TaskPayloadPyroServerIndexing, Common.PyroHealthFhirResource.CodeSystems.PyroHealth.Codes.PyroFhirServer.GetPyroLiteral());    
          }
          else
          {
            throw new System.ApplicationException($"Unhanded IBackgroundTaskPayloadBase instance of type: {TaskPayload.TaskType.GetPyroLiteral()}"); 
          }
        }
        return false;
      }
    }

    
  }
}

using Pyro.Common.BackgroundTask.TaskPayload;
using Pyro.Common.BackgroundTask.TaskService.HiService;
using Pyro.Common.BackgroundTask.TaskService.Indexer;
using Pyro.Common.Enum;
using Pyro.Common.Interfaces.Repositories;
using SimpleInjector.Lifestyles;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pyro.Common.CompositionRoot.Concrete
{
  public class BackgroundTaskFactory : IBackgroundTaskFactory
  {
    private readonly SimpleInjector.Container Container;

    public BackgroundTaskFactory(SimpleInjector.Container Container)
    {
      this.Container = Container;      
    }

    public void Create(IBackgroundTaskPayload TaskPayload, string ConnectionId, CancellationTokenSource CancellationToken)
    {      
      Task<bool> TaskInstance = Task<bool>.Factory.StartNew(() =>
      {
        //Random delay to prevent many background workers all trying to claim the task at the same time
        //Although there is also logic at the database SQL statement level that prevents two claiming it, this is only added protection and not really required 
        //We could never rely on this as the only mechanism as random will always clash over time
        DelayLaunch(20000, ConnectionId, TaskPayload.TaskType.GetPyroLiteral(), TaskPayload.TaskId); //20 sec

        try
        {
          using (AsyncScopedLifestyle.BeginScope(Container))
          {            
            IFhirTaskWorkerRepository IFhirTaskWorkerRepository = Container.GetInstance<IFhirTaskWorkerRepository>();
            if (IFhirTaskWorkerRepository.AttemptToClaim(TaskPayload.TaskType, ConnectionId))
            {
              Logging.Logger.Log.Info($"ConnectionId: {ConnectionId} has claimed the task worker of type: {TaskPayload.TaskType.GetPyroLiteral()}  based on the triggered task Id of : {TaskPayload.TaskId}");
              switch (TaskPayload.TaskType)
              {
                case BackgroundTaskEnum.BackgroundTaskType.HiServiceIHISearch:
                  Container.GetInstance<IIhiSearchService>().Run(TaskPayload, ConnectionId, CancellationToken);
                  break;
                case BackgroundTaskEnum.BackgroundTaskType.PyroServerIndexing:
                  Container.GetInstance<IIndexerService>().Run(TaskPayload, ConnectionId, CancellationToken);
                  break;
                default:
                  break;
              }              
            }
          }
          return true;
        }
        catch (OperationCanceledException CancelExec)
        {
          Logging.Logger.Log.Error(CancelExec, $"The background task of type {TaskPayload.TaskType.GetPyroLiteral()} triggered by the Task/{TaskPayload.TaskId} and performed by connection ID {ConnectionId} was cancelled by request.");
          return false;
          throw CancelExec;
        }
        catch (Exception Exec)
        {
          Logging.Logger.Log.Error(Exec, "BackgroundTaskFactory uncaught exception in Task/Thread.");
          return false;
        }
      }, CancellationToken.Token);

      //Below maybe useful one day

      //var displayResults = TaskInstance.ContinueWith(resultTask =>
      //  {
      //    if (resultTask.Result)
      //    {
      //      Console.WriteLine("Task Was true.");
      //    }
      //  },
      //  TaskContinuationOptions.OnlyOnRanToCompletion);

      //var displayCancelledTasks = TaskInstance.ContinueWith(resultTask =>
      //  {
      //    Console.WriteLine("ask CXancxeld");
      //  },
      //  TaskContinuationOptions.OnlyOnCanceled);

    }

    private void DelayLaunch(int MaxDelayMilliseconds, string ConnectionId, string TaskType, string TaskId)
    {      
      Random Ran = new Random(Guid.NewGuid().GetHashCode());
      int DelayInt = Ran.Next(0, MaxDelayMilliseconds);
      Logging.Logger.Log.Info($"Begin background task start delay amount :{DelayInt.ToString()} milliseconds for ConnectionId: {ConnectionId}, TaskType: {TaskType}, TaskId {TaskId}");
      Task.Delay(DelayInt).Wait();      
      Logging.Logger.Log.Info($"End background task start delay amount :{DelayInt.ToString()} milliseconds for ConnectionId: {ConnectionId}, TaskType: {TaskType}, TaskId {TaskId}");
    }

  }
}
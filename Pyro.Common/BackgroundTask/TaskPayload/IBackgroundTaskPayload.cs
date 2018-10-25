
using Pyro.Common.Enum;

namespace Pyro.Common.BackgroundTask.TaskPayload
{
  public interface IBackgroundTaskPayload
  {
    BackgroundTaskEnum.BackgroundTaskType TaskType { get; set; }
    string TaskId { get; set; }    
  }
}
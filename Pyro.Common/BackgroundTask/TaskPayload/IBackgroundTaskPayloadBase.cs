namespace Pyro.Common.BackgroundTask.TaskPayload
{
  public interface IBackgroundTaskPayloadBase
  {
    BackgroundTaskType TaskType { get; }
    string TaskId { get; set; }    
  }
}
namespace Pyro.Common.BackgroundTask
{
  public interface IBackgroundTaskPayloadBase
  {
    BackgroundTaskType TaskType { get; }
    string TaskId { get; }    
  }
}
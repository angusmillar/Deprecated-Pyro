namespace Pyro.Common.BackgroundTask.Task
{
  public interface ITaskPayloadHiServiceIHISearch : IBackgroundTaskPayloadBase
  {
    string PatientId { get; set; }    
    string TaskId { get; set; }
  }
}
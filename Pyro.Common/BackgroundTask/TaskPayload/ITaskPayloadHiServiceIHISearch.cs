namespace Pyro.Common.BackgroundTask.TaskPayload
{
  public interface ITaskPayloadHiServiceIHISearch : IBackgroundTaskPayloadBase
  {
    string PatientId { get; set; }        
  }
}
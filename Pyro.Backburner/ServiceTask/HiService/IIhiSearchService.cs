using Pyro.Common.BackgroundTask.Task;

namespace Pyro.Backburner.ServiceTask.HiService
{
  public interface IIhiSearchService
  {
    void DoSomthing(ITaskPayloadHiServiceIHISearch TaskPayloadHiServiceIHISearch);
  }
}
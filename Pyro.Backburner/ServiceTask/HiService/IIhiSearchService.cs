using Pyro.Common.BackgroundTask.Task;

namespace Pyro.Backburner.ServiceTask.HiService
{
  public interface IIhiSearchService
  {
    void Run(ITaskPayloadHiServiceIHISearch TaskPayloadHiServiceIHISearch);
  }
}
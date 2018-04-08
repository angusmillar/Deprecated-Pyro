using Pyro.Common.BackgroundTask.Task;

namespace Pyro.Backburner.ServiceTaskLaunch
{
  public interface IIhiSearchServiceTaskLauncher
  {
    void Doit(ITaskPayloadHiServiceIHISearch TaskPayloadHiServiceIHISearch);
  }
}
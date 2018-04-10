using System.Threading.Tasks;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using Pyro.Common.BackgroundTask.Task;
using Pyro.Backburner.ServiceTask.HiService;

namespace Pyro.Backburner.ServiceTaskLaunch
{
  public class IhiSearchServiceTaskLauncher
  {
    private readonly Container Container;

    public string TaskName { get { return "IHI Search Service"; } }

    public IhiSearchServiceTaskLauncher(Container Container)
    {
      this.Container = Container;
    }
    
    public void Launch(ITaskPayloadHiServiceIHISearch TaskPayloadHiServiceIHISearch)
    {
      Task.Factory.StartNew(() =>
      {
        using (AsyncScopedLifestyle.BeginScope(Container))
        {
          this.Container.GetInstance<IIhiSearchService>().Run(TaskPayloadHiServiceIHISearch);
        }
      });
    }
  }

}

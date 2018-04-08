using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Backburner.CompositionRoot;
using Pyro.Common.BackgroundTask.Task;

namespace Pyro.Backburner.ServiceTaskLaunch
{
  public class IhiSearchServiceTaskLauncher : IIhiSearchServiceTaskLauncher
  {
    private readonly IIhiSearchServiceFactory IHIServiceFactory;
    public IhiSearchServiceTaskLauncher(IIhiSearchServiceFactory IHIServiceFactory)
    {
      this.IHIServiceFactory = IHIServiceFactory;
    }

    public void Doit(ITaskPayloadHiServiceIHISearch TaskPayloadHiServiceIHISearch)
    {
      Task.Factory.StartNew(
        () => {
          this.IHIServiceFactory.CreateTestService().DoSomthing(TaskPayloadHiServiceIHISearch);          
        });
    }
  }
}

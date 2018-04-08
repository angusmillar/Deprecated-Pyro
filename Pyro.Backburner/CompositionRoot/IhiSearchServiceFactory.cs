using Pyro.Backburner.ServiceTask.HiService;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Backburner.CompositionRoot
{

  public class IhiSearchServiceFactory : IIhiSearchServiceFactory
  {
    private readonly SimpleInjector.Container Container;

    public IhiSearchServiceFactory(SimpleInjector.Container Container)
    {
      this.Container = Container;
    }

    public IIhiSearchService CreateTestService()
    {
      using (AsyncScopedLifestyle.BeginScope(Container))
      {
        return Container.GetInstance<IIhiSearchService>();
      }
    }
  }

}

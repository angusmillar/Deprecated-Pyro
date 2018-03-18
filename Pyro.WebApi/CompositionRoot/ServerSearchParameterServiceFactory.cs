using Pyro.Common.Search;
using Pyro.Common.CompositionRoot;
using Pyro.Common.RequestMetadata;
using Pyro.Common.Service;

namespace Pyro.WebApi.CompositionRoot
{
  public class ServerSearchParameterServiceFactory : IServerSearchParameterServiceFactory
  {
    private readonly SimpleInjector.Container Container;

    public ServerSearchParameterServiceFactory(SimpleInjector.Container Container)
    {
      this.Container = Container;
    }

    public IServerSearchParameterService CreateServerSearchParameterService()
    {
      return Container.GetInstance<IServerSearchParameterService>();
    }
  }
}
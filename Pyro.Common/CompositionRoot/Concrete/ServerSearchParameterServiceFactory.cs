using Pyro.Common.Search;
using Pyro.Common.CompositionRoot;
using Pyro.Common.RequestMetadata;
using Pyro.Common.Service.ResourceService;
using Pyro.Common.FhirOperation.ServerSearchParameter;

namespace Pyro.Common.CompositionRoot.Concrete
{
  public class ServerSearchParameterServiceFactory : IServerSearchParameterServiceFactory
  {
    private readonly SimpleInjector.Container Container;

    public ServerSearchParameterServiceFactory(SimpleInjector.Container Container)
    {
      this.Container = Container;
    }

    public IServerSearchParameterOperation CreateServerSearchParameterService()
    {
      return Container.GetInstance<IServerSearchParameterOperation>();
    }
  }
}
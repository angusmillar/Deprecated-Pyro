using Pyro.Common.CompositionRoot;
using Pyro.Common.ServiceRoot;
using Pyro.Common.Tools.UriSupport;

namespace Pyro.Common.CompositionRoot.Concrete
{
  public class DtoRootUrlStoreFactory : IDtoRootUrlStoreFactory
  {
    private readonly SimpleInjector.Container Container;

    public DtoRootUrlStoreFactory(SimpleInjector.Container Container)
    {
      this.Container = Container;
    }

    public IDtoRootUrlStore CreateDtoRootUrlStore()
    {
      return Container.GetInstance<IDtoRootUrlStore>();
    }
  }
}
using Pyro.Common.CompositionRoot;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Tools.UriSupport;

namespace Pyro.Backburner.CompositionRoot2
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
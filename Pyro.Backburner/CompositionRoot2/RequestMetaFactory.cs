using Pyro.Common.Search;
using Pyro.Common.CompositionRoot;
using Pyro.Common.RequestMetadata;

namespace Pyro.Backburner.CompositionRoot2
{
  public class RequestMetaFactory : IRequestMetaFactory
  {
    private readonly SimpleInjector.Container Container;

    public RequestMetaFactory(SimpleInjector.Container Container)
    {
      this.Container = Container;
    }

    public IRequestMeta CreateRequestMeta()
    {
      return Container.GetInstance<IRequestMeta>();
    }
  }
}
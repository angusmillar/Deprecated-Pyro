using Pyro.Common.Service;
using Pyro.Common.CompositionRoot;

namespace Pyro.Backburner.CompositionRoot2
{
  public class SearchParameterServiceFactory : ISearchParameterServiceFactory
  {
    private readonly SimpleInjector.Container Container;

    public SearchParameterServiceFactory(SimpleInjector.Container Container)
    {
      this.Container = Container;
    }

    public ISearchParameterService CreateSearchParameterService()
    {
      return Container.GetInstance<ISearchParameterService>();
    }
  }
}
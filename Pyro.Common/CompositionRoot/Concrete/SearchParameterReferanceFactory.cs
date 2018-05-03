using Pyro.Common.Search;
using Pyro.Common.CompositionRoot;

namespace Pyro.Common.CompositionRoot.Concrete
{
  public class SearchParameterReferanceFactory : ISearchParameterReferanceFactory
  {
    private readonly SimpleInjector.Container Container;

    public SearchParameterReferanceFactory(SimpleInjector.Container Container)
    {
      this.Container = Container;
    }

    public ISearchParameterReferance CreateDtoSearchParameterReferance()
    {
      return Container.GetInstance<ISearchParameterReferance>();
    }

  }
}
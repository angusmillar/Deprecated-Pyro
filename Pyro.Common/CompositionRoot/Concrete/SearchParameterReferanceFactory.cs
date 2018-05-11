using Pyro.Common.CompositionRoot;
using Pyro.Common.Search.SearchParameterEntity;

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
using Pyro.Common.CompositionRoot;
using Pyro.Common.Search;

namespace Pyro.Common.CompositionRoot.Concrete
{
  public class SearchParameterGenericFactory : ISearchParameterGenericFactory
  {
    private readonly SimpleInjector.Container Container;

    public SearchParameterGenericFactory(SimpleInjector.Container Container)
    {
      this.Container = Container;
    }

    public ISearchParameterGeneric CreateDtoSearchParameterGeneric()
    {
      return Container.GetInstance<ISearchParameterGeneric>();
    }

  }
}
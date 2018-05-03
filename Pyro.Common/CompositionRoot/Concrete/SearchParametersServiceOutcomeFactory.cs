using Pyro.Common.CompositionRoot;
using Pyro.Common.Service;

namespace Pyro.Common.CompositionRoot.Concrete
{
  public class SearchParametersServiceOutcomeFactory : ISearchParametersServiceOutcomeFactory
  {
    private readonly SimpleInjector.Container Container;

    public SearchParametersServiceOutcomeFactory(SimpleInjector.Container Container)
    {
      this.Container = Container;
    }

    public ISearchParametersServiceOutcome CreateSearchParametersServiceOutcome()
    {
      return Container.GetInstance<ISearchParametersServiceOutcome>();
    }

  }
}
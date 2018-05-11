using Pyro.Common.Service.SearchParameters;

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
using Pyro.Common.CompositionRoot;
using Pyro.Common.Service;

namespace Pyro.Web.CompositionRoot
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
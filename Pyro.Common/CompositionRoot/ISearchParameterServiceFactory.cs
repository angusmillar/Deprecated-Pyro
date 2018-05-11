using Pyro.Common.Service.SearchParameters;

namespace Pyro.Common.CompositionRoot
{
  public interface ISearchParameterServiceFactory
  {
    ISearchParameterService CreateSearchParameterService();
  }
}
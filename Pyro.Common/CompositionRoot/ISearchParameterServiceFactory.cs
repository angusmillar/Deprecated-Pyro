using Pyro.Common.Service;

namespace Pyro.Common.CompositionRoot
{
  public interface ISearchParameterServiceFactory
  {
    ISearchParameterService CreateSearchParameterService();
  }
}
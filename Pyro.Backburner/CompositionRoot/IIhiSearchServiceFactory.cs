using Pyro.Backburner.ServiceTask.HiService;

namespace Pyro.Backburner.CompositionRoot
{
  public interface IIhiSearchServiceFactory
  {
    IIhiSearchService CreateTestService();
  }
}
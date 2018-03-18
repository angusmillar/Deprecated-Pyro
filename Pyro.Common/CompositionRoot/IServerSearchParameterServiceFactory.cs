using Pyro.Common.Service;

namespace Pyro.Common.CompositionRoot
{
  public interface IServerSearchParameterServiceFactory
  {
    IServerSearchParameterService CreateServerSearchParameterService();
  }
}
using Pyro.Common.Service.ResourceService;
using Pyro.Common.FhirOperation.ServerSearchParameter;

namespace Pyro.Common.CompositionRoot
{
  public interface IServerSearchParameterServiceFactory
  {
    IServerSearchParameterOperation CreateServerSearchParameterService();
  }
}
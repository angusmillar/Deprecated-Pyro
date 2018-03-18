using Pyro.Common.Interfaces.Service;

namespace Pyro.Common.CompositionRoot
{
  public interface IFhirBaseOperationServiceFactory
  {
    IFhirBaseOperationService CreateFhirBaseOperationService();
  }
}
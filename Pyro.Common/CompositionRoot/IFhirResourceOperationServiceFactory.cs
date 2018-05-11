using Pyro.Common.Interfaces.Operation;

namespace Pyro.Common.CompositionRoot
{
  public interface IFhirResourceOperationServiceFactory
  {
    IFhirResourceOperationService CreateFhirResourceOperationService();
  }
}
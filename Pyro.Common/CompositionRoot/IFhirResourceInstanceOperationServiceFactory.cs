using Pyro.Common.Interfaces.Operation;

namespace Pyro.Common.CompositionRoot
{
  public interface IFhirResourceInstanceOperationServiceFactory
  {
    IFhirResourceInstanceOperationService CreateFhirResourceInstanceOperationService();
  }
}
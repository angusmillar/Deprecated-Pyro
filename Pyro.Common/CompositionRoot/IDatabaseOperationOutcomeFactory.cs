using Pyro.Common.Interfaces.Service;

namespace Pyro.Common.CompositionRoot
{
  public interface IDatabaseOperationOutcomeFactory
  {
    IDatabaseOperationOutcome CreateDatabaseOperationOutcome();
  }
}
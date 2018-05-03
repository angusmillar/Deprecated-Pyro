using Pyro.Common.CompositionRoot;
using Pyro.Common.Interfaces.Service;

namespace Pyro.Common.CompositionRoot.Concrete
{
  public class DatabaseOperationOutcomeFactory : IDatabaseOperationOutcomeFactory
  {
    private readonly SimpleInjector.Container Container;

    public DatabaseOperationOutcomeFactory(SimpleInjector.Container Container)
    {
      this.Container = Container;
    }

    public IDatabaseOperationOutcome CreateDatabaseOperationOutcome()
    {
      return Container.GetInstance<IDatabaseOperationOutcome>();
    }
  }
}
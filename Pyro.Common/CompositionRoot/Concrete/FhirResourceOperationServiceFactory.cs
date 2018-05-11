using Pyro.Common.CompositionRoot;
using Pyro.Common.Interfaces.Operation;

namespace Pyro.Common.CompositionRoot.Concrete
{ 
  public class FhirResourceOperationServiceFactory : IFhirResourceOperationServiceFactory
  {
    private readonly SimpleInjector.Container Container;

    public FhirResourceOperationServiceFactory(SimpleInjector.Container Container)
    {
      this.Container = Container;
    }

    public IFhirResourceOperationService CreateFhirResourceOperationService()
    {
      return Container.GetInstance<IFhirResourceOperationService>();
    }
  }
}
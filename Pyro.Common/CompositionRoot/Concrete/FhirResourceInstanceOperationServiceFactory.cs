using Pyro.Common.Search;
using Pyro.Common.CompositionRoot;
using Pyro.Common.RequestMetadata;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.Operation;

namespace Pyro.Common.CompositionRoot.Concrete
{ 

  public class FhirResourceInstanceOperationServiceFactory : IFhirResourceInstanceOperationServiceFactory
  {
    private readonly SimpleInjector.Container Container;

    public FhirResourceInstanceOperationServiceFactory(SimpleInjector.Container Container)
    {
      this.Container = Container;
    }

    public IFhirResourceInstanceOperationService CreateFhirResourceInstanceOperationService()
    {
      return Container.GetInstance<IFhirResourceInstanceOperationService>();
    }
  }
}
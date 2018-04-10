using Pyro.Common.Search;
using Pyro.Common.CompositionRoot;
using Pyro.Common.RequestMetadata;
using Pyro.Common.Interfaces.Service;

namespace Pyro.Backburner.CompositionRoot2
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
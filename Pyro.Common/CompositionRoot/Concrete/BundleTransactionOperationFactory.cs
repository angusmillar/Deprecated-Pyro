using Pyro.Common.FhirOperation.BundleTransaction;

namespace Pyro.Common.CompositionRoot.Concrete
{
  public class BundleTransactionOperationFactory : IBundleTransactionOperationFactory
  {
    private readonly SimpleInjector.Container Container;

    public BundleTransactionOperationFactory(SimpleInjector.Container Container)
    {
      this.Container = Container;
    }

    public IBundleTransactionOperation CreateBundleTransactionOperation()
    {
      return Container.GetInstance<IBundleTransactionOperation>();
    }
  }
}
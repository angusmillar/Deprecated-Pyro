using Pyro.Common.Search;
using Pyro.Common.CompositionRoot;
using Pyro.Common.RequestMetadata;
using Pyro.Common.Interfaces.Service;

namespace Pyro.Backburner.CompositionRoot2
{
  public class BundleTransactionServiceFactory : IBundleTransactionServiceFactory
  {
    private readonly SimpleInjector.Container Container;

    public BundleTransactionServiceFactory(SimpleInjector.Container Container)
    {
      this.Container = Container;
    }

    public IBundleTransactionService CreateBundleTransactionService()
    {
      return Container.GetInstance<IBundleTransactionService>();
    }
  }
}
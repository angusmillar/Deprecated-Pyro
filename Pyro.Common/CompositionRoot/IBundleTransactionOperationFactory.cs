using Pyro.Common.Interfaces.Service;
using Pyro.Common.FhirOperation.BundleTransaction;

namespace Pyro.Common.CompositionRoot
{
  public interface IBundleTransactionOperationFactory
  {
    IBundleTransactionOperation CreateBundleTransactionOperation();
  }
}
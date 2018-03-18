using Pyro.Common.Interfaces.Service;

namespace Pyro.Common.CompositionRoot
{
  public interface IBundleTransactionServiceFactory
  {
    IBundleTransactionService CreateBundleTransactionService();
  }
}
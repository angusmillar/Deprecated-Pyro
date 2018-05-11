using Pyro.Common.ServiceRoot;

namespace Pyro.Common.CompositionRoot
{
  public interface IDtoRootUrlStoreFactory
  {
    IDtoRootUrlStore CreateDtoRootUrlStore();
  }
}
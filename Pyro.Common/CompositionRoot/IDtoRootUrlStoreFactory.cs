using Pyro.Common.Interfaces.Dto;

namespace Pyro.Common.CompositionRoot
{
  public interface IDtoRootUrlStoreFactory
  {
    IDtoRootUrlStore CreateDtoRootUrlStore();
  }
}
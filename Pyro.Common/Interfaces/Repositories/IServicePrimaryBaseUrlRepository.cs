using Pyro.Common.Interfaces.Dto;

namespace Pyro.Common.Interfaces.Repositories
{
  public interface IServicePrimaryBaseUrlRepository
  {    
    IDtoRootUrlStore GetPrimaryRootUrlStore();
    IDtoRootUrlStore SetPrimaryRootUrlStore(string RootUrl);
  }
}
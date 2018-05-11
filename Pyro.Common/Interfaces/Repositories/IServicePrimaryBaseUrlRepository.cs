using Pyro.Common.ServiceRoot;

namespace Pyro.Common.Interfaces.Repositories
{
  public interface IServicePrimaryBaseUrlRepository
  {    
    IDtoRootUrlStore GetPrimaryRootUrlStore();
    IDtoRootUrlStore SetPrimaryRootUrlStore(string RootUrl);
  }
}
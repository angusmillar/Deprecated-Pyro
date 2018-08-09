using Pyro.Common.Interfaces.Service;

namespace Pyro.Common.ServiceRoot
{
  public interface IPrimaryServiceRootCache
  {
    IDtoRootUrlStore GetPrimaryRootUrlStoreFromDatabase();
    string GetPrimaryRootUrlFromWebConfig();
    void ClearPrimaryRootUrlFromCache();
    void ClearPrimaryRootUrlStoreFromCache();
  }
}
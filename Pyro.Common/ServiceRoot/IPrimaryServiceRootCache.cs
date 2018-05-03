using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Service;

namespace Pyro.Common.ServiceRoot
{
  public interface IPrimaryServiceRootCache
  {
    IDtoRootUrlStore GetPrimaryRootUrlFromDatabase();
    string GetPrimaryRootUrlFromWebConfig();
    void ClearPrimaryRootUrlFromCache();
  }
}
using Blaze.Common.Interfaces.Dto;

namespace Blaze.Common.Interfaces.Repositories
{
  public interface IDtoCommonRepository
  {
    IDtoRootUrlStore GetPrimaryRootUrlStore();
    IDtoRootUrlStore SetPrimaryRootUrlStore(string RootUrl);    
  }
}

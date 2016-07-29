using Blaze.Common.BusinessEntities.Dto;

namespace Blaze.Common.Interfaces.Repositories
{
  public interface IDtoCommonRepository
  {    
    DtoRootUrlStore GetPrimaryRootUrlStore();
    DtoRootUrlStore SetPrimaryRootUrlStore(string RootUrl);    
  }
}

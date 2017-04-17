using System.Collections.Generic;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.BusinessEntities.Dto;

namespace Pyro.Common.Interfaces.Repositories
{
  public interface IDtoCommonRepository
  {
    IDtoRootUrlStore GetPrimaryRootUrlStore();
    IDtoRootUrlStore SetPrimaryRootUrlStore(string RootUrl);
    IList<DtoServiceSearchParameterLight> GetServiceSearchParametersForResource(string ResourceType);
  }
}

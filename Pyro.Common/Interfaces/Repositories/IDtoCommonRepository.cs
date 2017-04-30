using System.Collections.Generic;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.BusinessEntities.Dto;

namespace Pyro.Common.Interfaces.Repositories
{
  public interface IDtoCommonRepository
  {
    IDtoRootUrlStore GetPrimaryRootUrlStore();
    IDtoRootUrlStore SetPrimaryRootUrlStore(string RootUrl);

    IList<DtoServiceSearchParameterLight> GetServiceSearchParametersLightForResource(string ResourceType);
    IList<DtoServiceSearchParameterHeavy> GetServiceSearchParametersHeavy();
    IList<DtoServiceSearchParameterHeavy> GetServiceSearchParametersHeavyForResource(string ResourceType);

  }
}

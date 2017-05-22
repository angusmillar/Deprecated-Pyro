using System.Collections.Generic;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.BusinessEntities.Dto;

namespace Pyro.Common.Interfaces.Repositories
{
  public interface IDtoCommonRepository
  {
    IDtoRootUrlStore GetPrimaryRootUrlStore();
    IDtoRootUrlStore SetPrimaryRootUrlStore(string RootUrl);

    List<DtoServiceSearchParameterLight> GetServiceSearchParametersLightForResource(string ResourceType);
    List<DtoServiceSearchParameterHeavy> GetServiceSearchParametersHeavy(bool CustomOnly = false);
    List<DtoServiceSearchParameterHeavy> GetServiceSearchParametersHeavyForResource(string ResourceType);
    void AddServiceSearchParametersHeavy(DtoServiceSearchParameterHeavy ServiceSearchParameterHeavy);



  }
}

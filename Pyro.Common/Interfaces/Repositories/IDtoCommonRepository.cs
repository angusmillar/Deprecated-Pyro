using System.Collections.Generic;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Search;

namespace Pyro.Common.Interfaces.Repositories
{
  public interface IDtoCommonRepository
  {
    IDtoRootUrlStore GetPrimaryRootUrlStore();
    IDtoRootUrlStore SetPrimaryRootUrlStore(string RootUrl);

    //List<ServiceSearchParameterLight> GetServiceSearchParametersLightForResource(string ResourceType);
    //List<ServiceSearchParameterHeavy> GetServiceSearchParametersHeavy(bool CustomOnly = false);
    //List<ServiceSearchParameterHeavy> GetServiceSearchParametersHeavyForResource(string ResourceType);
    //ServiceSearchParameterHeavy AddServiceSearchParametersHeavy(ServiceSearchParameterHeavy ServiceSearchParameterHeavy);
    //ServiceSearchParameterHeavy UpdateServiceSearchParametersHeavy(ServiceSearchParameterHeavy ServiceSearchParameterHeavy);
    //void DeleteServiceSearchParameters(int Id);

  }
}

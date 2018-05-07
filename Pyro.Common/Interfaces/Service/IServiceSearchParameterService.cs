using System.Collections.Generic;
using Pyro.Common.Search;

namespace Pyro.Common.Interfaces.Service
{
  public interface IServiceSearchParameterService
  {
    DtoServiceSearchParameterHeavy AddServiceSearchParametersHeavy(DtoServiceSearchParameterHeavy ServiceSearchParameterHeavy);
    void DeleteServiceSearchParameters(int Id);
    List<DtoServiceSearchParameterLight> GetServiceSearchParametersForResource(string ResourceType);
    List<DtoServiceSearchParameterHeavy> GetServiceSearchParametersHeavy(bool CustomOnly = false);
    List<DtoServiceSearchParameterHeavy> GetServiceSearchParametersHeavyForResource(string ResourceType);
    DtoServiceSearchParameterHeavy UpdateServiceSearchParametersHeavy(DtoServiceSearchParameterHeavy ServiceSearchParameterHeavy);
  }
}
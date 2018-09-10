using System.Collections.Generic;
using Pyro.Common.Search;

namespace Pyro.Common.Interfaces.Service
{
  public interface IServiceSearchParameterService
  {
    DtoServiceSearchParameterHeavy AddServiceSearchParametersHeavy(DtoServiceSearchParameterHeavy ServiceSearchParameterHeavy);
    void DeleteServiceSearchParameters(int Id);
    List<DtoServiceSearchParameterLight> GetServiceSearchParametersForResource(string ResourceType);
    List<DtoServiceSearchParameterHeavy> GetServiceSearchParametersHeavyByIsIndexed(bool IsIndexed);
    List<DtoServiceSearchParameterHeavy> GetServiceSearchParametersHeavyForResource(string ResourceType);
    DtoServiceSearchParameterHeavy UpdateServiceSearchParametersHeavy(DtoServiceSearchParameterHeavy ServiceSearchParameterHeavy);
  }
}
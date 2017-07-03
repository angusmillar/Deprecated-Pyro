using System.Collections.Generic;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Common.Interfaces.Repositories;

namespace Pyro.Common.ServiceSearchParameter
{
  public interface IServiceSearchParameterCache
  {
    List<DtoServiceSearchParameterLight> GetSearchParameterForResource(IDtoCommonRepository ICommonRepository, string ResourceType);
    List<DtoServiceSearchParameterLight> GetSearchParameterForResource(string ResourceType);
  }
}
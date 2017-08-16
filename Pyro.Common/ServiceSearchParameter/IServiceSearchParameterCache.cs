using System.Collections.Generic;
using Pyro.Common.Search;
using Pyro.Common.Interfaces.Repositories;

namespace Pyro.Common.ServiceSearchParameter
{
  public interface IServiceSearchParameterCache
  {
    List<ServiceSearchParameterLight> GetSearchParameterForResource(string ResourceType);
  }
}
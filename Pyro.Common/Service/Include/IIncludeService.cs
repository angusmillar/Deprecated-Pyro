using Pyro.Common.DtoEntity;
using Pyro.Common.Search;
using System.Collections.Generic;

namespace Pyro.Common.Service.Include
{
  public interface IIncludeService
  {
    List<DtoResource> ResolveIncludeResourceList(List<SearchParameterInclude> IncludeList, List<DtoResource> SourceInputResourceList, string Compartment = "", string CompartmentId = "");
  }
}
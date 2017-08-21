using System.Collections.Generic;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Common.Search;

namespace Pyro.Common.Service
{
  public interface IIncludeService
  {
    List<DtoResource> ResolveIncludeResourceList(List<SearchParameterInclude> IncludeList, List<DtoResource> SearchResourceList, bool Recursive = false);
  }
}
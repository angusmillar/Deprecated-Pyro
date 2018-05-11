using Pyro.Common.Search;
using Pyro.Common.Search.SearchParameterEntity;

namespace Pyro.Common.Service.ChainSearching
{
  public interface IChainSearchingService
  {
    bool ResolveChain(ISearchParameterReferance SearchParameterReferance);
  }
}
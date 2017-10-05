using Pyro.Common.Search;

namespace Pyro.Common.Service
{
  public interface IChainSearchingService
  {
    void ResolveChain(ISearchParameterReferance SearchParameterReferance);
  }
}
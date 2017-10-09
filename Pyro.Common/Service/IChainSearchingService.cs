using Pyro.Common.Search;

namespace Pyro.Common.Service
{
  public interface IChainSearchingService
  {
    bool ResolveChain(ISearchParameterReferance SearchParameterReferance);
  }
}
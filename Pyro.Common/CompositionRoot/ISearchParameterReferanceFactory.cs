using Pyro.Common.Search;

namespace Pyro.Common.CompositionRoot
{
  public interface ISearchParameterReferanceFactory
  {
    ISearchParameterReferance CreateDtoSearchParameterReferance();
  }
}
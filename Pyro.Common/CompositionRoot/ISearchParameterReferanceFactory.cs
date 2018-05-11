using Pyro.Common.Search.SearchParameterEntity;

namespace Pyro.Common.CompositionRoot
{
  public interface ISearchParameterReferanceFactory
  {
    ISearchParameterReferance CreateDtoSearchParameterReferance();
  }
}
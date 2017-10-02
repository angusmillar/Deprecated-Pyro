using Pyro.Common.Search;

namespace Pyro.Common.CompositionRoot
{
  public interface ISearchParameterGenericFactory
  {
    ISearchParameterGeneric CreateDtoSearchParameterGeneric();
  }
}
using Pyro.Common.SearchIndexer;
using Pyro.Common.SearchIndexer.Setter;

namespace Pyro.Common.CompositionRoot
{
  public interface IIndexSetterFactory
  {
    //IDateTimeSetter CreateDateTimeSetter();
    INumberSetter CreateNumberSetter();
    //IQuantitySetter CreateQuantitySetter();
    IReferenceSetter CreateReferenceSetter();
    //IStringSetter CreateStringSetter();
    //ITokenSetter CreateTokenSetter();
    //IUriSetter CreateUriSetter();
  }
}
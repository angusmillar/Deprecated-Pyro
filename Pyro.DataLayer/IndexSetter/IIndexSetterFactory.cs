using System;

namespace Pyro.DataLayer.IndexSetter
{
  public interface IIndexSetterFactory
  {
    INumberSetter CreateINumberSetter();
    IReferenceSetter CreateReferenceSetter();
    IDateTimeSetter CreateDateTimeSetter();
    IQuantitySetter CreateQuantitySetter();
    IStringSetter CreateStringSetter();
    ITokenSetter CreateTokenSetter();
    IUriSetter CreateUriSetter();
  }
}
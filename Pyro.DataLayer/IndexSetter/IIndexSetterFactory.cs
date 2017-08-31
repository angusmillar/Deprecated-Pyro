using System;
using Pyro.DataLayer.DbModel.EntityBase;

namespace Pyro.DataLayer.IndexSetter
{
  public interface IIndexSetterFactory<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
  {
    INumberSetter<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType> CreateNumberSetter();
    IReferenceSetter<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType> CreateReferenceSetter();
    IDateTimeSetter<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType> CreateDateTimeSetter();
    IQuantitySetter<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType> CreateQuantitySetter();
    IStringSetter<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType> CreateStringSetter();
    ITokenSetter<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType> CreateTokenSetter();
    IUriSetter<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType> CreateUriSetter();
  }
}
using System;
using Pyro.DataLayer.IndexSetter;
using Pyro.DataLayer.DbModel.EntityBase;

namespace Pyro.Web.CompositionRoot
{
  public class IndexSetterFactory<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType> :
      IIndexSetterFactory<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
  {
    private readonly SimpleInjector.Container Container;

    public IndexSetterFactory(SimpleInjector.Container Container)
    {
      this.Container = Container;
    }

    public IReferenceSetter<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType> CreateReferenceSetter()
    {
      return Container.GetInstance<IReferenceSetter<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>>();
    }

    public INumberSetter<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType> CreateNumberSetter()
    {
      return Container.GetInstance<INumberSetter<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>>();
    }

    public IDateTimeSetter<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType> CreateDateTimeSetter()
    {
      return Container.GetInstance<IDateTimeSetter<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>>();
    }

    public IQuantitySetter<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType> CreateQuantitySetter()
    {
      return Container.GetInstance<IQuantitySetter<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>>();
    }

    public IStringSetter<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType> CreateStringSetter()
    {
      return Container.GetInstance<IStringSetter<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>>();
    }

    public ITokenSetter<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType> CreateTokenSetter()
    {
      return Container.GetInstance<ITokenSetter<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>>();
    }

    public IUriSetter<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType> CreateUriSetter()
    {
      return Container.GetInstance<IUriSetter<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>>();
    }
  }
}
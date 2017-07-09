using System;
using Pyro.DataLayer.IndexSetter;

namespace Pyro.Web.CompositionRoot
{
  public class IndexSetterFactory : IIndexSetterFactory
  {
    private readonly SimpleInjector.Container Container;

    public IndexSetterFactory(SimpleInjector.Container Container)
    {
      this.Container = Container;
    }

    public IReferenceSetter CreateReferenceSetter()
    {
      return Container.GetInstance<IReferenceSetter>();
    }

    public INumberSetter CreateINumberSetter()
    {
      return Container.GetInstance<INumberSetter>();
    }

    public IDateTimeSetter CreateDateTimeSetter()
    {
      return Container.GetInstance<IDateTimeSetter>();
    }

    public IQuantitySetter CreateQuantitySetter()
    {
      return Container.GetInstance<IQuantitySetter>();
    }

    public IStringSetter CreateStringSetter()
    {
      return Container.GetInstance<IStringSetter>();
    }

    public ITokenSetter CreateTokenSetter()
    {
      return Container.GetInstance<ITokenSetter>();
    }

    public IUriSetter CreateUriSetter()
    {
      return Container.GetInstance<IUriSetter>();
    }
  }
}
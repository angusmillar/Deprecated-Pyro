using Pyro.Common.SearchIndexer;
using Pyro.Common.SearchIndexer.Setter;
using System;

namespace Pyro.Common.CompositionRoot.Concrete
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

    public INumberSetter CreateNumberSetter()
    {
      return Container.GetInstance<INumberSetter>();
    }

    //public IDateTimeSetter CreateDateTimeSetter()
    //{
    //  return Container.GetInstance<IDateTimeSetter>();
    //}

    //public IQuantitySetter CreateQuantitySetter()
    //{
    //  return Container.GetInstance<IQuantitySetter>();
    //}

    //public IStringSetter CreateStringSetter()
    //{
    //  return Container.GetInstance<IStringSetter>();
    //}

    //public ITokenSetter CreateTokenSetter()
    //{
    //  return Container.GetInstance<ITokenSetter>();
    //}

    //public IUriSetter CreateUriSetter()
    //{
    //  return Container.GetInstance<IUriSetter>();
    //}
  }
}
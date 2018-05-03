﻿using Pyro.Common.Service;
using Pyro.Common.CompositionRoot;

namespace Pyro.Common.CompositionRoot.Concrete
{
  public class SearchParameterServiceFactory : ISearchParameterServiceFactory
  {
    private readonly SimpleInjector.Container Container;

    public SearchParameterServiceFactory(SimpleInjector.Container Container)
    {
      this.Container = Container;
    }

    public ISearchParameterService CreateSearchParameterService()
    {
      return Container.GetInstance<ISearchParameterService>();
    }
  }
}
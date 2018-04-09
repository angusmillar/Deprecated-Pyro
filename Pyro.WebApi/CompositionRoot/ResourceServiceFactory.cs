using Pyro.Common.CompositionRoot;
using Pyro.Common.Interfaces.Service;

namespace Pyro.WebApi.CompositionRoot
{
  public class ResourceServiceFactory : IResourceServiceFactory
  {
    private readonly SimpleInjector.Container Container;

    public ResourceServiceFactory(SimpleInjector.Container Container)
    {
      this.Container = Container;
    }

    public T Create<T>() where T : IResourceServices
    {
      return (T)Container.GetInstance(typeof(T));
    }
  }
}

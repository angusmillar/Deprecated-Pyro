using Pyro.Common.Interfaces.Service;


namespace Pyro.Common.CompositionRoot
{
  public interface IResourceServiceFactory
  {
    T Create<T>() where T : IResourceServices;
  }
}

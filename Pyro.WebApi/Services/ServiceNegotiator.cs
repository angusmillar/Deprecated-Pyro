using Pyro.Common.Interfaces.Service;

namespace Pyro.WebApi.Services
{
  public class ServiceNegotiator : IServiceNegotiator
  {
    private readonly SimpleInjector.Container Container;

    public ServiceNegotiator(SimpleInjector.Container Container)
    {
      this.Container = Container;
    }

    public T Create<T>() where T : IResourceServices
    {
      return (T)Container.GetInstance(typeof(T));
    }
  }
}

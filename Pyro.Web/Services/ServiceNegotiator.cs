using Pyro.Common.Interfaces.Service;

namespace Pyro.Web.Services
{
  public class ServiceNegotiator : IServiceNegotiator
  {
    private readonly SimpleInjector.Container Container;

    public ServiceNegotiator(SimpleInjector.Container Container)
    {
      this.Container = Container;
    }

    public T Create<T>() where T : ICommonServices
    {
      return (T)Container.GetInstance(typeof(T));
    }    
  }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.CompositionRoot.Concrete
{
  public class GenericInstanceFactory : IGenericInstanceFactory
  {
    private readonly SimpleInjector.Container Container;

    public GenericInstanceFactory(SimpleInjector.Container Container)
    {
      this.Container = Container;
    }

    public T Create<T>()
    {
      return (T)Container.GetInstance(typeof(T));
    }
  }
}

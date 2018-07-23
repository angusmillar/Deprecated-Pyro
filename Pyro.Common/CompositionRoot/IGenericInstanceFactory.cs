namespace Pyro.Common.CompositionRoot
{
  public interface IGenericInstanceFactory
  {
    T Create<T>();
  }
}
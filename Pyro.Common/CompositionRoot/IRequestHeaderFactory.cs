using Pyro.Common.Tools.Headers;

namespace Pyro.Common.CompositionRoot
{
  public interface IRequestHeaderFactory
  {
    IRequestHeader CreateRequestHeader();
  }
}
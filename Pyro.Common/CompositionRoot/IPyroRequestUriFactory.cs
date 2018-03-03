using Pyro.Common.Tools.UriSupport;

namespace Pyro.Common.CompositionRoot
{
  public interface IPyroRequestUriFactory
  {
    IPyroRequestUri CreateFhirRequestUri();
  }
}
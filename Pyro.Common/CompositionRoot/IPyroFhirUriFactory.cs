using Pyro.Common.Tools.UriSupport;

namespace Pyro.Common.CompositionRoot
{
  public interface IPyroFhirUriFactory
  {
    IPyroFhirUri CreateFhirRequestUri();
  }
}
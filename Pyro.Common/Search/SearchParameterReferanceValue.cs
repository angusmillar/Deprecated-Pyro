using Pyro.Common.Tools.UriSupport;

namespace Pyro.Common.Search
{
  public class SearchParameterReferanceValue : SearchParameterValueBase
  {
    public IPyroFhirUri FhirRequestUri { get; set; }
  }
}

using Pyro.Common.ServiceRoot;
using System;

namespace Pyro.Common.Tools.UriSupport
{
  public interface IPyroRequestUri
  {
    IPyroFhirUri FhirRequestUri { get; set; }
    IDtoRootUrlStore PrimaryRootUrlStore { get; set; }
  }
}

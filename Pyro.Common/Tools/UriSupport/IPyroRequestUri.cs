using System;
using Pyro.Common.Interfaces.Dto;

namespace Pyro.Common.Tools.UriSupport
{
  public interface IPyroRequestUri
  {
    IPyroFhirUri FhirRequestUri { get; set; }
    IDtoRootUrlStore PrimaryRootUrlStore { get; set; }
  }
}

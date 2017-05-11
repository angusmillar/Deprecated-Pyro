using System;
using Pyro.Common.Interfaces.Dto;

namespace Pyro.Common.Interfaces.UriSupport
{
  public interface IDtoRequestUri
  {
    //IFhirUri FhirUri { get; set; }
    IFhirRequestUri FhirRequestUri { get; set; }
    IDtoRootUrlStore PrimaryRootUrlStore { get; set; }
  }
}

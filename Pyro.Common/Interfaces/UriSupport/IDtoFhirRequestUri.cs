using System;

namespace Pyro.Common.Interfaces.UriSupport
{
  public interface IDtoFhirRequestUri
  {
    Pyro.Common.Interfaces.UriSupport.IFhirUri FhirUri { get; set; }
    Pyro.Common.Interfaces.Dto.IDtoRootUrlStore PrimaryRootUrlStore { get; set; }
  }
}

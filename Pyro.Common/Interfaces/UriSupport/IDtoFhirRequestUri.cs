using System;
using Pyro.Common.Interfaces.Dto;

namespace Pyro.Common.Interfaces.UriSupport
{
  public interface IDtoRequestUri
  {    
    IFhirRequestUri FhirRequestUri { get; set; }
    IDtoRootUrlStore PrimaryRootUrlStore { get; set; }
  }
}

using System;

namespace Blaze.Common.Interfaces.UriSupport
{
  public interface IDtoFhirRequestUri
  {
    Blaze.Common.Interfaces.UriSupport.IFhirUri FhirUri { get; set; }
    Blaze.Common.Interfaces.Dto.IDtoRootUrlStore PrimaryRootUrlStore { get; set; }
  }
}

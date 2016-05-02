using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.Common.BusinessEntities.UriSupport;
using Blaze.Common.Interfaces.UriSupport;
using Blaze.Common.Interfaces.Dto;
using Blaze.Common.Interfaces.Services;

namespace Blaze.Common.BusinessEntities.UriSupport
{
  public class DtoFhirRequestUri : IDtoFhirRequestUri
  {
    public IFhirUri FhirUri { get; set; }
    public IDtoRootUrlStore PrimaryRootUrlStore { get; set; }
    public static IDtoFhirRequestUri Create(IDtoRootUrlStore PrimaryRootUrlStore, IFhirUri RequestUri)
    {
      var FhirRequestUri = new DtoFhirRequestUri();
      FhirRequestUri.PrimaryRootUrlStore = PrimaryRootUrlStore;
      FhirRequestUri.FhirUri = RequestUri;
      return FhirRequestUri;
    }
  }
}

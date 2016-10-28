using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.BusinessEntities.UriSupport;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Services;

namespace Pyro.Common.BusinessEntities.UriSupport
{
  public class DtoFhirRequestUri : IDtoFhirRequestUri
  {
    public IFhirUri FhirUri { get; set; }
    public IDtoRootUrlStore PrimaryRootUrlStore { get; set; }
    public static IDtoFhirRequestUri Create(IDtoRootUrlStore PrimaryRootUrlStore, IFhirUri RequestUri)
    {
      var FhirRequestUri = Common.CommonFactory.GetFhirRequestUri();
      FhirRequestUri.PrimaryRootUrlStore = PrimaryRootUrlStore;
      FhirRequestUri.FhirUri = RequestUri;
      return FhirRequestUri;
    }
  }
}

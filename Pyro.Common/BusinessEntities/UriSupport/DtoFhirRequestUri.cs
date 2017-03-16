using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.BusinessEntities.UriSupport;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Service;

namespace Pyro.Common.BusinessEntities.UriSupport
{
  public class DtoFhirRequestUri : IDtoFhirRequestUri
  {
    public IFhirUri FhirUri { get; set; }
    public IDtoRootUrlStore PrimaryRootUrlStore { get; set; }
    internal DtoFhirRequestUri() { }
    internal DtoFhirRequestUri(IDtoRootUrlStore PrimaryRootUrlStore, IFhirUri RequestUri)
    {
      this.PrimaryRootUrlStore = PrimaryRootUrlStore;
      this.FhirUri = RequestUri;
    }
    internal DtoFhirRequestUri(IDtoRootUrlStore PrimaryRootUrlStore)
    {
      this.PrimaryRootUrlStore = PrimaryRootUrlStore;
      this.FhirUri = null;
    }


  }
}

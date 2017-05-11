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
  public class DtoRequestUri : IDtoRequestUri
  {    
    public IDtoRootUrlStore PrimaryRootUrlStore { get; set; }
    public IFhirRequestUri FhirRequestUri { get; set; }

    internal DtoRequestUri() { }

    internal DtoRequestUri(IDtoRootUrlStore PrimaryRootUrlStore, IFhirRequestUri FhirRequestUri)
    {
      this.PrimaryRootUrlStore = PrimaryRootUrlStore;
      this.FhirRequestUri = FhirRequestUri;
    }
    
  }
}

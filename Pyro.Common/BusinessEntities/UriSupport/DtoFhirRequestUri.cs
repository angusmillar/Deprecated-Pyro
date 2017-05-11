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
    //public IFhirUri FhirUri { get; set; }
    public IDtoRootUrlStore PrimaryRootUrlStore { get; set; }
    public IFhirRequestUri FhirRequestUri { get; set; }

    internal DtoRequestUri() { }
    //internal DtoFhirRequestUri(IDtoRootUrlStore PrimaryRootUrlStore, IFhirUri RequestUri)
    //{
    //  this.PrimaryRootUrlStore = PrimaryRootUrlStore;
    //  this.FhirUri = RequestUri;
    //}
    //internal DtoFhirRequestUri(IDtoRootUrlStore PrimaryRootUrlStore)
    //{
    //  this.PrimaryRootUrlStore = PrimaryRootUrlStore;
    //  this.FhirUri = null;
    //}

    internal DtoRequestUri(IDtoRootUrlStore PrimaryRootUrlStore, IFhirRequestUri FhirRequestUri)
    {
      this.PrimaryRootUrlStore = PrimaryRootUrlStore;
      this.FhirRequestUri = FhirRequestUri;

    }

    internal DtoRequestUri(IDtoRootUrlStore PrimaryRootUrlStore)
    {
      this.PrimaryRootUrlStore = PrimaryRootUrlStore;
      this.FhirRequestUri = null;

    }


  }
}

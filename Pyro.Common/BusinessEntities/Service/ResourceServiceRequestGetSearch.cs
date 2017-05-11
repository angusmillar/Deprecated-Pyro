using System;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Interfaces.Dto;

namespace Pyro.Common.BusinessEntities.Service
{
  public class ResourceServiceRequestGetSearch : IResourceServiceRequestGetSearch
  {
    public IDtoRequestUri RequestUri { get; set; }
    public IDtoSearchParameterGeneric SearchParameterGeneric { get; set; }

    public ResourceServiceRequestGetSearch(IDtoRequestUri FhirRequestUri, IDtoSearchParameterGeneric SearchParameterGeneric)
    {
      if (FhirRequestUri == null)
        throw new NullReferenceException("FhirRequestUri can not be null.");

      if (SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric can not be null.");

      this.RequestUri = FhirRequestUri;
      this.SearchParameterGeneric = SearchParameterGeneric;
    }

  }
}

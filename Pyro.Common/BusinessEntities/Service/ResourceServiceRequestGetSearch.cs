using System;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Interfaces.Dto;

namespace Pyro.Common.BusinessEntities.Service
{
  public class ResourceServiceRequestGetSearch : IResourceServiceRequestGetSearch
  {
    public IDtoFhirRequestUri FhirRequestUri { get; set; }
    public IDtoSearchParameterGeneric SearchParameterGeneric { get; set; }

    public ResourceServiceRequestGetSearch(IDtoFhirRequestUri FhirRequestUri, IDtoSearchParameterGeneric SearchParameterGeneric)
    {
      if (FhirRequestUri == null)
        throw new NullReferenceException("FhirRequestUri can not be null.");

      if (SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric can not be null.");

      this.FhirRequestUri = FhirRequestUri;
      this.SearchParameterGeneric = SearchParameterGeneric;
    }

  }
}

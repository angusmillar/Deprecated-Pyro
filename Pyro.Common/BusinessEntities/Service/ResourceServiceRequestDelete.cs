using System;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Interfaces.Dto;

namespace Pyro.Common.BusinessEntities.Service
{
  public class ResourceServiceRequestDelete : IResourceServiceRequestDelete
  {    
    public string ResourceId { get; set; }
    public IDtoFhirRequestUri FhirRequestUri { get; set; }
    public IDtoSearchParameterGeneric SearchParameterGeneric { get; set; }
   
    public ResourceServiceRequestDelete(string ResourceId, IDtoFhirRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric SearchParameterGeneric)
    {   
      this.ResourceId = ResourceId;
      this.FhirRequestUri = DtoFhirRequestUri;
      this.SearchParameterGeneric = SearchParameterGeneric;   
    }

  }
}

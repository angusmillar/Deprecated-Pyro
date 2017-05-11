using System;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Interfaces.Dto;

namespace Pyro.Common.BusinessEntities.Service
{
  public class ResourceServiceRequestDelete : IResourceServiceRequestDelete
  {    
    public string ResourceId { get; set; }
    public IDtoRequestUri RequestUri { get; set; }
    public IDtoSearchParameterGeneric SearchParameterGeneric { get; set; }
   
    public ResourceServiceRequestDelete(string ResourceId, IDtoRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric SearchParameterGeneric)
    {   
      this.ResourceId = ResourceId;
      this.RequestUri = DtoFhirRequestUri;
      this.SearchParameterGeneric = SearchParameterGeneric;   
    }

  }
}

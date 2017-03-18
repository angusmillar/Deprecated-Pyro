using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Enum;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Dto.Headers;

namespace Pyro.Common.BusinessEntities.Service
{
  public class ResourceServiceRequestGetHistory : IResourceServiceRequestGetHistory
  {    
    public string ResourceId { get; set; }
    public string VersionId { get; set; }    
    public IDtoFhirRequestUri FhirRequestUri { get; set; }
    public IDtoSearchParameterGeneric SearchParameterGeneric { get; set; }    

    public ResourceServiceRequestGetHistory(string ResourceId, string Vid, IDtoFhirRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric SearchParameterGeneric)
    {
      if (string.IsNullOrEmpty(ResourceId))
        throw new NullReferenceException("ResourceId can not be null or empty string.");
      //VersionId can be null
      if (FhirRequestUri == null)
        throw new NullReferenceException("FhirRequestUri can not be null.");
      if (SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric can not be null.");

      this.ResourceId = ResourceId;
      this.VersionId = Vid;      
      this.FhirRequestUri = DtoFhirRequestUri;
      this.SearchParameterGeneric = SearchParameterGeneric;      
    }
  }
}

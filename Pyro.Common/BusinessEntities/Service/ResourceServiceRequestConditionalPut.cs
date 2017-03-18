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
  public class ResourceServiceRequestConditionalPut : IResourceServiceRequestConditionalPut
  {    
    public Resource Resource { get; set; }
    public IDtoFhirRequestUri FhirRequestUri { get; set; }
    public IDtoSearchParameterGeneric SearchParameterGeneric { get; set; }

    public ResourceServiceRequestConditionalPut(Resource Resource, IDtoFhirRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric SearchParameterGeneric)
    {
      if (Resource == null)
        throw new NullReferenceException($"{Resource.ToString()} can not be null.");
      if (DtoFhirRequestUri == null)
        throw new NullReferenceException($"{DtoFhirRequestUri.ToString()} can not be null.");
      if (SearchParameterGeneric == null)
        throw new NullReferenceException($"{SearchParameterGeneric.ToString()} can not be null.");

      this.Resource = Resource;
      this.FhirRequestUri = DtoFhirRequestUri;
      this.SearchParameterGeneric = SearchParameterGeneric;
    }
  }
}

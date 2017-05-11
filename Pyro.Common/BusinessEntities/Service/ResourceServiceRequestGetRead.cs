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
  public class ResourceServiceRequestGetRead : IResourceServiceRequestGetRead
  {    
    public string ResourceId { get; set; }
    public IDtoRequestUri RequestUri { get; set; }
    public IDtoSearchParameterGeneric SearchParameterGeneric { get; set; }
    public IDtoRequestHeaders RequestHeaders { get; set; }

    public ResourceServiceRequestGetRead(string ResourceId, IDtoRequestUri DtoRequestUri, IDtoSearchParameterGeneric SearchParameterGeneric, IDtoRequestHeaders RequestHeaders)
    {
      if (string.IsNullOrWhiteSpace(ResourceId))
        throw new NullReferenceException("ResourceId can not be null or empty string.");
      if (DtoRequestUri == null)
        throw new NullReferenceException("DtoFhirRequestUri can not be null.");
      if (SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric can not be null.");
      if (RequestHeaders == null)
        throw new NullReferenceException("RequestHeaders can not be null.");

      this.ResourceId = ResourceId;
      this.RequestUri = DtoRequestUri;
      this.SearchParameterGeneric = SearchParameterGeneric;
      this.RequestHeaders = RequestHeaders;
    }
  }
}

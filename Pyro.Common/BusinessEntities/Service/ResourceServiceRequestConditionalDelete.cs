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
  public class ResourceServiceRequestConditionalDelete : IResourceServiceRequestConditionalDelete
  {
    public IDtoRequestUri RequestUri { get; set; }
    public IDtoSearchParameterGeneric SearchParameterGeneric { get; set; }
   
    public ResourceServiceRequestConditionalDelete(IDtoRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric SearchParameterGeneric)
    {
      this.RequestUri = DtoFhirRequestUri;
      this.SearchParameterGeneric = SearchParameterGeneric;   
    }


  }
}

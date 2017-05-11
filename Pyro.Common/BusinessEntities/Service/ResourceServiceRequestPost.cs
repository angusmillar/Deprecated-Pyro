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
  public class ResourceServiceRequestPost : IResourceServiceRequestPost
  {    
    public Resource Resource { get; set; }
    public string ForceId { get; set; }
    public IDtoRequestUri RequestUri { get; set; }
    public IDtoSearchParameterGeneric SearchParameterGeneric { get; set; }
    public IDtoRequestHeaders RequestHeaders { get; set; }

    public ResourceServiceRequestPost(Resource Resource, IDtoRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric SearchParameterGeneric, IDtoRequestHeaders RequestHeaders, string ForceId = null)
    {
      ConstructorSetter(Resource, DtoFhirRequestUri, SearchParameterGeneric, RequestHeaders, ForceId);
    }

    public ResourceServiceRequestPost(Resource Resource, IDtoRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric SearchParameterGeneric)
    {
      ConstructorSetter(Resource, DtoFhirRequestUri, SearchParameterGeneric, null, null);
    }

    private void ConstructorSetter(Resource Resource, IDtoRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric SearchParameterGeneric, IDtoRequestHeaders RequestHeaders, string ForceId = null)
    {
      //RequestHeaders can be null as seen on ConditonalPut (Update) which does not have RequestHeaders when it perfomes a Post (add) due to the
      //Resource search parameters not resolving to a Resource instance.

      //ForceId is used to force that the Post (add) uses the resource Id given, this is used by Batch Transaction operation
      
      if (Resource == null)
        throw new NullReferenceException("Resource can not be null.");
      if (DtoFhirRequestUri == null)
        throw new NullReferenceException("DtoFhirRequestUri can not be null.");
      if (SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric can not be null.");

      if (!string.IsNullOrWhiteSpace(ForceId))
      {
        Guid TempGuid;
        if (!Guid.TryParseExact(ForceId, "D", out TempGuid))
        {
          throw new FormatException($"The 'ForceId' used by the server in a POST (add) request must be a valid GUID. Value given was: {ForceId}");
        }        
      }

      this.Resource = Resource;
      this.ForceId = ForceId;
      this.RequestUri = DtoFhirRequestUri;
      this.SearchParameterGeneric = SearchParameterGeneric;
      this.RequestHeaders = RequestHeaders;
    }


  }
}

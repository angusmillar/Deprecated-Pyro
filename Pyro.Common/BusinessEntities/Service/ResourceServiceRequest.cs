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
  public class ResourceServiceRequest : IResourceServiceRequest
  {
    public ServiceEnums.ServiceRequestType ServiceRequestType { get; set; }
    public string ResourceId { get; set; }
    public string VersionId { get; set; }
    public Resource Resource { get; set; }
    public IDtoFhirRequestUri FhirRequestUri { get; set; }    
    public IDtoSearchParameterGeneric SearchParameterGeneric { get; set; }
    public IDtoRequestHeaders RequestHeaders { get; set; }

    public ResourceServiceRequest(ServiceEnums.ServiceRequestType ServiceRequestType, IDtoSearchParameterGeneric SearchParameterGeneric)
    {
      this.ServiceRequestType = ServiceRequestType;
      this.ResourceId = null;
      this.VersionId = null;
      this.Resource = null;
      this.FhirRequestUri = null;      
      this.SearchParameterGeneric = SearchParameterGeneric;
      this.RequestHeaders = null;
    }

    public ResourceServiceRequest(ServiceEnums.ServiceRequestType ServiceRequestType, string ResourceId, IDtoFhirRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric SearchParameterGeneric)
    {
      this.ServiceRequestType = ServiceRequestType;
      this.ResourceId = ResourceId;
      this.VersionId = string.Empty;
      this.Resource = null;
      this.FhirRequestUri = DtoFhirRequestUri;
      this.SearchParameterGeneric = SearchParameterGeneric;
      this.RequestHeaders = null;
    }

    public ResourceServiceRequest(ServiceEnums.ServiceRequestType ServiceRequestType, string ResourceId, Resource Resource, IDtoFhirRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric SearchParameterGeneric)
    {
      this.ServiceRequestType = ServiceRequestType;
      this.ResourceId = ResourceId;
      this.VersionId = string.Empty;
      this.Resource = Resource;
      this.FhirRequestUri = DtoFhirRequestUri;
      this.SearchParameterGeneric = SearchParameterGeneric;
      this.RequestHeaders = null;
    }

    public ResourceServiceRequest(ServiceEnums.ServiceRequestType ServiceRequestType, Resource Resource, IDtoFhirRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric SearchParameterGeneric, IDtoRequestHeaders RequestHeaders)
    {
      this.ServiceRequestType = ServiceRequestType;
      this.ResourceId = string.Empty;
      this.VersionId = string.Empty;
      this.Resource = Resource;
      this.FhirRequestUri = DtoFhirRequestUri;
      this.SearchParameterGeneric = SearchParameterGeneric;
      this.RequestHeaders = RequestHeaders;
    }

    public ResourceServiceRequest(ServiceEnums.ServiceRequestType ServiceRequestType, Resource Resource, IDtoFhirRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric SearchParameterGeneric)
    {
      this.ServiceRequestType = ServiceRequestType;
      this.ResourceId = string.Empty;
      this.VersionId = string.Empty;
      this.Resource = Resource;
      this.FhirRequestUri = DtoFhirRequestUri;
      this.SearchParameterGeneric = SearchParameterGeneric;
      this.RequestHeaders = null;
    }

    public ResourceServiceRequest(ServiceEnums.ServiceRequestType ServiceRequestType, IDtoFhirRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric SearchParameterGeneric)
    {
      this.ServiceRequestType = ServiceRequestType;
      this.ResourceId = string.Empty;
      this.VersionId = string.Empty;
      this.Resource = null;
      this.FhirRequestUri = DtoFhirRequestUri;
      this.SearchParameterGeneric = SearchParameterGeneric;
      this.RequestHeaders = null;
    }

    public ResourceServiceRequest(ServiceEnums.ServiceRequestType ServiceRequestType, string FhirId, string Vid, IDtoFhirRequestUri DtoFhirRequestUri, IDtoSearchParameterGeneric SearchParameterGeneric)
    {
      this.ServiceRequestType = ServiceRequestType;
      this.ResourceId = FhirId;
      this.VersionId = Vid;
      this.Resource = null;
      this.FhirRequestUri = DtoFhirRequestUri;
      this.SearchParameterGeneric = SearchParameterGeneric;
      this.RequestHeaders = null;
    }
  }
}

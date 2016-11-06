using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Pyro.Common.Interfaces.Services;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Enum;

namespace Pyro.Web.Services
{
  public class ServiceRequest : IServiceRequest
  {
    public ServiceEnums.ServiceRequestType ServiceRequestType { get; set; }
    public string ResourceId { get; set; }
    public string VersionId { get; set; }
    public Resource Resource { get; set; }
    public IDtoFhirRequestUri FhirRequestUri { get; set; }
    public SearchParams SearchParams { get; set; }

    public ServiceRequest(ServiceEnums.ServiceRequestType ServiceRequestType, string ResourceId)
    {
      this.ServiceRequestType = ServiceRequestType;
      this.ResourceId = ResourceId;
      this.VersionId = string.Empty;
      this.Resource = null;
      this.FhirRequestUri = null;
      this.SearchParams = null;
    }

    public ServiceRequest(ServiceEnums.ServiceRequestType ServiceRequestType, string ResourceId, Resource Resource, IDtoFhirRequestUri DtoFhirRequestUri)
    {
      this.ServiceRequestType = ServiceRequestType;
      this.ResourceId = ResourceId;
      this.VersionId = string.Empty;
      this.Resource = Resource;
      this.FhirRequestUri = DtoFhirRequestUri;
      this.SearchParams = null;
    }

    public ServiceRequest(ServiceEnums.ServiceRequestType ServiceRequestType, Resource Resource, IDtoFhirRequestUri DtoFhirRequestUri)
    {
      this.ServiceRequestType = ServiceRequestType;
      this.ResourceId = string.Empty;
      this.VersionId = string.Empty;
      this.Resource = Resource;
      this.FhirRequestUri = DtoFhirRequestUri;
      this.SearchParams = null;
    }

    public ServiceRequest(ServiceEnums.ServiceRequestType ServiceRequestType, IDtoFhirRequestUri DtoFhirRequestUri, SearchParams SearchParams)
    {
      this.ServiceRequestType = ServiceRequestType;
      this.ResourceId = string.Empty;
      this.VersionId = string.Empty;
      this.Resource = null;
      this.FhirRequestUri = DtoFhirRequestUri;
      this.SearchParams = SearchParams;
    }

    public ServiceRequest(ServiceEnums.ServiceRequestType ServiceRequestType, string FhirId, string Vid, IDtoFhirRequestUri DtoFhirRequestUri, SearchParams SearchParams)
    {
      this.ServiceRequestType = ServiceRequestType;
      this.ResourceId = FhirId;
      this.VersionId = Vid;
      this.Resource = null;
      this.FhirRequestUri = DtoFhirRequestUri;
      this.SearchParams = SearchParams;
    }
  }
}

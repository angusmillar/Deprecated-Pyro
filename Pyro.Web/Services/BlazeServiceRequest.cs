using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Pyro.Common.Interfaces.Services;
using Pyro.Common.Interfaces.UriSupport;

namespace Pyro.Web.Services
{
  public class PyroServiceRequest : IPyroServiceRequest
  {
    public string ResourceId { get; set; }
    public Resource Resource { get; set; }
    public IDtoFhirRequestUri FhirRequestUri { get; set; }
    public SearchParams SearchParams { get; set; }

    public PyroServiceRequest(string ResourceId, Resource Resource, IDtoFhirRequestUri DtoFhirRequestUri)
    {
      this.ResourceId = ResourceId;
      this.Resource = Resource;
      this.FhirRequestUri = DtoFhirRequestUri;
      this.SearchParams = null;
    }

    public PyroServiceRequest(Resource Resource, IDtoFhirRequestUri DtoFhirRequestUri)
    {
      this.ResourceId = null;
      this.Resource = Resource;
      this.FhirRequestUri = DtoFhirRequestUri;
      this.SearchParams = null;
    }

    public PyroServiceRequest(IDtoFhirRequestUri DtoFhirRequestUri, SearchParams SearchParams)
    {
      this.ResourceId = null;
      this.Resource = null;
      this.FhirRequestUri = DtoFhirRequestUri;
      this.SearchParams = SearchParams;
    }
  }
}

using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Dto.Headers;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Interfaces.Service;
using System;

namespace Pyro.Common.BusinessEntities.Service
{
  public class ResourceOperationsServiceRequest : IResourceOperationsServiceRequest
  {    
    public string OperationName { get; set; }
    public Resource Resource { get; set; }
    public IResourceServices ResourceServices { get; set; }
    public IDtoFhirRequestUri FhirRequestUri { get; set; }
    public IDtoSearchParameterGeneric SearchParameterGeneric { get; set; }
    public IDtoRequestHeaders RequestHeaders { get; set; }    

    internal ResourceOperationsServiceRequest(string OperationName, Resource Resource, IResourceServices ResourceServices, IDtoFhirRequestUri FhirRequestUri, IDtoSearchParameterGeneric SearchParameterGeneric, IDtoRequestHeaders RequestHeaders)
    {
      this.OperationName = OperationName;
      this.Resource = Resource;
      this.ResourceServices = ResourceServices;
      this.FhirRequestUri = FhirRequestUri;
      this.SearchParameterGeneric = SearchParameterGeneric;
      this.RequestHeaders = RequestHeaders;
    }
  }
}

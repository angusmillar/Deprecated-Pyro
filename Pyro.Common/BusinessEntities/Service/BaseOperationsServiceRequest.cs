using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Dto.Headers;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Interfaces.Service;
using System;

namespace Pyro.Common.BusinessEntities.Service
{
  public class BaseOperationsServiceRequest : IBaseOperationsServiceRequest
  {    
    public string OperationName { get; set; }
    public IResourceServices ResourceServices { get; set; }
    public IDtoRequestUri RequestUri { get; set; }
    public IDtoSearchParameterGeneric SearchParameterGeneric { get; set; }
    public IDtoRequestHeaders RequestHeaders { get; set; }
    public Resource Resource { get; set; }

    internal BaseOperationsServiceRequest(string OperationName, Resource Resource, IResourceServices ResourceServices, IDtoRequestUri FhirRequestUri, IDtoSearchParameterGeneric SearchParameterGeneric, IDtoRequestHeaders RequestHeaders)
    {
      this.OperationName = OperationName;  
      this.ResourceServices = ResourceServices;
      this.RequestUri = FhirRequestUri;
      this.SearchParameterGeneric = SearchParameterGeneric;
      this.RequestHeaders = RequestHeaders;
      this.Resource = Resource;
    }

    internal BaseOperationsServiceRequest(string OperationName, IResourceServices ResourceServices, IDtoRequestUri FhirRequestUri, IDtoSearchParameterGeneric SearchParameterGeneric, IDtoRequestHeaders RequestHeaders)
    {
      this.OperationName = OperationName;
      this.ResourceServices = ResourceServices;
      this.RequestUri = FhirRequestUri;
      this.SearchParameterGeneric = SearchParameterGeneric;
      this.RequestHeaders = RequestHeaders;
      this.Resource = null;
    }

  }
}

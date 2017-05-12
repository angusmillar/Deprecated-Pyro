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
    public IServiceNegotiator ServiceNegotiator { get; set; }
    public IDtoRequestUri RequestUri { get; set; }
    public IDtoSearchParameterGeneric SearchParameterGeneric { get; set; }
    public IDtoRequestHeaders RequestHeaders { get; set; }
    public Resource Resource { get; set; }

    internal BaseOperationsServiceRequest(string OperationName, Resource Resource, IServiceNegotiator ServiceNegotiator, IDtoRequestUri FhirRequestUri, IDtoSearchParameterGeneric SearchParameterGeneric, IDtoRequestHeaders RequestHeaders)
    {
      this.OperationName = OperationName;  
      this.ServiceNegotiator = ServiceNegotiator;
      this.RequestUri = FhirRequestUri;
      this.SearchParameterGeneric = SearchParameterGeneric;
      this.RequestHeaders = RequestHeaders;
      this.Resource = Resource;
    }
  }
}

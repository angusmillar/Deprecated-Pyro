using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Dto.Headers;
using Pyro.Common.BusinessEntities.FhirOperation;
using Pyro.Common.Interfaces.UriSupport;

namespace Pyro.Common.Interfaces.Service
{
  public interface IBaseOperationsServiceRequest
  {
    string OperationName { get; set; }
    OperationClass OperationClass { get; set; }
    IResourceServices ResourceServices { get; set; }
    IDtoRequestUri RequestUri { get; set; }
    IDtoSearchParameterGeneric SearchParameterGeneric { get; set; }
    IDtoRequestHeaders RequestHeaders { get; set; }
    Resource Resource { get; set; }
  }
}

using System.Net;
using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.BusinessEntities.Service;
using System.Collections.Generic;
using Pyro.Common.BusinessEntities.FhirOperation;
using Pyro.Common.Enum;

namespace Pyro.Common.Interfaces.Service
{
  public interface ISearchParametersServiceRequest
  {
    IDtoSearchParameterGeneric SearchParameterGeneric { get; set; }
    SearchParameterService.SearchParameterServiceType SearchParameterServiceType { get; set; }
    FHIRAllTypes? ResourceType { get; set; }
    OperationClass OperationClass { get; set; }
    ICommonServices CommonServices { get; set; }
    UriSupport.IDtoRequestUri RequestUri { get; set; }
  }
}
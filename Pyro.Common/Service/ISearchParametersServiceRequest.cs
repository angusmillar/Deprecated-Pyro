using Hl7.Fhir.Model;
using Pyro.Common.Search;
using Pyro.Common.FhirOperation;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Tools.UriSupport;

namespace Pyro.Common.Service
{
  public interface ISearchParametersServiceRequest
  {
    ISearchParameterGeneric SearchParameterGeneric { get; set; }
    SearchParameterService.SearchParameterServiceType SearchParameterServiceType { get; set; }
    FHIRAllTypes? ResourceType { get; set; }
    OperationClass OperationClass { get; set; }
    //ICommonServices CommonServices { get; set; }
    IPyroRequestUri RequestUri { get; set; }
  }
}
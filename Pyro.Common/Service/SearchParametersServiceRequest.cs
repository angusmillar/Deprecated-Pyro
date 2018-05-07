using Hl7.Fhir.Model;
using Pyro.Common.Search;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.FhirOperation;

namespace Pyro.Common.Service
{
  public class SearchParametersServiceRequest : ISearchParametersServiceRequest
  {
    public ISearchParameterGeneric SearchParameterGeneric { get; set; }
    public SearchParameterService.SearchParameterServiceType SearchParameterServiceType { get; set; }
    public OperationClass OperationClass { get; set; }
    public FHIRAllTypes? ResourceType { get; set; }
    //public ICommonServices CommonServices { get; set; }
    public IPyroRequestUri RequestUri { get; set; }

    internal SearchParametersServiceRequest() { }
  }
}

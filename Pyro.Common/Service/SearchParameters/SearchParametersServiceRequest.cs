using Hl7.Fhir.Model;
using Pyro.Common.FhirOperation;
using Pyro.Common.Search;
using Pyro.Common.Tools.UriSupport;

namespace Pyro.Common.Service.SearchParameters
{
  public class SearchParametersServiceRequest : ISearchParametersServiceRequest
  {
    public ISearchParameterGeneric SearchParameterGeneric { get; set; }
    public SearchParameterService.SearchParameterServiceType SearchParameterServiceType { get; set; }
    public OperationClass OperationClass { get; set; }
    public FHIRAllTypes? ResourceType { get; set; }    
    public IPyroRequestUri RequestUri { get; set; }

    internal SearchParametersServiceRequest() { }
  }
}

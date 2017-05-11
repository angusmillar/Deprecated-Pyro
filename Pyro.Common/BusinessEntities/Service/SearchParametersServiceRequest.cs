using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.UriSupport;

namespace Pyro.Common.BusinessEntities.Service
{
  public class SearchParametersServiceRequest : ISearchParametersServiceRequest
  {
    public IDtoSearchParameterGeneric SearchParameterGeneric { get; set; }
    public SearchParameterService.SearchParameterServiceType SearchParameterServiceType { get; set; }
    public FHIRAllTypes? ResourceType { get; set; }
    public ICommonServices CommonServices { get; set; }
    public IDtoRequestUri RequestUri { get; set; }

    internal SearchParametersServiceRequest(){}
  }
}

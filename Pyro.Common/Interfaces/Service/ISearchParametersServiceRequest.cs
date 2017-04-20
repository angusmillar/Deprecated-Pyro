using System.Net;
using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.BusinessEntities.Service;
using System.Collections.Generic;
using Pyro.Common.BusinessEntities.Dto;

namespace Pyro.Common.Interfaces.Service
{
  public interface ISearchParametersServiceRequest
  {
    IDtoSearchParameterGeneric SearchParameterGeneric { get; set; }
    SearchParameterService.SearchParameterServiceType SearchParameterServiceType { get; set; }
    FHIRAllTypes? ResourceType { get; set; }
    ICommonServices CommonServices { get; set; }
    //IList<DtoServiceSearchParameterLight> DtoServiceSearchParameterLightList { get; set; }
  }
}
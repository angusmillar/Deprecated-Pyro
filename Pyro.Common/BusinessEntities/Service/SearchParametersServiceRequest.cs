using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.Dto;
//using Pyro.Common.Interfaces.Service;
using Pyro.Common.BusinessEntities.Dto;

namespace Pyro.Common.BusinessEntities.Service
{
  public class SearchParametersServiceRequest : ISearchParametersServiceRequest
  {
    public IDtoSearchParameterGeneric SearchParameterGeneric { get; set; }
    public SearchParameterService.SearchParameterServiceType SearchParameterServiceType { get; set; }
    public FHIRAllTypes? ResourceType { get; set; }
    public ICommonServices CommonServices { get; set; }
    //public IList<DtoServiceSearchParameterLight> DtoServiceSearchParameterLightList { get; set; }

    internal SearchParametersServiceRequest(){}
  }
}

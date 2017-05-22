using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.BusinessEntities.Dto;

namespace Pyro.Common.Interfaces.Service
{
  public interface ICommonServices
  {
    IDtoRootUrlStore GetPrimaryServiceRootUrl();
    IDtoRootUrlStore SetPrimaryRootUrlStore(string RootUrl);
    List<DtoServiceSearchParameterLight> GetServiceSearchParametersForResource(string ResourceType);

    List<DtoServiceSearchParameterHeavy> GetServiceSearchParametersHeavy(bool CustomOnly = false);
    List<DtoServiceSearchParameterHeavy> GetServiceSearchParametersHeavyForResource(string ResourceType);
    void AddServiceSearchParametersHeavy(DtoServiceSearchParameterHeavy ServiceSearchParameterHeavy);

  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Search;

namespace Pyro.Common.Interfaces.Service
{
  public interface ICommonServices
  {
    IDtoRootUrlStore GetPrimaryServiceRootUrl();
    IDtoRootUrlStore SetPrimaryRootUrlStore(string RootUrl);
    //List<ServiceSearchParameterLight> GetServiceSearchParametersForResource(string ResourceType);
    //List<ServiceSearchParameterHeavy> GetServiceSearchParametersHeavy(bool CustomOnly = false);
    //List<ServiceSearchParameterHeavy> GetServiceSearchParametersHeavyForResource(string ResourceType);
    //ServiceSearchParameterHeavy AddServiceSearchParametersHeavy(ServiceSearchParameterHeavy ServiceSearchParameterHeavy);
    //ServiceSearchParameterHeavy UpdateServiceSearchParametersHeavy(ServiceSearchParameterHeavy ServiceSearchParameterHeavy);
    //void DeleteServiceSearchParameters(int Id);

  }
}

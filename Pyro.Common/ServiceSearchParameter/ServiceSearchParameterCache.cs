using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.Search;
using Pyro.Common.Global;
using Pyro.Common.Cache;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.ITools;
using Pyro.Common.Interfaces.Service;
using System.Collections.Generic;

namespace Pyro.Common.ServiceSearchParameter
{
  public class ServiceSearchParameterCache : IServiceSearchParameterCache
  {
    private readonly ICommonServices ICommonServices;
    private readonly IGlobalProperties GlobalProperties;
    private readonly IApplicationCacheSupport IApplicationCacheSupport;
    public ServiceSearchParameterCache(ICommonServices ICommonServices, IGlobalProperties GlobalProperties, IApplicationCacheSupport IApplicationCacheSupport)
    {
      this.ICommonServices = ICommonServices;
      this.GlobalProperties = GlobalProperties;
      this.IApplicationCacheSupport = IApplicationCacheSupport;
    }

    public List<ServiceSearchParameterLight> GetSearchParameterForResource(string ResourceType)
    {
      var DtoServiceSearchParameterLightList = new List<ServiceSearchParameterLight>();
      string Resource_ResourceName = FHIRAllTypes.Resource.GetLiteral();
      if (!GlobalProperties.ApplicationCacheServicesActive)
      {
        //Add the general Resource search parameters as well          
        DtoServiceSearchParameterLightList.AddRange(ICommonServices.GetServiceSearchParametersForResource(Resource_ResourceName));
        //Get all for the Resource Asked for       
        DtoServiceSearchParameterLightList.AddRange(ICommonServices.GetServiceSearchParametersForResource(ResourceType));
      }
      else
      {
        //Add the general Resource search parameters as well
        DtoServiceSearchParameterLightList.AddRange(IApplicationCacheSupport.GetOrSet($"GetServiceSearchParametersForResource.{Resource_ResourceName}", () => ICommonServices.GetServiceSearchParametersForResource(Resource_ResourceName)));

        DtoServiceSearchParameterLightList.AddRange(IApplicationCacheSupport.GetOrSet($"GetServiceSearchParametersForResource.{ResourceType}", () => ICommonServices.GetServiceSearchParametersForResource(ResourceType)));
      }

      return DtoServiceSearchParameterLightList;
    }

  }
}

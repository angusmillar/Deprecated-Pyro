using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.Search;
using Pyro.Common.Global;
using Pyro.Common.Cache;
using Pyro.Common.Interfaces.Service;
using System.Collections.Generic;

namespace Pyro.Common.ServiceSearchParameter
{
  public class ServiceSearchParameterCache : IServiceSearchParameterCache
  {
    private readonly IServiceSearchParameterService IServiceSearchParameterService;
    private readonly IGlobalProperties GlobalProperties;
    private readonly IApplicationCacheSupport IApplicationCacheSupport;
    public ServiceSearchParameterCache(IServiceSearchParameterService IServiceSearchParameterService, IGlobalProperties GlobalProperties, IApplicationCacheSupport IApplicationCacheSupport)
    {
      this.IServiceSearchParameterService = IServiceSearchParameterService;
      this.GlobalProperties = GlobalProperties;
      this.IApplicationCacheSupport = IApplicationCacheSupport;
    }

    public List<DtoServiceSearchParameterLight> GetSearchParameterForResource(string ResourceType)
    {
      var DtoServiceSearchParameterLightList = new List<DtoServiceSearchParameterLight>();
      string Resource_ResourceName = FHIRAllTypes.Resource.GetLiteral();
      if (!GlobalProperties.ApplicationCacheServicesActive)
      {
        //Add the general Resource search parameters as well          
        DtoServiceSearchParameterLightList.AddRange(IServiceSearchParameterService.GetServiceSearchParametersForResource(Resource_ResourceName));
        //Get all for the Resource Asked for, unless it was just resource type 'Resource'  
        if (ResourceType != Resource_ResourceName)
          DtoServiceSearchParameterLightList.AddRange(IServiceSearchParameterService.GetServiceSearchParametersForResource(ResourceType));
      }
      else
      {
        //Add the general Resource search parameters as well
        DtoServiceSearchParameterLightList.AddRange(IApplicationCacheSupport.GetOrSet($"GetServiceSearchParametersForResource.{Resource_ResourceName}", () => IServiceSearchParameterService.GetServiceSearchParametersForResource(Resource_ResourceName)));

        //Get all for the Resource Asked for, unless it was just resource type 'Resource'  
        if (ResourceType != Resource_ResourceName)
          DtoServiceSearchParameterLightList.AddRange(IApplicationCacheSupport.GetOrSet($"GetServiceSearchParametersForResource.{ResourceType}", () => IServiceSearchParameterService.GetServiceSearchParametersForResource(ResourceType)));
      }

      return DtoServiceSearchParameterLightList;
    }

  }
}

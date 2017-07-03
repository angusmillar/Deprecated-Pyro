using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Common.BusinessEntities.Global;
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

    public List<DtoServiceSearchParameterLight> GetSearchParameterForResource(string ResourceType)
    {
      var DtoServiceSearchParameterLightList = new List<DtoServiceSearchParameterLight>();
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

    public List<DtoServiceSearchParameterLight> GetSearchParameterForResource(Common.Interfaces.Repositories.IDtoCommonRepository ICommonRepository, string ResourceType)
    {
      var DtoServiceSearchParameterLightList = new List<DtoServiceSearchParameterLight>();
      //Add the general Resource search parameters as well
      string Resource_ResourceName = FHIRAllTypes.Resource.GetLiteral();
      if (!GlobalProperties.ApplicationCacheServicesActive)
      {
        DtoServiceSearchParameterLightList.AddRange(ICommonRepository.GetServiceSearchParametersLightForResource(Resource_ResourceName));
        DtoServiceSearchParameterLightList.AddRange(ICommonRepository.GetServiceSearchParametersLightForResource(ResourceType));
      }
      else
      {
        DtoServiceSearchParameterLightList.AddRange(IApplicationCacheSupport.GetOrSet($"GetServiceSearchParametersForResource.{Resource_ResourceName}", () => ICommonRepository.GetServiceSearchParametersLightForResource(Resource_ResourceName)));
        DtoServiceSearchParameterLightList.AddRange(IApplicationCacheSupport.GetOrSet($"GetServiceSearchParametersForResource.{ResourceType}", () => ICommonRepository.GetServiceSearchParametersLightForResource(ResourceType)));
      }
      return DtoServiceSearchParameterLightList;
    }


  }
}

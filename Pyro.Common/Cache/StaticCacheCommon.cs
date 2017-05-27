using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.ITools;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Common.BusinessEntities;
using System.Configuration;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;

namespace Pyro.Common.Cache
{
  public static class StaticCacheCommon
  {
    public static IDtoRootUrlStore GetPrimaryRootUrlStore(ICommonServices CommonServices)
    {
      IDtoRootUrlStore PrimaryRootUrlStore = null;
      
      //At Runtime get the URL from the database and then Cache it
      IApplicationCacheSupport Cache = Common.CommonFactory.GetApplicationCacheService();      
      PrimaryRootUrlStore = Cache.GetOrSet(() => CommonServices.GetPrimaryServiceRootUrl());

      return PrimaryRootUrlStore;
    }

    public static List<DtoServiceSearchParameterLight> GetSearchParameterForResource(ICommonServices CommonServices, string ResourceType)
    {
      var DtoServiceSearchParameterLightList = new List<DtoServiceSearchParameterLight>();

      IApplicationCacheSupport Cache = Common.CommonFactory.GetApplicationCacheService();
      
      //Add the general Resource search parameters as well
      string Resource_ResourceName = FHIRAllTypes.Resource.GetLiteral();
      DtoServiceSearchParameterLightList.AddRange(Cache.GetOrSet($"GetServiceSearchParametersForResource.{Resource_ResourceName}", () => CommonServices.GetServiceSearchParametersForResource(Resource_ResourceName)));
      
      //Get all for the Resource Asked for       
      DtoServiceSearchParameterLightList.AddRange(Cache.GetOrSet($"GetServiceSearchParametersForResource.{ResourceType}", () => CommonServices.GetServiceSearchParametersForResource(ResourceType)));
      
      return DtoServiceSearchParameterLightList;
    }

    public static List<DtoServiceSearchParameterLight> GetSearchParameterForResource(Common.Interfaces.Repositories.IDtoCommonRepository ICommonRepository, string ResourceType)
    {
      var DtoServiceSearchParameterLightList = new List<DtoServiceSearchParameterLight>();
      
      IApplicationCacheSupport Cache = Common.CommonFactory.GetApplicationCacheService();
      
      //Add the general Resource search parameters as well
      string Resource_ResourceName = FHIRAllTypes.Resource.GetLiteral();
      DtoServiceSearchParameterLightList.AddRange(Cache.GetOrSet($"GetServiceSearchParametersForResource.{Resource_ResourceName}", () => ICommonRepository.GetServiceSearchParametersLightForResource(Resource_ResourceName)));

      //Get all for the Resource Asked for 
      DtoServiceSearchParameterLightList.AddRange(Cache.GetOrSet($"GetServiceSearchParametersForResource.{ResourceType}", () => ICommonRepository.GetServiceSearchParametersLightForResource(ResourceType)));

      return DtoServiceSearchParameterLightList;
    }

    public static string WebConfigServiceBaseURL
    {
      get
      {
        IApplicationCacheSupport Cache = Common.CommonFactory.GetApplicationCacheService();
        return Cache.GetOrSet(() => WebConfigProperties.ServiceBaseURL());
      }
    }

    public static void ClearCache()
    {
      IApplicationCacheSupport Cache = Common.CommonFactory.GetApplicationCacheService();
      Cache.RemoveAll();
    }

  }




}
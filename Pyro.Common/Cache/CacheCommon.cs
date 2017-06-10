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
  public class CacheCommon
  {
    //Turn this off to debug with no cache.
    private readonly bool TurnCacheOff = false;

    public IDtoRootUrlStore GetPrimaryRootUrlStore(ICommonServices CommonServices)
    {
      IDtoRootUrlStore PrimaryRootUrlStore = null;
      //At Runtime get the URL from the database and then Cache it
      if (TurnCacheOff)
      {
        PrimaryRootUrlStore = CommonServices.GetPrimaryServiceRootUrl();
      }
      else
      {
        IApplicationCacheSupport Cache = Common.CommonFactory.GetApplicationCacheService();
        PrimaryRootUrlStore = Cache.GetOrSet(() => CommonServices.GetPrimaryServiceRootUrl());
      }
      return PrimaryRootUrlStore;
    }

    public List<DtoServiceSearchParameterLight> GetSearchParameterForResource(ICommonServices CommonServices, string ResourceType)
    {
      var DtoServiceSearchParameterLightList = new List<DtoServiceSearchParameterLight>();

      string Resource_ResourceName = FHIRAllTypes.Resource.GetLiteral();
      if (TurnCacheOff)
      {
        //Add the general Resource search parameters as well          
        DtoServiceSearchParameterLightList.AddRange(CommonServices.GetServiceSearchParametersForResource(Resource_ResourceName));
        //Get all for the Resource Asked for       
        DtoServiceSearchParameterLightList.AddRange(CommonServices.GetServiceSearchParametersForResource(ResourceType));
      }
      else
      {
        IApplicationCacheSupport Cache = Common.CommonFactory.GetApplicationCacheService();
        //Add the general Resource search parameters as well
        DtoServiceSearchParameterLightList.AddRange(Cache.GetOrSet($"GetServiceSearchParametersForResource.{Resource_ResourceName}", () => CommonServices.GetServiceSearchParametersForResource(Resource_ResourceName)));

        DtoServiceSearchParameterLightList.AddRange(Cache.GetOrSet($"GetServiceSearchParametersForResource.{ResourceType}", () => CommonServices.GetServiceSearchParametersForResource(ResourceType)));
      }

      return DtoServiceSearchParameterLightList;
    }

    public List<DtoServiceSearchParameterLight> GetSearchParameterForResource(Common.Interfaces.Repositories.IDtoCommonRepository ICommonRepository, string ResourceType)
    {
      var DtoServiceSearchParameterLightList = new List<DtoServiceSearchParameterLight>();
      //Add the general Resource search parameters as well
      string Resource_ResourceName = FHIRAllTypes.Resource.GetLiteral();
      if (TurnCacheOff)
      {
        DtoServiceSearchParameterLightList.AddRange(ICommonRepository.GetServiceSearchParametersLightForResource(Resource_ResourceName));
        DtoServiceSearchParameterLightList.AddRange(ICommonRepository.GetServiceSearchParametersLightForResource(ResourceType));
      }
      else
      {
        IApplicationCacheSupport Cache = Common.CommonFactory.GetApplicationCacheService();
        DtoServiceSearchParameterLightList.AddRange(Cache.GetOrSet($"GetServiceSearchParametersForResource.{Resource_ResourceName}", () => ICommonRepository.GetServiceSearchParametersLightForResource(Resource_ResourceName)));
        DtoServiceSearchParameterLightList.AddRange(Cache.GetOrSet($"GetServiceSearchParametersForResource.{ResourceType}", () => ICommonRepository.GetServiceSearchParametersLightForResource(ResourceType)));
      }
      return DtoServiceSearchParameterLightList;
    }

    public string WebConfigServiceBaseURL()
    {
      if (TurnCacheOff)
      {
        return WebConfigProperties.ServiceBaseURL();
      }
      else
      {
        IApplicationCacheSupport Cache = Common.CommonFactory.GetApplicationCacheService();
        return Cache.GetOrSet(() => WebConfigProperties.ServiceBaseURL());
      }
    }

    public void ClearCache()
    {
      IApplicationCacheSupport Cache = Common.CommonFactory.GetApplicationCacheService();
      Cache.RemoveAll();
    }

  }




}
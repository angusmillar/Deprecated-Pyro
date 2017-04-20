using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Tools;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Common.BusinessEntities;
using System.Configuration;

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

    public static IList<DtoServiceSearchParameterLight> GetSearchParameterForResource(ICommonServices CommonServices, string ResourceType)
    {
      IList<DtoServiceSearchParameterLight> DtoServiceSearchParameterLightList = null;
     
      //At Runtime get the URL from the database and then Cache it
      IApplicationCacheSupport Cache = Common.CommonFactory.GetApplicationCacheService();
      DtoServiceSearchParameterLightList = Cache.GetOrSet($"GetServiceSearchParametersForResource.{ResourceType}", () => CommonServices.GetServiceSearchParametersForResource(ResourceType));
     
      return DtoServiceSearchParameterLightList;
    }

    public static IList<DtoServiceSearchParameterLight> GetSearchParameterForResource(Common.Interfaces.Repositories.IDtoCommonRepository ICommonRepository, string ResourceType)
    {
      IList<DtoServiceSearchParameterLight> DtoServiceSearchParameterLightList = null;

      //At Runtime get the URL from the database and then Cache it
      IApplicationCacheSupport Cache = Common.CommonFactory.GetApplicationCacheService();
      DtoServiceSearchParameterLightList = Cache.GetOrSet($"GetServiceSearchParametersForResource.{ResourceType}", () => ICommonRepository.GetServiceSearchParametersForResource(ResourceType));

      return DtoServiceSearchParameterLightList;
    }

  }




}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Tools;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Common.BusinessEntities;

namespace Pyro.Web.ApplicationCache
{
  public static class StaticCache
  {    
    public static IDtoRootUrlStore LoadStaticCache(ICommonServices CommonServices)
    {
      IDtoRootUrlStore PrimaryRootUrlStore = null;

#if DEBUG
      //Development static set for speed.
      PrimaryRootUrlStore = Common.CommonFactory.GetRootUrlStore();
      PrimaryRootUrlStore.IsServersPrimaryUrlRoot = true;
      PrimaryRootUrlStore.ServiceRootUrlStoreID = 1;
      //PrimaryRootUrlStore.RootUrl = "localhost:50579/test/stu3/fhir";
      PrimaryRootUrlStore.RootUrl = "localhost:8888/test/stu3/fhir";
#else
        //Runtime use cache
        IApplicationCacheSupport Cache = Common.CommonFactory.GetApplicationCacheService();        
        PrimaryRootUrlStore = Cache.GetOrSet(() => CommonServices.GetPrimaryServiceRootUrl());
#endif

      return PrimaryRootUrlStore;
    }

  }




}
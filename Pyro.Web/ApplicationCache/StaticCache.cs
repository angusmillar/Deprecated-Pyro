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
      
      string Port = Pyro.Common.Web.StaticWebInfo.TestingPort;
      string uri = "localhost";
      string FhirEndpoint = uri + ":" + Port + "/" + Pyro.Common.Web.StaticWebInfo.ServiceRoute;
      PrimaryRootUrlStore.RootUrl = FhirEndpoint;      
      //PrimaryRootUrlStore.RootUrl = "localhost:50579/test/stu3/fhir";
#else
        //Runtime use cache
        IApplicationCacheSupport Cache = Common.CommonFactory.GetApplicationCacheService();        
        PrimaryRootUrlStore = Cache.GetOrSet(() => CommonServices.GetPrimaryServiceRootUrl());
#endif

      return PrimaryRootUrlStore;
    }

  }




}
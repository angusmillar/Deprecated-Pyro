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

namespace Pyro.Web.ApplicationCache
{
  public static class StaticCache
  {
    public static IDtoRootUrlStore GetPrimaryRootUrlStore(ICommonServices CommonServices)
    {
      IDtoRootUrlStore PrimaryRootUrlStore = null;

#if DEBUG
      //In Development just return the URL from the Web config as if it came from the database 
      //to avoid waiting for the DB to initalise.
      PrimaryRootUrlStore = Common.CommonFactory.GetRootUrlStore();
      PrimaryRootUrlStore.IsServersPrimaryUrlRoot = true;
      PrimaryRootUrlStore.ServiceRootUrlStoreID = 1;
      PrimaryRootUrlStore.RootUrl = WebConfigServiceBaseURLForComparison;
      //PrimaryRootUrlStore.RootUrl = "localhost:8887/test/stu3/fhir";      
#else
        //At Runtime get the URL from the database and then Cache it
        IApplicationCacheSupport Cache = Common.CommonFactory.GetApplicationCacheService();        
        PrimaryRootUrlStore = Cache.GetOrSet(() => CommonServices.GetPrimaryServiceRootUrl());
#endif

      return PrimaryRootUrlStore;
    }

    public static string WebConfigServiceBaseURL
    {
      get
      {
        IApplicationCacheSupport Cache = Common.CommonFactory.GetApplicationCacheService();
        return Cache.GetOrSet(() => WebConfigProperties.ServiceBaseURL());
      }
    }

    public static string WebConfigServiceBaseURLForComparison
    {
      get
      {
        var ServiceRootUri = new Uri(WebConfigServiceBaseURL);
        return ServiceRootUri.Authority + ServiceRootUri.AbsolutePath;
      }
    }


  }




}
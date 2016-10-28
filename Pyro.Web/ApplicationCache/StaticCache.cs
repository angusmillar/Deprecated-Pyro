using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pyro.Common.Interfaces.Services;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Common.BusinessEntities;

namespace Pyro.Web.ApplicationCache
{
  public static class StaticCache
  {
    private static readonly string Key = "PrimaryRootUrlStore";
    public static IDtoRootUrlStore LoadStaticCache(ICommonServices CommonServices)
    {
      IDtoRootUrlStore PrimaryRootUrlStore = GetDtoRootUrlStore();
      if (PrimaryRootUrlStore == null)
      {
#if DEBUG
        PrimaryRootUrlStore = Common.CommonFactory.GetRootUrlStore();
        PrimaryRootUrlStore.IsServersPrimaryUrlRoot = true;
        PrimaryRootUrlStore.ServiceRootUrlStoreID = 1;
        PrimaryRootUrlStore.RootUrl = "localhost:50579/fhirapi";
#else        
          PrimaryRootUrlStore = CommonServices.GetPrimaryServiceRootUrl();
#endif
        //PrimaryRootUrlStore = CommonServices.GetPrimaryServiceRootUrl();
        HttpContext.Current.Application[Key] = PrimaryRootUrlStore;         
      }
      return PrimaryRootUrlStore;
    }

    public static IDtoRootUrlStore GetDtoRootUrlStore()
    {
      return HttpContext.Current.Application[Key] as IDtoRootUrlStore;
    }
  }
}
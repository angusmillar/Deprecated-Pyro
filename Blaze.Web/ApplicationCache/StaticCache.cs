using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blaze.Common.Interfaces.Services;
using Blaze.Common.Interfaces.Dto;
using Blaze.Common.BusinessEntities.Dto;
using Blaze.Common.BusinessEntities;

namespace Blaze.Web.ApplicationCache
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
        PrimaryRootUrlStore = new DtoRootUrlStore();
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
      return HttpContext.Current.Application[Key] as DtoRootUrlStore;
    }
  }
}
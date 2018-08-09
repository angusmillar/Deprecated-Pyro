using Pyro.Common.Global;
using Pyro.Common.Cache;
using Pyro.Common.Tools;
using Pyro.Common.Interfaces.Service;

namespace Pyro.Common.ServiceRoot
{
  public class PrimaryServiceRootCache : IPrimaryServiceRootCache
  {
    private readonly IServicePrimaryBaseUrlService IServiceBaseUrlService;
    private readonly IGlobalProperties GlobalProperties;
    private readonly IApplicationCacheSupport IApplicationCacheSupport;
    private readonly string CacheKeyString = "PrimaryServiceRootUrlString";
    private readonly string CacheKeyStore = "PrimaryServiceRootUrlStore";

    public PrimaryServiceRootCache(IServicePrimaryBaseUrlService IServiceBaseUrlService, IGlobalProperties GlobalProperties, IApplicationCacheSupport ApplicationCacheSupport)
    {
      this.IServiceBaseUrlService = IServiceBaseUrlService;
      this.GlobalProperties = GlobalProperties;
      this.IApplicationCacheSupport = ApplicationCacheSupport;
    }

    public IDtoRootUrlStore GetPrimaryRootUrlStoreFromDatabase()
    {
      //At Runtime get the URL from the database and then Cache it
      if (!GlobalProperties.ApplicationCacheServicesActive)
      {
        return IServiceBaseUrlService.GetPrimaryServiceRootUrl();
      }
      else
      {
        return IApplicationCacheSupport.GetOrSet(CacheKeyStore, () => IServiceBaseUrlService.GetPrimaryServiceRootUrl());        
      }
    }

    public string GetPrimaryRootUrlFromWebConfig()
    {
      if (!GlobalProperties.ApplicationCacheServicesActive)
      {
        return GlobalProperties.ServiceBaseURL;
      }
      else
      {
        return IApplicationCacheSupport.GetOrSet(CacheKeyString, () => GlobalProperties.ServiceBaseURL);        
      }
    }

    public void ClearPrimaryRootUrlFromCache()
    {
      if (GlobalProperties.ApplicationCacheServicesActive)
      {
        IApplicationCacheSupport.RemoveKey(CacheKeyString);
      }
    }

    public void ClearPrimaryRootUrlStoreFromCache()
    {
      if (GlobalProperties.ApplicationCacheServicesActive)
      {
        IApplicationCacheSupport.RemoveKey(CacheKeyStore);
      }
    }

  }
}

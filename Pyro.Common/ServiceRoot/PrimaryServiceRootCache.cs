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
    private readonly string CacheKey = "PrimaryServiceRootUrl";

    public PrimaryServiceRootCache(IServicePrimaryBaseUrlService IServiceBaseUrlService, IGlobalProperties GlobalProperties, IApplicationCacheSupport ApplicationCacheSupport)
    {
      this.IServiceBaseUrlService = IServiceBaseUrlService;
      this.GlobalProperties = GlobalProperties;
      this.IApplicationCacheSupport = ApplicationCacheSupport;
    }

    public IDtoRootUrlStore GetPrimaryRootUrlFromDatabase()
    {
      //At Runtime get the URL from the database and then Cache it
      if (!GlobalProperties.ApplicationCacheServicesActive)
      {
        return IServiceBaseUrlService.GetPrimaryServiceRootUrl();
      }
      else
      {
        return IApplicationCacheSupport.GetOrSet(CacheKey, () => IServiceBaseUrlService.GetPrimaryServiceRootUrl());        
      }
    }

    public string GetPrimaryRootUrlFromWebConfig()
    {
      if (!GlobalProperties.ApplicationCacheServicesActive)
      {
        return WebConfigProperties.ServiceBaseURL();
      }
      else
      {
        return IApplicationCacheSupport.GetOrSet(CacheKey, () => WebConfigProperties.ServiceBaseURL());        
      }
    }

    public void ClearPrimaryRootUrlFromCache()
    {
      if (GlobalProperties.ApplicationCacheServicesActive)
      {
        IApplicationCacheSupport.RemoveKey(CacheKey);
      }
    }

  }
}

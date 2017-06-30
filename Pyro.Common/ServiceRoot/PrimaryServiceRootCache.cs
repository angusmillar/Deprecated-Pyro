using Pyro.Common.BusinessEntities.Global;
using Pyro.Common.Cache;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.ITools;
using Pyro.Common.Interfaces.Service;

namespace Pyro.Common.ServiceRoot
{
  public class PrimaryServiceRootCache : IPrimaryServiceRootCache
  {
    private readonly ICommonServices CommonServices;
    private readonly IGlobalProperties GlobalProperties;
    private readonly IApplicationCacheSupport ApplicationCacheSupport;
    public PrimaryServiceRootCache(ICommonServices CommonServices, IGlobalProperties GlobalProperties, IApplicationCacheSupport ApplicationCacheSupport)
    {
      this.CommonServices = CommonServices;
      this.GlobalProperties = GlobalProperties;
      this.ApplicationCacheSupport = ApplicationCacheSupport;
    }

    public IDtoRootUrlStore GetPrimaryRootUrlFromDatabase()
    {
      //At Runtime get the URL from the database and then Cache it
      if (!GlobalProperties.ApplicationCacheServicesActive)
      {
        return CommonServices.GetPrimaryServiceRootUrl();
      }
      else
      {
        return ApplicationCacheSupport.GetOrSet(() => CommonServices.GetPrimaryServiceRootUrl());
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
        IApplicationCacheSupport Cache = Common.CommonFactory.GetApplicationCacheService();
        return Cache.GetOrSet(() => WebConfigProperties.ServiceBaseURL());
      }
    }
  }
}

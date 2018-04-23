
namespace Pyro.Common.Cache
{
  public class CacheClear : ICacheClear
  {
    private readonly IApplicationCacheSupport IApplicationCacheSupport;
    public CacheClear(IApplicationCacheSupport IApplicationCacheSupport)
    {
      this.IApplicationCacheSupport = IApplicationCacheSupport;
    }

    public void ClearCache()
    {
      IApplicationCacheSupport.RemoveAll();      
    }
  }
}

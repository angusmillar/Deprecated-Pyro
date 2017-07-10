using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Common.BusinessEntities.Global;
using Pyro.Common.Cache;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.ITools;
using Pyro.Common.Interfaces.Service;
using System.Collections.Generic;

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

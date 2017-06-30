using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Cache;

namespace Pyro.Common.BusinessEntities.Global
{
  public sealed class GlobalProperties : IGlobalProperties
  {
    public GlobalProperties()
    {
      _ServiceRootUrl = WebConfigProperties.ServiceBaseURL();
      _ApplicationCacheServicesActive = true;
    }

    private string _ServiceRootUrl;
    public string ServiceRootUrl
    {
      get { return _ServiceRootUrl; }
    }

    private bool _ApplicationCacheServicesActive;
    public bool ApplicationCacheServicesActive
    {
      get
      {
        return _ApplicationCacheServicesActive;
      }
    }
  }



}

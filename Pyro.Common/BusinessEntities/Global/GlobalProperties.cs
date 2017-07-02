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
      _ApplicationVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(typeof(Pyro.Common.BusinessEntities.Global.GlobalProperties).Assembly.Location).ProductVersion;
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

    private string _ApplicationVersionInfo;
    public string ApplicationVersionInfo
    {
      get
      {
        return _ApplicationVersionInfo;
      }
    }

  }



}

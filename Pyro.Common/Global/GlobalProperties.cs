using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Cache;

namespace Pyro.Common.Global
{
  public sealed class GlobalProperties : IGlobalProperties
  {
    public GlobalProperties()
    {
      _ServiceRootUrl = WebConfigProperties.ServiceBaseURL();
      _ApplicationCacheServicesActive = WebConfigProperties.ApplicationCacheServicesActive();
      _ApplicationVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(typeof(GlobalProperties).Assembly.Location).ProductVersion;
      _NumberOfRecordsPerPageDefault = WebConfigProperties.NumberOfRecordsPerPageDefault();
      _MaxNumberOfRecordsPerPage = WebConfigProperties.MaxNumberOfRecordsPerPage();
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

    private int _NumberOfRecordsPerPageDefault;
    public int NumberOfRecordsPerPageDefault
    {
      get
      {
        return _NumberOfRecordsPerPageDefault;
      }
    }

    private int _MaxNumberOfRecordsPerPage;
    public int MaxNumberOfRecordsPerPage
    {
      get
      {
        return _MaxNumberOfRecordsPerPage;
      }
    }

  }



}

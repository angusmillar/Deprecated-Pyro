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
    }

    private string _ServiceRootUrl;
    public string ServiceRootUrl
    {
      get { return _ServiceRootUrl; }
    }

  }



}

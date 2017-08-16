using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.ServiceRoot;

namespace Pyro.Common.Tools.UriSupport
{
  public class PyroRequestUri : IPyroRequestUri
  {
    private readonly IPrimaryServiceRootCache IPrimaryServiceRootCache;

    public PyroRequestUri(IPrimaryServiceRootCache IPrimaryServiceRootCache)
    {
      this.IPrimaryServiceRootCache = IPrimaryServiceRootCache;
    }

    public IDtoRootUrlStore PrimaryRootUrlStore
    {
      get
      {
        return IPrimaryServiceRootCache.GetPrimaryRootUrlFromDatabase();
      }
      set
      {
        throw new NotImplementedException();
      }
    }
    public IPyroFhirUri FhirRequestUri { get; set; }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.BusinessEntities.UriSupport;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.ServiceRoot;

namespace Pyro.Common.BusinessEntities.UriSupport
{
  public class DtoRequestUriForDi : IDtoRequestUri
  {
    private readonly IPrimaryServiceRootCache IPrimaryServiceRootCache;

    public DtoRequestUriForDi(IPrimaryServiceRootCache IPrimaryServiceRootCache)
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
    public IFhirRequestUri FhirRequestUri { get; set; }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.Common.Interfaces.UriSupport;
using Blaze.Common.Interfaces.Dto;
using Blaze.Common.Interfaces.Services;
using Blaze.Common.Interfaces;
using Blaze.Common.BusinessEntities.UriSupport;
using Blaze.Common.BusinessEntities.Service;
using Blaze.Common.BusinessEntities.Dto;

namespace Blaze.Common
{
  public static class CommonFactory
  {
    public static IFhirUri GetFhirUri(string value)
    {
      return new DtoFhirUri(value);
    }

    public static IFhirUri GetFhirUri(Uri value)
    {
      return new DtoFhirUri(value);
    }

    public static IDtoFhirRequestUri GetFhirRequestUri()
    {
      return new DtoFhirRequestUri();
    }

    public static IDtoRootUrlStore GetRootUrlStore()
    {
      return new DtoRootUrlStore();
    }

    public static IServiceOperationOutcome GetBlazeServiceOperationOutcome()
    {
      return new ServiceOperationOutcome();
    }




  }
}

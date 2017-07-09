using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Enum;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.ITools;
using Pyro.Common.Interfaces.Dto.Headers;
using Pyro.Common.BusinessEntities.UriSupport;
using Pyro.Common.BusinessEntities.Service;
using Pyro.Common.BusinessEntities.Dto;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Pyro.Common.BusinessEntities.FhirOperation;

namespace Pyro.Common
{
  public static class CommonFactory
  {
    public static IDtoRootUrlStore GetRootUrlStore()
    {
      return new DtoRootUrlStore();
    }

    public static IResourceServiceOutcome GetResourceServiceOutcome()
    {
      return new ResourceServiceOutcome();
    }

    public static IDatabaseOperationOutcome GetDatabaseOperationOutcome()
    {
      return new DtoDatabaseOperationOutcome();
    }

    public static IApplicationCacheSupport GetApplicationCacheService()
    {
      return new Tools.ApplicationCacheSupport();
    }

    public static ISearchParametersServiceOutcome GetSearchParametersServiceOutcome()
    {
      return new SearchParametersServiceOutcome();
    }

    public static IFhirNarativeGenerationSupport GetFhirNarativeSupport()
    {
      return new Tools.FhirNarativeGenerationSupport();
    }


  }
}

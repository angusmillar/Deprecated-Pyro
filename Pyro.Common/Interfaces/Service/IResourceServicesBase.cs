using System.Collections.Generic;
using Hl7.Fhir.Model;
using Pyro.Common.Enum;
using Pyro.Common.Interfaces.Dto.Headers;
using Pyro.Common.Interfaces.UriSupport;

namespace Pyro.Common.Interfaces.Service
{
  public interface IResourceServicesBase
  {
    FHIRAllTypes ServiceResourceType { get; }
    FHIRAllTypes SetCurrentResourceType { set; }

    IResourceServiceOutcome GetResourceHistoryInFull(string ResourceId, IDtoRequestUri FhirRequestUri, ISearchParametersServiceOutcome SearchParametersServiceOutcome, IResourceServiceOutcome oPyroServiceOperationOutcome);
    IResourceServiceOutcome GetResourceHistoryInstance(string ResourceId, string Version, IDtoRequestUri FhirRequestUri, IResourceServiceOutcome oPyroServiceOperationOutcome);
    IResourceServiceOutcome GetResourceInstance(string ResourceId, IDtoRequestUri FhirRequestUri, IResourceServiceOutcome oPyroServiceOperationOutcome, IDtoRequestHeaders RequestHeaders = null);
    IResourceServiceOutcome GetResourcesBySearch(IDtoRequestUri FhirRequestUri, ISearchParametersServiceOutcome SearchParametersServiceOutcome, IResourceServiceOutcome oPyroServiceOperationOutcome);
    IResourceServiceOutcome SetResource(Resource Resource, IDtoRequestUri FhirRequestUri, RestEnum.CrudOperationType CrudOperationType);
    IResourceServiceOutcome SetResourceCollectionAsDeleted(ICollection<string> ResourceIdCollection);
  }
}
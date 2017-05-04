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

    IResourceServiceOutcome GetResourceHistoryInFull(string ResourceId, IDtoFhirRequestUri FhirRequestUri, ISearchParametersServiceOutcome SearchParametersServiceOutcome, IResourceServiceOutcome oPyroServiceOperationOutcome);
    IResourceServiceOutcome GetResourceHistoryInstance(string ResourceId, string Version, IDtoFhirRequestUri FhirRequestUri, IResourceServiceOutcome oPyroServiceOperationOutcome);
    IResourceServiceOutcome GetResourceInstance(string ResourceId, IDtoFhirRequestUri FhirRequestUri, IResourceServiceOutcome oPyroServiceOperationOutcome, IDtoRequestHeaders RequestHeaders = null);
    IResourceServiceOutcome GetResourcesBySearch(IDtoFhirRequestUri FhirRequestUri, ISearchParametersServiceOutcome SearchParametersServiceOutcome, IResourceServiceOutcome oPyroServiceOperationOutcome);
    IResourceServiceOutcome SetResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri, RestEnum.CrudOperationType CrudOperationType);
    IResourceServiceOutcome SetResourceCollectionAsDeleted(ICollection<string> ResourceIdCollection);
  }
}
using System.Collections.Generic;
using Hl7.Fhir.Model;
using Pyro.Common.Enum;
using Pyro.Common.Tools.Headers;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.Service;

namespace Pyro.Common.Interfaces.Service
{
  public interface IResourceServicesBase
  {
    FHIRAllTypes ServiceResourceType { get; }

    IResourceServiceOutcome GetResourceHistoryInFull(string ResourceId, IPyroRequestUri FhirRequestUri, ISearchParametersServiceOutcome SearchParametersServiceOutcome, IResourceServiceOutcome oPyroServiceOperationOutcome);
    IResourceServiceOutcome GetResourceHistoryInstance(string ResourceId, string Version, IPyroRequestUri FhirRequestUri, IResourceServiceOutcome oPyroServiceOperationOutcome);
    IResourceServiceOutcome GetResourceInstance(string ResourceId, IPyroRequestUri FhirRequestUri, IResourceServiceOutcome oPyroServiceOperationOutcome, IRequestHeader RequestHeaders = null);
    IResourceServiceOutcome GetResourcesBySearch(IPyroRequestUri FhirRequestUri, ISearchParametersServiceOutcome SearchParametersServiceOutcome, IResourceServiceOutcome oPyroServiceOperationOutcome);
    IResourceServiceOutcome SetResource(Resource Resource, IPyroRequestUri FhirRequestUri, RestEnum.CrudOperationType CrudOperationType);
    IResourceServiceOutcome SetResourceCollectionAsDeleted(ICollection<string> ResourceIdCollection);
  }
}
using System;
using System.Collections.Generic;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Common.Search;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.Interfaces.Service;
using Hl7.Fhir.Model;

namespace Pyro.Common.Interfaces.Repositories
{
  public interface IResourceRepository
  {
    FHIRAllTypes RepositoryResourceType { get; }
    IDatabaseOperationOutcome GetResourceBySearch(PyroSearchParameters DtoSearchParameters, bool WithXml = false);
    IDatabaseOperationOutcome AddResource(Resource Resource, IPyroRequestUri FhirRequestUri);
    IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IPyroRequestUri FhirRequestUri);
    IDatabaseOperationOutcome UpdateResouceIdAsDeleted(string FhirResourceId);
    IDatabaseOperationOutcome UpdateResouceIdColectionAsDeleted(ICollection<string> ResourceIdCollection);
    IDatabaseOperationOutcome GetResourceHistoryByFhirID(string FhirId, PyroSearchParameters DtoSearchParameters);
    IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirId, string ResourceVersionNumber);
    IDatabaseOperationOutcome GetResourceByFhirID(string FhirId, bool WithXml = false, bool IncludeDeleted = true);

    string[] GetResourceFhirIdByResourceIdAndIndexReferance(int ResourceId, int SearchParameterId);
    string[] GetResourceFhirIdByResourceIdAndIndexReferance2(int ResourceId, int[] SearchParameterIdArray, string ResourceName = "");

    int DeleteNonCurrentResourceIndexes();
    void AddCurrentResourceIndex(List<ServiceSearchParameterLight> ServiceSearchParameterLightList, IPyroRequestUri FhirRequestUri);
    int GetTotalCurrentResourceCount();
    DateTimeOffset? GetLastCurrentResourceLastUpdatedValue();
  }
}

using Hl7.Fhir.Model;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.Search;
using Pyro.Common.Tools.Headers;
using Pyro.Common.Service;
using Pyro.Common.RequestMetadata;
using Pyro.Common.Enum;

namespace Pyro.Common.Interfaces.Service
{
  public interface IResourceServices
  {
    //DbContextTransaction BeginTransaction();

    FHIRAllTypes ServiceResourceType { get; }
    void SetCurrentResourceType(FHIRAllTypes ResourceType);
    void SetCurrentResourceType(string ResourceName);
    void SetCurrentResourceType(ResourceType ResourceType);

    //Read
    // GET: URL/FhirApi/Patient/5    
    IResourceServiceOutcome GetRead(ResourceType ResourceType, string ResourceId, IRequestMeta RequestMeta);

    //Search
    // GET: URL/FhirApi/Patient/5    
    IResourceServiceOutcome GetSearch(IRequestMeta RequestMeta);

    //History
    // GET: URL/FhirApi/Patient/5/_history    
    // GET: URL/FhirApi/Patient/5/_history/2    
    IResourceServiceOutcome GetHistory(string ResourceId, string VersionId, IRequestMeta RequestMeta);

    // Add
    // POST: URL/FhirApi/Patient
    IResourceServiceOutcome Post(Resource Resource, IRequestMeta RequestMeta, string ForceId = "");

    //Update
    // PUT: URL/FhirApi/Patient/5
    IResourceServiceOutcome Put(string ResourceId, Resource Resource, IRequestMeta RequestMeta);

    //Delete
    // DELETE: URL/FhirApi/Patient/5    
    IResourceServiceOutcome Delete(string ResourceId, IRequestMeta RequestMeta);

    //Conditional Delete
    // DELETE: URL/FhirApi/Patient?identifier=12345&family=millar&given=angus 
    IResourceServiceOutcome ConditionalDelete(IRequestMeta RequestMeta);

    //Conditional Update
    /// PUT: URL/FhirApi/Patient?given=angus
    IResourceServiceOutcome ConditionalPut(Resource Resource, IRequestMeta RequestMeta);

    //DeleteHistoryIndexes
    // POST: URL/FhirAPI/Patient/$delete-history-indexes
    IResourceServiceOutcome DeleteHistoryIndexes(IPyroRequestUri RequestUri, ISearchParameterGeneric SearchParameterGeneric);


    IResourceServiceOutcome GetResourceHistoryInFull(string ResourceId, IPyroRequestUri FhirRequestUri, ISearchParametersServiceOutcome SearchParametersServiceOutcome, IResourceServiceOutcome oPyroServiceOperationOutcome);
    IResourceServiceOutcome GetResourceHistoryInstance(string ResourceId, string Version, IPyroRequestUri FhirRequestUri, IResourceServiceOutcome oPyroServiceOperationOutcome);
    IResourceServiceOutcome GetResourceInstance(string ResourceId, IPyroRequestUri FhirRequestUri, IResourceServiceOutcome oPyroServiceOperationOutcome, IRequestHeader RequestHeaders = null);
    IResourceServiceOutcome GetResourcesBySearch(IPyroRequestUri FhirRequestUri, ISearchParametersServiceOutcome SearchParametersServiceOutcome, IResourceServiceOutcome oPyroServiceOperationOutcome);
    IResourceServiceOutcome SetResource(Resource Resource, IPyroRequestUri FhirRequestUri, RestEnum.CrudOperationType CrudOperationType);
    IResourceServiceOutcome SetResourceCollectionAsDeleted(ICollection<string> ResourceIdCollection);

    //Add the given ServiceSearchParameterLight to the current resource instance
    void AddResourceIndexs(List<ServiceSearchParameterLight> ServiceSearchParameterLightList, IPyroRequestUri FhirRequestUri);

    DateTimeOffset? GetLastCurrentResourceLastUpdatedValue();

    int GetTotalCurrentResourceCount();

  }

}

using Hl7.Fhir.Model;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.Search;
using Pyro.Common.Tools.Headers;
using Pyro.Common.Service.ResourceService;
using Pyro.Common.RequestMetadata;
using Pyro.Common.Enum;

namespace Pyro.Common.Interfaces.Service
{
  public interface IResourceServices
  {
    
    //Read
    // GET: URL/FhirApi/Patient/5    
    IResourceServiceOutcome GetRead(string ResourceId, IRequestMeta RequestMeta);

    //Search
    // GET: URL/FhirApi/Patient/5    
    IResourceServiceOutcome GetSearch(IRequestMeta RequestMeta);

    // GET by Compartment Search
    // GET: URL/FhirApi/Patient/123456/Observation?code=http://loinc.org|LA20343-2          
    IResourceServiceOutcome GetCompartmentSearch(IRequestMeta RequestMeta, string Compartment, string id, string ResourceName);

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
    IResourceServiceOutcome DeleteHistoryIndexes(IRequestMeta RequestMeta);
    
    //Add the given ServiceSearchParameterLight to the current resource instance
    void AddResourceIndexs(ResourceType ResourceType, List<DtoServiceSearchParameterLight> ServiceSearchParameterLightList, IPyroRequestUri FhirRequestUri);
    
    //Get the dateTime that the last instance of this ResourceType was Added, Updated, Deleted in the server
    DateTimeOffset? GetLastCurrentResourceLastUpdatedValue(ResourceType ResourceType);

    //Get the Total count of this ResourceType in the server, only Current not History resources
    int GetTotalCurrentResourceCount(ResourceType ResourceType);

  }

}

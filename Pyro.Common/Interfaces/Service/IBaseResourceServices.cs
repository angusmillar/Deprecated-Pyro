using Hl7.Fhir.Model;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Dto.Headers;

namespace Pyro.Common.Interfaces.Service
{
  public interface IResourceServices : ICommonServices
  {
    DbContextTransaction BeginTransaction();

    FHIRAllTypes ServiceResourceType { get; }

    void SetCurrentResourceType(FHIRAllTypes ResourceType);
    void SetCurrentResourceType(string ResourceName);
    void SetCurrentResourceType(ResourceType ResourceType);

    //Read
    // GET: URL/FhirApi/Patient/5    
    IResourceServiceOutcome GetRead(
      string ResourceId,
      IDtoRequestUri RequestUri,
      IDtoSearchParameterGeneric SearchParameterGeneric,
      IDtoRequestHeaders RequestHeaders);

    //Search
    // GET: URL/FhirApi/Patient/5    
    IResourceServiceOutcome GetSearch(
      IDtoRequestUri RequestUri,
      IDtoSearchParameterGeneric SearchParameterGeneric);

    //History
    // GET: URL/FhirApi/Patient/5/_history    
    // GET: URL/FhirApi/Patient/5/_history/2    
    IResourceServiceOutcome GetHistory(
      string ResourceId,
      string VersionId,
      IDtoRequestUri RequestUri,
      IDtoSearchParameterGeneric SearchParameterGeneric);

    // Add
    // POST: URL/FhirApi/Patient
    IResourceServiceOutcome Post(
      Resource Resource,
      IDtoRequestUri RequestUri,
      IDtoSearchParameterGeneric SearchParameterGeneric,
      IDtoRequestHeaders RequestHeaders,
      string ForceId = "");

    //Update
    // PUT: URL/FhirApi/Patient/5
    IResourceServiceOutcome Put(
      string ResourceId,
      Resource Resource,
      IDtoRequestUri RequestUri,
      IDtoSearchParameterGeneric SearchParameterGeneric,
      IDtoRequestHeaders RequestHeaders);

    //Delete
    // DELETE: URL/FhirApi/Patient/5    
    IResourceServiceOutcome Delete(
      string ResourceId,
      IDtoRequestUri RequestUri,
      IDtoSearchParameterGeneric SearchParameterGeneric);

    //Conditional Delete
    // DELETE: URL/FhirApi/Patient?identifier=12345&family=millar&given=angus 
    IResourceServiceOutcome ConditionalDelete(
      IDtoRequestUri RequestUri,
      IDtoSearchParameterGeneric SearchParameterGeneric);

    //Conditional Update
    /// PUT: URL/FhirApi/Patient?given=angus
    IResourceServiceOutcome ConditionalPut(
      Resource Resource,
      IDtoRequestUri FhirRequestUri,
      IDtoSearchParameterGeneric SearchParameterGeneric);

    //DeleteHistoryIndexes
    // POST: URL/FhirAPI/Patient/$delete-history-indexes
    IResourceServiceOutcome DeleteHistoryIndexes(
      IDtoRequestUri RequestUri,
      IDtoSearchParameterGeneric SearchParameterGeneric);

    //Add the given ServiceSearchParameterLight to the current resource instance
    void AddResourceIndexs(List<Common.BusinessEntities.Dto.DtoServiceSearchParameterLight> ServiceSearchParameterLightList, IDtoRequestUri FhirRequestUri);

    DateTimeOffset? GetLastCurrentResourceLastUpdatedValue();

    int GetTotalCurrentResourceCount();

  }

}

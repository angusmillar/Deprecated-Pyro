using Hl7.Fhir.Model;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.Search;
using Pyro.Common.Tools.Headers;
using Pyro.Common.Service;

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
      IPyroRequestUri RequestUri,
      ISearchParameterGeneric SearchParameterGeneric,
      IRequestHeader RequestHeaders);

    //Search
    // GET: URL/FhirApi/Patient/5    
    IResourceServiceOutcome GetSearch(
      IPyroRequestUri RequestUri,
      ISearchParameterGeneric SearchParameterGeneric,
      IRequestHeader RequestHeaders);

    //History
    // GET: URL/FhirApi/Patient/5/_history    
    // GET: URL/FhirApi/Patient/5/_history/2    
    IResourceServiceOutcome GetHistory(
      string ResourceId,
      string VersionId,
      IPyroRequestUri RequestUri,
      ISearchParameterGeneric SearchParameterGeneric);

    // Add
    // POST: URL/FhirApi/Patient
    IResourceServiceOutcome Post(
      Resource Resource,
      IPyroRequestUri RequestUri,
      ISearchParameterGeneric SearchParameterGeneric,
      IRequestHeader RequestHeaders,
      string ForceId = "");

    //Update
    // PUT: URL/FhirApi/Patient/5
    IResourceServiceOutcome Put(
      string ResourceId,
      Resource Resource,
      IPyroRequestUri RequestUri,
      ISearchParameterGeneric SearchParameterGeneric,
      IRequestHeader RequestHeaders);

    //Delete
    // DELETE: URL/FhirApi/Patient/5    
    IResourceServiceOutcome Delete(
      string ResourceId,
      IPyroRequestUri RequestUri,
      ISearchParameterGeneric SearchParameterGeneric);

    //Conditional Delete
    // DELETE: URL/FhirApi/Patient?identifier=12345&family=millar&given=angus 
    IResourceServiceOutcome ConditionalDelete(
      IPyroRequestUri RequestUri,
      ISearchParameterGeneric SearchParameterGeneric);

    //Conditional Update
    /// PUT: URL/FhirApi/Patient?given=angus
    IResourceServiceOutcome ConditionalPut(
      Resource Resource,
      IPyroRequestUri FhirRequestUri,
      ISearchParameterGeneric SearchParameterGeneric);

    //DeleteHistoryIndexes
    // POST: URL/FhirAPI/Patient/$delete-history-indexes
    IResourceServiceOutcome DeleteHistoryIndexes(
      IPyroRequestUri RequestUri,
      ISearchParameterGeneric SearchParameterGeneric);

    //Add the given ServiceSearchParameterLight to the current resource instance
    void AddResourceIndexs(List<ServiceSearchParameterLight> ServiceSearchParameterLightList, IPyroRequestUri FhirRequestUri);

    DateTimeOffset? GetLastCurrentResourceLastUpdatedValue();

    int GetTotalCurrentResourceCount();

  }

}

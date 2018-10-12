using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.Compartment;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Enum;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.RequestMetadata;
using Pyro.Common.Search;
using Pyro.Common.Service.ResourceService;
using Pyro.Common.Service.Include;
using Pyro.Common.Tools;
using Pyro.Common.Tools.Headers;
using Pyro.Common.Tools.Paging;
using Pyro.Common.Tools.UriSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Pyro.Common.Service.CompartmentSearchParameter;
using Pyro.Common.Service.SearchParameters;
using Pyro.Common.DtoEntity;
using Pyro.Common.Search.SearchParameterEntity;
using Pyro.Common.Service.Smart;


namespace Pyro.Engine.Services.Resources
{
  public class ResourceServices : IResourceServices
  {
    private readonly IRepositorySwitcher IRepositorySwitcher;
    private readonly IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory;
    private readonly ISearchParameterServiceFactory ISearchParameterServiceFactory;
    private readonly ISearchParameterGenericFactory ISearchParameterGenericFactory;
    private readonly IIncludeService IIncludeService;
    private readonly IPyroFhirUriFactory IPyroFhirUriFactory;
    private readonly IServiceCompartmentCache IServiceCompartmentCache;
    private readonly ICompartmentSearchParameterService ICompartmentSearchParameterService;    
    private readonly IPagingSupport IPagingSupport;
    private readonly ISmartScopeService ISmartScopeService;

    private IResourceRepository IResourceRepository = null;

    //Constructor for dependency injection
    public ResourceServices(IRepositorySwitcher IRepositorySwitcher, IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory, ISearchParameterServiceFactory ISearchParameterServiceFactory, ISearchParameterGenericFactory ISearchParameterGenericFactory, IIncludeService IIncludeService, IPyroFhirUriFactory IPyroFhirUriFactory, IServiceCompartmentCache IServiceCompartmentCache, ICompartmentSearchParameterService ICompartmentSearchParameterService, IPagingSupport IPagingSupport, ISmartScopeService ISmartScopeService)
    {      
      this.IRepositorySwitcher = IRepositorySwitcher;
      this.IResourceServiceOutcomeFactory = IResourceServiceOutcomeFactory;
      this.ISearchParameterServiceFactory = ISearchParameterServiceFactory;
      this.ISearchParameterGenericFactory = ISearchParameterGenericFactory;
      this.IIncludeService = IIncludeService;
      this.IPyroFhirUriFactory = IPyroFhirUriFactory;
      this.IServiceCompartmentCache = IServiceCompartmentCache;
      this.ICompartmentSearchParameterService = ICompartmentSearchParameterService;      
      this.IPagingSupport = IPagingSupport;
      this.ISmartScopeService = ISmartScopeService;
    }

    private void SetCurrentResourceType(FHIRAllTypes ResourceType)
    {
      ServiceResourceType = ResourceType;
      IResourceRepository = IRepositorySwitcher.GetRepository(ServiceResourceType);
    }

    private void SetCurrentResourceType(ResourceType ResourceType)
    {
      SetCurrentResourceType(ResourceNameResolutionSupport.GetResourceFhirAllType(ResourceType));
    }

    private FHIRAllTypes ServiceResourceType { get; set; } = FHIRAllTypes.Resource;
    

    //GET Read   
    // Get: URL/Fhir/Patient/1
    public virtual IResourceServiceOutcome GetRead(string ResourceId, IRequestMeta RequestMeta)
    {
      if (RequestMeta == null)
        throw new NullReferenceException("RequestMeta can not be null.");
      if (string.IsNullOrWhiteSpace(ResourceId))
        throw new NullReferenceException("ResourceId can not be null or empty string.");
      if (RequestMeta.PyroRequestUri == null)
        throw new NullReferenceException("DtoFhirRequestUri can not be null.");
      if (RequestMeta.PyroRequestUri.FhirRequestUri == null)
        throw new NullReferenceException("FhirRequestUri can not be null.");
      if (RequestMeta.PyroRequestUri.FhirRequestUri.ResourceType.HasValue == false)
        throw new NullReferenceException("FhirRequestUri.ResourceType can not be null.");
      if (RequestMeta.SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric can not be null.");
      if (RequestMeta.RequestHeader == null)
        throw new NullReferenceException("RequestHeaders can not be null.");

      SetCurrentResourceType(RequestMeta.PyroRequestUri.FhirRequestUri.ResourceType.Value);

      IResourceServiceOutcome oServiceOperationOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
      oServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;

      // GET by FhirId
      // GET URL/FhirApi/Patient/5          
      ISearchParameterService SearchService = ISearchParameterServiceFactory.CreateSearchParameterService();
      ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchService.ProcessBaseSearchParameters(RequestMeta.SearchParameterGeneric);
      if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
      {
        oServiceOperationOutcome.ResourceResult = SearchParametersServiceOutcome.FhirOperationOutcome;
        oServiceOperationOutcome.HttpStatusCode = SearchParametersServiceOutcome.HttpStatusCode;
        oServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
        return oServiceOperationOutcome;
      }
      oServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;

      IDatabaseOperationOutcome DatabaseOperationOutcome = IResourceRepository.GetResourceByFhirID(ResourceId, true);

      if (DatabaseOperationOutcome.ReturnedResourceList.Count == 1 && !DatabaseOperationOutcome.ReturnedResourceList[0].IsDeleted)
      {
        if (RequestMeta.RequestHeader != null &&
          (!string.IsNullOrWhiteSpace(RequestMeta.RequestHeader.IfNoneMatch) ||
          !string.IsNullOrWhiteSpace(RequestMeta.RequestHeader.IfModifiedSince)))
        {
          if (!HttpHeaderSupport.IsModifiedOrNoneMatch(RequestMeta.RequestHeader.IfNoneMatch,
            RequestMeta.RequestHeader.IfModifiedSince,
            DatabaseOperationOutcome.ReturnedResourceList[0].Version,
            DatabaseOperationOutcome.ReturnedResourceList[0].Received))
          {
            oServiceOperationOutcome.ResourceResult = null;
            oServiceOperationOutcome.FhirResourceId = DatabaseOperationOutcome.ReturnedResourceList[0].FhirId;
            oServiceOperationOutcome.LastModified = DatabaseOperationOutcome.ReturnedResourceList[0].Received;
            oServiceOperationOutcome.IsDeleted = DatabaseOperationOutcome.ReturnedResourceList[0].IsDeleted;
            oServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;
            oServiceOperationOutcome.ResourceVersionNumber = DatabaseOperationOutcome.ReturnedResourceList[0].Version;
            oServiceOperationOutcome.RequestUri = RequestMeta.PyroRequestUri.FhirRequestUri;
            oServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.NotModified;
            return oServiceOperationOutcome;
          }
        }
        
        oServiceOperationOutcome.ResourceResult = FhirResourceSerializationSupport.DeSerializeFromGZip(DatabaseOperationOutcome.ReturnedResourceList[0].Resource);
        oServiceOperationOutcome.FhirResourceId = DatabaseOperationOutcome.ReturnedResourceList[0].FhirId;
        oServiceOperationOutcome.LastModified = DatabaseOperationOutcome.ReturnedResourceList[0].Received;
        oServiceOperationOutcome.IsDeleted = DatabaseOperationOutcome.ReturnedResourceList[0].IsDeleted;
        oServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;
        oServiceOperationOutcome.ResourceVersionNumber = DatabaseOperationOutcome.ReturnedResourceList[0].Version;
        oServiceOperationOutcome.RequestUri = RequestMeta.PyroRequestUri.FhirRequestUri;
        oServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;
      }
      else if (DatabaseOperationOutcome.ReturnedResourceList.Count == 1 && DatabaseOperationOutcome.ReturnedResourceList[0].IsDeleted)
      {
        oServiceOperationOutcome.ResourceResult = null;
        oServiceOperationOutcome.FhirResourceId = DatabaseOperationOutcome.ReturnedResourceList[0].FhirId;
        oServiceOperationOutcome.LastModified = DatabaseOperationOutcome.ReturnedResourceList[0].Received;
        oServiceOperationOutcome.IsDeleted = DatabaseOperationOutcome.ReturnedResourceList[0].IsDeleted;
        oServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;
        oServiceOperationOutcome.ResourceVersionNumber = DatabaseOperationOutcome.ReturnedResourceList[0].Version;
        oServiceOperationOutcome.RequestUri = RequestMeta.PyroRequestUri.FhirRequestUri;
        oServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.Gone;
      }
      else
      {
        oServiceOperationOutcome.ResourceResult = null;
        oServiceOperationOutcome.FhirResourceId = null;
        oServiceOperationOutcome.LastModified = null;
        oServiceOperationOutcome.IsDeleted = null;
        oServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;
        oServiceOperationOutcome.ResourceVersionNumber = null;
        oServiceOperationOutcome.RequestUri = RequestMeta.PyroRequestUri.FhirRequestUri;
        oServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.NotFound;
      }

      oServiceOperationOutcome.SuccessfulTransaction = true;
      return oServiceOperationOutcome;
    }

    // GET by Search
    // GET: URL//FhirApi/Patient?family=Smith&given=John            
    public virtual IResourceServiceOutcome GetSearch(IRequestMeta RequestMeta)
    {
      if (RequestMeta == null)
        throw new NullReferenceException("RequestMeta can not be null.");
      if (RequestMeta.PyroRequestUri == null)
        throw new NullReferenceException("DtoFhirRequestUri can not be null.");
      if (RequestMeta.PyroRequestUri.FhirRequestUri == null)
        throw new NullReferenceException("FhirRequestUri can not be null.");
      if (RequestMeta.PyroRequestUri.FhirRequestUri.ResourceType.HasValue == false)
        throw new NullReferenceException("FhirRequestUri.ResourceType can not be null.");
      if (RequestMeta.SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric can not be null.");
      if (RequestMeta.RequestHeader == null)
        throw new NullReferenceException("RequestHeaders can not be null.");

      SetCurrentResourceType(RequestMeta.PyroRequestUri.FhirRequestUri.ResourceType.Value);

      IResourceServiceOutcome oServiceOperationOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
      oServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;

      // GET by Search
      // GET: URL//FhirApi/Patient?family=Smith&given=John           
      ISearchParameterService SearchService = ISearchParameterServiceFactory.CreateSearchParameterService();
      ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchService.ProcessSearchParameters(RequestMeta.SearchParameterGeneric, 
                                                                                                              SearchParameterService.SearchParameterServiceType.Base | 
                                                                                                              SearchParameterService.SearchParameterServiceType.Bundle | 
                                                                                                              SearchParameterService.SearchParameterServiceType.Resource, 
                                                                                                              ServiceResourceType, null);
      if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
      {
        oServiceOperationOutcome.ResourceResult = SearchParametersServiceOutcome.FhirOperationOutcome;
        oServiceOperationOutcome.HttpStatusCode = SearchParametersServiceOutcome.HttpStatusCode;
        oServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
        return oServiceOperationOutcome;
      }
      //If header Handling=strict then return search parameter errors if there are any
      if (RequestMeta.RequestHeader.Prefer != null && RequestMeta.RequestHeader.Prefer.IsHandlingStrict && SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList.Count > 0)
      {
        oServiceOperationOutcome.ResourceResult = SearchParametersServiceOutcome.FhirOperationOutcomeUnsupportedParameters;
        oServiceOperationOutcome.HttpStatusCode = HttpStatusCode.Forbidden;
        oServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
        return oServiceOperationOutcome;
      }

      //Is this where we check SMART on FHIR scopes, if FHIRApiAuthentication = false this returns OK?
      ISmartScopeOutcome SmartScopeOutcome = ISmartScopeService.ProcessScopes(SearchParametersServiceOutcome.SearchParameters, ServiceResourceType, true, false);
      if (!SmartScopeOutcome.ScopesOK)
      {
        oServiceOperationOutcome.ResourceResult = SmartScopeOutcome.OperationOutcome;
        oServiceOperationOutcome.HttpStatusCode = HttpStatusCode.Forbidden;
        oServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
        return oServiceOperationOutcome;
      }

      //Must get the SelfLink here because GetResourcesBySearch can call the database and in there SearchParametersServiceOutcome is modified
      //as the all resource search parameters e.g _id, _lastModified are removed from the list.      
      Uri SelfLink = IPagingSupport.GetSelfLink(SearchParametersServiceOutcome.SearchParameters, RequestMeta.PyroRequestUri.FhirRequestUri.UriPrimaryServiceRoot.OriginalString);

      IDatabaseOperationOutcome DatabaseOperationOutcome = GetResourcesBySearch(SearchParametersServiceOutcome.SearchParameters);      
      oServiceOperationOutcome.ResourceResult = Common.Tools.Bundles.FhirBundleSupport.CreateBundle(DatabaseOperationOutcome.ReturnedResourceList,
                                                                                                    Bundle.BundleType.Searchset,
                                                                                                    RequestMeta.PyroRequestUri,
                                                                                                    DatabaseOperationOutcome.SearchTotal,
                                                                                                    DatabaseOperationOutcome.PagesTotal,
                                                                                                    DatabaseOperationOutcome.PageRequested,
                                                                                                    IPagingSupport,
                                                                                                    SelfLink);
      
      oServiceOperationOutcome.FhirResourceId = string.Empty;
      oServiceOperationOutcome.LastModified = null;
      oServiceOperationOutcome.IsDeleted = null;
      oServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;
      oServiceOperationOutcome.ResourceVersionNumber = string.Empty;
      oServiceOperationOutcome.RequestUri = RequestMeta.PyroRequestUri.FhirRequestUri;
      oServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
      oServiceOperationOutcome.HttpStatusCode = HttpStatusCode.OK;

      oServiceOperationOutcome.SuccessfulTransaction = true;
      return oServiceOperationOutcome;
    }

    // GET by Compartment Search
    // GET: URL/FhirApi/Patient/123456/Observation?code=http://loinc.org|LA20343-2          
    public virtual IResourceServiceOutcome GetCompartmentSearch(IRequestMeta RequestMeta, string Compartment, string CompartmentId, string ResourceName)
    {
      if (RequestMeta == null)
        throw new NullReferenceException("RequestMeta can not be null.");
      if (RequestMeta.PyroRequestUri == null)
        throw new NullReferenceException("DtoFhirRequestUri can not be null.");
      if (RequestMeta.PyroRequestUri.FhirRequestUri == null)
        throw new NullReferenceException("FhirRequestUri can not be null.");
      if (RequestMeta.PyroRequestUri.FhirRequestUri.ResourceType.HasValue == false)
        throw new NullReferenceException("FhirRequestUri.ResourceType can not be null.");
      if (RequestMeta.SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric can not be null.");
      if (RequestMeta.RequestHeader == null)
        throw new NullReferenceException("RequestHeaders can not be null.");
      if (string.IsNullOrWhiteSpace(Compartment))
        throw new NullReferenceException("Compartment can not be null.");
      if (string.IsNullOrWhiteSpace(CompartmentId))
        throw new NullReferenceException("id can not be null.");
      if (string.IsNullOrWhiteSpace(ResourceName))
        throw new NullReferenceException("ResourceName can not be null.");
      

      SetCurrentResourceType(ResourceNameResolutionSupport.GetResourceFhirAllType(ResourceName));

      //First get the search parameters from the originl request, we will add the Compartment search parameters afterwards
      //e.g (subject:Patient=Patient/123456 or patient:Patient=Patient/123456)
      IResourceServiceOutcome oServiceOperationOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
      oServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;

      // GET by Search
      // GET: URL//FhirApi/Patient?family=Smith&given=John           
      ISearchParameterService SearchService = ISearchParameterServiceFactory.CreateSearchParameterService();
      ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchService.ProcessSearchParameters(RequestMeta.SearchParameterGeneric, SearchParameterService.SearchParameterServiceType.Base | SearchParameterService.SearchParameterServiceType.Bundle | SearchParameterService.SearchParameterServiceType.Resource, ServiceResourceType, null);
      if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
      {
        oServiceOperationOutcome.ResourceResult = SearchParametersServiceOutcome.FhirOperationOutcome;
        oServiceOperationOutcome.HttpStatusCode = SearchParametersServiceOutcome.HttpStatusCode;
        oServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
        return oServiceOperationOutcome;
      }
      //If header Handling=strict then return search parameter errors if there are any
      if (RequestMeta.RequestHeader.Prefer != null && RequestMeta.RequestHeader.Prefer.IsHandlingStrict && SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList.Count > 0)
      {
        oServiceOperationOutcome.ResourceResult = SearchParametersServiceOutcome.FhirOperationOutcomeUnsupportedParameters;
        oServiceOperationOutcome.HttpStatusCode = HttpStatusCode.Forbidden;
        oServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
        return oServiceOperationOutcome;
      }

      //Now to contruct the Container search parameters, these are cached from the database Conatiner Resource      
      PyroSearchParameters CompartmentSearchParameters = ICompartmentSearchParameterService.GetSearchParameters(Compartment, CompartmentId, ResourceName);

      //Must get the SelfLink here because GetResourcesBySearch can call the database and in there SearchParametersServiceOutcome is modified
      //as the all resource search parameters e.g _id, _lastModified are removed from the list.      
      Uri SelfLink = IPagingSupport.GetSelfLink(SearchParametersServiceOutcome.SearchParameters, RequestMeta.PyroRequestUri.FhirRequestUri.UriPrimaryServiceRoot.OriginalString, Compartment, CompartmentId);

      IDatabaseOperationOutcome DatabaseOperationOutcome = GetResourcesByCompartmentSearch(CompartmentSearchParameters, SearchParametersServiceOutcome.SearchParameters, Compartment, CompartmentId);      
      oServiceOperationOutcome.ResourceResult = Common.Tools.Bundles.FhirBundleSupport.CreateBundle(DatabaseOperationOutcome.ReturnedResourceList,
                                                                                                    Bundle.BundleType.Searchset,
                                                                                                    RequestMeta.PyroRequestUri,
                                                                                                    DatabaseOperationOutcome.SearchTotal,
                                                                                                    DatabaseOperationOutcome.PagesTotal,
                                                                                                    DatabaseOperationOutcome.PageRequested,
                                                                                                    IPagingSupport,
                                                                                                    SelfLink);     

      oServiceOperationOutcome.FhirResourceId = string.Empty;
      oServiceOperationOutcome.LastModified = null;
      oServiceOperationOutcome.IsDeleted = null;
      oServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;
      oServiceOperationOutcome.ResourceVersionNumber = string.Empty;
      oServiceOperationOutcome.RequestUri = RequestMeta.PyroRequestUri.FhirRequestUri;
      oServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
      oServiceOperationOutcome.HttpStatusCode = HttpStatusCode.OK;

      oServiceOperationOutcome.SuccessfulTransaction = true;
      return oServiceOperationOutcome;
    }

    // GET All history for Id
    // GET URL/FhirApi/Patient/5/_history
    //Read all history
    public virtual IResourceServiceOutcome GetHistory(string ResourceId, string VersionId, IRequestMeta RequestMeta)
    {
      if (string.IsNullOrEmpty(ResourceId))
        throw new NullReferenceException("ResourceId can not be null or empty string.");
      //VersionId can be null
      if (RequestMeta == null)
        throw new NullReferenceException("RequestMeta can not be null.");
      if (RequestMeta.PyroRequestUri == null)
        throw new NullReferenceException("DtoFhirRequestUri can not be null.");
      if (RequestMeta.PyroRequestUri.FhirRequestUri == null)
        throw new NullReferenceException("FhirRequestUri can not be null.");
      if (RequestMeta.PyroRequestUri.FhirRequestUri.ResourceType.HasValue == false)
        throw new NullReferenceException("FhirRequestUri.ResourceType can not be null.");
      if (RequestMeta.SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric can not be null.");
      //Note that RequestHeaders are not required for this call but sent for consistancy

      SetCurrentResourceType(RequestMeta.PyroRequestUri.FhirRequestUri.ResourceType.Value);

      IResourceServiceOutcome oServiceOperationOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
      oServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;

      if (string.IsNullOrWhiteSpace(VersionId))
      {
        // GET All history for Id
        // GET URL/FhirApi/Patient/5/_history
        //Read all history
        ISearchParameterService SearchService = ISearchParameterServiceFactory.CreateSearchParameterService();
        ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchService.ProcessBundleSearchParameters(RequestMeta.SearchParameterGeneric);
        oServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;

        if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
        {
          oServiceOperationOutcome.ResourceResult = SearchParametersServiceOutcome.FhirOperationOutcome;
          oServiceOperationOutcome.HttpStatusCode = SearchParametersServiceOutcome.HttpStatusCode;
          oServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
          return oServiceOperationOutcome;
        }

        GetResourceHistoryInFull(ResourceId, RequestMeta.PyroRequestUri, SearchParametersServiceOutcome, oServiceOperationOutcome);

        oServiceOperationOutcome.SuccessfulTransaction = true;
        return oServiceOperationOutcome;
      }
      else
      {
        // GET by FhirId and FhirVId
        // GET URL/FhirApi/Patient/5/_history/2   
        ISearchParameterService SearchService = ISearchParameterServiceFactory.CreateSearchParameterService();
        ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchService.ProcessBaseSearchParameters(RequestMeta.SearchParameterGeneric);

        if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
        {
          oServiceOperationOutcome.ResourceResult = SearchParametersServiceOutcome.FhirOperationOutcome;
          oServiceOperationOutcome.HttpStatusCode = SearchParametersServiceOutcome.HttpStatusCode;
          oServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
          return oServiceOperationOutcome;
        }
        oServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;

        GetResourceHistoryInstance(ResourceId, VersionId, RequestMeta.PyroRequestUri, oServiceOperationOutcome);

        oServiceOperationOutcome.SuccessfulTransaction = true;
        return oServiceOperationOutcome;
      }
    }

    // Add (POST)
    // POST: URL/FhirApi/Patient
    public virtual IResourceServiceOutcome Post(Resource Resource, IRequestMeta RequestMeta, string ForceId = "")
    {
      if (RequestMeta == null)
        throw new NullReferenceException("RequestMeta can not be null.");
      if (RequestMeta.PyroRequestUri == null)
        throw new NullReferenceException("DtoFhirRequestUri can not be null.");
      if (RequestMeta.PyroRequestUri.FhirRequestUri == null)
        throw new NullReferenceException("FhirRequestUri can not be null.");
      if (RequestMeta.PyroRequestUri.FhirRequestUri.ResourceType.HasValue == false)
        throw new NullReferenceException("FhirRequestUri.ResourceType can not be null.");
      if (RequestMeta.SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric can not be null.");
      //Note that RequestHeaders are not required for this call but sent for consistancy

      SetCurrentResourceType(RequestMeta.PyroRequestUri.FhirRequestUri.ResourceType.Value);

      if (!ResourceProvidedMatchesEndpointItWasProvidedOn(RequestMeta.PyroRequestUri, Resource.ResourceType))
        throw new FormatException($"Attempting to POST a Resource of type {Resource.ResourceType.GetLiteral()} on an endpoint for Resource Type {RequestMeta.PyroRequestUri.FhirRequestUri.ResourseName}, this is not allowed.");


      if (!string.IsNullOrWhiteSpace(ForceId))
      {
        //The id must be a valid GUID and is later validated as one.
        if (!Common.Tools.FhirGuid.FhirGuid.IsFhirGuid(ForceId))
        {
          throw new FormatException($"The 'ForceId' used by the server in a POST (add) request must be a valid GUID. Value given was: {ForceId}");
        }
      }

      IResourceServiceOutcome oServiceOperationOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();

      ISearchParameterService SearchService = ISearchParameterServiceFactory.CreateSearchParameterService();
      ISearchParametersServiceOutcome SearchParametersServiceOutcomeBase = SearchService.ProcessBaseSearchParameters(RequestMeta.SearchParameterGeneric);

      if (SearchParametersServiceOutcomeBase.FhirOperationOutcome != null)
      {
        oServiceOperationOutcome.ResourceResult = SearchParametersServiceOutcomeBase.FhirOperationOutcome;
        oServiceOperationOutcome.HttpStatusCode = SearchParametersServiceOutcomeBase.HttpStatusCode;
        oServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcomeBase.SearchParameters.Format;
        return oServiceOperationOutcome;
      }

      //If header Handling=strict then return search parameter errors if there are any
      if (RequestMeta.RequestHeader.Prefer != null && RequestMeta.RequestHeader.Prefer.IsHandlingStrict && SearchParametersServiceOutcomeBase.SearchParameters.UnspportedSearchParameterList.Count > 0)
      {
        oServiceOperationOutcome.ResourceResult = SearchParametersServiceOutcomeBase.FhirOperationOutcomeUnsupportedParameters;
        oServiceOperationOutcome.HttpStatusCode = HttpStatusCode.Forbidden;
        oServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcomeBase.SearchParameters.Format;
        return oServiceOperationOutcome;
      }

      if ((RequestMeta.RequestHeader != null) && (!string.IsNullOrWhiteSpace(RequestMeta.RequestHeader.IfNoneExist)))
      {
        ISearchParameterGeneric SearchParameterGenericIfNoneExist = ISearchParameterGenericFactory.CreateDtoSearchParameterGeneric().Parse(RequestMeta.RequestHeader.IfNoneExist);
        ISearchParameterService SearchServiceIfNoneExist = ISearchParameterServiceFactory.CreateSearchParameterService();
        ISearchParametersServiceOutcome SearchParametersServiceOutcomeIfNoneExist = SearchService.ProcessSearchParameters(SearchParameterGenericIfNoneExist, SearchParameterService.SearchParameterServiceType.Bundle | SearchParameterService.SearchParameterServiceType.Resource, ServiceResourceType, null);
        if (SearchParametersServiceOutcomeIfNoneExist.FhirOperationOutcome != null)
        {
          oServiceOperationOutcome.ResourceResult = SearchParametersServiceOutcomeIfNoneExist.FhirOperationOutcome;
          oServiceOperationOutcome.HttpStatusCode = SearchParametersServiceOutcomeIfNoneExist.HttpStatusCode;
          oServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcomeIfNoneExist.SearchParameters.Format;
          return oServiceOperationOutcome;
        }

        IDatabaseOperationOutcome DatabaseOperationOutcomeIfNoneExist = IResourceRepository.GetResourceBySearch(SearchParametersServiceOutcomeIfNoneExist.SearchParameters, false);
        if (DatabaseOperationOutcomeIfNoneExist.SearchTotal == 1)
        {
          //From FHIR Specification: One Match: The server ignore the post and returns 200 OK          
          oServiceOperationOutcome.ResourceResult = null;
          oServiceOperationOutcome.FhirResourceId = DatabaseOperationOutcomeIfNoneExist.ReturnedResourceList[0].FhirId;
          oServiceOperationOutcome.LastModified = DatabaseOperationOutcomeIfNoneExist.ReturnedResourceList[0].Received;
          oServiceOperationOutcome.IsDeleted = DatabaseOperationOutcomeIfNoneExist.ReturnedResourceList[0].IsDeleted;
          oServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Create;
          oServiceOperationOutcome.ResourceVersionNumber = DatabaseOperationOutcomeIfNoneExist.ReturnedResourceList[0].Version;
          oServiceOperationOutcome.RequestUri = RequestMeta.PyroRequestUri.FhirRequestUri;
          oServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcomeBase.SearchParameters.Format;
          oServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;
          oServiceOperationOutcome.SuccessfulTransaction = true;
          return oServiceOperationOutcome;
        }
        else if (DatabaseOperationOutcomeIfNoneExist.SearchTotal > 1)
        {
          //From FHIR Specification: Multiple matches: The server returns a 412 Precondition Failed error 
          //                         indicating the client's criteria were not selective enough
          oServiceOperationOutcome.ResourceResult = null;
          oServiceOperationOutcome.FhirResourceId = string.Empty;
          oServiceOperationOutcome.LastModified = null;
          oServiceOperationOutcome.IsDeleted = null;
          oServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Create;
          oServiceOperationOutcome.ResourceVersionNumber = string.Empty;
          oServiceOperationOutcome.RequestUri = RequestMeta.PyroRequestUri.FhirRequestUri;
          oServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcomeBase.SearchParameters.Format;
          oServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.PreconditionFailed;
          oServiceOperationOutcome.SuccessfulTransaction = false;
          return oServiceOperationOutcome;
        }
      }

      if (!string.IsNullOrWhiteSpace(Resource.Id))
      {
        string Message = string.Format("The create (POST) interaction creates a new resource in a server-assigned location. If the client wishes to have control over the id of a newly submitted resource, it should use the update interaction instead. The Resource provide was found to contain the id: {0}", Resource.Id);
        oServiceOperationOutcome.ResourceResult = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Required, Message, new List<string>() { "Resource.Id" });
        oServiceOperationOutcome.HttpStatusCode = HttpStatusCode.BadRequest;
        oServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcomeBase.SearchParameters.Format;
        return oServiceOperationOutcome;
      }
      //BatchTransaction Operation need to pre assign the id GUID inorder to update referances in the batch
      //That id is then passed into 'ForceId' and is then used for the POST (add), must always be a GUID
      if (!string.IsNullOrWhiteSpace(ForceId))
      {
        Resource.Id = ForceId;
      }
      //All good commit the resource.
      oServiceOperationOutcome = SetResource(Resource, RequestMeta.PyroRequestUri, RestEnum.CrudOperationType.Create);
      oServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcomeBase.SearchParameters.Format;
      oServiceOperationOutcome.SuccessfulTransaction = true;
      return oServiceOperationOutcome;
    }

    //Update (PUT)
    // PUT: URL/FhirApi/Patient/5
    public virtual IResourceServiceOutcome Put(string ResourceId, Resource Resource, IRequestMeta RequestMeta)
    {
      if (string.IsNullOrWhiteSpace(ResourceId))
        throw new NullReferenceException("ResourceId can not be null or empty.");
      if (Resource == null)
        throw new NullReferenceException("Resource can not be null.");
      if (RequestMeta == null)
        throw new NullReferenceException("RequestMeta can not be null.");
      if (RequestMeta.PyroRequestUri == null)
        throw new NullReferenceException("DtoFhirRequestUri can not be null.");
      if (RequestMeta.PyroRequestUri.FhirRequestUri == null)
        throw new NullReferenceException("FhirRequestUri can not be null.");
      if (RequestMeta.PyroRequestUri.FhirRequestUri.ResourceType.HasValue == false)
        throw new NullReferenceException("FhirRequestUri.ResourceType can not be null.");
      if (RequestMeta.RequestHeader == null)
        throw new NullReferenceException("RequestHeaders can not be null.");
      if (!ResourceProvidedMatchesEndpointItWasProvidedOn(RequestMeta.PyroRequestUri, Resource.ResourceType))
        throw new FormatException($"Attempting to PUT a Resource of type {Resource.ResourceType.GetLiteral()} on an endpoint for Resource Type {RequestMeta.PyroRequestUri.FhirRequestUri.ResourseName}, this is not allowed.");

      SetCurrentResourceType(RequestMeta.PyroRequestUri.FhirRequestUri.ResourceType.Value);

      IResourceServiceOutcome oServiceOperationOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();

      ISearchParameterService SearchService = ISearchParameterServiceFactory.CreateSearchParameterService();
      ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchService.ProcessBaseSearchParameters(RequestMeta.SearchParameterGeneric);
      if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
      {
        oServiceOperationOutcome.ResourceResult = SearchParametersServiceOutcome.FhirOperationOutcome;
        oServiceOperationOutcome.HttpStatusCode = SearchParametersServiceOutcome.HttpStatusCode;
        oServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
        return oServiceOperationOutcome;
      }

      if (string.IsNullOrWhiteSpace(Resource.Id) || Resource.Id != ResourceId)
      {
        string Message = String.Format("The Resource SHALL contain an id element that has an identical value to the [id] in the URL. The id in the resource was: '{0}' and the [id] in the URL was: '{1}'", Resource.Id, ResourceId);
        oServiceOperationOutcome.ResourceResult = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Required, Message);
        oServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        return oServiceOperationOutcome;
      }

      //Create Resource's Meta element if not found and update its last updated property to now
      if (Resource.Meta == null)
      {
        Resource.Meta = new Meta();
      }

      //Check db for existence of this Resource 
      IDatabaseOperationOutcome DatabaseOperationOutcomeGet = IResourceRepository.GetResourceByFhirID(ResourceId);

      if (DatabaseOperationOutcomeGet.ReturnedResourceList != null && DatabaseOperationOutcomeGet.ReturnedResourceList.Count == 1)
      {

        if (!string.IsNullOrWhiteSpace(RequestMeta.RequestHeader.IfMatch) &&
          (HttpHeaderSupport.GetETagValueFromETagString(RequestMeta.RequestHeader.IfMatch) != DatabaseOperationOutcomeGet.ReturnedResourceList[0].Version))
        {
          string Message = $"Version aware update conflict error. HTTP Header 'If-Match' used. The version intended to be updated was: '{HttpHeaderSupport.GetETagValueFromETagString(RequestMeta.RequestHeader.IfMatch)}' the current version found on the server was: '{DatabaseOperationOutcomeGet.ReturnedResourceList[0].Version}'.";
          oServiceOperationOutcome.ResourceResult = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Conflict, Message);
          oServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Update;
          oServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.Conflict;
          return oServiceOperationOutcome;
        }
        else
        {
          //The resource has been found, and if provided If-match matched, so update its version number based on the older resource              
          Resource.Meta.VersionId = Common.Tools.ResourceVersionNumber.Increment(DatabaseOperationOutcomeGet.ReturnedResourceList[0].Version);

          oServiceOperationOutcome = SetResource(Resource, RequestMeta.PyroRequestUri, RestEnum.CrudOperationType.Update);
          oServiceOperationOutcome.SuccessfulTransaction = true;
          //If the found resource is IsDeleted = true then need to return Status = 201 (Created) after 
          //performing to update, not 201 (OK)
          if (DatabaseOperationOutcomeGet.ReturnedResourceList[0].IsDeleted)
          {
            oServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.Created;
          }
        }
      }
      else if (DatabaseOperationOutcomeGet.ReturnedResourceList != null && DatabaseOperationOutcomeGet.ReturnedResourceList.Count == 0)
      {
        if (!string.IsNullOrWhiteSpace(RequestMeta.RequestHeader.IfMatch))
        {
          string Message = $"Version aware update conflict. HTTP Header 'If-Match: {RequestMeta.RequestHeader.IfMatch}' used, and no previous resource can be found in the server.";
          oServiceOperationOutcome.ResourceResult = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Conflict, Message);
          oServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.Conflict;
          oServiceOperationOutcome.SuccessfulTransaction = false;
          return oServiceOperationOutcome;
        }
        else
        {
          //This is a new resource so update its version number as 1 and create
          Resource.Meta.VersionId = Common.Tools.ResourceVersionNumber.FirstVersion();
          oServiceOperationOutcome = SetResource(Resource, RequestMeta.PyroRequestUri, RestEnum.CrudOperationType.Create);
          oServiceOperationOutcome.SuccessfulTransaction = true;
        }
      }

      oServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
      return oServiceOperationOutcome;
    }

    //Delete
    // DELETE: URL/FhirApi/Patient/5
    public virtual IResourceServiceOutcome Delete(string ResourceId, IRequestMeta RequestMeta)
    {
      if (string.IsNullOrWhiteSpace(ResourceId))
        throw new NullReferenceException("ResourceId can not be null or empty.");
      if (RequestMeta == null)
        throw new NullReferenceException("RequestMeta can not be null.");
      if (RequestMeta.PyroRequestUri == null)
        throw new NullReferenceException("DtoFhirRequestUri can not be null.");
      if (RequestMeta.PyroRequestUri.FhirRequestUri == null)
        throw new NullReferenceException("FhirRequestUri can not be null.");
      if (RequestMeta.PyroRequestUri.FhirRequestUri.ResourceType.HasValue == false)
        throw new NullReferenceException("FhirRequestUri.ResourceType can not be null.");
      if (RequestMeta.SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric can not be null.");
      //Note that RequestHeaders are not required for this call but sent for consistancy

      SetCurrentResourceType(RequestMeta.PyroRequestUri.FhirRequestUri.ResourceType.Value);

      IResourceServiceOutcome oServiceOperationOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();

      ISearchParameterService SearchService = ISearchParameterServiceFactory.CreateSearchParameterService();
      ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchService.ProcessBaseSearchParameters(RequestMeta.SearchParameterGeneric);
      if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
      {
        oServiceOperationOutcome.ResourceResult = SearchParametersServiceOutcome.FhirOperationOutcome;
        oServiceOperationOutcome.HttpStatusCode = SearchParametersServiceOutcome.HttpStatusCode;
        oServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
        oServiceOperationOutcome.SuccessfulTransaction = false;
        return oServiceOperationOutcome;
      }
      else
      {
        oServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
      }

      IDatabaseOperationOutcome DatabaseOperationOutcomeGet = IResourceRepository.GetResourceByFhirID(ResourceId, false);
      if (DatabaseOperationOutcomeGet.ReturnedResourceList.Count == 1 &&
        DatabaseOperationOutcomeGet.ReturnedResourceList[0].IsDeleted)
      {
        // The resource exists yet is already deleted, 
        //need to return the details about it but not the xml content 
        oServiceOperationOutcome.ResourceResult = null;
        oServiceOperationOutcome.FhirResourceId = ResourceId;
        oServiceOperationOutcome.LastModified = DatabaseOperationOutcomeGet.ReturnedResourceList[0].Received;
        oServiceOperationOutcome.IsDeleted = DatabaseOperationOutcomeGet.ReturnedResourceList[0].IsDeleted;
        oServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Delete;
        oServiceOperationOutcome.ResourceVersionNumber = DatabaseOperationOutcomeGet.ReturnedResourceList[0].Version;
        oServiceOperationOutcome.RequestUri = null;
        oServiceOperationOutcome.SuccessfulTransaction = true;
        oServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.NoContent;
        return oServiceOperationOutcome;
      }
      else
      {
        //There is one that is not already deleted or there is none
        //Either case calling the CommitResourceCollectionAsDeleted will return the correct result. 
        ICollection<string> ResourceIdsToBeDeleted = DatabaseOperationOutcomeGet.ReturnedResourceList.Where(x => x.IsDeleted == false).Select(x => x.FhirId).ToArray();
        oServiceOperationOutcome = SetResourceCollectionAsDeleted(ResourceIdsToBeDeleted);
        return oServiceOperationOutcome;
      }           
    }

    //ConditionalUpdate (PUT)
    //DELETE: URL/FhirApi/Patient?identifier=12345&family=millar&given=angus 
    public virtual IResourceServiceOutcome ConditionalPut(Resource Resource, IRequestMeta RequestMeta)
    {
      if (Resource == null)
        throw new NullReferenceException("Resource can not be null.");
      if (RequestMeta == null)
        throw new NullReferenceException("RequestMeta can not be null.");
      if (RequestMeta.PyroRequestUri == null)
        throw new NullReferenceException("DtoFhirRequestUri can not be null.");
      if (RequestMeta.PyroRequestUri.FhirRequestUri == null)
        throw new NullReferenceException("FhirRequestUri can not be null.");
      if (RequestMeta.PyroRequestUri.FhirRequestUri.ResourceType.HasValue == false)
        throw new NullReferenceException("FhirRequestUri.ResourceType can not be null.");
      if (RequestMeta.SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGenericcan not be null.");
      if (!ResourceProvidedMatchesEndpointItWasProvidedOn(RequestMeta.PyroRequestUri, Resource.ResourceType))
        throw new FormatException($"Attempting to PUT a Resource of type {Resource.ResourceType.GetLiteral()} on an endpoint for Resource Type {RequestMeta.PyroRequestUri.FhirRequestUri.ResourseName}, this is not allowed.");
      if (RequestMeta.RequestHeader == null)
        throw new NullReferenceException("RequestHeaders can not be null.");

      SetCurrentResourceType(RequestMeta.PyroRequestUri.FhirRequestUri.ResourceType.Value);

      IResourceServiceOutcome ServiceOperationOutcomeConditionalPut = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
      // GET: URL//FhirApi/Patient?family=Smith&given=John                        

      ISearchParameterService SearchService = ISearchParameterServiceFactory.CreateSearchParameterService();
      ISearchParametersServiceOutcome SearchParametersServiceOutcomeAll = SearchService.ProcessResourceSearchParameters(RequestMeta.SearchParameterGeneric, SearchParameterService.SearchParameterServiceType.Base | SearchParameterService.SearchParameterServiceType.Resource, ServiceResourceType);
      if (SearchParametersServiceOutcomeAll.FhirOperationOutcome != null)
      {
        ServiceOperationOutcomeConditionalPut.ResourceResult = SearchParametersServiceOutcomeAll.FhirOperationOutcome;
        ServiceOperationOutcomeConditionalPut.HttpStatusCode = SearchParametersServiceOutcomeAll.HttpStatusCode;
        ServiceOperationOutcomeConditionalPut.FormatMimeType = SearchParametersServiceOutcomeAll.SearchParameters.Format;
        ServiceOperationOutcomeConditionalPut.SuccessfulTransaction = false;
        return ServiceOperationOutcomeConditionalPut;
      }
      else
      {
        ServiceOperationOutcomeConditionalPut.FormatMimeType = SearchParametersServiceOutcomeAll.SearchParameters.Format;
      }

      //If header Handling=strict then return search parameter errors if there are any
      if (RequestMeta.RequestHeader.Prefer != null && RequestMeta.RequestHeader.Prefer.IsHandlingStrict && SearchParametersServiceOutcomeAll.SearchParameters.UnspportedSearchParameterList.Count > 0)
      {
        ServiceOperationOutcomeConditionalPut.ResourceResult = SearchParametersServiceOutcomeAll.FhirOperationOutcomeUnsupportedParameters;
        ServiceOperationOutcomeConditionalPut.HttpStatusCode = HttpStatusCode.Forbidden;        
        ServiceOperationOutcomeConditionalPut.SuccessfulTransaction = false;
        return ServiceOperationOutcomeConditionalPut;
      }

      ServiceOperationOutcomeConditionalPut.FormatMimeType = SearchParametersServiceOutcomeAll.SearchParameters.Format;

      IDatabaseOperationOutcome DatabaseOperationOutcomeSearch = IResourceRepository.GetResourceBySearch(SearchParametersServiceOutcomeAll.SearchParameters, false);
      if (DatabaseOperationOutcomeSearch.ReturnedResourceList.Count == 0)
      {
        //No resource found so do a normal Create, first clear any Resource Id that may 
        //be in the resource
        Resource.Id = string.Empty;
        ServiceOperationOutcomeConditionalPut = this.Post(Resource, RequestMeta, null);        
        //Don't set to true below as the POST above will set the bool based on it's own result
        //oServiceOperationOutcome.SuccessfulTransaction = true;
        return ServiceOperationOutcomeConditionalPut;
      }
      else if (DatabaseOperationOutcomeSearch.ReturnedResourceList.Count == 1)
      {
        if (!string.IsNullOrWhiteSpace(Resource.Id))
        {
          if (DatabaseOperationOutcomeSearch.ReturnedResourceList[0].FhirId != Resource.Id)
          {
            string Message = "The single Resource located by the conditional PUT search has a different Resource Id to that which was found in the Resource given. Either, remove the Id from the Resource given or re-evaluate the search parameters.";
            ServiceOperationOutcomeConditionalPut.ResourceResult = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.BusinessRule, Message);
            ServiceOperationOutcomeConditionalPut.HttpStatusCode = HttpStatusCode.BadRequest;            
            ServiceOperationOutcomeConditionalPut.SuccessfulTransaction = false;
            return ServiceOperationOutcomeConditionalPut;
          }
        }
        else
        {
          Resource.Id = DatabaseOperationOutcomeSearch.ReturnedResourceList[0].FhirId;
        }

        //Create Resource's Meta element if not found and update its last updated property to now
        if (Resource.Meta == null)
          Resource.Meta = new Meta();

        //A database resource has been found so update the new resource's version number based on the older resource              
        Resource.Meta.VersionId = Common.Tools.ResourceVersionNumber.Increment(DatabaseOperationOutcomeSearch.ReturnedResourceList[0].Version);
        ServiceOperationOutcomeConditionalPut = SetResource(Resource, RequestMeta.PyroRequestUri, RestEnum.CrudOperationType.Update);
        ServiceOperationOutcomeConditionalPut.SuccessfulTransaction = true;        
        return ServiceOperationOutcomeConditionalPut;
      }
      else
      {
        //more than one returned so PreconditionFailed.        
        ServiceOperationOutcomeConditionalPut.ResourceResult = null;
        ServiceOperationOutcomeConditionalPut.FhirResourceId = null;
        ServiceOperationOutcomeConditionalPut.LastModified = null;
        ServiceOperationOutcomeConditionalPut.IsDeleted = true;
        ServiceOperationOutcomeConditionalPut.OperationType = RestEnum.CrudOperationType.Update;
        ServiceOperationOutcomeConditionalPut.ResourceVersionNumber = null;
        ServiceOperationOutcomeConditionalPut.RequestUri = null;        
        ServiceOperationOutcomeConditionalPut.HttpStatusCode = System.Net.HttpStatusCode.PreconditionFailed;
        ServiceOperationOutcomeConditionalPut.SuccessfulTransaction = false;
        return ServiceOperationOutcomeConditionalPut;
      }
    }

    //ConditionalDelete (Delete)
    //DELETE: URL/FhirApi/Patient?identifier=12345&family=millar&given=angus 
    public virtual IResourceServiceOutcome ConditionalDelete(IRequestMeta RequestMeta)
    {
      if (RequestMeta == null)
        throw new NullReferenceException("RequestMeta can not be null.");
      if (RequestMeta.PyroRequestUri == null)
        throw new NullReferenceException("DtoFhirRequestUri can not be null.");
      if (RequestMeta.PyroRequestUri.FhirRequestUri == null)
        throw new NullReferenceException("FhirRequestUri can not be null.");
      if (RequestMeta.PyroRequestUri.FhirRequestUri.ResourceType.HasValue == false)
        throw new NullReferenceException("FhirRequestUri.ResourceType can not be null.");
      if (RequestMeta.SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGenericcan not be null.");
      if (RequestMeta.RequestHeader == null)
        throw new NullReferenceException("RequestHeader not be null.");

      SetCurrentResourceType(RequestMeta.PyroRequestUri.FhirRequestUri.ResourceType.Value);

      IResourceServiceOutcome ServiceOperationOutcomeConditionalDelete = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
      // GET: URL//FhirApi/Patient?family=Smith&given=John          

      ISearchParameterService SearchServiceBase = ISearchParameterServiceFactory.CreateSearchParameterService();
      ISearchParametersServiceOutcome SearchParametersServiceOutcomeBaseOnly = SearchServiceBase.ProcessBaseSearchParameters(RequestMeta.SearchParameterGeneric);

      ISearchParameterService SearchServiceAll = ISearchParameterServiceFactory.CreateSearchParameterService();
      ISearchParametersServiceOutcome SearchParametersServiceOutcomeAll = SearchServiceAll.ProcessResourceSearchParameters(RequestMeta.SearchParameterGeneric, SearchParameterService.SearchParameterServiceType.Base | SearchParameterService.SearchParameterServiceType.Resource, ServiceResourceType);

      //If any syntax errors in Search parameters
      if (SearchParametersServiceOutcomeAll.FhirOperationOutcome != null)
      {
        ServiceOperationOutcomeConditionalDelete.ResourceResult = SearchParametersServiceOutcomeAll.FhirOperationOutcome;
        ServiceOperationOutcomeConditionalDelete.HttpStatusCode = SearchParametersServiceOutcomeAll.HttpStatusCode;
        ServiceOperationOutcomeConditionalDelete.FormatMimeType = SearchParametersServiceOutcomeBaseOnly.SearchParameters.Format;
        ServiceOperationOutcomeConditionalDelete.SuccessfulTransaction = false;
        return ServiceOperationOutcomeConditionalDelete;
      }
      else
      {
        ServiceOperationOutcomeConditionalDelete.FormatMimeType = SearchParametersServiceOutcomeBaseOnly.SearchParameters.Format;
      }

      //If header Handling=strict then return search parameter errors if there are any
      if (RequestMeta.RequestHeader.Prefer != null && RequestMeta.RequestHeader.Prefer.IsHandlingStrict && SearchParametersServiceOutcomeAll.SearchParameters.UnspportedSearchParameterList.Count > 0)
      {
        ServiceOperationOutcomeConditionalDelete.ResourceResult = SearchParametersServiceOutcomeAll.FhirOperationOutcomeUnsupportedParameters;
        ServiceOperationOutcomeConditionalDelete.HttpStatusCode = HttpStatusCode.Forbidden;
        ServiceOperationOutcomeConditionalDelete.SuccessfulTransaction = false;
        return ServiceOperationOutcomeConditionalDelete;
      }

      if ((SearchParametersServiceOutcomeAll.SearchParameters.SearchParametersList.Count - SearchParametersServiceOutcomeBaseOnly.SearchParameters.SearchParametersList.Count) <= 0 ||
        SearchParametersServiceOutcomeAll.SearchParameters.UnspportedSearchParameterList.Count != 0)
      {
        string Message = string.Empty;
        if ((SearchParametersServiceOutcomeAll.SearchParameters.SearchParametersList.Count - SearchParametersServiceOutcomeBaseOnly.SearchParameters.SearchParametersList.Count) <= 0)
        {
          Message = String.Format($"The Conditional Delete operation requires at least one valid Resource search parameter in order to be performed.");
        }
        else if (SearchParametersServiceOutcomeAll.SearchParameters.UnspportedSearchParameterList.Count != 0)
        {
          string UnspportedSearchParameterMessage = string.Empty;
          foreach (var item in SearchParametersServiceOutcomeAll.SearchParameters.UnspportedSearchParameterList)
          {
            UnspportedSearchParameterMessage = UnspportedSearchParameterMessage + $"Parameter: {item.RawParameter}, Reason: {item.ReasonMessage};";
          }
          Message = String.Format($"The Conditional Delete operation requires that all Search parameters are understood. The following supplied  parameters were not understood: {UnspportedSearchParameterMessage}");
        }
        ServiceOperationOutcomeConditionalDelete.ResourceResult = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.BusinessRule, Message);
        ServiceOperationOutcomeConditionalDelete.HttpStatusCode = HttpStatusCode.PreconditionFailed;
        ServiceOperationOutcomeConditionalDelete.SuccessfulTransaction = false;
        return ServiceOperationOutcomeConditionalDelete;
      }

      IDatabaseOperationOutcome DatabaseOperationOutcomeSearch = IResourceRepository.GetResourceBySearch(SearchParametersServiceOutcomeAll.SearchParameters, false);

      //There are zero or many or one to be deleted, note that GetResourceBySearch never returns deleted resource.
      ICollection<string> ResourceIdsToBeDeleted = DatabaseOperationOutcomeSearch.ReturnedResourceList.Select(x => x.FhirId).ToArray();
      ServiceOperationOutcomeConditionalDelete = SetResourceCollectionAsDeleted(ResourceIdsToBeDeleted);            
      return ServiceOperationOutcomeConditionalDelete;
    }

    //This is the method to add/update new indexes
    public virtual void AddAndUpdateResourceIndexes(ResourceType ResourceType, List<DtoServiceSearchParameterLight> ServiceSearchParameterLightList)
    {
      if (ServiceSearchParameterLightList.Any(x => x.Resource != ResourceType.GetLiteral()))
        throw new ArgumentNullException("Internal Server Error: AddAndUpdateResourceIndexes must only be passed a list of ServiceSearchParameter which are all for the same ResourceType");
      SetCurrentResourceType(ResourceType);
      IResourceRepository.AddAndUpdateResourceIndexes(ServiceSearchParameterLightList);
    }

    public DateTimeOffset? GetLastCurrentResourceLastUpdatedValue(ResourceType ResourceType)
    {
      SetCurrentResourceType(ResourceType);
      return IResourceRepository.GetLastCurrentResourceLastUpdatedValue();
    }

    public int GetTotalCurrentResourceCount(ResourceType ResourceType)
    {
      SetCurrentResourceType(ResourceType);
      return IResourceRepository.GetTotalCurrentResourceCount();
    }

    // Private Methods ---------------------------------------------------------------------------------------------

    private IResourceServiceOutcome SetResourceCollectionAsDeleted(ICollection<string> ResourceIdCollection)
    {
      IResourceServiceOutcome oPyroServiceOperationOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
      if (ResourceIdCollection.Count == 1)
      {
        //Delete one resource that is not already deleted 
        IDatabaseOperationOutcome DatabaseOperationOutcomeDelete = IResourceRepository.UpdateResouceIdAsDeleted(ResourceIdCollection.First());

        if (DatabaseOperationOutcomeDelete.TriggerOutCome != null && DatabaseOperationOutcomeDelete.TriggerOutCome.Report)
        {          
          oPyroServiceOperationOutcome.ResourceResult = DatabaseOperationOutcomeDelete.TriggerOutCome.Resource;
          oPyroServiceOperationOutcome.FhirResourceId = null;
          oPyroServiceOperationOutcome.LastModified = null;
          oPyroServiceOperationOutcome.IsDeleted = null;
          oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Delete;
          oPyroServiceOperationOutcome.ResourceVersionNumber = null;
          oPyroServiceOperationOutcome.RequestUri = null;
          oPyroServiceOperationOutcome.HttpStatusCode = DatabaseOperationOutcomeDelete.TriggerOutCome.HttpStatusCode;
          oPyroServiceOperationOutcome.SuccessfulTransaction = false;
          return oPyroServiceOperationOutcome;
        }

        oPyroServiceOperationOutcome.ResourceResult = null;
        oPyroServiceOperationOutcome.FhirResourceId = DatabaseOperationOutcomeDelete.ReturnedResourceList[0].FhirId;
        oPyroServiceOperationOutcome.LastModified = DatabaseOperationOutcomeDelete.ReturnedResourceList[0].Received;
        oPyroServiceOperationOutcome.IsDeleted = DatabaseOperationOutcomeDelete.ReturnedResourceList[0].IsDeleted;
        oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Delete;
        oPyroServiceOperationOutcome.ResourceVersionNumber = DatabaseOperationOutcomeDelete.ReturnedResourceList[0].Version;
        oPyroServiceOperationOutcome.RequestUri = null;
        oPyroServiceOperationOutcome.FormatMimeType = null;
        oPyroServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.NoContent;
        oPyroServiceOperationOutcome.SuccessfulTransaction = true;
        return oPyroServiceOperationOutcome;
      }
      else if (ResourceIdCollection.Count > 1)
      {
        //Delete many resources that are not already deleted 
        IDatabaseOperationOutcome DatabaseOperationOutcomeDeleteMany = IResourceRepository.UpdateResouceIdColectionAsDeleted(ResourceIdCollection);
        if (DatabaseOperationOutcomeDeleteMany.TriggerOutCome != null && DatabaseOperationOutcomeDeleteMany.TriggerOutCome.Report)
        {
          //Nothing to delete at all or many were deleted.
          oPyroServiceOperationOutcome.ResourceResult = DatabaseOperationOutcomeDeleteMany.TriggerOutCome.Resource;
          oPyroServiceOperationOutcome.FhirResourceId = null;
          oPyroServiceOperationOutcome.LastModified = null;
          oPyroServiceOperationOutcome.IsDeleted = null;
          oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Delete;
          oPyroServiceOperationOutcome.ResourceVersionNumber = null;
          oPyroServiceOperationOutcome.RequestUri = null;
          oPyroServiceOperationOutcome.HttpStatusCode = DatabaseOperationOutcomeDeleteMany.TriggerOutCome.HttpStatusCode;
          oPyroServiceOperationOutcome.SuccessfulTransaction = false;
          return oPyroServiceOperationOutcome;
        }
      }
      
      //Nothing to delete at all or many were deleted.
      oPyroServiceOperationOutcome.ResourceResult = null;
      oPyroServiceOperationOutcome.FhirResourceId = null;
      oPyroServiceOperationOutcome.LastModified = null;
      oPyroServiceOperationOutcome.IsDeleted = null;
      oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Delete;
      oPyroServiceOperationOutcome.ResourceVersionNumber = null;
      oPyroServiceOperationOutcome.RequestUri = null;
      oPyroServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.NoContent;
      oPyroServiceOperationOutcome.SuccessfulTransaction = true;
      return oPyroServiceOperationOutcome;
    }

    private IResourceServiceOutcome SetResource(Resource Resource, IPyroRequestUri RequestUri, RestEnum.CrudOperationType CrudOperationType)
    {
      if (CrudOperationType == RestEnum.CrudOperationType.Update && (Resource.Meta == null || string.IsNullOrWhiteSpace(Resource.Meta.VersionId)))
        throw new ArgumentNullException("Internal Server Error:Resource's Version can not be null when CrudOperationType = Update");
      if ((CrudOperationType != RestEnum.CrudOperationType.Create) && (CrudOperationType != RestEnum.CrudOperationType.Update))
        throw new FormatException("Internal Server Error: CrudOperationType must be Update or Create");
      if (CrudOperationType == RestEnum.CrudOperationType.Update && string.IsNullOrWhiteSpace(Resource.Id))
        throw new ArgumentNullException("Internal Server Error: Resource Id must be populated for CrudOperationType = Update");

      IResourceServiceOutcome ServiceOperationOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();

      //Assign new GUID as FHIR id if not already assigned 
      if (string.IsNullOrWhiteSpace(Resource.Id))
        Resource.Id = Common.Tools.FhirGuid.FhirGuid.NewFhirGuid();

      string ResourceVersionNumber = string.Empty;
      if (Resource.Meta == null)
      {
        Resource.Meta = new Meta();
      }
      if (CrudOperationType == RestEnum.CrudOperationType.Create)
      {
        ResourceVersionNumber = Common.Tools.ResourceVersionNumber.FirstVersion();
        Resource.Meta.VersionId = ResourceVersionNumber;
      }
      else if (CrudOperationType == RestEnum.CrudOperationType.Update)
      {
        ResourceVersionNumber = Resource.Meta.VersionId;
      }
      Resource.Meta.LastUpdated = DateTimeOffset.Now;

      IDatabaseOperationOutcome DatabaseOperationOutcome = null;
      if (CrudOperationType == RestEnum.CrudOperationType.Update)
      {
        DatabaseOperationOutcome = IResourceRepository.UpdateResource(ResourceVersionNumber, Resource);
      }
      else if (CrudOperationType == RestEnum.CrudOperationType.Create)
      {
        DatabaseOperationOutcome = IResourceRepository.AddResource(Resource);
      }

      //Trigger wants to report
      if (DatabaseOperationOutcome.TriggerOutCome != null && DatabaseOperationOutcome.TriggerOutCome.Report)
      {
        ServiceOperationOutcome.ResourceResult = DatabaseOperationOutcome.TriggerOutCome.Resource;
        ServiceOperationOutcome.FhirResourceId = string.Empty;
        ServiceOperationOutcome.LastModified = null;
        ServiceOperationOutcome.IsDeleted = null;
        ServiceOperationOutcome.OperationType = CrudOperationType;
        ServiceOperationOutcome.ResourceVersionNumber = string.Empty;
        ServiceOperationOutcome.RequestUri = RequestUri.FhirRequestUri;
        ServiceOperationOutcome.FormatMimeType = null;
        ServiceOperationOutcome.HttpStatusCode = DatabaseOperationOutcome.TriggerOutCome.HttpStatusCode;
        return ServiceOperationOutcome;
      }

      if (DatabaseOperationOutcome.ReturnedResourceList != null && DatabaseOperationOutcome.ReturnedResourceList.Count == 1)
      {        
        ServiceOperationOutcome.ResourceResult = FhirResourceSerializationSupport.DeSerializeFromGZip(DatabaseOperationOutcome.ReturnedResourceList[0].Resource);
        ServiceOperationOutcome.FhirResourceId = DatabaseOperationOutcome.ReturnedResourceList[0].FhirId;
        ServiceOperationOutcome.LastModified = DatabaseOperationOutcome.ReturnedResourceList[0].Received;
        ServiceOperationOutcome.IsDeleted = DatabaseOperationOutcome.ReturnedResourceList[0].IsDeleted;
        ServiceOperationOutcome.OperationType = CrudOperationType;
        ServiceOperationOutcome.ResourceVersionNumber = DatabaseOperationOutcome.ReturnedResourceList[0].Version;
        ServiceOperationOutcome.RequestUri = RequestUri.FhirRequestUri;
        ServiceOperationOutcome.FormatMimeType = null;
        if (CrudOperationType == RestEnum.CrudOperationType.Create)
          ServiceOperationOutcome.HttpStatusCode = HttpStatusCode.Created;
        if (CrudOperationType == RestEnum.CrudOperationType.Update)
          ServiceOperationOutcome.HttpStatusCode = HttpStatusCode.OK;
      }
      else
      {
        ServiceOperationOutcome.ResourceResult = null;
        ServiceOperationOutcome.FhirResourceId = string.Empty;
        ServiceOperationOutcome.LastModified = null;
        ServiceOperationOutcome.IsDeleted = null;
        ServiceOperationOutcome.OperationType = CrudOperationType;
        ServiceOperationOutcome.ResourceVersionNumber = string.Empty;
        ServiceOperationOutcome.RequestUri = RequestUri.FhirRequestUri;
        ServiceOperationOutcome.FormatMimeType = null;
        ServiceOperationOutcome.HttpStatusCode = HttpStatusCode.BadRequest;
      }

      return ServiceOperationOutcome;
    }

    private IResourceServiceOutcome GetResourceHistoryInFull(string ResourceId, IPyroRequestUri RequestUri, ISearchParametersServiceOutcome SearchParametersServiceOutcome, IResourceServiceOutcome oPyroServiceOperationOutcome)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = IResourceRepository.GetResourceHistoryByFhirID(ResourceId, SearchParametersServiceOutcome.SearchParameters);

      Uri SupportedSearchSelfLink = null;
      Uri.TryCreate(RequestUri.FhirRequestUri.OriginalString, UriKind.Absolute, out SupportedSearchSelfLink);

      oPyroServiceOperationOutcome.ResourceResult = Common.Tools.Bundles.FhirBundleSupport.CreateBundle(DatabaseOperationOutcome.ReturnedResourceList,
                                                                                           Bundle.BundleType.History,
                                                                                           RequestUri,
                                                                                           DatabaseOperationOutcome.SearchTotal,
                                                                                           DatabaseOperationOutcome.PagesTotal,
                                                                                           DatabaseOperationOutcome.PageRequested,
                                                                                           IPagingSupport,
                                                                                           SupportedSearchSelfLink);
      oPyroServiceOperationOutcome.FhirResourceId = string.Empty;
      oPyroServiceOperationOutcome.LastModified = null;
      oPyroServiceOperationOutcome.IsDeleted = null;
      oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;
      oPyroServiceOperationOutcome.ResourceVersionNumber = string.Empty;
      oPyroServiceOperationOutcome.RequestUri = RequestUri.FhirRequestUri;
      oPyroServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;

      return oPyroServiceOperationOutcome;
    }

    private IResourceServiceOutcome GetResourceHistoryInstance(string ResourceId, string Version, IPyroRequestUri RequestUri, IResourceServiceOutcome oPyroServiceOperationOutcome)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = IResourceRepository.GetResourceByFhirIDAndVersionNumber(ResourceId, Version);
      if (DatabaseOperationOutcome.ReturnedResourceList != null && DatabaseOperationOutcome.ReturnedResourceList.Count == 1)
      {
        if (!DatabaseOperationOutcome.ReturnedResourceList[0].IsDeleted)          
          oPyroServiceOperationOutcome.ResourceResult = FhirResourceSerializationSupport.DeSerializeFromGZip(DatabaseOperationOutcome.ReturnedResourceList[0].Resource);
        oPyroServiceOperationOutcome.FhirResourceId = DatabaseOperationOutcome.ReturnedResourceList[0].FhirId;
        oPyroServiceOperationOutcome.LastModified = DatabaseOperationOutcome.ReturnedResourceList[0].Received;
        oPyroServiceOperationOutcome.IsDeleted = DatabaseOperationOutcome.ReturnedResourceList[0].IsDeleted;
        oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;
        oPyroServiceOperationOutcome.ResourceVersionNumber = DatabaseOperationOutcome.ReturnedResourceList[0].Version;
        oPyroServiceOperationOutcome.RequestUri = RequestUri.FhirRequestUri;
        oPyroServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;
      }
      else
      {
        oPyroServiceOperationOutcome.ResourceResult = null;
        oPyroServiceOperationOutcome.FhirResourceId = string.Empty;
        oPyroServiceOperationOutcome.LastModified = null;
        oPyroServiceOperationOutcome.IsDeleted = null;
        oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;
        oPyroServiceOperationOutcome.ResourceVersionNumber = string.Empty;
        oPyroServiceOperationOutcome.RequestUri = RequestUri.FhirRequestUri;
        oPyroServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.NotFound;
      }
      return oPyroServiceOperationOutcome;
    }

    private IResourceServiceOutcome GetResourceInstance(string ResourceId, IPyroRequestUri RequestUri, IResourceServiceOutcome oPyroServiceOperationOutcome, IRequestHeader RequestHeaders = null)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = IResourceRepository.GetResourceByFhirID(ResourceId, true);

      if (DatabaseOperationOutcome.ReturnedResourceList.Count == 1 && !DatabaseOperationOutcome.ReturnedResourceList[0].IsDeleted)
      {
        if (RequestHeaders != null &&
          (!string.IsNullOrWhiteSpace(RequestHeaders.IfNoneMatch) ||
          !string.IsNullOrWhiteSpace(RequestHeaders.IfModifiedSince)))
        {
          if (!HttpHeaderSupport.IsModifiedOrNoneMatch(RequestHeaders.IfNoneMatch,
            RequestHeaders.IfModifiedSince,
            DatabaseOperationOutcome.ReturnedResourceList[0].Version,
            DatabaseOperationOutcome.ReturnedResourceList[0].Received))
          {
            oPyroServiceOperationOutcome.ResourceResult = null;
            oPyroServiceOperationOutcome.FhirResourceId = DatabaseOperationOutcome.ReturnedResourceList[0].FhirId;
            oPyroServiceOperationOutcome.LastModified = DatabaseOperationOutcome.ReturnedResourceList[0].Received;
            oPyroServiceOperationOutcome.IsDeleted = DatabaseOperationOutcome.ReturnedResourceList[0].IsDeleted;
            oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;
            oPyroServiceOperationOutcome.ResourceVersionNumber = DatabaseOperationOutcome.ReturnedResourceList[0].Version;
            oPyroServiceOperationOutcome.RequestUri = RequestUri.FhirRequestUri;
            oPyroServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.NotModified;
            return oPyroServiceOperationOutcome;
          }
        }
        
        oPyroServiceOperationOutcome.ResourceResult = FhirResourceSerializationSupport.DeSerializeFromGZip(DatabaseOperationOutcome.ReturnedResourceList[0].Resource);
        oPyroServiceOperationOutcome.FhirResourceId = DatabaseOperationOutcome.ReturnedResourceList[0].FhirId;
        oPyroServiceOperationOutcome.LastModified = DatabaseOperationOutcome.ReturnedResourceList[0].Received;
        oPyroServiceOperationOutcome.IsDeleted = DatabaseOperationOutcome.ReturnedResourceList[0].IsDeleted;
        oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;
        oPyroServiceOperationOutcome.ResourceVersionNumber = DatabaseOperationOutcome.ReturnedResourceList[0].Version;
        oPyroServiceOperationOutcome.RequestUri = RequestUri.FhirRequestUri;
        oPyroServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;
      }
      else if (DatabaseOperationOutcome.ReturnedResourceList.Count == 1 && DatabaseOperationOutcome.ReturnedResourceList[0].IsDeleted)
      {
        oPyroServiceOperationOutcome.ResourceResult = null;
        oPyroServiceOperationOutcome.FhirResourceId = DatabaseOperationOutcome.ReturnedResourceList[0].FhirId;
        oPyroServiceOperationOutcome.LastModified = DatabaseOperationOutcome.ReturnedResourceList[0].Received;
        oPyroServiceOperationOutcome.IsDeleted = DatabaseOperationOutcome.ReturnedResourceList[0].IsDeleted;
        oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;
        oPyroServiceOperationOutcome.ResourceVersionNumber = DatabaseOperationOutcome.ReturnedResourceList[0].Version;
        oPyroServiceOperationOutcome.RequestUri = RequestUri.FhirRequestUri;
        oPyroServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.Gone;
      }
      else
      {
        oPyroServiceOperationOutcome.ResourceResult = null;
        oPyroServiceOperationOutcome.FhirResourceId = null;
        oPyroServiceOperationOutcome.LastModified = null;
        oPyroServiceOperationOutcome.IsDeleted = null;
        oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;
        oPyroServiceOperationOutcome.ResourceVersionNumber = null;
        oPyroServiceOperationOutcome.RequestUri = RequestUri.FhirRequestUri;
        oPyroServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.NotFound;
      }
      return oPyroServiceOperationOutcome;
    }

    private IDatabaseOperationOutcome GetResourcesBySearch(PyroSearchParameters SearchParameters)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = DatabaseOperationOutcome = IResourceRepository.GetResourceBySearch(SearchParameters, true);
      //Add any _include or _revinclude Resources
      if (SearchParameters != null && SearchParameters.IncludeList != null && DatabaseOperationOutcome.ReturnedResourceList != null)
      {
        DatabaseOperationOutcome.ReturnedResourceList = IIncludeService.ResolveIncludeResourceList(SearchParameters.IncludeList, DatabaseOperationOutcome.ReturnedResourceList);
      }
      return DatabaseOperationOutcome;
    }

    private IDatabaseOperationOutcome GetResourcesByCompartmentSearch(PyroSearchParameters CompartmentSearchParameters, PyroSearchParameters SearchParameters, string Compartment, string CompartmentId)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = null;
      DatabaseOperationOutcome = IResourceRepository.GetResourceByCompartmentSearch(CompartmentSearchParameters, SearchParameters, true);

      //Add any _include or _revinclude Resources
      if (SearchParameters != null && SearchParameters.IncludeList != null && DatabaseOperationOutcome.ReturnedResourceList != null)
      {
        DatabaseOperationOutcome.ReturnedResourceList = IIncludeService.ResolveIncludeResourceList(SearchParameters.IncludeList, DatabaseOperationOutcome.ReturnedResourceList, Compartment, CompartmentId);
      }
      return DatabaseOperationOutcome;
    }

    private bool ResourceProvidedMatchesEndpointItWasProvidedOn(IPyroRequestUri requestUri, ResourceType resourceType)
    {
      return (requestUri.FhirRequestUri.ResourseName == resourceType.GetLiteral());
    }

  }
}

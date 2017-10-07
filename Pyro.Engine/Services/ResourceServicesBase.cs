using System;
using System.Collections.Generic;
using System.Linq;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Enum;
using Pyro.Common.Tools;
using Hl7.Fhir.Model;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Interfaces.ITools;
using Pyro.Common.Exceptions;
using System.Net;
using Hl7.Fhir.Utility;
using Pyro.Common.Search;
using Pyro.Common.Service;
using Pyro.Common.Tools.Headers;

namespace Pyro.Engine.Services
{
  public class ResourceServicesBase : CommonServices, IResourceServicesBase
  {
    protected IResourceRepository IResourceRepository = null;
    protected readonly ICommonFactory ICommonFactory;
    protected readonly ISearchParameterGenericFactory ISearchParameterGenericFactory;
    private readonly IRepositorySwitcher IRepositorySwitcher;
    private readonly IIncludeService IIncludeService;
    private readonly IChainSearchingService IChainSearchingService;

    //Constructor for dependency injection
    public ResourceServicesBase(IUnitOfWork IUnitOfWork, IRepositorySwitcher IRepositorySwitcher, ICommonFactory ICommonFactory, ISearchParameterGenericFactory ISearchParameterGenericFactory, IIncludeService IIncludeService, IChainSearchingService IChainSearchingService)
      : base(IUnitOfWork)
    {
      this.ICommonFactory = ICommonFactory;
      this.IRepositorySwitcher = IRepositorySwitcher;
      this.IIncludeService = IIncludeService;
      this.IChainSearchingService = IChainSearchingService;
      this.ISearchParameterGenericFactory = ISearchParameterGenericFactory;
    }

    public void SetCurrentResourceType(FHIRAllTypes ResourceType)
    {
      _CurrentResourceType = ResourceType;
      IResourceRepository = IRepositorySwitcher.GetRepository(_CurrentResourceType);
    }

    public void SetCurrentResourceType(ResourceType ResourceType)
    {
      SetCurrentResourceType(ResourceNameResolutionSupport.GetResourceFhirAllType(ResourceType));
    }

    public void SetCurrentResourceType(string ResourceName)
    {
      SetCurrentResourceType(ResourceNameResolutionSupport.GetResourceFhirAllType(ResourceName));
    }

    protected FHIRAllTypes _CurrentResourceType = FHIRAllTypes.AuditEvent;

    public FHIRAllTypes ServiceResourceType
    {
      get
      {
        return _CurrentResourceType;
      }
    }

    public IResourceServiceOutcome SetResourceCollectionAsDeleted(ICollection<string> ResourceIdCollection)
    {
      IResourceServiceOutcome oPyroServiceOperationOutcome = ICommonFactory.CreateResourceServiceOutcome();
      if (ResourceIdCollection.Count == 1)
      {
        //Delete one resource that is not already deleted 
        IDatabaseOperationOutcome DatabaseOperationOutcomeDelete = IResourceRepository.UpdateResouceIdAsDeleted(ResourceIdCollection.First());
        oPyroServiceOperationOutcome.ResourceResult = null;
        oPyroServiceOperationOutcome.FhirResourceId = DatabaseOperationOutcomeDelete.ReturnedResourceList[0].FhirId;
        oPyroServiceOperationOutcome.LastModified = DatabaseOperationOutcomeDelete.ReturnedResourceList[0].Received;
        oPyroServiceOperationOutcome.IsDeleted = DatabaseOperationOutcomeDelete.ReturnedResourceList[0].IsDeleted;
        oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Delete;
        oPyroServiceOperationOutcome.ResourceVersionNumber = DatabaseOperationOutcomeDelete.ReturnedResourceList[0].Version;
        oPyroServiceOperationOutcome.RequestUri = null;
        oPyroServiceOperationOutcome.FormatMimeType = null;
        oPyroServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.NoContent;
        return oPyroServiceOperationOutcome;
      }
      else if (ResourceIdCollection.Count > 1)
      {
        //Delete many resources that are not already deleted 
        IDatabaseOperationOutcome DatabaseOperationOutcomeDeleteMany = IResourceRepository.UpdateResouceIdColectionAsDeleted(ResourceIdCollection);
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

      return oPyroServiceOperationOutcome;
    }

    public IResourceServiceOutcome SetResource(Resource Resource, IPyroRequestUri RequestUri, RestEnum.CrudOperationType CrudOperationType)
    {
      if (CrudOperationType == RestEnum.CrudOperationType.Update && (Resource.Meta == null || string.IsNullOrWhiteSpace(Resource.Meta.VersionId)))
        throw new ArgumentNullException("Internal Server Error:Resource's Version can not be null when CrudOperationType = Update");
      if ((CrudOperationType != RestEnum.CrudOperationType.Create) && (CrudOperationType != RestEnum.CrudOperationType.Update))
        throw new FormatException("Internal Server Error: CrudOperationType must be Update or Create");
      if (CrudOperationType == RestEnum.CrudOperationType.Update && string.IsNullOrWhiteSpace(Resource.Id))
        throw new ArgumentNullException("Internal Server Error: Resource Id must be populated for CrudOperationType = Update");

      IResourceServiceOutcome ServiceOperationOutcome = ICommonFactory.CreateResourceServiceOutcome();

      //Assign GUID as FHIR id;
      if (string.IsNullOrWhiteSpace(Resource.Id))
        Resource.Id = Guid.NewGuid().ToString();

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
        DatabaseOperationOutcome = IResourceRepository.UpdateResource(ResourceVersionNumber, Resource, RequestUri);
      }
      else if (CrudOperationType == RestEnum.CrudOperationType.Create)
      {
        DatabaseOperationOutcome = IResourceRepository.AddResource(Resource, RequestUri);
      }

      if (DatabaseOperationOutcome.ReturnedResourceList != null && DatabaseOperationOutcome.ReturnedResourceList.Count == 1)
      {
        ServiceOperationOutcome.ResourceResult = FhirResourceSerializationSupport.DeSerializeFromXml(DatabaseOperationOutcome.ReturnedResourceList[0].Xml);
        ServiceOperationOutcome.FhirResourceId = DatabaseOperationOutcome.ReturnedResourceList[0].FhirId;
        ServiceOperationOutcome.LastModified = DatabaseOperationOutcome.ReturnedResourceList[0].Received;
        ServiceOperationOutcome.IsDeleted = DatabaseOperationOutcome.ReturnedResourceList[0].IsDeleted;
        ServiceOperationOutcome.OperationType = CrudOperationType;
        ServiceOperationOutcome.ResourceVersionNumber = DatabaseOperationOutcome.ReturnedResourceList[0].Version;
        ServiceOperationOutcome.RequestUri = RequestUri.FhirRequestUri;
        //ServiceOperationOutcome.ServiceRootUri = RequestUri.PrimaryRootUrlStore.RootUri;
        ServiceOperationOutcome.FormatMimeType = null;
        if (CrudOperationType == RestEnum.CrudOperationType.Create)
          ServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.Created;
        if (CrudOperationType == RestEnum.CrudOperationType.Update)
          ServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;
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
        ServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
      }
      return ServiceOperationOutcome;
    }

    public IResourceServiceOutcome GetResourceHistoryInFull(string ResourceId, IPyroRequestUri RequestUri, ISearchParametersServiceOutcome SearchParametersServiceOutcome, IResourceServiceOutcome oPyroServiceOperationOutcome)
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

    public IResourceServiceOutcome GetResourceHistoryInstance(string ResourceId, string Version, IPyroRequestUri RequestUri, IResourceServiceOutcome oPyroServiceOperationOutcome)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = IResourceRepository.GetResourceByFhirIDAndVersionNumber(ResourceId, Version);
      if (DatabaseOperationOutcome.ReturnedResourceList != null && DatabaseOperationOutcome.ReturnedResourceList.Count == 1)
      {
        if (!DatabaseOperationOutcome.ReturnedResourceList[0].IsDeleted)
          oPyroServiceOperationOutcome.ResourceResult = FhirResourceSerializationSupport.DeSerializeFromXml(DatabaseOperationOutcome.ReturnedResourceList[0].Xml);
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

    public IResourceServiceOutcome GetResourceInstance(string ResourceId, IPyroRequestUri RequestUri, IResourceServiceOutcome oPyroServiceOperationOutcome, IRequestHeader RequestHeaders = null)
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

        oPyroServiceOperationOutcome.ResourceResult = FhirResourceSerializationSupport.DeSerializeFromXml(DatabaseOperationOutcome.ReturnedResourceList[0].Xml);
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

    public IResourceServiceOutcome GetResourcesBySearch(IPyroRequestUri RequestUri, ISearchParametersServiceOutcome SearchParametersServiceOutcome, IResourceServiceOutcome oPyroServiceOperationOutcome)
    {
      Uri SelfLink = SearchParametersServiceOutcome.SearchParameters.SupportedSearchUrl(RequestUri.FhirRequestUri.UriPrimaryServiceRoot.OriginalString);

      foreach (SearchParameterReferance Chain in SearchParametersServiceOutcome.SearchParameters.SearchParametersList.OfType<SearchParameterReferance>().Where(x => x.IsChained == true))
      {
        IChainSearchingService.ResolveChain(Chain);
      }

      IDatabaseOperationOutcome DatabaseOperationOutcome = IResourceRepository.GetResourceBySearch(SearchParametersServiceOutcome.SearchParameters, true);

      //Add any _Revinclude Resources
      if (SearchParametersServiceOutcome.SearchParameters != null && SearchParametersServiceOutcome.SearchParameters.IncludeList != null && DatabaseOperationOutcome.ReturnedResourceList != null)
      {
        DatabaseOperationOutcome.ReturnedResourceList = IIncludeService.ResolveIncludeResourceList(SearchParametersServiceOutcome.SearchParameters.IncludeList, DatabaseOperationOutcome.ReturnedResourceList);
      }

      oPyroServiceOperationOutcome.ResourceResult = Common.Tools.Bundles.FhirBundleSupport.CreateBundle(DatabaseOperationOutcome.ReturnedResourceList,
                                                                                             Bundle.BundleType.Searchset,
                                                                                             RequestUri,
                                                                                             DatabaseOperationOutcome.SearchTotal,
                                                                                             DatabaseOperationOutcome.PagesTotal,
                                                                                             DatabaseOperationOutcome.PageRequested,
                                                                                             SelfLink);
      oPyroServiceOperationOutcome.FhirResourceId = string.Empty;
      oPyroServiceOperationOutcome.LastModified = null;
      oPyroServiceOperationOutcome.IsDeleted = null;
      oPyroServiceOperationOutcome.OperationType = RestEnum.CrudOperationType.Read;
      oPyroServiceOperationOutcome.ResourceVersionNumber = string.Empty;
      oPyroServiceOperationOutcome.RequestUri = RequestUri.FhirRequestUri;
      oPyroServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
      oPyroServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;

      return oPyroServiceOperationOutcome;
    }

  }
}

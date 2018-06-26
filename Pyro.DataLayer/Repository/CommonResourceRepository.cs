using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Hl7.FhirPath;
using Pyro.Common.DtoEntity;
using Pyro.Common.Search;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.ServiceRoot;
using Pyro.Common.Extentions;
using Pyro.DataLayer.DbModel.EntityBase;
using Pyro.DataLayer.IndexSetter;
using Pyro.DataLayer.Search.Extentions;
using Pyro.DataLayer.Support;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using Pyro.DataLayer.DbModel.DatabaseContext;
using Pyro.Common.ServiceSearchParameter;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Global;
using Pyro.Common.FhirRelease;
using Pyro.Common.Tools.Paging;

namespace Pyro.DataLayer.Repository
{
  public class CommonResourceRepository<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType> :
    BaseRepository,
    ICommonResourceRepository<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>,
    IResourceRepository
    where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
  {
    public FHIRAllTypes RepositoryResourceType { get; set; }
    private readonly IIndexSetterFactory<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType> IIndexSetterFactory;
    private readonly IServiceSearchParameterCache IServiceSearchParameterCache;
    private readonly IFhirReleaseCache IFhirReleaseCache;
    private readonly IDatabaseOperationOutcomeFactory IDatabaseOperationOutcomeFactory;
    private readonly IPagingSupport IPagingSupport;

    private CommonRepository<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType> CommonRepository;
   
    public CommonResourceRepository(IPyroDbContext IPyroDbContext,
      IPrimaryServiceRootCache IPrimaryServiceRootCache,
      IIndexSetterFactory<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType> IIndexSetterFactory,
      IServiceSearchParameterCache IServiceSearchParameterCache,
      IFhirReleaseCache IFhirReleaseCache,
      IDatabaseOperationOutcomeFactory IDatabaseOperationOutcomeFactory,            
      IPagingSupport IPagingSupport)
      : base(IPyroDbContext)
    {
      this.IIndexSetterFactory = IIndexSetterFactory;
      this.IServiceSearchParameterCache = IServiceSearchParameterCache;
      this.IFhirReleaseCache = IFhirReleaseCache;
      this.IDatabaseOperationOutcomeFactory = IDatabaseOperationOutcomeFactory;
      this.IPagingSupport = IPagingSupport;
    
      this.CommonRepository = new CommonRepository<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(IPyroDbContext, IPrimaryServiceRootCache);
    }

    //Used for _include and _Revinclude
    public string[] GetResourceFhirIdByResourceIdAndIndexReferance(int ResourceId, int[] SearchParameterIdArray, string ResourceName = "")
    {
      LinqKit.ExpressionStarter<ResIndexReferenceType> RefPredicate = null;
      if (string.IsNullOrWhiteSpace(ResourceName))
        RefPredicate = this.CommonRepository.IndexRefPredicateGenerator(ResourceId, SearchParameterIdArray);
      else
        RefPredicate = this.CommonRepository.IndexRefPredicateGenerator(ResourceId, SearchParameterIdArray, ResourceName);

      var IndexQuery = this.CommonRepository.DbGetIndexAll(RefPredicate);
      var IndexResult = IndexQuery.Select(x => x.ReferenceFhirId).ToArray();
      return IndexResult;
    }

    //Used for Chain Reference Searching
    public string[] GetResourceFhirIdByReferanceIndex(IEnumerable<string> FhirIdArray, string ResourceName, int SearchParameterIdArray)
    {
      LinqKit.ExpressionStarter<ResCurrentType> ResCurrentTypePredicate = null;

      ResCurrentTypePredicate = this.CommonRepository.ResourceCurrentPredicateGeneratorByRefereneNoPaging(FhirIdArray, ResourceName, SearchParameterIdArray);

      var Query = this.CommonRepository.DbGetAll(ResCurrentTypePredicate);

      var Result = Query.Select(x => x.FhirId).ToArray();
      return Result;
    }

    //Used for Primary Chain Searching
    public string[] GetResourceFhirIdBySearchNoPaging(PyroSearchParameters DtoSearchParameters)
    {
      
      //var Predicate = LinqKit.PredicateBuilder.New<ResCurrentType>(true);
      //Predicate = PredicateCurrentNotDeleted<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(Predicate);
      //Predicate = PredicateResourceIdAndLastUpdatedDate<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(DtoSearchParameters.SearchParametersList, Predicate);
      //Predicate = ANDSearchParameterListPredicateGenerator<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(DtoSearchParameters.SearchParametersList, Predicate);

      var Predicate = LinqKit.PredicateBuilder.New<ResCurrentType>(true);
      
      var PredicateOne = this.CommonRepository.PredicateCurrentNotDeleted();
      var PredicateTwo = this.CommonRepository.PredicateResourceIdAndLastUpdatedDate(DtoSearchParameters.SearchParametersList);
      var PredicateThree = this.CommonRepository.ANDSearchParameterListPredicateGenerator(DtoSearchParameters.SearchParametersList);

      Predicate = Predicate.And(PredicateOne);
      Predicate = Predicate.And(PredicateTwo);
      Predicate = Predicate.And(PredicateThree);




      var Query = this.CommonRepository.DbGetAll(Predicate);
      
      string[] FhirIdResultArray = Query.Select(x => x.FhirId).ToArray();
      return FhirIdResultArray;
    }

    public IDatabaseOperationOutcome GetResourceBySearch(PyroSearchParameters DtoSearchParameters, bool WithXml = false)
    {
      //SetNumberOfRecordsPerPage(DtoSearchParameters);
      var Predicate = LinqKit.PredicateBuilder.New<ResCurrentType>(true);
      var PredicateCurrentResources = this.CommonRepository.PredicateCurrentNotDeleted();
      var PredicateIdAndLastUpdated = this.CommonRepository.PredicateResourceIdAndLastUpdatedDate(DtoSearchParameters.SearchParametersList);
      var PredicateSearchParameters = this.CommonRepository.ANDSearchParameterListPredicateGenerator(DtoSearchParameters.SearchParametersList);
      
      Predicate = Predicate.And(PredicateCurrentResources);
      Predicate = Predicate.And(PredicateIdAndLastUpdated);
      Predicate = Predicate.And(PredicateSearchParameters);

      int TotalRecordCount = this.CommonRepository.DbGetALLCount<ResCurrentType>(Predicate);
      var Query = this.CommonRepository.DbGetAll(Predicate);

      //Todo: Sort not implemented just defaulting to last update order      
      Query = Query.OrderBy(x => x.LastUpdated);

      int ClaculatedPageRequired = IPagingSupport.CalculatePageRequired(DtoSearchParameters.RequiredPageNumber, DtoSearchParameters.CountOfRecordsRequested, TotalRecordCount);

      Query = Query.Paging(ClaculatedPageRequired, IPagingSupport.SetNumberOfRecordsPerPage(DtoSearchParameters.CountOfRecordsRequested));
      var DtoResourceList = new List<DtoResource>();
      if (WithXml)
      {
        DtoResourceList = Query.Select(x => new DtoResource
        {
          Id = x.Id,
          FhirId = x.FhirId,
          IsDeleted = x.IsDeleted,
          IsCurrent = true,
          Version = x.VersionId,
          Received = x.LastUpdated,
          Method = x.Method,
          ResourceType = this.RepositoryResourceType,
          Xml = x.XmlBlob
        }).ToList();
      }
      else
      {
        DtoResourceList = Query.Select(x => new DtoResource
        {
          Id = x.Id,
          FhirId = x.FhirId,
          IsDeleted = x.IsDeleted,
          IsCurrent = true,
          Version = x.VersionId,
          Received = x.LastUpdated,
          Method = x.Method,
          ResourceType = this.RepositoryResourceType
        }).ToList();
      }

      IDatabaseOperationOutcome DatabaseOperationOutcome = IDatabaseOperationOutcomeFactory.CreateDatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = false;
      DatabaseOperationOutcome.SearchTotal = TotalRecordCount;
      DatabaseOperationOutcome.PagesTotal = IPagingSupport.CalculateTotalPages(DtoSearchParameters.CountOfRecordsRequested, TotalRecordCount); ;
      DatabaseOperationOutcome.PageRequested = ClaculatedPageRequired;
      DatabaseOperationOutcome.ReturnedResourceList = DtoResourceList;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome GetResourceByCompartmentSearch(PyroSearchParameters CompartmentSearchParameters, PyroSearchParameters DtoSearchParameters, bool WithXml = false)
    {
      //SetNumberOfRecordsPerPage(DtoSearchParameters);

      var Predicate = LinqKit.PredicateBuilder.New<ResCurrentType>(true);
      var PredicateCurrentResources = this.CommonRepository.PredicateCurrentNotDeleted();
      var PredicateIdAndLastUpdated = this.CommonRepository.PredicateResourceIdAndLastUpdatedDate(DtoSearchParameters.SearchParametersList);
      var PredicateSearchParameters = this.CommonRepository.ANDSearchParameterListPredicateGenerator(DtoSearchParameters.SearchParametersList);
      var PredicateCompartment = this.CommonRepository.ORSearchParameterListPredicateGenerator(CompartmentSearchParameters.SearchParametersList);

      Predicate = Predicate.And(PredicateCurrentResources);
      Predicate = Predicate.And(PredicateIdAndLastUpdated);
      Predicate = Predicate.And(PredicateSearchParameters);
      Predicate = Predicate.And(PredicateCompartment);
      
      int TotalRecordCount = this.CommonRepository.DbGetALLCount<ResCurrentType>(Predicate);
      var Query = this.CommonRepository.DbGetAll(Predicate);

      //Todo: Sort not implemented just defaulting to last update order      
      Query = Query.OrderBy(x => x.LastUpdated);

      int ClaculatedPageRequired = IPagingSupport.CalculatePageRequired(DtoSearchParameters.RequiredPageNumber, DtoSearchParameters.CountOfRecordsRequested, TotalRecordCount);

      Query = Query.Paging(ClaculatedPageRequired, IPagingSupport.SetNumberOfRecordsPerPage(DtoSearchParameters.CountOfRecordsRequested));
      var DtoResourceList = new List<DtoResource>();
      if (WithXml)
      {
        DtoResourceList = Query.Select(x => new DtoResource
        {
          Id = x.Id,
          FhirId = x.FhirId,
          IsDeleted = x.IsDeleted,
          IsCurrent = true,
          Version = x.VersionId,
          Received = x.LastUpdated,
          Method = x.Method,
          ResourceType = this.RepositoryResourceType,
          Xml = x.XmlBlob
        }).ToList();
      }
      else
      {
        DtoResourceList = Query.Select(x => new DtoResource
        {
          Id = x.Id,
          FhirId = x.FhirId,
          IsDeleted = x.IsDeleted,
          IsCurrent = true,
          Version = x.VersionId,
          Received = x.LastUpdated,
          Method = x.Method,
          ResourceType = this.RepositoryResourceType
        }).ToList();
      }

      IDatabaseOperationOutcome DatabaseOperationOutcome = IDatabaseOperationOutcomeFactory.CreateDatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = false;
      DatabaseOperationOutcome.SearchTotal = TotalRecordCount;
      DatabaseOperationOutcome.PagesTotal = IPagingSupport.CalculateTotalPages(DtoSearchParameters.CountOfRecordsRequested, TotalRecordCount); 
      DatabaseOperationOutcome.PageRequested = ClaculatedPageRequired;
      DatabaseOperationOutcome.ReturnedResourceList = DtoResourceList;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome GetResourceByFhirID(string FhirId, bool WithXml = false, bool IncludeDeleted = true)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = IDatabaseOperationOutcomeFactory.CreateDatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      DtoResource DtoResource = null;
      if (WithXml)
      {
        if (IncludeDeleted)
          DtoResource = this.CommonRepository.DbGetWithXML(x => x.FhirId == FhirId & x.IsCurrent == true);
        else
          DtoResource = this.CommonRepository.DbGetWithXML(x => x.FhirId == FhirId & x.IsCurrent == true & x.IsDeleted == false);
      }
      else
      {
        if (IncludeDeleted)
          DtoResource = this.CommonRepository.DbGetNoXML(x => x.FhirId == FhirId & x.IsCurrent == true);
        else
          DtoResource = this.CommonRepository.DbGetNoXML(x => x.FhirId == FhirId & x.IsCurrent == true & x.IsDeleted == false);
      }
      if (DtoResource != null)
      {
        DtoResource.ResourceType = this.RepositoryResourceType;
        DatabaseOperationOutcome.ReturnedResourceList.Add(DtoResource);
      }
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = IDatabaseOperationOutcomeFactory.CreateDatabaseOperationOutcome();

      if (!string.IsNullOrWhiteSpace(ResourceVersionNumber))
      {
        DatabaseOperationOutcome.SingleResourceRead = true;
        var ResourceHistoryEntity = this.CommonRepository.DbGet(x => x.FhirId == FhirResourceId && x.VersionId == ResourceVersionNumber);
        if (ResourceHistoryEntity != null)
        {
          DatabaseOperationOutcome.ReturnedResourceList.Add(IndexSettingSupport.SetDtoResource(ResourceHistoryEntity, this.RepositoryResourceType));
        }
      }
      else
      {

        DatabaseOperationOutcome.SingleResourceRead = false;
        var Predicate = LinqKit.PredicateBuilder.New<ResCurrentType>(true);
        Predicate = Predicate.And(x => x.FhirId == FhirResourceId);
        int TotalRecordCount = this.CommonRepository.DbGetALLCount<ResCurrentType>(Predicate);
        var Query = this.CommonRepository.DbGetAll(Predicate);

        //Todo: Sort not implemented just defaulting to last update order
        //Query = Query.OrderBy(x => x.lastUpdated);
        //int ClaculatedPageRequired = PaginationSupport.CalculatePageRequired(DtoSearchParameters.RequiredPageNumber, _NumberOfRecordsPerPage, TotalRecordCount);

        //Query = Query.Paging(ClaculatedPageRequired, _NumberOfRecordsPerPage);
        var DtoResourceList = new List<DtoResource>();
        Query.ToList().ForEach(x => DtoResourceList.Add(IndexSettingSupport.SetDtoResource<ResourceBase>(x, this.RepositoryResourceType)));

      }
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome GetResourceHistoryByFhirID(string FhirResourceId, PyroSearchParameters DtoSearchParameters)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = IDatabaseOperationOutcomeFactory.CreateDatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = false;

      //SetNumberOfRecordsPerPage(DtoSearchParameters);

      var Predicate = LinqKit.PredicateBuilder.New<ResCurrentType>(true);
      Predicate = Predicate.And(x => x.FhirId == FhirResourceId);

      //Query for total count
      int TotalRecordCount = this.CommonRepository.DbGetALLCount<ResCurrentType>(Predicate);

      //Paging set-up
      var Query = this.CommonRepository.DbGetAll(Predicate);

      //Which way to order, touchstone tests failing for history due to wrong way, have changed to Descending to see if they pass 
      //Query = Query.OrderBy(x => x.LastUpdated);
      Query = Query.OrderByDescending(x => x.LastUpdated);

      int ClaculatedPageRequired = IPagingSupport.CalculatePageRequired(DtoSearchParameters.RequiredPageNumber, DtoSearchParameters.CountOfRecordsRequested, TotalRecordCount);
      Query = Query.Paging(ClaculatedPageRequired, IPagingSupport.SetNumberOfRecordsPerPage(DtoSearchParameters.CountOfRecordsRequested));
      int PagesTotal = IPagingSupport.CalculateTotalPages(DtoSearchParameters.CountOfRecordsRequested, TotalRecordCount);

      //Query for Resources
      var HistoryEntityList = Query.ToList();

      //Convert to DTO
      var DtoResourceList = new List<DtoResource>();
      if (HistoryEntityList != null)
        HistoryEntityList.ForEach(x => DtoResourceList.Add(IndexSettingSupport.SetDtoResource(x, this.RepositoryResourceType)));

      DatabaseOperationOutcome.SingleResourceRead = false;
      DatabaseOperationOutcome.SearchTotal = TotalRecordCount;
      DatabaseOperationOutcome.PagesTotal = IPagingSupport.CalculateTotalPages(DtoSearchParameters.CountOfRecordsRequested, TotalRecordCount);
      DatabaseOperationOutcome.PageRequested = IPagingSupport.CalculatePageRequired(DtoSearchParameters.RequiredPageNumber, DtoSearchParameters.CountOfRecordsRequested, TotalRecordCount);
      DatabaseOperationOutcome.ReturnedResourceList = DtoResourceList;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IPyroRequestUri FhirRequestUri)
    {
      var ResourceEntity = new ResCurrentType();
      DtoFhirRelease DtoFhirRelease = IFhirReleaseCache.GetFhirReleaseByFhirVersion(Hl7.Fhir.Model.ModelInfo.Version);
      IndexSettingSupport.SetResourceBaseAddOrUpdate(Resource, ResourceEntity, Common.Tools.ResourceVersionNumber.FirstVersion(), false, Bundle.HTTPVerb.POST, DtoFhirRelease.Id);
      this.PopulateResourceEntity(ResourceEntity, Resource, FhirRequestUri);
      ResourceEntity.IsCurrent = true;
      this.CommonRepository.DbAddEntity(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = IDatabaseOperationOutcomeFactory.CreateDatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      DatabaseOperationOutcome.ReturnedResourceList.Add(IndexSettingSupport.SetDtoResource(ResourceEntity, this.RepositoryResourceType));
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IPyroRequestUri FhirRequestUri)
    {
      var NewResourceEntity = new ResCurrentType();
      var ResourceHistoryEntity = LoadCurrentResourceEntity(Resource.Id);
      ResourceHistoryEntity.IsCurrent = false;
      DtoFhirRelease DtoFhirRelease = IFhirReleaseCache.GetFhirReleaseByFhirVersion(Hl7.Fhir.Model.ModelInfo.Version);
      IndexSettingSupport.SetResourceBaseAddOrUpdate(Resource, NewResourceEntity, ResourceVersion, false, Bundle.HTTPVerb.PUT, DtoFhirRelease.Id);
      this.PopulateResourceEntity(NewResourceEntity, Resource, FhirRequestUri);
      NewResourceEntity.IsCurrent = true;
      this.CommonRepository.DbAddEntity(NewResourceEntity);
      //this.Save();
      IDatabaseOperationOutcome DatabaseOperationOutcome = IDatabaseOperationOutcomeFactory.CreateDatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      DatabaseOperationOutcome.ReturnedResourceList.Add(IndexSettingSupport.SetDtoResource(NewResourceEntity, this.RepositoryResourceType));
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResouceIdAsDeleted(string FhirId)
    {
      var OldResourceEntity = this.LoadCurrentResourceEntity(FhirId);
      var NewResourceEntity = new ResCurrentType();
      IndexSettingSupport.SetHistoryResourceEntity(OldResourceEntity, NewResourceEntity);
      string NewDeletedResourceVersion = Common.Tools.ResourceVersionNumber.Increment(OldResourceEntity.VersionId);
      NewResourceEntity.IsCurrent = true;
      NewResourceEntity.IsDeleted = true;
      NewResourceEntity.LastUpdated = DateTimeOffset.Now;
      NewResourceEntity.Method = Bundle.HTTPVerb.DELETE;
      NewResourceEntity.XmlBlob = string.Empty;
      NewResourceEntity.VersionId = NewDeletedResourceVersion;
      this.CommonRepository.DbAddEntity(NewResourceEntity);
      OldResourceEntity.IsCurrent = false;
      //this.Save();
      IDatabaseOperationOutcome DatabaseOperationOutcome = IDatabaseOperationOutcomeFactory.CreateDatabaseOperationOutcome();
      DatabaseOperationOutcome.ReturnedResourceList.Add(IndexSettingSupport.SetDtoResource(NewResourceEntity, this.RepositoryResourceType));
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResouceIdColectionAsDeleted(ICollection<string> ResourceIdCollection)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = IDatabaseOperationOutcomeFactory.CreateDatabaseOperationOutcome();
      foreach (string ResourceId in ResourceIdCollection)
      {
        var OldResourceEntity = this.LoadCurrentResourceEntity(ResourceId);
        var NewResourceEntity = new ResCurrentType();
        IndexSettingSupport.SetHistoryResourceEntity(OldResourceEntity, NewResourceEntity);
        string NewDeletedResourceVersion = Common.Tools.ResourceVersionNumber.Increment(OldResourceEntity.VersionId);
        NewResourceEntity.IsCurrent = true;
        NewResourceEntity.IsDeleted = true;
        NewResourceEntity.LastUpdated = DateTimeOffset.Now;
        NewResourceEntity.Method = Bundle.HTTPVerb.DELETE;
        NewResourceEntity.XmlBlob = string.Empty;
        NewResourceEntity.VersionId = NewDeletedResourceVersion;
        this.CommonRepository.DbAddEntity(NewResourceEntity);
        OldResourceEntity.IsCurrent = false;

        DatabaseOperationOutcome.ReturnedResourceList.Add(IndexSettingSupport.SetDtoResource(NewResourceEntity, this.RepositoryResourceType));
      }
      //this.Save();
      return DatabaseOperationOutcome;
    }

    public ResCurrentType LoadCurrentResourceEntity(string FhirId)
    {
      var IncludeList = new List<Expression<Func<ResCurrentType, object>>>();
      IncludeList.Add(x => x.IndexQuantityList);
      IncludeList.Add(x => x.IndexDateTimeList);
      IncludeList.Add(x => x.IndexReferenceList);
      IncludeList.Add(x => x.IndexStringList);
      IncludeList.Add(x => x.IndexTokenList);
      IncludeList.Add(x => x.IndexUriList);

      var ResourceEntity = this.CommonRepository.DbQueryEntityWithInclude(x => x.FhirId == FhirId & x.IsCurrent == true, IncludeList);
      return ResourceEntity;
    }

    public int GetTotalCurrentResourceCount()
    {
      return this.CommonRepository.DbGetALLCount<ResCurrentType>(x => x.IsCurrent == true);
    }

    public DateTimeOffset? GetLastCurrentResourceLastUpdatedValue()
    {
      var LastEntity = IPyroDbContext.Set<ResCurrentType>().Max(x => x.LastUpdated);
      if (LastEntity != null)
        return LastEntity;
      else
        return null;
    }

    public void AddCurrentResourceIndex(List<DtoServiceSearchParameterLight> ServiceSearchParameterLightList, IPyroRequestUri FhirRequestUri)
    {
      int ChunkSize = 100;
      int ProgressCount = 0;
      var Count = this.CommonRepository.DbGetAll(x => x.IsCurrent == true & x.IsDeleted == false).Count();

      while (Count > ProgressCount)
      {
        var EntityList = this.CommonRepository.DbGetAll(x => x.IsCurrent == true & x.IsDeleted == false)
         .Include(x => x.IndexDateTimeList)
         .Include(x => x.IndexQuantityList)
         .Include(x => x.IndexReferenceList)
         .Include(x => x.IndexStringList)
         .Include(x => x.IndexTokenList)
         .Include(x => x.IndexUriList)
         .OrderBy(x => x.Id)
         .Skip(ProgressCount)
         .Take(ChunkSize)
         .ToList();
        foreach (var Entity in EntityList)
        {
          Resource Resource = Common.Tools.FhirResourceSerializationSupport.DeSerializeFromXml(Entity.XmlBlob);
          AddResourceIndexes(Entity, Resource, FhirRequestUri, ServiceSearchParameterLightList);
        }
        this.Save();
        ProgressCount = ProgressCount + ChunkSize;
      }
    }

    private int DeleteIndex<IndexType>(IQueryable<IndexType> IndexList, int CurrentCounter)
      where IndexType : ModelBase
    {
      foreach (IndexType Index in IndexList)
      {
        CurrentCounter++;
        (IPyroDbContext as IObjectContextAdapter).ObjectContext.DeleteObject(Index);
      }
      return CurrentCounter;
    }

    public int DeleteNonCurrentResourceIndexes()
    {
      int RowsRemovedCount = 0;
      var StringIndexList = IPyroDbContext.Set<ResIndexStringType>()
        .Where(w => w.Resource.IsCurrent == false);
      RowsRemovedCount = RowsRemovedCount + DeleteIndex(StringIndexList, RowsRemovedCount);

      var TokenIndexList = IPyroDbContext.Set<ResIndexTokenType>()
       .Where(w => w.Resource.IsCurrent == false);
      RowsRemovedCount = RowsRemovedCount + DeleteIndex(TokenIndexList, RowsRemovedCount);

      var UriIndexList = IPyroDbContext.Set<ResIndexUriType>()
       .Where(w => w.Resource.IsCurrent == false);
      RowsRemovedCount = RowsRemovedCount + DeleteIndex(UriIndexList, RowsRemovedCount);

      var ReferenceIndexList = IPyroDbContext.Set<ResIndexReferenceType>()
       .Where(w => w.Resource.IsCurrent == false);
      RowsRemovedCount = RowsRemovedCount + DeleteIndex(ReferenceIndexList, RowsRemovedCount);

      var QuantityIndexList = IPyroDbContext.Set<ResIndexQuantityType>()
       .Where(w => w.Resource.IsCurrent == false);
      RowsRemovedCount = RowsRemovedCount + DeleteIndex(QuantityIndexList, RowsRemovedCount);

      var DateTimeIndexList = IPyroDbContext.Set<ResIndexDateTimeType>()
       .Where(w => w.Resource.IsCurrent == false);
      RowsRemovedCount = RowsRemovedCount + DeleteIndex(DateTimeIndexList, RowsRemovedCount);

      this.Save();
      return RowsRemovedCount;
    }

    //public void GetResourceHistoryEntityList(LinqKit.ExpressionStarter<ResCurrentType> Predicate, int StartRecord, List<DtoResource> DtoResourceList)
    //{
    //  var HistoryEntityList = DbGetAll<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(Predicate)
    //     .OrderByDescending(x => x.LastUpdated)
    //     .Skip(StartRecord)
    //     .Take(_NumberOfRecordsPerPage)
    //     .ToList();

    //  if (HistoryEntityList != null)
    //    HistoryEntityList.ForEach(x => DtoResourceList.Add(IndexSettingSupport.SetDtoResource(x, this.RepositoryResourceType)));
    //}

    public void PopulateResourceEntity(ResCurrentType ResourceEntity, Resource Resource, IPyroRequestUri FhirRequestUri)
    {
      IList<DtoServiceSearchParameterLight> SearchParmeters = IServiceSearchParameterCache.GetSearchParameterForResource(Resource.ResourceType.GetLiteral());
      _PopulateResourceEntity(ResourceEntity, Resource, FhirRequestUri, SearchParmeters);
    }

    public void AddResourceIndexes(ResCurrentType ResourceEntity, Resource Resource, IPyroRequestUri FhirRequestUri, IList<DtoServiceSearchParameterLight> SearchParmeters)
    {
      _PopulateResourceEntity(ResourceEntity, Resource, FhirRequestUri, SearchParmeters);
    }

    private void _PopulateResourceEntity(ResCurrentType ResourceEntity, Resource Resource, IPyroRequestUri FhirRequestUri, IList<DtoServiceSearchParameterLight> SearchParametersList)
    {
      Hl7.Fhir.ElementModel.PocoNavigator Navigator = new Hl7.Fhir.ElementModel.PocoNavigator(Resource);
      string Resource_ResourceName = FHIRAllTypes.Resource.GetLiteral();
      foreach (DtoServiceSearchParameterLight SearchParameter in SearchParametersList)
      {
        //Todo: Composite searchParameters are not supported as yet, need to do work to read 
        // the sub search parameters of the composite directly fro the SearchParameter resources.
        if (SearchParameter.Type != SearchParamType.Composite)
        {
          bool SetSearchParameterIndex = true;
          if ((SearchParameter.Resource == Resource_ResourceName && SearchParameter.Name == "_id") ||
            (SearchParameter.Resource == Resource_ResourceName && SearchParameter.Name == "_lastUpdated"))
          {
            SetSearchParameterIndex = false;
          }

          if (SetSearchParameterIndex)
          {
            string Expression = SearchParameter.Expression;
            if (SearchParameter.Resource == Resource_ResourceName)
            {
              //If the Expression is one with a parent resource of Resource then swap it for the actual current resource name
              //For example make 'Resource._tag' be 'Observation._tag' for Observation resources.
              Expression = Resource.TypeName + SearchParameter.Expression.TrimStart(Resource_ResourceName.ToCharArray());
            }

            IEnumerable<IElementNavigator> ResultList = Navigator.Select(Expression, new EvaluationContext(Navigator));
            //Upgrade of FHRI .NET API 
            //IEnumerable<IElementNavigator> ResultList = Navigator.Select(Expression, Navigator);

            foreach (IElementNavigator oElement in ResultList)
            {
              if (oElement != null)
              {
                switch (SearchParameter.Type)
                {
                  case SearchParamType.Number:
                    {
                      ICollection<ResIndexQuantityType> ResourceIndexQuantity = IIndexSetterFactory.CreateNumberSetter().Set(oElement, SearchParameter);
                      if (ResourceIndexQuantity != null)
                        ResourceEntity.IndexQuantityList.AddRange(ResourceIndexQuantity);
                      break;
                    }
                  case SearchParamType.Date:
                    {
                      ICollection<ResIndexDateTimeType> ResourceIndexDateTime = IIndexSetterFactory.CreateDateTimeSetter().Set(oElement, SearchParameter);
                      if (ResourceIndexDateTime != null)
                        ResourceEntity.IndexDateTimeList.AddRange(ResourceIndexDateTime);
                      break;
                    }
                  case SearchParamType.String:
                    {
                      ICollection<ResIndexStringType> ResourceIndexString = IIndexSetterFactory.CreateStringSetter().Set(oElement, SearchParameter);
                      if (ResourceIndexString != null)
                        ResourceEntity.IndexStringList.AddRange(ResourceIndexString);
                      break;
                    }
                  case SearchParamType.Token:
                    {
                      ICollection<ResIndexTokenType> ResourceIndexToken = IIndexSetterFactory.CreateTokenSetter().Set(oElement, SearchParameter);
                      if (ResourceIndexToken != null)
                        ResourceEntity.IndexTokenList.AddRange(ResourceIndexToken);
                      break;
                    }
                  case SearchParamType.Reference:
                    {
                      ICollection<ResIndexReferenceType> ResourceIndexReference = IIndexSetterFactory.CreateReferenceSetter().Set(oElement, SearchParameter);
                      if (ResourceIndexReference != null)
                        ResourceEntity.IndexReferenceList.AddRange(ResourceIndexReference);
                      break;
                    }
                  case SearchParamType.Composite:
                    {
                      break;
                    }
                  case SearchParamType.Quantity:
                    {
                      ICollection<ResIndexQuantityType> ResourceIndexQuantity = IIndexSetterFactory.CreateQuantitySetter().Set(oElement, SearchParameter);
                      if (ResourceIndexQuantity != null)
                        ResourceEntity.IndexQuantityList.AddRange(ResourceIndexQuantity);
                      break;
                    }
                  case SearchParamType.Uri:
                    {
                      ICollection<ResIndexUriType> ResourceIndexUri = IIndexSetterFactory.CreateUriSetter().Set(oElement, SearchParameter);
                      if (ResourceIndexUri != null)
                        ResourceEntity.IndexUriList.AddRange(ResourceIndexUri);
                      break;
                    }
                  default:
                    throw new System.ComponentModel.InvalidEnumArgumentException(SearchParameter.Type.ToString(), (int)SearchParameter.Type, typeof(SearchParamType));
                }
              }
            }
          }
        }
      }
    }

    
  }
}

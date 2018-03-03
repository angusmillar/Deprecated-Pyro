using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Hl7.FhirPath;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Common.Search;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.ServiceRoot;
using Pyro.Common.Extentions;
using Pyro.DataLayer.DbModel.EntityBase;
using Pyro.DataLayer.DbModel.UnitOfWork;
using Pyro.DataLayer.IndexSetter;
using Pyro.DataLayer.Repository.Interfaces;
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
using Pyro.Common.Interfaces.Dto;

namespace Pyro.DataLayer.Repository
{
  public class CommonResourceRepository<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType> :
    CommonRepository,
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
    private readonly IDatabaseOperationOutcomeFactory IDatabaseOperationOutcomeFactory;

    public CommonResourceRepository(IPyroDbContext Context,
      IPrimaryServiceRootCache IPrimaryServiceRootCache,
      IIndexSetterFactory<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType> IIndexSetterFactory,
      IServiceSearchParameterCache IServiceSearchParameterCache,
      IDatabaseOperationOutcomeFactory IDatabaseOperationOutcomeFactory,
      IDtoRootUrlStoreFactory IDtoRootUrlStoreFactory,
      IGlobalProperties IGlobalProperties)
      : base(Context, IPrimaryServiceRootCache, IDtoRootUrlStoreFactory, IGlobalProperties)
    {
      this.IIndexSetterFactory = IIndexSetterFactory;
      this.IServiceSearchParameterCache = IServiceSearchParameterCache;
      this.IDatabaseOperationOutcomeFactory = IDatabaseOperationOutcomeFactory;
    }

    //Used for _include and _Revinclude
    public string[] GetResourceFhirIdByResourceIdAndIndexReferance(int ResourceId, int[] SearchParameterIdArray, string ResourceName = "")
    {
      LinqKit.ExpressionStarter<ResIndexReferenceType> RefPredicate = null;
      if (string.IsNullOrWhiteSpace(ResourceName))
        RefPredicate = IndexRefPredicateGenerator<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(ResourceId, SearchParameterIdArray);
      else
        RefPredicate = IndexRefPredicateGenerator<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(ResourceId, SearchParameterIdArray, ResourceName);

      var IndexQuery = DbGetIndexAll<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(RefPredicate);
      var IndexResult = IndexQuery.Select(x => x.ReferenceFhirId).ToArray();
      return IndexResult;
    }

    //Used for Chain Reference Searching
    public string[] GetResourceFhirIdByReferanceIndex(IEnumerable<string> FhirIdArray, string ResourceName, int SearchParameterIdArray)
    {
      LinqKit.ExpressionStarter<ResCurrentType> ResCurrentTypePredicate = null;

      ResCurrentTypePredicate = ResourceCurrentPredicateGeneratorByRefereneNoPaging<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(FhirIdArray, ResourceName, SearchParameterIdArray);

      var Query = DbGetAll<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(ResCurrentTypePredicate);

      var Result = Query.Select(x => x.FhirId).ToArray();
      return Result;
    }

    //Used for Primary Chain Searching
    public string[] GetResourceFhirIdBySearchNoPaging(PyroSearchParameters DtoSearchParameters)
    {
      var Predicate = PredicateGenerator<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(DtoSearchParameters);

      var Query = DbGetAll<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(Predicate);

      //Was just testing the query looked correct
      //var Query2 = Query.Select(x => x.FhirId);
      //string[] FhirIdResultArray = Query2.ToArray();

      string[] FhirIdResultArray = Query.Select(x => x.FhirId).ToArray();
      return FhirIdResultArray;
    }

    public IDatabaseOperationOutcome GetResourceBySearch(PyroSearchParameters DtoSearchParameters, bool WithXml = false)
    {
      SetNumberOfRecordsPerPage(DtoSearchParameters);

      var Predicate = PredicateGenerator<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(DtoSearchParameters);

      int TotalRecordCount = DbGetALLCount<ResCurrentType>(Predicate);
      var Query = DbGetAll<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(Predicate);

      //Todo: Sort not implemented just defaulting to last update order      
      Query = Query.OrderBy(x => x.LastUpdated);

      int ClaculatedPageRequired = Common.Tools.PagingSupport.CalculatePageRequired(DtoSearchParameters.RequiredPageNumber, _NumberOfRecordsPerPage, TotalRecordCount);

      Query = Query.Paging(ClaculatedPageRequired, _NumberOfRecordsPerPage);
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
      DatabaseOperationOutcome.PagesTotal = Common.Tools.PagingSupport.CalculateTotalPages(_NumberOfRecordsPerPage, TotalRecordCount); ;
      DatabaseOperationOutcome.PageRequested = ClaculatedPageRequired;
      DatabaseOperationOutcome.ReturnedResourceList = DtoResourceList;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome GetResourceByFhirID(string FhirId, bool WithXml = false, bool IncludeDeleted = true)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = IDatabaseOperationOutcomeFactory.CreateDatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      Pyro.Common.BusinessEntities.Dto.DtoResource DtoResource = null;
      if (WithXml)
      {
        if (IncludeDeleted)
          DtoResource = DbGetWithXML<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(x => x.FhirId == FhirId & x.IsCurrent == true);
        else
          DtoResource = DbGetWithXML<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(x => x.FhirId == FhirId & x.IsCurrent == true & x.IsDeleted == false);
      }
      else
      {
        if (IncludeDeleted)
          DtoResource = DbGetNoXML<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(x => x.FhirId == FhirId & x.IsCurrent == true);
        else
          DtoResource = DbGetNoXML<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(x => x.FhirId == FhirId & x.IsCurrent == true & x.IsDeleted == false);
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
        var ResourceHistoryEntity = DbGet<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(x => x.FhirId == FhirResourceId && x.VersionId == ResourceVersionNumber);
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
        int TotalRecordCount = DbGetALLCount<ResCurrentType>(Predicate);
        var Query = DbGetAll<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(Predicate);

        //Todo: Sort not implemented just defaulting to last update order
        //Query = Query.OrderBy(x => x.lastUpdated);
        //int ClaculatedPageRequired = PaginationSupport.CalculatePageRequired(DtoSearchParameters.RequiredPageNumber, _NumberOfRecordsPerPage, TotalRecordCount);

        //Query = Query.Paging(ClaculatedPageRequired, _NumberOfRecordsPerPage);
        var DtoResourceList = new List<Common.BusinessEntities.Dto.DtoResource>();
        Query.ToList().ForEach(x => DtoResourceList.Add(IndexSettingSupport.SetDtoResource<ResourceBase>(x, this.RepositoryResourceType)));

      }
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome GetResourceHistoryByFhirID(string FhirResourceId, PyroSearchParameters DtoSearchParameters)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = IDatabaseOperationOutcomeFactory.CreateDatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = false;

      SetNumberOfRecordsPerPage(DtoSearchParameters);

      var Predicate = LinqKit.PredicateBuilder.New<ResCurrentType>(true);
      Predicate = Predicate.And(x => x.FhirId == FhirResourceId);

      //Query for total count
      int TotalRecordCount = DbGetALLCount<ResCurrentType>(Predicate);

      //Paging set-up
      var Query = DbGetAll<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(Predicate);

      //Which way to order, touchstone tests failing for history due to wrong way, have changed to Descending to see if they pass 
      //Query = Query.OrderBy(x => x.LastUpdated);
      Query = Query.OrderByDescending(x => x.LastUpdated);

      int ClaculatedPageRequired = Common.Tools.PagingSupport.CalculatePageRequired(DtoSearchParameters.RequiredPageNumber, _NumberOfRecordsPerPage, TotalRecordCount);
      Query = Query.Paging(ClaculatedPageRequired, _NumberOfRecordsPerPage);
      int PagesTotal = Common.Tools.PagingSupport.CalculateTotalPages(_NumberOfRecordsPerPage, TotalRecordCount);

      //Query for Resources
      var HistoryEntityList = Query.ToList();

      //Convert to DTO
      var DtoResourceList = new List<DtoResource>();
      if (HistoryEntityList != null)
        HistoryEntityList.ForEach(x => DtoResourceList.Add(IndexSettingSupport.SetDtoResource(x, this.RepositoryResourceType)));

      DatabaseOperationOutcome.SingleResourceRead = false;
      DatabaseOperationOutcome.SearchTotal = TotalRecordCount;
      DatabaseOperationOutcome.PagesTotal = Common.Tools.PagingSupport.CalculateTotalPages(_NumberOfRecordsPerPage, TotalRecordCount);
      DatabaseOperationOutcome.PageRequested = Common.Tools.PagingSupport.CalculatePageRequired(DtoSearchParameters.RequiredPageNumber, _NumberOfRecordsPerPage, TotalRecordCount);
      DatabaseOperationOutcome.ReturnedResourceList = DtoResourceList;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IPyroRequestUri FhirRequestUri)
    {
      var ResourceEntity = new ResCurrentType();
      IndexSettingSupport.SetResourceBaseAddOrUpdate(Resource, ResourceEntity, Common.Tools.ResourceVersionNumber.FirstVersion(), false, Bundle.HTTPVerb.POST);
      this.PopulateResourceEntity(ResourceEntity, Resource, FhirRequestUri);
      ResourceEntity.IsCurrent = true;
      this.DbAddEntity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(ResourceEntity);
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
      IndexSettingSupport.SetResourceBaseAddOrUpdate(Resource, NewResourceEntity, ResourceVersion, false, Bundle.HTTPVerb.PUT);
      this.PopulateResourceEntity(NewResourceEntity, Resource, FhirRequestUri);
      NewResourceEntity.IsCurrent = true;
      this.DbAddEntity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(NewResourceEntity);
      this.Save();
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
      this.DbAddEntity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(NewResourceEntity);
      OldResourceEntity.IsCurrent = false;
      this.Save();
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
        this.DbAddEntity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(NewResourceEntity);
        OldResourceEntity.IsCurrent = false;

        DatabaseOperationOutcome.ReturnedResourceList.Add(IndexSettingSupport.SetDtoResource(NewResourceEntity, this.RepositoryResourceType));
      }
      this.Save();
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

      var ResourceEntity = DbQueryEntityWithInclude<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(x => x.FhirId == FhirId & x.IsCurrent == true, IncludeList);
      return ResourceEntity;
    }

    public int GetTotalCurrentResourceCount()
    {
      return DbGetALLCount<ResCurrentType>(x => x.IsCurrent == true);
    }

    public DateTimeOffset? GetLastCurrentResourceLastUpdatedValue()
    {
      var LastEntity = IPyroDbContext.Set<ResCurrentType>().Max(x => x.LastUpdated);
      if (LastEntity != null)
        return LastEntity;
      else
        return null;
    }

    public void AddCurrentResourceIndex(List<ServiceSearchParameterLight> ServiceSearchParameterLightList, IPyroRequestUri FhirRequestUri)
    {
      int ChunkSize = 100;
      int ProgressCount = 0;
      var Count = DbGetAll<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(x => x.IsCurrent == true & x.IsDeleted == false).Count();

      while (Count > ProgressCount)
      {
        var EntityList = DbGetAll<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(x => x.IsCurrent == true & x.IsDeleted == false)
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

    public void GetResourceHistoryEntityList(LinqKit.ExpressionStarter<ResCurrentType> Predicate, int StartRecord, List<DtoResource> DtoResourceList)
    {
      var HistoryEntityList = DbGetAll<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(Predicate)
         .OrderByDescending(x => x.LastUpdated)
         .Skip(StartRecord)
         .Take(_NumberOfRecordsPerPage)
         .ToList();

      if (HistoryEntityList != null)
        HistoryEntityList.ForEach(x => DtoResourceList.Add(IndexSettingSupport.SetDtoResource(x, this.RepositoryResourceType)));
    }

    public void PopulateResourceEntity(ResCurrentType ResourceEntity, Resource Resource, IPyroRequestUri FhirRequestUri)
    {
      IList<ServiceSearchParameterLight> SearchParmeters = IServiceSearchParameterCache.GetSearchParameterForResource(Resource.ResourceType.GetLiteral());
      _PopulateResourceEntity(ResourceEntity, Resource, FhirRequestUri, SearchParmeters);
    }

    public void AddResourceIndexes(ResCurrentType ResourceEntity, Resource Resource, IPyroRequestUri FhirRequestUri, IList<ServiceSearchParameterLight> SearchParmeters)
    {
      _PopulateResourceEntity(ResourceEntity, Resource, FhirRequestUri, SearchParmeters);
    }

    private void _PopulateResourceEntity(ResCurrentType ResourceEntity, Resource Resource, IPyroRequestUri FhirRequestUri, IList<ServiceSearchParameterLight> SearchParametersList)
    {
      Hl7.Fhir.ElementModel.PocoNavigator Navigator = new Hl7.Fhir.ElementModel.PocoNavigator(Resource);
      string Resource_ResourceName = FHIRAllTypes.Resource.GetLiteral();
      foreach (ServiceSearchParameterLight SearchParameter in SearchParametersList)
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

    private void SetNumberOfRecordsPerPage(PyroSearchParameters DtoSearchParameters)
    {
      if (DtoSearchParameters.CountOfRecordsRequested.HasValue)
      {
        if (DtoSearchParameters.CountOfRecordsRequested.Value <= _MaxNumberOfRecordsPerPage)
        {
          _NumberOfRecordsPerPage = DtoSearchParameters.CountOfRecordsRequested.Value;
        }
        else
        {
          _NumberOfRecordsPerPage = _MaxNumberOfRecordsPerPage;
        }
      }
    }
  }
}

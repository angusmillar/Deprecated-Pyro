using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using Pyro.DataLayer.DbModel.EntityGenerated;
using Pyro.DataLayer.DbModel.EntityBase;
using Pyro.DataLayer.Support;
using Pyro.DataLayer.IndexSetter;
//using Pyro.DataModel.Support;
//using Pyro.DataModel.IndexSetter;
using Pyro.Common.BusinessEntities.Search;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.BusinessEntities.Dto;
//using Pyro.DataModel.Search;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Hl7.FhirPath;
using Hl7.Fhir.ElementModel;
using Pyro.DataLayer.Repository.Interfaces;

namespace Pyro.DataLayer.Repository
{
  public class CommonResourceRepository<ResourceCurrentType, ResourceHistoryType, ResourceIndexType> : CommonRepository, IResourceRepository
    where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceHistoryType, ResourceIndexType>, new()
    where ResourceHistoryType : ResourceHistoryBase<ResourceCurrentType>, new()
    where ResourceIndexType : ResourceIndexBase, new()
  {
    public FHIRAllTypes RepositoryResourceType { get; }

    public CommonResourceRepository(Pyro.DataLayer.DbModel.DatabaseContext.PyroDbContext Context, FHIRAllTypes RepositoryResourceType)
      : base(Context)
    {
      this.RepositoryResourceType = RepositoryResourceType;
    }

    public IDatabaseOperationOutcome GetResourceBySearch(DtoSearchParameters DtoSearchParameters, bool WithXml = false)
    {
      //SetNumberOfRecordsPerPage(DtoSearchParameters);

      //var Predicate = PredicateGenerator<ResourceIndexType>(DtoSearchParameters);
      //int TotalRecordCount = DbGetALLCount<ResourceIndexType>(Predicate);
      //var Query = DbGetAll<ResourceCurrentType>(Predicate);

      ////Todo: Sort not implemented just defaulting to last update order
      //Query = Query.OrderBy(x => x.LastUpdated);
      //int ClaculatedPageRequired = Common.Tools.PagingSupport.CalculatePageRequired(DtoSearchParameters.RequiredPageNumber, _NumberOfRecordsPerPage, TotalRecordCount);

      //Query = Query.Paging(ClaculatedPageRequired, _NumberOfRecordsPerPage);
      //var DtoResourceList = new List<DtoResource>();
      //if (WithXml)
      //{
      //  DtoResourceList = Query.Select(x => new DtoResource
      //  {
      //    FhirId = x.FhirId,
      //    IsDeleted = x.IsDeleted,
      //    IsCurrent = true,
      //    Version = x.VersionId,
      //    Received = x.LastUpdated,
      //    Method = x.Method,
      //    ResourceType = this.RepositoryResourceType,
      //    Xml = x.XmlBlob
      //  }).ToList();
      //}
      //else
      //{
      //  DtoResourceList = Query.Select(x => new DtoResource
      //  {
      //    FhirId = x.FhirId,
      //    IsDeleted = x.IsDeleted,
      //    IsCurrent = true,
      //    Version = x.VersionId,
      //    Received = x.LastUpdated,
      //    Method = x.Method,
      //    ResourceType = this.RepositoryResourceType
      //  }).ToList();
      //}

      IDatabaseOperationOutcome DatabaseOperationOutcome = Common.CommonFactory.GetDatabaseOperationOutcome();
      //DatabaseOperationOutcome.SingleResourceRead = false;
      //DatabaseOperationOutcome.SearchTotal = TotalRecordCount;
      //DatabaseOperationOutcome.PagesTotal = Common.Tools.PagingSupport.CalculateTotalPages(_NumberOfRecordsPerPage, TotalRecordCount); ;
      //DatabaseOperationOutcome.PageRequested = ClaculatedPageRequired;
      //DatabaseOperationOutcome.ReturnedResourceList = DtoResourceList;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome GetResourceByFhirID(string FhirResourceId, bool WithXml = false)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = Common.CommonFactory.GetDatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      Pyro.Common.BusinessEntities.Dto.DtoResource DtoResource = null;
      if (WithXml)
      {
        DtoResource = DbGetAll<ResourceBase>(x => x.FhirId == FhirResourceId)
          .Select(x => new Pyro.Common.BusinessEntities.Dto.DtoResource
          {
            FhirId = x.FhirId,
            IsDeleted = x.IsDeleted,
            IsCurrent = true,
            Version = x.VersionId,
            Received = x.LastUpdated,
            Method = x.Method,
            ResourceType = this.RepositoryResourceType,
            Xml = x.XmlBlob
          }).SingleOrDefault();
      }
      else
      {
        DtoResource = DbGetAll<ResourceBase>(x => x.FhirId == FhirResourceId)
          .Select(x => new Pyro.Common.BusinessEntities.Dto.DtoResource
          {
            FhirId = x.FhirId,
            IsDeleted = x.IsDeleted,
            IsCurrent = true,
            Version = x.VersionId,
            Received = x.LastUpdated,
            Method = x.Method,
            ResourceType = this.RepositoryResourceType
          }).SingleOrDefault();
      }
      if (DtoResource != null)
        DatabaseOperationOutcome.ReturnedResourceList.Add(DtoResource);
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = Common.CommonFactory.GetDatabaseOperationOutcome();

      if (!string.IsNullOrWhiteSpace(ResourceVersionNumber))
      {
        DatabaseOperationOutcome.SingleResourceRead = true;
        var ResourceHistoryEntity = DbGet<ResourceCurrentType, ResourceHistoryType, ResourceIndexType>(x => x.FhirId == FhirResourceId && x.VersionId == ResourceVersionNumber);
        if (ResourceHistoryEntity != null)
        {
          DatabaseOperationOutcome.ReturnedResourceList.Add(IndexSettingSupport.SetDtoResource(ResourceHistoryEntity, this.RepositoryResourceType, false));
        }
        else
        {
          var ResourceEntity = DbGet<ResourceCurrentType, ResourceHistoryType, ResourceIndexType>(x => x.FhirId == FhirResourceId && x.VersionId == ResourceVersionNumber);
          if (ResourceEntity != null)
            DatabaseOperationOutcome.ReturnedResourceList.Add(IndexSettingSupport.SetDtoResource(ResourceEntity, this.RepositoryResourceType, true));
        }
      }
      else
      {

        DatabaseOperationOutcome.SingleResourceRead = false;
        var Predicate = LinqKit.PredicateBuilder.New<ResourceBase>(true);
        Predicate = Predicate.And(x => x.FhirId == FhirResourceId);
        int TotalRecordCount = DbGetALLCount<ResourceBase>(Predicate);
        var Query = DbGetAll<ResourceBase>(Predicate);

        //Todo: Sort not implemented just defaulting to last update order
        //Query = Query.OrderBy(x => x.lastUpdated);
        //int ClaculatedPageRequired = PaginationSupport.CalculatePageRequired(DtoSearchParameters.RequiredPageNumber, _NumberOfRecordsPerPage, TotalRecordCount);

        //Query = Query.Paging(ClaculatedPageRequired, _NumberOfRecordsPerPage);
        var DtoResourceList = new List<Common.BusinessEntities.Dto.DtoResource>();
        Query.ToList().ForEach(x => DtoResourceList.Add(IndexSettingSupport.SetDtoResource<ResourceBase>(x, this.RepositoryResourceType, true)));

      }
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome GetResourceHistoryByFhirID(string FhirResourceId, DtoSearchParameters DtoSearchParameters)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = Common.CommonFactory.GetDatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = false;
      int TotalRecordCount = 0;
      SetNumberOfRecordsPerPage(DtoSearchParameters);

      var DtoResourceList = new List<DtoResource>();

      var Predicate = LinqKit.PredicateBuilder.New<ResourceCurrentType>(true);
      Predicate = Predicate.And(x => x.FhirId == FhirResourceId);
      ResourceCurrentType CurrentResourceEntity = DbGet<ResourceCurrentType, ResourceHistoryType, ResourceIndexType>(Predicate);

      if (CurrentResourceEntity != null)
      {
        TotalRecordCount++;
        //If page one required then add the current record to the return list as first.
        if (DtoSearchParameters.RequiredPageNumber <= 1)
        {
          _NumberOfRecordsPerPage--;
          DtoResourceList.Add(IndexSettingSupport.SetDtoResource(CurrentResourceEntity, RepositoryResourceType, true));
        }
      }

      TotalRecordCount = TotalRecordCount + GetResourceHistoryEntityCount(Predicate);



      int StartRecord = 0;
      int PagesTotal = Common.Tools.PagingSupport.CalculateTotalPages(_NumberOfRecordsPerPage, TotalRecordCount);
      if (DtoSearchParameters.RequiredPageNumber > PagesTotal)
        StartRecord = (_NumberOfRecordsPerPage * (PagesTotal - 1)) - 1;
      else if (DtoSearchParameters.RequiredPageNumber > 1)
        StartRecord = (_NumberOfRecordsPerPage * (DtoSearchParameters.RequiredPageNumber - 1)) - 1;

      GetResourceHistoryEntityList(Predicate, StartRecord, DtoResourceList);

      DatabaseOperationOutcome.SingleResourceRead = false;
      DatabaseOperationOutcome.SearchTotal = TotalRecordCount;
      DatabaseOperationOutcome.PagesTotal = Common.Tools.PagingSupport.CalculateTotalPages(_NumberOfRecordsPerPage, TotalRecordCount);
      DatabaseOperationOutcome.PageRequested = Common.Tools.PagingSupport.CalculatePageRequired(DtoSearchParameters.RequiredPageNumber, _NumberOfRecordsPerPage, TotalRecordCount);
      DatabaseOperationOutcome.ReturnedResourceList = DtoResourceList;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceEntity = new ResourceCurrentType();
      IndexSettingSupport.SetResourceBaseAddOrUpdate(Resource, ResourceEntity, Common.Tools.ResourceVersionNumber.FirstVersion(), false, Bundle.HTTPVerb.POST);
      var test = this.RepositoryResourceType;
      this.PopulateResourceEntity(ResourceEntity, Common.Tools.ResourceVersionNumber.FirstVersion(), Resource, FhirRequestUri);
      this.DbAddEntity<ResourceCurrentType, ResourceHistoryType, ResourceIndexType>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = Common.CommonFactory.GetDatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      DatabaseOperationOutcome.ReturnedResourceList.Add(IndexSettingSupport.SetDtoResource(ResourceEntity, this.RepositoryResourceType, true));
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceHistoryEntity = new ResourceHistoryType();
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      this.AddResourceHistoryEntityToResourceEntity(ResourceEntity, ResourceHistoryEntity);
      IndexSettingSupport.ResetResourceEntityBase(ResourceEntity);
      this.ResetResourceEntity(ResourceEntity);
      IndexSettingSupport.SetResourceBaseAddOrUpdate(Resource, ResourceEntity, ResourceVersion, false, Bundle.HTTPVerb.PUT);
      this.PopulateResourceEntity(ResourceEntity, ResourceVersion, Resource, FhirRequestUri);
      this.Save();
      IDatabaseOperationOutcome DatabaseOperationOutcome = Common.CommonFactory.GetDatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      DatabaseOperationOutcome.ReturnedResourceList.Add(IndexSettingSupport.SetDtoResource(ResourceEntity, this.RepositoryResourceType, true));
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResouceIdAsDeleted(string FhirResourceId)
    {
      var ResourceHistoryEntity = new ResourceHistoryType();
      var ResourceEntity = this.LoadCurrentResourceEntity(FhirResourceId);
      string NewDeletedResourceVersion = Common.Tools.ResourceVersionNumber.Increment(ResourceEntity.VersionId);
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      this.AddResourceHistoryEntityToResourceEntity(ResourceEntity, ResourceHistoryEntity);
      IndexSettingSupport.ResetResourceEntityBase(ResourceEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.FhirId = FhirResourceId;
      ResourceEntity.IsDeleted = true;
      ResourceEntity.VersionId = NewDeletedResourceVersion;
      ResourceEntity.XmlBlob = string.Empty;
      ResourceEntity.LastUpdated = DateTimeOffset.Now;
      ResourceEntity.Method = Bundle.HTTPVerb.DELETE;
      this.Save();
      IDatabaseOperationOutcome DatabaseOperationOutcome = Common.CommonFactory.GetDatabaseOperationOutcome();
      DatabaseOperationOutcome.ReturnedResourceList.Add(IndexSettingSupport.SetDtoResource(ResourceEntity, this.RepositoryResourceType, true));
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResouceIdColectionAsDeleted(ICollection<string> ResourceIdCollection)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = Common.CommonFactory.GetDatabaseOperationOutcome();
      foreach (string ResourceId in ResourceIdCollection)
      {
        var ResourceHistoryEntity = new ResourceHistoryType();
        var ResourceEntity = this.LoadCurrentResourceEntity(ResourceId);
        string NewDeletedResourceVersion = Common.Tools.ResourceVersionNumber.Increment(ResourceEntity.VersionId);
        IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
        this.AddResourceHistoryEntityToResourceEntity(ResourceEntity, ResourceHistoryEntity);
        IndexSettingSupport.ResetResourceEntityBase(ResourceEntity);
        this.ResetResourceEntity(ResourceEntity);
        ResourceEntity.FhirId = ResourceId;
        ResourceEntity.IsDeleted = true;
        ResourceEntity.VersionId = NewDeletedResourceVersion;
        ResourceEntity.XmlBlob = string.Empty;
        ResourceEntity.LastUpdated = DateTimeOffset.Now;
        ResourceEntity.Method = Bundle.HTTPVerb.DELETE;
        DatabaseOperationOutcome.ReturnedResourceList.Add(IndexSettingSupport.SetDtoResource(ResourceEntity, this.RepositoryResourceType, true));
      }
      this.Save();
      return DatabaseOperationOutcome;
    }

    private void SetNumberOfRecordsPerPage(DtoSearchParameters DtoSearchParameters)
    {
      if (DtoSearchParameters.CountOfRecordsRequested.HasValue)
      {
        if (DtoSearchParameters.CountOfRecordsRequested.Value < _MaxNumberOfRecordsPerPage)
        {
          _NumberOfRecordsPerPage = DtoSearchParameters.CountOfRecordsRequested.Value;
        }
        else
        {
          _NumberOfRecordsPerPage = _MaxNumberOfRecordsPerPage;
        }
      }
    }

    // --- Abstract Methods -------------------------------------------------------------
    public void GetResourceHistoryEntityList(LinqKit.ExpressionStarter<ResourceCurrentType> Predicate, int StartRecord, List<DtoResource> DtoResourceList)
    {
      var HistoryEntityList = DbGetAll<ResourceCurrentType>(Predicate)
         .SelectMany(y => y.HistoryList)
         .OrderByDescending(x => x.LastUpdated)
         .Skip(StartRecord)
         .Take(_NumberOfRecordsPerPage)
         .ToList();

      if (HistoryEntityList != null)
        HistoryEntityList.ForEach(x => DtoResourceList.Add(IndexSettingSupport.SetDtoResource(x, this.RepositoryResourceType, false)));
    }

    public int GetResourceHistoryEntityCount(LinqKit.ExpressionStarter<ResourceCurrentType> Predicate)
    {
      return DbGetAll<ResourceCurrentType>(Predicate).SelectMany(y => y.HistoryList).Count();
    }

    public void AddResourceHistoryEntityToResourceEntity(ResourceCurrentType ResourceEntity, ResourceHistoryType ResourceHistoryEntity)
    {
      ResourceEntity.HistoryList.Add(ResourceHistoryEntity);
    }

    public void ResetResourceEntity(ResourceCurrentType ResourceEntity)
    {
      ResourceEntity.IndexList.Clear();
      throw new NotImplementedException("Does this line above work like the one below??");
      //_Context.PatientIndex.RemoveRange(ResourceEntity.IndexList);
    }

    public ResourceCurrentType LoadCurrentResourceEntity(string fhirResourceId)
    {
      var IncludeList = new List<Expression<Func<ResourceCurrentType, object>>>();
      IncludeList.Add(x => x.IndexList);

      var ResourceEntity = DbQueryEntityWithInclude<ResourceCurrentType, ResourceHistoryType, ResourceIndexType>(x => x.FhirId == fhirResourceId, IncludeList);
      return ResourceEntity;
    }

    public void PopulateResourceEntity(ResourceCurrentType ResourceEntity, string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      IList<DtoServiceSearchParameterLight> searchparameters = Common.Cache.StaticCacheCommon.GetSearchParameterForResource(this as IDtoCommonRepository, Resource.ResourceType.GetLiteral());
      Hl7.Fhir.FhirPath.PocoNavigator Navigator = new Hl7.Fhir.FhirPath.PocoNavigator(Resource);
      foreach (DtoServiceSearchParameterLight SearchParameter in searchparameters)
      {        
        //Todo: Composite searchParameters are not supported as yet, need to do work to read 
        // the sub search parameters of the composite directly fro the SearchParameter resources.
        if (SearchParameter.Type != SearchParamType.Composite)
        {
          IEnumerable<IElementNavigator> ResultList = Navigator.Select(SearchParameter.Expression, Navigator);
          foreach (IElementNavigator oElement in ResultList)
          {
            if (oElement != null)
            {
              IList<ResourceIndexType> ResourceIndex = IndexSetterFactory.Set<ResourceIndexType>(oElement, SearchParameter, FhirRequestUri, this as ICommonRepository);
              if (ResourceIndex != null)
                ResourceIndex.ToList().ForEach(x => ResourceEntity.IndexList.Add(x));
            }
          }
        }
      }
    }

  }
}

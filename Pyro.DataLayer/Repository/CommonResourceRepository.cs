using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Hl7.FhirPath;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Common.BusinessEntities.Search;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.ServiceRoot;
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

namespace Pyro.DataLayer.Repository
{
  public class CommonResourceRepository<ResourceCurrentType, ResourceIndexType> :
    CommonRepository,
    ICommonResourceRepository<ResourceCurrentType, ResourceIndexType>,
    IResourceRepository
    where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
    where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
  {
    public FHIRAllTypes RepositoryResourceType { get; set; }
    private readonly IIndexSetterFactory IIndexSetterFactory;
    private readonly IServiceSearchParameterCache IServiceSearchParameterCache;

    public CommonResourceRepository(IPyroDbContext Context,
      IPrimaryServiceRootCache IPrimaryServiceRootCache,
      IIndexSetterFactory IIndexSetterFactory,
      IServiceSearchParameterCache IServiceSearchParameterCache,
      ICommonFactory ICommonFactory)
      : base(Context, IPrimaryServiceRootCache, ICommonFactory)
    {
      this.IIndexSetterFactory = IIndexSetterFactory;
      this.IServiceSearchParameterCache = IServiceSearchParameterCache;
    }


    public string[] GetResourceFhirIdByResourceIdAndIndexReferance2(int ResourceId, int[] SearchParameterIdArray, string ResourceName = "")
    {
      LinqKit.ExpressionStarter<ResourceIndexType> RefPredicate = null;
      if (string.IsNullOrWhiteSpace(ResourceName))
        RefPredicate = IndexRefPredicateGenerator2<ResourceCurrentType, ResourceIndexType>(ResourceId, SearchParameterIdArray);
      else
        RefPredicate = IndexRefPredicateGenerator2<ResourceCurrentType, ResourceIndexType>(ResourceId, SearchParameterIdArray, ResourceName);

      var IndexQuery = DbGetIndexAll<ResourceCurrentType, ResourceIndexType>(RefPredicate);
      var IndexResult = IndexQuery.Select(x => x.ReferenceFhirId).ToArray();
      return IndexResult;
    }


    public string[] GetResourceFhirIdByResourceIdAndIndexReferance(int ResourceId, int SearchParameterId)
    {
      var RefPredicate = IndexRefPredicateGenerator<ResourceCurrentType, ResourceIndexType>(ResourceId, SearchParameterId);
      var IndexQuery = DbGetIndexAll<ResourceCurrentType, ResourceIndexType>(RefPredicate);
      var IndexResult = IndexQuery.Select(x => x.ReferenceFhirId).ToArray();
      return IndexResult;
    }


    public IDatabaseOperationOutcome GetResourceBySearch(DtoSearchParameters DtoSearchParameters, bool WithXml = false)
    {
      SetNumberOfRecordsPerPage(DtoSearchParameters);

      var Predicate = PredicateGenerator<ResourceCurrentType, ResourceIndexType>(DtoSearchParameters);

      int TotalRecordCount = DbGetALLCount<ResourceCurrentType>(Predicate);
      var Query = DbGetAll<ResourceCurrentType, ResourceIndexType>(Predicate);

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

      IDatabaseOperationOutcome DatabaseOperationOutcome = ICommonFactory.CreateDatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = false;
      DatabaseOperationOutcome.SearchTotal = TotalRecordCount;
      DatabaseOperationOutcome.PagesTotal = Common.Tools.PagingSupport.CalculateTotalPages(_NumberOfRecordsPerPage, TotalRecordCount); ;
      DatabaseOperationOutcome.PageRequested = ClaculatedPageRequired;
      DatabaseOperationOutcome.ReturnedResourceList = DtoResourceList;
      return DatabaseOperationOutcome;
    }


    public IDatabaseOperationOutcome GetResourceByFhirID(string FhirId, bool WithXml = false, bool IncludeDeleted = true)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = ICommonFactory.CreateDatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      Pyro.Common.BusinessEntities.Dto.DtoResource DtoResource = null;
      if (WithXml)
      {
        if (IncludeDeleted)
          DtoResource = DbGetWithXML<ResourceCurrentType, ResourceIndexType>(x => x.FhirId == FhirId & x.IsCurrent == true);
        else
          DtoResource = DbGetWithXML<ResourceCurrentType, ResourceIndexType>(x => x.FhirId == FhirId & x.IsCurrent == true & x.IsDeleted == false);
      }
      else
      {
        if (IncludeDeleted)
          DtoResource = DbGetNoXML<ResourceCurrentType, ResourceIndexType>(x => x.FhirId == FhirId & x.IsCurrent == true);
        else
          DtoResource = DbGetNoXML<ResourceCurrentType, ResourceIndexType>(x => x.FhirId == FhirId & x.IsCurrent == true & x.IsDeleted == false);
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
      IDatabaseOperationOutcome DatabaseOperationOutcome = ICommonFactory.CreateDatabaseOperationOutcome();

      if (!string.IsNullOrWhiteSpace(ResourceVersionNumber))
      {
        DatabaseOperationOutcome.SingleResourceRead = true;
        var ResourceHistoryEntity = DbGet<ResourceCurrentType, ResourceIndexType>(x => x.FhirId == FhirResourceId && x.VersionId == ResourceVersionNumber);
        if (ResourceHistoryEntity != null)
        {
          DatabaseOperationOutcome.ReturnedResourceList.Add(IndexSettingSupport.SetDtoResource(ResourceHistoryEntity, this.RepositoryResourceType));
        }
      }
      else
      {

        DatabaseOperationOutcome.SingleResourceRead = false;
        var Predicate = LinqKit.PredicateBuilder.New<ResourceCurrentType>(true);
        Predicate = Predicate.And(x => x.FhirId == FhirResourceId);
        int TotalRecordCount = DbGetALLCount<ResourceCurrentType>(Predicate);
        var Query = DbGetAll<ResourceCurrentType, ResourceIndexType>(Predicate);

        //Todo: Sort not implemented just defaulting to last update order
        //Query = Query.OrderBy(x => x.lastUpdated);
        //int ClaculatedPageRequired = PaginationSupport.CalculatePageRequired(DtoSearchParameters.RequiredPageNumber, _NumberOfRecordsPerPage, TotalRecordCount);

        //Query = Query.Paging(ClaculatedPageRequired, _NumberOfRecordsPerPage);
        var DtoResourceList = new List<Common.BusinessEntities.Dto.DtoResource>();
        Query.ToList().ForEach(x => DtoResourceList.Add(IndexSettingSupport.SetDtoResource<ResourceBase>(x, this.RepositoryResourceType)));

      }
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome GetResourceHistoryByFhirID(string FhirResourceId, DtoSearchParameters DtoSearchParameters)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = ICommonFactory.CreateDatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = false;

      SetNumberOfRecordsPerPage(DtoSearchParameters);

      var Predicate = LinqKit.PredicateBuilder.New<ResourceCurrentType>(true);
      Predicate = Predicate.And(x => x.FhirId == FhirResourceId);

      //Query for total count
      int TotalRecordCount = DbGetALLCount<ResourceCurrentType>(Predicate);

      //Paging set-up
      var Query = DbGetAll<ResourceCurrentType, ResourceIndexType>(Predicate);
      Query = Query.OrderBy(x => x.LastUpdated);
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

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoRequestUri FhirRequestUri)
    {
      var ResourceEntity = new ResourceCurrentType();
      IndexSettingSupport.SetResourceBaseAddOrUpdate(Resource, ResourceEntity, Common.Tools.ResourceVersionNumber.FirstVersion(), false, Bundle.HTTPVerb.POST);
      this.PopulateResourceEntity(ResourceEntity, Resource, FhirRequestUri);
      ResourceEntity.IsCurrent = true;
      this.DbAddEntity<ResourceCurrentType, ResourceIndexType>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = ICommonFactory.CreateDatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      DatabaseOperationOutcome.ReturnedResourceList.Add(IndexSettingSupport.SetDtoResource(ResourceEntity, this.RepositoryResourceType));
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoRequestUri FhirRequestUri)
    {
      var NewResourceEntity = new ResourceCurrentType();
      var ResourceHistoryEntity = LoadCurrentResourceEntity(Resource.Id);
      ResourceHistoryEntity.IsCurrent = false;
      IndexSettingSupport.SetResourceBaseAddOrUpdate(Resource, NewResourceEntity, ResourceVersion, false, Bundle.HTTPVerb.PUT);
      this.PopulateResourceEntity(NewResourceEntity, Resource, FhirRequestUri);
      NewResourceEntity.IsCurrent = true;
      this.DbAddEntity<ResourceCurrentType, ResourceIndexType>(NewResourceEntity);
      this.Save();
      IDatabaseOperationOutcome DatabaseOperationOutcome = ICommonFactory.CreateDatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      DatabaseOperationOutcome.ReturnedResourceList.Add(IndexSettingSupport.SetDtoResource(NewResourceEntity, this.RepositoryResourceType));
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResouceIdAsDeleted(string FhirId)
    {
      var OldResourceEntity = this.LoadCurrentResourceEntity(FhirId);
      var NewResourceEntity = new ResourceCurrentType();
      IndexSettingSupport.SetHistoryResourceEntity(OldResourceEntity, NewResourceEntity);
      string NewDeletedResourceVersion = Common.Tools.ResourceVersionNumber.Increment(OldResourceEntity.VersionId);
      NewResourceEntity.IsCurrent = true;
      NewResourceEntity.IsDeleted = true;
      NewResourceEntity.LastUpdated = DateTimeOffset.Now;
      NewResourceEntity.Method = Bundle.HTTPVerb.DELETE;
      NewResourceEntity.XmlBlob = string.Empty;
      NewResourceEntity.VersionId = NewDeletedResourceVersion;
      this.DbAddEntity<ResourceCurrentType, ResourceIndexType>(NewResourceEntity);
      OldResourceEntity.IsCurrent = false;
      this.Save();
      IDatabaseOperationOutcome DatabaseOperationOutcome = ICommonFactory.CreateDatabaseOperationOutcome();
      DatabaseOperationOutcome.ReturnedResourceList.Add(IndexSettingSupport.SetDtoResource(NewResourceEntity, this.RepositoryResourceType));
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResouceIdColectionAsDeleted(ICollection<string> ResourceIdCollection)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = ICommonFactory.CreateDatabaseOperationOutcome();
      foreach (string ResourceId in ResourceIdCollection)
      {
        var OldResourceEntity = this.LoadCurrentResourceEntity(ResourceId);
        var NewResourceEntity = new ResourceCurrentType();
        IndexSettingSupport.SetHistoryResourceEntity(OldResourceEntity, NewResourceEntity);
        string NewDeletedResourceVersion = Common.Tools.ResourceVersionNumber.Increment(OldResourceEntity.VersionId);
        NewResourceEntity.IsCurrent = true;
        NewResourceEntity.IsDeleted = true;
        NewResourceEntity.LastUpdated = DateTimeOffset.Now;
        NewResourceEntity.Method = Bundle.HTTPVerb.DELETE;
        NewResourceEntity.XmlBlob = string.Empty;
        NewResourceEntity.VersionId = NewDeletedResourceVersion;
        this.DbAddEntity<ResourceCurrentType, ResourceIndexType>(NewResourceEntity);
        OldResourceEntity.IsCurrent = false;

        DatabaseOperationOutcome.ReturnedResourceList.Add(IndexSettingSupport.SetDtoResource(NewResourceEntity, this.RepositoryResourceType));
      }
      this.Save();
      return DatabaseOperationOutcome;
    }

    public ResourceCurrentType LoadCurrentResourceEntity(string FhirId)
    {
      var IncludeList = new List<Expression<Func<ResourceCurrentType, object>>>();
      IncludeList.Add(x => x.IndexList);

      var ResourceEntity = DbQueryEntityWithInclude<ResourceCurrentType, ResourceIndexType>(x => x.FhirId == FhirId & x.IsCurrent == true, IncludeList);
      return ResourceEntity;
    }

    public int GetTotalCurrentResourceCount()
    {
      return DbGetALLCount<ResourceCurrentType>(x => x.IsCurrent == true);
    }

    public DateTimeOffset? GetLastCurrentResourceLastUpdatedValue()
    {
      var LastEntity = IPyroDbContext.Set<ResourceCurrentType>().Max(x => x.LastUpdated);
      if (LastEntity != null)
        return LastEntity;
      else
        return null;
    }

    public void AddCurrentResourceIndex(List<DtoServiceSearchParameterLight> ServiceSearchParameterLightList, IDtoRequestUri FhirRequestUri)
    {
      int ChunkSize = 100;
      int ProgressCount = 0;
      var Count = DbGetAll<ResourceCurrentType, ResourceIndexType>(x => x.IsCurrent == true & x.IsDeleted == false).Count();

      while (Count > ProgressCount)
      {
        var EntityList = DbGetAll<ResourceCurrentType, ResourceIndexType>(x => x.IsCurrent == true & x.IsDeleted == false)
         .Include(x => x.IndexList)
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

    public int DeleteNonCurrentResourceIndexes()
    {
      int RowsRemovedCount = 0;
      var IndexList = IPyroDbContext.Set<ResourceIndexType>()
        .Where(w => w.Resource.IsCurrent == false);

      foreach (ResourceIndexType Index in IndexList)
      {
        RowsRemovedCount = RowsRemovedCount + 1;
        (IPyroDbContext as IObjectContextAdapter).ObjectContext.DeleteObject(Index);
      }
      //Old Way
      //var ListToRemove = _Context.Set<ResourceIndexType>().Where(x => x.Resource.IsCurrent == false).ToList();
      //RowsRemovedCount = ListToRemove.Count;
      //ListToRemove.ForEach(x => _Context.Set<ResourceIndexType>().Remove(x));
      this.Save();
      return RowsRemovedCount;
    }

    public void GetResourceHistoryEntityList(LinqKit.ExpressionStarter<ResourceCurrentType> Predicate, int StartRecord, List<DtoResource> DtoResourceList)
    {
      var HistoryEntityList = DbGetAll<ResourceCurrentType, ResourceIndexType>(Predicate)
         .OrderByDescending(x => x.LastUpdated)
         .Skip(StartRecord)
         .Take(_NumberOfRecordsPerPage)
         .ToList();

      if (HistoryEntityList != null)
        HistoryEntityList.ForEach(x => DtoResourceList.Add(IndexSettingSupport.SetDtoResource(x, this.RepositoryResourceType)));
    }

    public void ResetResourceEntity(ResourceCurrentType ResourceEntity)
    {
      ResourceEntity.IndexList.Clear();
      throw new NotImplementedException("Does this line above work like the one below??");
      //_Context.PatientIndex.RemoveRange(ResourceEntity.IndexList);
    }

    public void PopulateResourceEntity(ResourceCurrentType ResourceEntity, Resource Resource, IDtoRequestUri FhirRequestUri)
    {
      IList<DtoServiceSearchParameterLight> SearchParmeters = IServiceSearchParameterCache.GetSearchParameterForResource(Resource.ResourceType.GetLiteral());
      _PopulateResourceEntity(ResourceEntity, Resource, FhirRequestUri, SearchParmeters);
    }

    public void AddResourceIndexes(ResourceCurrentType ResourceEntity, Resource Resource, IDtoRequestUri FhirRequestUri, IList<DtoServiceSearchParameterLight> SearchParmeters)
    {
      _PopulateResourceEntity(ResourceEntity, Resource, FhirRequestUri, SearchParmeters);
    }

    private void _PopulateResourceEntity(ResourceCurrentType ResourceEntity, Resource Resource, IDtoRequestUri FhirRequestUri, IList<DtoServiceSearchParameterLight> SearchParametersList)
    {
      Hl7.Fhir.FhirPath.PocoNavigator Navigator = new Hl7.Fhir.FhirPath.PocoNavigator(Resource);
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

            IEnumerable<IElementNavigator> ResultList = Navigator.Select(Expression, Navigator);
            foreach (IElementNavigator oElement in ResultList)
            {
              IList<ResourceIndexType> ResourceIndex = null;
              if (oElement != null)
              {
                switch (SearchParameter.Type)
                {
                  case SearchParamType.Number:
                    {
                      ResourceIndex = IIndexSetterFactory.CreateINumberSetter().Set<ResourceCurrentType, ResourceIndexType>(oElement, SearchParameter);
                      break;
                    }
                  case SearchParamType.Date:
                    {
                      ResourceIndex = IIndexSetterFactory.CreateDateTimeSetter().Set<ResourceCurrentType, ResourceIndexType>(oElement, SearchParameter);
                      break;
                    }
                  case SearchParamType.String:
                    {
                      ResourceIndex = IIndexSetterFactory.CreateStringSetter().Set<ResourceCurrentType, ResourceIndexType>(oElement, SearchParameter);
                      break;
                    }
                  case SearchParamType.Token:
                    {
                      ResourceIndex = IIndexSetterFactory.CreateTokenSetter().Set<ResourceCurrentType, ResourceIndexType>(oElement, SearchParameter);
                      break;
                    }
                  case SearchParamType.Reference:
                    {
                      ResourceIndex = IIndexSetterFactory.CreateReferenceSetter().Set<ResourceCurrentType, ResourceIndexType>(oElement, SearchParameter);
                      break;
                    }
                  case SearchParamType.Composite:
                    {
                      break;
                    }
                  case SearchParamType.Quantity:
                    {
                      ResourceIndex = IIndexSetterFactory.CreateQuantitySetter().Set<ResourceCurrentType, ResourceIndexType>(oElement, SearchParameter);
                      break;
                    }
                  case SearchParamType.Uri:
                    {
                      ResourceIndex = IIndexSetterFactory.CreateUriSetter().Set<ResourceCurrentType, ResourceIndexType>(oElement, SearchParameter);
                      break;
                    }
                  default:
                    throw new System.ComponentModel.InvalidEnumArgumentException(SearchParameter.Type.ToString(), (int)SearchParameter.Type, typeof(SearchParamType));
                }

                if (ResourceIndex != null)
                  ResourceIndex.ToList().ForEach(x => ResourceEntity.IndexList.Add(x));
              }
            }
          }
        }
      }
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
  }
}

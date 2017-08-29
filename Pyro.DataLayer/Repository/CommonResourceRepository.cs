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
  public class CommonResourceRepository<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType> :
    CommonRepository,
    ICommonResourceRepository<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>,
    IResourceRepository
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
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
      LinqKit.ExpressionStarter<ResourceIndexBaseType> RefPredicate = null;
      if (string.IsNullOrWhiteSpace(ResourceName))
        RefPredicate = IndexRefPredicateGenerator2<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(ResourceId, SearchParameterIdArray);
      else
        RefPredicate = IndexRefPredicateGenerator2<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(ResourceId, SearchParameterIdArray, ResourceName);

      var IndexQuery = DbGetIndexAll<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(RefPredicate);
      var IndexResult = IndexQuery.Select(x => x.ReferenceFhirId).ToArray();
      return IndexResult;
    }


    public string[] GetResourceFhirIdByResourceIdAndIndexReferance(int ResourceId, int SearchParameterId)
    {
      var RefPredicate = IndexRefPredicateGenerator<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(ResourceId, SearchParameterId);
      var IndexQuery = DbGetIndexAll<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(RefPredicate);
      var IndexResult = IndexQuery.Select(x => x.ReferenceFhirId).ToArray();
      return IndexResult;
    }


    public IDatabaseOperationOutcome GetResourceBySearch(PyroSearchParameters DtoSearchParameters, bool WithXml = false)
    {
      SetNumberOfRecordsPerPage(DtoSearchParameters);

      var Predicate = PredicateGenerator<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(DtoSearchParameters);

      int TotalRecordCount = DbGetALLCount<ResourceCurrentBaseType>(Predicate);
      var Query = DbGetAll<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Predicate);

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
          DtoResource = DbGetWithXML<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(x => x.FhirId == FhirId & x.IsCurrent == true);
        else
          DtoResource = DbGetWithXML<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(x => x.FhirId == FhirId & x.IsCurrent == true & x.IsDeleted == false);
      }
      else
      {
        if (IncludeDeleted)
          DtoResource = DbGetNoXML<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(x => x.FhirId == FhirId & x.IsCurrent == true);
        else
          DtoResource = DbGetNoXML<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(x => x.FhirId == FhirId & x.IsCurrent == true & x.IsDeleted == false);
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
        var ResourceHistoryEntity = DbGet<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(x => x.FhirId == FhirResourceId && x.VersionId == ResourceVersionNumber);
        if (ResourceHistoryEntity != null)
        {
          DatabaseOperationOutcome.ReturnedResourceList.Add(IndexSettingSupport.SetDtoResource(ResourceHistoryEntity, this.RepositoryResourceType));
        }
      }
      else
      {

        DatabaseOperationOutcome.SingleResourceRead = false;
        var Predicate = LinqKit.PredicateBuilder.New<ResourceCurrentBaseType>(true);
        Predicate = Predicate.And(x => x.FhirId == FhirResourceId);
        int TotalRecordCount = DbGetALLCount<ResourceCurrentBaseType>(Predicate);
        var Query = DbGetAll<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Predicate);

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
      IDatabaseOperationOutcome DatabaseOperationOutcome = ICommonFactory.CreateDatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = false;

      SetNumberOfRecordsPerPage(DtoSearchParameters);

      var Predicate = LinqKit.PredicateBuilder.New<ResourceCurrentBaseType>(true);
      Predicate = Predicate.And(x => x.FhirId == FhirResourceId);

      //Query for total count
      int TotalRecordCount = DbGetALLCount<ResourceCurrentBaseType>(Predicate);

      //Paging set-up
      var Query = DbGetAll<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Predicate);
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

    public IDatabaseOperationOutcome AddResource(Resource Resource, IPyroRequestUri FhirRequestUri)
    {
      var ResourceEntity = new ResourceCurrentBaseType();
      IndexSettingSupport.SetResourceBaseAddOrUpdate(Resource, ResourceEntity, Common.Tools.ResourceVersionNumber.FirstVersion(), false, Bundle.HTTPVerb.POST);
      this.PopulateResourceEntity(ResourceEntity, Resource, FhirRequestUri);
      ResourceEntity.IsCurrent = true;
      this.DbAddEntity<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = ICommonFactory.CreateDatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      DatabaseOperationOutcome.ReturnedResourceList.Add(IndexSettingSupport.SetDtoResource(ResourceEntity, this.RepositoryResourceType));
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IPyroRequestUri FhirRequestUri)
    {
      var NewResourceEntity = new ResourceCurrentBaseType();
      var ResourceHistoryEntity = LoadCurrentResourceEntity(Resource.Id);
      ResourceHistoryEntity.IsCurrent = false;
      IndexSettingSupport.SetResourceBaseAddOrUpdate(Resource, NewResourceEntity, ResourceVersion, false, Bundle.HTTPVerb.PUT);
      this.PopulateResourceEntity(NewResourceEntity, Resource, FhirRequestUri);
      NewResourceEntity.IsCurrent = true;
      this.DbAddEntity<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(NewResourceEntity);
      this.Save();
      IDatabaseOperationOutcome DatabaseOperationOutcome = ICommonFactory.CreateDatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      DatabaseOperationOutcome.ReturnedResourceList.Add(IndexSettingSupport.SetDtoResource(NewResourceEntity, this.RepositoryResourceType));
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResouceIdAsDeleted(string FhirId)
    {
      var OldResourceEntity = this.LoadCurrentResourceEntity(FhirId);
      var NewResourceEntity = new ResourceCurrentBaseType();
      IndexSettingSupport.SetHistoryResourceEntity(OldResourceEntity, NewResourceEntity);
      string NewDeletedResourceVersion = Common.Tools.ResourceVersionNumber.Increment(OldResourceEntity.VersionId);
      NewResourceEntity.IsCurrent = true;
      NewResourceEntity.IsDeleted = true;
      NewResourceEntity.LastUpdated = DateTimeOffset.Now;
      NewResourceEntity.Method = Bundle.HTTPVerb.DELETE;
      NewResourceEntity.XmlBlob = string.Empty;
      NewResourceEntity.VersionId = NewDeletedResourceVersion;
      this.DbAddEntity<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(NewResourceEntity);
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
        var NewResourceEntity = new ResourceCurrentBaseType();
        IndexSettingSupport.SetHistoryResourceEntity(OldResourceEntity, NewResourceEntity);
        string NewDeletedResourceVersion = Common.Tools.ResourceVersionNumber.Increment(OldResourceEntity.VersionId);
        NewResourceEntity.IsCurrent = true;
        NewResourceEntity.IsDeleted = true;
        NewResourceEntity.LastUpdated = DateTimeOffset.Now;
        NewResourceEntity.Method = Bundle.HTTPVerb.DELETE;
        NewResourceEntity.XmlBlob = string.Empty;
        NewResourceEntity.VersionId = NewDeletedResourceVersion;
        this.DbAddEntity<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(NewResourceEntity);
        OldResourceEntity.IsCurrent = false;

        DatabaseOperationOutcome.ReturnedResourceList.Add(IndexSettingSupport.SetDtoResource(NewResourceEntity, this.RepositoryResourceType));
      }
      this.Save();
      return DatabaseOperationOutcome;
    }

    public ResourceCurrentBaseType LoadCurrentResourceEntity(string FhirId)
    {
      var IncludeList = new List<Expression<Func<ResourceCurrentBaseType, object>>>();
      IncludeList.Add(x => x.IndexList);

      var ResourceEntity = DbQueryEntityWithInclude<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(x => x.FhirId == FhirId & x.IsCurrent == true, IncludeList);
      return ResourceEntity;
    }

    public int GetTotalCurrentResourceCount()
    {
      return DbGetALLCount<ResourceCurrentBaseType>(x => x.IsCurrent == true);
    }

    public DateTimeOffset? GetLastCurrentResourceLastUpdatedValue()
    {
      var LastEntity = IPyroDbContext.Set<ResourceCurrentBaseType>().Max(x => x.LastUpdated);
      if (LastEntity != null)
        return LastEntity;
      else
        return null;
    }

    public void AddCurrentResourceIndex(List<ServiceSearchParameterLight> ServiceSearchParameterLightList, IPyroRequestUri FhirRequestUri)
    {
      int ChunkSize = 100;
      int ProgressCount = 0;
      var Count = DbGetAll<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(x => x.IsCurrent == true & x.IsDeleted == false).Count();

      while (Count > ProgressCount)
      {
        var EntityList = DbGetAll<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(x => x.IsCurrent == true & x.IsDeleted == false)
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
      var IndexList = IPyroDbContext.Set<ResourceIndexBaseType>()
        .Where(w => w.Resource.IsCurrent == false);

      foreach (ResourceIndexBaseType Index in IndexList)
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

    public void GetResourceHistoryEntityList(LinqKit.ExpressionStarter<ResourceCurrentBaseType> Predicate, int StartRecord, List<DtoResource> DtoResourceList)
    {
      var HistoryEntityList = DbGetAll<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Predicate)
         .OrderByDescending(x => x.LastUpdated)
         .Skip(StartRecord)
         .Take(_NumberOfRecordsPerPage)
         .ToList();

      if (HistoryEntityList != null)
        HistoryEntityList.ForEach(x => DtoResourceList.Add(IndexSettingSupport.SetDtoResource(x, this.RepositoryResourceType)));
    }

    public void ResetResourceEntity(ResourceCurrentBaseType ResourceEntity)
    {
      ResourceEntity.IndexList.Clear();
      throw new NotImplementedException("Does this line above work like the one below??");
      //_Context.PatientIndex.RemoveRange(ResourceEntity.IndexList);
    }

    public void PopulateResourceEntity(ResourceCurrentBaseType ResourceEntity, Resource Resource, IPyroRequestUri FhirRequestUri)
    {
      IList<ServiceSearchParameterLight> SearchParmeters = IServiceSearchParameterCache.GetSearchParameterForResource(Resource.ResourceType.GetLiteral());
      _PopulateResourceEntity(ResourceEntity, Resource, FhirRequestUri, SearchParmeters);
    }

    public void AddResourceIndexes(ResourceCurrentBaseType ResourceEntity, Resource Resource, IPyroRequestUri FhirRequestUri, IList<ServiceSearchParameterLight> SearchParmeters)
    {
      _PopulateResourceEntity(ResourceEntity, Resource, FhirRequestUri, SearchParmeters);
    }

    private void _PopulateResourceEntity(ResourceCurrentBaseType ResourceEntity, Resource Resource, IPyroRequestUri FhirRequestUri, IList<ServiceSearchParameterLight> SearchParametersList)
    {
      Hl7.Fhir.FhirPath.PocoNavigator Navigator = new Hl7.Fhir.FhirPath.PocoNavigator(Resource);
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

            IEnumerable<IElementNavigator> ResultList = Navigator.Select(Expression, Navigator);
            foreach (IElementNavigator oElement in ResultList)
            {
              IList<ResourceIndexBaseType> ResourceIndex = null;
              IList<ResourceIndexStringType> ResourceIndexString = null;
              if (oElement != null)
              {
                switch (SearchParameter.Type)
                {
                  case SearchParamType.Number:
                    {
                      ResourceIndex = IIndexSetterFactory.CreateINumberSetter().Set<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(oElement, SearchParameter);
                      break;
                    }
                  case SearchParamType.Date:
                    {
                      ResourceIndex = IIndexSetterFactory.CreateDateTimeSetter().Set<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(oElement, SearchParameter);
                      break;
                    }
                  case SearchParamType.String:
                    {
                      ResourceIndexString = IIndexSetterFactory.CreateStringSetter().Set<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(oElement, SearchParameter);
                      break;
                    }
                  case SearchParamType.Token:
                    {
                      ResourceIndex = IIndexSetterFactory.CreateTokenSetter().Set<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(oElement, SearchParameter);
                      break;
                    }
                  case SearchParamType.Reference:
                    {
                      ResourceIndex = IIndexSetterFactory.CreateReferenceSetter().Set<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(oElement, SearchParameter);
                      break;
                    }
                  case SearchParamType.Composite:
                    {
                      break;
                    }
                  case SearchParamType.Quantity:
                    {
                      ResourceIndex = IIndexSetterFactory.CreateQuantitySetter().Set<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(oElement, SearchParameter);
                      break;
                    }
                  case SearchParamType.Uri:
                    {
                      ResourceIndex = IIndexSetterFactory.CreateUriSetter().Set<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(oElement, SearchParameter);
                      break;
                    }
                  default:
                    throw new System.ComponentModel.InvalidEnumArgumentException(SearchParameter.Type.ToString(), (int)SearchParameter.Type, typeof(SearchParamType));
                }

                if (ResourceIndex != null)
                {
                  ResourceIndex.ToList().ForEach(x => ResourceEntity.IndexList.Add(x));
                }

                if (ResourceIndexString != null)
                {
                  ResourceIndexString.ToList().ForEach(x => ResourceEntity.IndexStringList.Add(x));
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

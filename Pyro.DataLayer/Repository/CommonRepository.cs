using Hl7.Fhir.Model;
using LinqKit;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Common.Search;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Tools;
using Pyro.Common.Interfaces.Repositories;
using Pyro.DataLayer.DbModel.Entity;
using Pyro.DataLayer.DbModel.EntityBase;
using Pyro.DataLayer.Search;
using Pyro.DataLayer.Search.Predicate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Hl7.Fhir.Utility;
using Pyro.DataLayer.DbModel.DatabaseContext;
using Pyro.Common.ServiceRoot;
using Pyro.Common.CompositionRoot;

namespace Pyro.DataLayer.Repository
{
  public class CommonRepository : BaseRepository, IDtoCommonRepository, Interfaces.ICommonRepository
  {
    protected readonly IPrimaryServiceRootCache IPrimaryServiceRootCache;
    protected readonly ICommonFactory ICommonFactory;
    #region Constructor
    public CommonRepository(IPyroDbContext IPyroDbContext, IPrimaryServiceRootCache IPrimaryServiceRootCache, ICommonFactory ICommonFactory)
      : base(IPyroDbContext)
    {
      this.IPrimaryServiceRootCache = IPrimaryServiceRootCache;
      this.ICommonFactory = ICommonFactory;
    }
    #endregion


    protected ExpressionStarter<ResourceIndexBaseType> IndexRefPredicateGenerator2<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(int ResourceId, int[] ServiceSearchParameterIdArray, string ResourceName)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      //var Search = new ResourceSearch<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>();
      var Predicate = LinqKit.PredicateBuilder.New<ResourceIndexBaseType>(true);

      Predicate = Predicate.And(x =>
        ServiceSearchParameterIdArray.Contains(x.ServiceSearchParameterId) &
        x.ReferenceResourceType == ResourceName &
        x.ResourceId == ResourceId &
        x.Resource.IsDeleted == false &
        x.Resource.IsCurrent == true &
        x.ReferenceUrl.IsServersPrimaryUrlRoot == true
      );

      return Predicate;
    }

    protected ExpressionStarter<ResourceIndexBaseType> IndexRefPredicateGenerator2<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(int ResourceId, int[] ServiceSearchParameterIdArray)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      //var Search = new ResourceSearch<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>();
      var Predicate = LinqKit.PredicateBuilder.New<ResourceIndexBaseType>(true);

      Predicate = Predicate.And(x =>
        ServiceSearchParameterIdArray.Contains(x.ServiceSearchParameterId) &
        x.ResourceId == ResourceId &
        x.Resource.IsDeleted == false &
        x.Resource.IsCurrent == true &
        x.ReferenceUrl.IsServersPrimaryUrlRoot == true
      );

      return Predicate;
    }

    protected ExpressionStarter<ResourceIndexBaseType> IndexRefPredicateGenerator<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(int ResourceId, int ServiceSearchParameterId)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      //var Search = new ResourceSearch<ResourceCurrentType, ResourceIndexType>();
      var Predicate = LinqKit.PredicateBuilder.New<ResourceIndexBaseType>(true);

      Predicate = Predicate.And(x =>
        x.ServiceSearchParameterId == ServiceSearchParameterId &
        x.ResourceId == ResourceId &
        x.Resource.IsDeleted == false &
        x.Resource.IsCurrent == true &
        x.ReferenceUrl.IsServersPrimaryUrlRoot == true
      );

      return Predicate;
    }



    //---- PredicateGenerator ---------------------------------------------------------------
    protected ExpressionStarter<ResourceCurrentBaseType> PredicateGenerator<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(PyroSearchParameters DtoSearchParameters)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      var Search = new ResourceSearch<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>();
      var MainPredicate = LinqKit.PredicateBuilder.New<ResourceCurrentBaseType>(true);
      MainPredicate = MainPredicate.And(x => x.IsDeleted == false & x.IsCurrent == true);

      IdSearchParameterPredicateProcessing(DtoSearchParameters, Search, MainPredicate);
      LastUpdatedDatePredicateBuilder<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>.Build(DtoSearchParameters, Search, MainPredicate);

      ExpressionStarter<ResourceCurrentBaseType> NewPredicate = null;


      foreach (SearchParameterBase SearchItem in DtoSearchParameters.SearchParametersList)
      {
        NewPredicate = LinqKit.PredicateBuilder.New<ResourceCurrentBaseType>();
        switch (SearchItem.Type)
        {
          case SearchParamType.Date:
            NewPredicate = DateTimePeriodPredicateBuilder<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>.Build(Search, NewPredicate, SearchItem);
            break;
          case SearchParamType.Number:
            {
              if (SearchItem is SearchParameterNumber)
              {
                var SearchTypeNumber = SearchItem as SearchParameterNumber;
                foreach (var SearchValue in SearchTypeNumber.ValueList)
                {
                  if (SearchTypeNumber.Name != "page")
                  {
                    //ToDo: more needed here
                  }
                }
              }
              NewPredicate = NumberPredicateBuilder<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>.Build(Search, NewPredicate, SearchItem);
            }
            break;
          case SearchParamType.Quantity:
            NewPredicate = QuantityPredicateBuilder<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>.Build(Search, NewPredicate, SearchItem);
            break;
          case SearchParamType.Reference:
            NewPredicate = ReferancePredicateBuilder<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>.Build(Search, NewPredicate, SearchItem, IPrimaryServiceRootCache.GetPrimaryRootUrlFromDatabase());
            break;
          case SearchParamType.String:
            NewPredicate = StringPredicateBuilder<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>.Build(Search, NewPredicate, SearchItem);
            break;
          case SearchParamType.Token:
            NewPredicate = TokenPredicateBuilder<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>.Build(Search, NewPredicate, SearchItem);
            break;
          case SearchParamType.Uri:
            NewPredicate = UriPredicateBuilder<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>.Build(Search, NewPredicate, SearchItem);
            break;
          default:
            throw new System.ComponentModel.InvalidEnumArgumentException(SearchItem.Type.ToString(), (int)SearchItem.Type, typeof(SearchParamType));
        }
        MainPredicate.Extend<ResourceCurrentBaseType>(NewPredicate, PredicateOperator.And);
      }

      return MainPredicate;
    }

    //---- PrimaryRootUrlStore -------------------------------------------------------------------
    public IDtoRootUrlStore SetPrimaryRootUrlStore(string RootUrl)
    {
      RootUrl = StringSupport.ToLowerFast(RootUrl.StripHttp());
      ServiceBaseUrl ExsistingPrimaryRootURL = this.GetPrimaryPyro_RootUrlStore();
      if (ExsistingPrimaryRootURL != null)
      {
        ExsistingPrimaryRootURL.IsServersPrimaryUrlRoot = false;
      }
      ServiceBaseUrl ExsistingNonPrimaryRootURL = this.GetPyro_RootUrlStore(RootUrl);
      if (ExsistingNonPrimaryRootURL != null)
      {
        ExsistingNonPrimaryRootURL.IsServersPrimaryUrlRoot = true;
      }
      else
      {
        ServiceBaseUrl Pyro_RootUrlStore = new ServiceBaseUrl();
        Pyro_RootUrlStore.IsServersPrimaryUrlRoot = true;
        Pyro_RootUrlStore.Url = RootUrl;
        IPyroDbContext.Set<ServiceBaseUrl>().Add(Pyro_RootUrlStore);
      }
      this.Save();
      return this.GetPrimaryRootUrlStore();
    }

    public IDtoRootUrlStore GetPrimaryRootUrlStore()
    {
      IDtoRootUrlStore DtoRootUrlStore = null;
      ServiceBaseUrl oServiceBaseUrl = GetPrimaryPyro_RootUrlStore();
      if (oServiceBaseUrl != null)
      {
        DtoRootUrlStore = ICommonFactory.CreateDtoRootUrlStore();
        DtoRootUrlStore.Id = oServiceBaseUrl.Id;
        DtoRootUrlStore.Url = oServiceBaseUrl.Url;
        DtoRootUrlStore.IsServersPrimaryUrlRoot = oServiceBaseUrl.IsServersPrimaryUrlRoot;
      }
      return DtoRootUrlStore;
    }

    /// <summary>
    /// Gets the ServiceBaseUrl Instance if found or creates a new instance if not found 
    /// </summary>
    /// <param name="UrlString"></param>
    /// <returns></returns>
    public ServiceBaseUrl GetAndOrAddService_RootUrlStore(string ServiceRootUrl)
    {
      ServiceRootUrl = StringSupport.ToLowerFast(ServiceRootUrl.StripHttp());
      ServiceBaseUrl Pyro_RootUrlStore = this.GetPyro_RootUrlStore(ServiceRootUrl);
      if (Pyro_RootUrlStore == null)
      {
        Pyro_RootUrlStore = new ServiceBaseUrl();
        Pyro_RootUrlStore.IsServersPrimaryUrlRoot = false;
        Pyro_RootUrlStore.Url = ServiceRootUrl;
        Pyro_RootUrlStore = IPyroDbContext.Set<ServiceBaseUrl>().Add(Pyro_RootUrlStore);
        this.Save();
        return Pyro_RootUrlStore;
      }
      else
      {
        return Pyro_RootUrlStore;
      }
    }

    protected ServiceBaseUrl GetPrimaryPyro_RootUrlStore()
    {
      return IPyroDbContext.ServiceBaseUrl.SingleOrDefault(x => x.IsServersPrimaryUrlRoot == true);
    }

    protected ServiceBaseUrl GetPyro_RootUrlStore(string ServiceRootUrl)
    {
      ServiceRootUrl = StringSupport.ToLowerFast(ServiceRootUrl.StripHttp());
      return IPyroDbContext.ServiceBaseUrl.SingleOrDefault(x => x.Url == ServiceRootUrl);
    }

    //---- ServiceSearchParameters ---------------------------------------------------------------

    public List<ServiceSearchParameterLight> GetServiceSearchParametersLightForResource(string ResourceType)
    {
      var ReturnList = new List<ServiceSearchParameterLight>();

      var List = IPyroDbContext.ServiceSearchParameter.Include(x => x.TargetResourceTypeList).Where(x => x.Resource == ResourceType & x.IsIndexed == true & x.Status == PublicationStatus.Active)
        .Select(x => new { x.Id, x.Name, x.Expression, x.Resource, x.Type, x.TargetResourceTypeList }).ToList();
      if (List != null)
      {
        foreach (var x in List)
        {
          var Light = new ServiceSearchParameterLight();
          Light.Id = x.Id;
          Light.Name = x.Name;
          Light.Expression = x.Expression;
          Light.Type = x.Type;
          Light.Resource = x.Resource;
          Light.TargetResourceTypeList = new List<IServiceSearchParameterTargetResource>();
          if (x.TargetResourceTypeList != null)
          {
            foreach (var Target in x.TargetResourceTypeList)
              Light.TargetResourceTypeList.Add(new DtoServiceSearchParameterTargetResource() { ResourceType = Target.ResourceType });
          }
          ReturnList.Add(Light);
        }
      }

      return ReturnList;
    }

    public List<ServiceSearchParameterHeavy> GetServiceSearchParametersHeavy(bool CustomOnly = false)
    {
      var ReturnList = new List<ServiceSearchParameterHeavy>();

      List<ServiceSearchParameter> ResourceServiceSearchParameterList;
      if (CustomOnly)
      {
        ResourceServiceSearchParameterList = IPyroDbContext.ServiceSearchParameter.Include(x => x.TargetResourceTypeList).Where(x => x.SearchParameterResourceId != null).ToList();
      }
      else
      {
        ResourceServiceSearchParameterList = IPyroDbContext.ServiceSearchParameter.Include(x => x.TargetResourceTypeList).ToList();
      }

      foreach (var x in ResourceServiceSearchParameterList)
      {
        var Heavy = new ServiceSearchParameterHeavy();
        Heavy.Id = x.Id;
        Heavy.Name = x.Name;
        Heavy.Expression = x.Expression;
        Heavy.Resource = x.Resource;
        Heavy.Type = x.Type;
        Heavy.Description = x.Description;
        Heavy.Url = x.Url;
        Heavy.XPath = x.XPath;
        Heavy.SearchParameterResourceId = x.SearchParameterResourceId;
        Heavy.SearchParameterResourceVersion = x.SearchParameterResourceVersion;
        Heavy.Status = x.Status;
        Heavy.IsIndexed = x.IsIndexed;
        Heavy.LastUpdated = x.LastUpdated;
        Heavy.TargetResourceTypeList = new List<IServiceSearchParameterTargetResource>();
        foreach (var Target in x.TargetResourceTypeList.ToList())
          Heavy.TargetResourceTypeList.Add(new DtoServiceSearchParameterTargetResource() { ResourceType = Target.ResourceType });
        ReturnList.Add(Heavy);
      }
      return ReturnList;
    }

    public List<ServiceSearchParameterHeavy> GetServiceSearchParametersHeavy()
    {
      var ReturnList = new List<ServiceSearchParameterHeavy>();

      var ResourceServiceSearchParameterList = IPyroDbContext.ServiceSearchParameter.Include(x => x.TargetResourceTypeList).ToList();
      foreach (var x in ResourceServiceSearchParameterList)
      {
        var Heavy = new ServiceSearchParameterHeavy();
        Heavy.Id = x.Id;
        Heavy.Name = x.Name;
        Heavy.Expression = x.Expression;
        Heavy.Resource = x.Resource;
        Heavy.Type = x.Type;
        Heavy.Description = x.Description;
        Heavy.Url = x.Url;
        Heavy.XPath = x.XPath;
        Heavy.SearchParameterResourceId = x.SearchParameterResourceId;
        Heavy.SearchParameterResourceVersion = x.SearchParameterResourceVersion;
        Heavy.Status = x.Status;
        Heavy.IsIndexed = x.IsIndexed;
        Heavy.LastUpdated = x.LastUpdated;
        Heavy.TargetResourceTypeList = new List<IServiceSearchParameterTargetResource>();
        foreach (var Target in x.TargetResourceTypeList.ToList())
          Heavy.TargetResourceTypeList.Add(new DtoServiceSearchParameterTargetResource() { ResourceType = Target.ResourceType });
        ReturnList.Add(Heavy);
      }
      return ReturnList;
    }

    public List<ServiceSearchParameterHeavy> GetServiceSearchParametersHeavyForResource(string ResourceType)
    {
      var ReturnList = new List<ServiceSearchParameterHeavy>();

      var ResourceServiceSearchParameterList = IPyroDbContext.ServiceSearchParameter.Where(x => x.Resource == ResourceType).Include(x => x.TargetResourceTypeList).ToList();
      foreach (var x in ResourceServiceSearchParameterList)
      {
        var Heavy = new ServiceSearchParameterHeavy();
        Heavy.Id = x.Id;
        Heavy.Name = x.Name;
        Heavy.Expression = x.Expression;
        Heavy.Resource = x.Resource;
        Heavy.Type = x.Type;
        Heavy.Description = x.Description;
        Heavy.Url = x.Url;
        Heavy.XPath = x.XPath;
        Heavy.SearchParameterResourceId = x.SearchParameterResourceId;
        Heavy.SearchParameterResourceVersion = x.SearchParameterResourceVersion;
        Heavy.Status = x.Status;
        Heavy.IsIndexed = x.IsIndexed;
        Heavy.LastUpdated = x.LastUpdated;
        Heavy.TargetResourceTypeList = new List<IServiceSearchParameterTargetResource>();
        foreach (var Target in x.TargetResourceTypeList.ToList())
          Heavy.TargetResourceTypeList.Add(new DtoServiceSearchParameterTargetResource() { ResourceType = Target.ResourceType });
        ReturnList.Add(Heavy);
      }
      return ReturnList;

    }

    public ServiceSearchParameterHeavy AddServiceSearchParametersHeavy(ServiceSearchParameterHeavy ServiceSearchParameterHeavy)
    {
      if (ServiceSearchParameterHeavy == null)
        return null;

      var DbSearchParameter = new ServiceSearchParameter();
      DbSearchParameter.Description = ServiceSearchParameterHeavy.Description;
      DbSearchParameter.Expression = ServiceSearchParameterHeavy.Expression;
      DbSearchParameter.IsIndexed = ServiceSearchParameterHeavy.IsIndexed;
      DbSearchParameter.LastUpdated = DateTimeOffset.Now;
      DbSearchParameter.Name = ServiceSearchParameterHeavy.Name;
      DbSearchParameter.Resource = ServiceSearchParameterHeavy.Resource;
      DbSearchParameter.SearchParameterResourceId = ServiceSearchParameterHeavy.SearchParameterResourceId;
      DbSearchParameter.SearchParameterResourceVersion = ServiceSearchParameterHeavy.SearchParameterResourceVersion;
      DbSearchParameter.Status = ServiceSearchParameterHeavy.Status;
      DbSearchParameter.Type = ServiceSearchParameterHeavy.Type;
      DbSearchParameter.Url = ServiceSearchParameterHeavy.Url;
      DbSearchParameter.XPath = ServiceSearchParameterHeavy.XPath;
      if (ServiceSearchParameterHeavy.TargetResourceTypeList != null)
      {
        DbSearchParameter.TargetResourceTypeList = new List<ServiceSearchParameterTargetResource>();
        foreach (var Target in ServiceSearchParameterHeavy.TargetResourceTypeList)
          DbSearchParameter.TargetResourceTypeList.Add(new ServiceSearchParameterTargetResource() { ResourceType = Target.ResourceType });
      }
      ServiceSearchParameter value = AddServiceSearchParameters(DbSearchParameter);
      ServiceSearchParameterHeavy.Id = value.Id;
      this.Save();
      return ServiceSearchParameterHeavy;
    }

    public ServiceSearchParameterHeavy UpdateServiceSearchParametersHeavy(ServiceSearchParameterHeavy ServiceSearchParameterHeavy)
    {
      if (ServiceSearchParameterHeavy == null)
        return null;

      var DbSearchParameter = new ServiceSearchParameter();
      DbSearchParameter.Description = ServiceSearchParameterHeavy.Description;
      DbSearchParameter.Expression = ServiceSearchParameterHeavy.Expression;
      DbSearchParameter.IsIndexed = ServiceSearchParameterHeavy.IsIndexed;
      DbSearchParameter.LastUpdated = DateTimeOffset.Now;
      DbSearchParameter.Name = ServiceSearchParameterHeavy.Name;
      DbSearchParameter.Resource = ServiceSearchParameterHeavy.Resource;
      DbSearchParameter.SearchParameterResourceId = ServiceSearchParameterHeavy.SearchParameterResourceId;
      DbSearchParameter.SearchParameterResourceVersion = ServiceSearchParameterHeavy.SearchParameterResourceVersion;
      DbSearchParameter.Status = ServiceSearchParameterHeavy.Status;
      DbSearchParameter.Type = ServiceSearchParameterHeavy.Type;
      DbSearchParameter.Url = ServiceSearchParameterHeavy.Url;
      DbSearchParameter.XPath = ServiceSearchParameterHeavy.XPath;
      if (ServiceSearchParameterHeavy.TargetResourceTypeList != null)
      {
        DbSearchParameter.TargetResourceTypeList = new List<ServiceSearchParameterTargetResource>();
        foreach (var Target in ServiceSearchParameterHeavy.TargetResourceTypeList)
          DbSearchParameter.TargetResourceTypeList.Add(new ServiceSearchParameterTargetResource() { ResourceType = Target.ResourceType });
      }
      ServiceSearchParameter value = UpdateServiceSearchParameters(ServiceSearchParameterHeavy.Id, DbSearchParameter);
      ServiceSearchParameterHeavy.Id = value.Id;
      return ServiceSearchParameterHeavy;
    }


    public void DeleteServiceSearchParameters(int Id)
    {
      var Entity = IPyroDbContext.ServiceSearchParameter.SingleOrDefault(x => x.Id == Id);
      if (Entity != null)
      {
        IPyroDbContext.ServiceSearchParameter.Remove(Entity);
        this.Save();
      }
    }

    protected ServiceSearchParameter AddServiceSearchParameters(ServiceSearchParameter ServiceSearchParameter)
    {
      ServiceSearchParameter = IPyroDbContext.Set<ServiceSearchParameter>().Add(ServiceSearchParameter);
      this.Save();
      return ServiceSearchParameter;
    }

    protected ServiceSearchParameter GetServiceSearchParameters(string ResourceType, string Name)
    {
      return IPyroDbContext.ServiceSearchParameter.SingleOrDefault(x => x.Resource == ResourceType & x.Name == Name);
    }

    protected ServiceSearchParameter UpdateServiceSearchParameters(int Id, ServiceSearchParameter SearchParameter)
    {
      var DbSearchParameter = IPyroDbContext.ServiceSearchParameter.SingleOrDefault(x => x.Id == Id);
      DbSearchParameter.Description = SearchParameter.Description;
      DbSearchParameter.Expression = SearchParameter.Expression;
      DbSearchParameter.IsIndexed = SearchParameter.IsIndexed;
      DbSearchParameter.LastUpdated = DateTimeOffset.Now;
      DbSearchParameter.Name = SearchParameter.Name;
      DbSearchParameter.Resource = SearchParameter.Resource;
      DbSearchParameter.SearchParameterResourceId = SearchParameter.SearchParameterResourceId;
      DbSearchParameter.SearchParameterResourceVersion = SearchParameter.SearchParameterResourceVersion;
      DbSearchParameter.Status = SearchParameter.Status;
      DbSearchParameter.TargetResourceTypeList = SearchParameter.TargetResourceTypeList;
      DbSearchParameter.Type = SearchParameter.Type;
      DbSearchParameter.Url = SearchParameter.Url;
      DbSearchParameter.XPath = SearchParameter.XPath;
      IPyroDbContext.Entry(DbSearchParameter).State = EntityState.Modified;
      this.Save();
      return DbSearchParameter;
    }

    protected List<ServiceSearchParameter> GetAllServiceSearchParameters()
    {
      return IPyroDbContext.ServiceSearchParameter.ToList();
    }
    //---- Resource ---------------------------------------------------------------

    protected ResourceCurrentBaseType DbGet<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Expression<Func<ResourceCurrentBaseType, bool>> predicate)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      ResourceCurrentBaseType ResourceEntity = null;
      ResourceEntity = IPyroDbContext.Set<ResourceCurrentBaseType>().SingleOrDefault(predicate);
      return ResourceEntity;
    }

    protected DtoResource DbGetNoXML<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Expression<Func<ResourceCurrentBaseType, bool>> predicate)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      return IPyroDbContext.Set<ResourceCurrentBaseType>().Where(predicate).Select(x => new Pyro.Common.BusinessEntities.Dto.DtoResource
      {
        Id = x.Id,
        IsCurrent = x.IsCurrent,
        FhirId = x.FhirId,
        IsDeleted = x.IsDeleted,
        Version = x.VersionId,
        Received = x.LastUpdated,
        Method = x.Method,
      }).FirstOrDefault();
    }

    protected DtoResource DbGetWithXML<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Expression<Func<ResourceCurrentBaseType, bool>> predicate)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      return IPyroDbContext.Set<ResourceCurrentBaseType>().AsExpandable().Where(predicate).Select(x => new Pyro.Common.BusinessEntities.Dto.DtoResource
      {
        Id = x.Id,
        IsCurrent = x.IsCurrent,
        FhirId = x.FhirId,
        IsDeleted = x.IsDeleted,
        Version = x.VersionId,
        Received = x.LastUpdated,
        Method = x.Method,
        Xml = x.XmlBlob,
      }).FirstOrDefault();
    }

    protected IQueryable<ResourceIndexBaseType> DbGetIndexAll<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Expression<Func<ResourceIndexBaseType, bool>> predicate)
     where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      IQueryable<ResourceIndexBaseType> ResourceIndexEntity = null;
      ResourceIndexEntity = IPyroDbContext.Set<ResourceIndexBaseType>().AsExpandable().Where(predicate);
      return ResourceIndexEntity;
    }


    protected IQueryable<ResourceCurrentBaseType> DbGetAll<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Expression<Func<ResourceCurrentBaseType, bool>> predicate)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      IQueryable<ResourceCurrentBaseType> ResourceEntity = null;
      ResourceEntity = IPyroDbContext.Set<ResourceCurrentBaseType>().AsExpandable().Where(predicate);
      return ResourceEntity;
    }

    protected int DbGetALLCount<ResourceBaseType>(Expression<Func<ResourceBaseType, bool>> predicate)
      where ResourceBaseType : ResourceBase
    {
      IQueryable<ResourceBaseType> ResourceEntity = null;
      ResourceEntity = IPyroDbContext.Set<ResourceBaseType>().AsExpandable().Where(predicate);
      return ResourceEntity.Count();
    }

    protected void DbAddEntity<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(ResourceCurrentBaseType Entity)
     where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      IPyroDbContext.Set<ResourceCurrentBaseType>().Add(Entity);
      this.Save();
    }

    protected ResourceCurrentBaseType DbQueryEntityWithInclude<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Expression<Func<ResourceCurrentBaseType, bool>> predicate, List<Expression<Func<ResourceCurrentBaseType, object>>> IncludeList)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      ResourceCurrentBaseType ResourceEntity = null;

      IQueryable<ResourceCurrentBaseType> query = IPyroDbContext.Set<ResourceCurrentBaseType>();

      //Apply includes
      foreach (Expression<Func<ResourceCurrentBaseType, object>> include in IncludeList)
        query = query.Include<ResourceCurrentBaseType, object>(include);

      ResourceEntity = query.SingleOrDefault(predicate);
      return ResourceEntity;

    }

    private static void IdSearchParameterPredicateProcessing<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(PyroSearchParameters DtoSearchParameters, ResourceSearch<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType> Search, ExpressionStarter<ResourceCurrentBaseType> MainPredicate)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      var IdSearchParamerterList = DtoSearchParameters.SearchParametersList.Where(x => x.Resource == FHIRAllTypes.Resource.GetLiteral() && x.Name == "_id");
      if (IdSearchParamerterList != null)
      {
        ExpressionStarter<ResourceCurrentBaseType> NewIdPredicate = null;
        foreach (var IdSearchParameter in IdSearchParamerterList)
        {
          if (IdSearchParameter is SearchParameterToken SearchTypeToken)
          {
            NewIdPredicate = LinqKit.PredicateBuilder.New<ResourceCurrentBaseType>();
            foreach (var SearchValue in SearchTypeToken.ValueList)
            {
              if (!SearchTypeToken.Modifier.HasValue)
              {
                var Expression = Search.TokenMainAnyEqualTo(SearchValue.Code);
                NewIdPredicate = NewIdPredicate.Or(Expression);
              }
            }
          }
          MainPredicate.Extend<ResourceCurrentBaseType>(NewIdPredicate, PredicateOperator.And);
        }
        DtoSearchParameters.SearchParametersList.RemoveAll(x => x.Resource == FHIRAllTypes.Resource.GetLiteral() && x.Name == "_id");
      }
    }


  }
}

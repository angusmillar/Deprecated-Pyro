using Hl7.Fhir.Model;
using LinqKit;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Common.BusinessEntities.Search;
using Pyro.Common.Interfaces.Dto;
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


namespace Pyro.DataLayer.Repository
{
  public class CommonRepository : BaseRepository, IDtoCommonRepository, Interfaces.ICommonRepository
  {
    #region Constructor
    public CommonRepository(Pyro.DataLayer.DbModel.DatabaseContext.IPyroDbContext Context)
    {
      _Context = Context;
    }
    #endregion

    //---- PredicateGenerator ---------------------------------------------------------------
    protected ExpressionStarter<ResourceCurrentType> PredicateGenerator<ResourceCurrentType, ResourceIndexType>(DtoSearchParameters DtoSearchParameters)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>
    {
      var Search = new ResourceSearch<ResourceCurrentType, ResourceIndexType>();
      var MainPredicate = LinqKit.PredicateBuilder.New<ResourceCurrentType>(true);
      MainPredicate = MainPredicate.And(x => x.IsDeleted == false & x.IsCurrent == true);

      IdSearchParameterPredicateProcessing(DtoSearchParameters, Search, MainPredicate);
      LastUpdatedDatePredicateBuilder<ResourceCurrentType, ResourceIndexType>.Build(DtoSearchParameters, Search, MainPredicate);

      ExpressionStarter<ResourceCurrentType> NewPredicate = null;


      foreach (DtoSearchParameterBase SearchItem in DtoSearchParameters.SearchParametersList)
      {
        NewPredicate = LinqKit.PredicateBuilder.New<ResourceCurrentType>();
        switch (SearchItem.Type)
        {
          case SearchParamType.Date:
            NewPredicate = DateTimePeriodPredicateBuilder<ResourceCurrentType, ResourceIndexType>.Build(Search, NewPredicate, SearchItem);
            break;
          case SearchParamType.Number:
            {
              if (SearchItem is DtoSearchParameterNumber)
              {
                var SearchTypeNumber = SearchItem as DtoSearchParameterNumber;
                foreach (var SearchValue in SearchTypeNumber.ValueList)
                {
                  if (SearchTypeNumber.Name != "page")
                  {
                    //ToDo: more needed here
                  }
                }
              }
              NewPredicate = NumberPredicateBuilder<ResourceCurrentType, ResourceIndexType>.Build(Search, NewPredicate, SearchItem);
            }
            break;
          case SearchParamType.Quantity:
            NewPredicate = QuantityPredicateBuilder<ResourceCurrentType, ResourceIndexType>.Build(Search, NewPredicate, SearchItem);
            break;
          case SearchParamType.Reference:
            NewPredicate = ReferancePredicateBuilder<ResourceCurrentType, ResourceIndexType>.Build(Search, NewPredicate, SearchItem, DtoSearchParameters.PrimaryRootUrlStore);
            break;
          case SearchParamType.String:
            NewPredicate = StringPredicateBuilder<ResourceCurrentType, ResourceIndexType>.Build(Search, NewPredicate, SearchItem);
            break;
          case SearchParamType.Token:
            NewPredicate = TokenPredicateBuilder<ResourceCurrentType, ResourceIndexType>.Build(Search, NewPredicate, SearchItem);
            break;
          case SearchParamType.Uri:
            NewPredicate = UriPredicateBuilder<ResourceCurrentType, ResourceIndexType>.Build(Search, NewPredicate, SearchItem);
            break;
          default:
            throw new System.ComponentModel.InvalidEnumArgumentException(SearchItem.Type.ToString(), (int)SearchItem.Type, typeof(SearchParamType));
        }
        MainPredicate.Extend<ResourceCurrentType>(NewPredicate, PredicateOperator.And);
      }

      return MainPredicate;
    }

    //---- PrimaryRootUrlStore -------------------------------------------------------------------
    public IDtoRootUrlStore SetPrimaryRootUrlStore(string RootUrl)
    {
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
        _Context.Set<ServiceBaseUrl>().Add(Pyro_RootUrlStore);
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
        DtoRootUrlStore = Common.CommonFactory.GetRootUrlStore();
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
      ServiceBaseUrl Pyro_RootUrlStore = this.GetPyro_RootUrlStore(ServiceRootUrl);
      if (Pyro_RootUrlStore == null)
      {
        Pyro_RootUrlStore = new ServiceBaseUrl();
        Pyro_RootUrlStore.IsServersPrimaryUrlRoot = false;
        Pyro_RootUrlStore.Url = ServiceRootUrl;
        Pyro_RootUrlStore = _Context.Set<ServiceBaseUrl>().Add(Pyro_RootUrlStore);
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
      return _Context.ServiceBaseUrl.SingleOrDefault(x => x.IsServersPrimaryUrlRoot == true);
    }

    protected ServiceBaseUrl GetPyro_RootUrlStore(string ServiceRootUrl)
    {
      return _Context.ServiceBaseUrl.SingleOrDefault(x => x.Url == ServiceRootUrl);
    }

    //---- ServiceSearchParameters ---------------------------------------------------------------

    public List<DtoServiceSearchParameterLight> GetServiceSearchParametersLightForResource(string ResourceType)
    {
      var ReturnList = new List<DtoServiceSearchParameterLight>();

      var List = _Context.ServiceSearchParameter.Include(x => x.TargetResourceTypeList).Where(x => x.Resource == ResourceType & x.IsIndexed == true & x.Status == PublicationStatus.Active)
        .Select(x => new { x.Id, x.Name, x.Expression, x.Resource, x.Type, x.TargetResourceTypeList }).ToList();
      if (List != null)
      {
        foreach (var x in List)
        {
          var Light = new DtoServiceSearchParameterLight();
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

    public List<DtoServiceSearchParameterHeavy> GetServiceSearchParametersHeavy(bool CustomOnly = false)
    {
      var ReturnList = new List<Pyro.Common.BusinessEntities.Dto.DtoServiceSearchParameterHeavy>();

      List<ServiceSearchParameter> ResourceServiceSearchParameterList;
      if (CustomOnly)
      {
        ResourceServiceSearchParameterList = _Context.ServiceSearchParameter.Include(x => x.TargetResourceTypeList).Where(x => x.SearchParameterResourceId != null).ToList();
      }
      else
      {
        ResourceServiceSearchParameterList = _Context.ServiceSearchParameter.Include(x => x.TargetResourceTypeList).ToList();
      }

      foreach (var x in ResourceServiceSearchParameterList)
      {
        var Heavy = new DtoServiceSearchParameterHeavy();
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

    public List<DtoServiceSearchParameterHeavy> GetServiceSearchParametersHeavy()
    {
      var ReturnList = new List<Pyro.Common.BusinessEntities.Dto.DtoServiceSearchParameterHeavy>();

      var ResourceServiceSearchParameterList = _Context.ServiceSearchParameter.Include(x => x.TargetResourceTypeList).ToList();
      foreach (var x in ResourceServiceSearchParameterList)
      {
        var Heavy = new DtoServiceSearchParameterHeavy();
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

    public List<DtoServiceSearchParameterHeavy> GetServiceSearchParametersHeavyForResource(string ResourceType)
    {
      var ReturnList = new List<Pyro.Common.BusinessEntities.Dto.DtoServiceSearchParameterHeavy>();

      var ResourceServiceSearchParameterList = _Context.ServiceSearchParameter.Where(x => x.Resource == ResourceType).Include(x => x.TargetResourceTypeList).ToList();
      foreach (var x in ResourceServiceSearchParameterList)
      {
        var Heavy = new DtoServiceSearchParameterHeavy();
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

    public DtoServiceSearchParameterHeavy AddServiceSearchParametersHeavy(DtoServiceSearchParameterHeavy ServiceSearchParameterHeavy)
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

    public DtoServiceSearchParameterHeavy UpdateServiceSearchParametersHeavy(DtoServiceSearchParameterHeavy ServiceSearchParameterHeavy)
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
      var Entity = _Context.ServiceSearchParameter.SingleOrDefault(x => x.Id == Id);
      if (Entity != null)
      {
        _Context.ServiceSearchParameter.Remove(Entity);
        this.Save();
      }
    }

    protected ServiceSearchParameter AddServiceSearchParameters(ServiceSearchParameter ServiceSearchParameter)
    {
      ServiceSearchParameter = _Context.Set<ServiceSearchParameter>().Add(ServiceSearchParameter);
      this.Save();
      return ServiceSearchParameter;
    }

    protected ServiceSearchParameter GetServiceSearchParameters(string ResourceType, string Name)
    {
      return _Context.ServiceSearchParameter.SingleOrDefault(x => x.Resource == ResourceType & x.Name == Name);
    }

    protected ServiceSearchParameter UpdateServiceSearchParameters(int Id, ServiceSearchParameter SearchParameter)
    {
      var DbSearchParameter = _Context.ServiceSearchParameter.SingleOrDefault(x => x.Id == Id);
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
      _Context.Entry(DbSearchParameter).State = EntityState.Modified;
      this.Save();
      return DbSearchParameter;
    }

    protected List<ServiceSearchParameter> GetAllServiceSearchParameters()
    {
      return _Context.ServiceSearchParameter.ToList();
    }
    //---- Resource ---------------------------------------------------------------

    protected ResourceCurrentType DbGet<ResourceCurrentType, ResourceIndexType>(Expression<Func<ResourceCurrentType, bool>> predicate)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>
    {
      ResourceCurrentType ResourceEntity = null;
      ResourceEntity = _Context.Set<ResourceCurrentType>().SingleOrDefault(predicate);
      return ResourceEntity;
    }

    protected DtoResource DbGetNoXML<ResourceCurrentType, ResourceIndexType>(Expression<Func<ResourceCurrentType, bool>> predicate)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>
    {
      return _Context.Set<ResourceCurrentType>().Where(predicate).Select(x => new Pyro.Common.BusinessEntities.Dto.DtoResource
      {
        IsCurrent = x.IsCurrent,
        FhirId = x.FhirId,
        IsDeleted = x.IsDeleted,
        Version = x.VersionId,
        Received = x.LastUpdated,
        Method = x.Method,
      }).FirstOrDefault();
    }

    protected DtoResource DbGetWithXML<ResourceCurrentType, ResourceIndexType>(Expression<Func<ResourceCurrentType, bool>> predicate)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>
    {
      return _Context.Set<ResourceCurrentType>().AsExpandable().Where(predicate).Select(x => new Pyro.Common.BusinessEntities.Dto.DtoResource
      {
        IsCurrent = x.IsCurrent,
        FhirId = x.FhirId,
        IsDeleted = x.IsDeleted,
        Version = x.VersionId,
        Received = x.LastUpdated,
        Method = x.Method,
        Xml = x.XmlBlob,
      }).FirstOrDefault();
    }

    protected IQueryable<ResourceCurrentType> DbGetAll<ResourceCurrentType, ResourceIndexType>(Expression<Func<ResourceCurrentType, bool>> predicate)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>
    {
      IQueryable<ResourceCurrentType> ResourceEntity = null;
      ResourceEntity = _Context.Set<ResourceCurrentType>().AsExpandable().Where(predicate);
      return ResourceEntity;
    }

    protected int DbGetALLCount<ResourceBaseType>(Expression<Func<ResourceBaseType, bool>> predicate)
      where ResourceBaseType : ResourceBase
    {
      IQueryable<ResourceBaseType> ResourceEntity = null;
      ResourceEntity = _Context.Set<ResourceBaseType>().AsExpandable().Where(predicate);
      return ResourceEntity.Count();
    }

    protected void DbAddEntity<ResourceCurrentType, ResourceIndexType>(ResourceCurrentType Entity)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>
    {
      _Context.Set<ResourceCurrentType>().Add(Entity);
      this.Save();
    }

    protected ResourceCurrentType DbQueryEntityWithInclude<ResourceCurrentType, ResourceIndexType>(Expression<Func<ResourceCurrentType, bool>> predicate, List<Expression<Func<ResourceCurrentType, object>>> IncludeList)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>
    {
      ResourceCurrentType ResourceEntity = null;

      IQueryable<ResourceCurrentType> query = _Context.Set<ResourceCurrentType>();

      //Apply includes
      foreach (Expression<Func<ResourceCurrentType, object>> include in IncludeList)
        query = query.Include<ResourceCurrentType, object>(include);

      ResourceEntity = query.SingleOrDefault(predicate);
      return ResourceEntity;

    }

    private static void IdSearchParameterPredicateProcessing<ResourceCurrentType, ResourceIndexType>(DtoSearchParameters DtoSearchParameters, ResourceSearch<ResourceCurrentType, ResourceIndexType> Search, ExpressionStarter<ResourceCurrentType> MainPredicate)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>
    {
      var IdSearchParamerterList = DtoSearchParameters.SearchParametersList.Where(x => x.Resource == FHIRAllTypes.Resource.GetLiteral() && x.Name == "_id");
      if (IdSearchParamerterList != null)
      {
        ExpressionStarter<ResourceCurrentType> NewIdPredicate = null;
        foreach (var IdSearchParameter in IdSearchParamerterList)
        {
          if (IdSearchParameter is DtoSearchParameterToken SearchTypeToken)
          {
            NewIdPredicate = LinqKit.PredicateBuilder.New<ResourceCurrentType>();
            foreach (var SearchValue in SearchTypeToken.ValueList)
            {
              if (!SearchTypeToken.Modifier.HasValue)
              {
                var Expression = Search.TokenMainAnyEqualTo(SearchValue.Code);
                NewIdPredicate = NewIdPredicate.Or(Expression);
              }
            }
          }
          MainPredicate.Extend<ResourceCurrentType>(NewIdPredicate, PredicateOperator.And);
        }
        DtoSearchParameters.SearchParametersList.RemoveAll(x => x.Resource == FHIRAllTypes.Resource.GetLiteral() && x.Name == "_id");
      }
    }


  }
}

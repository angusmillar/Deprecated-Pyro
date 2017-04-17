using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqKit;
using System.Linq.Expressions;
using System.Data.Entity;
using Pyro.DataLayer.DbModel.EntityGenerated;
using Pyro.DataLayer.DbModel.EntityBase;
using Pyro.DataLayer.DbModel.Entity;
//using Pyro.DataModel.Search;
//using Pyro.DataModel.Support;

using Pyro.Common.Interfaces;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Common.BusinessEntities.Search;
using Hl7.Fhir.Model;


namespace Pyro.DataLayer.Repository
{
  public class CommonRepository : BaseRepository, IDtoCommonRepository, Interfaces.ICommonRepository
  {
    #region Constructor
    public CommonRepository(Pyro.DataLayer.DbModel.DatabaseContext.PyroDbContext Context)
    {
      _Context = Context;
    }
    #endregion

    //---- PredicateGenerator ---------------------------------------------------------------
    protected ExpressionStarter<ResourceCurrentType> PredicateGenerator<ResourceCurrentType, ResourceHistoryType, ResourceIndexType>(DtoSearchParameters DtoSearchParameters) 
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceHistoryType, ResourceIndexType>
      where ResourceHistoryType : ResourceHistoryBase<ResourceCurrentType>
      where ResourceIndexType : ResourceIndexBase
    {
      //var Search = new ResourceSearch<ResourceCurrentType>();
      var MainPredicate = LinqKit.PredicateBuilder.New<ResourceCurrentType>(true);
      //MainPredicate = MainPredicate.And(x => x.IsDeleted == false);

      //ExpressionStarter<ResourceCurrentType> NewPredicate = null;


      //foreach (DtoSearchParameterBase SearchItem in DtoSearchParameters.SearchParametersList)
      //{
      //  NewPredicate = LinqKit.PredicateBuilder.New<ResourceCurrentType>();
      //  switch (SearchItem.DbSearchParameterType)
      //  {
      //    case Common.Enum.DatabaseEnum.DbIndexType.DateTimeIndex:
      //      NewPredicate = DateTimePredicateBuilder.Build(Search, NewPredicate, SearchItem);
      //      break;
      //    case Common.Enum.DatabaseEnum.DbIndexType.DateIndex:
      //      NewPredicate = DatePredicateBuilder.Build(Search, NewPredicate, SearchItem);
      //      break;
      //    case Common.Enum.DatabaseEnum.DbIndexType.DateTimePeriodIndex:
      //      NewPredicate = DateTimePeriodPredicateBuilder.Build(Search, NewPredicate, SearchItem);
      //      break;
      //    case Common.Enum.DatabaseEnum.DbIndexType.NumberIndex:
      //      {
      //        if (SearchItem is DtoSearchParameterNumber)
      //        {
      //          var SearchTypeNumber = SearchItem as DtoSearchParameterNumber;
      //          foreach (var SearchValue in SearchTypeNumber.ValueList)
      //          {
      //            if (SearchTypeNumber.Name != Common.Enum.FhirSearchEnum.SearchParameterNameType.page)
      //            {
      //              //ToDo: more needed here
      //            }
      //          }
      //        }
      //        NewPredicate = NumberPredicateBuilder.Build(Search, NewPredicate, SearchItem);
      //      }
      //      break;
      //    case Common.Enum.DatabaseEnum.DbIndexType.QuantityIndex:
      //      NewPredicate = QuantityPredicateBuilder.Build(Search, NewPredicate, SearchItem);
      //      break;
      //    case Common.Enum.DatabaseEnum.DbIndexType.QuantityRangeIndex:
      //      throw new NotImplementedException("QuantityRangeIndex searches are not supported in this version.");
      //    case Common.Enum.DatabaseEnum.DbIndexType.ReferenceIndex:
      //      NewPredicate = ReferancePredicateBuilder.Build(Search, NewPredicate, SearchItem, DtoSearchParameters.PrimaryRootUrlStore);
      //      break;
      //    case Common.Enum.DatabaseEnum.DbIndexType.StringIndex:
      //      NewPredicate = StringPredicateBuilder.Build(Search, NewPredicate, SearchItem);
      //      break;
      //    case Common.Enum.DatabaseEnum.DbIndexType.TokenIndex:
      //      NewPredicate = TokenPredicateBuilder.Build(Search, NewPredicate, SearchItem);
      //      break;
      //    case Common.Enum.DatabaseEnum.DbIndexType.UriIndex:
      //      NewPredicate = UriPredicateBuilder.Build(Search, NewPredicate, SearchItem);
      //      break;
      //    default:
      //      throw new System.ComponentModel.InvalidEnumArgumentException(SearchItem.DbSearchParameterType.ToString(), (int)SearchItem.DbSearchParameterType, typeof(Common.Enum.DatabaseEnum.DbIndexType));
      //  }
      //  MainPredicate.Extend<ResourceCurrentType>(NewPredicate, PredicateOperator.And);
      //}

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

    public IList<DtoServiceSearchParameterLight> GetServiceSearchParametersForResource(string ResourceType)
    {
      return _Context.ServiceSearchParameter.Where(x => x.Resource == ResourceType)
        .Select(x => new Pyro.Common.BusinessEntities.Dto.DtoServiceSearchParameterLight
        {
          Name = x.Name,
          Expression = x.Expression,
          Resource = x.Resource,
          Type = x.Type
        }).ToList();     
    }

    protected IList<ServiceSearchParameter> GetAllServiceSearchParameters()
    {
      return _Context.ServiceSearchParameter.ToList();
    }

    //---- Resource ---------------------------------------------------------------

    protected ResourceCurrentType DbGet<ResourceCurrentType, ResourceHistoryType, ResourceIndexType>(Expression<Func<ResourceCurrentType, bool>> predicate)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceHistoryType, ResourceIndexType>
      where ResourceHistoryType : ResourceHistoryBase<ResourceCurrentType>
      where ResourceIndexType : ResourceIndexBase
    {
      ResourceCurrentType ResourceEntity = null;
      ResourceEntity = _Context.Set<ResourceCurrentType>().SingleOrDefault(predicate);
      return ResourceEntity;
    }

    protected IQueryable<ResourceBaseType> DbGetAll<ResourceBaseType>(Expression<Func<ResourceBaseType, bool>> predicate) 
      where ResourceBaseType : ResourceBase
    {
      IQueryable<ResourceBaseType> ResourceEntity = null;
      ResourceEntity = _Context.Set<ResourceBaseType>().AsExpandable().Where(predicate);
      return ResourceEntity;
    }

    protected int DbGetALLCount<ResourceBaseType>(Expression<Func<ResourceBaseType, bool>> predicate)
      where ResourceBaseType : ResourceBase
    {
      IQueryable<ResourceBaseType> ResourceEntity = null;
      ResourceEntity = _Context.Set<ResourceBaseType>().AsExpandable().Where(predicate);
      return ResourceEntity.Count();
    }

    protected void DbAddEntity<ResourceCurrentType, ResourceHistoryType, ResourceIndexType>(ResourceCurrentType Entity)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceHistoryType, ResourceIndexType>
      where ResourceHistoryType : ResourceHistoryBase<ResourceCurrentType>
      where ResourceIndexType : ResourceIndexBase
    {
      //var Cache = Common.CommonFactory.GetApplicationCacheService();
      //var test = Cache.Get("AngusTest") as string;

      _Context.Set<ResourceCurrentType>().Add(Entity);
      this.Save();
    }

    protected ResourceCurrentType DbQueryEntityWithInclude<ResourceCurrentType, ResourceHistoryType, ResourceIndexType>(Expression<Func<ResourceCurrentType, bool>> predicate, List<Expression<Func<ResourceCurrentType, object>>> IncludeList)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceHistoryType, ResourceIndexType>
      where ResourceHistoryType : ResourceHistoryBase<ResourceCurrentType>
      where ResourceIndexType : ResourceIndexBase
    {
      ResourceCurrentType ResourceEntity = null;

      IQueryable<ResourceCurrentType> query = _Context.Set<ResourceCurrentType>();

      //Apply includes
      foreach (Expression<Func<ResourceCurrentType, object>> include in IncludeList)
        query = query.Include<ResourceCurrentType, object>(include);

      ResourceEntity = query.SingleOrDefault(predicate);
      return ResourceEntity;

    }

  }
}

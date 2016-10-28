using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqKit;
using System.Linq.Expressions;
using System.Data.Entity;
using Pyro.DataModel.DatabaseModel;
using Pyro.DataModel.DatabaseModel.Base;
using Pyro.DataModel.Search;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.Dto;
//using Pyro.Common.BusinessEntities.Dto;
using Pyro.Common.BusinessEntities.Search;


namespace Pyro.DataModel.Repository
{
  public class CommonRepository : BaseRepository, IDtoCommonRepository, Interfaces.ICommonRepository
  {
    #region Constructor
    public CommonRepository(DataModel.DatabaseModel.DatabaseContext Context)
    {
      _Context = Context;
    }
    #endregion

    protected ExpressionStarter<T> PredicateGenerator<T>(DtoSearchParameters DtoSearchParameters) where T : ResourceIndexBase
    {
      var Search = new ResourceSearch<T>();
      var MainPredicate = LinqKit.PredicateBuilder.New<T>();
      ExpressionStarter<T> NewPredicate = null;


      foreach (DtoSearchParameterBase SearchItem in DtoSearchParameters.SearchParametersList)
      {
        NewPredicate = LinqKit.PredicateBuilder.New<T>();
        switch (SearchItem.DbSearchParameterType)
        {
          case Common.Enum.DatabaseEnum.DbIndexType.DateTimeIndex:
            NewPredicate = DateTimePredicateBuilder.Build(Search, NewPredicate, SearchItem);
            break;
          case Common.Enum.DatabaseEnum.DbIndexType.DateIndex:
            NewPredicate = DatePredicateBuilder.Build(Search, NewPredicate, SearchItem);
            break;
          case Common.Enum.DatabaseEnum.DbIndexType.DateTimePeriodIndex:
            NewPredicate = DateTimePeriodPredicateBuilder.Build(Search, NewPredicate, SearchItem);
            break;
          case Common.Enum.DatabaseEnum.DbIndexType.NumberIndex:
            {
              if (SearchItem is DtoSearchParameterNumber)
              {
                var SearchTypeNumber = SearchItem as DtoSearchParameterNumber;
                foreach (var SearchValue in SearchTypeNumber.ValueList)
                {
                  if (SearchTypeNumber.Name != Common.Enum.FhirSearchEnum.SearchParameterNameType.page)
                  {
                    //ToDo: more needed here
                  }
                }
              }
              NewPredicate = NumberPredicateBuilder.Build(Search, NewPredicate, SearchItem);
            }
            break;
          case Common.Enum.DatabaseEnum.DbIndexType.QuantityIndex:
            NewPredicate = QuantityPredicateBuilder.Build(Search, NewPredicate, SearchItem);
            break;
          case Common.Enum.DatabaseEnum.DbIndexType.QuantityRangeIndex:
            throw new NotImplementedException("QuantityRangeIndex searches are not supported in this version.");
          case Common.Enum.DatabaseEnum.DbIndexType.ReferenceIndex:
            NewPredicate = ReferancePredicateBuilder.Build(Search, NewPredicate, SearchItem, DtoSearchParameters.PrimaryRootUrlStore);
            break;
          case Common.Enum.DatabaseEnum.DbIndexType.StringIndex:
            NewPredicate = StringPredicateBuilder.Build(Search, NewPredicate, SearchItem);
            break;
          case Common.Enum.DatabaseEnum.DbIndexType.TokenIndex:
            NewPredicate = TokenPredicateBuilder.Build(Search, NewPredicate, SearchItem);
            break;
          case Common.Enum.DatabaseEnum.DbIndexType.UriIndex:
            NewPredicate = UriPredicateBuilder.Build(Search, NewPredicate, SearchItem);
            break;
          default:
            throw new System.ComponentModel.InvalidEnumArgumentException(SearchItem.DbSearchParameterType.ToString(), (int)SearchItem.DbSearchParameterType, typeof(Common.Enum.DatabaseEnum.DbIndexType));
        }
        MainPredicate.Extend<T>(NewPredicate, PredicateOperator.And);
      }

      return MainPredicate;
    }


    public IDtoRootUrlStore SetPrimaryRootUrlStore(string RootUrl)
    {
      ServiceRootURL_Store ExsistingPrimaryRootURL = this.GetPrimaryPyro_RootUrlStore();
      if (ExsistingPrimaryRootURL != null)
      {
        ExsistingPrimaryRootURL.IsServersPrimaryUrlRoot = false;
      }
      ServiceRootURL_Store ExsistingNonPrimaryRootURL = this.GetPyro_RootUrlStore(RootUrl);
      if (ExsistingNonPrimaryRootURL != null)
      {
        ExsistingNonPrimaryRootURL.IsServersPrimaryUrlRoot = true;
      }
      else
      {
        ServiceRootURL_Store Pyro_RootUrlStore = new ServiceRootURL_Store();
        Pyro_RootUrlStore.IsServersPrimaryUrlRoot = true;
        Pyro_RootUrlStore.RootUrl = RootUrl;
        _Context.Set<ServiceRootURL_Store>().Add(Pyro_RootUrlStore);
      }
      this.Save();
      return this.GetPrimaryRootUrlStore();
    }

    public IDtoRootUrlStore GetPrimaryRootUrlStore()
    {
      IDtoRootUrlStore DtoRootUrlStore = null;
      ServiceRootURL_Store Pyro_RootUrlStore = GetPrimaryPyro_RootUrlStore();
      if (Pyro_RootUrlStore != null)
      {
        DtoRootUrlStore = Common.CommonFactory.GetRootUrlStore();
        DtoRootUrlStore.ServiceRootUrlStoreID = Pyro_RootUrlStore.ServiceRootURL_StoreID;
        DtoRootUrlStore.RootUrl = Pyro_RootUrlStore.RootUrl;
        DtoRootUrlStore.IsServersPrimaryUrlRoot = Pyro_RootUrlStore.IsServersPrimaryUrlRoot;
      }
      return DtoRootUrlStore;
    }

    /// <summary>
    /// Gets the RootUrlStore Instance if found or creates a new instance if not found 
    /// </summary>
    /// <param name="UrlString"></param>
    /// <returns></returns>
    public ServiceRootURL_Store GetAndOrAddService_RootUrlStore(string ServiceRootUrl)
    {
      ServiceRootURL_Store Pyro_RootUrlStore = this.GetPyro_RootUrlStore(ServiceRootUrl);
      if (Pyro_RootUrlStore == null)
      {
        Pyro_RootUrlStore = new ServiceRootURL_Store();
        Pyro_RootUrlStore.IsServersPrimaryUrlRoot = false;
        Pyro_RootUrlStore.RootUrl = ServiceRootUrl;
        return Pyro_RootUrlStore;
      }
      else
      {
        return Pyro_RootUrlStore;
      }
    }

    protected ServiceRootURL_Store GetPrimaryPyro_RootUrlStore()
    {      
      return _Context.ServiceRootURL_Store.SingleOrDefault(x => x.IsServersPrimaryUrlRoot == true);      
    }

    /// <summary>
    /// Get a RootUrlStore by Url string
    /// </summary>
    /// <param name="UrlString"></param>
    /// <returns></returns>
    protected ServiceRootURL_Store GetPyro_RootUrlStore(string ServiceRootUrl)
    {
      return _Context.ServiceRootURL_Store.SingleOrDefault(x => x.RootUrl == ServiceRootUrl);
    }

    protected T DbGet<T>(Expression<Func<T, bool>> predicate) where T : class
    {
      T ResourceEntity = null;
      ResourceEntity = _Context.Set<T>().SingleOrDefault(predicate);
      return ResourceEntity;
    }

    protected IQueryable<T> DbGetAll<T>(Expression<Func<T, bool>> predicate) where T : class
    {
      IQueryable<T> ResourceEntity = null;
      ResourceEntity = _Context.Set<T>().AsExpandable().Where(predicate);
      return ResourceEntity;
    }

    protected int DbGetALLCount<T>(Expression<Func<T, bool>> predicate) where T : class
    {
      IQueryable<T> ResourceEntity = null;
      ResourceEntity = _Context.Set<T>().AsExpandable().Where(predicate);
      return ResourceEntity.Count();
    }

    protected void DbAddEntity<T>(T Entity) where T : class
    {
      _Context.Set<T>().Add(Entity);
      this.Save();
    }

    protected T DbQueryEntityWithInclude<T>(Expression<Func<T, bool>> predicate, List<Expression<Func<T, object>>> IncludeList) where T : class
    {
      T ResourceEntity = null;

      IQueryable<T> query = _Context.Set<T>();

      //Apply includes
      foreach (Expression<Func<T, object>> include in IncludeList)
        query = query.Include<T, object>(include);

      ResourceEntity = query.SingleOrDefault(predicate);
      return ResourceEntity;

    }

  }
}

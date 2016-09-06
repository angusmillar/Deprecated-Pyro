using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqKit;
using System.Linq.Expressions;
using System.Data.Entity;
using Blaze.DataModel.DatabaseModel;
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.DataModel.Search;
using Blaze.Common.Interfaces.Repositories;
using Blaze.Common.BusinessEntities.Dto;
using Blaze.Common.BusinessEntities.Search;


namespace Blaze.DataModel.Repository
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
          case Common.Enum.DatabaseEnum.DbIndexType.DateIndex:
            {
              
              if (SearchItem is DtoSearchParameterDate)
              {
                var SearchTypeDate = SearchItem as DtoSearchParameterDate;
                foreach (var SearchValue in SearchTypeDate.ValueList)
                {
                  
                  switch (SearchTypeDate.Modifier)
                  {
                    case Common.Enum.FhirSearchEnum.SearchModifierType.None:
                      if (SearchTypeDate.IsDbCollection)
                      {                        
                        NewPredicate = NewPredicate.Or(Search.DateCollectionAnyStartsOrEndsWith(SearchTypeDate.DbPropertyName, SearchValue.Value));
                      }
                      else
                      {
                        DateTimeOffset Test = new DateTimeOffset(SearchValue.Value.Date, new TimeSpan(0));
                        NewPredicate = NewPredicate.Or(Search.DatePropertyEqualTo(SearchTypeDate.DbPropertyName, Test));                        
                      }
                      break;
                    case Common.Enum.FhirSearchEnum.SearchModifierType.Missing:
                      break;
                    case Common.Enum.FhirSearchEnum.SearchModifierType.Exact:
                      if (SearchTypeDate.IsDbCollection)
                      {
                        //Predicate = Predicate.Or(Search.StringCollectionAnyEqualTo(SearchTypeString.DbPropertyName, SearchValue));
                      }
                      else
                      {
                        //Predicate = Predicate.Or(Search.StringPropertyEqualTo(SearchTypeString.DbPropertyName, SearchValue));
                      }
                      break;
                    case Common.Enum.FhirSearchEnum.SearchModifierType.Contains:
                      if (SearchTypeDate.IsDbCollection)
                      {
                        //Predicate = Predicate.Or(Search.StringCollectionAnyContains(SearchTypeString.DbPropertyName, SearchValue));
                      }
                      else
                      {
                        //Predicate = Predicate.Or(Search.StringPropertyContains(SearchTypeString.DbPropertyName, SearchValue));
                      }
                      break;
                    case Common.Enum.FhirSearchEnum.SearchModifierType.Text:
                      throw new FormatException($"The search modifier: {SearchTypeDate.Modifier.ToString()} is not supported for search parameter types of date.");
                    case Common.Enum.FhirSearchEnum.SearchModifierType.Type:
                      throw new FormatException($"The search modifier: {SearchTypeDate.Modifier.ToString()} is not supported for search parameter types of date.");
                    case Common.Enum.FhirSearchEnum.SearchModifierType.Below:
                      throw new FormatException($"The search modifier: {SearchTypeDate.Modifier.ToString()} is not supported for search parameter types of date.");
                    case Common.Enum.FhirSearchEnum.SearchModifierType.Above:
                      throw new FormatException($"The search modifier: {SearchTypeDate.Modifier.ToString()} is not supported for search parameter types of date.");
                    case Common.Enum.FhirSearchEnum.SearchModifierType.In:
                      throw new FormatException($"The search modifier: {SearchTypeDate.Modifier.ToString()} is not supported for search parameter types of date.");
                    case Common.Enum.FhirSearchEnum.SearchModifierType.NotIn:
                      throw new FormatException($"The search modifier: {SearchTypeDate.Modifier.ToString()} is not supported for search parameter types of date.");
                    default:
                      throw new System.ComponentModel.InvalidEnumArgumentException(SearchTypeDate.Modifier.ToString(), (int)SearchTypeDate.Modifier, typeof(Common.Enum.FhirSearchEnum.SearchModifierType));
                  }
                }       
              }
            }
            break;
          case Common.Enum.DatabaseEnum.DbIndexType.DatePeriodIndex:
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
            }
            break;
          case Common.Enum.DatabaseEnum.DbIndexType.QuantityIndex:
            break;
          case Common.Enum.DatabaseEnum.DbIndexType.QuantityRangeIndex:
            break;
          case Common.Enum.DatabaseEnum.DbIndexType.ReferenceIndex:
            break;
          case Common.Enum.DatabaseEnum.DbIndexType.StringIndex:
            {
              if (SearchItem is DtoSearchParameterString)
              {
                var SearchTypeString = SearchItem as DtoSearchParameterString;
                foreach (var SearchValue in SearchTypeString.Values)
                {
                  switch (SearchTypeString.Modifier)
                  {
                    case Common.Enum.FhirSearchEnum.SearchModifierType.None:
                      if (SearchTypeString.IsDbCollection)
                      {
                        NewPredicate = NewPredicate.Or(Search.StringCollectionAnyStartsOrEndsWith(SearchTypeString.DbPropertyName, SearchValue));
                      }
                      else
                      {
                        NewPredicate = NewPredicate.Or(Search.StringPropertyStartsOrEndsWith(SearchTypeString.DbPropertyName, SearchValue));
                      }
                      break;
                    case Common.Enum.FhirSearchEnum.SearchModifierType.Missing:
                      break;
                    case Common.Enum.FhirSearchEnum.SearchModifierType.Exact:
                      if (SearchTypeString.IsDbCollection)
                      {
                        NewPredicate = NewPredicate.Or(Search.StringCollectionAnyEqualTo(SearchTypeString.DbPropertyName, SearchValue));
                      }
                      else
                      {
                        NewPredicate = NewPredicate.Or(Search.StringPropertyEqualTo(SearchTypeString.DbPropertyName, SearchValue));
                      }
                      break;
                    case Common.Enum.FhirSearchEnum.SearchModifierType.Contains:
                      if (SearchTypeString.IsDbCollection)
                      {
                        NewPredicate = NewPredicate.Or(Search.StringCollectionAnyContains(SearchTypeString.DbPropertyName, SearchValue));
                      }
                      else
                      {
                        NewPredicate = NewPredicate.Or(Search.StringPropertyContains(SearchTypeString.DbPropertyName, SearchValue));
                      }
                      break;
                    case Common.Enum.FhirSearchEnum.SearchModifierType.Text:
                      throw new FormatException($"The search modifier: {SearchTypeString.Modifier.ToString()} is not supported for search parameter types of string.");
                    case Common.Enum.FhirSearchEnum.SearchModifierType.Type:
                      throw new FormatException($"The search modifier: {SearchTypeString.Modifier.ToString()} is not supported for search parameter types of string.");
                    case Common.Enum.FhirSearchEnum.SearchModifierType.Below:
                      throw new FormatException($"The search modifier: {SearchTypeString.Modifier.ToString()} is not supported for search parameter types of string.");
                    case Common.Enum.FhirSearchEnum.SearchModifierType.Above:
                      throw new FormatException($"The search modifier: {SearchTypeString.Modifier.ToString()} is not supported for search parameter types of string.");
                    case Common.Enum.FhirSearchEnum.SearchModifierType.In:
                      throw new FormatException($"The search modifier: {SearchTypeString.Modifier.ToString()} is not supported for search parameter types of string.");
                    case Common.Enum.FhirSearchEnum.SearchModifierType.NotIn:
                      throw new FormatException($"The search modifier: {SearchTypeString.Modifier.ToString()} is not supported for search parameter types of string.");
                    default:
                      throw new System.ComponentModel.InvalidEnumArgumentException(SearchTypeString.Modifier.ToString(), (int)SearchTypeString.Modifier, typeof(Common.Enum.FhirSearchEnum.SearchModifierType));
                  }
                }                
              }
            }
            break;
          case Common.Enum.DatabaseEnum.DbIndexType.TokenIndex:
            break;
          case Common.Enum.DatabaseEnum.DbIndexType.UriIndex:
            break;
          default:
            break;
        }
        //NewPredicate = NewPredicate.And(NewPredicate);
        MainPredicate.Extend<T>(NewPredicate, PredicateOperator.And);
      }

      return MainPredicate;
    }

    public DtoRootUrlStore SetPrimaryRootUrlStore(string RootUrl)
    {
      ServiceRootURL_Store ExsistingPrimaryRootURL = this.GetPrimaryBlaze_RootUrlStore();
      if (ExsistingPrimaryRootURL != null)
      {
        ExsistingPrimaryRootURL.IsServersPrimaryUrlRoot = false;
      }
      ServiceRootURL_Store ExsistingNonPrimaryRootURL = this.GetBlaze_RootUrlStore(RootUrl);
      if (ExsistingNonPrimaryRootURL != null)
      {
        ExsistingNonPrimaryRootURL.IsServersPrimaryUrlRoot = true;
      }
      else
      {
        ServiceRootURL_Store Blaze_RootUrlStore = new ServiceRootURL_Store();
        Blaze_RootUrlStore.IsServersPrimaryUrlRoot = true;
        Blaze_RootUrlStore.RootUrl = RootUrl;
        _Context.Set<ServiceRootURL_Store>().Add(Blaze_RootUrlStore);
      }
      this.Save();
      return this.GetPrimaryRootUrlStore();
    }

    public DtoRootUrlStore GetPrimaryRootUrlStore()
    {
      DtoRootUrlStore DtoRootUrlStore = null;
      ServiceRootURL_Store Blaze_RootUrlStore = this.GetPrimaryBlaze_RootUrlStore();
      if (Blaze_RootUrlStore != null)
      {
        DtoRootUrlStore = new DtoRootUrlStore();
        DtoRootUrlStore.ServiceRootUrlStoreID = Blaze_RootUrlStore.ServiceRootURL_StoreID;
        DtoRootUrlStore.RootUrl = Blaze_RootUrlStore.RootUrl;
        DtoRootUrlStore.IsServersPrimaryUrlRoot = Blaze_RootUrlStore.IsServersPrimaryUrlRoot;
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
      ServiceRootURL_Store Blaze_RootUrlStore = this.GetBlaze_RootUrlStore(ServiceRootUrl);
      if (Blaze_RootUrlStore == null)
      {
        Blaze_RootUrlStore = new ServiceRootURL_Store();
        Blaze_RootUrlStore.IsServersPrimaryUrlRoot = false;
        Blaze_RootUrlStore.RootUrl = ServiceRootUrl;
        return Blaze_RootUrlStore;
      }
      else
      {
        return Blaze_RootUrlStore;
      }
    }

    protected ServiceRootURL_Store GetPrimaryBlaze_RootUrlStore()
    {
      return _Context.ServiceRootURL_Store.SingleOrDefault(x => x.IsServersPrimaryUrlRoot == true);
    }

    /// <summary>
    /// Get a RootUrlStore by Url string
    /// </summary>
    /// <param name="UrlString"></param>
    /// <returns></returns>
    protected ServiceRootURL_Store GetBlaze_RootUrlStore(string ServiceRootUrl)
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

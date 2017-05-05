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
    public CommonRepository(Pyro.DataLayer.DbModel.DatabaseContext.PyroDbContext Context)
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
      return _Context.ServiceSearchParameter.Where(x => x.Resource == ResourceType)
        .Select(x => new Pyro.Common.BusinessEntities.Dto.DtoServiceSearchParameterLight
        {
          Id = x.Id,
          Name = x.Name,
          Expression = x.Expression,
          Resource = x.Resource,
          Type = x.Type
        }).ToList();     
    }
    
    public List<DtoServiceSearchParameterHeavy> GetServiceSearchParametersHeavy()
    {
      return _Context.ServiceSearchParameter
        .Select(x => new Pyro.Common.BusinessEntities.Dto.DtoServiceSearchParameterHeavy
        {
          Description = x.Description,
          Expression = x.Expression,
          Name = x.Name,
          Resource = x.Resource,
          Type = x.Type,
          Url = x.Url,
          XPath = x.XPath
        }).ToList();            
    }

    public List<DtoServiceSearchParameterHeavy> GetServiceSearchParametersHeavyForResource(string ResourceType)
    {
      return _Context.ServiceSearchParameter.Where(x => x.Resource == ResourceType)
        .Select(x => new Pyro.Common.BusinessEntities.Dto.DtoServiceSearchParameterHeavy
        {
          Id = x.Id,
          Name = x.Name,
          Expression = x.Expression,
          Resource = x.Resource,
          Type = x.Type,
          Description = x.Description,
          Url = x.Url,
          XPath = x.XPath
        }).ToList();
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

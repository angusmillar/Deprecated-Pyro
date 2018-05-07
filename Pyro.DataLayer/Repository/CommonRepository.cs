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
using Pyro.Common.Global;

namespace Pyro.DataLayer.Repository
{
  public class CommonRepository : BaseRepository, IDtoCommonRepository, Interfaces.ICommonRepository
  {
    protected readonly IPrimaryServiceRootCache IPrimaryServiceRootCache;
    protected readonly IDtoRootUrlStoreFactory IDtoRootUrlStoreFactory;
    private readonly AutoMapper.IMapper IMapper;
    #region Constructor
    public CommonRepository(IPyroDbContext IPyroDbContext, IPrimaryServiceRootCache IPrimaryServiceRootCache, IDtoRootUrlStoreFactory IDtoRootUrlStoreFactory, AutoMapper.IMapper IMapper)
      : base(IPyroDbContext)
    {
      this.IPrimaryServiceRootCache = IPrimaryServiceRootCache;
      this.IDtoRootUrlStoreFactory = IDtoRootUrlStoreFactory;
      this.IMapper = IMapper;
    }
    #endregion

    protected ExpressionStarter<ResIndexReferenceType>
      IndexRefPredicateGenerator<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      (int ResourceId, int[] ServiceSearchParameterIdArray, string ResourceName)
    where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    {
      var Predicate = LinqKit.PredicateBuilder.New<ResIndexReferenceType>(true);

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

    protected ExpressionStarter<ResIndexReferenceType>
      IndexRefPredicateGenerator<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      (int ResourceId, int[] ServiceSearchParameterIdArray)
    where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    {
      var Predicate = LinqKit.PredicateBuilder.New<ResIndexReferenceType>(true);

      Predicate = Predicate.And(x =>
        ServiceSearchParameterIdArray.Contains(x.ServiceSearchParameterId) &
        x.ResourceId == ResourceId &
        x.Resource.IsDeleted == false &
        x.Resource.IsCurrent == true &
        x.ReferenceUrl.IsServersPrimaryUrlRoot == true
      );

      return Predicate;
    }

    //Call for references in chain searches
    protected ExpressionStarter<ResCurrentType>
      ResourceCurrentPredicateGeneratorByRefereneNoPaging<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      (IEnumerable<string> FhirIdArray, string ResourceName, int ServiceSearchParameterId)
    where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    {
      var Predicate = LinqKit.PredicateBuilder.New<ResCurrentType>(true);

      Predicate = Predicate.And(x => x.IsDeleted == false &
                                     x.IsCurrent == true &
                                     x.IndexReferenceList.Any(y => y.ServiceSearchParameterId == ServiceSearchParameterId &
                                                                   y.ReferenceResourceType == ResourceName &
                                                                   FhirIdArray.Contains(y.ReferenceFhirId) &
                                                                   y.ReferenceUrl.IsServersPrimaryUrlRoot == true &
                                                                   y.ReferenceVersionId == null));
      return Predicate;
    }

    //---- PredicateGenerator ---------------------------------------------------------------
    protected ExpressionStarter<ResCurrentType> PredicateCurrentNotDeleted<
      ResCurrentType,
      ResIndexStringType,
      ResIndexTokenType,
      ResIndexUriType,
      ResIndexReferenceType,
      ResIndexQuantityType,
      ResIndexDateTimeType>()
    where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    {
      var NewPredicate = LinqKit.PredicateBuilder.New<ResCurrentType>(true);
      return NewPredicate.And(x => x.IsDeleted == false & x.IsCurrent == true);
    }

    protected ExpressionStarter<ResCurrentType> PredicateResourceIdAndLastUpdatedDate<
        ResCurrentType,
        ResIndexStringType,
        ResIndexTokenType,
        ResIndexUriType,
        ResIndexReferenceType,
        ResIndexQuantityType,
        ResIndexDateTimeType>(List<ISearchParameterBase> SearchParametersList)
      where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
      where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    {
      var Predicate = LinqKit.PredicateBuilder.New<ResCurrentType>(true);
      var Search = new ResourceSearch<
        ResCurrentType, 
        ResIndexStringType, 
        ResIndexTokenType, 
        ResIndexUriType, 
        ResIndexReferenceType, 
        ResIndexQuantityType, 
        ResIndexDateTimeType>();          

      IdSearchParameterPredicateProcessing(SearchParametersList, Search, Predicate);
      LastUpdatedDatePredicateBuilder<
        ResCurrentType,
        ResIndexStringType,
        ResIndexTokenType,
        ResIndexUriType,
        ResIndexReferenceType,
        ResIndexQuantityType,
        ResIndexDateTimeType>.Build(SearchParametersList, Search, Predicate);

      return Predicate;
    }

    protected ExpressionStarter<ResCurrentType> PredicateSearchParameter<
      ResCurrentType,
      ResIndexStringType,
      ResIndexTokenType,
      ResIndexUriType,
      ResIndexReferenceType,
      ResIndexQuantityType,
      ResIndexDateTimeType>(SearchParameterBase SearchItem)
    where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    {
      var Search = new ResourceSearch<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>();
      ExpressionStarter<ResCurrentType> Predicate = LinqKit.PredicateBuilder.New<ResCurrentType>();
      switch (SearchItem.Type)
      {
        case SearchParamType.Date:
          Predicate = DateTimePeriodPredicateBuilder<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>.Build(Search, Predicate, SearchItem);
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
            Predicate = NumberPredicateBuilder<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>.Build(Search, Predicate, SearchItem);
          }
          break;
        case SearchParamType.Quantity:
          Predicate = QuantityPredicateBuilder<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>.Build(Search, Predicate, SearchItem);
          break;
        case SearchParamType.Reference:
          Predicate = ReferancePredicateBuilder<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>.Build(Search, Predicate, SearchItem, IPrimaryServiceRootCache.GetPrimaryRootUrlFromDatabase());
          break;
        case SearchParamType.String:
          Predicate = StringPredicateBuilder<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>.Build(Search, Predicate, SearchItem);
          break;
        case SearchParamType.Token:
          Predicate = TokenPredicateBuilder<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>.Build(Search, Predicate, SearchItem);
          break;
        case SearchParamType.Uri:
          Predicate = UriPredicateBuilder<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>.Build(Search, Predicate, SearchItem);
          break;
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(SearchItem.Type.ToString(), (int)SearchItem.Type, typeof(SearchParamType));
      }
      return Predicate;
    }


    protected ExpressionStarter<ResCurrentType> ANDSearchParameterListPredicateGenerator<
      ResCurrentType,
      ResIndexStringType,
      ResIndexTokenType,
      ResIndexUriType,
      ResIndexReferenceType,
      ResIndexQuantityType,
      ResIndexDateTimeType>(List<ISearchParameterBase> SearchParametersList)
    where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    {
      var Predicate = LinqKit.PredicateBuilder.New<ResCurrentType>(true);
      foreach (SearchParameterBase SearchItem in SearchParametersList)
      {
        ExpressionStarter<ResCurrentType> NewPredicate = PredicateSearchParameter<
          ResCurrentType, 
          ResIndexStringType, 
          ResIndexTokenType, 
          ResIndexUriType, 
          ResIndexReferenceType, 
          ResIndexQuantityType, 
          ResIndexDateTimeType>(SearchItem);
        
        Predicate.Extend<ResCurrentType>(NewPredicate, PredicateOperator.And);
      }

      return Predicate;
    }

    protected ExpressionStarter<ResCurrentType> ORSearchParameterListPredicateGenerator<
      ResCurrentType,
      ResIndexStringType,
      ResIndexTokenType,
      ResIndexUriType,
      ResIndexReferenceType,
      ResIndexQuantityType,
      ResIndexDateTimeType>(List<ISearchParameterBase> SearchParametersList)
    where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    {
      var Predicate = LinqKit.PredicateBuilder.New<ResCurrentType>(true);
      foreach (SearchParameterBase SearchItem in SearchParametersList)
      {
        ExpressionStarter<ResCurrentType> NewPredicate = PredicateSearchParameter<
          ResCurrentType,
          ResIndexStringType,
          ResIndexTokenType,
          ResIndexUriType,
          ResIndexReferenceType,
          ResIndexQuantityType,
          ResIndexDateTimeType>(SearchItem);

        Predicate.Extend<ResCurrentType>(NewPredicate, PredicateOperator.Or);
      }

      return Predicate;
    }

    //---- PrimaryRootUrlStore -------------------------------------------------------------------
    public IDtoRootUrlStore SetPrimaryRootUrlStore(string RootUrl)
    {
      RootUrl = StringSupport.ToLowerFast(RootUrl.StripHttp());
      _ServiceBaseUrl ExsistingPrimaryRootURL = this.GetPrimaryPyro_RootUrlStore();
      if (ExsistingPrimaryRootURL != null)
      {
        ExsistingPrimaryRootURL.IsServersPrimaryUrlRoot = false;
      }
      _ServiceBaseUrl ExsistingNonPrimaryRootURL = this.GetPyro_RootUrlStore(RootUrl);
      if (ExsistingNonPrimaryRootURL != null)
      {
        ExsistingNonPrimaryRootURL.IsServersPrimaryUrlRoot = true;
      }
      else
      {
        _ServiceBaseUrl Pyro_RootUrlStore = new _ServiceBaseUrl();
        Pyro_RootUrlStore.IsServersPrimaryUrlRoot = true;
        Pyro_RootUrlStore.Url = RootUrl;
        IPyroDbContext.Set<_ServiceBaseUrl>().Add(Pyro_RootUrlStore);
      }
      this.Save();
      return this.GetPrimaryRootUrlStore();
    }

    public IDtoRootUrlStore GetPrimaryRootUrlStore()
    {
      IDtoRootUrlStore DtoRootUrlStore = null;
      _ServiceBaseUrl oServiceBaseUrl = GetPrimaryPyro_RootUrlStore();
      if (oServiceBaseUrl != null)
      {
        DtoRootUrlStore = IDtoRootUrlStoreFactory.CreateDtoRootUrlStore();
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
    public _ServiceBaseUrl GetAndOrAddService_RootUrlStore(string ServiceRootUrl)
    {
      ServiceRootUrl = StringSupport.ToLowerFast(ServiceRootUrl.StripHttp());
      _ServiceBaseUrl Pyro_RootUrlStore = this.GetPyro_RootUrlStore(ServiceRootUrl);
      if (Pyro_RootUrlStore == null)
      {
        Pyro_RootUrlStore = new _ServiceBaseUrl();
        Pyro_RootUrlStore.IsServersPrimaryUrlRoot = false;
        Pyro_RootUrlStore.Url = ServiceRootUrl;
        Pyro_RootUrlStore = IPyroDbContext.Set<_ServiceBaseUrl>().Add(Pyro_RootUrlStore);
        this.Save();
        return Pyro_RootUrlStore;
      }
      else
      {
        return Pyro_RootUrlStore;
      }
    }

    protected _ServiceBaseUrl GetPrimaryPyro_RootUrlStore()
    {
      return IPyroDbContext.ServiceBaseUrl.SingleOrDefault(x => x.IsServersPrimaryUrlRoot == true);
    }

    protected _ServiceBaseUrl GetPyro_RootUrlStore(string ServiceRootUrl)
    {
      ServiceRootUrl = StringSupport.ToLowerFast(ServiceRootUrl.StripHttp());
      return IPyroDbContext.ServiceBaseUrl.SingleOrDefault(x => x.Url == ServiceRootUrl);
    }

    //---- ServiceSearchParameters ---------------------------------------------------------------

    //public List<ServiceSearchParameterLight> GetServiceSearchParametersLightForResource(string ResourceType)
    //{
    //  var ReturnList = new List<ServiceSearchParameterLight>();
      
    //  var List = IPyroDbContext.ServiceSearchParameter.Include(x => x.TargetResourceTypeList)
    //    .Where(x => x.Resource == ResourceType & x.IsIndexed == true & x.Status == PublicationStatus.Active)
    //    .Select(x => new { x.Id, x.Name, x.Expression, x.Resource, x.Type, x.TargetResourceTypeList }).ToList();
      
    //  if (List != null)
    //  {
    //    foreach (var x in List)
    //    {
    //      var Light = new ServiceSearchParameterLight();
    //      Light.Id = x.Id;
    //      Light.Name = x.Name;
    //      Light.Expression = x.Expression;
    //      Light.Type = x.Type;
    //      Light.Resource = x.Resource;
    //      Light.TargetResourceTypeList = new List<IServiceSearchParameterTargetResource>();
    //      if (x.TargetResourceTypeList != null)
    //      {
    //        foreach (var Target in x.TargetResourceTypeList)
    //          Light.TargetResourceTypeList.Add(new DtoServiceSearchParameterTargetResource() { ResourceType = Target.ResourceType });
    //      }
    //      ReturnList.Add(Light);
    //    }
    //  }

    //  return ReturnList;
    //}

    //public List<ServiceSearchParameterHeavy> GetServiceSearchParametersHeavy(bool CustomOnly = false)
    //{
    //  var ReturnList = new List<ServiceSearchParameterHeavy>();

    //  List<_ServiceSearchParameter> ResourceServiceSearchParameterList;
    //  if (CustomOnly)
    //  {
    //    ResourceServiceSearchParameterList = IPyroDbContext.ServiceSearchParameter.Include(x => x.TargetResourceTypeList).Where(x => x.SearchParameterResourceId != null).ToList();
    //  }
    //  else
    //  {
    //    ResourceServiceSearchParameterList = IPyroDbContext.ServiceSearchParameter.Include(x => x.TargetResourceTypeList).ToList();
    //  }

    //  foreach (var x in ResourceServiceSearchParameterList)
    //  {
    //    var Heavy = new ServiceSearchParameterHeavy();
    //    Heavy.Id = x.Id;
    //    Heavy.Name = x.Name;
    //    Heavy.Expression = x.Expression;
    //    Heavy.Resource = x.Resource;
    //    Heavy.Type = x.Type;
    //    Heavy.Description = x.Description;
    //    Heavy.Url = x.Url;
    //    Heavy.XPath = x.XPath;
    //    Heavy.SearchParameterResourceId = x.SearchParameterResourceId;
    //    Heavy.SearchParameterResourceVersion = x.SearchParameterResourceVersion;
    //    Heavy.Status = x.Status;
    //    Heavy.IsIndexed = x.IsIndexed;
    //    Heavy.LastUpdated = x.LastUpdated;
    //    Heavy.TargetResourceTypeList = new List<IServiceSearchParameterTargetResource>();
    //    foreach (var Target in x.TargetResourceTypeList.ToList())
    //      Heavy.TargetResourceTypeList.Add(new DtoServiceSearchParameterTargetResource() { ResourceType = Target.ResourceType });
    //    ReturnList.Add(Heavy);
    //  }
    //  return ReturnList;
    //}

    //public List<ServiceSearchParameterHeavy> GetServiceSearchParametersHeavy()
    //{
    //  var ReturnList = new List<ServiceSearchParameterHeavy>();

    //  var ResourceServiceSearchParameterList = IPyroDbContext.ServiceSearchParameter.Include(x => x.TargetResourceTypeList).ToList();
    //  foreach (var x in ResourceServiceSearchParameterList)
    //  {
    //    var Heavy = new ServiceSearchParameterHeavy();
    //    Heavy.Id = x.Id;
    //    Heavy.Name = x.Name;
    //    Heavy.Expression = x.Expression;
    //    Heavy.Resource = x.Resource;
    //    Heavy.Type = x.Type;
    //    Heavy.Description = x.Description;
    //    Heavy.Url = x.Url;
    //    Heavy.XPath = x.XPath;
    //    Heavy.SearchParameterResourceId = x.SearchParameterResourceId;
    //    Heavy.SearchParameterResourceVersion = x.SearchParameterResourceVersion;
    //    Heavy.Status = x.Status;
    //    Heavy.IsIndexed = x.IsIndexed;
    //    Heavy.LastUpdated = x.LastUpdated;
    //    Heavy.TargetResourceTypeList = new List<IServiceSearchParameterTargetResource>();
    //    foreach (var Target in x.TargetResourceTypeList.ToList())
    //      Heavy.TargetResourceTypeList.Add(new DtoServiceSearchParameterTargetResource() { ResourceType = Target.ResourceType });
    //    ReturnList.Add(Heavy);
    //  }
    //  return ReturnList;
    //}

    //public List<ServiceSearchParameterHeavy> GetServiceSearchParametersHeavyForResource(string ResourceType)
    //{
    //  var ReturnList = new List<ServiceSearchParameterHeavy>();

    //  var ResourceServiceSearchParameterList = IPyroDbContext.ServiceSearchParameter.Where(x => x.Resource == ResourceType).Include(x => x.TargetResourceTypeList).ToList();
    //  foreach (var x in ResourceServiceSearchParameterList)
    //  {
    //    var Heavy = new ServiceSearchParameterHeavy();
    //    Heavy.Id = x.Id;
    //    Heavy.Name = x.Name;
    //    Heavy.Expression = x.Expression;
    //    Heavy.Resource = x.Resource;
    //    Heavy.Type = x.Type;
    //    Heavy.Description = x.Description;
    //    Heavy.Url = x.Url;
    //    Heavy.XPath = x.XPath;
    //    Heavy.SearchParameterResourceId = x.SearchParameterResourceId;
    //    Heavy.SearchParameterResourceVersion = x.SearchParameterResourceVersion;
    //    Heavy.Status = x.Status;
    //    Heavy.IsIndexed = x.IsIndexed;
    //    Heavy.LastUpdated = x.LastUpdated;
    //    Heavy.TargetResourceTypeList = new List<IServiceSearchParameterTargetResource>();
    //    foreach (var Target in x.TargetResourceTypeList.ToList())
    //      Heavy.TargetResourceTypeList.Add(new DtoServiceSearchParameterTargetResource() { ResourceType = Target.ResourceType });
    //    ReturnList.Add(Heavy);
    //  }
    //  return ReturnList;

    //}

    //public ServiceSearchParameterHeavy AddServiceSearchParametersHeavy(ServiceSearchParameterHeavy ServiceSearchParameterHeavy)
    //{
    //  if (ServiceSearchParameterHeavy == null)
    //    return null;

    //  var DbSearchParameter = new _ServiceSearchParameter();
    //  DbSearchParameter.Description = ServiceSearchParameterHeavy.Description;
    //  DbSearchParameter.Expression = ServiceSearchParameterHeavy.Expression;
    //  DbSearchParameter.IsIndexed = ServiceSearchParameterHeavy.IsIndexed;
    //  DbSearchParameter.LastUpdated = DateTimeOffset.Now;
    //  DbSearchParameter.Name = ServiceSearchParameterHeavy.Name;
    //  DbSearchParameter.Resource = ServiceSearchParameterHeavy.Resource;
    //  DbSearchParameter.SearchParameterResourceId = ServiceSearchParameterHeavy.SearchParameterResourceId;
    //  DbSearchParameter.SearchParameterResourceVersion = ServiceSearchParameterHeavy.SearchParameterResourceVersion;
    //  DbSearchParameter.Status = ServiceSearchParameterHeavy.Status;
    //  DbSearchParameter.Type = ServiceSearchParameterHeavy.Type;
    //  DbSearchParameter.Url = ServiceSearchParameterHeavy.Url;
    //  DbSearchParameter.XPath = ServiceSearchParameterHeavy.XPath;
    //  if (ServiceSearchParameterHeavy.TargetResourceTypeList != null)
    //  {
    //    DbSearchParameter.TargetResourceTypeList = new List<_ServiceSearchParameterTargetResource>();
    //    foreach (var Target in ServiceSearchParameterHeavy.TargetResourceTypeList)
    //      DbSearchParameter.TargetResourceTypeList.Add(new _ServiceSearchParameterTargetResource() { ResourceType = Target.ResourceType });
    //  }
    //  _ServiceSearchParameter value = AddServiceSearchParameters(DbSearchParameter);
    //  ServiceSearchParameterHeavy.Id = value.Id;
    //  this.Save();
    //  return ServiceSearchParameterHeavy;
    //}

    //public ServiceSearchParameterHeavy UpdateServiceSearchParametersHeavy(ServiceSearchParameterHeavy ServiceSearchParameterHeavy)
    //{
    //  if (ServiceSearchParameterHeavy == null)
    //    return null;

    //  var DbSearchParameter = new _ServiceSearchParameter();
    //  DbSearchParameter.Description = ServiceSearchParameterHeavy.Description;
    //  DbSearchParameter.Expression = ServiceSearchParameterHeavy.Expression;
    //  DbSearchParameter.IsIndexed = ServiceSearchParameterHeavy.IsIndexed;
    //  DbSearchParameter.LastUpdated = DateTimeOffset.Now;
    //  DbSearchParameter.Name = ServiceSearchParameterHeavy.Name;
    //  DbSearchParameter.Resource = ServiceSearchParameterHeavy.Resource;
    //  DbSearchParameter.SearchParameterResourceId = ServiceSearchParameterHeavy.SearchParameterResourceId;
    //  DbSearchParameter.SearchParameterResourceVersion = ServiceSearchParameterHeavy.SearchParameterResourceVersion;
    //  DbSearchParameter.Status = ServiceSearchParameterHeavy.Status;
    //  DbSearchParameter.Type = ServiceSearchParameterHeavy.Type;
    //  DbSearchParameter.Url = ServiceSearchParameterHeavy.Url;
    //  DbSearchParameter.XPath = ServiceSearchParameterHeavy.XPath;
    //  if (ServiceSearchParameterHeavy.TargetResourceTypeList != null)
    //  {
    //    DbSearchParameter.TargetResourceTypeList = new List<_ServiceSearchParameterTargetResource>();
    //    foreach (var Target in ServiceSearchParameterHeavy.TargetResourceTypeList)
    //      DbSearchParameter.TargetResourceTypeList.Add(new _ServiceSearchParameterTargetResource() { ResourceType = Target.ResourceType });
    //  }
    //  _ServiceSearchParameter value = UpdateServiceSearchParameters(ServiceSearchParameterHeavy.Id, DbSearchParameter);
    //  ServiceSearchParameterHeavy.Id = value.Id;
    //  return ServiceSearchParameterHeavy;
    //}

    //public void DeleteServiceSearchParameters(int Id)
    //{
    //  var Entity = IPyroDbContext.ServiceSearchParameter.SingleOrDefault(x => x.Id == Id);
    //  if (Entity != null)
    //  {
    //    IPyroDbContext.ServiceSearchParameter.Remove(Entity);
    //    this.Save();
    //  }
    //}

    //protected _ServiceSearchParameter AddServiceSearchParameters(_ServiceSearchParameter ServiceSearchParameter)
    //{
    //  ServiceSearchParameter = IPyroDbContext.Set<_ServiceSearchParameter>().Add(ServiceSearchParameter);
    //  this.Save();
    //  return ServiceSearchParameter;
    //}

    //protected _ServiceSearchParameter GetServiceSearchParameters(string ResourceType, string Name)
    //{
    //  return IPyroDbContext.ServiceSearchParameter.SingleOrDefault(x => x.Resource == ResourceType & x.Name == Name);
    //}

    //protected _ServiceSearchParameter UpdateServiceSearchParameters(int Id, _ServiceSearchParameter SearchParameter)
    //{
    //  var DbSearchParameter = IPyroDbContext.ServiceSearchParameter.SingleOrDefault(x => x.Id == Id);
    //  DbSearchParameter.Description = SearchParameter.Description;
    //  DbSearchParameter.Expression = SearchParameter.Expression;
    //  DbSearchParameter.IsIndexed = SearchParameter.IsIndexed;
    //  DbSearchParameter.LastUpdated = DateTimeOffset.Now;
    //  DbSearchParameter.Name = SearchParameter.Name;
    //  DbSearchParameter.Resource = SearchParameter.Resource;
    //  DbSearchParameter.SearchParameterResourceId = SearchParameter.SearchParameterResourceId;
    //  DbSearchParameter.SearchParameterResourceVersion = SearchParameter.SearchParameterResourceVersion;
    //  DbSearchParameter.Status = SearchParameter.Status;
    //  DbSearchParameter.TargetResourceTypeList = SearchParameter.TargetResourceTypeList;
    //  DbSearchParameter.Type = SearchParameter.Type;
    //  DbSearchParameter.Url = SearchParameter.Url;
    //  DbSearchParameter.XPath = SearchParameter.XPath;
    //  IPyroDbContext.Entry(DbSearchParameter).State = EntityState.Modified;
    //  this.Save();
    //  return DbSearchParameter;
    //}

    //protected List<_ServiceSearchParameter> GetAllServiceSearchParameters()
    //{
    //  return IPyroDbContext.ServiceSearchParameter.ToList();
    //}

    //---- ServiceCompartment---------------------------------------------------------------

    //public _ServiceCompartment GetServiceCompartment(string Code)
    //{
    //  return IPyroDbContext.ServiceCompartment.SingleOrDefault(x => x.Code == Code);      
    //}

    //public _ServiceCompartment UpdateServiceCompartment(_ServiceCompartment ServiceCompartment)
    //{
    //  DeleteServiceCompartment(ServiceCompartment.Code);
    //  ServiceCompartment = IPyroDbContext.Set<_ServiceCompartment>().Add(ServiceCompartment);
    //  this.Save();
    //  return ServiceCompartment;

    //}

    public bool DeleteServiceCompartment(string Code)
    {
      var Entity = IPyroDbContext.ServiceCompartment.SingleOrDefault(x => x.Code == Code);
      if (Entity != null)
      {
        IPyroDbContext.ServiceCompartment.Remove(Entity);
        this.Save();
        return true;
      }
      return false;
    }

    //---- Resource ---------------------------------------------------------------

    protected ResCurrentType DbGet<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(Expression<Func<ResCurrentType, bool>> predicate)
      where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
      where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>

    {
      ResCurrentType ResourceEntity = null;
      ResourceEntity = IPyroDbContext.Set<ResCurrentType>().SingleOrDefault(predicate);
      return ResourceEntity;
    }

    protected DtoResource DbGetNoXML<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(Expression<Func<ResCurrentType, bool>> predicate)
      where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
      where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>

    {
      return IPyroDbContext.Set<ResCurrentType>().Where(predicate).Select(x => new Pyro.Common.BusinessEntities.Dto.DtoResource
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

    protected DtoResource DbGetWithXML<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(Expression<Func<ResCurrentType, bool>> predicate)
      where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
      where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>

    {
      return IPyroDbContext.Set<ResCurrentType>().AsExpandable().Where(predicate).Select(x => new Pyro.Common.BusinessEntities.Dto.DtoResource
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

    protected IQueryable<ResIndexReferenceType> DbGetIndexAll<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(Expression<Func<ResIndexReferenceType, bool>> predicate)
      where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
      where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>

    {
      IQueryable<ResIndexReferenceType> ResourceIndexEntity = null;
      ResourceIndexEntity = IPyroDbContext.Set<ResIndexReferenceType>().AsExpandable().Where(predicate);
      return ResourceIndexEntity;
    }

    protected IQueryable<ResCurrentType> DbGetAll<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(Expression<Func<ResCurrentType, bool>> predicate)
      where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
      where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>

    {
      IQueryable<ResCurrentType> ResourceEntity = null;
      ResourceEntity = IPyroDbContext.Set<ResCurrentType>().AsExpandable().Where(predicate);
      return ResourceEntity;
    }

    protected int DbGetALLCount<ResourceBaseType>(Expression<Func<ResourceBaseType, bool>> predicate)
      where ResourceBaseType : ResourceBase
    {
      IQueryable<ResourceBaseType> ResourceEntity = null;
      ResourceEntity = IPyroDbContext.Set<ResourceBaseType>().AsExpandable().Where(predicate);
      return ResourceEntity.Count();
    }

    protected void DbAddEntity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(ResCurrentType Entity)
      where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
      where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>

    {
      IPyroDbContext.Set<ResCurrentType>().Add(Entity);
      this.Save();
    }

    protected ResCurrentType DbQueryEntityWithInclude<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(Expression<Func<ResCurrentType, bool>> predicate, List<Expression<Func<ResCurrentType, object>>> IncludeList)
      where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
      where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>

    {
      ResCurrentType ResourceEntity = null;

      IQueryable<ResCurrentType> query = IPyroDbContext.Set<ResCurrentType>();

      //Apply includes
      foreach (Expression<Func<ResCurrentType, object>> include in IncludeList)
        query = query.Include<ResCurrentType, object>(include);

      ResourceEntity = query.SingleOrDefault(predicate);
      return ResourceEntity;

    }

    private static void IdSearchParameterPredicateProcessing<
      ResCurrentType, 
      ResIndexStringType, 
      ResIndexTokenType, 
      ResIndexUriType, 
      ResIndexReferenceType, 
      ResIndexQuantityType, 
      ResIndexDateTimeType>(List<ISearchParameterBase> SearchParametersList, ResourceSearch<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType> Search, ExpressionStarter<ResCurrentType> MainPredicate)
      where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
      where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>

    {
      var IdSearchParamerterList = SearchParametersList.Where(x => x.Resource == FHIRAllTypes.Resource.GetLiteral() && x.Name == "_id");
      if (IdSearchParamerterList != null)
      {
        ExpressionStarter<ResCurrentType> NewIdPredicate = null;
        foreach (var IdSearchParameter in IdSearchParamerterList)
        {
          if (IdSearchParameter is SearchParameterToken SearchTypeToken)
          {
            NewIdPredicate = LinqKit.PredicateBuilder.New<ResCurrentType>();
            foreach (var SearchValue in SearchTypeToken.ValueList)
            {
              if (!SearchTypeToken.Modifier.HasValue)
              {
                var Expression = Search.TokenMainAnyEqualTo(SearchValue.Code);
                NewIdPredicate = NewIdPredicate.Or(Expression);
              }
            }
          }
          MainPredicate.Extend<ResCurrentType>(NewIdPredicate, PredicateOperator.And);
        }
        SearchParametersList.RemoveAll(x => x.Resource == FHIRAllTypes.Resource.GetLiteral() && x.Name == "_id");
      }
    }
  }

}

using Hl7.Fhir.Model;
using LinqKit;
using Pyro.Common.DtoEntity;
using Pyro.Common.Search;
using Pyro.Common.ServiceRoot;
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
using Pyro.Common.CompositionRoot;
using Pyro.Common.Global;
using Pyro.Common.Search.SearchParameterEntity;

namespace Pyro.DataLayer.Repository
{
  public class CommonRepository : BaseRepository
  {
    protected readonly IPrimaryServiceRootCache IPrimaryServiceRootCache;
    
    #region Constructor
    public CommonRepository(IPyroDbContext IPyroDbContext, IPrimaryServiceRootCache IPrimaryServiceRootCache)
      : base(IPyroDbContext)
    {
      this.IPrimaryServiceRootCache = IPrimaryServiceRootCache;          
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
      return IPyroDbContext.Set<ResCurrentType>().Where(predicate).Select(x => new DtoResource
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
      return IPyroDbContext.Set<ResCurrentType>().AsExpandable().Where(predicate).Select(x => new DtoResource
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

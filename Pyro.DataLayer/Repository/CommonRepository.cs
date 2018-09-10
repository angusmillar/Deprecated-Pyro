using Hl7.Fhir.Model;
using LinqKit;
using Pyro.Common.DtoEntity;
using Pyro.Common.ServiceRoot;
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
using Pyro.Common.Search.SearchParameterEntity;
using System.Data;

namespace Pyro.DataLayer.Repository
{
  public class CommonRepository<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    : BaseRepository
    where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
  {
    protected readonly IPrimaryServiceRootCache IPrimaryServiceRootCache;
    private readonly ResourceSearch<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType> _ResourceSearch;
    

    #region Constructor
    public CommonRepository(IPyroDbContext IPyroDbContext, IPrimaryServiceRootCache IPrimaryServiceRootCache)
      : base(IPyroDbContext)
    {
      this.IPrimaryServiceRootCache = IPrimaryServiceRootCache;
      _ResourceSearch = new ResourceSearch<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>(IPrimaryServiceRootCache);
    }
    #endregion

    public ExpressionStarter<ResIndexReferenceType> IndexRefPredicateGenerator(int ResourceId, int[] ServiceSearchParameterIdArray, string ResourceName)
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

    public ExpressionStarter<ResIndexReferenceType> IndexRefPredicateGenerator(int ResourceId, int[] ServiceSearchParameterIdArray)
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
    public ExpressionStarter<ResCurrentType> ResourceCurrentPredicateGeneratorByRefereneNoPaging(IEnumerable<string> FhirIdArray, string ResourceName, int ServiceSearchParameterId)
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
    public ExpressionStarter<ResCurrentType> PredicateCurrentNotDeleted()
    {
      var NewPredicate = LinqKit.PredicateBuilder.New<ResCurrentType>(true);
      return NewPredicate.And(x => x.IsDeleted == false & x.IsCurrent == true);
    }

    public ExpressionStarter<ResCurrentType> PredicateResourceIdAndLastUpdatedDate(List<ISearchParameterBase> SearchParametersList)
    {
      var Predicate = LinqKit.PredicateBuilder.New<ResCurrentType>(true);
      var Search = new ResourceSearchExpressionTrees<
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

    public ExpressionStarter<ResCurrentType> PredicateSearchParameter(SearchParameterBase SearchItem)
    {
      return _ResourceSearch.PredicateSearchParameter(SearchItem);
    }

    public ExpressionStarter<ResCurrentType> ANDSearchParameterListPredicateGenerator(List<ISearchParameterBase> SearchParametersList)
    {
      return _ResourceSearch.ANDSearchParameterListPredicateGenerator(SearchParametersList);
    }

    public ExpressionStarter<ResCurrentType> ORSearchParameterListPredicateGenerator(List<ISearchParameterBase> SearchParametersList)
    {
      return _ResourceSearch.ORSearchParameterListPredicateGenerator(SearchParametersList);
    }

    //---- Resource ---------------------------------------------------------------

    public ResCurrentType DbGet(Expression<Func<ResCurrentType, bool>> predicate)
    {
      ResCurrentType ResourceEntity = null;
      ResourceEntity = IPyroDbContext.Set<ResCurrentType>().SingleOrDefault(predicate);
      return ResourceEntity;
    }

    public DtoResource DbGetNoXML(Expression<Func<ResCurrentType, bool>> predicate)
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

    public DtoResource DbGetWithXML(Expression<Func<ResCurrentType, bool>> predicate)
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
        Resource = x.Resource
      }).FirstOrDefault();
    }

    public IQueryable<ResIndexReferenceType> DbGetIndexAll(Expression<Func<ResIndexReferenceType, bool>> predicate)
    {
      IQueryable<ResIndexReferenceType> ResourceIndexEntity = null;
      ResourceIndexEntity = IPyroDbContext.Set<ResIndexReferenceType>().AsExpandable().Where(predicate);
      return ResourceIndexEntity;
    }

    public IQueryable<ResCurrentType> DbGetAll(Expression<Func<ResCurrentType, bool>> predicate)
    {
      IQueryable<ResCurrentType> ResourceEntity = null;
      ResourceEntity = IPyroDbContext.Set<ResCurrentType>().AsExpandable().Where(predicate);
      return ResourceEntity;
    }

    public int DbGetALLCount<ResourceBaseType>(Expression<Func<ResourceBaseType, bool>> predicate)
      where ResourceBaseType : ResourceBase
    {
      IQueryable<ResourceBaseType> ResourceEntity = null;
      ResourceEntity = IPyroDbContext.Set<ResourceBaseType>().AsExpandable().Where(predicate);
      return ResourceEntity.Count();
    }
    
    public void DbAddEntity(ResCurrentType Entity)
    {
      IPyroDbContext.Set<ResCurrentType>().Add(Entity);
      this.Save();
    }

    public ResCurrentType DbQueryEntityWithInclude(Expression<Func<ResCurrentType, bool>> predicate, List<Expression<Func<ResCurrentType, object>>> IncludeList)
    {
      ResCurrentType ResourceEntity = null;

      IQueryable<ResCurrentType> query = IPyroDbContext.Set<ResCurrentType>();

      //Apply includes
      foreach (Expression<Func<ResCurrentType, object>> include in IncludeList)
        query = query.Include<ResCurrentType, object>(include);

      ResourceEntity = query.SingleOrDefault(predicate);
      return ResourceEntity;

    }

    private static void IdSearchParameterPredicateProcessing(List<ISearchParameterBase> SearchParametersList, ResourceSearchExpressionTrees<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType> Search, ExpressionStarter<ResCurrentType> MainPredicate)
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
                var Expression = Search.MainResourceFhirIdAny(SearchValue.Code);
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

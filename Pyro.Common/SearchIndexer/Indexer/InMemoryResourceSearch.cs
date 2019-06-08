using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using LinqKit;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Search;
using Pyro.Common.Search.SearchParameterEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.SearchIndexer.Indexer.Predicate;
using Pyro.Common.ServiceRoot;
using Pyro.Common.Enum;

namespace Pyro.Common.SearchIndexer.Indexer
{
  /// <summary>
  /// This used the same standard FHIR search parameters to search on a list of provided Resource all in memory
  /// </summary>
  public class InMemoryResourceSearch : IInMemoryResourceSearch
  {
    private readonly IGenericInstanceFactory IGenericInstanceFactory;
    private readonly IPrimaryServiceRootCache IPrimaryServiceRootCache;

    public InMemoryResourceSearch(IGenericInstanceFactory IGenericInstanceFactory, IPrimaryServiceRootCache IPrimaryServiceRootCache)
    {
      this.IGenericInstanceFactory = IGenericInstanceFactory;
      this.IPrimaryServiceRootCache = IPrimaryServiceRootCache;
    }

    private List<IResourceIndexed> MainResourceList;    

    /// <summary>
    /// This method only indexes for the search parameters provided, so it is faster that  LoadResource followed by Search.
    /// Note: Chain searches do not work in this indexer, only in the databsed indexes
    /// </summary>
    /// <param name="ResourceList"></param>
    /// <param name="DtoSearchParameters"></param>
    /// <returns></returns>
    public List<IResourceIndexed> SearchResourceList(ICollection<Resource> ResourceList, PyroSearchParameters DtoSearchParameters)
    {
      MainResourceList = new List<IResourceIndexed>();
      foreach (Resource Res in ResourceList)
      {
        if (Res.ResourceType == Common.Tools.ResourceNameResolutionSupport.GetResourceType(DtoSearchParameters.ResourceTarget.GetLiteral()))
        {
          var ResourceIndexed = IGenericInstanceFactory.Create<IResourceIndexed>();
          ResourceIndexed.Index(Res, DtoSearchParameters);
          MainResourceList.Add(ResourceIndexed);
        }
      }
      return SearchLoadedResources(DtoSearchParameters);
    }

    public List<IResourceIndexed> SearchKeyedResourceList(Dictionary<string, Resource> ResourceDictonary, PyroSearchParameters DtoSearchParameters)
    {
      MainResourceList = new List<IResourceIndexed>();
      foreach (var DicItem in ResourceDictonary)
      {
        if (DicItem.Value.ResourceType == Common.Tools.ResourceNameResolutionSupport.GetResourceType(DtoSearchParameters.ResourceTarget.GetLiteral()))
        {
          var ResourceIndexed = IGenericInstanceFactory.Create<IResourceIndexed>();
          ResourceIndexed.Index(DicItem.Value, DtoSearchParameters);
          ResourceIndexed.Key = DicItem.Key;
          MainResourceList.Add(ResourceIndexed);
        }
      }
      return SearchLoadedResources(DtoSearchParameters);
    }

    /// <summary>
    /// This method indexes the entrie resource list for all possiable search parameters
    /// Note: It is faster to use SearchResourceList as it only indexes for the search parameters provided
    /// </summary>
    /// <param name="ResourceList"></param>
    public void LoadResourceList(ICollection<Resource> ResourceList)
    {
      MainResourceList = new List<IResourceIndexed>();
      foreach (Resource Res in ResourceList)
      {
        var ResourceIndexed = IGenericInstanceFactory.Create<IResourceIndexed>();
        ResourceIndexed.Index(Res);
        MainResourceList.Add(ResourceIndexed);
      }
    }    

    /// <summary>
    ///  Search the loaded resources for the given search parameters    
    ///  Note: It is faster to use SearchResourceList as it only indexes for the search parameters provided
    ///  Note: Chain searches do not work in this indexer, only in the databsed indexes
    /// </summary>
    /// <param name="DtoSearchParameters"></param>
    /// <returns></returns>
    public List<IResourceIndexed> SearchLoadedResources(PyroSearchParameters DtoSearchParameters)
    {
      var Predicate = LinqKit.PredicateBuilder.New<IResourceIndexed>(true);
      var TargetResourceList = MainResourceList.Where(x => x.ResourceType == Common.Tools.ResourceNameResolutionSupport.GetResourceType(DtoSearchParameters.ResourceTarget.GetLiteral()));
      Predicate = ANDSearchParameterListPredicateGenerator(DtoSearchParameters.SearchParametersList);      
      IEnumerable<IResourceIndexed> ResultList = TargetResourceList.Where(Predicate);
      return ResultList.ToList();
    }

    private ExpressionStarter<IResourceIndexed> ANDSearchParameterListPredicateGenerator(List<ISearchParameterBase> SearchParametersList)
    {
      var Predicate = LinqKit.PredicateBuilder.New<IResourceIndexed>(true);
      foreach (SearchParameterBase SearchItem in SearchParametersList)
      {
        ExpressionStarter<IResourceIndexed> NewPredicate = PredicateSearchParameter(SearchItem);

        Predicate.Extend<IResourceIndexed>(NewPredicate, PredicateOperator.And);
      }

      return Predicate;
    }

    private ExpressionStarter<IResourceIndexed> PredicateSearchParameter(SearchParameterBase SearchItem)
    {
      var Search = new Search<IResourceIndexed>();      
      ExpressionStarter<IResourceIndexed> Predicate = LinqKit.PredicateBuilder.New<IResourceIndexed>();
      switch (SearchItem.Type)
      {
        case SearchParamType.Date:
          Predicate = DateTimePeriodPredicateBuilder<IResourceIndexed>.Build(Search, Predicate, SearchItem);
          break;
        case SearchParamType.Number:
          {
            if (SearchItem is SearchParameterNumber)
            {
              var SearchTypeNumber = SearchItem as SearchParameterNumber;
              foreach (var SearchValue in SearchTypeNumber.ValueList)
              {
                if (SearchTypeNumber.Name != SearchParameterSearchResultParameterType.page.GetPyroLiteral())
                {
                  //ToDo: more needed here
                }
              }
            }
            Predicate = NumberPredicateBuilder<IResourceIndexed>.Build(Search, Predicate, SearchItem);
          }
          break;
        case SearchParamType.Quantity:
          Predicate = QuantityPredicateBuilder<IResourceIndexed>.Build(Search, Predicate, SearchItem);
          break;
        case SearchParamType.Reference:
          Predicate = ReferancePredicateBuilder<IResourceIndexed>.Build(Search, Predicate, SearchItem, IPrimaryServiceRootCache.GetPrimaryRootUrlStoreFromDatabase());
          break;
        case SearchParamType.String:
          Predicate = StringPredicateBuilder<IResourceIndexed>.Build(Search, Predicate, SearchItem);
          break;
        case SearchParamType.Token:
          Predicate = TokenPredicateBuilder<IResourceIndexed>.Build(Search, Predicate, SearchItem);
          break;
        case SearchParamType.Uri:
          Predicate = UriPredicateBuilder<IResourceIndexed>.Build(Search, Predicate, SearchItem);
          break;
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(SearchItem.Type.ToString(), (int)SearchItem.Type, typeof(SearchParamType));
      }
      return Predicate;
    }
  }
}

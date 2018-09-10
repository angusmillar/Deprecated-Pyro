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
using System.Data;
using System.Data.Entity.Core.Objects;

namespace Pyro.DataLayer.Search
{
  public class ResourceSearch<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>    
    where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
  {
    protected readonly IPrimaryServiceRootCache IPrimaryServiceRootCache;

    #region Constructor
    public ResourceSearch(IPrimaryServiceRootCache IPrimaryServiceRootCache)
    {
      this.IPrimaryServiceRootCache = IPrimaryServiceRootCache;
    }
    #endregion

    public ExpressionStarter<ResCurrentType> ANDSearchParameterListPredicateGenerator(List<ISearchParameterBase> SearchParametersList)
    {
      var Predicate = LinqKit.PredicateBuilder.New<ResCurrentType>(true);
      foreach (SearchParameterBase SearchItem in SearchParametersList)
      {
        ExpressionStarter<ResCurrentType> NewPredicate = PredicateSearchParameter(SearchItem);

        Predicate.Extend<ResCurrentType>(NewPredicate, PredicateOperator.And);
      }

      return Predicate;
    }

    public ExpressionStarter<ResCurrentType> ORSearchParameterListPredicateGenerator(List<ISearchParameterBase> SearchParametersList)
    {
      var Predicate = LinqKit.PredicateBuilder.New<ResCurrentType>(true);
      foreach (SearchParameterBase SearchItem in SearchParametersList)
      {
        ExpressionStarter<ResCurrentType> NewPredicate = PredicateSearchParameter(SearchItem);

        Predicate.Extend<ResCurrentType>(NewPredicate, PredicateOperator.Or);
      }

      return Predicate;
    }

    public ExpressionStarter<ResCurrentType> PredicateSearchParameter(SearchParameterBase SearchItem)
    {
      var Search = new ResourceSearchExpressionTrees<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>();
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
          Predicate = ReferancePredicateBuilder<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>.Build(Search, Predicate, SearchItem, IPrimaryServiceRootCache.GetPrimaryRootUrlStoreFromDatabase());
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
        case SearchParamType.Composite:          
          Predicate = CompositePredicateBuilder<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>.Build(Search, Predicate, SearchItem, IPrimaryServiceRootCache);
          break;
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(SearchItem.Type.ToString(), (int)SearchItem.Type, typeof(SearchParamType));
      }
      return Predicate;
    }

   
  }

}

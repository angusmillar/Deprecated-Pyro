using System;
using LinqKit;
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.DataModel.Search;
using Blaze.Common.BusinessEntities.Search;

namespace Blaze.DataModel.Repository
{
  public static class ReferancePredicateBuilder
  {
    public static ExpressionStarter<T> Build<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterBase SearchItem, Common.Interfaces.Dto.IDtoRootUrlStore PrimaryRootUrlStore) where T : ResourceIndexBase
    {
      if (SearchItem is DtoSearchParameterReferance)
      {
        var SearchTypeReferance = SearchItem as DtoSearchParameterReferance;
        if (SearchTypeReferance.ChainedSearchParameter != null)
        {
          throw new NotImplementedException("Chained parameters have not been implemented for use on this server.");
        }
        else
        {
          foreach (var SearchValue in SearchTypeReferance.ValueList)
          {
            switch (SearchTypeReferance.Modifier)
            {
              case Common.Enum.FhirSearchEnum.SearchModifierType.None:
                if (SearchTypeReferance.IsDbCollection)
                {
                  //NewPredicate = NewPredicate.Or(Search.UriCollectionAnyEqualTo(SearchTypeReferance.DbPropertyName, SearchValue.Value.ToString()));
                }
                else
                {
                  if (IsServiceUrlPrimary(PrimaryRootUrlStore, SearchValue))
                  {
                    NewPredicate = NewPredicate.Or(Search.ReferancePropertyEqualTo_ByKey(SearchTypeReferance.DbPropertyName, PrimaryRootUrlStore.ServiceRootUrlStoreID, SearchValue.FhirUri.ResourseType, SearchValue.FhirUri.Id, SearchValue.FhirUri.VersionId));
                  }
                  else
                  {
                    NewPredicate = NewPredicate.Or(Search.ReferancePropertyEqualTo_ByUrlString(SearchTypeReferance.DbPropertyName, SearchValue.FhirUri.ServiceRootUrlForComparison, SearchValue.FhirUri.ResourseType, SearchValue.FhirUri.Id, SearchValue.FhirUri.VersionId));
                  }
                  //NewPredicate = NewPredicate.Or(Search.UriPropertyEqualTo(SearchTypeReferance.DbPropertyName, SearchValue.Value.ToString())); ;
                }
                break;
              case Common.Enum.FhirSearchEnum.SearchModifierType.Missing:
                if (SearchTypeReferance.IsDbCollection)
                {
                  if (SearchValue.IsMissing)
                  {
                    //NewPredicate = NewPredicate.Or(Search.UriCollectionIsNull(SearchTypeReferance.DbPropertyName));
                  }
                  else
                  {
                    //NewPredicate = NewPredicate.Or(Search.UriCollectionIsNotNull(SearchTypeReferance.DbPropertyName));
                  }
                }
                else
                {
                  if (SearchValue.IsMissing)
                  {
                    //NewPredicate = NewPredicate.Or(Search.UriPropertyIsNull(SearchTypeReferance.DbPropertyName));
                  }
                  else
                  {
                    //NewPredicate = NewPredicate.Or(Search.UriPropertyIsNotNull(SearchTypeReferance.DbPropertyName));
                  }
                }
                break;
              case Common.Enum.FhirSearchEnum.SearchModifierType.Exact:
                if (SearchTypeReferance.IsDbCollection)
                {
                  //NewPredicate = NewPredicate.Or(Search.UriCollectionAnyEqualTo(SearchTypeReferance.DbPropertyName, SearchValue.Value.ToString()));
                }
                else
                {
                  //NewPredicate = NewPredicate.Or(Search.UriPropertyEqualTo(SearchTypeReferance.DbPropertyName, SearchValue.Value.ToString())); ;
                }
                break;
              case Common.Enum.FhirSearchEnum.SearchModifierType.Contains:
                if (SearchTypeReferance.IsDbCollection)
                {
                  //NewPredicate = NewPredicate.Or(Search.UriCollectionAnyContains(SearchTypeReferance.DbPropertyName, SearchValue.Value.ToString()));
                }
                else
                {
                  //NewPredicate = NewPredicate.Or(Search.UriPropertyContains(SearchTypeReferance.DbPropertyName, SearchValue.Value.ToString()));
                }
                break;
              case Common.Enum.FhirSearchEnum.SearchModifierType.Text:
                throw new FormatException($"The search modifier: {SearchTypeReferance.Modifier.ToString()} is not supported for search parameter types of string.");
              case Common.Enum.FhirSearchEnum.SearchModifierType.Type:
                {

                }
                break;
              case Common.Enum.FhirSearchEnum.SearchModifierType.Below:
                if (SearchTypeReferance.IsDbCollection)
                {
                  //NewPredicate = NewPredicate.Or(Search.UriCollectionAnyStartsWith(SearchTypeReferance.DbPropertyName, SearchValue.Value.ToString()));
                }
                else
                {
                  //NewPredicate = NewPredicate.Or(Search.UriPropertyStartsWith(SearchTypeReferance.DbPropertyName, SearchValue.Value.ToString()));
                }
                break;
              case Common.Enum.FhirSearchEnum.SearchModifierType.Above:
                if (SearchTypeReferance.IsDbCollection)
                {
                  //NewPredicate = NewPredicate.Or(Search.UriCollectionAnyEndsWith(SearchTypeReferance.DbPropertyName, SearchValue.Value.ToString()));
                }
                else
                {
                  //NewPredicate = NewPredicate.Or(Search.UriPropertyEndsWith(SearchTypeReferance.DbPropertyName, SearchValue.Value.ToString()));
                }
                break;
              case Common.Enum.FhirSearchEnum.SearchModifierType.In:
                throw new FormatException($"The search modifier: {SearchTypeReferance.Modifier.ToString()} is not supported for search parameter types of string.");
              case Common.Enum.FhirSearchEnum.SearchModifierType.NotIn:
                throw new FormatException($"The search modifier: {SearchTypeReferance.Modifier.ToString()} is not supported for search parameter types of string.");
              default:
                throw new System.ComponentModel.InvalidEnumArgumentException(SearchTypeReferance.Modifier.ToString(), (int)SearchTypeReferance.Modifier, typeof(Common.Enum.FhirSearchEnum.SearchModifierType));
            }
          }
        }
      }
      return NewPredicate;
    }

    private static bool IsServiceUrlPrimary(Common.Interfaces.Dto.IDtoRootUrlStore PrimaryRootUrlStore, DtoSearchParameterReferanceValue SearchValue)
    {
      if (!string.IsNullOrWhiteSpace(SearchValue.FhirUri.ServiceRootUrlForComparison))
      {
        Common.Interfaces.UriSupport.IFhirUri PrimaryFhirUri = new Common.BusinessEntities.UriSupport.DtoFhirUri(PrimaryRootUrlStore.RootUrl);
        if (SearchValue.FhirUri.ServiceRootUrlForComparison != PrimaryFhirUri.ServiceRootUrlForComparison)
        {
          return false;
        }        
      }
      return true;
    }
  }
}

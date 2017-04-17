using System;
using LinqKit;
using Pyro.DataModel.DatabaseModel.Base;
using Pyro.DataModel.Search;
using Pyro.Common.BusinessEntities.Search;

namespace Pyro.DataModel.Repository
{
  public static class ReferancePredicateBuilder
  {
    public static ExpressionStarter<T> Build<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterBase SearchItem, Common.Interfaces.Dto.IDtoRootUrlStore PrimaryRootUrlStore) where T : ResourceIndexBase
    {
      if (SearchItem is DtoSearchParameterReferance)
      {
        var SearchTypeReference = SearchItem as DtoSearchParameterReferance;
        if (SearchTypeReference.ChainedSearchParameter != null)
        {          
          throw new NotImplementedException("Chained parameters have not been implemented for use on this server.");
        }
        else
        {
          foreach (var SearchValue in SearchTypeReference.ValueList)
          {
            switch (SearchTypeReference.Modifier)
            {
              case Common.Enum.FhirSearchEnum.SearchModifierType.None:
                if (SearchTypeReference.IsDbCollection)
                {
                  if (IsServiceUrlPrimary(PrimaryRootUrlStore, SearchValue))
                  {
                    NewPredicate = NewPredicate.Or(Search.ReferanceCollectionAnyEqualTo_ByKey(SearchTypeReference.DbPropertyName, PrimaryRootUrlStore.Id, SearchValue.FhirUri.ResourseType, SearchValue.FhirUri.Id, SearchValue.FhirUri.VersionId));
                  }
                  else
                  {
                    NewPredicate = NewPredicate.Or(Search.ReferanceCollectionAnyEqualTo_ByUrlString(SearchTypeReference.DbPropertyName, SearchValue.FhirUri.ServiceRootUrlForComparison, SearchValue.FhirUri.ResourseType, SearchValue.FhirUri.Id, SearchValue.FhirUri.VersionId));
                  }
                }
                else
                {
                  if (IsServiceUrlPrimary(PrimaryRootUrlStore, SearchValue))
                  {
                    NewPredicate = NewPredicate.Or(Search.ReferancePropertyEqualTo_ByKey(SearchTypeReference.DbPropertyName, PrimaryRootUrlStore.Id, SearchValue.FhirUri.ResourseType, SearchValue.FhirUri.Id, SearchValue.FhirUri.VersionId));
                  }
                  else
                  {
                    NewPredicate = NewPredicate.Or(Search.ReferancePropertyEqualTo_ByUrlString(SearchTypeReference.DbPropertyName, SearchValue.FhirUri.ServiceRootUrlForComparison, SearchValue.FhirUri.ResourseType, SearchValue.FhirUri.Id, SearchValue.FhirUri.VersionId));
                  }
                }
                break;
              case Common.Enum.FhirSearchEnum.SearchModifierType.Missing:
                if (SearchTypeReference.IsDbCollection)
                {
                  if (SearchValue.IsMissing)
                  {
                    NewPredicate = NewPredicate.Or(Search.ReferanceCollectionIsNull(SearchTypeReference.DbPropertyName));
                  }
                  else
                  {
                    NewPredicate = NewPredicate.Or(Search.ReferanceCollectionIsNotNull(SearchTypeReference.DbPropertyName));
                  }
                }
                else
                {
                  if (SearchValue.IsMissing)
                  {
                    NewPredicate = NewPredicate.Or(Search.ReferancePropertyIsNull(SearchTypeReference.DbPropertyName));
                  }
                  else
                  {
                    NewPredicate = NewPredicate.Or(Search.ReferancePropertyIsNotNull(SearchTypeReference.DbPropertyName));
                  }
                }
                break;
              case Common.Enum.FhirSearchEnum.SearchModifierType.Exact:
                throw new FormatException($"The search modifier: {SearchTypeReference.Modifier.ToString()} is not supported for search parameter types of Reference.");
              case Common.Enum.FhirSearchEnum.SearchModifierType.Contains:
                throw new FormatException($"The search modifier: {SearchTypeReference.Modifier.ToString()} is not supported for search parameter types of Reference.");
              case Common.Enum.FhirSearchEnum.SearchModifierType.Text:
                throw new FormatException($"The search modifier: {SearchTypeReference.Modifier.ToString()} is not supported for search parameter types of Reference.");
              case Common.Enum.FhirSearchEnum.SearchModifierType.Type:
                {
                  if (SearchTypeReference.IsDbCollection)
                  {
                    if (IsServiceUrlPrimary(PrimaryRootUrlStore, SearchValue))
                    {
                      NewPredicate = NewPredicate.Or(Search.ReferanceCollectionAnyEqualTo_ByKey(SearchTypeReference.DbPropertyName, PrimaryRootUrlStore.Id, SearchValue.FhirUri.ResourseType, SearchValue.FhirUri.Id, SearchValue.FhirUri.VersionId));
                    }
                    else
                    {
                      NewPredicate = NewPredicate.Or(Search.ReferanceCollectionAnyEqualTo_ByUrlString(SearchTypeReference.DbPropertyName, SearchValue.FhirUri.ServiceRootUrlForComparison, SearchValue.FhirUri.ResourseType, SearchValue.FhirUri.Id, SearchValue.FhirUri.VersionId));
                    }
                  }
                  else
                  {
                    if (IsServiceUrlPrimary(PrimaryRootUrlStore, SearchValue))
                    {
                      NewPredicate = NewPredicate.Or(Search.ReferancePropertyEqualTo_ByKey(SearchTypeReference.DbPropertyName, PrimaryRootUrlStore.Id, SearchValue.FhirUri.ResourseType, SearchValue.FhirUri.Id, SearchValue.FhirUri.VersionId));
                    }
                    else
                    {
                      NewPredicate = NewPredicate.Or(Search.ReferancePropertyEqualTo_ByUrlString(SearchTypeReference.DbPropertyName, SearchValue.FhirUri.ServiceRootUrlForComparison, SearchValue.FhirUri.ResourseType, SearchValue.FhirUri.Id, SearchValue.FhirUri.VersionId));
                    }
                  }
                }
                break;
              case Common.Enum.FhirSearchEnum.SearchModifierType.Below:
                throw new FormatException($"The search modifier: {SearchTypeReference.Modifier.ToString()} is not supported for search parameter types of Reference.");
              case Common.Enum.FhirSearchEnum.SearchModifierType.Above:
                throw new FormatException($"The search modifier: {SearchTypeReference.Modifier.ToString()} is not supported for search parameter types of Reference.");
              case Common.Enum.FhirSearchEnum.SearchModifierType.In:
                throw new FormatException($"The search modifier: {SearchTypeReference.Modifier.ToString()} is not supported for search parameter types of Reference.");
              case Common.Enum.FhirSearchEnum.SearchModifierType.NotIn:
                throw new FormatException($"The search modifier: {SearchTypeReference.Modifier.ToString()} is not supported for search parameter types of Reference.");
              default:
                throw new System.ComponentModel.InvalidEnumArgumentException(SearchTypeReference.Modifier.ToString(), (int)SearchTypeReference.Modifier, typeof(Common.Enum.FhirSearchEnum.SearchModifierType));
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
        Common.Interfaces.UriSupport.IFhirUri PrimaryFhirUri = Common.CommonFactory.GetFhirUri(PrimaryRootUrlStore.Url);        
        if (SearchValue.FhirUri.ServiceRootUrlForComparison != PrimaryFhirUri.ServiceRootUrlForComparison)
        {
          return false;
        }
      }
      return true;
    }
  }
}

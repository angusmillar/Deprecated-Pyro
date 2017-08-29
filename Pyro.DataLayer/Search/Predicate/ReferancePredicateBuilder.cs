using System;
using LinqKit;
using Pyro.DataLayer.DbModel.EntityBase;
using Pyro.Common.Search;
using Hl7.Fhir.Model;
using Pyro.Common.Tools;

namespace Pyro.DataLayer.Search.Predicate
{
  public static class ReferancePredicateBuilder<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
  {
    public static ExpressionStarter<ResourceCurrentBaseType> Build(ResourceSearch<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType> Search, ExpressionStarter<ResourceCurrentBaseType> NewPredicate, SearchParameterBase SearchItem, Common.Interfaces.Dto.IDtoRootUrlStore PrimaryRootUrlStore)
    {
      if (SearchItem is SearchParameterReferance)
      {
        var SearchTypeReference = SearchItem as SearchParameterReferance;
        if (SearchTypeReference.ChainedSearchParameter != null)
        {
          throw new NotImplementedException("Chained parameters have not been implemented for use on this server.");
        }
        else
        {
          foreach (var SearchValue in SearchTypeReference.ValueList)
          {
            if (!SearchTypeReference.Modifier.HasValue)
            {
              if (IsServiceUrlPrimary(PrimaryRootUrlStore, SearchValue))
              {
                NewPredicate = NewPredicate.Or(Search.ReferanceCollectionAnyEqualTo_ByKey(SearchTypeReference.Id, PrimaryRootUrlStore.Id, SearchValue.FhirRequestUri.ResourseName, SearchValue.FhirRequestUri.ResourceId, SearchValue.FhirRequestUri.VersionId));
              }
              else
              {
                NewPredicate = NewPredicate.Or(Search.ReferanceCollectionAnyEqualTo_ByUrlString(SearchTypeReference.Id, SearchValue.FhirRequestUri.UriPrimaryServiceRoot.OriginalString.StripHttp().ToLower(), SearchValue.FhirRequestUri.ResourseName, SearchValue.FhirRequestUri.ResourceId, SearchValue.FhirRequestUri.VersionId));
              }
            }
            else
            {
              switch (SearchTypeReference.Modifier)
              {
                case SearchParameter.SearchModifierCode.Missing:
                  if (SearchValue.IsMissing)
                  {
                    NewPredicate = NewPredicate.Or(Search.ReferanceCollectionIsNull(SearchTypeReference.Id));
                  }
                  else
                  {
                    NewPredicate = NewPredicate.Or(Search.ReferanceCollectionIsNotNull(SearchTypeReference.Id));
                  }
                  break;
                case SearchParameter.SearchModifierCode.Exact:
                  throw new FormatException($"The search modifier: {SearchTypeReference.Modifier.ToString()} is not supported for search parameter types of Reference.");
                case SearchParameter.SearchModifierCode.Contains:
                  throw new FormatException($"The search modifier: {SearchTypeReference.Modifier.ToString()} is not supported for search parameter types of Reference.");
                case SearchParameter.SearchModifierCode.Text:
                  throw new FormatException($"The search modifier: {SearchTypeReference.Modifier.ToString()} is not supported for search parameter types of Reference.");
                case SearchParameter.SearchModifierCode.Type:
                  if (IsServiceUrlPrimary(PrimaryRootUrlStore, SearchValue))
                  {
                    NewPredicate = NewPredicate.Or(Search.ReferanceCollectionAnyEqualTo_ByKey(SearchTypeReference.Id, PrimaryRootUrlStore.Id, SearchValue.FhirRequestUri.ResourseName, SearchValue.FhirRequestUri.ResourceId, SearchValue.FhirRequestUri.VersionId));
                  }
                  else
                  {
                    NewPredicate = NewPredicate.Or(Search.ReferanceCollectionAnyEqualTo_ByUrlString(SearchTypeReference.Id, SearchValue.FhirRequestUri.UriPrimaryServiceRoot.OriginalString.StripHttp().ToLower(), SearchValue.FhirRequestUri.ResourseName, SearchValue.FhirRequestUri.ResourceId, SearchValue.FhirRequestUri.VersionId));
                  }
                  break;
                case SearchParameter.SearchModifierCode.Below:
                  throw new FormatException($"The search modifier: {SearchTypeReference.Modifier.ToString()} is not supported for search parameter types of Reference.");
                case SearchParameter.SearchModifierCode.Above:
                  throw new FormatException($"The search modifier: {SearchTypeReference.Modifier.ToString()} is not supported for search parameter types of Reference.");
                case SearchParameter.SearchModifierCode.In:
                  throw new FormatException($"The search modifier: {SearchTypeReference.Modifier.ToString()} is not supported for search parameter types of Reference.");
                case SearchParameter.SearchModifierCode.NotIn:
                  throw new FormatException($"The search modifier: {SearchTypeReference.Modifier.ToString()} is not supported for search parameter types of Reference.");
                default:
                  throw new System.ComponentModel.InvalidEnumArgumentException(SearchTypeReference.Modifier.ToString(), (int)SearchTypeReference.Modifier, typeof(SearchParameter.SearchModifierCode));
              }
            }
          }
        }
      }
      return NewPredicate;
    }

    private static bool IsServiceUrlPrimary(Common.Interfaces.Dto.IDtoRootUrlStore PrimaryRootUrlStore, SearchParameterReferanceValue SearchValue)
    {
      if (!string.IsNullOrWhiteSpace(SearchValue.FhirRequestUri.UriPrimaryServiceRoot.OriginalString))
      {
        if (!SearchValue.FhirRequestUri.UriPrimaryServiceRoot.OriginalString.IsEqualUri(PrimaryRootUrlStore.Url))
        {
          return false;
        }
      }
      return true;
    }
  }
}

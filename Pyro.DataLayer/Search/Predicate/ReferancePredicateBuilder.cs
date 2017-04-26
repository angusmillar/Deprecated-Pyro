using System;
using LinqKit;
using Pyro.DataLayer.DbModel.EntityBase;
using Pyro.Common.BusinessEntities.Search;
using Hl7.Fhir.Model;

namespace Pyro.DataLayer.Search.Predicate
{
  public static class ReferancePredicateBuilder
  {
    public static ExpressionStarter<T> Build<T>(ResourceSearch<T> Search, ExpressionStarter<T> NewPredicate, DtoSearchParameterBase SearchItem, Common.Interfaces.Dto.IDtoRootUrlStore PrimaryRootUrlStore) 
      where T : ResourceBase
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
            if (!SearchTypeReference.Modifier.HasValue)
            {              
              if (IsServiceUrlPrimary(PrimaryRootUrlStore, SearchValue))
              {
                NewPredicate = NewPredicate.Or(Search.ReferanceCollectionAnyEqualTo_ByKey(SearchTypeReference.Id, PrimaryRootUrlStore.Id, SearchValue.FhirUri.ResourseType, SearchValue.FhirUri.Id, SearchValue.FhirUri.VersionId));
              }
              else
              {
                NewPredicate = NewPredicate.Or(Search.ReferanceCollectionAnyEqualTo_ByUrlString(SearchTypeReference.Id, SearchValue.FhirUri.ServiceRootUrlForComparison, SearchValue.FhirUri.ResourseType, SearchValue.FhirUri.Id, SearchValue.FhirUri.VersionId));
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
                    //NewPredicate = NewPredicate.Or(Search.ReferanceCollectionAnyEqualTo_ByKey(SearchTypeReference.DbPropertyName, PrimaryRootUrlStore.Id, SearchValue.FhirUri.ResourseType, SearchValue.FhirUri.Id, SearchValue.FhirUri.VersionId));
                  }
                  else
                  {
                    //NewPredicate = NewPredicate.Or(Search.ReferanceCollectionAnyEqualTo_ByUrlString(SearchTypeReference.DbPropertyName, SearchValue.FhirUri.ServiceRootUrlForComparison, SearchValue.FhirUri.ResourseType, SearchValue.FhirUri.Id, SearchValue.FhirUri.VersionId));
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

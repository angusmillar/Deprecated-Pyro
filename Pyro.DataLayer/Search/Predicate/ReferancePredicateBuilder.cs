using System;
using System.Linq;
using LinqKit;
using Pyro.DataLayer.DbModel.EntityBase;
using Pyro.Common.Search;
using Hl7.Fhir.Model;
using Pyro.Common.Tools;

namespace Pyro.DataLayer.Search.Predicate
{
  public static class ReferancePredicateBuilder<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
      where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>

  {
    public static ExpressionStarter<ResCurrentType> Build(ResourceSearch<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType> Search, ExpressionStarter<ResCurrentType> NewPredicate, SearchParameterBase SearchItem, Common.Interfaces.Dto.IDtoRootUrlStore PrimaryRootUrlStore)
    {
      if (SearchItem is SearchParameterReferance SearchTypeReference)
      {
        //Improved Query when searching for FhirIds for the same Resource type and search parameter yet different FhirIds.
        //It creates a SQL 'IN' cause instead of many 'OR' statements and should be more efficient.        
        //Heavily used in chain searching where we traverse many References. 
        //The 'Type' modifier is already resolved when the search parameter is parsed, so the SearchValue.FhirRequestUri.ResourseName is the correct Resource name at this stage
        if (SearchTypeReference.ValueList.Count > 1 && SearchTypeReference.ValueList.TrueForAll(x =>
                                                                                                x.FhirRequestUri.IsRelativeToServer &&
                                                                                                x.FhirRequestUri.ResourseName == SearchTypeReference.ValueList[0].FhirRequestUri.ResourseName &&
                                                                                                string.IsNullOrWhiteSpace(x.FhirRequestUri.VersionId)))
        {
          string[] ReferenceFhirIdArray = SearchTypeReference.ValueList.Select(x => x.FhirRequestUri.ResourceId).ToArray();
          NewPredicate = NewPredicate.Or(Search.ReferanceCollectionAnyEqualTo_ByKey_Many_FhirIds(SearchTypeReference.Id, PrimaryRootUrlStore.Id, SearchTypeReference.ValueList[0].FhirRequestUri.ResourseName, ReferenceFhirIdArray, SearchTypeReference.ValueList[0].FhirRequestUri.VersionId));
          return NewPredicate;
        }

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
                //The 'Type' modifier is already resolved when the search parameter is parsed, so the SearchValue.FhirRequestUri.ResourseName is the correct Resource name at this stage
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

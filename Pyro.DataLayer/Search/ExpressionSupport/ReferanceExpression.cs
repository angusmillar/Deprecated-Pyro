using System;
using System.Linq.Expressions;


namespace Pyro.DataLayer.Search.ExpressionSupport
{
  public static class ReferanceExpression
  {
    public static Expression EqualTo_ByURLStoreKey_Expression(
      MemberExpression propertyReferenceUrlStoreKey,
      MemberExpression propertyReferenceResource,
      MemberExpression propertyReferenceFhirID,
      MemberExpression SearchValueReferenceHistory,
      ConstantExpression SearchValue_UrlStoreKey,
      ConstantExpression SearchValue_Resource,
      ConstantExpression SearchValue_FhirId,
      ConstantExpression SearchValue_History)
    {
      //(x.organization_ServiceRootURL_StoreID == 1)
      var BinaryExpression_ResourceUrlStoreKey_IsEqualTo_SearchUrlStoreKey = Expression.Equal(propertyReferenceUrlStoreKey, SearchValue_UrlStoreKey);

      //(x.organization_Type == "Orginization")
      var BinaryExpression_ResourceResource_IsEqualTo_SearchResource = Expression.Equal(propertyReferenceResource, SearchValue_Resource);

      //(x.organization_FhirId == "f495c8c9-8875-4b1f-86c8-984d30d26169")
      var BinaryExpression_ResourceFhirID_IsEqualTo_SearchFhirID = Expression.Equal(propertyReferenceFhirID, SearchValue_FhirId);

      //(x.organization_VersionId == "2")
      var BinaryExpression_ResourceHistory_IsEqualTo_SearchHistory = Expression.Equal(SearchValueReferenceHistory, SearchValue_History);


      //(x.organization_ServiceRootURL_StoreID == 1) And (x.organization_Type == "Orginization")
      var Expression_A = Expression.And(BinaryExpression_ResourceUrlStoreKey_IsEqualTo_SearchUrlStoreKey, BinaryExpression_ResourceResource_IsEqualTo_SearchResource);

      //(x.organization_FhirId == "f495c8c9-8875-4b1f-86c8-984d30d26169") And (x.organization_VersionId == "2")
      var Expression_B = Expression.AndAlso(BinaryExpression_ResourceFhirID_IsEqualTo_SearchFhirID, BinaryExpression_ResourceHistory_IsEqualTo_SearchHistory);

      var Finaly_Expression = Expression.AndAlso(Expression_A, Expression_B);


      return Finaly_Expression;
    }

    public static Expression EqualTo_ByURLString_Expression(
      MemberExpression propertyReferenceUrl,
      MemberExpression propertyReferenceServiceRootURL_StoreRootUrl,
      MemberExpression propertyReferenceResource,
      MemberExpression propertyReferenceFhirID,
      MemberExpression SearchValueReferenceHistory,
      ConstantExpression SearchValue_UrlString,
      ConstantExpression SearchValue_Resource,
      ConstantExpression SearchValue_FhirId,
      ConstantExpression SearchValue_History)
      {
        //(x.organization_ServiceRootURL_StoreID == 1)
        var BinaryExpression_ResourceUrlString_IsEqualTo_SearchUrlString = Expression.Equal(propertyReferenceServiceRootURL_StoreRootUrl, SearchValue_UrlString);

        //(x.organization_Type == "Orginization")
        var BinaryExpression_ResourceResource_IsEqualTo_SearchResource = Expression.Equal(propertyReferenceResource, SearchValue_Resource);

        //(x.organization_FhirId == "f495c8c9-8875-4b1f-86c8-984d30d26169")
        var BinaryExpression_ResourceFhirID_IsEqualTo_SearchFhirID = Expression.Equal(propertyReferenceFhirID, SearchValue_FhirId);

        //(x.organization_VersionId == "2")
        var BinaryExpression_ResourceHistory_IsEqualTo_SearchHistory = Expression.Equal(SearchValueReferenceHistory, SearchValue_History);


        //(x.organization_ServiceRootURL_StoreID == 1) And (x.organization_Type == "Orginization")
        var Expression_A = Expression.And(BinaryExpression_ResourceUrlString_IsEqualTo_SearchUrlString, BinaryExpression_ResourceResource_IsEqualTo_SearchResource);

        //(x.organization_FhirId == "f495c8c9-8875-4b1f-86c8-984d30d26169") And (x.organization_VersionId == "2")
        var Expression_B = Expression.AndAlso(BinaryExpression_ResourceFhirID_IsEqualTo_SearchFhirID, BinaryExpression_ResourceHistory_IsEqualTo_SearchHistory);

        var Finaly_Expression = Expression.AndAlso(Expression_A, Expression_B);


        return Finaly_Expression;
      }

  }
}


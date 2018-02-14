using System;
using Pyro.DataLayer.DbModel.EntityBase;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Pyro.Common.Search;
using Pyro.Common.Tools;
using System.Collections.Generic;
using System.Linq;

namespace Pyro.DataLayer.IndexSetter
{
  public class UriSetter<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType> :
    IUriSetter<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    
  {
    public UriSetter() { }
    public IList<ResIndexUriType> Set(IElementNavigator oElement, ServiceSearchParameterLight SearchParameter)
    {
      var ResourceIndexList = new List<ResIndexUriType>();
      var ServiceSearchParameterId = SearchParameter.Id;

      if (oElement is Hl7.Fhir.ElementModel.PocoNavigator Poco && Poco.FhirValue != null)
      {
        if (Poco.FhirValue is FhirUri FhirUri)
        {
          SetUri(FhirUri, ResourceIndexList);
        }
        else if (Poco.FhirValue is Oid Oid)
        {
          SetOid(Oid, ResourceIndexList);
        }
        else
        {
          throw new FormatException($"Unknown FhirType: '{oElement.Type}' for SearchParameterType: '{SearchParameter.Type}'");
        }
        ResourceIndexList.ForEach(x => x.ServiceSearchParameterId = ServiceSearchParameterId);
        return ResourceIndexList;
      }
      else
      {
        throw new FormatException($"Unknown Navigator FhirType: '{oElement.Type}' for SearchParameterType: '{SearchParameter.Type}'");
      }
    }

    private void SetOid(Oid Oid, List<ResIndexUriType> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(Oid.Value))
      {
        var ResourceIndex = new ResIndexUriType();
        ResourceIndex.Uri = Oid.Value;
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetUri(FhirUri FhirUri, List<ResIndexUriType> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(FhirUri.Value))
      {
        var ResourceIndex = new ResIndexUriType();
        ResourceIndex.Uri = StringSupport.ToLowerFast(FhirUri.Value.StripHttp());
        ResourceIndexList.Add(ResourceIndex);
      }
    }

  }
}

using System;
using Hl7.Fhir.Model;
using Pyro.DataLayer.DbModel.Entity;

namespace Pyro.DataLayer.DbModel.EntityBase
{
  public interface IResourceIndexBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType> :
    IResourceIndexNewBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
    where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
    where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
    where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
    where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
    where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
    where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
    where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
    where ResIndexBaseType : ResourceIndexBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
  {
    ResCurrentType Resource { get; set; }

    string Code { get; set; }
    string CodeHigh { get; set; }

    Quantity.QuantityComparator? Comparator { get; set; }
    Quantity.QuantityComparator? ComparatorHigh { get; set; }

    DateTimeOffset? DateTimeOffsetHigh { get; set; }
    DateTimeOffset? DateTimeOffsetLow { get; set; }

    decimal? Quantity { get; set; }
    decimal? QuantityHigh { get; set; }

    string ReferenceFhirId { get; set; }
    string ReferenceResourceType { get; set; }
    int? ReferenceServiceBaseUrlId { get; set; }
    ServiceBaseUrl ReferenceUrl { get; set; }
    string ReferenceVersionId { get; set; }

    string System { get; set; }
    string SystemHigh { get; set; }
    string Unit { get; set; }
    string UnitHigh { get; set; }

    string Uri { get; set; }
  }
}
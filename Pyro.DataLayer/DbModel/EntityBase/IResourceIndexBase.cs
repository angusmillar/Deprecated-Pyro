using System;
using Hl7.Fhir.Model;
using Pyro.DataLayer.DbModel.Entity;

namespace Pyro.DataLayer.DbModel.EntityBase
{
  public interface IResourceIndexBase<ResourceCurrentType, ResourceIndexType>
    where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>
    where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>
  {
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
    ResourceCurrentType Resource { get; set; }
    int ResourceId { get; set; }
    ServiceSearchParameter ServiceSearchParameter { get; set; }
    int ServiceSearchParameterId { get; set; }
    string String { get; set; }
    string System { get; set; }
    string SystemHigh { get; set; }
    string Unit { get; set; }
    string UnitHigh { get; set; }
    string Uri { get; set; }
  }
}
using Hl7.Fhir.Model;
using Pyro.Common.Search;

namespace Pyro.Common.SearchIndexer.Index
{
  public interface IQuantityIndex
  {
    string Code { get; set; }
    string CodeHigh { get; set; }
    Quantity.QuantityComparator? Comparator { get; set; }
    Quantity.QuantityComparator? ComparatorHigh { get; set; }
    decimal? Quantity { get; set; }
    decimal? QuantityHigh { get; set; }
    IServiceSearchParameterLight ServiceSearchParameterLight { get; set; }
    string System { get; set; }
    string SystemHigh { get; set; }
    string Unit { get; set; }
    string UnitHigh { get; set; }
  }
}
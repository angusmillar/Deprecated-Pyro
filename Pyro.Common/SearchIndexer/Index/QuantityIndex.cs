using Hl7.Fhir.Model;
using Pyro.Common.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.SearchIndexer.Index
{
  public class QuantityIndex : IQuantityIndex
  {
    public QuantityIndex(IServiceSearchParameterLight ServiceSearchParameterLight)
    {
      this.ServiceSearchParameterLight = ServiceSearchParameterLight;
    }

    public IServiceSearchParameterLight ServiceSearchParameterLight { get; set; }

    public Quantity.QuantityComparator? Comparator { get; set; }
    public decimal? Quantity { get; set; }
    public string Code { get; set; }
    public string System { get; set; }
    public string Unit { get; set; }

    public Quantity.QuantityComparator? ComparatorHigh { get; set; }
    public decimal? QuantityHigh { get; set; }
    public string CodeHigh { get; set; }
    public string SystemHigh { get; set; }
    public string UnitHigh { get; set; }
  }
}

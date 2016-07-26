using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace Blaze.DataModel.DatabaseModel.Base
{
  public class QuantityRangeIndex : ModelBase
  {
    public Quantity.QuantityComparator? ComparatorLow { get; set; }
    public decimal? QuantityLow { get; set; }
    public string SystemLow { get; set; }
    public string CodeLow { get; set; }

    public Quantity.QuantityComparator? ComparatorHigh { get; set; }
    public decimal? QuantityHigh { get; set; }
    public string SystemHigh { get; set; }
    public string CodeHigh { get; set; }

  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.DataModel.DatabaseModel.Base
{
  public abstract class QuantityIndex : ModelBase
  {
    public decimal Quantity { get; set; }
    public string System { get; set; }
    public string Code { get; set; }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.DataModel.DatabaseModel.Base
{
  public class DateTimePeriodIndex : ModelBase
  {
    public DateTimeOffset? DateTimeOffsetLow { get; set; }
    public DateTimeOffset? DateTimeOffsetHigh { get; set; }
  }
}

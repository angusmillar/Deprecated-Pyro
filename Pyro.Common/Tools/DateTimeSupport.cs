using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.Tools
{
  public static class DateTimeSupport
  {
    public static DateTime? DateTimeOffSetToUTCDateTime(DateTimeOffset? item)
    {
      if (item.HasValue)
        return item.Value.UtcDateTime;
      else
        return null;
    }

    public static DateTime DateTimeOffSetToUTCDateTime(DateTimeOffset item)
    {      
      return item.UtcDateTime;      
    }

    public static DateTime UTCDateTimeNow()
    {
      return DateTimeOffset.Now.UtcDateTime;
    }
  }
}

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

    public static string UTCDateTimeNowPostgreFormat()
    {
      //2018-10-18 08:12:47.27152
      return UTCDateTimeNow().ToString("yyyy-MM-dd HH:mm:ss.FFFFFF");
    }

    public static string UTCDateTimeNowMSSQLFormat()
    {
      //2018-10-18 08:12:47.27152
      return UTCDateTimeNow().ToString("yyyy-MM-dd HH:mm:ss.FFF");
    }
  }
}

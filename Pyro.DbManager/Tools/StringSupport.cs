using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.DbManager.Tools
{
  public static class StringSupport
  {
    public static string GetPostgreSQLDateTimeOffSet(DateTimeOffset date)
    {
      return date.ToString("yyyy-MM-dd hh:mm:ss zzz");
    }

    public static  string GetBoolToByteString(bool item)
    {
      if (item)
        return "1";
      else
        return "0";
    }

    public static string EscapePostgreSQL(string item)
    {
      if (item == null)
        return item;
      item = item.Replace("'", "''");
      //This replaces '\' with '\\', and yes it must be "\\" as the target.
      item = item.Replace(@"\\", @"\\");      
      return item;
    }
  }
}

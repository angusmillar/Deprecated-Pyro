using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.Tools
{
  public static class IntegerExtensions
  {
    public static string Ordinal(this int num)
    {
      if (num ==  0) return num.ToString();
      if (num.ToString().EndsWith("11")) return num.ToString() + "th";
      if (num.ToString().EndsWith("12")) return num.ToString() + "th";
      if (num.ToString().EndsWith("13")) return num.ToString() + "th";
      if (num.ToString().EndsWith("1")) return num.ToString() + "st";
      if (num.ToString().EndsWith("2")) return num.ToString() + "nd";
      if (num.ToString().EndsWith("3")) return num.ToString() + "rd";
      return num.ToString() + "th";
    }
  }
}

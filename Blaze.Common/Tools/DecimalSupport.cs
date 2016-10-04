using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Common.Tools
{
  public class DecimalSupport
  {
    public static decimal CalculateHighNumber(decimal Value, int Scale)
    {
      return Decimal.Add(Value, CalculateNewScale(Scale));
    }

    public static decimal CalculateLowNumber(decimal Value, int Scale)
    {
      return Decimal.Subtract(Value, CalculateNewScale(Scale));
    }

    private static decimal CalculateNewScale(int Scale)
    {
      double Margin = 5;
      return Convert.ToDecimal(Margin / (Math.Pow(10, Scale + 1)));
    }


  }
}

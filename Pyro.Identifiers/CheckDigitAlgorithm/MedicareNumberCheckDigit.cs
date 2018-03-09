using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Pyro.Identifiers.CheckDigitAlgorithm
{
  internal static class MedicareNumberCheckDigit
  {
    public static bool GetCheckDigit(string Item, out string CheckDigit)
    {
      if (!string.IsNullOrEmpty(Item))
      {
        if (Item.Length == 8)
        {
          if (Regex.IsMatch(Item, @"^\d+$"))
          {
            int One = Convert.ToInt32(Item.Substring(0, 1));
            //The first Char must be in the range 2-6
            if (One > 1 && One < 7)
            {
              int Two = Convert.ToInt32(Item.Substring(1, 1));
              int Three = Convert.ToInt32(Item.Substring(2, 1));
              int Four = Convert.ToInt32(Item.Substring(3, 1));
              int Five = Convert.ToInt32(Item.Substring(4, 1));
              int Six = Convert.ToInt32(Item.Substring(5, 1));
              int Seven = Convert.ToInt32(Item.Substring(6, 1));
              int Eight = Convert.ToInt32(Item.Substring(7, 1));

              int CheckDigitInt = ((One) + (Two * 3) + (Three * 7) + (Four * 9) + (Five) + (Six * 3) + (Seven * 7) + (Eight * 9));
              CheckDigitInt = CheckDigitInt % 10;
              CheckDigit = CheckDigitInt.ToString();
              return true;
            }
          }
        }
      }
      CheckDigit = string.Empty;
      return false;
    }
  }
}

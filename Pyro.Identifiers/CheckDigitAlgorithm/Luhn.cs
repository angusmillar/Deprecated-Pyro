using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pyro.Identifiers.CheckDigitAlgorithm
{
  public class Luhn
  {
    public static string GetCheckDigit(string Ihi)
    {
      if (!Support.StringSupport.IsDigitsOnly(Ihi))
      {
        throw new FormatException("Luhn Algorithm can only be perfomed on numericalk digits.");
      }

      int counter = 1;
      int value = 0;

      while(counter <= Ihi.Length)
      {
        string substring = Ihi.Substring(counter - 1, 1);
        int digit = int.Parse(substring);

        if (counter % 2 == 0)
        {
          //even
          value = value + digit;
        }
        else
        {
          //odd
          value = value + ((digit * 2) / 10 + (digit * 2) % 10);
        }
        counter++;
      }

      value = (10 - (value % 10)) % 10;

      if (value < 0)
      {
        value = value * -1;
      }

      return value.ToString();
    }    
  }
}

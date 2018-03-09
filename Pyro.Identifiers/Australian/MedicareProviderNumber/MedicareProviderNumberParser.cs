using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Pyro.Identifiers.Australian.MedicareProviderNumber
{
  public class MedicareProviderNumberParser : IMedicareProviderNumberParser
  {
    //The Allowed Practice Location Values (PLV) and there positions
    internal static char[] PracticeLocationValueChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                                             'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K',
                                             'L', 'M', 'N', 'P', 'Q', 'R', 'T', 'U', 'V', 'W',
                                             'X', 'Y'};

    //The Allowed Check Characters and there positions
    internal static char[] RemainderCheckCharacterChars = { 'Y', 'X', 'W', 'T', 'L', 'K', 'J', 'H', 'F', 'B', 'A' };

    public bool TryParse(string MedicareProviderNumberString, out IMedicareProviderNumber MedicareProviderNumber)
    {
      MedicareProviderNumber = null;
      MedicareProviderNumber Mpn = null;

      if (MedicareProviderNumberString.Length == 8)
      {
        if (Regex.IsMatch(MedicareProviderNumberString.Substring(0, 6), @"^\d+$"))
        {
          int PLVInteger = Array.IndexOf(PracticeLocationValueChars, MedicareProviderNumberString.Substring(6, 1).ToCharArray()[0]);
          if (PLVInteger > -1)
          {
            int One = Convert.ToInt32(MedicareProviderNumberString.Substring(0, 1));
            int Two = Convert.ToInt32(MedicareProviderNumberString.Substring(1, 1));
            int Three = Convert.ToInt32(MedicareProviderNumberString.Substring(2, 1));
            int Four = Convert.ToInt32(MedicareProviderNumberString.Substring(3, 1));
            int Five = Convert.ToInt32(MedicareProviderNumberString.Substring(4, 1));
            int Six = Convert.ToInt32(MedicareProviderNumberString.Substring(5, 1));
            int CheckDigit = ((One * 3) + (Two * 5) + (Three * 8) + (Four * 4) + (Five * 2) + (Six) + (PLVInteger * 6)) % 11;
            if (MedicareProviderNumberString.Substring(7, 1) == RemainderCheckCharacterChars[CheckDigit].ToString())
            {
              Mpn = new MedicareProviderNumber();
              Mpn.Value = MedicareProviderNumberString;
              Mpn.Stem = MedicareProviderNumberString.Substring(0, 6);
              Mpn.LocationCharacter = MedicareProviderNumberString.Substring(6, 1);
              Mpn.CheckCharacter = MedicareProviderNumberString.Substring(7, 1);
              MedicareProviderNumber = Mpn;
              return true;
            }            
          }
        }
      }
      return false;
    }
  }
}

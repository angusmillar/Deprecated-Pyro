using System;
using System.Text.RegularExpressions;

namespace Pyro.Identifiers.Australian.MedicareProviderNumber
{
  public class MedicareProviderNumberGenerator : IMedicareProviderNumberGenerator
  {
    public string Generate()
    {
      Random Random = new Random();
      string Stem = Random.Next(0, 999999).ToString().PadLeft(6, '0'); ;
      int PLVInteger = Random.Next(0, 31);
      char PLVChar = MedicareProviderNumberParser.PracticeLocationValueChars[PLVInteger];
      int One = Convert.ToInt32(Stem.Substring(0, 1));
      int Two = Convert.ToInt32(Stem.Substring(1, 1));
      int Three = Convert.ToInt32(Stem.Substring(2, 1));
      int Four = Convert.ToInt32(Stem.Substring(3, 1));
      int Five = Convert.ToInt32(Stem.Substring(4, 1));
      int Six = Convert.ToInt32(Stem.Substring(5, 1));
      int CheckDigit = ((One * 3) + (Two * 5) + (Three * 8) + (Four * 4) + (Five * 2) + (Six) + (PLVInteger * 6)) % 11;
      return Stem + PLVChar + MedicareProviderNumberParser.RemainderCheckCharacterChars[CheckDigit].ToString();


    }
  }
}

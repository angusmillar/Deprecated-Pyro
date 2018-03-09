using System;
using System.Text.RegularExpressions;

namespace Pyro.Identifiers.Australian.MedicareNumber
{
  public class MedicareMedicareNumberGenerator : IMedicareMedicareNumberGenerator
  {
    public string Generate(bool WithIRN = false)
    {
      Random Random = new Random();
      int FirstChar = Random.Next(2, 6);
      int Number = Random.Next(0, 9999999);
      string IdNumber = (FirstChar.ToString() + Number.ToString().PadLeft(7, '0'));
      if (CheckDigitAlgorithm.MedicareNumberCheckDigit.GetCheckDigit(FirstChar.ToString() + Number.ToString().PadLeft(7, '0'), out string CheckDigit))
      {
        int IssueNum = Random.Next(0, 9);
        if (WithIRN)
        {
          return $"{IdNumber}{CheckDigit}{IssueNum}{Random.Next(1, 9)}";
        }
        else
        {
          return $"{IdNumber}{CheckDigit}{IssueNum}";
        }
      }
      else
      {
        throw new ArgumentException($"Internal error in Medicare Number Checkdigit generator, coudl not create check digit from internal generated value '{FirstChar.ToString() + Number.ToString().PadLeft(7, '0')}'");
      }

    }
  }
}

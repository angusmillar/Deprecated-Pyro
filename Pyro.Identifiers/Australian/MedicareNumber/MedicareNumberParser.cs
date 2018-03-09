using System;
using System.Text.RegularExpressions;

namespace Pyro.Identifiers.Australian.MedicareNumber
{
  public class MedicareNumberParser : IMedicareNumberParser
  {
    public bool TryParse(string MedicareNumberString, out IMedicareNumber MedicareNumber)
    {
      MedicareNumber = null;
      MedicareNumber Med = null;
      string Number = string.Empty;
      string Irn = string.Empty;
      if (MedicareNumberString.Length == 11)
      {
        Number = MedicareNumberString.Substring(0, 10);
        Irn = MedicareNumberString.Substring(10, 1);
      }
      else if (MedicareNumberString.Length == 10)
      {
        Number = MedicareNumberString;
      }
      else
      {
        return false;
      }
      Med = new MedicareNumber();
      Med.Value = Number;
      if (!Regex.IsMatch(Med.Value, @"^\d+$"))
      {
        return false;
      }

      if (Number.Length >= 8)
        Med.Identifer = Number.Substring(0, 8);
      else
        return false;

      int TempInteger;
      if (int.TryParse(Med.Identifer.Substring(0, 1), out TempInteger))
      {
        if (TempInteger < 2)
          return false;

        if (TempInteger > 6)
          return false;
      }


      if (Number.Length >= 9)
        Med.Checksum = Number.Substring(8, 1);
      else
        return false;

      string CheckDigit;
      if (CheckDigitAlgorithm.MedicareNumberCheckDigit.GetCheckDigit(Med.Identifer, out CheckDigit))
      {
        if (Med.Checksum != CheckDigit)
          return false;
      }
      else
      {
        return false;
      }

      if (Number.Length >= 10)
        Med.IssueNumber = Number.Substring(9, 1);
      else
        return false;

      if (Med.IssueNumber.Length != 1)
        return false;
      
      Med.IRN = Irn;
      if (Med.IRN != string.Empty)
      {
        if (!Regex.IsMatch(Med.IRN, @"^\d+$"))
        {
          return false;
        }
        if (Med.IRN.Length > 1)
          return false;
      }

      MedicareNumber = Med;
      return true;

    }
  }
}

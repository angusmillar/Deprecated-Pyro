using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pyro.Identifiers.Australian.DepartmentVeteransAffairs
{
  public class DVANumberParser : IDVANumberParser
  {
    string[] ValidStateCodes = { "N", "V", "Q", "W", "S", "T" };
    public bool TryParse(string DVANumberString, out IDVANumber DVANumber)
    {
      DVANumber = null;
      DVANumber DVA = null;
      DVANumberString = Identifiers.Support.StringSupport.RemoveWhitespace(DVANumberString.Trim());
      if (DVANumberString.Length == 8 || DVANumberString.Length == 9)
      {
        if (ValidStateCodes.Contains(DVANumberString.Substring(0,1)))
        {
          string StateCode = DVANumberString.Substring(0, 1);
          string FileNumber = DVANumberString.Substring(1, 7);
          string WarCode = string.Empty;
          string Number = string.Empty;
          foreach (char x in FileNumber.ToCharArray())
          {
            if (Char.IsLetter(x))
            {
              if (Number.Length > 0)
                return false;

              WarCode = WarCode + x;
              if (WarCode.Length > 3)
                return false;
            }
            else if (Char.IsNumber(x))
            {
              if (WarCode.Length < 1)
                return false;
              Number = Number + x;
            }
            else
            {
              return false;
            }
          }

          //Char 9 must be a letter
          if (DVANumberString.Length == 9 && !Char.IsLetter(DVANumberString.Substring(8, 1).ToCharArray()[0]))
          {
            return false;
          }
          
          //All good populate object to return
          DVA = new DVANumber();
          DVA.StateCode = StateCode;
          DVA.WarCode = WarCode;
          DVA.Number = Number;
          DVA.Value = DVANumberString;
          DVA.SegmentLink = string.Empty;
          if (DVANumberString.Length == 9)
            DVA.SegmentLink = DVANumberString.Substring(8, 1);
          DVANumber = DVA;
          return true;

        }
      }
      return false;
    }
  }
}

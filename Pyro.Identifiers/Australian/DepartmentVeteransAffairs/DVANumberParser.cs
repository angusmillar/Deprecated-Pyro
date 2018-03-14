using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pyro.Identifiers.Australian.DepartmentVeteransAffairs
{
  public class DVANumberParser : IDVANumberParser
  {
    //Care here becasue in DVA Number the space matters so this is valid 'N 909030E' and so is this 'N908030C'
    //This parse strips space and still works as we can never trust people providing the space correctly, they are 
    //likley to also strip it out.
    string[] ValidStateCodes = { "N", "V", "Q", "W", "S", "T" };
    public bool TryParse(string DVANumberString, out IDVANumber DVANumber)
    {
      DVANumber = null;
      DVANumber DVA = null;
      DVANumberString = Support.StringSupport.RemoveWhitespace(DVANumberString.Trim());
      if (DVANumberString.Length == 7 || DVANumberString.Length == 8 || DVANumberString.Length == 9)
      {
        if (ValidStateCodes.Contains(DVANumberString.Substring(0,1)))
        {
          string StateCode = DVANumberString.Substring(0, 1);          
          string FileNumber = DVANumberString.Substring(1, DVANumberString.Length - 1);
          string WarCode = string.Empty;
          string Number = string.Empty;
          string SegmentLink = string.Empty;
          char[] FileNumberArray = FileNumber.ToCharArray();
          for (int i = 0; i < FileNumberArray.Length; i++)
          { 
            if (Char.IsLetter(FileNumberArray[i]))
            {
              if (i == FileNumberArray.Length - 1 && !string.IsNullOrWhiteSpace(Number))
              {
                SegmentLink = FileNumberArray[i].ToString();
                break;
              }
              if (Number.Length > 0)
                return false;

              WarCode = WarCode + FileNumberArray[i];
              if (WarCode.Length > 3)
                return false;
            }
            else if (Char.IsNumber(FileNumberArray[i]))
            {                            
              Number = Number + FileNumberArray[i];
            }
            else
            {
              return false;
            }
          }

          if (String.IsNullOrWhiteSpace(WarCode))
          {
            WarCode = " "; // if not war code then single empty space for formating
          }
          if (DVANumberString.Length == 9 && String.IsNullOrWhiteSpace(SegmentLink))
          {
            return false;
          }

          //All good populate object to return
          DVA = new DVANumber();
          DVA.StateCode = StateCode;
          DVA.WarCode = WarCode;
          DVA.Number = Number;
          DVA.Value = DVANumberString;
          DVA.SegmentLink = SegmentLink;
          DVA.ValueFormated = $"{DVA.StateCode}{DVA.WarCode}{DVA.Number}{DVA.SegmentLink}";
          DVANumber = DVA;
          return true;
        }
      }
      return false;
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using System.Text.RegularExpressions;

namespace Blaze.Common.Tools
{
  public static class FhirDateTimeSupport
  {
    public static int? ConvertDateTimeToInteger(Date Date)
    {
      //2001-05-06
      int DateInt = 0;
      if (Int32.TryParse(Date.Value.Replace("-", "").Replace(" ","").PadRight(8, '0'), out DateInt))
      {
        return DateInt;
      }
      else
      {
        return null;
      }
    }

  }
}

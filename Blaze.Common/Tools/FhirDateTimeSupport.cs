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
    public enum Pression
    {
      Year,
      YearMonth,
      YearMonthDay,
      HourMin,
      Sec,
      MilliSec,
    }

    public static Pression GetPression(string DateTimeString)
    {
      if (Regex.IsMatch(DateTimeString as string, "^" + FhirDateTime.PATTERN + "$", RegexOptions.Singleline))
      {
        return Pression.MilliSec;
      }
      else if (Regex.IsMatch(DateTimeString as string, "^" + FhirDateTime.FMT_YEARMONTHDAY + "$", RegexOptions.Singleline))
      {
        return Pression.YearMonthDay;
      }
      else if (Regex.IsMatch(DateTimeString as string, "^" + FhirDateTime.FMT_YEARMONTH + "$", RegexOptions.Singleline))
      {
        return Pression.YearMonth;
      }
      else if (Regex.IsMatch(DateTimeString as string, "^" + FhirDateTime.FMT_YEAR + "$", RegexOptions.Singleline))
      {
        return Pression.Year;
      }
      else
      {
        return Pression.YearMonthDay;
      }
      
    }

  }
}

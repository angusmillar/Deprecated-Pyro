using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Pyro.Common.Search;

namespace Pyro.Common.Tools
{
  public class FhirDateTimeSupport
  {
    private readonly static char MinusTimeZoneDelimiter = '-';
    private readonly static char PlusTimeZoneDelimiter = '+';
    //private readonly static string TimeDelimiter = "T";
    private readonly static string MilliSecDelimiter = ".";
    private readonly static string HourMinSecDelimiter = ":";

    public enum DateTimePrecision { Year, Month, Day, HourMin, Sec, MilliSec, Tick };
    public DateTimeOffset? Value { get; set; }
    public int ValueDate { get; set; }

    public DateTimePrecision Precision { get; set; }
    private bool _IsValid;

    public bool IsValid
    {
      get { return _IsValid; }
    }

    public FhirDateTimeSupport(string Value)
    {
      _IsValid = Parse(Value);
    }


    private bool Parse(string FhirDateTime)
    {
      if (string.IsNullOrWhiteSpace(FhirDateTime))
        throw new NullReferenceException("Fhir DateTime cannot be null of empty string.");

      string OrginalFhirDateString = FhirDateTime;
      int OrginalFhirDateTimeLength = FhirDateTime.Length;
      FhirDateTime = CorrectByAddingSecondsToHourMinDateTimeWithNoSeconds(FhirDateTime);

      //Remember that timezone's must have coloums i.e +08:00 not +0800
      if (!Hl7.Fhir.Model.Primitives.PartialDateTime.TryParse(FhirDateTime, out Hl7.Fhir.Model.Primitives.PartialDateTime PartialDateTime))
        return false;


      if (OrginalFhirDateTimeLength > 29 && OrginalFhirDateTimeLength < 34)
      {
        //"yyyy-MM-ddTHH:mm:ss.ffffzzz"
        string Format = "yyyy-MM-ddTHH:mm:ss.ffffzzz";
        ParseDateTimeToUniversalTime(FhirDateTime, DateTimePrecision.Tick, Format, true);
        return true;
      }
      else if (OrginalFhirDateTimeLength == 29)
      {
        //"yyyy-MM-ddTHH:mm:ss.FFFzzz"
        string Format = "yyyy-MM-ddTHH:mm:ss.FFFzzz";
        ParseDateTimeToUniversalTime(FhirDateTime, DateTimePrecision.MilliSec, Format, true);
        return true;
      }
      else if (OrginalFhirDateTimeLength == 28)
      {
        //"yyyy-MM-ddTHH:mm:ss.FFzzz"
        string Format = "yyyy-MM-ddTHH:mm:ss.FFzzz";
        ParseDateTimeToUniversalTime(FhirDateTime, DateTimePrecision.MilliSec, Format, true);
        return true;
      }
      else if (OrginalFhirDateTimeLength == 27)
      {
        //"yyyy-MM-ddTHH:mm:ss.Fzzz"
        string Format = "yyyy-MM-ddTHH:mm:ss.Fzzz";
        ParseDateTimeToUniversalTime(FhirDateTime, DateTimePrecision.MilliSec, Format, true);
        return true;
      }
      else if (OrginalFhirDateTimeLength == 25)
      {
        //"yyyy-MM-ddTHH:mm:sszzz"
        string Format = "yyyy-MM-ddTHH:mm:sszzz";
        ParseDateTimeToUniversalTime(FhirDateTime, DateTimePrecision.Sec, Format, true);
        return true;
      }
      else if (OrginalFhirDateTimeLength == 24)
      {
        //1974-12-25T14:35:45.123Z
        //"yyyy-MM-ddTHH:mm:ss.FFFK"
        string Format = "yyyy-MM-ddTHH:mm:ss.FFFK";
        ParseDateTimeToUniversalTime(FhirDateTime, DateTimePrecision.Sec, Format, true);
        return true;
      }
      else if (OrginalFhirDateTimeLength == 23)
      {
        //"yyyy-MM-ddTHH:mm:ss.FFF"
        string Format = "yyyy-MM-ddTHH:mm:ss.FFF";
        ParseDateTimeToUniversalTime(FhirDateTime, DateTimePrecision.MilliSec, Format, false);
        return true;
      }
      else if (OrginalFhirDateTimeLength == 22 && OrginalFhirDateString.Substring(19, 1) == MilliSecDelimiter)
      {
        //"yyyy-MM-ddTHH:mm:ss.FF"
        string Format = "yyyy-MM-ddTHH:mm:ss.FF";
        ParseDateTimeToUniversalTime(FhirDateTime, DateTimePrecision.MilliSec, Format, false);
        return true;
      }
      else if (OrginalFhirDateTimeLength == 22 && OrginalFhirDateString.Substring(19, 1) == HourMinSecDelimiter)
      {
        //It was orginaly this "yyyy-MM-ddTHH:mmzzz", yet we have added the seconds on to make it valid so it is now "yyyy-MM-ddTHH:mm:sszzz" for parsing
        //"yyyy-MM-ddTHH:mmzzz"
        string Format = "yyyy-MM-ddTHH:mm:sszzz";
        ParseDateTimeToUniversalTime(FhirDateTime, DateTimePrecision.HourMin, Format, true);
        return true;
      }
      else if (OrginalFhirDateTimeLength == 21)
      {
        //"yyyy-MM-ddTHH:mm:ss.F"
        string Format = "yyyy-MM-ddTHH:mm:ss.F";
        ParseDateTimeToUniversalTime(FhirDateTime, DateTimePrecision.MilliSec, Format, false);
        return true;
      }
      else if (OrginalFhirDateTimeLength == 20)
      {
        //1974-12-25T14:35:45Z
        //"yyyy-MM-ddTHH:mm:ssK"
        string Format = "yyyy-MM-ddTHH:mm:ssK";
        ParseDateTimeToUniversalTime(FhirDateTime, DateTimePrecision.Sec, Format, true);
        return true;
      }
      else if (OrginalFhirDateTimeLength == 19)
      {
        //"yyyy-MM-ddTHH:mm:ss"
        string Format = "yyyy-MM-ddTHH:mm:ss";
        ParseDateTimeToUniversalTime(FhirDateTime, DateTimePrecision.Sec, Format, false);
        return true;
      }
      else if (OrginalFhirDateTimeLength == 16)
      {
        //It was orginaly this "yyyy-MM-ddTHH:mm", yet we have added the seconds on to make it valid so it is now "yyyy-MM-ddTHH:mm:ss" for parsing
        string Format = "yyyy-MM-ddTHH:mm:ss";
        ParseDateTimeToUniversalTime(FhirDateTime, DateTimePrecision.HourMin, Format, false);
        return true;
      }
      else if (OrginalFhirDateTimeLength == 10)
      {
        //"yyyy-MM-dd"    
        string Format = "yyyy-MM-dd";
        ParseDateTimeToUniversalTime(FhirDateTime, DateTimePrecision.Day, Format, false);
        return true;
      }
      else if (OrginalFhirDateTimeLength == 7)
      {
        //"yyyy-MM"
        string Format = "yyyy-MM";
        ParseDateTimeToUniversalTime(FhirDateTime, DateTimePrecision.Month, Format, false);
        return true;
      }
      else if (OrginalFhirDateTimeLength == 4)
      {
        //"yyyy"
        string Format = "yyyy";
        ParseDateTimeToUniversalTime(FhirDateTime, DateTimePrecision.Year, Format, false);
        return true;
      }
      else
      {
        throw new FormatException($"Unable to parse datetime using FHIR format rules. Value was {FhirDateTime}, no format could be determined.");
      }
    }

    private string CorrectByAddingSecondsToHourMinDateTimeWithNoSeconds(string FhirDateTime)
    {
      //Correct dateTimes that have no seconds yet do have Hours and Minitues
      //2017-04-28T18:29+10:00      
      //2017-04-28T18:29
      string SecondsToAdd = "00";
      var Split = FhirDateTime.Split(HourMinSecDelimiter.ToCharArray());
      string New = string.Empty;
      string Temp = string.Empty;
      if ((FhirDateTime.Length == 22 && FhirDateTime.Substring(19, 1) == HourMinSecDelimiter) || (FhirDateTime.Length == 16))
      {
        if (FhirDateTime.Length > 16)
        {
          //"yyyy-MM-ddTHH:mm" convert to "yyyy-MM-ddTHH:mm:ss"
          //Value has a timezone
          if (Split[1].Contains(MinusTimeZoneDelimiter))
          {
            Temp = $"{Split[1].Split(MinusTimeZoneDelimiter)[0]}{HourMinSecDelimiter}{SecondsToAdd}{MinusTimeZoneDelimiter}{Split[1].Split(MinusTimeZoneDelimiter)[1]}";
          }
          else if (Split[1].Contains(PlusTimeZoneDelimiter))
          {
            Temp = $"{Split[1].Split(PlusTimeZoneDelimiter)[0]}{HourMinSecDelimiter}{SecondsToAdd}{PlusTimeZoneDelimiter}{Split[1].Split(PlusTimeZoneDelimiter)[1]}";
          }
          return $"{Split[0]}{HourMinSecDelimiter}{Temp}{HourMinSecDelimiter}{Split[2]}";
        }
        else 
        {
          //"yyyy-MM-ddTHH:mmzzz" convert to "yyyy-MM-ddTHH:mm:sszzz"
          return $"{Split[0]}{HourMinSecDelimiter}{Split[1]}{HourMinSecDelimiter}{SecondsToAdd}";
        }        
      }
      else
      {
        return FhirDateTime;
      }      
    }

    private void ParseDateTimeToUniversalTime(string item, DateTimePrecision DateTimePrecision, string format, bool HasTimeZone)
    {
      if (HasTimeZone)
      {
        //As we have timezone info in the string we can parse stright to DateTimeOffset and then to UniversalTime
        if (DateTimeOffset.TryParseExact(item, format, null, System.Globalization.DateTimeStyles.None, out DateTimeOffset DateTimeOffsetFinal))
        {
          this.Precision = DateTimePrecision;
          this.Value = DateTimeOffsetFinal.ToUniversalTime();
        }
        else
        {
          throw new NullReferenceException($"Error parsing datetime with time zone info. Value was {item}, format in use {format}, the DateTime precision detected was {DateTimePrecision.ToString()}");
        }
      }
      else
      {
        //As we have no timezone info we must first parse to DateTime, then set as local timezone before converting to UniversalTime
        if (DateTime.TryParseExact(item, format, null, System.Globalization.DateTimeStyles.None, out DateTime DateTimeOut))
        {
          DateTimeOffset DateTimeOffsetFinal = new DateTimeOffset(DateTimeOut, TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow));
          this.Precision = DateTimePrecision;
          this.Value = DateTimeOffsetFinal.ToUniversalTime();
        }
        else
        {
          throw new NullReferenceException($"Error parsing datetime wiht no time zone info. Value was {item}, format in use {format}, the DateTime precision detected was {DateTimePrecision.ToString()}");
        }
      }
    }

    public static DateTimeOffset? ConvertToDateTimeOffSetLow(string FhirDateTimeString)
    {
      Hl7.Fhir.Model.Primitives.PartialDateTime PartialDateTime;
      if (Hl7.Fhir.Model.Primitives.PartialDateTime.TryParse(FhirDateTimeString, out PartialDateTime))
      {
        //var LocalTimeOffSet = DateTimeOffset.Now.Offset;
        //Convert to DateTimeOffset, which is done by caling ToUniversalTime(), yet this converts to UniversalTime
        // So we then set the timezone to the local timezone, which converts the time value to plus that timezone
        // So then subtract that timezone hours from the final result 
        //Now we have the original timezone and correct time.
        //DateTimeOffset Low = PartialDateTime.ToUniversalTime().ToOffset(LocalTimeOffSet).Subtract(LocalTimeOffSet);
        DateTimeOffset Low = PartialDateTime.ToUniversalTime();
        return Low;
        //return PartialDateTime.ToUniversalTime().ToLocalTime();
      }
      else
      {
        return null;
      }
    }

    public static DateTimeOffset CalculateHighDateTimeForRange(DateTimeOffset LowValue, DateTimePrecision Precision)
    {
      DateTimeOffset HighDateTime = LowValue;
      if (Precision == Common.Tools.FhirDateTimeSupport.DateTimePrecision.Year)
      {
        HighDateTime = LowValue.AddYears(1).AddMilliseconds(-1);
      }
      else if (Precision == Common.Tools.FhirDateTimeSupport.DateTimePrecision.Month)
      {
        HighDateTime = LowValue.AddMonths(1).AddMilliseconds(-1);
      }
      else if (Precision == Common.Tools.FhirDateTimeSupport.DateTimePrecision.Day)
      {
        HighDateTime = LowValue.AddDays(1).AddMilliseconds(-1);
      }
      else if (Precision == Common.Tools.FhirDateTimeSupport.DateTimePrecision.HourMin)
      {
        HighDateTime = LowValue.AddMinutes(1).AddMilliseconds(-1);
      }
      else if (Precision == Common.Tools.FhirDateTimeSupport.DateTimePrecision.Sec)
      {
        HighDateTime = LowValue.AddSeconds(1).AddMilliseconds(-1);
      }
      else if (Precision == Common.Tools.FhirDateTimeSupport.DateTimePrecision.MilliSec)
      {
        HighDateTime = LowValue.AddMilliseconds(1).AddTicks(-1);
      }
      else if (Precision == Common.Tools.FhirDateTimeSupport.DateTimePrecision.Tick)
      {
        HighDateTime = LowValue;
      }
      else
      {
        throw new System.ComponentModel.InvalidEnumArgumentException(Precision.ToString(), (int)Precision, typeof(DateTimePrecision));
      }
      return HighDateTime;
    }

  }
}

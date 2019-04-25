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

      if (OrginalFhirDateTimeLength == 34)
      {
        //2019-04-24T11:00:54.12345678+10:00
        string Format = "yyyy-MM-ddTHH:mm:ss.ffffffffzzz";
        ParseDateTimeToUniversalTime(FhirDateTime, DateTimePrecision.MilliSec, Format, true);
        return true;
      }
      else if (OrginalFhirDateTimeLength == 33)
      {
        //2019-04-24T11:00:54.1234567+10:00
        string Format = "yyyy-MM-ddTHH:mm:ss.fffffffzzz";
        ParseDateTimeToUniversalTime(FhirDateTime, DateTimePrecision.MilliSec, Format, true);
        return true;
      }
      else if (OrginalFhirDateTimeLength == 32)
      {
        //2019-04-24T11:00:54.123456+10:00
        string Format = "yyyy-MM-ddTHH:mm:ss.ffffffzzz";
        ParseDateTimeToUniversalTime(FhirDateTime, DateTimePrecision.MilliSec, Format, true);
        return true;
      }
      else if (OrginalFhirDateTimeLength == 31)
      {
        //2019-04-24T11:00:54.12345+10:00
        string Format = "yyyy-MM-ddTHH:mm:ss.fffffzzz";
        ParseDateTimeToUniversalTime(FhirDateTime, DateTimePrecision.MilliSec, Format, true);
        return true;
      }
      else if (OrginalFhirDateTimeLength == 30)
      {
        //2019-04-24T11:00:54.7699+10:00
        string Format = "yyyy-MM-ddTHH:mm:ss.ffffzzz";
        ParseDateTimeToUniversalTime(FhirDateTime, DateTimePrecision.MilliSec, Format, true);
        return true;
      }
      else if (OrginalFhirDateTimeLength == 29)
      {
        //"yyyy-MM-ddTHH:mm:ss.FFFzzz"
        string Format = "yyyy-MM-ddTHH:mm:ss.fffzzz";
        ParseDateTimeToUniversalTime(FhirDateTime, DateTimePrecision.MilliSec, Format, true);
        return true;
      }
      else if (OrginalFhirDateTimeLength == 28)
      {
        //"yyyy-MM-ddTHH:mm:ss.FFzzz"
        string Format = "yyyy-MM-ddTHH:mm:ss.ffzzz";
        ParseDateTimeToUniversalTime(FhirDateTime, DateTimePrecision.MilliSec, Format, true);
        return true;
      }
      else if (OrginalFhirDateTimeLength == 27)
      {
        //"yyyy-MM-ddTHH:mm:ss.Fzzz"
        string Format = "yyyy-MM-ddTHH:mm:ss.fzzz";
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
        string Format = "yyyy-MM-ddTHH:mm:ss.fffK";
        ParseDateTimeToUniversalTime(FhirDateTime, DateTimePrecision.Sec, Format, true);
        return true;
      }
      else if (OrginalFhirDateTimeLength == 23)
      {
        //"yyyy-MM-ddTHH:mm:ss.FFF"
        string Format = "yyyy-MM-ddTHH:mm:ss.fff";
        ParseDateTimeToUniversalTime(FhirDateTime, DateTimePrecision.MilliSec, Format, false);
        return true;
      }
      else if (OrginalFhirDateTimeLength == 22 && OrginalFhirDateString.Substring(19, 1) == MilliSecDelimiter)
      {
        //"yyyy-MM-ddTHH:mm:ss.FF"
        string Format = "yyyy-MM-ddTHH:mm:ss.ff";
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
        string Format = "yyyy-MM-ddTHH:mm:ss.f";
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
        //To deal with the problem of no time zones on Dates, e.g 2018-10-05 we treat the search as a 36 hour day rather than a 24 hours day
        //When the precision is one on Year, Month or Day. For more find grained precisions such as Hour, Min, Sec we  expected to have the 
        //time zones information surplus, if time zone differences are a concern of the searcher.
        //
        //So to do this I subtract 6 hours from the beginning of the date range 2018-10-05T00:00 and we add 6 hours to the end of the day 2018-10-05T23:59
        //This gives us a 36 hour day range. The idea is that it is better to return more than less for the search.
        //This is a compromise as we really do not know what is meant by a date with no time zone. We can assume the servers default time zone as a starting point
        //but this is only a guess to what the true time zone was for either the supplied search date or the stored FHIR resource dates, when dealing with only date 
        //and no time.  
        //
        //So the range we actually use for this example is not:   
        //  2018-10-05T00:00 to 2018-10-05T23:59 
        //but rather: 
        //  2018-10-04T18:00 to 2018-10-06T05:59 
        //which in a 12hr clock is 04/10/2018 6:00PM to 06/10/2018 6:00AM when the search date was: 05/10/2018
        //Also bare in mind that all date times are converted to UTC Zulu +00:00 time when stored and searched in the database.

        //Work out the normal 24 hour day range low and high
        HighDateTime = LowValue.AddYears(1).AddMilliseconds(-1);

        //Subtract 6 hours from the low
        LowValue = LowValue.AddHours(-6);
        //Add 6 hours to the high
        HighDateTime = HighDateTime.AddHours(6);

      }
      else if (Precision == Common.Tools.FhirDateTimeSupport.DateTimePrecision.Month)
      {
        //Work out the normal 24 hour day range low and high
        HighDateTime = LowValue.AddMonths(1).AddMilliseconds(-1);

        //Subtract 6 hours from the low
        LowValue = LowValue.AddHours(-6);
        //Add 6 hours to the high
        HighDateTime = HighDateTime.AddHours(6);
      }
      else if (Precision == Common.Tools.FhirDateTimeSupport.DateTimePrecision.Day)
      {
        //Work out the normal 24 hour day range low and high
        HighDateTime = LowValue.AddDays(1).AddMilliseconds(-1);
        
        //Subtract 6 hours from the low
        LowValue = LowValue.AddHours(-6);
        //Add 6 hours to the high
        HighDateTime = HighDateTime.AddHours(6);
        
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

    public static string DateTimeOffSetToFhirStringFormat(DateTimeOffset datetime)
    {
      //2018-12-27T22:37:54+11:00
      return datetime.ToString("yyyy-MM-ddTHH:mm:sszzz");
    }
  }
}

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Pyro.Common.BusinessEntities.Search;

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


      DateTimeOffset TempDateTimeOffset = DateTimeOffset.MinValue;
      if (FhirDateTime.Length > 29 && FhirDateTime.Length < 34)
      {
        //"yyyy-MM-ddTHH:mm:ss.ffffzzz"
        var Result = ConvertToDateTimeOffSet(FhirDateTime);
        if (Result.HasValue)
        {
          this.Precision = DateTimePrecision.Tick;
          this.Value = Result.Value;
          return true;
        }
      }
      else if (FhirDateTime.Length == 29)
      {
        //"yyyy-MM-ddTHH:mm:ss.FFFzzz"
        var Result = ConvertToDateTimeOffSet(FhirDateTime);
        if (Result.HasValue)
        {
          this.Precision = DateTimePrecision.MilliSec;
          this.Value = Result.Value;
          return true;
        }              
      }
      else if (FhirDateTime.Length == 28)
      {
        //"yyyy-MM-ddTHH:mm:ss.FFzzz"
        var Result = ConvertToDateTimeOffSet(FhirDateTime);
        if (Result.HasValue)
        {
          this.Precision = DateTimePrecision.MilliSec;
          this.Value = Result.Value;
          return true;
        }        
      }
      else if (FhirDateTime.Length == 27)
      {
        //"yyyy-MM-ddTHH:mm:ss.Fzzz"
        var Result = ConvertToDateTimeOffSet(FhirDateTime);
        if (Result.HasValue)
        {
          this.Precision = DateTimePrecision.MilliSec;
          this.Value = Result.Value;
          return true;
        }        
      }
      else if (FhirDateTime.Length == 25)
      {
        //"yyyy-MM-ddTHH:mm:sszzz"
        var Result = ConvertToDateTimeOffSet(FhirDateTime);
        if (Result.HasValue)
        {
          this.Precision = DateTimePrecision.Sec;
          this.Value = Result.Value;
          return true;
        }
      }
      else if (FhirDateTime.Length == 24)
      {
        //1974-12-25T14:35:45.123Z
        //"yyyy-MM-ddTHH:mm:ss.FFFK"
        var Result = ConvertToDateTimeOffSet(FhirDateTime);
        if (Result.HasValue)
        {
          this.Precision = DateTimePrecision.Sec;
          this.Value = Result.Value;
          return true;
        }
      }
      else if (FhirDateTime.Length == 23)
      {
        //"yyyy-MM-ddTHH:mm:ss.FFF"
        var Result = ConvertToDateTimeOffSet(FhirDateTime);
        if (Result.HasValue)
        {
          this.Precision = DateTimePrecision.MilliSec;
          this.Value = Result.Value;
          return true;
        }        
      }
      else if (FhirDateTime.Length == 22 && FhirDateTime.Substring(19, 1) == MilliSecDelimiter)
      {
        //"yyyy-MM-ddTHH:mm:ss.FF"
        var Result = ConvertToDateTimeOffSet(FhirDateTime);
        if (Result.HasValue)
        {
          this.Precision = DateTimePrecision.MilliSec;
          this.Value = Result.Value;
          return true;
        }        
      }
      else if (FhirDateTime.Length == 22 && FhirDateTime.Substring(19, 1) == HourMinSecDelimiter)
      {
        //"yyyy-MM-ddTHH:mmzzz"
        var Result = ConvertToDateTimeOffSet(AddSecondsToHourMinDateTime(FhirDateTime));
        if (Result.HasValue)
        {
          this.Precision = DateTimePrecision.HourMin;
          this.Value = Result.Value;
          return true;
        }        
      }
      else if (FhirDateTime.Length == 21)
      {
        //"yyyy-MM-ddTHH:mm:ss.F"
        var Result = ConvertToDateTimeOffSet(FhirDateTime);
        if (Result.HasValue)
        {
          this.Precision = DateTimePrecision.MilliSec;
          this.Value = Result.Value;
          return true;
        }        
      }
      else if (FhirDateTime.Length == 20)
      {

        //1974-12-25T14:35:45Z
        //"yyyy-MM-ddTHH:mm:ssK"
        var Result = ConvertToDateTimeOffSet(FhirDateTime);
        if (Result.HasValue)
        {
          this.Precision = DateTimePrecision.Sec;
          this.Value = Result.Value;
          return true;
        }
      }
      else if (FhirDateTime.Length == 19)
      {
        //"yyyy-MM-ddTHH:mm:ss"
        var Result = ConvertToDateTimeOffSet(FhirDateTime);
        if (Result.HasValue)
        {
          this.Precision = DateTimePrecision.Sec;
          this.Value = Result.Value;
          return true;
        }        
      }
      else if (FhirDateTime.Length == 16)
      {
        //"yyyy-MM-ddTHH:mm"
        var Result = ConvertToDateTimeOffSet(AddSecondsToHourMinDateTime(FhirDateTime));
        if (Result.HasValue)
        {
          this.Precision = DateTimePrecision.HourMin;
          this.Value = Result.Value;
          return true;
        }
      }
      else if (FhirDateTime.Length == 10)
      {
        //"yyyy-MM-dd"
        var Result = ConvertToDateTimeOffSet(FhirDateTime);
        if (Result.HasValue)
        {
          this.Precision = DateTimePrecision.Day;
          this.Value = Result.Value;
          return true;
        }        
      }
      else if (FhirDateTime.Length == 7)
      {
        //"yyyy-MM"
        var Result = ConvertToDateTimeOffSet(FhirDateTime);
        if (Result.HasValue)
        {
          this.Precision = DateTimePrecision.Month;
          this.Value = Result.Value;
          return true;
        }
      }
      else if (FhirDateTime.Length == 4)
      {
        //"yyyy"
        var Result = ConvertToDateTimeOffSet(FhirDateTime);
        if (Result.HasValue)
        {
          this.Precision = DateTimePrecision.Year;
          this.Value = Result.Value;
          return true;
        }
      }
      this.Value = null;
      return false;
    }

    private string AddSecondsToHourMinDateTime(string FhirDateTime)
    {
      //2017-04-28T18:29+10:00      
      //2017-04-28T18:29
      string SecondsToAdd = "00";
      var Split = FhirDateTime.Split(HourMinSecDelimiter.ToCharArray());
      string New = string.Empty;
      string Temp = string.Empty;
      if (FhirDateTime.Length > 16)
      {
        //Value has a timezone
        if (Split[1].Contains(MinusTimeZoneDelimiter))
        {
          Temp = $"{Split[1].Split(MinusTimeZoneDelimiter)[0]}{HourMinSecDelimiter}{SecondsToAdd}{MinusTimeZoneDelimiter}{Split[1].Split(MinusTimeZoneDelimiter)[1]}";
        }
        else if (Split[1].Contains(PlusTimeZoneDelimiter))
        {
          Temp = $"{Split[1].Split(PlusTimeZoneDelimiter)[0]}{HourMinSecDelimiter}{SecondsToAdd}{PlusTimeZoneDelimiter}{Split[1].Split(PlusTimeZoneDelimiter)[1]}";
        }
        New = $"{Split[0]}{HourMinSecDelimiter}{Temp}{HourMinSecDelimiter}{Split[2]}"; 
      }
      else
      {
        New = $"{Split[0]}{HourMinSecDelimiter}{Split[1]}{HourMinSecDelimiter}{SecondsToAdd}";
      }
      return New;
    }

    private DateTimeOffset? ConvertToDateTimeOffSet(string Value)
    {
      Hl7.Fhir.Model.Primitives.PartialDateTime PartialDateTime;
      if (Hl7.Fhir.Model.Primitives.PartialDateTime.TryParse(Value, out PartialDateTime))
      {
        return PartialDateTime.ToUniversalTime().ToLocalTime();
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

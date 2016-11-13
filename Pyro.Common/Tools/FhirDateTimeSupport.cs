using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;


namespace Pyro.Common.Tools
{
  public class FhirDateTimeSupport
  {

    //private readonly static string DateAndTimeZoneDelimiter = "-";
    //private readonly static string PlusTimeZoneDelimiter = "+";
    //private readonly static string TimeDelimiter = "T";
    private readonly static string MilliSecDelimiter = ".";
    private readonly static string HourMinSecDelimiter = ":";

    public enum DateTimePrecision { Year, Month, Day, HourMin, Sec, MilliSec };
    public DateTimeOffset? Value { get; set; }
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
      if (FhirDateTime.Length == 29)
      {
        var Result = ConvertToDateTimeOffSet(FhirDateTime, "yyyy-MM-ddTHH:mm:ss.FFFzzz", true);
        if (Result.HasValue)
        {
          this.Precision = DateTimePrecision.MilliSec;
          this.Value = Result.Value;
          return true;
        }              
      }
      else if (FhirDateTime.Length == 28)
      {
        var Result = ConvertToDateTimeOffSet(FhirDateTime, "yyyy-MM-ddTHH:mm:ss.FFzzz", true);
        if (Result.HasValue)
        {
          this.Precision = DateTimePrecision.MilliSec;
          this.Value = Result.Value;
          return true;
        }        
      }
      else if (FhirDateTime.Length == 27)
      {
        var Result = ConvertToDateTimeOffSet(FhirDateTime, "yyyy-MM-ddTHH:mm:ss.Fzzz", true);
        if (Result.HasValue)
        {
          this.Precision = DateTimePrecision.MilliSec;
          this.Value = Result.Value;
          return true;
        }        
      }
      else if (FhirDateTime.Length == 25)
      {
        var Result = ConvertToDateTimeOffSet(FhirDateTime, "yyyy-MM-ddTHH:mm:sszzz", true);
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
        var Result = ConvertToDateTimeOffSet(FhirDateTime, "yyyy-MM-ddTHH:mm:ss.FFFK", true);
        if (Result.HasValue)
        {
          this.Precision = DateTimePrecision.Sec;
          this.Value = Result.Value;
          return true;
        }
      }
      else if (FhirDateTime.Length == 23)
      {
        var Result = ConvertToDateTimeOffSet(FhirDateTime, "yyyy-MM-ddTHH:mm:ss.FFF", false);
        if (Result.HasValue)
        {
          this.Precision = DateTimePrecision.MilliSec;
          this.Value = Result.Value;
          return true;
        }        
      }
      else if (FhirDateTime.Length == 22 && FhirDateTime.Substring(19, 1) == MilliSecDelimiter)
      {
        var Result = ConvertToDateTimeOffSet(FhirDateTime, "yyyy-MM-ddTHH:mm:ss.FF", false);
        if (Result.HasValue)
        {
          this.Precision = DateTimePrecision.MilliSec;
          this.Value = Result.Value;
          return true;
        }        
      }
      else if (FhirDateTime.Length == 22 && FhirDateTime.Substring(19, 1) == HourMinSecDelimiter)
      {
        var Result = ConvertToDateTimeOffSet(FhirDateTime, "yyyy-MM-ddTHH:mmzzz", true);
        if (Result.HasValue)
        {
          this.Precision = DateTimePrecision.HourMin;
          this.Value = Result.Value;
          return true;
        }        
      }
      else if (FhirDateTime.Length == 21)
      {
        var Result = ConvertToDateTimeOffSet(FhirDateTime, "yyyy-MM-ddTHH:mm:ss.F", false);
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
        var Result = ConvertToDateTimeOffSet(FhirDateTime, "yyyy-MM-ddTHH:mm:ssK", true);
        if (Result.HasValue)
        {
          this.Precision = DateTimePrecision.Sec;
          this.Value = Result.Value;
          return true;
        }
      }
      else if (FhirDateTime.Length == 19)
      {
        var Result = ConvertToDateTimeOffSet(FhirDateTime, "yyyy-MM-ddTHH:mm:ss", false);
        if (Result.HasValue)
        {
          this.Precision = DateTimePrecision.Sec;
          this.Value = Result.Value;
          return true;
        }        
      }
      else if (FhirDateTime.Length == 16)
      {
        var Result = ConvertToDateTimeOffSet(FhirDateTime, "yyyy-MM-ddTHH:mm", false);
        if (Result.HasValue)
        {
          this.Precision = DateTimePrecision.HourMin;
          this.Value = Result.Value;
          return true;
        }
      }
      else if (FhirDateTime.Length == 10)
      {
        var Result = ConvertToDateTimeOffSet(FhirDateTime, "yyyy-MM-dd", false);
        if (Result.HasValue)
        {
          this.Precision = DateTimePrecision.Day;
          this.Value = Result.Value;
          return true;
        }        
      }
      else if (FhirDateTime.Length == 7)
      {
        var Result = ConvertToDateTimeOffSet(FhirDateTime, "yyyy-MM", false);
        if (Result.HasValue)
        {
          this.Precision = DateTimePrecision.Month;
          this.Value = Result.Value;
          return true;
        }
      }
      else if (FhirDateTime.Length == 4)
      {
        var Result = ConvertToDateTimeOffSet(FhirDateTime, "yyyy", false);
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

    private DateTimeOffset? ConvertToDateTimeOffSet(string Value, string Format, bool HasTimeZone)
    {
      DateTimeOffset TempDateTimeOffset = DateTimeOffset.MinValue;
      if (DateTimeOffset.TryParseExact(Value, Format, System.Globalization.CultureInfo.InvariantCulture, 
                                       System.Globalization.DateTimeStyles.RoundtripKind, out TempDateTimeOffset))
      {        
        return TempDateTimeOffset;
      }
      else
      {
        return null;
      }
    }
    
    

  }
}

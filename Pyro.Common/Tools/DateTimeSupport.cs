using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Model.Primitives;
using Hl7.Fhir.Support;


namespace Pyro.Common.Tools
{
  public static class DateTimeSupport
  {
    public static DateTimeIndex GetDateTimeIndex(Date value)
    {
      PartialDateTime? PartialDateTimeType = value.ToPartialDateTime();
      return ParsePartialDateTime(PartialDateTimeType);     
    }

    public static DateTimeIndex GetDateTimeIndex(FhirDateTime value)
    {
      PartialDateTime? PartialDateTimeType = value.ToPartialDateTime();
      return ParsePartialDateTime(PartialDateTimeType);
    }

    public static DateTimeIndex GetDateTimeIndex(Instant value)
    {
      PartialDateTime? PartialDateTimeType = value.ToPartialDateTime();
      return ParsePartialDateTime(PartialDateTimeType);
    }

    public static DateTimeIndex GetDateTimeIndex(Period value)
    {
      var DateTimeIndex = new DateTimeIndex();
      PartialDateTime? PartialDateTimeLow = null;
      if (value.StartElement != null)
      {
        PartialDateTimeLow = value.StartElement.ToPartialDateTime();
      }

      PartialDateTime? PartialDateTimeHigh = null;
      if (value.EndElement != null)
      {
        PartialDateTimeHigh = value.EndElement.ToPartialDateTime();
      }

      if (PartialDateTimeLow.HasValue)
        DateTimeIndex.Low = PartialDateTimeLow.Value.ToUniversalTime().ToLocalTime();
      if (PartialDateTimeHigh.HasValue)
        DateTimeIndex.High = PartialDateTimeHigh.Value.ToUniversalTime().ToLocalTime();

      return DateTimeIndex;
    }

    public static DateTimeIndex GetDateTimeIndex(Timing Timing)
    {
      var DateTimeIndex = new DateTimeIndex();
      if (Timing.Event != null)
      {        
        DateTimeIndex.Low = ResolveTargetEventDateTime(Timing, true);
        if (DateTimeIndex.Low != DateTimeOffset.MaxValue)
        {
          decimal TargetDuration = ResolveTargetDurationValue(Timing);
          Timing.UnitsOfTime? TargetUnitsOfTime = null;
          if (TargetDuration > decimal.Zero)
          {
            if (Timing.Repeat.DurationUnit.HasValue)
              TargetUnitsOfTime = Timing.Repeat.DurationUnit.Value;
          }

          if (TargetDuration > decimal.Zero && TargetUnitsOfTime.HasValue)
          {
            DateTimeIndex.High = AddDurationTimeToEvent(ResolveTargetEventDateTime(Timing, false), TargetDuration, TargetUnitsOfTime);            
          }
          else
          {
            DateTimeIndex.High = null;
          }          
        }
        else
        {
          DateTimeIndex.Low = null;
        }
      }
      return DateTimeIndex;      
    }

    private static DateTimeIndex ParsePartialDateTime(PartialDateTime? PartialDateTimeType)
    {
      //2012-12-01T12:00:00+01:00
      DateTimeOffset Low = PartialDateTimeType.Value.ToUniversalTime().ToLocalTime();
      DateTimeOffset High = DateTimeOffset.MaxValue;
      if (PartialDateTimeType != null)
      {
        int DateCharCount = PartialDateTimeType.Value.ToString().Count();
        if (DateCharCount == 4)
        {
          High = Low.AddYears(1).AddMilliseconds(-1);
        }
        else if (DateCharCount == 7)
        {
          High = Low.AddMonths(1).AddMilliseconds(-1);
        }
        else if (DateCharCount == 10)
        {
          High = Low.AddDays(1).AddMilliseconds(-1);
        }        
        else if (DateCharCount == 25)
        {
          High = Low.AddSeconds(1).AddMilliseconds(-1);
        }
        else if (DateCharCount == 27 || DateCharCount == 28 || DateCharCount == 29)
        {
          High = Low.AddMilliseconds(1);
        }
        else if (DateCharCount > 29)
        {
          High = Low.AddTicks(1);
        }    
      }
      return new DateTimeIndex(Low, High);
    }

    //Check all DateTime values in the list and find the earliest value.        
    private static DateTimeOffset ResolveTargetEventDateTime(Timing Timing, bool TargetLowest)
    {
      DateTimeOffset TargetEventDateTime;
      if (TargetLowest)
        TargetEventDateTime = DateTimeOffset.MaxValue;
      else
        TargetEventDateTime = DateTimeOffset.MinValue;

      foreach (var EventDateTime in Timing.EventElement)
      {
        if (!string.IsNullOrWhiteSpace(EventDateTime.Value))
        {
          if (FhirDateTime.IsValidValue(EventDateTime.Value))
          {
            PartialDateTime? PartialDateTimeType = EventDateTime.ToPartialDateTime();            
            if (PartialDateTimeType.HasValue)
            {
              DateTimeOffset DateTimeOffSetValue = PartialDateTimeType.Value.ToUniversalTime().ToLocalTime();
              if (TargetLowest)
              {
                if (TargetEventDateTime > DateTimeOffSetValue)
                {
                  TargetEventDateTime = DateTimeOffSetValue;
                }
              }
              else
              {
                if (TargetEventDateTime < DateTimeOffSetValue)
                {
                  TargetEventDateTime = DateTimeOffSetValue;
                }
              }
            }
          }
        }
      }
      return TargetEventDateTime;
    }
    private static decimal ResolveTargetDurationValue(Timing Timing)
    {
      decimal TargetDuration = decimal.Zero;
      decimal DurationMax = decimal.Zero;
      decimal Duration = decimal.Zero;
      if (Timing.Repeat != null)
      {
        if (Timing.Repeat.DurationMax != null)
        {
          if (Timing.Repeat.DurationMax.HasValue)
          {
            DurationMax = Timing.Repeat.DurationMax.Value;
          }
        }
        if (DurationMax == decimal.Zero)
        {
          if (Timing.Repeat.Duration != null)
          {
            if (Timing.Repeat.Duration.HasValue)
            {
              Duration = Timing.Repeat.Duration.Value;
            }
          }
        }
        if (DurationMax > decimal.Zero)
        {
          TargetDuration = DurationMax;
        }
        else if (Duration > decimal.Zero)
        {
          TargetDuration = Duration;
        }
        return TargetDuration;
      }
      return decimal.Zero;
    }
    private static DateTimeOffset AddDurationTimeToEvent(DateTimeOffset FromDateTime, decimal TargetDuration, Timing.UnitsOfTime? TargetUnitsOfTime)
    {
      switch (TargetUnitsOfTime)
      {
        case Timing.UnitsOfTime.S:
          {
            return FromDateTime.AddSeconds(Convert.ToDouble(TargetDuration));
          }
        case Timing.UnitsOfTime.Min:
          {
            return FromDateTime.AddMinutes(Convert.ToDouble(TargetDuration));
          }
        case Timing.UnitsOfTime.H:
          {
            return FromDateTime.AddHours(Convert.ToDouble(TargetDuration));
          }
        case Timing.UnitsOfTime.D:
          {
            return FromDateTime.AddDays(Convert.ToDouble(TargetDuration));
          }
        case Timing.UnitsOfTime.Wk:
          {
            return FromDateTime.AddDays(Convert.ToDouble(TargetDuration * 7));
          }
        case Timing.UnitsOfTime.Mo:
          {
            return FromDateTime.AddMonths(Convert.ToInt32(TargetDuration));
          }
        case Timing.UnitsOfTime.A:
          {
            return FromDateTime.AddYears(Convert.ToInt32(TargetDuration));
          }
        default:
          {
            throw new System.ComponentModel.InvalidEnumArgumentException(TargetUnitsOfTime.ToString(), (int)TargetUnitsOfTime, typeof(Timing.UnitsOfTime));
          }
      }
    }
  }
}

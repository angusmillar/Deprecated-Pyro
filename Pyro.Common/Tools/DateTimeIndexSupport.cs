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
  public static class DateTimeIndexSupport
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
      DateTimeIndex DateTimeIndexStart = null;
      DateTimeIndex DateTimeIndexEnd = null;

      var DateTimeIndex = new DateTimeIndex();
      PartialDateTime? PartialDateTimeLow = null;
      if (value.StartElement != null)
      {        
        PartialDateTimeLow = value.StartElement.ToPartialDateTime();
        DateTimeIndexStart = ParsePartialDateTime(PartialDateTimeLow);
      }

      PartialDateTime? PartialDateTimeHigh = null;
      if (value.EndElement != null)
      {
        PartialDateTimeHigh = value.EndElement.ToPartialDateTime();
        DateTimeIndexEnd = ParsePartialDateTime(PartialDateTimeHigh);
      }

      if (DateTimeIndexStart != null)
        DateTimeIndex.Low = DateTimeIndexStart.Low;
      if (DateTimeIndexEnd != null)
        DateTimeIndex.High = DateTimeIndexEnd.High;
      
      return DateTimeIndex;
    }

    public static DateTimeIndex GetDateTimeIndex(Timing Timing)
    {
      var DateTimeIndex = new DateTimeIndex();
      if (Timing.Event != null)
      {
        DateTimeIndex.Low = ResolveTargetEventDateTime(Timing, true);
        if (DateTimeIndex.Low != DateTimeOffset.MaxValue.ToUniversalTime())
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
      FhirDateTimeSupport FhirDateTimeSupport = new FhirDateTimeSupport(PartialDateTimeType.Value.ToString());
      if (FhirDateTimeSupport.IsValid)
      {
        DateTimeOffset? Low = FhirDateTimeSupport.Value;
        DateTimeOffset High = DateTimeOffset.MaxValue;

        switch (FhirDateTimeSupport.Precision)
        {
          case FhirDateTimeSupport.DateTimePrecision.Year:
            High = Low.Value.AddYears(1).AddMilliseconds(-1);
            break;
          case FhirDateTimeSupport.DateTimePrecision.Month:
            High = Low.Value.AddMonths(1).AddMilliseconds(-1);
            break;
          case FhirDateTimeSupport.DateTimePrecision.Day:
            High = Low.Value.AddDays(1).AddMilliseconds(-1);
            break;
          case FhirDateTimeSupport.DateTimePrecision.HourMin:
            High = Low.Value.AddSeconds(1).AddMilliseconds(-1);
            break;
          case FhirDateTimeSupport.DateTimePrecision.Sec:
            High = Low.Value.AddMilliseconds(999);
            break;
          case FhirDateTimeSupport.DateTimePrecision.MilliSec:
            High = Low.Value.AddMilliseconds(1).AddTicks(-1);            
            break;
          case FhirDateTimeSupport.DateTimePrecision.Tick:
            High = Low.Value.AddTicks(1);
            break;
          default:
            break;
        }
        return new DateTimeIndex(Low.Value, High);       
      }
      return null;
    }
    
    //Check all DateTime values in the list and find the earliest value.        
    private static DateTimeOffset ResolveTargetEventDateTime(Timing Timing, bool TargetLowest)
    {
      DateTimeOffset TargetEventDateTime;
      if (TargetLowest)
        TargetEventDateTime = DateTimeOffset.MaxValue.ToUniversalTime();
      else
        TargetEventDateTime = DateTimeOffset.MinValue.ToUniversalTime();

      foreach (var EventDateTime in Timing.EventElement)
      {
        if (!string.IsNullOrWhiteSpace(EventDateTime.Value))
        {
          if (FhirDateTime.IsValidValue(EventDateTime.Value))
          {            
            PartialDateTime? PartialDateTimeType = EventDateTime.ToPartialDateTime();
            if (PartialDateTimeType.HasValue)
            {
              DateTimeIndex DateTimeIndexOffSetValue = ParsePartialDateTime(PartialDateTimeType.Value);

              DateTimeOffset DateTimeOffSetValue = PartialDateTimeType.Value.ToUniversalTime().ToLocalTime();
              if (TargetLowest)
              {
                if (TargetEventDateTime > DateTimeIndexOffSetValue.Low.Value)
                {
                  TargetEventDateTime = DateTimeIndexOffSetValue.Low.Value;
                }
              }
              else
              {
                if (TargetEventDateTime < DateTimeIndexOffSetValue.High.Value)
                {
                  TargetEventDateTime = DateTimeIndexOffSetValue.High.Value;
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

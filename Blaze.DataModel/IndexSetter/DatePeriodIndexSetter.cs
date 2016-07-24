using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.Common.Interfaces.UriSupport;
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.DataModel.Repository;
using Hl7.Fhir.Model;

namespace Blaze.DataModel.IndexSetter
{
  public class DatePeriodIndexSetter : IDatePeriodIndexSetter
  {
    public ModelBase Set(Element FhirElement, ModelBase ModelBase, IDtoFhirRequestUri FhirRequestUri = null, CommonRepository CommonRepository = null)
    {
      if (ModelBase == null)
      {
        throw new ArgumentNullException("ModelBase cannot be null for method.");
      }
      if (FhirElement == null)
      {
        throw new ArgumentNullException("FhirElement cannot be null for method.");
      }

      if (ModelBase is DatePeriodIndex)
      {
        var DatePeriodIndex = ModelBase as DatePeriodIndex;
        if (FhirElement is Period)
        {
          return SetPeriod(FhirElement as Period, DatePeriodIndex);
        }
        else if (FhirElement is Timing)
        {
          return SetTiming(FhirElement as Timing, DatePeriodIndex);
        }
        else
        {
          throw new Exception(string.Format("FhirElement was unexpected type for QuantityRangeIndexSetter, type was {0}", FhirElement.ToString()));
        }
      }
      else
      {
        throw new InvalidCastException(string.Format("DateIndexSetter expected typeof {0} yet was passed typeof {1}", typeof(DatePeriodIndex).Name, ModelBase.GetType().Name));
      }
    }

    public DatePeriodIndex SetPeriod(Period Period, DatePeriodIndex DatePeriodIndex)
    {
      if (Period == null)
        throw new ArgumentNullException("Period cannot be null for method.");

      if (DatePeriodIndex == null)
        throw new ArgumentNullException("DatePeriodIndex cannot be null for method.");


      if (Period.StartElement != null)
      {
        if (FhirDateTime.IsValidValue(Period.Start))
        {
          DatePeriodIndex.DateTimeOffsetLow = Period.StartElement.ToDateTimeOffset();
        }
        else
        {
          throw new FormatException(string.Format("The date & time given '{0}' is not a valid FHIR date & time format.", Period.Start));
        }
      }
      else
      {
        DatePeriodIndex.DateTimeOffsetLow = null;
      }
      if (Period.EndElement != null)
      {
        if (FhirDateTime.IsValidValue(Period.End))
        {
          DatePeriodIndex.DateTimeOffsetHigh = Period.EndElement.ToDateTimeOffset();
        }
        else
        {
          throw new FormatException(string.Format("The date & time given '{0}' is not a valid FHIR date & time format.", Period.End));
        }
      }
      else
      {
        DatePeriodIndex.DateTimeOffsetHigh = null;
      }
      if (DatePeriodIndex.DateTimeOffsetLow == null && DatePeriodIndex.DateTimeOffsetHigh == null)
      {
        return null;
      }
      return DatePeriodIndex;
    }
    
    public DatePeriodIndex SetTiming(Timing Timing, DatePeriodIndex DatePeriodIndex)
    {
      if (Timing == null)
        throw new ArgumentNullException("Timing cannot be null for method.");

      if (DatePeriodIndex == null)
        throw new ArgumentNullException("DatePeriodIndex cannot be null for method.");

      if (Timing.Event == null)
      {
        return null;
      }
      else
      {
        DatePeriodIndex.DateTimeOffsetLow = ResolveTargetEventDateTime(Timing, true);
        if (DatePeriodIndex.DateTimeOffsetLow == DateTimeOffset.MaxValue)
        {
          //If we have no start event then we can not calculate the end date time so return null
          return null;
        }
        else
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
            DatePeriodIndex.DateTimeOffsetHigh = AddDurationTimeToEvent(ResolveTargetEventDateTime(Timing, false), TargetDuration, TargetUnitsOfTime);
            return DatePeriodIndex;
          }
          else
          {
            DatePeriodIndex.DateTimeOffsetHigh = null;
          }

          if (DatePeriodIndex.DateTimeOffsetLow == null && DatePeriodIndex.DateTimeOffsetHigh == null)
          {
            return null;
          }
          else
          {
            return DatePeriodIndex;
          }
        }
      }
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
            var TempDateTimeOffset = new DateTimeOffset();
            if (DateTimeOffset.TryParse(EventDateTime.Value, out TempDateTimeOffset))
            {
              if (TargetLowest)
              {
                if (TargetEventDateTime > TempDateTimeOffset)
                {
                  TargetEventDateTime = TempDateTimeOffset;
                }
              }
              else
              {
                if (TargetEventDateTime < TempDateTimeOffset)
                {
                  TargetEventDateTime = TempDateTimeOffset;
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

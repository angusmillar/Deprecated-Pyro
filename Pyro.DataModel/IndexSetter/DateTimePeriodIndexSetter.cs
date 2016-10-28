using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.DataModel.DatabaseModel.Base;
using Pyro.DataModel.Repository;
using Hl7.Fhir.Model;
using Pyro.DataModel.Repository.Interfaces;

namespace Pyro.DataModel.IndexSetter
{
  public class DateTimePeriodIndexSetter : IDateTimePeriodIndexSetter
  {
    public ModelBase Set(Element FhirElement, ModelBase ModelBase, IDtoFhirRequestUri FhirRequestUri = null, ICommonRepository CommonRepository = null)
    {
      if (ModelBase == null)
      {
        throw new ArgumentNullException("ModelBase cannot be null for method.");
      }
      if (FhirElement == null)
      {
        throw new ArgumentNullException("FhirElement cannot be null for method.");
      }

      if (ModelBase is DateTimePeriodIndex)
      {
        var DateTimePeriodIndex = ModelBase as DateTimePeriodIndex;
        if (FhirElement is Period)
        {
          return SetPeriod(FhirElement as Period, DateTimePeriodIndex);
        }
        else if (FhirElement is Timing)
        {
          return SetTiming(FhirElement as Timing, DateTimePeriodIndex);
        }
        else if (FhirElement is FhirString)
        {
          return SetFhirString(FhirElement as FhirString, DateTimePeriodIndex);
        }
        else if (FhirElement is FhirDateTime)
        {
          return SetFhirDateTime(FhirElement as FhirDateTime, DateTimePeriodIndex);
        }
        else
        {
          throw new Exception(string.Format("FhirElement was unexpected type for QuantityRangeIndexSetter, type was {0}", FhirElement.ToString()));
        }
      }
      else
      {
        throw new InvalidCastException(string.Format("DateIndexSetter expected typeof {0} yet was passed typeof {1}", typeof(DateTimePeriodIndex).Name, ModelBase.GetType().Name));
      }
    }

    public DateTimePeriodIndex SetPeriod(Period Period, DateTimePeriodIndex DateTimePeriodIndex)
    {
      if (Period == null)
        throw new ArgumentNullException("Period cannot be null for method.");

      if (DateTimePeriodIndex == null)
        throw new ArgumentNullException("DateTimePeriodIndex cannot be null for method.");


      if (Period.StartElement != null)
      {
        if (FhirDateTime.IsValidValue(Period.Start))
        {
          Common.Tools.FhirDateTimeSupport oFhirDateTimeTool = new Common.Tools.FhirDateTimeSupport(Period.Start);
          if (oFhirDateTimeTool.IsValid)
          {
            DateTimePeriodIndex.DateTimeOffsetLow = oFhirDateTimeTool.Value.Value;
          }
          else
          {
            throw new FormatException(string.Format("The date & time given '{0}' could not be converted to a FHIR Date time.", Period.Start));
          }
        }
        else
        {
          throw new FormatException(string.Format("The date & time given '{0}' is not a valid FHIR date & time format.", Period.Start));
        }
      }
      else
      {
        DateTimePeriodIndex.DateTimeOffsetLow = null;
      }
      if (Period.EndElement != null)
      {
        if (FhirDateTime.IsValidValue(Period.End))
        {
          Common.Tools.FhirDateTimeSupport oFhirDateTimeTool = new Common.Tools.FhirDateTimeSupport(Period.End);
          if (oFhirDateTimeTool.IsValid)
          {
            DateTimePeriodIndex.DateTimeOffsetHigh = oFhirDateTimeTool.Value.Value;
          }
          else
          {
            throw new FormatException(string.Format("The date & time given '{0}' could not be converted to a FHIR Date time.", Period.Start));
          }
        }
        else
        {
          throw new FormatException(string.Format("The date & time given '{0}' is not a valid FHIR date & time format.", Period.End));
        }
      }
      else
      {
        DateTimePeriodIndex.DateTimeOffsetHigh = null;
      }
      if (DateTimePeriodIndex.DateTimeOffsetLow == null && DateTimePeriodIndex.DateTimeOffsetHigh == null)
      {
        return null;
      }
      return DateTimePeriodIndex;
    }

    public DateTimePeriodIndex SetTiming(Timing Timing, DateTimePeriodIndex DateTimePeriodIndex)
    {
      if (Timing == null)
        throw new ArgumentNullException("Timing cannot be null for method.");

      if (DateTimePeriodIndex == null)
        throw new ArgumentNullException("DateTimePeriodIndex cannot be null for method.");

      if (Timing.Event == null)
      {
        return null;
      }
      else
      {
        DateTimePeriodIndex.DateTimeOffsetLow = ResolveTargetEventDateTime(Timing, true);
        if (DateTimePeriodIndex.DateTimeOffsetLow == DateTimeOffset.MaxValue)
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
            DateTimePeriodIndex.DateTimeOffsetHigh = AddDurationTimeToEvent(ResolveTargetEventDateTime(Timing, false), TargetDuration, TargetUnitsOfTime);
            return DateTimePeriodIndex;
          }
          else
          {
            DateTimePeriodIndex.DateTimeOffsetHigh = null;
          }

          if (DateTimePeriodIndex.DateTimeOffsetLow == null && DateTimePeriodIndex.DateTimeOffsetHigh == null)
          {
            return null;
          }
          else
          {
            return DateTimePeriodIndex;
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
            Common.Tools.FhirDateTimeSupport oFhirDateTimeTool = new Common.Tools.FhirDateTimeSupport(EventDateTime.Value);
            if (oFhirDateTimeTool.IsValid)
            {
              if (TargetLowest)
              {
                if (TargetEventDateTime > oFhirDateTimeTool.Value.Value)
                {
                  TargetEventDateTime = oFhirDateTimeTool.Value.Value;
                }
              }
              else
              {
                if (TargetEventDateTime < oFhirDateTimeTool.Value.Value)
                {
                  TargetEventDateTime = oFhirDateTimeTool.Value.Value;
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

    public DateTimePeriodIndex SetFhirString(FhirString FhirString, DateTimePeriodIndex DateTimePeriodIndex)
    {
      if (FhirString == null)
        throw new ArgumentNullException("FhirString cannot be null for method.");

      if (DateTimePeriodIndex == null)
        throw new ArgumentNullException("DateTimePeriodIndex cannot be null for method.");

      if (!string.IsNullOrWhiteSpace(FhirString.Value))
      {
        //Can Parse a basic range like examples below:
        //2016-01-02T10:00:00+10:00 - 2016-01-02T10:00:00+10:00
        //2016-01-02T10:00:00+10:00 2016-01-02T10:00:00+10:00
        if (FhirString.Value.Trim().Contains(" ") || FhirString.Value.Trim().Contains(" - "))
        {
          string[] Spit = null;
          if (FhirString.Value.Trim().Contains(" - "))
          {
            Spit = FhirString.Value.Trim().Split(new string[] { " - " }, StringSplitOptions.None);            
          }
          else
          {
            Spit = FhirString.Value.Trim().Split(' ');
          }
          if (FhirDateTime.IsValidValue(Spit[0].Trim()) && FhirDateTime.IsValidValue(Spit[1].Trim()))
          {
            Common.Tools.FhirDateTimeSupport oFhirDateTimeToolLow = new Common.Tools.FhirDateTimeSupport(Spit[0].Trim());
            Common.Tools.FhirDateTimeSupport oFhirDateTimeToolHigh = new Common.Tools.FhirDateTimeSupport(Spit[1].Trim());
            if (oFhirDateTimeToolLow.IsValid && oFhirDateTimeToolHigh.IsValid)
            {
              DateTimePeriodIndex.DateTimeOffsetLow = oFhirDateTimeToolLow.Value.Value;
              DateTimePeriodIndex.DateTimeOffsetHigh = oFhirDateTimeToolHigh.Value.Value;
              return DateTimePeriodIndex;
            }
          }
          return null;
        }
        else if (FhirDateTime.IsValidValue(FhirString.Value.Trim()))
        {
          Common.Tools.FhirDateTimeSupport oFhirDateTimeTool = new Common.Tools.FhirDateTimeSupport(FhirString.Value.Trim());
          if (oFhirDateTimeTool.IsValid)
          {
            DateTimePeriodIndex.DateTimeOffsetLow = oFhirDateTimeTool.Value.Value;
            DateTimePeriodIndex.DateTimeOffsetHigh = oFhirDateTimeTool.Value.Value;
            return DateTimePeriodIndex;
          }
        }
      }
      return null;
    }

    public DateTimePeriodIndex SetFhirDateTime(FhirDateTime FhirDateTime, DateTimePeriodIndex DateTimePeriodIndex)
    {
      if (FhirDateTime == null)
        throw new ArgumentNullException("FhirDateTime cannot be null for method.");

      if (DateTimePeriodIndex == null)
        throw new ArgumentNullException("DateTimePeriodIndex cannot be null for method.");

      if (FhirDateTime.IsValidValue(FhirDateTime.Value))
      {
        Common.Tools.FhirDateTimeSupport oFhirDateTimeTool = new Common.Tools.FhirDateTimeSupport(FhirDateTime.Value.Trim());
        if (oFhirDateTimeTool.IsValid)
        {
          DateTimePeriodIndex.DateTimeOffsetLow = oFhirDateTimeTool.Value.Value;
          DateTimePeriodIndex.DateTimeOffsetHigh = oFhirDateTimeTool.Value.Value;
          return DateTimePeriodIndex;
        }
      }
      return null;
    }
  }
}

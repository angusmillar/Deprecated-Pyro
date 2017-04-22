using System;
using Pyro.DataLayer.DbModel.EntityBase;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Pyro.Common.BusinessEntities.Dto;
using System.Collections.Generic;

namespace Pyro.DataLayer.IndexSetter
{
  public static class DateTimeSetter<ResourceIndexType> where ResourceIndexType : ResourceIndexBase, new()
  {
    private static List<ResourceIndexType> ResourceIndexList;
    private static int ServiceSearchParameterId;

    public static IList<ResourceIndexType> Set(IElementNavigator oElement, DtoServiceSearchParameterLight SearchParameter)     
    {
      ResourceIndexList = new List<ResourceIndexType>();
      ServiceSearchParameterId = SearchParameter.Id;
      
      if (oElement is Hl7.Fhir.FhirPath.PocoNavigator Poco && Poco.FhirValue != null)
      {
        if (Poco.FhirValue is Date Date)
        {
          SetDate(Date);
        }
        else if (Poco.FhirValue is Period Period)
        {
          SetPeriod(Period);
        }
        else if (Poco.FhirValue is FhirDateTime FhirDateTime)
        {
          SetDateTime(FhirDateTime);
        }
        else if (Poco.FhirValue is FhirString FhirString)
        {
          SetString(FhirString);
        }
        else if (Poco.FhirValue is Instant Instant)
        {
          SetInstant(Instant);
        }
        else if (Poco.FhirValue is Timing Timing)
        {
          SetTiming(Timing);
        }        
        else
        {
          throw new FormatException($"Unkown FhirType: '{oElement.Type}' for SearchParameterType: '{SearchParameter.Type}'");
        }
        ResourceIndexList.ForEach(x => x.ServiceSearchParameterId = ServiceSearchParameterId);
        return ResourceIndexList;
      }      
      else
      {
        throw new FormatException($"Unkown FhirType: '{oElement.Type}' for SearchParameterType: '{SearchParameter.Type}'");
      }      
    }

    private static void SetTiming(Timing Timing)
    {
      if (Timing.Event != null)      
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndex.DateTimeOffsetLow = ResolveTargetEventDateTime(Timing, true);
        if (ResourceIndex.DateTimeOffsetLow != DateTimeOffset.MaxValue)
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
            ResourceIndex.DateTimeOffsetHigh = AddDurationTimeToEvent(ResolveTargetEventDateTime(Timing, false), TargetDuration, TargetUnitsOfTime);
            ResourceIndexList.Add(ResourceIndex);
          }
          else
          {
            ResourceIndex.DateTimeOffsetHigh = null;
          }

          if (ResourceIndex.DateTimeOffsetLow != null && ResourceIndex.DateTimeOffsetHigh != null)
          {
            ResourceIndexList.Add(ResourceIndex);
          }
        }
      }
    }
    private static void SetInstant(Instant Instant)     
    {
      if (Instant.Value.HasValue)
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndex.DateTimeOffsetLow = Instant.Value.Value;
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private static void SetString(FhirString FhirString)     
    {
      if (Hl7.Fhir.Model.Date.IsValidValue(FhirString.Value) || FhirDateTime.IsValidValue(FhirString.Value))
      {
        Common.Tools.FhirDateTimeSupport oFhirDateTimeTool = new Common.Tools.FhirDateTimeSupport(FhirString.Value);
        if (oFhirDateTimeTool.IsValid)
        {
          var ResourceIndex = new ResourceIndexType();
          ResourceIndex.DateTimeOffsetLow = oFhirDateTimeTool.Value.Value;
          ResourceIndexList.Add(ResourceIndex);
        }
      }      
    }
    private static void SetDateTime(FhirDateTime FhirDateTime)
    {
      if (FhirDateTime.IsValidValue(FhirDateTime.Value))
      {
        Common.Tools.FhirDateTimeSupport oFhirDateTimeTool = new Common.Tools.FhirDateTimeSupport(FhirDateTime.Value);
        if (oFhirDateTimeTool.IsValid)
        {
          var ResourceIndex = new ResourceIndexType();
          ResourceIndex.DateTimeOffsetLow = oFhirDateTimeTool.Value.Value;
          ResourceIndexList.Add(ResourceIndex);
        }
        else
        {
          throw new FormatException($"Unable to convert the given FhirDateTime '{FhirDateTime.Value}' to a valid datetime.");
        }
      }
      else
      {
        throw new FormatException($"The date & time given '{FhirDateTime.Value}' is not a valid FHIR date & time format.");
      }
    }
    private static void SetPeriod(Period Period)
    {
      var ResourceIndex = new ResourceIndexType();
      if (Period.StartElement != null)
      {
        if (FhirDateTime.IsValidValue(Period.Start))
        {
          Common.Tools.FhirDateTimeSupport oFhirDateTimeTool = new Common.Tools.FhirDateTimeSupport(Period.Start);
          if (oFhirDateTimeTool.IsValid)
          {
            ResourceIndex.DateTimeOffsetLow = oFhirDateTimeTool.Value.Value;
          }
          else
          {
            throw new FormatException($"The date & time given '{Period.Start}' could not be converted to a FHIR Date time.");
          }
        }
        else
        {
          throw new FormatException($"The date & time given '{Period.Start}' is not a valid FHIR date & time format.");
        }
      }
      else
      {
        ResourceIndex.DateTimeOffsetLow = null;
      }
      if (Period.EndElement != null)
      {
        if (FhirDateTime.IsValidValue(Period.End))
        {
          Common.Tools.FhirDateTimeSupport oFhirDateTimeTool = new Common.Tools.FhirDateTimeSupport(Period.End);
          if (oFhirDateTimeTool.IsValid)
          {
            ResourceIndex.DateTimeOffsetHigh = oFhirDateTimeTool.Value.Value;
          }
          else
          {
            throw new FormatException($"The date & time given '{Period.Start}' could not be converted to a FHIR Date time.");
          }
        }
        else
        {
          throw new FormatException($"The date & time given '{Period.End}' is not a valid FHIR date & time format.");
        }
      }
      else
      {
        ResourceIndex.DateTimeOffsetHigh = null;
      }
      if (ResourceIndex.DateTimeOffsetLow != null && ResourceIndex.DateTimeOffsetHigh != null)
      {
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private static void SetDate(Date Date)
    {
      if (Date.IsValidValue(Date.Value))
      {
        int? DateAsInteger = Pyro.Common.Tools.FhirTimeSupport.ConvertDateToInteger(Date);
        if (DateAsInteger.HasValue)
        {
          var ResourceIndex = new ResourceIndexType();
          ResourceIndex.Date = DateAsInteger.Value;
          ResourceIndexList.Add(ResourceIndex);
        }
        else
        {
          throw new FormatException(string.Format("Unable to convert the given date '{0}' to a valid date.", Date.Value));
        }
      }
      else
      {
        throw new FormatException(string.Format("The date given '{0}' is not a valid FHIR date format.", Date.Value));
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

  }

}

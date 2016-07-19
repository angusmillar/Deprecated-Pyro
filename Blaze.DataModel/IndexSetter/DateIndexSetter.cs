using System;
using Hl7.Fhir.Model;
using Blaze.DataModel.DatabaseModel.Base;

namespace Blaze.DataModel.IndexSetter
{
  public class DateIndexSetter : IDateIndexSetter
  {
    public ModelBase Set(Element FhirElement)
    {
      if (FhirElement is Date)
      {
        return SetDate(FhirElement as Date);
      }
      else if (FhirElement is FhirDateTime)
      {
        return SetFhirDateTime(FhirElement as FhirDateTime);
      }
      else if (FhirElement is FhirString)
      {
        return SetFhirString(FhirElement as FhirString);
      }
      else if (FhirElement is Instant)
      {
        return SetInstant(FhirElement as Instant);
      }
      else
      {
        throw new Exception(string.Format("FhirElement was unexpected type for QuantityRangeIndexSetter, type was {0}", FhirElement.ToString()));
      }
    }

    public DateIndex SetDate(Date Date)
    {
      //E.g: "1974-12-25"
      var Return = new DateIndex();
      DateTime TempDate = new DateTime();
      if (Date.IsValidValue(Date.Value))
      {
        if (DateTime.TryParse(Date.Value, out TempDate))
        {
          Return.DateTimeOffset = new DateTimeOffset(TempDate, new TimeSpan(0));
          return Return;
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

    public DateIndex SetFhirDateTime(FhirDateTime FhirDateTime)
    {
      var Return = new DateIndex();
      if (FhirDateTime.IsValidValue(FhirDateTime.Value))
      {
        Return.DateTimeOffset = FhirDateTime.ToDateTimeOffset();
        return Return;
      }
      else
      {
        throw new FormatException(string.Format("The date & time given '{0}' is not a valid FHIR date & time format.", FhirDateTime.Value));
      }
    }

    public DateIndex SetFhirString(FhirString FhirString)
    {
      var Return = new DateIndex();

      if (Date.IsValidValue(FhirString.Value))
      {
        var TempDateTime = new DateTime();
        if (DateTime.TryParse(FhirString.Value, out TempDateTime))
        {
          Return.DateTimeOffset = new DateTimeOffset(TempDateTime, new TimeSpan(0));
          return Return;
        }
        else
        {
          return null;
        }
      }
      if (FhirDateTime.IsValidValue(FhirString.Value))
      {
        var TempDateTimeOffset = new DateTimeOffset();
        if (DateTimeOffset.TryParse(FhirString.Value, out TempDateTimeOffset))
        {
          Return.DateTimeOffset = TempDateTimeOffset;
          return Return;
        }
        else
        {
          return null;
        }

      }
      else
      {
        return null;
      }
    }

    public DateIndex SetInstant(Instant Instant)
    {
      var Return = new DateIndex();
      if (Instant.Value != null)
      {
        Return.DateTimeOffset = (DateTimeOffset)Instant.Value;
        return Return;
      }
      else
      {
        return null;
      }
    }
  }
}

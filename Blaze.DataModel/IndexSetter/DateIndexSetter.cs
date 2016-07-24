using System;
using Hl7.Fhir.Model;
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.DataModel.Repository;
using Blaze.Common.Interfaces.UriSupport;

namespace Blaze.DataModel.IndexSetter
{
  public class DateIndexSetter : IDateIndexSetter
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

      if (ModelBase is DateIndex)
      {
        var DateIndex = ModelBase as DateIndex;
        if (FhirElement is Date)
        {
          return SetDate(FhirElement as Date, DateIndex);
        }
        else if (FhirElement is FhirDateTime)
        {
          return SetFhirDateTime(FhirElement as FhirDateTime, DateIndex);
        }
        else if (FhirElement is FhirString)
        {
          return SetFhirString(FhirElement as FhirString, DateIndex);
        }
        else if (FhirElement is Instant)
        {
          return SetInstant(FhirElement as Instant, DateIndex);
        }
        else
        {
          throw new Exception(string.Format("FhirElement was unexpected type for QuantityRangeIndexSetter, type was {0}", FhirElement.ToString()));
        }
      }
      else
      {
        throw new InvalidCastException(string.Format("DateIndexSetter expected typeof {0} yet was passed typeof {1}", typeof(DateIndex).Name, ModelBase.GetType().Name));
      }
    }

    public DateIndex SetDate(Date Date, DateIndex DateIndex)
    {
      if (Date == null)
        throw new ArgumentNullException("Date cannot be null for method.");

      if (DateIndex == null)
        throw new ArgumentNullException("DateIndex cannot be null for method.");

      //E.g: "1974-12-25"      
      DateTime TempDate = new DateTime();
      if (Date.IsValidValue(Date.Value))
      {
        if (DateTime.TryParse(Date.Value, out TempDate))
        {
          DateIndex.DateTimeOffset = new DateTimeOffset(TempDate, new TimeSpan(0));
          return DateIndex;
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

    public DateIndex SetFhirDateTime(FhirDateTime FhirDateTime, DateIndex DateIndex)
    {
      if (FhirDateTime == null)
        throw new ArgumentNullException("FhirDateTime cannot be null for method.");

      if (DateIndex == null)
        throw new ArgumentNullException("DateIndex cannot be null for method.");

      if (FhirDateTime.IsValidValue(FhirDateTime.Value))
      {
        DateIndex.DateTimeOffset = FhirDateTime.ToDateTimeOffset();
        return DateIndex;
      }
      else
      {
        throw new FormatException(string.Format("The date & time given '{0}' is not a valid FHIR date & time format.", FhirDateTime.Value));
      }
    }

    public DateIndex SetFhirString(FhirString FhirString, DateIndex DateIndex)
    {
      if (FhirString == null)
        throw new ArgumentNullException("FhirString cannot be null for method.");

      if (DateIndex == null)
        throw new ArgumentNullException("DateIndex cannot be null for method.");

      if (Date.IsValidValue(FhirString.Value))
      {
        var TempDateTime = new DateTime();
        if (DateTime.TryParse(FhirString.Value, out TempDateTime))
        {
          DateIndex.DateTimeOffset = new DateTimeOffset(TempDateTime, new TimeSpan(0));
          return DateIndex;
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
          DateIndex.DateTimeOffset = TempDateTimeOffset;
          return DateIndex;
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

    public DateIndex SetInstant(Instant Instant, DateIndex DateIndex)
    {
      if (Instant == null)
        throw new ArgumentNullException("Instant cannot be null for method.");

      if (DateIndex == null)
        throw new ArgumentNullException("DateIndex cannot be null for method.");

      if (Instant.Value != null)
      {
        DateIndex.DateTimeOffset = (DateTimeOffset)Instant.Value;
        return DateIndex;
      }
      else
      {
        return null;
      }
    }
  }
}

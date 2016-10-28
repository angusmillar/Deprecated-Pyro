using System;
using Hl7.Fhir.Model;
using Pyro.DataModel.DatabaseModel.Base;
using Pyro.DataModel.Repository;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.DataModel.Repository.Interfaces;

namespace Pyro.DataModel.IndexSetter
{
  public class DateTimeIndexSetter : IDateTimeIndexSetter
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

      if (ModelBase is DateTimeIndex)
      {
        var DateIndex = ModelBase as DateTimeIndex;
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
        throw new InvalidCastException(string.Format("DateIndexSetter expected typeof {0} yet was passed typeof {1}", typeof(DateTimeIndex).Name, ModelBase.GetType().Name));
      }
    }

    public DateTimeIndex SetDate(Date Date, DateTimeIndex DateIndex)
    {
      if (Date == null)
        throw new ArgumentNullException("Date cannot be null for method.");

      if (DateIndex == null)
        throw new ArgumentNullException("DateIndex cannot be null for method.");

      //e.g: "1974-12-25T08:30:15.123+10:00"            
      if (Date.IsValidValue(Date.Value))
      {
        Common.Tools.FhirDateTimeSupport oFhirDateTimeTool = new Common.Tools.FhirDateTimeSupport(Date.Value);         
        if (oFhirDateTimeTool.IsValid)
        {
          DateIndex.DateTimeOffset = oFhirDateTimeTool.Value.Value;
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

    public DateTimeIndex SetFhirDateTime(FhirDateTime FhirDateTime, DateTimeIndex DateIndex)
    {
      if (FhirDateTime == null)
        throw new ArgumentNullException("FhirDateTime cannot be null for method.");

      if (DateIndex == null)
        throw new ArgumentNullException("DateIndex cannot be null for method.");
      
      if (FhirDateTime.IsValidValue(FhirDateTime.Value))
      {
        Common.Tools.FhirDateTimeSupport oFhirDateTimeTool = new Common.Tools.FhirDateTimeSupport(FhirDateTime.Value);
        if (oFhirDateTimeTool.IsValid)
        {
          DateIndex.DateTimeOffset = oFhirDateTimeTool.Value.Value;
          return DateIndex;
        }
        else
        {
          throw new FormatException(string.Format("Unable to convert the given FhirDateTime '{0}' to a valid datetime.", FhirDateTime.Value));
        }
      }
      else
      {
        throw new FormatException(string.Format("The date & time given '{0}' is not a valid FHIR date & time format.", FhirDateTime.Value));
      }
    }

    public DateTimeIndex SetFhirString(FhirString FhirString, DateTimeIndex DateIndex)
    {
      if (FhirString == null)
        throw new ArgumentNullException("FhirString cannot be null for method.");

      if (DateIndex == null)
        throw new ArgumentNullException("DateIndex cannot be null for method.");

      if (Date.IsValidValue(FhirString.Value) || FhirDateTime.IsValidValue(FhirString.Value))
      {
        Common.Tools.FhirDateTimeSupport oFhirDateTimeTool = new Common.Tools.FhirDateTimeSupport(FhirString.Value);
        if (oFhirDateTimeTool.IsValid)
        {
          DateIndex.DateTimeOffset = oFhirDateTimeTool.Value.Value;
          return DateIndex;
        }
      }
      return null;
    }

    public DateTimeIndex SetInstant(Instant Instant, DateTimeIndex DateIndex)
    {
      if (Instant == null)
        throw new ArgumentNullException("Instant cannot be null for method.");

      if (DateIndex == null)
        throw new ArgumentNullException("DateIndex cannot be null for method.");

      if (Instant.Value.HasValue)
      {
        DateIndex.DateTimeOffset = Instant.Value.Value;
        return DateIndex;
      }
      else
      {
        return null;
      }
    }
  }
}

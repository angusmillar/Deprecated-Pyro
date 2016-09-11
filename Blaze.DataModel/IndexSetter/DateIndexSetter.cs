using System;
using Hl7.Fhir.Model;
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.DataModel.Repository;
using Blaze.Common.Interfaces.UriSupport;
using Blaze.DataModel.Repository.Interfaces;

namespace Blaze.DataModel.IndexSetter
{
  public class DateIndexSetter : IDateIndexSetter
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

      if (ModelBase is DateIndex)
      {
        var DateIndex = ModelBase as DateIndex;
        if (FhirElement is Date)
        {
          return SetDate(FhirElement as Date, DateIndex);
        }
        else
        {
          throw new Exception(string.Format("FhirElement was unexpected type for DateIndexSetter, type was {0}", FhirElement.ToString()));
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
      if (Date.IsValidValue(Date.Value))
      {
        int? DateAsInteger = Blaze.Common.Tools.FhirDateTimeSupport.ConvertDateToInteger(Date);
        if (DateAsInteger.HasValue)
        {
          DateIndex.Date = DateAsInteger.Value;
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

  }
}

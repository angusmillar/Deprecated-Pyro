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
      else
      {
        throw new Exception(string.Format("FhirElement was unexpected type for QuantityRangeIndexSetter, type was {0}", FhirElement.ToString()));
      }
    }

    public DateIndex SetDate(Date Date)
    {
      var Return = new DateIndex();
      throw new NotImplementedException();
    }

    public DateIndex SetFhirDateTime(FhirDateTime FhirDateTime)
    {
      var Return = new DateIndex();
      throw new NotImplementedException();
    }

    public DateIndex SetFhirString(FhirString FhirString)
    {
      throw new NotImplementedException();
    }

    public DateIndex SetInstant(Instant Instant)
    {
      throw new NotImplementedException();
    }
  }
}

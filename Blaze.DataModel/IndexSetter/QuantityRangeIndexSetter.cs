using System;
using Hl7.Fhir.Model;
using Blaze.DataModel.DatabaseModel.Base;

namespace Blaze.DataModel.IndexSetter
{
  public class QuantityRangeIndexSetter : IQuantityRangeIndexSetter
  {
    public ModelBase Set(Element FhirElement)
    {
      if (FhirElement is Range)
      {
        return SetRange(FhirElement as Range);
      }
      else
      {
        throw new Exception(string.Format("FhirElement was unexpected type for QuantityRangeIndexSetter, type was {0}", FhirElement.ToString()));
      }
    }

    public QuantityRangeIndex SetRange(Range Range)
    {
      var QuantityRangeIndex = new QuantityRangeIndex();
      if (Range.Low != null)
      {
        QuantityRangeIndex.ComparatorLow = Range.Low.Comparator;
        QuantityRangeIndex.CodeLow = Range.Low.Code;
        QuantityRangeIndex.SystemLow = Range.Low.System;
        QuantityRangeIndex.QuantityLow = (decimal)Range.Low.Value;
      }
      if (Range.High != null)
      {
        QuantityRangeIndex.ComparatorLow = Range.High.Comparator;
        QuantityRangeIndex.CodeLow = Range.High.Code;
        QuantityRangeIndex.SystemLow = Range.High.System;
        QuantityRangeIndex.QuantityLow = (decimal)Range.High.Value;
      }
      return QuantityRangeIndex;
    }
  }
}

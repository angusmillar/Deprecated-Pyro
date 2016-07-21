using System;
using Hl7.Fhir.Model;
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.DataModel.Repository;
using Blaze.Common.Interfaces.UriSupport;

namespace Blaze.DataModel.IndexSetter
{
  public class QuantityRangeIndexSetter : IQuantityRangeIndexSetter
  {
    public ModelBase Set(Element FhirElement, ModelBase ModelBase, IDtoFhirRequestUri FhirRequestUri = null, CommonRepository CommonRepository = null)
    {
      if (ModelBase is QuantityRangeIndex)
      {
        var QuantityRangeIndex = ModelBase as QuantityRangeIndex;

        if (FhirElement is Range)
        {
          return SetRange(FhirElement as Range, QuantityRangeIndex);
        }
        else
        {
          throw new Exception(string.Format("FhirElement was unexpected type for QuantityRangeIndexSetter, type was {0}", FhirElement.ToString()));
        }
      }
      else
      {
        throw new InvalidCastException(string.Format("DateIndexSetter expected typeof {0} yet was passed typeof {1}", typeof(QuantityRangeIndex).Name, ModelBase.GetType().Name));
      }
    }

    public QuantityRangeIndex SetRange(Range Range, QuantityRangeIndex QuantityRangeIndex)
    {
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

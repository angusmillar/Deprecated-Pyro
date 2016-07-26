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
      if (ModelBase == null)
        throw new ArgumentNullException("ModelBase cannot be null for method.");

      if (FhirElement == null)
        throw new ArgumentNullException("FhirElement cannot be null for method.");

      if (ModelBase is QuantityRangeIndex)
      {
        var QuantityRangeIndex = ModelBase as QuantityRangeIndex;
        if (FhirElement is Range)
        {
          return SetRange(FhirElement as Range, QuantityRangeIndex);
        }
        else
        {
          throw new Exception(string.Format("FhirElement was unexpected type for QuantityRangeIndex, type was {0}", FhirElement.ToString()));
        }
      }
      else
      {
        throw new InvalidCastException(string.Format("QuantityRangeIndex expected typeof {0} yet was passed typeof {1}", typeof(QuantityRangeIndex).Name, ModelBase.GetType().Name));
      }
    }

    public QuantityRangeIndex SetRange(Range Range, QuantityRangeIndex QuantityRangeIndex)
    {
      if (Range == null)
        throw new ArgumentNullException("Range cannot be null for method.");

      if (QuantityRangeIndex == null)
        throw new ArgumentNullException("QuantityRangeIndex cannot be null for method.");

      //If either value is missing then their is no range as the Range data type uses SimpleQuantity 
      //which has no Comparator property. Therefore there is no such thing as >10 or <100, their must be to values
      // for examples 10 - 100. 
      if (!Range.High.Value.HasValue || !Range.Low.Value.HasValue)
      {
        return null;
      }
      else
      {        
        QuantityRangeIndex.ComparatorLow = Range.Low.Comparator;
        QuantityRangeIndex.CodeLow = Range.Low.Code;
        QuantityRangeIndex.SystemLow = Range.Low.System;
        QuantityRangeIndex.QuantityLow = Range.Low.Value.Value;
        
        QuantityRangeIndex.ComparatorHigh = Range.High.Comparator;
        QuantityRangeIndex.CodeHigh = Range.High.Code;
        QuantityRangeIndex.SystemHigh = Range.High.System;
        QuantityRangeIndex.QuantityHigh = Range.High.Value.Value;
        
        return QuantityRangeIndex;
      }
      

    }
  }
}

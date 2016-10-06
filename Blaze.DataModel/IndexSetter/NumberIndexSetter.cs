using System;
using Hl7.Fhir.Model;
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.DataModel.Repository;
using Blaze.Common.Interfaces.UriSupport;
using Blaze.DataModel.Repository.Interfaces;

namespace Blaze.DataModel.IndexSetter
{
  public class NumberIndexSetter : INumberIndexSetter
  {
    public ModelBase Set(Element FhirElement, ModelBase ModelBase, IDtoFhirRequestUri FhirRequestUri = null, ICommonRepository CommonRepository = null)
    {
      if (ModelBase == null)
        throw new ArgumentNullException("ModelBase cannot be null for method.");

      if (FhirElement == null)
        throw new ArgumentNullException("FhirElement cannot be null for method.");


      if (ModelBase is NumberIndex)
      {
        var DatePeriodIndex = ModelBase as NumberIndex;
        if (FhirElement is Duration)
        {
          return SetDuration(FhirElement as Duration, DatePeriodIndex);
        }
        else if (FhirElement is Integer)
        {
          return SetInteger(FhirElement as Integer, DatePeriodIndex);
        }
        else if (FhirElement is PositiveInt)
        {
          return SetPositiveInt(FhirElement as PositiveInt, DatePeriodIndex);
        }
        else
        {
          throw new Exception(string.Format("FhirElement was unexpected type for NumberIndexSetter, type was {0}", FhirElement.ToString()));
        }
      }
      else
      {
        throw new InvalidCastException(string.Format("NumberIndexSetter expected typeof {0} yet was passed typeof {1}", typeof(NumberIndex).Name, ModelBase.GetType().Name));
      }
    }

    public NumberIndex SetDuration(Duration Duration, NumberIndex NumberIndex)
    {
      if (Duration == null)
        throw new ArgumentNullException("Duration cannot be null for method.");

      if (NumberIndex == null)
        throw new ArgumentNullException("NumberIndex cannot be null for method.");

      if (Duration.Value.HasValue)
      {
        NumberIndex.Quantity = (decimal)Duration.Value;
        if (Duration.Comparator.HasValue)
        {
          NumberIndex.Comparator = Duration.Comparator.Value;
        }
        else
        {
          NumberIndex.Comparator = null;
        }
        return NumberIndex;
      }
      else
      {
        return null;
      }
    }

    public NumberIndex SetInteger(Integer Integer, NumberIndex NumberIndex)
    {
      if (Integer == null)
        throw new ArgumentNullException("Integer cannot be null for method.");

      if (NumberIndex == null)
        throw new ArgumentNullException("NumberIndex cannot be null for method.");

      if (Integer.Value.HasValue)
      {
        NumberIndex.Quantity = Convert.ToInt32(Integer.Value);
        NumberIndex.Comparator = null;
        return NumberIndex;
      }
      else
      {
        return null;
      }
    }

    public NumberIndex SetPositiveInt(PositiveInt PositiveInt, NumberIndex NumberIndex)
    {
      if (PositiveInt == null)
        throw new ArgumentNullException("PositiveInt cannot be null for method.");

      if (NumberIndex == null)
        throw new ArgumentNullException("NumberIndex cannot be null for method.");

      if (PositiveInt.Value.HasValue)
      {
        if (PositiveInt.Value < 0)
          throw new FormatException(string.Format("PositiveInt must be a positive value, value was : {0}", PositiveInt.Value.ToString()));
        NumberIndex.Quantity = Convert.ToInt32(PositiveInt.Value);
        NumberIndex.Comparator = null;
        return NumberIndex;
      }
      else
      {
        return null;
      }
    }

  }
}

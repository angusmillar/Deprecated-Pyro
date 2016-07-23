using System;
using Hl7.Fhir.Model;
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.DataModel.Repository;
using Blaze.Common.Interfaces.UriSupport;

namespace Blaze.DataModel.IndexSetter
{
  public class NumberIndexSetter : INumberIndexSetter
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
      if (Duration.Value.HasValue)
      {
        NumberIndex.Number = (decimal)Duration.Value;
        if (Duration.Comparator.HasValue)
        {
          //ToDo: Need to add Comparator to NumberIndex 
          //NumberIndex.Comparator = Duration.Comparator.Value;
          throw new NotImplementedException();
        }
        else
        {
          //NumberIndex.Comparator = null; 
          throw new NotImplementedException();
        }
      }
      else
      {
        return null;
      }
    }

    public NumberIndex SetInteger(Integer Integer, NumberIndex NumberIndex)
    {
      throw new NotImplementedException();
    }

    public NumberIndex SetPositiveInt(PositiveInt PositiveInt, NumberIndex NumberIndex)
    {
      throw new NotImplementedException();
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.Common.Interfaces.UriSupport;
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.DataModel.Repository;
using Hl7.Fhir.Model;

namespace Blaze.DataModel.IndexSetter
{
  public class DatePeriodIndexSetter : IDatePeriodIndexSetter
  {
    public ModelBase Set(Element FhirElement, ModelBase ModelBase, IDtoFhirRequestUri FhirRequestUri = null, CommonRepository CommonRepository = null)
    {
      if (ModelBase is DatePeriodIndex)
      {
        var DatePeriodIndex = ModelBase as DatePeriodIndex;
        if (FhirElement is Period)
        {
          return SetPeriod(FhirElement as Period, DatePeriodIndex);
        }
        else if (FhirElement is Timing)
        {
          return SetTiming(FhirElement as Timing, DatePeriodIndex);
        }       
        else
        {
          throw new Exception(string.Format("FhirElement was unexpected type for QuantityRangeIndexSetter, type was {0}", FhirElement.ToString()));
        }
      }
      else
      {
        throw new InvalidCastException(string.Format("DateIndexSetter expected typeof {0} yet was passed typeof {1}", typeof(DatePeriodIndex).Name, ModelBase.GetType().Name));
      }
    }

    public DatePeriodIndex SetPeriod(Period Period, DatePeriodIndex DatePeriodIndex)
    {
      throw new NotImplementedException();
    }

    public DatePeriodIndex SetTiming(Timing Timing, DatePeriodIndex DatePeriodIndex)
    {
      throw new NotImplementedException();
    }
  }
}

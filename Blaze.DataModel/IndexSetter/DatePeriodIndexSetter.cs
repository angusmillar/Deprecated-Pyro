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
      throw new NotImplementedException();
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

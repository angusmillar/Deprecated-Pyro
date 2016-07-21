using Hl7.Fhir.Model;
using Blaze.DataModel.DatabaseModel.Base;

namespace Blaze.DataModel.IndexSetter
{
  public interface IDatePeriodIndexSetter : IIndexSetter
  {
        DatePeriodIndex SetPeriod(Period Period, DatePeriodIndex DatePeriodIndex);
        DatePeriodIndex SetTiming(Timing Timing, DatePeriodIndex DatePeriodIndex);
      
  }
}


using Hl7.Fhir.Model;
using Blaze.DataModel.DatabaseModel.Base;

namespace Blaze.DataModel.IndexSetter
{
  public interface IDateTimePeriodIndexSetter : IIndexSetter
  {
    DateTimePeriodIndex SetPeriod(Period Period, DateTimePeriodIndex DateTimePeriodIndex);
    DateTimePeriodIndex SetTiming(Timing Timing, DateTimePeriodIndex DateTimePeriodIndex);
      
  }
}


using Hl7.Fhir.Model;
using Blaze.DataModel.DatabaseModel.Base;

namespace Blaze.DataModel.IndexSetter
{
  public interface IDatePeriodIndexSetter : IIndexSetter
  {
    	  DateIndex SetPeriod(Period Period);
	  	  DateIndex SetTiming(Timing Timing);
	    
  }
}


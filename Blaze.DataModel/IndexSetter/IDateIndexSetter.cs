using Hl7.Fhir.Model;
using Blaze.DataModel.DatabaseModel.Base;

namespace Blaze.DataModel.IndexSetter
{
  public interface IDateIndexSetter : IIndexSetter
  {
    	  DateIndex SetFhirDateTime(FhirDateTime FhirDateTime);
	  	  DateIndex SetInstant(Instant Instant);
	  	  DateIndex SetDate(Date Date);
	  	  DateIndex SetFhirString(FhirString FhirString);
	    
  }
}


using Hl7.Fhir.Model;
using Blaze.DataModel.DatabaseModel.Base;

namespace Blaze.DataModel.IndexSetter
{
  public interface INumberIndexSetter : IIndexSetter
  {
    	  NumberIndex SetDuration(Duration Duration);
	  	  NumberIndex SetPositiveInt(PositiveInt PositiveInt);
	  	  NumberIndex SetInteger(Integer Integer);
	    
  }
}


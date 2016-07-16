using Hl7.Fhir.Model;
using Blaze.DataModel.DatabaseModel.Base;

namespace Blaze.DataModel.IndexSetter
{
  public interface IQuantityIndexSetter : IIndexSetter
  {
    	  QuantityIndex SetMoney(Money Money);
	  	  QuantityIndex SetQuantity(Quantity Quantity);
	  	  QuantityIndex SetSimpleQuantity(SimpleQuantity SimpleQuantity);
	    
  }
}


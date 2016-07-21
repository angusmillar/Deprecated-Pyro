using Hl7.Fhir.Model;
using Blaze.DataModel.DatabaseModel.Base;

namespace Blaze.DataModel.IndexSetter
{
  public interface IQuantityIndexSetter : IIndexSetter
  {
        QuantityIndex SetMoney(Money Money, QuantityIndex QuantityIndex);
        QuantityIndex SetQuantity(Quantity Quantity, QuantityIndex QuantityIndex);
        QuantityIndex SetSimpleQuantity(SimpleQuantity SimpleQuantity, QuantityIndex QuantityIndex);
      
  }
}


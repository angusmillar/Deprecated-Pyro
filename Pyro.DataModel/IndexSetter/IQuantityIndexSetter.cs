using Hl7.Fhir.Model;
using Pyro.DataModel.DatabaseModel.Base;

namespace Pyro.DataModel.IndexSetter
{
  public interface IQuantityIndexSetter : IIndexSetter
  {
    QuantityIndex SetMoney(Money Money, QuantityIndex QuantityIndex);
    //QuantityIndex SetPositionComponent(PositionComponent PositionComponent, QuantityIndex QuantityIndex);
    QuantityIndex SetQuantity(Quantity Quantity, QuantityIndex QuantityIndex);
    QuantityIndex SetSimpleQuantity(SimpleQuantity SimpleQuantity, QuantityIndex QuantityIndex);
      
  }
}


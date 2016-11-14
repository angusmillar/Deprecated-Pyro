using Hl7.Fhir.Model;
using Pyro.DataModel.DatabaseModel.Base;

namespace Pyro.DataModel.IndexSetter
{
  public interface IQuantityIndexSetter : IIndexSetter
  {
    QuantityIndex SetMoney(Money Money, QuantityIndex QuantityIndex);
    QuantityIndex SetPositionComponent(Hl7.Fhir.Model.Location.PositionComponent PositionComponent, QuantityIndex QuantityIndex);
    QuantityIndex SetQuantity(Quantity Quantity, QuantityIndex QuantityIndex);
    QuantityIndex SetSimpleQuantity(SimpleQuantity SimpleQuantity, QuantityIndex QuantityIndex);
      
  }
}


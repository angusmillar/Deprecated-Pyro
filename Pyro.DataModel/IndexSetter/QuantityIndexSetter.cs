using System;
using Hl7.Fhir.Model;
using Pyro.DataModel.DatabaseModel.Base;
using Pyro.DataModel.Repository;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.DataModel.Repository.Interfaces;

namespace Pyro.DataModel.IndexSetter
{
  public class QuantityIndexSetter : IQuantityIndexSetter
  {
    public ModelBase Set(Element FhirElement, ModelBase ModelBase, IDtoFhirRequestUri FhirRequestUri = null, ICommonRepository CommonRepository = null)
    {
      if (ModelBase == null)
        throw new ArgumentNullException("ModelBase cannot be null for method.");

      if (FhirElement == null)
        throw new ArgumentNullException("FhirElement cannot be null for method.");

      if (ModelBase is QuantityIndex)
      {
        var QuantityIndex = ModelBase as QuantityIndex;
        if (FhirElement is Money)
        {
          return SetMoney(FhirElement as Money, QuantityIndex);
        }
        else if (FhirElement is SimpleQuantity)
        {
          return SetSimpleQuantity(FhirElement as SimpleQuantity, QuantityIndex);
        }
        else if (FhirElement is Quantity)
        {
          return SetQuantity(FhirElement as Quantity, QuantityIndex);
        }
        else
        {
          throw new Exception(string.Format("FhirElement was unexpected type for QuantityIndexSetter, type was {0}", FhirElement.ToString()));
        }
      }
      else
      {
        throw new InvalidCastException(string.Format("QuantityIndexSetter expected typeof {0} yet was passed typeof {1}", typeof(QuantityIndexSetter).Name, ModelBase.GetType().Name));
      }

    }

    public QuantityIndex SetMoney(Money Money, QuantityIndex QuantityIndex)
    {
      if (Money == null)
        throw new ArgumentNullException("Money cannot be null for method.");

      if (QuantityIndex == null)
        throw new ArgumentNullException("QuantityIndex cannot be null for method.");

      if (Money.Value.HasValue)
      {
        QuantityIndex.Quantity = Money.Value.Value;
        if (!string.IsNullOrWhiteSpace(Money.Code))
        {
          QuantityIndex.Code = Money.Code;
        }
        else
        {
          QuantityIndex.Code = null;
        }
        if (!string.IsNullOrWhiteSpace(Money.System))
        {
          QuantityIndex.System = Money.System;
        }
        else
        {
          QuantityIndex.System = null;
        }
        if (Money.Comparator.HasValue)
        {
          QuantityIndex.Comparator = Money.Comparator.Value;
        }
        else
        {
          QuantityIndex.Comparator = null;
        }
        if (!string.IsNullOrWhiteSpace(Money.Unit))
        {
          QuantityIndex.Unit = Money.Unit;
        }
        else
        {
          QuantityIndex.Unit = null;
        }


        return QuantityIndex;
      }
      else
      {
        return null;
      }
    }

    public QuantityIndex SetQuantity(Quantity Quantity, QuantityIndex QuantityIndex)
    {
      if (Quantity == null)
        throw new ArgumentNullException("Quantity cannot be null for method.");

      if (QuantityIndex == null)
        throw new ArgumentNullException("QuantityIndex cannot be null for method.");

      if (Quantity.Value.HasValue)
      {
        QuantityIndex.Quantity = Quantity.Value.Value;
        if (!string.IsNullOrWhiteSpace(Quantity.Code))
        {
          QuantityIndex.Code = Quantity.Code;
        }
        else
        {
          QuantityIndex.Code = null;
        }
        if (!string.IsNullOrWhiteSpace(Quantity.System))
        {
          QuantityIndex.System = Quantity.System;
        }
        else
        {
          QuantityIndex.System = null;
        }
        if (Quantity.Comparator.HasValue)
        {
          QuantityIndex.Comparator = Quantity.Comparator.Value;
        }
        else
        {
          QuantityIndex.Comparator = null;
        }
        if (!string.IsNullOrWhiteSpace(Quantity.Unit))
        {
          QuantityIndex.Unit = Quantity.Unit;
        }
        else
        {
          QuantityIndex.Unit = null;
        }

        return QuantityIndex;
      }
      else
      {
        return null;
      }
    }

    public QuantityIndex SetSimpleQuantity(SimpleQuantity SimpleQuantity, QuantityIndex QuantityIndex)
    {
      if (SimpleQuantity == null)
        throw new ArgumentNullException("Quantity cannot be null for method.");

      if (QuantityIndex == null)
        throw new ArgumentNullException("QuantityIndex cannot be null for method.");

      if (SimpleQuantity.Value.HasValue)
      {
        QuantityIndex.Quantity = SimpleQuantity.Value.Value;
        if (!string.IsNullOrWhiteSpace(SimpleQuantity.Code))
        {
          QuantityIndex.Code = SimpleQuantity.Code;
        }
        else
        {
          QuantityIndex.Code = null;
        }
        if (!string.IsNullOrWhiteSpace(SimpleQuantity.System))
        {
          QuantityIndex.System = SimpleQuantity.System;
        }
        else
        {
          QuantityIndex.System = null;
        }
        //Note: Simple Quantity should not have a Comparator but the FHIR API allows it so will record in on is found.
        if (SimpleQuantity.Comparator.HasValue)
        {
          QuantityIndex.Comparator = SimpleQuantity.Comparator.Value;
        }
        else
        {
          QuantityIndex.Comparator = null;
        }
        if (!string.IsNullOrWhiteSpace(SimpleQuantity.Unit))
        {
          QuantityIndex.Unit = SimpleQuantity.Unit;
        }
        else
        {
          QuantityIndex.Unit = null;
        }
        return QuantityIndex;
      }
      else
      {
        return null;
      }
    }
  }
}

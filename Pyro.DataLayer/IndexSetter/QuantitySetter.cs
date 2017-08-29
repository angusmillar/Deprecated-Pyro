using System;
using Pyro.DataLayer.DbModel.EntityBase;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Pyro.Common.Search;
using System.Collections.Generic;

namespace Pyro.DataLayer.IndexSetter
{
  public class QuantitySetter : IQuantitySetter
  {
    public QuantitySetter() { }

    public IList<ResourceIndexBaseType> Set<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(IElementNavigator oElement, ServiceSearchParameterLight SearchParameter)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      var ResourceIndexList = new List<ResourceIndexBaseType>();
      var ServiceSearchParameterId = SearchParameter.Id;

      if (oElement is Hl7.Fhir.FhirPath.PocoNavigator Poco && Poco.FhirValue != null)
      {
        if (Poco.FhirValue is Money Money)
        {
          SetMoney<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Money, ResourceIndexList);
        }
        else if (Poco.FhirValue is SimpleQuantity SimpleQuantity)
        {
          SetSimpleQuantity<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(SimpleQuantity, ResourceIndexList);
        }
        else if (Poco.FhirValue is Quantity Quantity)
        {
          SetQuantity<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Quantity, ResourceIndexList);
        }
        else if (Poco.FhirValue is Location.PositionComponent PositionComponent)
        {
          SetPositionComponent<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(PositionComponent, ResourceIndexList);
        }
        else if (Poco.FhirValue is Range Range)
        {
          SetRange<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Range, ResourceIndexList);
        }
        else
        {
          throw new FormatException($"Unknown FhirType: '{oElement.Type}' for SearchParameterType: '{SearchParameter.Type}'");
        }
        ResourceIndexList.ForEach(x => x.ServiceSearchParameterId = ServiceSearchParameterId);
        return ResourceIndexList;
      }
      else
      {
        throw new FormatException($"Unknown Navigator FhirType: '{oElement.Type}' for SearchParameterType: '{SearchParameter.Type}'");
      }
    }

    private void SetRange<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Range Range, List<ResourceIndexBaseType> ResourceIndexList)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      //If either value is missing then their is no range as the Range data type uses SimpleQuantity 
      //which has no Comparator property. Therefore there is no such thing as >10 or <100, their must be to values
      // for examples 10 - 100. 
      if (Range.High.Value.HasValue && Range.Low.Value.HasValue)
      {
        var ResourceIndex = new ResourceIndexBaseType();
        ResourceIndex.Comparator = Range.Low.Comparator;
        ResourceIndex.Code = Range.Low.Code;
        ResourceIndex.System = Range.Low.System;
        ResourceIndex.Quantity = Range.Low.Value.Value;
        ResourceIndex.Unit = Range.Low.Unit;

        ResourceIndex.ComparatorHigh = Range.High.Comparator;
        ResourceIndex.CodeHigh = Range.High.Code;
        ResourceIndex.SystemHigh = Range.High.System;
        ResourceIndex.QuantityHigh = Range.High.Value.Value;
        ResourceIndex.UnitHigh = Range.High.Unit;

        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetPositionComponent<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Location.PositionComponent PositionComponent, List<ResourceIndexBaseType> ResourceIndexList)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      //The only Quantity for Location.PositionComponent is in the Location resource and it's use if a little odd.
      //You never actual store a 'near-distance' search parameter as an index but rather it is used in conjunction with the 
      //'near' search parameter. 
      //for instance the search would be like this:
      //GET [base]/Location?near=-83.694810:42.256500&near-distance=11.20||km...
      //Where we need to work out the distance say in km between 'near' [latitude]:[longitude] we have stored in the db index and the [latitude]:[longitude] given in the search url's 'near'.
      //If that distance is less then or equal to the  'near-distance' given in the search Url (11.20km here) then return the resource.     
    }
    private void SetQuantity<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Quantity Quantity, List<ResourceIndexBaseType> ResourceIndexList)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      if (Quantity.Value.HasValue)
      {
        var ResourceIndex = new ResourceIndexBaseType();
        ResourceIndex.Quantity = Quantity.Value.Value;
        if (!string.IsNullOrWhiteSpace(Quantity.Code))
        {
          ResourceIndex.Code = Quantity.Code;
        }
        else
        {
          ResourceIndex.Code = null;
        }
        if (!string.IsNullOrWhiteSpace(Quantity.System))
        {
          ResourceIndex.System = Quantity.System;
        }
        else
        {
          ResourceIndex.System = null;
        }
        if (Quantity.Comparator.HasValue)
        {
          ResourceIndex.Comparator = Quantity.Comparator.Value;
        }
        else
        {
          ResourceIndex.Comparator = null;
        }
        if (!string.IsNullOrWhiteSpace(Quantity.Unit))
        {
          ResourceIndex.Unit = Quantity.Unit;
        }
        else
        {
          ResourceIndex.Unit = null;
        }
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetSimpleQuantity<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(SimpleQuantity SimpleQuantity, List<ResourceIndexBaseType> ResourceIndexList)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      if (SimpleQuantity.Value.HasValue)
      {
        var ResourceIndex = new ResourceIndexBaseType();
        ResourceIndex.Quantity = SimpleQuantity.Value.Value;
        if (!string.IsNullOrWhiteSpace(SimpleQuantity.Code))
        {
          ResourceIndex.Code = SimpleQuantity.Code;
        }
        else
        {
          ResourceIndex.Code = null;
        }
        if (!string.IsNullOrWhiteSpace(SimpleQuantity.System))
        {
          ResourceIndex.System = SimpleQuantity.System;
        }
        else
        {
          ResourceIndex.System = null;
        }
        //Note: Simple Quantity should not have a Comparator but the FHIR API allows it so will record in on is found.
        if (SimpleQuantity.Comparator.HasValue)
        {
          ResourceIndex.Comparator = SimpleQuantity.Comparator.Value;
        }
        else
        {
          ResourceIndex.Comparator = null;
        }
        if (!string.IsNullOrWhiteSpace(SimpleQuantity.Unit))
        {
          ResourceIndex.Unit = SimpleQuantity.Unit;
        }
        else
        {
          ResourceIndex.Unit = null;
        }
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetMoney<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Money Money, List<ResourceIndexBaseType> ResourceIndexList)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      if (Money.Value.HasValue)
      {
        var ResourceIndex = new ResourceIndexBaseType();
        ResourceIndex.Quantity = Money.Value.Value;
        if (!string.IsNullOrWhiteSpace(Money.Code))
        {
          ResourceIndex.Code = Money.Code;
        }
        else
        {
          ResourceIndex.Code = null;
        }
        if (!string.IsNullOrWhiteSpace(Money.System))
        {
          ResourceIndex.System = Money.System;
        }
        else
        {
          ResourceIndex.System = null;
        }
        if (Money.Comparator.HasValue)
        {
          ResourceIndex.Comparator = Money.Comparator.Value;
        }
        else
        {
          ResourceIndex.Comparator = null;
        }
        if (!string.IsNullOrWhiteSpace(Money.Unit))
        {
          ResourceIndex.Unit = Money.Unit;
        }
        else
        {
          ResourceIndex.Unit = null;
        }
        ResourceIndexList.Add(ResourceIndex);
      }
    }

  }
}

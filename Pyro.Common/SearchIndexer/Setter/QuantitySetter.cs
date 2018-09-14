using System;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Pyro.Common.Search;
using System.Collections.Generic;
using Pyro.Common.SearchIndexer.Index;
using Hl7.Fhir.Utility;

namespace Pyro.Common.SearchIndexer.Setter
{
  public class QuantitySetter : IQuantitySetter
  {
    private IServiceSearchParameterLight _SearchParameter;

    public QuantitySetter() { }

    public IList<IQuantityIndex> Set(IElementNavigator oElement, DtoServiceSearchParameterLight SearchParameter)
    {
      _SearchParameter = SearchParameter;

      var ResourceIndexList = new List<IQuantityIndex>();
      var ServiceSearchParameterId = SearchParameter.Id;

      if (oElement is Hl7.Fhir.ElementModel.PocoNavigator Poco && Poco.FhirValue != null)
      {
        if (Poco.FhirValue is Money Money)
        {
          SetMoney(Money, ResourceIndexList);
        }
        else if (Poco.FhirValue is SimpleQuantity SimpleQuantity)
        {
          SetSimpleQuantity(SimpleQuantity, ResourceIndexList);
        }
        else if (Poco.FhirValue is Quantity Quantity)
        {
          SetQuantity(Quantity, ResourceIndexList);
        }
        else if (Poco.FhirValue is Location.PositionComponent PositionComponent)
        {
          SetPositionComponent(PositionComponent, ResourceIndexList);
        }
        else if (Poco.FhirValue is Range Range)
        {
          SetRange(Range, ResourceIndexList);
        }
        else
        {
          throw new FormatException($"Unknown FhirType: '{oElement.Type}' for SearchParameterType: '{SearchParameter.Type}'");
        }        
        return ResourceIndexList;
      }
      else
      {
        throw new FormatException($"Unknown Navigator FhirType: '{oElement.Type}' for SearchParameterType: '{SearchParameter.Type}'");
      }
    }

    private void SetRange(Range Range, IList<IQuantityIndex> ResourceIndexList)
    {
      //If either value is missing then their is no range as the Range data type uses SimpleQuantity 
      //which has no Comparator property. Therefore there is no such thing as >10 or <100, their must be to values
      // for examples 10 - 100. 
      if (Range.High.Value.HasValue && Range.Low.Value.HasValue)
      {
        var ResourceIndex = new QuantityIndex(_SearchParameter);
        //Set the low end of range
        MainQuantitySetter(Range.Low, ResourceIndex);

        //Set the High end of range Manually        
        ResourceIndex.QuantityHigh = Range.High.Value;
        ResourceIndex.CodeHigh = string.IsNullOrWhiteSpace(Range.High.Code) ? null : Range.High.Code;
        ResourceIndex.SystemHigh = string.IsNullOrWhiteSpace(Range.High.System) ? null : Range.High.System;
        ResourceIndex.ComparatorHigh = Range.High.Comparator;
        ResourceIndex.UnitHigh = string.IsNullOrWhiteSpace(Range.High.Unit) ? null : Range.High.Unit;

        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetPositionComponent(Location.PositionComponent PositionComponent, IList<IQuantityIndex> ResourceIndexList)
    {
      //The only Quantity for Location.PositionComponent is in the Location resource and it's use is a little odd.
      //You never actual store a 'near-distance' search parameter as an index but rather it is used in conjunction with the 
      //'near' search parameter. 
      //for instance the search would be like this:
      //GET [base]/Location?near=-83.694810:42.256500&near-distance=11.20||km...
      //Where we need to work out the distance say in km between 'near' [latitude]:[longitude] we have stored in the db index and the [latitude]:[longitude] given in the search url's 'near'.
      //If that distance is less then or equal to the  'near-distance' given in the search Url (11.20km here) then return the resource.   
      //Update: Talked to Brian Pos and I can see I do need to store this as it's own index. SQL has a geography datatype which needs to be used
      //See ref: https://docs.microsoft.com/en-us/sql/t-sql/spatial-geography/spatial-types-geography
      // I also have some of Brians code as an example in NOTES, search for 'Brian's FHIR position longitude latitude code' in FHIR notebook
      //I think this will have to be a special case, maybe not a noraml Pyro FHIR token index but another, or maybe add it to the Token index yet it will be null 99% of time. 
      //More thinking required. At present the server never indexes this so the search never finds it. Not greate!
    }
    private void SetQuantity(Quantity Quantity, IList<IQuantityIndex> ResourceIndexList)
    {
      var ResourceIndex = new QuantityIndex(_SearchParameter);
      MainQuantitySetter(Quantity, ResourceIndex);
      ResourceIndexList.Add(ResourceIndex);
    }
    private void SetSimpleQuantity(SimpleQuantity SimpleQuantity, IList<IQuantityIndex> ResourceIndexList)
    {
      var ResourceIndex = new QuantityIndex(_SearchParameter);
      MainQuantitySetter(SimpleQuantity, ResourceIndex);
      ResourceIndexList.Add(ResourceIndex);
    }

    private void SetMoney(Money Money, IList<IQuantityIndex> ResourceIndexList)
    {      
      var ResourceIndex = new QuantityIndex(_SearchParameter);
      ResourceIndex.Quantity = Money.Value;
      if (Money.Currency.HasValue)
      {
        ResourceIndex.Code = Money.Currency.Value.GetLiteral();
        ResourceIndex.System = "urn:iso:std:iso:4217";
      }           
      ResourceIndexList.Add(ResourceIndex);
    }

    private void MainQuantitySetter(Quantity Quantity, IQuantityIndex ResourceIndex)
    {
      ResourceIndex.Quantity = Quantity.Value;
      ResourceIndex.Code = string.IsNullOrWhiteSpace(Quantity.Code) ? null : Quantity.Code;
      ResourceIndex.System = string.IsNullOrWhiteSpace(Quantity.System) ? null : Quantity.System;
      ResourceIndex.Comparator = Quantity.Comparator;
      ResourceIndex.Unit = string.IsNullOrWhiteSpace(Quantity.Unit) ? null : Quantity.Unit;
    }

  }
}

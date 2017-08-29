using System;
using Pyro.DataLayer.DbModel.EntityBase;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Pyro.Common.Search;
using System.Collections.Generic;
using System.Linq;

namespace Pyro.DataLayer.IndexSetter
{
  public class NumberSetter : INumberSetter
  {
    public NumberSetter() { }

    public IList<ResourceIndexBaseType> Set<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(IElementNavigator oElement, ServiceSearchParameterLight SearchParameter)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      var ResourceIndexList = new List<ResourceIndexBaseType>();
      int ServiceSearchParameterId = SearchParameter.Id;

      if (oElement is Hl7.Fhir.FhirPath.PocoNavigator Poco && Poco.FhirValue != null)
      {
        if (Poco.FhirValue is Integer Integer)
        {
          SetInteger<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Integer, ResourceIndexList);
        }
        else if (Poco.FhirValue is PositiveInt PositiveInt)
        {
          SetPositiveInt<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(PositiveInt, ResourceIndexList);
        }
        else if (Poco.FhirValue is Duration Duration)
        {
          SetDuration<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Duration, ResourceIndexList);
        }
        else if (Poco.FhirValue is FhirDecimal FhirDecimal)
        {
          SetFhirDecimal<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(FhirDecimal, ResourceIndexList);
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

    private static void SetFhirDecimal<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(FhirDecimal FhirDecimal, List<ResourceIndexBaseType> ResourceIndexList)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      if (FhirDecimal.Value.HasValue)
      {
        var ResourceIndex = new ResourceIndexBaseType();
        ResourceIndex.Quantity = FhirDecimal.Value;
        ResourceIndexList.Add(ResourceIndex);
      }
    }

    private static void SetRange<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Range Range, List<ResourceIndexBaseType> ResourceIndexList)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      if (Range.Low != null)
      {
        if (Range.Low.Value.HasValue)
        {
          var ResourceIndex = new ResourceIndexBaseType();
          ResourceIndex.Quantity = Range.Low.Value;
          ResourceIndex.Comparator = Quantity.QuantityComparator.GreaterOrEqual;
          ResourceIndexList.Add(ResourceIndex);
        }
      }
      if (Range.High != null)
      {
        if (Range.High.Value.HasValue)
        {
          var ResourceIndex = new ResourceIndexBaseType();
          ResourceIndex.Quantity = Range.High.Value;
          ResourceIndex.Comparator = Quantity.QuantityComparator.LessOrEqual;
          ResourceIndexList.Add(ResourceIndex);
        }
      }
    }

    private static void SetDuration<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Duration Duration, List<ResourceIndexBaseType> ResourceIndexList)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      if (Duration.Value.HasValue)
      {
        var ResourceIndex = new ResourceIndexBaseType();
        ResourceIndex.Quantity = (decimal)Duration.Value;
        if (Duration.Comparator.HasValue)
        {
          ResourceIndex.Comparator = Duration.Comparator.Value;
        }
        else
        {
          ResourceIndex.Comparator = null;
        }
        ResourceIndexList.Add(ResourceIndex);
      }
    }

    private static void SetPositiveInt<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(PositiveInt PositiveInt, List<ResourceIndexBaseType> ResourceIndexList)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      if (PositiveInt.Value.HasValue)
      {
        if (PositiveInt.Value < 0)
          throw new FormatException(string.Format("PositiveInt must be a positive value, value was : {0}", PositiveInt.Value.ToString()));

        var ResourceIndex = new ResourceIndexBaseType();
        ResourceIndex.Quantity = Convert.ToInt32(PositiveInt.Value);
        ResourceIndex.Comparator = null;
        ResourceIndexList.Add(ResourceIndex);
      }
    }

    private static void SetInteger<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Integer Integer, List<ResourceIndexBaseType> ResourceIndexList)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      if (Integer.Value.HasValue)
      {
        var ResourceIndex = new ResourceIndexBaseType();
        ResourceIndexList.Add(ResourceIndex);
        ResourceIndex.Quantity = Convert.ToInt32(Integer.Value);
        ResourceIndex.Comparator = null;
        ResourceIndexList.Add(ResourceIndex);
      }
    }
  }
}

using System;
using Pyro.DataLayer.DbModel.EntityBase;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Pyro.Common.Search;
using System.Collections.Generic;
using System.Linq;

namespace Pyro.DataLayer.IndexSetter
{
  public class NumberSetter<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType> :
    INumberSetter<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
    where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
  {
    public NumberSetter() { }

    public IList<ResourceIndexBaseType> Set(IElementNavigator oElement, ServiceSearchParameterLight SearchParameter)
    {
      var ResourceIndexList = new List<ResourceIndexBaseType>();
      int ServiceSearchParameterId = SearchParameter.Id;

      if (oElement is Hl7.Fhir.FhirPath.PocoNavigator Poco && Poco.FhirValue != null)
      {
        if (Poco.FhirValue is Integer Integer)
        {
          SetInteger(Integer, ResourceIndexList);
        }
        else if (Poco.FhirValue is PositiveInt PositiveInt)
        {
          SetPositiveInt(PositiveInt, ResourceIndexList);
        }
        else if (Poco.FhirValue is Duration Duration)
        {
          SetDuration(Duration, ResourceIndexList);
        }
        else if (Poco.FhirValue is FhirDecimal FhirDecimal)
        {
          SetFhirDecimal(FhirDecimal, ResourceIndexList);
        }
        else if (Poco.FhirValue is Range Range)
        {
          SetRange(Range, ResourceIndexList);
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

    private static void SetFhirDecimal(FhirDecimal FhirDecimal, List<ResourceIndexBaseType> ResourceIndexList)
    {
      if (FhirDecimal.Value.HasValue)
      {
        var ResourceIndex = new ResourceIndexBaseType();
        ResourceIndex.Quantity = FhirDecimal.Value;
        ResourceIndexList.Add(ResourceIndex);
      }
    }

    private static void SetRange(Range Range, List<ResourceIndexBaseType> ResourceIndexList)
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

    private static void SetDuration(Duration Duration, List<ResourceIndexBaseType> ResourceIndexList)
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

    private static void SetPositiveInt(PositiveInt PositiveInt, List<ResourceIndexBaseType> ResourceIndexList)
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

    private static void SetInteger(Integer Integer, List<ResourceIndexBaseType> ResourceIndexList)
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

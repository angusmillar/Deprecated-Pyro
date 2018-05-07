using System;
using Pyro.DataLayer.DbModel.EntityBase;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Pyro.Common.Search;
using System.Collections.Generic;
using System.Linq;

namespace Pyro.DataLayer.IndexSetter
{
  public class NumberSetter<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType> :
    INumberSetter<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>

  {
    public NumberSetter() { }

    public IList<ResIndexQuantityType> Set(IElementNavigator oElement, DtoServiceSearchParameterLight SearchParameter)
    {
      var ResourceIndexList = new List<ResIndexQuantityType>();
      int ServiceSearchParameterId = SearchParameter.Id;

      if (oElement is Hl7.Fhir.ElementModel.PocoNavigator Poco && Poco.FhirValue != null)
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

    private static void SetFhirDecimal(FhirDecimal FhirDecimal, List<ResIndexQuantityType> ResourceIndexList)
    {
      if (FhirDecimal.Value.HasValue)
      {
        var ResourceIndex = new ResIndexQuantityType();
        ResourceIndex.Quantity = FhirDecimal.Value;
        ResourceIndex.Comparator = null;
        ResourceIndexList.Add(ResourceIndex);
      }
    }

    private static void SetRange(Range Range, List<ResIndexQuantityType> ResourceIndexList)
    {
      if (Range.Low != null)
      {
        if (Range.Low.Value.HasValue)
        {
          var ResourceIndex = new ResIndexQuantityType();
          ResourceIndex.Quantity = Range.Low.Value;
          ResourceIndex.Comparator = Quantity.QuantityComparator.GreaterOrEqual;
          ResourceIndexList.Add(ResourceIndex);
        }
      }
      if (Range.High != null)
      {
        if (Range.High.Value.HasValue)
        {
          var ResourceIndex = new ResIndexQuantityType();
          ResourceIndex.Quantity = Range.High.Value;
          ResourceIndex.Comparator = Quantity.QuantityComparator.LessOrEqual;
          ResourceIndexList.Add(ResourceIndex);
        }
      }
    }

    private static void SetDuration(Duration Duration, List<ResIndexQuantityType> ResourceIndexList)
    {
      if (Duration.Value.HasValue)
      {
        var ResourceIndex = new ResIndexQuantityType();
        ResourceIndex.Quantity = (decimal)Duration.Value;
        ResourceIndex.Comparator = Duration.Comparator;
        ResourceIndexList.Add(ResourceIndex);
      }
    }

    private static void SetPositiveInt(PositiveInt PositiveInt, List<ResIndexQuantityType> ResourceIndexList)
    {
      if (PositiveInt.Value.HasValue)
      {
        if (PositiveInt.Value < 0)
          throw new FormatException(string.Format("PositiveInt must be a positive value, value was : {0}", PositiveInt.Value.ToString()));

        var ResourceIndex = new ResIndexQuantityType();
        ResourceIndex.Quantity = Convert.ToInt32(PositiveInt.Value);
        ResourceIndex.Comparator = null;
        ResourceIndexList.Add(ResourceIndex);
      }
    }

    private static void SetInteger(Integer Integer, List<ResIndexQuantityType> ResourceIndexList)
    {
      if (Integer.Value.HasValue)
      {
        var ResourceIndex = new ResIndexQuantityType();
        ResourceIndexList.Add(ResourceIndex);
        ResourceIndex.Quantity = Convert.ToInt32(Integer.Value);
        ResourceIndex.Comparator = null;
        ResourceIndexList.Add(ResourceIndex);
      }
    }
  }
}

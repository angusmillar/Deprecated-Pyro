using System;
using Pyro.DataLayer.DbModel.EntityBase;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Pyro.Common.BusinessEntities.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Pyro.DataLayer.IndexSetter
{
  public class NumberSetter : INumberSetter
  {
    public NumberSetter() { }

    public IList<ResourceIndexType> Set<ResourceCurrentType, ResourceIndexType>(IElementNavigator oElement, DtoServiceSearchParameterLight SearchParameter)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
    {
      var ResourceIndexList = new List<ResourceIndexType>();
      int ServiceSearchParameterId = SearchParameter.Id;

      if (oElement is Hl7.Fhir.FhirPath.PocoNavigator Poco && Poco.FhirValue != null)
      {
        if (Poco.FhirValue is Integer Integer)
        {
          SetInteger<ResourceCurrentType, ResourceIndexType>(Integer, ResourceIndexList);
        }
        else if (Poco.FhirValue is PositiveInt PositiveInt)
        {
          SetPositiveInt<ResourceCurrentType, ResourceIndexType>(PositiveInt, ResourceIndexList);
        }
        else if (Poco.FhirValue is Duration Duration)
        {
          SetDuration<ResourceCurrentType, ResourceIndexType>(Duration, ResourceIndexList);
        }
        else if (Poco.FhirValue is FhirDecimal FhirDecimal)
        {
          SetFhirDecimal<ResourceCurrentType, ResourceIndexType>(FhirDecimal, ResourceIndexList);
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
        throw new FormatException($"Unknown FhirType: '{oElement.Type}' for SearchParameterType: '{SearchParameter.Type}'");
      }
    }

    private static void SetFhirDecimal<ResourceCurrentType, ResourceIndexType>(FhirDecimal FhirDecimal, List<ResourceIndexType> ResourceIndexList)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
    {
      if (FhirDecimal.Value.HasValue)
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndex.Quantity = FhirDecimal.Value;
        ResourceIndexList.Add(ResourceIndex);
      }
    }

    private static void SetDuration<ResourceCurrentType, ResourceIndexType>(Duration Duration, List<ResourceIndexType> ResourceIndexList)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
    {
      if (Duration.Value.HasValue)
      {
        var ResourceIndex = new ResourceIndexType();
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

    private static void SetPositiveInt<ResourceCurrentType, ResourceIndexType>(PositiveInt PositiveInt, List<ResourceIndexType> ResourceIndexList)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
    {
      if (PositiveInt.Value.HasValue)
      {
        if (PositiveInt.Value < 0)
          throw new FormatException(string.Format("PositiveInt must be a positive value, value was : {0}", PositiveInt.Value.ToString()));

        var ResourceIndex = new ResourceIndexType();
        ResourceIndex.Quantity = Convert.ToInt32(PositiveInt.Value);
        ResourceIndex.Comparator = null;
        ResourceIndexList.Add(ResourceIndex);
      }
    }

    private static void SetInteger<ResourceCurrentType, ResourceIndexType>(Integer Integer, List<ResourceIndexType> ResourceIndexList)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
    {
      if (Integer.Value.HasValue)
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndexList.Add(ResourceIndex);
        ResourceIndex.Quantity = Convert.ToInt32(Integer.Value);
        ResourceIndex.Comparator = null;
        ResourceIndexList.Add(ResourceIndex);
      }
    }
  }
}

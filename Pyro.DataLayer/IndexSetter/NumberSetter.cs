using System;
using Pyro.DataLayer.DbModel.EntityBase;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Pyro.Common.BusinessEntities.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Pyro.DataLayer.IndexSetter
{
  public static class NumberSetter<ResourceIndexType> where ResourceIndexType : ResourceIndexBase, new()
  {
    private static List<ResourceIndexType> ResourceIndexList;
    private static int ServiceSearchParameterId;

    public static IList<ResourceIndexType> Set(IElementNavigator oElement, DtoServiceSearchParameterLight SearchParameter)      
    {
      ResourceIndexList = new List<ResourceIndexType>();      
      ServiceSearchParameterId = SearchParameter.Id;

      if (oElement is Hl7.Fhir.FhirPath.PocoNavigator Poco && Poco.FhirValue != null)
      {        
        if (Poco.FhirValue is Integer Integer)
        {
          SetInteger(Integer);
        }
        else if (Poco.FhirValue is PositiveInt PositiveInt)
        {
          SetPositiveInt(PositiveInt);
        }
        else if (Poco.FhirValue is Duration Duration)
        {
          SetDuration(Duration);
        }
        else if (Poco.FhirValue is FhirDecimal FhirDecimal)
        {
          SetFhirDecimal(FhirDecimal);
        }
        else
        {
          throw new FormatException($"Unkown FhirType: '{oElement.Type}' for SearchParameterType: '{SearchParameter.Type}'");
        }
        ResourceIndexList.ForEach(x => x.ServiceSearchParameterId = ServiceSearchParameterId);
        return ResourceIndexList;
      }      
      else
      {
        throw new FormatException($"Unkown FhirType: '{oElement.Type}' for SearchParameterType: '{SearchParameter.Type}'");
      }
    }

    private static void SetFhirDecimal(FhirDecimal FhirDecimal)
    {
      if (FhirDecimal.Value.HasValue)
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndex.Quantity = FhirDecimal.Value;        
        ResourceIndexList.Add(ResourceIndex);
      }
    }

    private static void SetDuration(Duration Duration)     
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

    private static void SetPositiveInt(PositiveInt PositiveInt) 
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

    private static void SetInteger(Integer Integer) 
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

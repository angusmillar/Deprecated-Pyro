using System;
using Pyro.DataLayer.DbModel.EntityBase;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Pyro.Common.BusinessEntities.Dto;
using System.Collections.Generic;

namespace Pyro.DataLayer.IndexSetter
{
  public static class DateTimeSetter<ResourceIndexType> where ResourceIndexType : ResourceIndexBase, new()
  {
    private static List<ResourceIndexType> ResourceIndexList;
    private static int ServiceSearchParameterId;

    public static IList<ResourceIndexType> Set(IElementNavigator oElement, DtoServiceSearchParameterLight SearchParameter)     
    {
      ResourceIndexList = new List<ResourceIndexType>();
      ServiceSearchParameterId = SearchParameter.Id;
      
      if (oElement is Hl7.Fhir.FhirPath.PocoNavigator Poco && Poco.FhirValue != null)
      {
        if (Poco.FhirValue is Date Date)
        {
          SetDate(Date);
        }
        else if (Poco.FhirValue is Period Period)
        {
          SetPeriod(Period);
        }
        else if (Poco.FhirValue is FhirDateTime FhirDateTime)
        {
          SetDateTime(FhirDateTime);
        }
        else if (Poco.FhirValue is FhirString FhirString)
        {
          SetString(FhirString);
        }
        else if (Poco.FhirValue is Instant Instant)
        {
          SetInstant(Instant);
        }
        else if (Poco.FhirValue is Timing Timing)
        {
          SetTiming(Timing);
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

    private static void SetTiming(Timing Timing)
    {
      var ResourceIndex = new ResourceIndexType();
      Common.Tools.DateTimeIndex DateTimeIndex = Common.Tools.DateTimeSupport.GetDateTimeIndex(Timing);     
      if (DateTimeIndex.Low != null || DateTimeIndex.High != null)
      {
        ResourceIndex.DateTimeOffsetLow = DateTimeIndex.Low;
        ResourceIndex.DateTimeOffsetHigh = DateTimeIndex.High;
        ResourceIndexList.Add(ResourceIndex);
      }      
    }
    private static void SetInstant(Instant Instant)     
    {
      if (Instant.Value.HasValue)
      {
        var ResourceIndex = new ResourceIndexType();
        Common.Tools.DateTimeIndex DateTimeIndex = Common.Tools.DateTimeSupport.GetDateTimeIndex(Instant);       
        if (DateTimeIndex.Low != null || DateTimeIndex.High != null)
        {
          ResourceIndex.DateTimeOffsetLow = DateTimeIndex.Low;
          ResourceIndex.DateTimeOffsetHigh = DateTimeIndex.High;
          ResourceIndexList.Add(ResourceIndex);
        }
      }
    }
    private static void SetString(FhirString FhirString)     
    {
      if (Hl7.Fhir.Model.Date.IsValidValue(FhirString.Value) || FhirDateTime.IsValidValue(FhirString.Value))
      {
        Common.Tools.FhirDateTimeSupport oFhirDateTimeTool = new Common.Tools.FhirDateTimeSupport(FhirString.Value);
        if (oFhirDateTimeTool.IsValid)
        {
          var ResourceIndex = new ResourceIndexType();
          ResourceIndex.DateTimeOffsetLow = oFhirDateTimeTool.Value.Value;
          ResourceIndexList.Add(ResourceIndex);
        }
      }      
    }
    private static void SetDateTime(FhirDateTime FhirDateTime)
    {
      if (FhirDateTime.IsValidValue(FhirDateTime.Value))
      {
        var ResourceIndex = new ResourceIndexType();
        Common.Tools.DateTimeIndex DateTimeIndex = Common.Tools.DateTimeSupport.GetDateTimeIndex(FhirDateTime);
        if (DateTimeIndex.Low != null || DateTimeIndex.High != null)
        {
          ResourceIndex.DateTimeOffsetLow = DateTimeIndex.Low;
          ResourceIndex.DateTimeOffsetHigh = DateTimeIndex.High;
          ResourceIndexList.Add(ResourceIndex);
        }
      }      
    }
    private static void SetPeriod(Period Period)
    {
      var ResourceIndex = new ResourceIndexType();
      Common.Tools.DateTimeIndex DateTimeIndex = Common.Tools.DateTimeSupport.GetDateTimeIndex(Period);
      if (DateTimeIndex.Low != null || DateTimeIndex.High != null)
      {
        ResourceIndex.DateTimeOffsetLow = DateTimeIndex.Low;
        ResourceIndex.DateTimeOffsetHigh = DateTimeIndex.High;
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private static void SetDate(Date Date)
    {
      if (Date.IsValidValue(Date.Value))
      {
        var ResourceIndex = new ResourceIndexType();
        Common.Tools.DateTimeIndex DateTimeIndex = Common.Tools.DateTimeSupport.GetDateTimeIndex(Date);
        if (DateTimeIndex.Low != null || DateTimeIndex.High != null)
        {
          ResourceIndex.DateTimeOffsetLow = DateTimeIndex.Low;
          ResourceIndex.DateTimeOffsetHigh = DateTimeIndex.High;
          ResourceIndexList.Add(ResourceIndex);
        }
      }      
    }

  }

}

using System;
using Pyro.DataLayer.DbModel.EntityBase;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Pyro.Common.Search;
using System.Collections.Generic;

namespace Pyro.DataLayer.IndexSetter
{
  public class DateTimeSetter : IDateTimeSetter
  {
    public DateTimeSetter() { }
    public IList<ResourceIndexBaseType> Set<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(IElementNavigator oElement, ServiceSearchParameterLight SearchParameter)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      var ResourceIndexList = new List<ResourceIndexBaseType>();
      int ServiceSearchParameterId = SearchParameter.Id;

      if (oElement is Hl7.Fhir.FhirPath.PocoNavigator Poco && Poco.FhirValue != null)
      {
        if (Poco.FhirValue is Date Date)
        {
          SetDate<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Date, ResourceIndexList);
        }
        else if (Poco.FhirValue is Period Period)
        {
          SetPeriod<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Period, ResourceIndexList);
        }
        else if (Poco.FhirValue is FhirDateTime FhirDateTime)
        {
          SetDateTime<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(FhirDateTime, ResourceIndexList);
        }
        else if (Poco.FhirValue is FhirString FhirString)
        {
          SetString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(FhirString, ResourceIndexList);
        }
        else if (Poco.FhirValue is Instant Instant)
        {
          SetInstant<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Instant, ResourceIndexList);
        }
        else if (Poco.FhirValue is Timing Timing)
        {
          SetTiming<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Timing, ResourceIndexList);
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

    private void SetTiming<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Timing Timing, List<ResourceIndexBaseType> ResourceIndexList)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      var ResourceIndex = new ResourceIndexBaseType();
      Common.Tools.DateTimeIndex DateTimeIndex = Common.Tools.DateTimeSupport.GetDateTimeIndex(Timing);
      if (DateTimeIndex.Low != null || DateTimeIndex.High != null)
      {
        ResourceIndex.DateTimeOffsetLow = DateTimeIndex.Low;
        ResourceIndex.DateTimeOffsetHigh = DateTimeIndex.High;
        ResourceIndexList.Add(ResourceIndex);
      }
    }

    private void SetInstant<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Instant Instant, List<ResourceIndexBaseType> ResourceIndexList)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      if (Instant.Value.HasValue)
      {
        var ResourceIndex = new ResourceIndexBaseType();
        Common.Tools.DateTimeIndex DateTimeIndex = Common.Tools.DateTimeSupport.GetDateTimeIndex(Instant);
        if (DateTimeIndex.Low != null || DateTimeIndex.High != null)
        {
          ResourceIndex.DateTimeOffsetLow = DateTimeIndex.Low;
          ResourceIndex.DateTimeOffsetHigh = DateTimeIndex.High;
          ResourceIndexList.Add(ResourceIndex);
        }
      }
    }
    private void SetString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(FhirString FhirString, List<ResourceIndexBaseType> ResourceIndexList)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      if (Hl7.Fhir.Model.Date.IsValidValue(FhirString.Value) || FhirDateTime.IsValidValue(FhirString.Value))
      {
        Common.Tools.FhirDateTimeSupport oFhirDateTimeTool = new Common.Tools.FhirDateTimeSupport(FhirString.Value);
        if (oFhirDateTimeTool.IsValid)
        {
          var ResourceIndex = new ResourceIndexBaseType();
          ResourceIndex.DateTimeOffsetLow = oFhirDateTimeTool.Value.Value;
          ResourceIndexList.Add(ResourceIndex);
        }
      }
    }
    private void SetDateTime<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(FhirDateTime FhirDateTime, List<ResourceIndexBaseType> ResourceIndexList)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      if (FhirDateTime.IsValidValue(FhirDateTime.Value))
      {
        var ResourceIndex = new ResourceIndexBaseType();
        Common.Tools.DateTimeIndex DateTimeIndex = Common.Tools.DateTimeSupport.GetDateTimeIndex(FhirDateTime);
        if (DateTimeIndex.Low != null || DateTimeIndex.High != null)
        {
          ResourceIndex.DateTimeOffsetLow = DateTimeIndex.Low;
          ResourceIndex.DateTimeOffsetHigh = DateTimeIndex.High;
          ResourceIndexList.Add(ResourceIndex);
        }
      }
    }
    private void SetPeriod<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Period Period, List<ResourceIndexBaseType> ResourceIndexList)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      var ResourceIndex = new ResourceIndexBaseType();
      Common.Tools.DateTimeIndex DateTimeIndex = Common.Tools.DateTimeSupport.GetDateTimeIndex(Period);
      if (DateTimeIndex.Low != null || DateTimeIndex.High != null)
      {
        ResourceIndex.DateTimeOffsetLow = DateTimeIndex.Low;
        ResourceIndex.DateTimeOffsetHigh = DateTimeIndex.High;
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetDate<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Date Date, List<ResourceIndexBaseType> ResourceIndexList)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      if (Date.IsValidValue(Date.Value))
      {
        var ResourceIndex = new ResourceIndexBaseType();
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

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
    public IList<ResourceIndexType> Set<ResourceCurrentType, ResourceIndexType>(IElementNavigator oElement, ServiceSearchParameterLight SearchParameter)
    where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
    where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
    {
      var ResourceIndexList = new List<ResourceIndexType>();
      int ServiceSearchParameterId = SearchParameter.Id;

      if (oElement is Hl7.Fhir.FhirPath.PocoNavigator Poco && Poco.FhirValue != null)
      {
        if (Poco.FhirValue is Date Date)
        {
          SetDate<ResourceCurrentType, ResourceIndexType>(Date, ResourceIndexList);
        }
        else if (Poco.FhirValue is Period Period)
        {
          SetPeriod<ResourceCurrentType, ResourceIndexType>(Period, ResourceIndexList);
        }
        else if (Poco.FhirValue is FhirDateTime FhirDateTime)
        {
          SetDateTime<ResourceCurrentType, ResourceIndexType>(FhirDateTime, ResourceIndexList);
        }
        else if (Poco.FhirValue is FhirString FhirString)
        {
          SetString<ResourceCurrentType, ResourceIndexType>(FhirString, ResourceIndexList);
        }
        else if (Poco.FhirValue is Instant Instant)
        {
          SetInstant<ResourceCurrentType, ResourceIndexType>(Instant, ResourceIndexList);
        }
        else if (Poco.FhirValue is Timing Timing)
        {
          SetTiming<ResourceCurrentType, ResourceIndexType>(Timing, ResourceIndexList);
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

    private void SetTiming<ResourceCurrentType, ResourceIndexType>(Timing Timing, List<ResourceIndexType> ResourceIndexList)
    where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
    where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
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
    private void SetInstant<ResourceCurrentType, ResourceIndexType>(Instant Instant, List<ResourceIndexType> ResourceIndexList)
    where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
    where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
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
    private void SetString<ResourceCurrentType, ResourceIndexType>(FhirString FhirString, List<ResourceIndexType> ResourceIndexList)
    where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
    where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
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
    private void SetDateTime<ResourceCurrentType, ResourceIndexType>(FhirDateTime FhirDateTime, List<ResourceIndexType> ResourceIndexList)
    where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
    where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
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
    private void SetPeriod<ResourceCurrentType, ResourceIndexType>(Period Period, List<ResourceIndexType> ResourceIndexList)
    where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
    where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
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
    private void SetDate<ResourceCurrentType, ResourceIndexType>(Date Date, List<ResourceIndexType> ResourceIndexList)
    where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
    where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
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

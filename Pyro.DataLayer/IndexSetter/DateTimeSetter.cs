using System;
using Pyro.DataLayer.DbModel.EntityBase;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Pyro.Common.Search;
using System.Collections.Generic;

namespace Pyro.DataLayer.IndexSetter
{
  public class DateTimeSetter<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType> :
    IDateTimeSetter<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    
  {
    public DateTimeSetter() { }
    public IList<ResIndexDateTimeType> Set(IElementNavigator oElement, ServiceSearchParameterLight SearchParameter)
    {
      var ResourceIndexList = new List<ResIndexDateTimeType>();
      int ServiceSearchParameterId = SearchParameter.Id;

      if (oElement is Hl7.Fhir.FhirPath.PocoNavigator Poco && Poco.FhirValue != null)
      {
        if (Poco.FhirValue is Date Date)
        {
          SetDate(Date, ResourceIndexList);
        }
        else if (Poco.FhirValue is Period Period)
        {
          SetPeriod(Period, ResourceIndexList);
        }
        else if (Poco.FhirValue is FhirDateTime FhirDateTime)
        {
          SetDateTime(FhirDateTime, ResourceIndexList);
        }
        else if (Poco.FhirValue is FhirString FhirString)
        {
          SetString(FhirString, ResourceIndexList);
        }
        else if (Poco.FhirValue is Instant Instant)
        {
          SetInstant(Instant, ResourceIndexList);
        }
        else if (Poco.FhirValue is Timing Timing)
        {
          SetTiming(Timing, ResourceIndexList);
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

    private void SetTiming(Timing Timing, List<ResIndexDateTimeType> ResourceIndexList)
    {
      var ResourceIndex = new ResIndexDateTimeType();
      Common.Tools.DateTimeIndex DateTimeIndex = Common.Tools.DateTimeSupport.GetDateTimeIndex(Timing);
      if (DateTimeIndex.Low != null || DateTimeIndex.High != null)
      {
        ResourceIndex.DateTimeOffsetLow = DateTimeIndex.Low;
        ResourceIndex.DateTimeOffsetHigh = DateTimeIndex.High;
        ResourceIndexList.Add(ResourceIndex);
      }
    }

    private void SetInstant(Instant Instant, List<ResIndexDateTimeType> ResourceIndexList)
    {
      if (Instant.Value.HasValue)
      {
        var ResourceIndex = new ResIndexDateTimeType();
        Common.Tools.DateTimeIndex DateTimeIndex = Common.Tools.DateTimeSupport.GetDateTimeIndex(Instant);
        if (DateTimeIndex.Low != null || DateTimeIndex.High != null)
        {
          ResourceIndex.DateTimeOffsetLow = DateTimeIndex.Low;
          ResourceIndex.DateTimeOffsetHigh = DateTimeIndex.High;
          ResourceIndexList.Add(ResourceIndex);
        }
      }
    }
    private void SetString(FhirString FhirString, List<ResIndexDateTimeType> ResourceIndexList)
    {
      if (Hl7.Fhir.Model.Date.IsValidValue(FhirString.Value) || FhirDateTime.IsValidValue(FhirString.Value))
      {
        Common.Tools.FhirDateTimeSupport oFhirDateTimeTool = new Common.Tools.FhirDateTimeSupport(FhirString.Value);
        if (oFhirDateTimeTool.IsValid)
        {
          var ResourceIndex = new ResIndexDateTimeType();
          ResourceIndex.DateTimeOffsetLow = oFhirDateTimeTool.Value.Value;
          ResourceIndexList.Add(ResourceIndex);
        }
      }
    }
    private void SetDateTime(FhirDateTime FhirDateTime, List<ResIndexDateTimeType> ResourceIndexList)
    {
      if (FhirDateTime.IsValidValue(FhirDateTime.Value))
      {
        var ResourceIndex = new ResIndexDateTimeType();
        Common.Tools.DateTimeIndex DateTimeIndex = Common.Tools.DateTimeSupport.GetDateTimeIndex(FhirDateTime);
        if (DateTimeIndex.Low != null || DateTimeIndex.High != null)
        {
          ResourceIndex.DateTimeOffsetLow = DateTimeIndex.Low;
          ResourceIndex.DateTimeOffsetHigh = DateTimeIndex.High;
          ResourceIndexList.Add(ResourceIndex);
        }
      }
    }
    private void SetPeriod(Period Period, List<ResIndexDateTimeType> ResourceIndexList)
    {
      var ResourceIndex = new ResIndexDateTimeType();
      Common.Tools.DateTimeIndex DateTimeIndex = Common.Tools.DateTimeSupport.GetDateTimeIndex(Period);
      if (DateTimeIndex.Low != null || DateTimeIndex.High != null)
      {
        ResourceIndex.DateTimeOffsetLow = DateTimeIndex.Low;
        ResourceIndex.DateTimeOffsetHigh = DateTimeIndex.High;
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetDate(Date Date, List<ResIndexDateTimeType> ResourceIndexList)
    {
      if (Date.IsValidValue(Date.Value))
      {
        var ResourceIndex = new ResIndexDateTimeType();
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

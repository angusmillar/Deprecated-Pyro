using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Pyro.Common.Search;
using Pyro.Common.SearchIndexer.Index;
using System;
using System.Collections.Generic;

namespace Pyro.Common.SearchIndexer.Setter
{
  public class DateTimeSetter : IDateTimeSetter
  {
    private IServiceSearchParameterLight _SearchParameter;
    
    public IList<IDateTimeIndex> Set(IElementNavigator oElement, DtoServiceSearchParameterLight SearchParameter)
    {
      var ResourceIndexList = new List<IDateTimeIndex>();
      _SearchParameter = SearchParameter;
      
      if (oElement is Hl7.Fhir.ElementModel.PocoNavigator Poco && Poco.FhirValue != null)
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
        
        return ResourceIndexList;
      }
      else
      {
        throw new FormatException($"Unknown Navigator FhirType: '{oElement.Type}' for SearchParameterType: '{SearchParameter.Type}'");
      }
    }

    private void SetTiming(Timing Timing, IList<IDateTimeIndex> ResourceIndexList)
    {
      var ResourceIndex = new DateTimeIndex(_SearchParameter);
      Common.Tools.DateTimeIndex DateTimeIndex = Common.Tools.DateTimeIndexSupport.GetDateTimeIndex(Timing);
      if (DateTimeIndex.Low != null || DateTimeIndex.High != null)
      {
        ResourceIndex.DateTimeOffsetLow = DateTimeIndex.Low;
        ResourceIndex.DateTimeOffsetHigh = DateTimeIndex.High;
        ResourceIndexList.Add(ResourceIndex);
      }
    }

    private void SetInstant(Instant Instant, IList<IDateTimeIndex> ResourceIndexList)
    {
      if (Instant.Value.HasValue)
      {
        var ResourceIndex = new DateTimeIndex(_SearchParameter);
        Common.Tools.DateTimeIndex DateTimeIndex = Common.Tools.DateTimeIndexSupport.GetDateTimeIndex(Instant);
        if (DateTimeIndex.Low != null || DateTimeIndex.High != null)
        {
          ResourceIndex.DateTimeOffsetLow = DateTimeIndex.Low;
          ResourceIndex.DateTimeOffsetHigh = DateTimeIndex.High;
          ResourceIndexList.Add(ResourceIndex);
        }
      }
    }
    private void SetString(FhirString FhirString, IList<IDateTimeIndex> ResourceIndexList)
    {
      if (Hl7.Fhir.Model.Date.IsValidValue(FhirString.Value) || FhirDateTime.IsValidValue(FhirString.Value))
      {
        Common.Tools.FhirDateTimeSupport oFhirDateTimeTool = new Common.Tools.FhirDateTimeSupport(FhirString.Value);
        if (oFhirDateTimeTool.IsValid)
        {
          var ResourceIndex = new DateTimeIndex(_SearchParameter);
          ResourceIndex.DateTimeOffsetLow = oFhirDateTimeTool.Value.Value;
          ResourceIndexList.Add(ResourceIndex);
        }
      }
    }
    private void SetDateTime(FhirDateTime FhirDateTime, IList<IDateTimeIndex> ResourceIndexList)
    {
      if (FhirDateTime.IsValidValue(FhirDateTime.Value))
      {
        var ResourceIndex = new DateTimeIndex(_SearchParameter);
        Common.Tools.DateTimeIndex DateTimeIndex = Common.Tools.DateTimeIndexSupport.GetDateTimeIndex(FhirDateTime);
        if (DateTimeIndex.Low != null || DateTimeIndex.High != null)
        {
          ResourceIndex.DateTimeOffsetLow = DateTimeIndex.Low;
          ResourceIndex.DateTimeOffsetHigh = DateTimeIndex.High;
          ResourceIndexList.Add(ResourceIndex);
        }
      }
    }
    private void SetPeriod(Period Period, IList<IDateTimeIndex> ResourceIndexList)
    {
      var ResourceIndex = new DateTimeIndex(_SearchParameter);
      Common.Tools.DateTimeIndex DateTimeIndex = Common.Tools.DateTimeIndexSupport.GetDateTimeIndex(Period);
      if (DateTimeIndex.Low != null || DateTimeIndex.High != null)
      {
        ResourceIndex.DateTimeOffsetLow = DateTimeIndex.Low;
        ResourceIndex.DateTimeOffsetHigh = DateTimeIndex.High;
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetDate(Date Date, IList<IDateTimeIndex> ResourceIndexList)
    {
      if (Date.IsValidValue(Date.Value))
      {
        var ResourceIndex = new DateTimeIndex(_SearchParameter);
        Common.Tools.DateTimeIndex DateTimeIndex = Common.Tools.DateTimeIndexSupport.GetDateTimeIndex(Date);
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

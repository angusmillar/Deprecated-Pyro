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

    public IList<IDateTimeIndex> Set(ITypedElement oElement, IServiceSearchParameterLight SearchParameter)
    {
      var ResourceIndexList = new List<IDateTimeIndex>();
      _SearchParameter = SearchParameter;

      FHIRAllTypes? FhirType = ModelInfo.FhirTypeNameToFhirType(oElement.InstanceType);
      if (FhirType.HasValue)
      {
        switch (FhirType.Value)
        {
          case FHIRAllTypes.Date:
            if (oElement.Value is Date Date)
            {
              SetDate(Date, ResourceIndexList);
            }
            break;
          case FHIRAllTypes.Period:
            if (oElement.Value is Period Period)
            {
              SetPeriod(Period, ResourceIndexList);
            }
            break;
          case FHIRAllTypes.DateTime:
            if (oElement.Value is FhirDateTime FhirDateTime)
            {
              SetDateTime(FhirDateTime, ResourceIndexList);
            }
            break;
          case FHIRAllTypes.String:
            if (oElement.Value is FhirString FhirString)
            {
              SetString(FhirString, ResourceIndexList);
            }
            break;
          case FHIRAllTypes.Instant:
            if (oElement.Value is Instant Instant)
            {
              SetInstant(Instant, ResourceIndexList);
            }
            break;
          case FHIRAllTypes.Timing:
            if (oElement.Value is Timing Timing)
            {
              SetTiming(Timing, ResourceIndexList);
            }
            break;
          default:
            throw new FormatException($"No cast for FhirType of : '{oElement.InstanceType}' for SearchParameterType: '{SearchParameter.Type}'");
        }
        return ResourceIndexList;
      }
      else
      {
        throw new FormatException($"Unknown FhirType of: '{oElement.InstanceType}' for SearchParameterType: '{SearchParameter.Type}'");
      }

    }
    
    private void SetTiming(Timing Timing, IList<IDateTimeIndex> ResourceIndexList)
    {
      var ResourceIndex = new DateTimeIndex(_SearchParameter);
      Common.Tools.DateTimeIndex DateTimeIndex = Common.Tools.DateTimeIndexSupport.GetDateTimeIndex(Timing);
      if (DateTimeIndex.Low != null || DateTimeIndex.High != null)
      {
        ResourceIndexList.Add(SetDateTimeAsUTC(DateTimeIndex));        
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
          ResourceIndexList.Add(SetDateTimeAsUTC(DateTimeIndex));         
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
          if (oFhirDateTimeTool.Value.HasValue)
          {
            var FhirDateTime = new FhirDateTime(oFhirDateTimeTool.Value.Value);
            Common.Tools.DateTimeIndex DateTimeIndex = Common.Tools.DateTimeIndexSupport.GetDateTimeIndex(FhirDateTime);
            ResourceIndexList.Add(SetDateTimeAsUTC(DateTimeIndex));
          }    
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
          ResourceIndexList.Add(SetDateTimeAsUTC(DateTimeIndex));
        }
      }
    }
    private void SetPeriod(Period Period, IList<IDateTimeIndex> ResourceIndexList)
    {
      var ResourceIndex = new DateTimeIndex(_SearchParameter);
      Common.Tools.DateTimeIndex DateTimeIndex = Common.Tools.DateTimeIndexSupport.GetDateTimeIndex(Period);
      if (DateTimeIndex.Low != null || DateTimeIndex.High != null)
      {
        ResourceIndexList.Add(SetDateTimeAsUTC(DateTimeIndex));
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
          ResourceIndexList.Add(SetDateTimeAsUTC(DateTimeIndex));
        }
      }
    }

    private Index.DateTimeIndex SetDateTimeAsUTC(Tools.DateTimeIndex item)
    {
      var ResourceIndex = new Index.DateTimeIndex(_SearchParameter);
      ResourceIndex.LowUtcDateTime = Tools.DateTimeSupport.DateTimeOffSetToUTCDateTime(item.Low);
      ResourceIndex.HighUtcDateTime = Tools.DateTimeSupport.DateTimeOffSetToUTCDateTime(item.High);
      return ResourceIndex;
    }

  }

}

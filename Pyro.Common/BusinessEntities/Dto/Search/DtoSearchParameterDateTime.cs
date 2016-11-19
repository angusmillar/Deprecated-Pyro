using System;
using System.Collections.Generic;
using Pyro.Common.Tools;
using Hl7.Fhir.Model;


namespace Pyro.Common.BusinessEntities.Search
{
  public class DtoSearchParameterDateTime : DtoSearchParameterBase
  {
    #region Constructor
    public DtoSearchParameterDateTime()
      : base()
    {
      this.DbSearchParameterType = Pyro.Common.Enum.DatabaseEnum.DbIndexType.DateTimeIndex;
    }
    #endregion

    public List<DtoSearchParameterDateTimeValue> ValueList { get; set; }

    public override bool TryParseValue(string Values)
    {
      this.ValueList = new List<DtoSearchParameterDateTimeValue>();
      foreach (string Value in Values.Split(OrDelimiter))
      {
        var DtoSearchParameterDateTimeValue = new DtoSearchParameterDateTimeValue();
        if (this.Modifier == Enum.FhirSearchEnum.SearchModifierType.Missing)
        {
          bool? IsMissing = DtoSearchParameterDateTimeValue.ParseModifierEqualToMissing(Value);
          if (IsMissing.HasValue)
          {
            DtoSearchParameterDateTimeValue.IsMissing = IsMissing.Value;
            ValueList.Add(DtoSearchParameterDateTimeValue);
          }
          else
          {
            return false;
          }
        }
        else
        {
          var DateTimeStirng = DtoSearchParameterDateTimeValue.ParsePrefix(Value);
          FhirDateTimeSupport FhirDateTimeSupport = new FhirDateTimeSupport(DateTimeStirng.Trim());
          if (FhirDateTimeSupport.IsValid)
          {
            if (FhirDateTimeSupport.Value.HasValue)
            {
              DtoSearchParameterDateTimeValue.Value = FhirDateTimeSupport.Value.Value;
              DtoSearchParameterDateTimeValue.Precision = FhirDateTimeSupport.Precision;
              ValueList.Add(DtoSearchParameterDateTimeValue);
            }
            else
            {
              return false;
            }

          }
          else
          {
            return false;
          }
        }
      }
      if (ValueList.Count > 1)
      {
        this.HasLogicalOrProperties = true;
      }
      if (this.ValueList.Count == 0)
      {
        return false;
      }
      else
      {
        return true;
      }
    }

    public override bool ValidatePrefixes(DtoSupportedSearchParameters DtoSupportedSearchParameters)
    {
      foreach (var Value in ValueList)
      {
        if (!Value.ValidatePreFix(DtoSupportedSearchParameters))
        {
          return false;
        }
      }
      return true;
    }
  }
}

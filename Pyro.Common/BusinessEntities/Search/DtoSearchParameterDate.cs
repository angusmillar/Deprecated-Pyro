using System;
using System.Collections.Generic;
using Hl7.Fhir.Model;


namespace Blaze.Common.BusinessEntities.Search
{
  public class DtoSearchParameterDate : DtoSearchParameterBase
  {
    #region Constructor
    public DtoSearchParameterDate()
      : base()
    {
      this.DbSearchParameterType = Blaze.Common.Enum.DatabaseEnum.DbIndexType.DateIndex;
    }
    #endregion

    public List<DtoSearchParameterDateValue> ValueList { get; set; }

    public override bool TryParseValue(string Values)
    {
      this.ValueList = new List<DtoSearchParameterDateValue>();
      foreach (string Value in Values.Split(OrDelimiter))
      {
        var DtoSearchParameterDateValue = new DtoSearchParameterDateValue();
        if (this.Modifier == Enum.FhirSearchEnum.SearchModifierType.Missing)
        {
          bool? IsMissing = DtoSearchParameterDateValue.ParseModifierEqualToMissing(Value);
          if (IsMissing.HasValue)
          {
            DtoSearchParameterDateValue.IsMissing = IsMissing.Value;
            ValueList.Add(DtoSearchParameterDateValue);
          }
          else
          {
            return false;
          }
        }
        else
        {
          int? DateInt = null;
          var Date = DtoSearchParameterDateValue.ParsePrefix(Value);
          if (Hl7.Fhir.Model.Date.IsValidValue(Date))
          {
            DateInt = Common.Tools.FhirTimeSupport.ConvertDateToInteger(new Date(Date));
            if (DateInt.HasValue)
            {
              DtoSearchParameterDateValue.Value = (int)DateInt;
              ValueList.Add(DtoSearchParameterDateValue);
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

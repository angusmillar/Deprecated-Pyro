using System;
using System.Collections.Generic;
using Pyro.Common.Tools;
using Hl7.Fhir.Model;
using Pyro.Common.DtoEntity;
using Pyro.Common.Enum;

namespace Pyro.Common.Search.SearchParameterEntity
{
  public class SearchParameterDateTime : SearchParameterBase
  {
    #region Constructor
    public SearchParameterDateTime()
      : base()
    {
      this.Type = Hl7.Fhir.Model.SearchParamType.Date;
      //this.DbSearchParameterType = Pyro.Common.Enum.DatabaseEnum.DbIndexType.DateTimeIndex;
    }
    #endregion

    public List<SearchParameterDateTimeValue> ValueList { get; set; }

    public override object CloneDeep()
    {
      var Clone = new SearchParameterDateTime();
      base.CloneDeep(Clone);
      Clone.ValueList = new List<SearchParameterDateTimeValue>();
      Clone.ValueList.AddRange(this.ValueList);
      return Clone;
    }

    public override bool TryParseValue(string Values)
    {
      this.ValueList = new List<SearchParameterDateTimeValue>();
      foreach (string Value in Values.Split(OrDelimiter))
      {
        var DtoSearchParameterDateTimeValue = new SearchParameterDateTimeValue();
        if (this.Modifier.HasValue && this.Modifier == SearchParameter.SearchModifierCode.Missing)
        {
          bool? IsMissing = DtoSearchParameterDateTimeValue.ParseModifierEqualToMissing(Value);
          if (IsMissing.HasValue)
          {
            DtoSearchParameterDateTimeValue.IsMissing = IsMissing.Value;
            ValueList.Add(DtoSearchParameterDateTimeValue);
          }
          else
          {
            this.InvalidMessage = $"Found the {Hl7.Fhir.Model.SearchParameter.SearchModifierCode.Missing.GetPyroLiteral()} Modifier yet is value was expected to be true or false yet found '{Value}'. ";
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
            this.InvalidMessage = $"Unable to parse the provided value of {DateTimeStirng.Trim()} as a FHIR DateTime.";
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

    public override bool ValidatePrefixes(DtoServiceSearchParameterLight DtoSupportedSearchParameters)
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

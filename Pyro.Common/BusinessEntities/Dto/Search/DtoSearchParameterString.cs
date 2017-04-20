using System;
using System.Collections.Generic;
using System.Linq;
using Pyro.Common.Enum;
using Pyro.Common.BusinessEntities.Dto;

namespace Pyro.Common.BusinessEntities.Search
{
  public class DtoSearchParameterString : DtoSearchParameterBase
  {
    #region Constructor
    public DtoSearchParameterString()
      : base()
    {
      this.Type = Hl7.Fhir.Model.SearchParamType.String;
      //this.DbSearchParameterType = DatabaseEnum.DbIndexType.StringIndex;
    }
    #endregion
    public List<DtoSearchParameterStringValue> ValueList { get; set; }

    public override bool TryParseValue(string Values)
    {
      this.ValueList = new List<DtoSearchParameterStringValue>();
      foreach (string Value in Values.Split(OrDelimiter))
      {
        var DtoSearchParameterStringValue = new DtoSearchParameterStringValue();
        if (this.Modifier == Enum.FhirSearchEnum.SearchModifierType.Missing)
        {
          bool? IsMissing = DtoSearchParameterStringValue.ParseModifierEqualToMissing(Value);
          if (IsMissing.HasValue)
          {
            DtoSearchParameterStringValue.IsMissing = IsMissing.Value;
            this.ValueList.Add(DtoSearchParameterStringValue);
          }
          else
          {
            return false;
          }
        }
        else
        {
          DtoSearchParameterStringValue.Value = Value.Trim();
          this.ValueList.Add(DtoSearchParameterStringValue);
        }
      }
      if (this.ValueList.Count() > 1)
        this.HasLogicalOrProperties = true;
      if (this.ValueList.Count > 0)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    public override bool ValidatePrefixes(DtoServiceSearchParameterLight DtoSupportedSearchParameters)
    {
      //String Search parameter types never have prefixes so always return true.
      return true;
    }

  }
}

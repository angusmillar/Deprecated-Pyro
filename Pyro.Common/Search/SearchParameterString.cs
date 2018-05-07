using System;
using System.Collections.Generic;
using System.Linq;
using Pyro.Common.Enum;
using Pyro.Common.BusinessEntities.Dto;

namespace Pyro.Common.Search
{
  public class SearchParameterString : SearchParameterBase
  {
    #region Constructor
    public SearchParameterString()
      : base()
    {
      this.Type = Hl7.Fhir.Model.SearchParamType.String;
      //this.DbSearchParameterType = DatabaseEnum.DbIndexType.StringIndex;
    }
    #endregion
    public List<SearchParameterStringValue> ValueList { get; set; }

    public override object CloneDeep()
    {
      var Clone = new SearchParameterString();
      base.CloneDeep(Clone);
      Clone.ValueList = new List<SearchParameterStringValue>();
      Clone.ValueList.AddRange(this.ValueList);
      return Clone;
    }


    public override bool TryParseValue(string Values)
    {
      this.ValueList = new List<SearchParameterStringValue>();
      foreach (string Value in Values.Split(OrDelimiter))
      {
        var DtoSearchParameterStringValue = new SearchParameterStringValue();
        if (this.Modifier.HasValue && this.Modifier == Hl7.Fhir.Model.SearchParameter.SearchModifierCode.Missing)
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

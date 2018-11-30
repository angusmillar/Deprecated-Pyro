using System;
using System.Collections.Generic;
using System.Linq;
using Pyro.Common.Enum;
using Pyro.Common.DtoEntity;
using Pyro.Common.Tools;

namespace Pyro.Common.Search.SearchParameterEntity
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
            this.InvalidMessage = $"Found the {Hl7.Fhir.Model.SearchParameter.SearchModifierCode.Missing.GetPyroLiteral()} Modifier yet the value was expected to be true or false yet found '{Value}'. ";
            return false;
          }
        }
        else
        {
          DtoSearchParameterStringValue.Value = StringSupport.ToLowerTrimRemoveDiacriticsTruncate(Value, Database.StaticDatabaseInfo.BaseDatabaseFieldLength.StringMaxLength); 
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

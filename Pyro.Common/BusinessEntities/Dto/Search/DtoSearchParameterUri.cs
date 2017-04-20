using System;
using System.Collections.Generic;
using System.Linq;
using Pyro.Common.Enum;
using Pyro.Common.BusinessEntities.Dto;

namespace Pyro.Common.BusinessEntities.Search
{
  public class DtoSearchParameterUri : DtoSearchParameterBase
  {
    #region Constructor
    public DtoSearchParameterUri()
      : base()
    {
      this.Type = Hl7.Fhir.Model.SearchParamType.Uri;
      //this.DbSearchParameterType = DatabaseEnum.DbIndexType.UriIndex;
    }
    #endregion
    public List<DtoSearchParameterUriValue> ValueList { get; set; }

    public override bool TryParseValue(string Values)
    {
      this.ValueList = new List<DtoSearchParameterUriValue>();
      foreach (string Value in Values.Split(OrDelimiter))
      {
        var DtoSearchParameterStringValue = new DtoSearchParameterUriValue();
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
          Uri TempUri = null;
          if (Uri.TryCreate(Value.Trim(), UriKind.RelativeOrAbsolute, out TempUri))
          {
            DtoSearchParameterStringValue.Value = TempUri;
            this.ValueList.Add(DtoSearchParameterStringValue);
          }
          else
          {
            this.InvalidMessage = $"Unable to parse the given URI search parameter string of : {Value.Trim()}";
            return false;
          }
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

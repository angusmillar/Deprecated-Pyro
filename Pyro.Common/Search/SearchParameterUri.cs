using System;
using System.Collections.Generic;
using System.Linq;
using Pyro.Common.Enum;
using Pyro.Common.BusinessEntities.Dto;

namespace Pyro.Common.Search
{
  public class SearchParameterUri : SearchParameterBase
  {
    #region Constructor
    public SearchParameterUri()
      : base()
    {
      this.Type = Hl7.Fhir.Model.SearchParamType.Uri;
      //this.DbSearchParameterType = DatabaseEnum.DbIndexType.UriIndex;
    }
    #endregion
    public List<SearchParameterUriValue> ValueList { get; set; }

    public override bool TryParseValue(string Values)
    {
      this.ValueList = new List<SearchParameterUriValue>();
      foreach (string Value in Values.Split(OrDelimiter))
      {
        var DtoSearchParameterStringValue = new SearchParameterUriValue();
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
    public override bool ValidatePrefixes(ServiceSearchParameterLight DtoSupportedSearchParameters)
    {
      //String Search parameter types never have prefixes so always return true.
      return true;
    }

  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Pyro.Common.Enum;


namespace Pyro.Common.BusinessEntities.Search
{
  public class DtoSearchParameterReferance : DtoSearchParameterBase
  {
    #region Constructor
    public DtoSearchParameterReferance()
      : base()
    {
      this.DbSearchParameterType = DatabaseEnum.DbIndexType.ReferenceIndex;
    }
    #endregion
    public List<DtoSearchParameterReferanceValue> ValueList { get; set; }
    public IList<string> AllowedReferanceResourceList { get; set; }

    public override bool TryParseValue(string Values)
    {
      this.ValueList = new List<DtoSearchParameterReferanceValue>();
      foreach (string Value in Values.Split(OrDelimiter))
      {
        var DtoSearchParameterReferanceValue = new DtoSearchParameterReferanceValue();
        if (this.Modifier == Enum.FhirSearchEnum.SearchModifierType.Missing)
        {
          bool? IsMissing = DtoSearchParameterReferanceValue.ParseModifierEqualToMissing(Value);
          if (IsMissing.HasValue)
          {
            DtoSearchParameterReferanceValue.IsMissing = IsMissing.Value;
            this.ValueList.Add(DtoSearchParameterReferanceValue);
          }
          else
          {
            return false;
          }
        }
        else
        {
          Interfaces.UriSupport.IFhirUri TempFhirUri = null;
          if (UriSupport.DtoFhirUri.TryParse(Value.Trim(), out TempFhirUri))
          {
            DtoSearchParameterReferanceValue.FhirUri = TempFhirUri;
          }
          else if (!string.IsNullOrWhiteSpace(Value.Trim()) && this.Modifier == FhirSearchEnum.SearchModifierType.Type && !string.IsNullOrWhiteSpace(this.TypeModifierResource))
          {
            if (UriSupport.DtoFhirUri.TryParse($"{this.TypeModifierResource}/{Value.Trim()}", out TempFhirUri))
            {
              DtoSearchParameterReferanceValue.FhirUri = TempFhirUri;
            }
            else
            {
              this.InvalidMessage = $"Unable to parse the Resource reference search parameter.";
              return false;
            }
          }
          else if (!string.IsNullOrWhiteSpace(Value.Trim()) && this.AllowedReferanceResourceList.Count() == 1)
          {
            if (UriSupport.DtoFhirUri.TryParse($"{this.AllowedReferanceResourceList[0]}/{Value.Trim()}", out TempFhirUri))
            {
              DtoSearchParameterReferanceValue.FhirUri = TempFhirUri;
            }
            else
            {
              this.InvalidMessage = $"The Resource Name was not given as a Type modifier in the reference search parameter and the search parameter supports many Resource types. You must specify the resource name the reference relates to.";
              return false;
            }
          }
          else
          {
            this.InvalidMessage = $"The Resource Name was not given as a Type modifier in the reference search parameter and the search parameter supports many Resource types. You must specify the resource name the reference relates to.";
            return false;
          }
          if (!this.AllowedReferanceResourceList.Contains(DtoSearchParameterReferanceValue.FhirUri.ResourseType))
          {
            this.InvalidMessage = $"The Resource Name used in the reference search parameter is not allowed for this search parameter against this Resource.";
            return false;
          }
          else
          {
            this.ValueList.Add(DtoSearchParameterReferanceValue);
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
    public override bool ValidatePrefixes(DtoSupportedSearchParameters DtoSupportedSearchParameters)
    {
      //String Search parameter types never have prefixes so always return true.
      return true;
    }

  }
}

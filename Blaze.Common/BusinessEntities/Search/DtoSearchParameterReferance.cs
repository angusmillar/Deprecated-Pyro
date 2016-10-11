using System;
using System.Collections.Generic;
using System.Linq;
using Blaze.Common.Enum;


namespace Blaze.Common.BusinessEntities.Search
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

    public override bool TryParseValue(string Values)
    {
      this.ValueList = new List<DtoSearchParameterReferanceValue>();
      foreach (string Value in Values.Split(OrDelimiter))
      {
        var DtoSearchParameterStringValue = new DtoSearchParameterReferanceValue();
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
          //Chained Parameter
          if (this.Modifier == FhirSearchEnum.SearchModifierType.Type && !string.IsNullOrWhiteSpace(this.TypeModifierResource))
          {
             //SearchParametersValidationOperationOutcome Validate(FHIRDefinedType ResourceType, SearchParams SearchParameter)
          }
          else
          {
            DtoSearchParameterStringValue.Value = Value.Trim();
          }          
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
    public override bool ValidatePrefixes(DtoSupportedSearchParameters DtoSupportedSearchParameters)
    {
      //String Search parameter types never have prefixes so always return true.
      return true;
    }

  }
}

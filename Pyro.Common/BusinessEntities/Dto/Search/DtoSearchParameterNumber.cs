using Pyro.Common.BusinessEntities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.BusinessEntities.Search
{
  public class DtoSearchParameterNumber : DtoSearchParameterBase
  {
    #region Constructor
    public DtoSearchParameterNumber()
      : base()
    {
      this.Type = Hl7.Fhir.Model.SearchParamType.Number;
      //this.DbSearchParameterType = Pyro.Common.Enum.DatabaseEnum.DbIndexType.NumberIndex;
    }
    #endregion

    public List<DtoSearchParameterNumberValue> ValueList { get; set; }

    public override bool TryParseValue(string Values)
    {
      this.ValueList = new List<DtoSearchParameterNumberValue>();      
      foreach (var Value in Values.Split(OrDelimiter))
      {
        var DtoSearchParameterNumber = new DtoSearchParameterNumberValue();
        if (this.Modifier == Enum.FhirSearchEnum.SearchModifierType.Missing)
        {
          bool? IsMissing = DtoSearchParameterNumber.ParseModifierEqualToMissing(Value);
          if (IsMissing.HasValue)
          {
            DtoSearchParameterNumber.IsMissing = IsMissing.Value;
            this.ValueList.Add(DtoSearchParameterNumber);
          }
          else
          {
            return false;
          }
        }
        else
        {
          decimal TempDouble;
          var Number = DtoSearchParameterNumber.ParsePrefix(Value);
          DtoSearchParameterNumber.Precision = Tools.StringSupport.GetPrecisionFromDecimal(Number);
          DtoSearchParameterNumber.Scale = Tools.StringSupport.GetScaleFromDecimal(Number);
          if (Decimal.TryParse(Number, out TempDouble))
          {
            DtoSearchParameterNumber.Value = TempDouble;
            this.ValueList.Add(DtoSearchParameterNumber);
          }
          else
          {
            return false;
          }
        }
      }
      if (this.ValueList.Count == 0)
        return false;
      else
        return true;
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

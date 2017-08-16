using Pyro.Common.BusinessEntities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.Search
{
  public class SearchParameterNumber : SearchParameterBase
  {
    #region Constructor
    public SearchParameterNumber()
      : base()
    {
      this.Type = Hl7.Fhir.Model.SearchParamType.Number;
    }
    #endregion

    public List<SearchParameterNumberValue> ValueList { get; set; }

    public override bool TryParseValue(string Values)
    {
      this.ValueList = new List<SearchParameterNumberValue>();
      foreach (var Value in Values.Split(OrDelimiter))
      {
        var DtoSearchParameterNumber = new SearchParameterNumberValue();
        if (this.Modifier.HasValue && this.Modifier == Hl7.Fhir.Model.SearchParameter.SearchModifierCode.Missing)
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
    public override bool ValidatePrefixes(ServiceSearchParameterLight DtoSupportedSearchParameters)
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

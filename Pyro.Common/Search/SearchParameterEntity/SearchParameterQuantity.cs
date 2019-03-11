using Hl7.Fhir.Utility;
using Pyro.Common.DtoEntity;
using Pyro.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.Search.SearchParameterEntity
{

  /// <summary>
  /// Class: DtoSearchParameterQuantity
  /// This same class can be used for both Quantity and QuantityRange type searches
  /// </summary>
  public class SearchParameterQuantity : SearchParameterBase
  {
    #region Private Properties
    private const char VerticalBarDelimiter = '|';
    #endregion

    #region Constructor
    public SearchParameterQuantity()
      : base()
    {
      this.Type = Hl7.Fhir.Model.SearchParamType.Quantity;
      //this.DbSearchParameterType = Pyro.Common.Enum.DatabaseEnum.DbIndexType.QuantityIndex;
    }
    #endregion

    public List<SearchParameterQuantityValue> ValueList { get; set; }

    public override object CloneDeep()
    {
      var Clone = new SearchParameterQuantity();
      base.CloneDeep(Clone);
      Clone.ValueList = new List<SearchParameterQuantityValue>();
      Clone.ValueList.AddRange(this.ValueList);
      return Clone;
    }

    public override bool TryParseValue(string Values)
    {
      this.ValueList = new List<SearchParameterQuantityValue>();
      foreach (var Value in Values.Split(OrDelimiter))
      {
        var DtoSearchParameterNumber = new SearchParameterQuantityValue();
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
            this.InvalidMessage = $"Found the {Hl7.Fhir.Model.SearchParameter.SearchModifierCode.Missing.GetPyroLiteral()} Modifier yet is value was expected to be true or false yet found '{Value}'. ";
            return false;
          }
        }
        else
        {
          //Examples:
          //Syntax: [parameter]=[prefix][number]|[system]|[code] matches a quantity with the given unit    
          //Observation?value=5.4|http://unitsofmeasure.org|mg
          //Observation?value=5.4||mg
          //Observation?value=le5.4|http://unitsofmeasure.org|mg
          //Observation?value=ap5.4|http://unitsofmeasure.org|mg

          //Observation?value=ap5.4
          //Observation?value=ap5.4|
          //Observation?value=ap5.4|http://unitsofmeasure.org
          //Observation?value=ap5.4|http://unitsofmeasure.org|

          string[] Split = Value.Trim().Split(VerticalBarDelimiter);
          if (Split.Count() == 1)
          {
            var Number = DtoSearchParameterNumber.ParsePrefix(Split[0]);
            DtoSearchParameterNumber.Precision = Tools.StringSupport.GetPrecisionFromDecimal(Number);
            DtoSearchParameterNumber.Scale = Tools.StringSupport.GetScaleFromDecimal(Number);
            decimal TempDouble;
            if (Decimal.TryParse(Number, out TempDouble))
            {
              DtoSearchParameterNumber.Value = TempDouble;
              DtoSearchParameterNumber.System = null;
              DtoSearchParameterNumber.Code = null;
              this.ValueList.Add(DtoSearchParameterNumber);
            }
            else
            {
              this.InvalidMessage = $"Expected a Quantity value yet was unable to parse the provided value '{Number}' as a Decimal. ";
              return false;
            }
          }
          else if (Split.Count() == 2)
          {
            var Number = DtoSearchParameterNumber.ParsePrefix(Split[0]);
            DtoSearchParameterNumber.Precision = Tools.StringSupport.GetPrecisionFromDecimal(Number);
            DtoSearchParameterNumber.Scale = Tools.StringSupport.GetScaleFromDecimal(Number);
            decimal TempDouble;
            if (Decimal.TryParse(Number, out TempDouble))
            {
              DtoSearchParameterNumber.Value = TempDouble;
              if (!string.IsNullOrWhiteSpace(Split[1].Trim()))
              {
                DtoSearchParameterNumber.System = Split[1].Trim();
              }
              else
              {
                DtoSearchParameterNumber.System = null;
              }              
              DtoSearchParameterNumber.Code = null;
              this.ValueList.Add(DtoSearchParameterNumber);
            }
            else
            {
              this.InvalidMessage = $"Expected a Quantity value yet was unable to parse the provided value '{Number}' as a Decimal. ";
              return false;
            }
          }
          else if (Split.Count() == 3)
          {
            var Number = DtoSearchParameterNumber.ParsePrefix(Split[0]);
            DtoSearchParameterNumber.Precision = Tools.StringSupport.GetPrecisionFromDecimal(Number);
            DtoSearchParameterNumber.Scale = Tools.StringSupport.GetScaleFromDecimal(Number);
            decimal TempDouble;
            if (Decimal.TryParse(Number, out TempDouble))
            {
              DtoSearchParameterNumber.Value = TempDouble;
              if (!string.IsNullOrWhiteSpace(Split[1].Trim()))
              {
                DtoSearchParameterNumber.System = Split[1].Trim();
              }
              else
              {
                DtoSearchParameterNumber.System = null;
              }

              if (!string.IsNullOrWhiteSpace(Split[2].Trim()))
              {
                DtoSearchParameterNumber.Code = Split[2].Trim();
              }
              else
              {
                DtoSearchParameterNumber.Code = null;
              }
              
              this.ValueList.Add(DtoSearchParameterNumber);
            }
            else
            {
              this.InvalidMessage = $"Expected a Quantity value yet was unable to parse the provided value '{Number}' as a Decimal. ";
              return false;
            }
          }
          else
          {
            this.InvalidMessage = $"Expected a Quantity value type yet found to many {VerticalBarDelimiter} Delimiters. ";
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
          this.InvalidMessage = $"The search parameter had an unsupported prefix of '{Value.Prefix.GetLiteral()}'. ";
          return false;
        }
      }
      return true;
    }

  }
}

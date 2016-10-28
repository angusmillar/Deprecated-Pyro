using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.BusinessEntities.Search
{

  /// <summary>
  /// Class: DtoSearchParameterQuantity
  /// This same class can be used for both Quantity and QuantityRange type searches
  /// </summary>
  public class DtoSearchParameterQuantity : DtoSearchParameterBase
  {
    #region Private Properties
    private const char VerticalBarDelimiter = '|';
    #endregion

    #region Constructor
    public DtoSearchParameterQuantity()
      : base()
    {
      this.DbSearchParameterType = Pyro.Common.Enum.DatabaseEnum.DbIndexType.QuantityIndex;
    }
    #endregion

    public List<DtoSearchParameterQuantityValue> ValueList { get; set; }

    public override bool TryParseValue(string Values)
    {
      this.ValueList = new List<DtoSearchParameterQuantityValue>();
      foreach (var Value in Values.Split(OrDelimiter))
      {
        var DtoSearchParameterNumber = new DtoSearchParameterQuantityValue();
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
          //Examples:
          //Syntax: [parameter]=[prefix][number]|[system]|[code] matches a quantity with the given unit    
          //Observation?value=5.4|http://unitsofmeasure.org|mg
          //Observation?value=5.4||mg
          //Observation?value=le5.4|http://unitsofmeasure.org|mg
          //Observation?value=ap5.4|http://unitsofmeasure.org|mg

          string[] Split = Value.Trim().Split(VerticalBarDelimiter);
          if (Split.Count() == 3)
          {
            var Number = DtoSearchParameterNumber.ParsePrefix(Split[0]);
            DtoSearchParameterNumber.Precision = Tools.StringSupport.GetPrecisionFromDecimal(Number);
            DtoSearchParameterNumber.Scale = Tools.StringSupport.GetScaleFromDecimal(Number);
            decimal TempDouble;
            if (Decimal.TryParse(Number, out TempDouble))
            {
              DtoSearchParameterNumber.Value = TempDouble;
              DtoSearchParameterNumber.System = Split[1].Trim();
              DtoSearchParameterNumber.Code = Split[2].Trim();
              this.ValueList.Add(DtoSearchParameterNumber);
            }
            else
            {
              return false;
            }
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
    public override bool ValidatePrefixes(DtoSupportedSearchParameters DtoSupportedSearchParameters)
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

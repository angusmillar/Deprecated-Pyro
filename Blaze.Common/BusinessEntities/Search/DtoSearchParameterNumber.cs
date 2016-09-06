using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Common.BusinessEntities.Search
{
  public class DtoSearchParameterNumber : DtoSearchParameterBase
  {
    #region Constructor
    public DtoSearchParameterNumber()
      : base()
    {
      this.DbSearchParameterType = Blaze.Common.Enum.DatabaseEnum.DbIndexType.NumberIndex;
    }
    #endregion

    public List<DtoSearchParameterNumberValue> ValueList { get; set; }

    public override bool TryParseValue(string Values)
    {
      this.ValueList = new List<DtoSearchParameterNumberValue>();
      double TempDouble;
      foreach (var Value in Values.Split(OrDelimiter))
      {        
        var DtoSearchParameterNumber = new DtoSearchParameterNumberValue();
        var Number = DtoSearchParameterNumber.ParsePrefix(Value);
        if (Double.TryParse(Number, out TempDouble))
        {          
          DtoSearchParameterNumber.Value = TempDouble;
          this.ValueList.Add(DtoSearchParameterNumber);
        }
        else
        {
          return false;
        }
      }
      if (this.ValueList.Count == 0)
        return false;
      else
        return true;
    }
    public override bool ValidatePrefixes(DtoSupportedSearchParameters DtoSupportedSearchParameters)
    {
      foreach(var Value in ValueList)
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

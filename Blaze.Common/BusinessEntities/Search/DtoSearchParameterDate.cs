using System;
using System.Collections.Generic;


namespace Blaze.Common.BusinessEntities.Search
{
  public class DtoSearchParameterDate : DtoSearchParameterBase
  {
    #region Constructor
    public DtoSearchParameterDate()
      : base()
    {
      this.DbSearchParameterType = Blaze.Common.Enum.DatabaseEnum.DbIndexType.DateIndex;
    }
    #endregion

    public List<DtoSearchParameterDateValue> ValueList { get; set; }

    public override bool TryParseValue(string Values)
    {
      this.ValueList = new List<DtoSearchParameterDateValue>();
      foreach (var Value in Values.Split(OrDelimiter))
      {
        DateTimeOffset DateTimeOffset;
        var DtoSearchParameterDateValue = new DtoSearchParameterDateValue();
        var Date = DtoSearchParameterDateValue.ParsePrefix(Value);
        if (DateTimeOffset.TryParse(Date, out DateTimeOffset))
        {
          DtoSearchParameterDateValue.Value = DateTimeOffset;
          ValueList.Add(DtoSearchParameterDateValue);
        }
        else
        {
          return false;
        }
      }
      if (ValueList.Count > 1)
      {
        this.HasLogicalOrProperties = true;
      }
      if (this.ValueList.Count == 0)
      {
        return false;
      }
      else
      {
        return true;
      }
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

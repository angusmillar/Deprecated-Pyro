using System;
using Blaze.Common.Enum;

namespace Blaze.Common.BusinessEntities.Search
{
  public class DtoSearchParameterDate : DtoSearchParameterBase
  {
    #region Constructor
    public DtoSearchParameterDate()
      : base()
    {      
      this.DbSearchParameterType = DatabaseEnum.BlazeIndexType.NumberIndex;
    }
    #endregion

    public override bool TryParseValue(string Value)
    {
      DateTimeOffset DateTime;
      if (DateTimeOffset.TryParse(Value, out DateTime))
      {
        this.Value = DateTime;
        return true;
      }
      else
      {
        return false;
      }
    }

    public DateTimeOffset Value { get; set; }

  }
}

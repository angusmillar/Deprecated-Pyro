using System.Collections.Generic;
using System.Linq;
using Blaze.Common.Enum;

namespace Blaze.Common.BusinessEntities.Search
{
  public class DtoSearchParameterToken : DtoSearchParameterBase
  {
    protected const char TokenDelimiter = '|';

     #region Constructor
    public DtoSearchParameterToken()
      : base()
    {      
      this.DbSearchParameterType = DatabaseEnum.BlazeIndexType.TokenIndex;      
    }
    #endregion

    public override bool TryParseValue(string Value)
    {
      var Temp = Value.Split(OrDelimiter);

      if (Temp.Count() > 1)
        this.HasLogicalOrProperties = true;
      List<TokenValue> oList = new List<TokenValue>();
      foreach (var item in Temp)
      {
        var oTokenValue = new TokenValue();
        if (item.Contains(TokenDelimiter))
        {
          var oSplit = item.Split(TokenDelimiter);
          oTokenValue.System = oSplit[0];
          oTokenValue.Code = oSplit[1];
        }
        else
        {
          oTokenValue.Code = item;
        }
        oList.Add(oTokenValue);
      }
      this.Values = oList.ToArray();
      return true;
    }
    public TokenValue[] Values { get; set; }

    public class TokenValue
    {
      public string System { get; set; }
      public string Code { get; set; }
    }
  }
}

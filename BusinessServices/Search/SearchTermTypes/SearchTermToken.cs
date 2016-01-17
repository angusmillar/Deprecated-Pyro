using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace Blaze.Engine.Search.SearchTermTypes
{
  public class SearchTermToken : SearchTermBase
  {
    public SearchTermToken()
    {
      this.SearchParameterType = SearchParamType.Token;
    }
    
    public override bool TryParseValue(string Value)
    {
      var Temp = Value.Split(OrDelimiter);

      if (Temp.Count() > 1)
        this.HasLogicalOrProperties = true;
      List<TokenValue> oList = new List<TokenValue>();
      foreach (var item in Temp)
      {
        var oTokenValue = new TokenValue();
        if (item.Contains('|'))
        {
          var oSplit = item.Split('|');
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Common.Enum
{
  public static class DatabaseEnum
  {
    public enum BlazeIndexType
    {
      DateIndex,
      DatePeriodIndex,
      NumberIndex,
      QuantityIndex,
      QuantityRangeIndex,
      ReferenceIndex,
      StringIndex,
      TokenIndex,
      UriIndex
    };

    public static Dictionary<BlazeIndexType, string> BlazeIndexTypeToStringDictonary
    {
      get
      {
        var Dic = new Dictionary<BlazeIndexType, string>();
        Dic.Add(BlazeIndexType.DateIndex, "DateIndex");
        Dic.Add(BlazeIndexType.DatePeriodIndex, "DatePeriodIndex");
        Dic.Add(BlazeIndexType.NumberIndex, "NumberIndex");
        Dic.Add(BlazeIndexType.QuantityIndex, "QuantityIndex");
        Dic.Add(BlazeIndexType.QuantityRangeIndex, "QuantityRangeIndex");
        Dic.Add(BlazeIndexType.ReferenceIndex, "ReferenceIndex");
        Dic.Add(BlazeIndexType.StringIndex, "StringIndex");
        Dic.Add(BlazeIndexType.TokenIndex, "TokenIndex");
        Dic.Add(BlazeIndexType.UriIndex, "UriIndex");
        return Dic;
      }
    }

    public static Dictionary<string, BlazeIndexType> StringToBlazeIndexTypeDictonary
    {
      get
      {
        var Dic = new Dictionary<string, BlazeIndexType>();
        Dic.Add("DateIndex", BlazeIndexType.DateIndex);
        Dic.Add("DatePeriodIndex", BlazeIndexType.DatePeriodIndex);
        Dic.Add("NumberIndex", BlazeIndexType.NumberIndex);
        Dic.Add("QuantityIndex", BlazeIndexType.QuantityIndex);
        Dic.Add("QuantityRangeIndex", BlazeIndexType.QuantityRangeIndex);
        Dic.Add("ReferenceIndex", BlazeIndexType.ReferenceIndex);
        Dic.Add("StringIndex", BlazeIndexType.StringIndex);
        Dic.Add("TokenIndex", BlazeIndexType.TokenIndex);
        Dic.Add("UriIndex", BlazeIndexType.UriIndex);
        return Dic;
      }
    }

  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.Enum
{
  public static class DatabaseEnum
  {
    public enum DbIndexType
    {
      DateIndex,
      DateTimeIndex,
      DateTimePeriodIndex,
      NumberIndex,
      QuantityIndex,
      QuantityRangeIndex,
      ReferenceIndex,
      StringIndex,
      TokenIndex,
      UriIndex
    };

    public static Dictionary<DbIndexType, string> DbIndexTypeToStringDictonary
    {
      get
      {
        var Dic = new Dictionary<DbIndexType, string>();
        Dic.Add(DbIndexType.DateIndex, "DateIndex");
        Dic.Add(DbIndexType.DateTimeIndex, "DateTimeIndex");        
        Dic.Add(DbIndexType.DateTimePeriodIndex, "DateTimePeriodIndex");
        Dic.Add(DbIndexType.NumberIndex, "NumberIndex");
        Dic.Add(DbIndexType.QuantityIndex, "QuantityIndex");
        Dic.Add(DbIndexType.QuantityRangeIndex, "QuantityRangeIndex");
        Dic.Add(DbIndexType.ReferenceIndex, "ReferenceIndex");
        Dic.Add(DbIndexType.StringIndex, "StringIndex");
        Dic.Add(DbIndexType.TokenIndex, "TokenIndex");
        Dic.Add(DbIndexType.UriIndex, "UriIndex");
        return Dic;
      }
    }

    public static Dictionary<string, DbIndexType> StringToDbIndexTypeDictonary
    {
      get
      {
        var Dic = new Dictionary<string, DbIndexType>();
        Dic.Add("DateIndex", DbIndexType.DateIndex);
        Dic.Add("DateTimeIndex", DbIndexType.DateTimeIndex);
        Dic.Add("DateTimePeriodIndex", DbIndexType.DateTimePeriodIndex);
        Dic.Add("NumberIndex", DbIndexType.NumberIndex);
        Dic.Add("QuantityIndex", DbIndexType.QuantityIndex);
        Dic.Add("QuantityRangeIndex", DbIndexType.QuantityRangeIndex);
        Dic.Add("ReferenceIndex", DbIndexType.ReferenceIndex);
        Dic.Add("StringIndex", DbIndexType.StringIndex);
        Dic.Add("TokenIndex", DbIndexType.TokenIndex);
        Dic.Add("UriIndex", DbIndexType.UriIndex);
        return Dic;
      }
    }

  }
}

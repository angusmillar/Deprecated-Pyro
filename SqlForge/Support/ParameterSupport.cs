using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SqlForge.Support
{
  public static class ParameterSupport
  {
    public static object[] GetParameter(Dictionary<string,object> ParameterDic)
    {
      List<SqlParameter> oParameterList = new List<SqlParameter>();
      foreach(var item in ParameterDic)
      {
        if (item.Value is bool)
        {
          oParameterList.Add(new SqlParameter(item.Key, (bool)item.Value));
        }
        else if (item.Value is int)
        {
          oParameterList.Add(new SqlParameter(item.Key, (int)item.Value));
        }
        else if (item.Value is double)
        {
          oParameterList.Add(new SqlParameter(item.Key, (double)item.Value));
        }
        else if (item.Value is DateTimeOffset)
        {
          oParameterList.Add(new SqlParameter(item.Key, (DateTimeOffset)item.Value));
        }
        else if (item.Value is DateTime)
        {
          oParameterList.Add(new SqlParameter(item.Key, (DateTime)item.Value));
        }
        else if (item.Value is String)
        {
          oParameterList.Add(new SqlParameter(item.Key, (String)item.Value));
        }
        else
          throw new InvalidCastException("Internal server error: No implementation in  ParameterSupport.GetParameter to cast to type that was given");
      }
      return oParameterList.ToArray();
    }
  }
}

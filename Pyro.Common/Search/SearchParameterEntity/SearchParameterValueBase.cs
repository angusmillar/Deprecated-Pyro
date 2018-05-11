using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.Search.SearchParameterEntity
{
  public abstract class SearchParameterValueBase
  {
    public bool IsMissing { get; set; }
    public bool? ParseModifierEqualToMissing(string Value)
    {
      bool TempBool = false;
      if (Boolean.TryParse(Value, out TempBool))
      {
        return TempBool;
      }
      else
      {
        return null;
      }
    }
  }
}

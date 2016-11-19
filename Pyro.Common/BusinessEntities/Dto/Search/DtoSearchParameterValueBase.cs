using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.BusinessEntities.Search
{
  public abstract class DtoSearchParameterValueBase
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

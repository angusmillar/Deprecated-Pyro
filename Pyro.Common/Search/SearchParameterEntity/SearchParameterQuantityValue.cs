using System;
using System.Collections.Generic;
using System.Linq;
using Pyro.Common.Enum;

namespace Pyro.Common.Search.SearchParameterEntity
{
  public class SearchParameterQuantityValue : SearchParameterValueWithPrefix
  {
    public string System { get; set; }
    public string Code { get; set; }

    public int Precision { get; set; }
    public int Scale { get; set; }
    public decimal Value { get; set; }
  }
}

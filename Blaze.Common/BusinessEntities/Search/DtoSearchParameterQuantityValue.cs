using System;
using System.Collections.Generic;
using System.Linq;
using Blaze.Common.Enum;

namespace Blaze.Common.BusinessEntities.Search
{
  public class DtoSearchParameterQuantityValue : DtoSearchParameterValueWithPrefix
  {    
    public string System { get; set; }
    public string Code { get; set; }

    public int Precision { get; set; }
    public int Scale { get; set; }
    public decimal Value { get; set; }        
  }
}

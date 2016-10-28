using System;
using System.Collections.Generic;
using System.Linq;
using Pyro.Common.Enum;

namespace Pyro.Common.BusinessEntities.Search
{
  public class DtoSearchParameterNumberValue : DtoSearchParameterValueWithPrefix
  {
    //Example: 
    //if Value = 10.005
    //then
    //  Precision = 5
    //  Scale = 3 
    public int Precision { get; set; }
    public int Scale { get; set; }
    public decimal Value { get; set; }        
  }
}

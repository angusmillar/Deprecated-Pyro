using System;
using System.Collections.Generic;
using System.Linq;
using Blaze.Common.Enum;

namespace Blaze.Common.BusinessEntities.Search
{
  public class DtoSearchParameterNumberValue : DtoSearchParameterValueWithPrefix
  {    
    public double Value { get; set; }        
  }
}

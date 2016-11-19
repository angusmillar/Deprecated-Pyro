using System;
using System.Collections.Generic;
using System.Linq;
using Pyro.Common.Enum;

namespace Pyro.Common.BusinessEntities.Search
{
  public class DtoSearchParameterDateValue : DtoSearchParameterValueWithPrefix
  {
    public int Value { get; set; }
  }
}

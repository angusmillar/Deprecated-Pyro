using System;
using System.Collections.Generic;
using System.Linq;
using Pyro.Common.Tools;

namespace Pyro.Common.Search.SearchParameterEntity
{
  public class SearchParameterDateTimeValue : SearchParameterValueWithPrefix
  {
    public FhirDateTimeSupport.DateTimePrecision Precision { get; set; }
    public DateTimeOffset Value { get; set; }
  }
}

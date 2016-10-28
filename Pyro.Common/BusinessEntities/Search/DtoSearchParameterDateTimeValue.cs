using System;
using System.Collections.Generic;
using System.Linq;
using Pyro.Common.Tools;

namespace Pyro.Common.BusinessEntities.Search
{
  public class DtoSearchParameterDateTimeValue : DtoSearchParameterValueWithPrefix
  {
    public FhirDateTimeSupport.DateTimePrecision Precision { get; set; }
    public DateTimeOffset Value { get; set; }
  }
}

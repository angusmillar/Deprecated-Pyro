using System;
using System.Collections.Generic;
using System.Linq;
using Blaze.Common.Tools;

namespace Blaze.Common.BusinessEntities.Search
{
  public class DtoSearchParameterDateTimeValue : DtoSearchParameterValueWithPrefix
  {
    public FhirDateTimeSupport.DateTimePrecision Precision { get; set; }
    public DateTimeOffset Value { get; set; }
  }
}

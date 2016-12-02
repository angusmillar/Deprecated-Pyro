using System;
using System.Collections.Generic;
using Hl7.Fhir.Rest;

namespace Pyro.Common.Interfaces.Dto
{
  public interface IDtoSearchParameterGeneric
  {
    int? Count { get; }
    IList<Tuple<string, string>> ParameterList { get; set; }
    IList<Tuple<string, SortOrder>> Sort { get; }
  }
}
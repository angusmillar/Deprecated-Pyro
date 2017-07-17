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
    SummaryType? SummaryType { get; }
    IDtoSearchParameterGeneric Parse(Hl7.Fhir.Rest.SearchParams SearchParams);
    IDtoSearchParameterGeneric Parse(string SearchParameterString);
    IList<Tuple<string, string>> Include { get; set; }
    IList<Tuple<string, string>> RevInclude { get; set; }
  }
}
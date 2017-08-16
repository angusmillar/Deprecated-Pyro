using System;
using System.Collections.Generic;
using Hl7.Fhir.Rest;

namespace Pyro.Common.Search
{
  public interface ISearchParameterGeneric
  {
    int? Count { get; }
    IList<Tuple<string, string>> ParameterList { get; set; }
    IList<Tuple<string, SortOrder>> Sort { get; }
    SummaryType? SummaryType { get; }
    ISearchParameterGeneric Parse(Hl7.Fhir.Rest.SearchParams SearchParams);
    ISearchParameterGeneric Parse(string SearchParameterString);
    IList<Tuple<string, string>> Include { get; set; }
    IList<Tuple<string, string>> RevInclude { get; set; }
  }
}
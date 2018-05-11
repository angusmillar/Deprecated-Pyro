using System.Collections.Generic;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Pyro.Common.Search.SearchParameterEntity;

namespace Pyro.Common.Search
{
  public class PyroSearchParameters
  {
    public FHIRAllTypes? ResourceTarget { get; set; }
    public List<ISearchParameterBase> SearchParametersList { get; set; }
    public List<SearchParameterInclude> IncludeList { get; set; }
    public List<UnspportedSearchParameter> UnspportedSearchParameterList { get; set; }
    public List<Sort> SortList { get; set; }
    public int RequiredPageNumber { get; set; }
    public int? CountOfRecordsRequested { get; set; }
    public string Format { get; set; }
    public SummaryType? SummaryType { get; set; }
    
    public PyroSearchParameters()
    {
      this.SummaryType = null;
    }

    public class Sort
    {
      public DtoServiceSearchParameterLight Value { get; set; }
      public Hl7.Fhir.Rest.SortOrder SortOrderType { get; set; }
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.BusinessEntities.Dto;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Utility;
using Pyro.Common.Search;

namespace Pyro.Common.Search
{
  public class PyroSearchParameters
  {
    public FHIRAllTypes? ResourceTarget { get; set; }
    public List<ISearchParameterBase> SearchParametersList { get; set; }
    public List<SearchParameterInclude> IncludeList { get; set; }
    public List<SearchParameterInclude> RevIncludeList { get; set; }
    public List<UnspportedSearchParameter> UnspportedSearchParameterList { get; set; }
    public List<Sort> SortList { get; set; }
    public int RequiredPageNumber { get; set; }
    public int? CountOfRecordsRequested { get; set; }
    public string Format { get; set; }
    public SummaryType? SummaryType { get; set; }
    public Uri SupportedSearchUrl(string RequestPrimaryServiceRoot)
    {
      string UrlString = RequestPrimaryServiceRoot;
      if (ResourceTarget.HasValue)
        UrlString = $"{UrlString}/{ResourceTarget.GetLiteral()}";
      bool FirstParameter = true;
      if ((SearchParametersList != null && SearchParametersList.Any()) || (IncludeList != null && IncludeList.Any()))
      {
        UrlString += "?";
      }

      for (int i = 0; i < SearchParametersList.Count; i++)
      {
        if (FirstParameter)
          UrlString += $"{SearchParametersList[i].RawValue}";
        else
          UrlString += $"&{UrlString}{SearchParametersList[i].RawValue}";
        FirstParameter = false;
      }
      if (IncludeList != null)
      {
        for (int i = 0; i < IncludeList.Count; i++)
        {
          if (FirstParameter)
            UrlString += $"{IncludeList[i].AsFormatedSearchParameter()}";
          else
            UrlString += $"&{IncludeList[i].AsFormatedSearchParameter()}";
          FirstParameter = false;
        }
      }
      try
      {
        var Uri = new Uri(UrlString, UriKind.Absolute);
        return Uri;
      }
      catch (UriFormatException)
      {
        return null;
      }
    }

    public PyroSearchParameters()
    {
      this.SummaryType = null;
    }

    public class Sort
    {
      public ServiceSearchParameterLight Value { get; set; }
      public Hl7.Fhir.Rest.SortOrder SortOrderType { get; set; }
    }
  }
}

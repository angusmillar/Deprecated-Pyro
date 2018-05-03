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
    public List<UnspportedSearchParameter> UnspportedSearchParameterList { get; set; }
    public List<Sort> SortList { get; set; }
    public int RequiredPageNumber { get; set; }
    public int? CountOfRecordsRequested { get; set; }
    public string Format { get; set; }
    public SummaryType? SummaryType { get; set; }
    public Uri SupportedSearchUrl(string RequestPrimaryServiceRoot, string Container = "", string ContainerId = "")
    {
      string UrlString = RequestPrimaryServiceRoot;
      if (!string.IsNullOrWhiteSpace(Container) && !string.IsNullOrWhiteSpace(ContainerId))
      {
        if (ResourceTarget.HasValue)
          UrlString = $"{UrlString}/{Container}/{ContainerId}/{ResourceTarget.GetLiteral()}";
      }
      else
      {
        if (ResourceTarget.HasValue)
          UrlString = $"{UrlString}/{ResourceTarget.GetLiteral()}";
      }
      
      bool FirstParameter = true;
      if ((SearchParametersList != null && SearchParametersList.Any()) || (IncludeList != null && IncludeList.Any() || RequiredPageNumber > 0 || SummaryType.HasValue))
      {
        UrlString += "?";
      }

      for (int i = 0; i < SearchParametersList.Count; i++)
      {
        if (SearchParametersList[i] is SearchParameterReferance SearchParameterReferance && SearchParameterReferance.IsChained)
        {
          ////Chained parameters
          string temp = SearchParameterReferance.RawValue;
          foreach (var Chain in SearchParameterReferance.ChainedSearchParameterList)
          {
            temp += Chain.RawValue;
          }
          if (FirstParameter)
            UrlString += $"{temp}";
          else
            UrlString += $"&{UrlString}{temp}";
          FirstParameter = false;
        }
        else
        {
          //Normal parameters
          if (FirstParameter)
            UrlString += $"{SearchParametersList[i].RawValue}";
          else
            UrlString += $"&{SearchParametersList[i].RawValue}";
          FirstParameter = false;
        }
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
      if (RequiredPageNumber > 0)
      {
        if (FirstParameter)
          UrlString += $"page={RequiredPageNumber.ToString()}";
        else
          UrlString += $"&page={RequiredPageNumber.ToString()}";
      }
      if (SummaryType.HasValue)
      {
        if (FirstParameter)
          UrlString += $"_summary={SummaryType.Value.GetLiteral()}";
        else
          UrlString += $"&_summary={SummaryType.Value.GetLiteral()}";
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

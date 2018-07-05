using System;
using System.Collections.Generic;
using System.Linq;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.Global;
using Pyro.Common.Search;
using Pyro.Common.Search.SearchParameterEntity;

namespace Pyro.Common.Tools.Paging
{
  public class PagingSupport : IPagingSupport
  {
    private readonly IGlobalProperties IGlobalProperties;

    public PagingSupport(IGlobalProperties IGlobalProperties)
    {
      this.IGlobalProperties = IGlobalProperties;
    }

    public int GetFirstPageNumber()
    {
      return 1;
    }

    public int GetLastPageNumber(int PagesTotal)
    {
      return PagesTotal;
    }

    public int? GetNextPageNumber(int PageCurrentlyRequired, int PagesTotal)
    {
      if (PageCurrentlyRequired < 1)
        PageCurrentlyRequired = 1;
      if (PageCurrentlyRequired >= PagesTotal)
        return null;
      else
        return PageCurrentlyRequired + 1;
    }

    public int? GetPreviousPageNumber(int PageCurrentlyRequired, int PagesTotal)
    {
      if (PageCurrentlyRequired <= 1)
      {
        return null;
      }
      else if (PageCurrentlyRequired >= PagesTotal)
      {
        return PagesTotal - 1;
      }
      else
      {
        return PageCurrentlyRequired - 1;
      }
    }

    public Uri GetPageNavigationUriOLD(string RequestUriString, int NewPageNumber)
    {
      Uri RequestUri = new Uri(RequestUriString);
      if (RequestUri != null)
      {
        string PageParameterText = "page=";
        string CurrentPageNumber = string.Empty;
        int StartIndexOfPageParameter = RequestUri.Query.LastIndexOf(PageParameterText);
        if (StartIndexOfPageParameter > -1)
        {

          StartIndexOfPageParameter = StartIndexOfPageParameter + PageParameterText.Length;
          int EndIndexOfPageNumber = RequestUri.Query.IndexOf('&', StartIndexOfPageParameter, RequestUri.Query.Length - StartIndexOfPageParameter);
          if (EndIndexOfPageNumber < 0)
            EndIndexOfPageNumber = RequestUri.Query.Length;
          CurrentPageNumber = RequestUri.Query.Substring(StartIndexOfPageParameter, EndIndexOfPageNumber - StartIndexOfPageParameter);
          return new Uri(String.Format("{0}://{1}{2}{3}", RequestUri.Scheme, RequestUri.Authority, RequestUri.AbsolutePath, RequestUri.Query.Replace("page=" + CurrentPageNumber, "page=" + NewPageNumber.ToString())));
        }
        return new Uri(String.Format("{0}://{1}{2}{3}{4}{5}", RequestUri.Scheme, RequestUri.Authority, RequestUri.AbsolutePath, RequestUri.Query, "&", "page=" + NewPageNumber.ToString()));
      }
      return null;
    }

    public Uri GetPageNavigationUri(string RequestUriString, int? NewPageNumber)
    {
      //examples
      //http://localhost:8888/fhir/StructureDefinition
      //http://localhost:8888/fhir/StructureDefinition/?page=1
      //http://localhost:8888/fhir/StructureDefinition/?url=http://blabla.com/something&page=1
      //http://localhost:8888/fhir/StructureDefinition/?url=http://blabla.com/something&page=1&xyz=bla

      //If the page number is null then we don't need a link as we are currently at the end or the beginning
      if (!NewPageNumber.HasValue)
        return null;

      string PageParameterText = "page=";
      var RequestSplit = RequestUriString.Split('?');
      if (RequestSplit.Length > 1)
      {
        string Base = RequestSplit[0];
        RequestSplit[0] = string.Empty;
        string Query = String.Join("", RequestSplit);
        List<string> ParameterSplit = new List<string>(Query.Split('&'));
        var PageParameter = ParameterSplit.SingleOrDefault(x => x.StartsWith(PageParameterText));
        if (PageParameter != null)
        {
          Query = Query.Replace(PageParameter, $"{PageParameterText}{NewPageNumber.ToString()}");
          return new Uri($"{Base}?{Query}");
        }
        else
        {
          Query += $"&{PageParameterText}{NewPageNumber.ToString()}";
          return new Uri($"{Base}?{Query}");
        }
      }
      return new Uri($"{RequestUriString}?{PageParameterText}{NewPageNumber.ToString()}");
    }

    public int CalculatePageRequired(int RequiredPageNumber, int? CountOfRecordsRequested, int TotalRecordCount)
    {
      int NumberOfRecordsPerPage = SetNumberOfRecordsPerPage(CountOfRecordsRequested);

      if (TotalRecordCount == 0 || RequiredPageNumber < 1)
        return 1;

      int TotalPages = CalculateTotalPages(NumberOfRecordsPerPage, TotalRecordCount);
      if (RequiredPageNumber >= TotalPages)
      {
        return TotalPages;
      }
      else
      {
        return RequiredPageNumber;
      }
    }

    public int CalculateTotalPages(int? CountOfRecordsRequested, int TotalRecordCount)
    {
      int NumberOfRecordsPerPage = SetNumberOfRecordsPerPage(CountOfRecordsRequested);
      if (TotalRecordCount == 0 || NumberOfRecordsPerPage == 0)
        return 1;

      int TotalPages = (TotalRecordCount / NumberOfRecordsPerPage);
      if ((TotalRecordCount % NumberOfRecordsPerPage) == 0)
      {
        return TotalPages;
      }
      else
      {
        return TotalPages + 1;
      }
    }

    public void SetBundlePagnation(Bundle Bundle, string RequestUriString, int PagesTotal, int PageCurrentlyRequired, Uri SearchPerformedUri = null)
    {
      int LastPageNumber = this.GetLastPageNumber(PagesTotal);

      Bundle.FirstLink = this.GetPageNavigationUri(RequestUriString, this.GetFirstPageNumber());

      Bundle.LastLink = this.GetPageNavigationUri(RequestUriString, LastPageNumber);

      Uri Next = this.GetPageNavigationUri(RequestUriString, this.GetNextPageNumber(PageCurrentlyRequired, PagesTotal));
      if (Next != null)
        Bundle.NextLink = Next;

      Uri Previous = this.GetPageNavigationUri(RequestUriString, this.GetPreviousPageNumber(PageCurrentlyRequired, PagesTotal));
      if (Previous != null)
        Bundle.PreviousLink = Previous;

      if (SearchPerformedUri != null)
        Bundle.SelfLink = SearchPerformedUri;
    }

    public Uri GetSelfLink(PyroSearchParameters SearchParameters,string PrimaryServiceRoot, string Container = "", string ContainerId = "")
    {
      string UrlString = PrimaryServiceRoot;
      if (!string.IsNullOrWhiteSpace(Container) && !string.IsNullOrWhiteSpace(ContainerId))
      {
        if (SearchParameters.ResourceTarget.HasValue)
          UrlString = $"{UrlString}/{Container}/{ContainerId}/{SearchParameters.ResourceTarget.GetLiteral()}";
      }
      else
      {
        if (SearchParameters.ResourceTarget.HasValue)
          UrlString = $"{UrlString}/{SearchParameters.ResourceTarget.GetLiteral()}";
      }

      bool FirstParameter = true;
      if ((SearchParameters.SearchParametersList != null && SearchParameters.SearchParametersList.Any()) || 
        (SearchParameters.IncludeList != null && SearchParameters.IncludeList.Any() || 
        SearchParameters.RequiredPageNumber > 0 || 
        SearchParameters.SummaryType.HasValue) ||
        SearchParameters.CountOfRecordsRequested.HasValue)
      {
        UrlString += "?";
      }

      for (int i = 0; i < SearchParameters.SearchParametersList.Count; i++)
      {
        if (SearchParameters.SearchParametersList[i] is SearchParameterReferance SearchParameterReferance && SearchParameterReferance.IsChained)
        {
          //Chained parameters         
          if (FirstParameter)
            UrlString += ResolveChainParameterString(SearchParameterReferance, string.Empty);
          else
            UrlString += $"&{ResolveChainParameterString(SearchParameterReferance, string.Empty)}";
          FirstParameter = false;
        }
        else
        {
          //Normal parameters
          if (FirstParameter)
            UrlString += $"{SearchParameters.SearchParametersList[i].RawValue}";
          else
            UrlString += $"&{SearchParameters.SearchParametersList[i].RawValue}";
          FirstParameter = false;
        }
      }
      if (SearchParameters.IncludeList != null)
      {
        for (int i = 0; i < SearchParameters.IncludeList.Count; i++)
        {
          if (FirstParameter)
            UrlString += $"{SearchParameters.IncludeList[i].AsFormatedSearchParameter()}";
          else
            UrlString += $"&{SearchParameters.IncludeList[i].AsFormatedSearchParameter()}";
          FirstParameter = false;
        }
      }
      if (SearchParameters.RequiredPageNumber > 0)
      {
        if (FirstParameter)
          UrlString += $"page={SearchParameters.RequiredPageNumber.ToString()}";
        else
          UrlString += $"&page={SearchParameters.RequiredPageNumber.ToString()}";
      }

      if (SearchParameters.CountOfRecordsRequested.HasValue)
      {        
        if (FirstParameter)
          UrlString += $"_count={SetNumberOfRecordsPerPage(SearchParameters.CountOfRecordsRequested).ToString()}";
        else
          UrlString += $"&_count={SetNumberOfRecordsPerPage(SearchParameters.CountOfRecordsRequested).ToString()}";
      }
      
      if (SearchParameters.SummaryType.HasValue)
      {
        if (FirstParameter)
          UrlString += $"_summary={SearchParameters.SummaryType.Value.GetLiteral()}";
        else
          UrlString += $"&_summary={SearchParameters.SummaryType.Value.GetLiteral()}";
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

    private string ResolveChainParameterString(ISearchParameterBase SearchParameter, string ParameterString)
    {
      if (SearchParameter.ChainedSearchParameter != null)
      {
        ParameterString += SearchParameter.RawValue;
        ParameterString = ResolveChainParameterString(SearchParameter.ChainedSearchParameter, ParameterString);
        return ParameterString;
      }
      else
      {
        ParameterString += SearchParameter.RawValue;
        return ParameterString;
      }
    }

    public int SetNumberOfRecordsPerPage(int? CountOfRecordsRequested)
    {
      if (CountOfRecordsRequested.HasValue)
      {
        if (CountOfRecordsRequested.Value <= IGlobalProperties.MaxNumberOfRecordsPerPage)
        {
          return CountOfRecordsRequested.Value;
        }
        else
        {
          return IGlobalProperties.MaxNumberOfRecordsPerPage;
        }
      }
      return IGlobalProperties.NumberOfRecordsPerPageDefault;
    }
  }
}

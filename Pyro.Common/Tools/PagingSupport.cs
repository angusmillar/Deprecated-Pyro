using System;
using System.Collections.Generic;
using System.Linq;
using Hl7.Fhir.Model;

namespace Pyro.Common.Tools
{
  public static class PagingSupport
  {
    public static int GetFirstPageNumber()
    {
      return 1;
    }

    public static int GetLastPageNumber(int PagesTotal)
    {
      return PagesTotal;
    }

    public static int? GetNextPageNumber(int PageCurrentlyRequired, int PagesTotal)
    {
      if (PageCurrentlyRequired < 1)
        PageCurrentlyRequired = 1;
      if (PageCurrentlyRequired >= PagesTotal)
        return null;
      else
        return PageCurrentlyRequired + 1;
    }

    public static int? GetPreviousPageNumber(int PageCurrentlyRequired, int PagesTotal)
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

    public static Uri GetPageNavigationUriOLD(string RequestUriString, int NewPageNumber)
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

    public static Uri GetPageNavigationUri(string RequestUriString, int? NewPageNumber)
    {
      //examples
      //http://localhost:8888/test/stu3/fhir/StructureDefinition
      //http://localhost:8888/test/stu3/fhir/StructureDefinition/?page=1
      //http://localhost:8888/test/stu3/fhir/StructureDefinition/?url=http://blabla.com/something&page=1
      //http://localhost:8888/test/stu3/fhir/StructureDefinition/?url=http://blabla.com/something&page=1&xyz=bla

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

    public static int CalculatePageRequired(int RequiredPageNumber, int NumberOfRecordsPerPage, int TotalRecordCount)
    {
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

    public static int CalculateTotalPages(int NumberOfRecordsPerPage, int TotalRecordCount)
    {
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

    public static void SetBundlePagnation(Bundle Bundle, string RequestUriString, int PagesTotal, int PageCurrentlyRequired, Uri SearchPerformedUri = null)
    {
      int LastPageNumber = PagingSupport.GetLastPageNumber(PagesTotal);

      Bundle.FirstLink = PagingSupport.GetPageNavigationUri(RequestUriString, PagingSupport.GetFirstPageNumber());

      Bundle.LastLink = PagingSupport.GetPageNavigationUri(RequestUriString, LastPageNumber);

      Uri Next = PagingSupport.GetPageNavigationUri(RequestUriString, PagingSupport.GetNextPageNumber(PageCurrentlyRequired, PagesTotal));
      if (Next != null)
        Bundle.NextLink = Next;

      Uri Previous = PagingSupport.GetPageNavigationUri(RequestUriString, PagingSupport.GetPreviousPageNumber(PageCurrentlyRequired, PagesTotal));
      if (Previous != null)
        Bundle.PreviousLink = Previous;

      if (SearchPerformedUri != null)
        Bundle.SelfLink = SearchPerformedUri;
    }
  }
}

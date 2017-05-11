using System;

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

    public static int GetNextPageNumber(int PageCurrentlyRequired, int PagesTotal)
    {
      if (PageCurrentlyRequired >= PagesTotal)
        return PagesTotal;
      else
        return PageCurrentlyRequired + 1;
    }

    public static int GetPreviousPageNumber(int PageCurrentlyRequired)
    {
      if (PageCurrentlyRequired == 1)
      {
        return PageCurrentlyRequired;
      }
      else
      {
        return PageCurrentlyRequired - 1;
      }
    }

    public static Uri GetPageNavigationUri(string RequestUriString, int NewPageNumber)
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
  }
}

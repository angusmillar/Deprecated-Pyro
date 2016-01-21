using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Engine.Support
{
  public static class PagingSupport
  {
    public static int GetFirstPageNumber()
    {
      return 1;
    }

    public static int GetLastPageNumber(int NumberOfRecordsPerPage, int TotalNumberOfRecords)
    {
      return (TotalNumberOfRecords / NumberOfRecordsPerPage) + 1;
    }

    public static int GetNextPageNumber(int PageCurrentlyRequired, int LastPageNumber)
    {
      if ((PageCurrentlyRequired + 1) > LastPageNumber)
        return LastPageNumber;
      else
        return PageCurrentlyRequired + 1;
    }

    public static int GetPreviousPageNumber(int PageCurrentlyRequired, int LastPageNumber)
    {
      if ((PageCurrentlyRequired - 1) < 1)
        return 1;
      if ((PageCurrentlyRequired - 1) > LastPageNumber)
        return LastPageNumber;
      else
        return PageCurrentlyRequired - 1;
    }

    public static Uri GetPageNavigationUri(Uri RequestUri, int NewPageNumber)
    {
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

  }
}

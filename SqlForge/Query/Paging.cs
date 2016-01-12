using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlForge.Support;

namespace SqlForge.Query
{
  public class Paging : StatmentBase
  {
    public int PageNumber { get; private set; }
    public int RowsPerPage { get; private set; }

    public Paging(int PageNumber, int RowsPerPage)
    {
      this.ResetCache();
      this.PageNumber = PageNumber;
      this.RowsPerPage = RowsPerPage;
    }

    public override string GetStatment()
    {
      if (this.CachedStatment != string.Empty)
        return this.CachedStatment;

      if (this.PageNumber == 0)
        throw new ArgumentException("PageNumber cannot be zero when requesting Page.");

      if (this.RowsPerPage == 0)
        throw new ArgumentException("RowsPerPage cannot be zero when calling Paging for SqlQueryForge.");

      int OffsetInteger = (this.PageNumber - 1) * this.RowsPerPage;
      var Statment = new StringBuilder();

      //Example:
      //OFFSET ((@PageNumber - 1) * @RowspPage) ROWS
      //FETCH NEXT @RowspPage ROWS ONLY;

      Statment.Offset().Space().Append(OffsetInteger.ToString()).Space().Rows().Space();
      Statment.Fetch().Space().Next().Space().Append(this.RowsPerPage).Space().Rows().Space().Only();

      Statment.NewLine();
      this.CachedStatment = Statment.ToString();
      return this.CachedStatment;
    }

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

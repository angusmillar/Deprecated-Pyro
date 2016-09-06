using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.DataModel.Support
{
  public static class PaginationSupport
  {
    public static int CalculatePageRequired(int RequiredPageNumber, int NumberOfRecordsPerPage, int TotalRecordCount)
    {
      //requiredPage = 1
      //NumberPerPage = 10
      //totalRecords = 100

      //Skip how many
      //take how many
      if (TotalRecordCount == 0 || RequiredPageNumber < 1)
        return 0;

      int TotalPages = CalculateTotalPages(NumberOfRecordsPerPage, TotalRecordCount);
      if ((RequiredPageNumber - 1) > TotalPages)
      {
        return TotalPages;
      }
      else
      {
        return RequiredPageNumber - 1;
      }
      

    }

    public static int CalculateTotalPages(int NumberOfRecordsPerPage, int TotalRecordCount)
    {
      if (TotalRecordCount == 0 || NumberOfRecordsPerPage == 0)
        return 0;

      int TotalPages = (TotalRecordCount / NumberOfRecordsPerPage);
      if ((TotalRecordCount % NumberOfRecordsPerPage) == 0)
      {
        return TotalPages + 1;
      }
      else
      {
        return TotalPages;
      }
    }
  }
}

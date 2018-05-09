using System;
using Hl7.Fhir.Model;
using Pyro.Common.Search;

namespace Pyro.Common.Tools.Paging
{
  public interface IPagingSupport
  {
    int CalculatePageRequired(int RequiredPageNumber, int? CountOfRecordsRequested, int TotalRecordCount);
    int CalculateTotalPages(int? CountOfRecordsRequested, int TotalRecordCount);
    int GetFirstPageNumber();
    int GetLastPageNumber(int PagesTotal);
    int? GetNextPageNumber(int PageCurrentlyRequired, int PagesTotal);
    Uri GetPageNavigationUri(string RequestUriString, int? NewPageNumber);
    Uri GetPageNavigationUriOLD(string RequestUriString, int NewPageNumber);
    int? GetPreviousPageNumber(int PageCurrentlyRequired, int PagesTotal);
    Uri GetSelfLink(PyroSearchParameters SearchParameters, string PrimaryServiceRoot, string Container = "", string ContainerId = "");
    void SetBundlePagnation(Bundle Bundle, string RequestUriString, int PagesTotal, int PageCurrentlyRequired, Uri SearchPerformedUri = null);
    int SetNumberOfRecordsPerPage(int? CountOfRecordsRequested);
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace Dip.Interfaces
{
  public interface IDatabaseSearchResult
  {
    string ErrorMessage { get; set; }
    bool HasDbError { get; set; }
    int NumberOfRecordsPerPage { get; set; }
    int PageRequested { get; set; }
    DtoResource ResourceMatchingSearch { get; set; }
    int ResourcesMatchingSearchCount { get; set; }
    List<DtoResource> ResourcesMatchingSearchList { get; set; }
  }
}

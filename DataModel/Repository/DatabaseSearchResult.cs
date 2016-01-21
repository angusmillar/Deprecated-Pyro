using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;


namespace DataModel.Repository
{
  public class DatabaseSearchResult : Dip.Interfaces.IDatabaseSearchResult
  {
    public List<DtoResource> ResourcesMatchingSearchList { get; set; }
    public DtoResource ResourceMatchingSearch { get; set; }
    public int ResourcesMatchingSearchCount { get; set; }
    public int PageRequested { get; set; }
    public int NumberOfRecordsPerPage { get; set; }
    public bool HasDbError { get; set; }
    public string ErrorMessage { get; set; }

    public DatabaseSearchResult()
    {
      this.HasDbError = false;
    }
  }
}

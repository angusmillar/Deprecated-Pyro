using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.BusinessEntities;
using System.Net;
namespace Common.Interfaces
{
  public interface IDatabaseOperationOutcome
  {
    
    int NumberOfRecordsPerPage { get; set; }
    int PageRequested { get; set; }    
    int ResourcesMatchingSearchCount { get; set; }
    List<DtoResource> ResourcesMatchingSearchList { get; set; }
    
    bool SingleResourceRead { get; set; }
    DtoResource ResourceMatchingSearch { get; set; }
    bool RecourceFoundDeleted { get; set; }
    int DeletedResourceVersionNumber { get; set; }
  }
}

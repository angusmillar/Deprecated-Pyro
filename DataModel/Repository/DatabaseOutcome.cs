using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.BusinessEntities;


namespace DataModel.Repository
{
  public class DatabaseOperationOutcome : Common.Interfaces.IDatabaseOperationOutcome
  {    
    public List<DtoResource> ResourcesMatchingSearchList { get; set; }    
    public int ResourcesMatchingSearchCount { get; set; }
    public int PageRequested { get; set; }
    public int NumberOfRecordsPerPage { get; set; }

    public bool SingleResourceRead { get; set; }
    public DtoResource ResourceMatchingSearch { get; set; }
    public bool RecourceFoundDeleted { get; set; }
    public int DeletedResourceVersionNumber { get; set; }

    public DatabaseOperationOutcome()
    {
      this.RecourceFoundDeleted = false;
      this.DeletedResourceVersionNumber = 0;
      SingleResourceRead = false;
    }
  }
}

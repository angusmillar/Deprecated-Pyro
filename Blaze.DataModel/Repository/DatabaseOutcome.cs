using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.Common.BusinessEntities.Dto;


namespace Blaze.DataModel.Repository
{
  public class DatabaseOperationOutcome : Blaze.Common.Interfaces.IDatabaseOperationOutcome
  {    
    public List<DtoResource> ResourcesMatchingSearchList { get; set; }    
    public int ResourcesMatchingSearchCount { get; set; }
    public int PageRequested { get; set; }
    public int NumberOfRecordsPerPage { get; set; }

    public bool SingleResourceRead { get; set; }
    public DtoResource ResourceMatchingSearch { get; set; }
    public bool RecourceIsDeleted { get; set; }
    public int ResourceVersionNumber { get; set; }

    public DatabaseOperationOutcome()
    {
      this.RecourceIsDeleted = false;
      this.ResourceVersionNumber = 0;
      SingleResourceRead = false;
    }
  }
}

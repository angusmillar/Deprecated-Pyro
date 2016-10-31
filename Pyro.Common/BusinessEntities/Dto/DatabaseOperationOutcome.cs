using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.BusinessEntities.Dto;


namespace Pyro.Common.BusinessEntities.Dto
{
  public class DatabaseOperationOutcome : Pyro.Common.Interfaces.IDatabaseOperationOutcome
  {
    public List<DtoResource> ReturnedResourceList { get; set; }
    public int ReturnedResourceCount { get; set; }
    public int PageRequested { get; set; }
    public int PagesTotal { get; set; }
    //public int NumberOfRecordsPerPage { get; set; }

    public bool SingleResourceRead { get; set; }
    public DtoResource ReturnedResource { get; set; }
    public bool RecourceIsDeleted { get; set; }
    public int ResourceVersionNumber { get; set; }

    internal DatabaseOperationOutcome()
    {
      this.RecourceIsDeleted = false;
      this.ResourceVersionNumber = 0;
      SingleResourceRead = false;
    }
  }
}

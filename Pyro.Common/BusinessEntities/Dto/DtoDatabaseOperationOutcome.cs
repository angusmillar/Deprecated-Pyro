using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.BusinessEntities.Dto
{
  class DtoDatabaseOperationOutcome : Pyro.Common.Interfaces.IDatabaseOperationOutcome
  {
    public List<DtoResource> ReturnedResourceList { get; set; }
    public int SearchTotal { get; set; }
    public int PageRequested { get; set; }
    public int PagesTotal { get; set; }

    public bool SingleResourceRead { get; set; }
    public bool RecourceIsDeleted { get; set; }
    public int ResourceVersionNumber { get; set; }

    internal DtoDatabaseOperationOutcome()
    {
      this.ReturnedResourceList = new List<DtoResource>();
      this.RecourceIsDeleted = false;
      this.ResourceVersionNumber = 0;
      SingleResourceRead = false;
    }
  }
}

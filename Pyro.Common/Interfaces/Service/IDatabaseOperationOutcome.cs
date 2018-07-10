using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.DtoEntity;
using System.Net;
using Pyro.Common.Service.Trigger;

namespace Pyro.Common.Interfaces.Service
{
  public interface IDatabaseOperationOutcome
  {
    int SearchTotal { get; set; }
    int PageRequested { get; set; }
    int PagesTotal { get; set; }
    List<DtoResource> ReturnedResourceList { get; set; }
    bool SingleResourceRead { get; set; }
    ITriggerOutcome TriggerOutCome { get; set; }
  }
}

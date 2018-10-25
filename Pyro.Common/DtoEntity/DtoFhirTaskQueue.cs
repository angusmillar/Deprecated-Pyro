using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.DtoEntity
{
  public class DtoFhirTaskQueue : DtoConfigEntityBase
  {
    public string TaskFhirId { get; set; }
    public string TaskType { get; set; }
    public string PerfomrerConnectionId { get; set; }
    public string Status { get; set; }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.DataLayer.DbModel.Entity
{
  public class _FhirTaskWorker : ConfigEntityBase
  {    
    public string TaskType { get; set; }
    public string ClaimedBy { get; set; }    
  }
}

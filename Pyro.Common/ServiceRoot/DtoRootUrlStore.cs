using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.ServiceRoot
{
  public class DtoRootUrlStore : DtoEntity.DtoConfigEntityBase, IDtoRootUrlStore
  {    
    public string Url { get; set; }
    public bool IsServersPrimaryUrlRoot { get; set; }   
  }
}

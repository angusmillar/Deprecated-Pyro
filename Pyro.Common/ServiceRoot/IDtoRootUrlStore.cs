using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.ServiceRoot
{
  public interface IDtoRootUrlStore
  {    
    int Id { get; set; }
    string Url { get; set; }        
    bool IsServersPrimaryUrlRoot { get; set; }
    DateTime CreatedDate { get; set; }
    string CreatedUser { get; set; }
    DateTime LastUpdated { get; set; }
    string LastUpdatedUser { get; set; }
  }
}

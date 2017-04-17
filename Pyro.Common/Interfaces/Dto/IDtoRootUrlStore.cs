using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.Interfaces.Dto
{
  public interface IDtoRootUrlStore
  {    
    int Id { get; set; }
    string Url { get; set; }    
    Uri RootUri { get; }
    bool IsServersPrimaryUrlRoot { get; set; }
  }
}

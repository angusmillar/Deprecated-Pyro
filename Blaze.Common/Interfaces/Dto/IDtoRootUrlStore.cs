using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Common.Interfaces.Dto
{
  public interface IDtoRootUrlStore
  {
    int ServiceRootUrlStoreID { get; set; }
    string RootUrl { get; set; }
    bool IsServersPrimaryUrlRoot { get; set; }
  }
}

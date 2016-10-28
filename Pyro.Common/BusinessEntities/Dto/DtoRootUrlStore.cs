using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Interfaces.Dto;

namespace Pyro.Common.BusinessEntities.Dto
{
  public class DtoRootUrlStore : IDtoRootUrlStore
  {
    public int ServiceRootUrlStoreID { get; set; }
    public string RootUrl { get; set; }
    public bool IsServersPrimaryUrlRoot { get; set; }
  }
}

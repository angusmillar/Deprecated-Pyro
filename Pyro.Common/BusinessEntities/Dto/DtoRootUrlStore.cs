using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.Common.Interfaces.Dto;

namespace Blaze.Common.BusinessEntities.Dto
{
  public class DtoRootUrlStore : IDtoRootUrlStore
  {
    public int ServiceRootUrlStoreID { get; set; }
    public string RootUrl { get; set; }
    public bool IsServersPrimaryUrlRoot { get; set; }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.DataModel.DatabaseModel.Base
{
  public abstract class ResourceCurrentIndexBase : ResourceIndexBase
  {
    public abstract ICollection<ResourceIndexBase> History_List { get; set; }
  }
}

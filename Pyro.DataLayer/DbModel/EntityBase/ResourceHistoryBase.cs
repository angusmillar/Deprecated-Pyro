using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.DataLayer.DbModel.EntityBase
{
  public abstract class ResourceHistoryBase<ResourceCurrentType> : ResourceBase
    where ResourceCurrentType : ResourceBase
  {
    public virtual ResourceCurrentType Resource { get; set; }
  }
}

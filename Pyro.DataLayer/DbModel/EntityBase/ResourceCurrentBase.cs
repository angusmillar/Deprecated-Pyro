using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.DataLayer.DbModel.EntityBase
{
  public abstract class ResourceCurrentBase<ResourceCurrentType, ResourceHistoryType, ResourceIndexType> : ResourceBase
    where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceHistoryType, ResourceIndexType>
    where ResourceHistoryType : ResourceHistoryBase<ResourceCurrentType>
    where ResourceIndexType : ResourceIndexBase
  {
    public ICollection<ResourceHistoryType> HistoryList { get; set; }
    public ICollection<ResourceIndexType> IndexList { get; set; }

    public ResourceCurrentBase()
    {
      this.HistoryList = new HashSet<ResourceHistoryType>();
      this.IndexList = new HashSet<ResourceIndexType>();
    }
  }
}

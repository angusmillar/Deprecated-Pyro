using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.DataLayer.DbModel.EntityBase
{
  public abstract class ResourceCurrentBase<ResourceCurrentType, ResourceIndexType> : ResourceBase
    where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>    
    where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>
  {    
    public ICollection<ResourceIndexType> IndexList { get; set; }

    public ResourceCurrentBase()
    {   
      this.IndexList = new HashSet<ResourceIndexType>();
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.DataLayer.DbModel.EntityBase
{
  public abstract class ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType> :
    ResourceBase,
    IModelBase,
    IResourceBase,
    IResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
  {
    public ICollection<ResourceIndexBaseType> IndexList { get; set; }
    public ICollection<ResourceIndexStringType> IndexStringList { get; set; }

    public ResourceCurrentBase()
    {
      this.IndexList = new HashSet<ResourceIndexBaseType>();
      this.IndexStringList = new HashSet<ResourceIndexStringType>();
    }
  }
}

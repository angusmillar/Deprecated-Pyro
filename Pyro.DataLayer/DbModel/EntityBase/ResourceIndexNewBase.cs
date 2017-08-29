using Pyro.DataLayer.DbModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.DataLayer.DbModel.EntityBase
{
  public abstract class ResourceIndexNewBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType> :
    ModelBase,
    IResourceIndexNewBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
  {
    public ServiceSearchParameter ServiceSearchParameter { get; set; }
    public int ServiceSearchParameterId { get; set; }

    public virtual ResourceCurrentBaseType Resource { get; set; }
    public int ResourceId { get; set; }


  }
}

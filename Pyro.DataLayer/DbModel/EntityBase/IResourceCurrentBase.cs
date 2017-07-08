using System.Collections.Generic;

namespace Pyro.DataLayer.DbModel.EntityBase
{
  public interface IResourceCurrentBase<ResourceCurrentType, ResourceIndexType>
    where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>
    where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>
  {
    ICollection<ResourceIndexType> IndexList { get; set; }
  }
}
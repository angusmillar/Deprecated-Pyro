using Pyro.DataLayer.DbModel.Entity;

namespace Pyro.DataLayer.DbModel.EntityBase
{
  public interface IResourceIndexNewBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
  {
    ResourceCurrentBaseType Resource { get; set; }
    int ResourceId { get; set; }

    ServiceSearchParameter ServiceSearchParameter { get; set; }
    int ServiceSearchParameterId { get; set; }
  }
}
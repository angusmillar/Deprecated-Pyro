namespace Pyro.DataLayer.DbModel.EntityBase
{
  public interface IResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType> :
    IResourceIndexNewBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
  {
    string String { get; set; }
  }
}
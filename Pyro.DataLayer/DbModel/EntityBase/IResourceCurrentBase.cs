﻿using System.Collections.Generic;

namespace Pyro.DataLayer.DbModel.EntityBase
{
  public interface IResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
  {
    ICollection<ResourceIndexBaseType> IndexList { get; set; }
    ICollection<ResourceIndexStringType> IndexStringList { get; set; }
  }
}
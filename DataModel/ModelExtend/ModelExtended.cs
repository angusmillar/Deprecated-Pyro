using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.ModelExtend
{
  public static class ModelExtended
  {
    public static BusinessEntities.DtoResource GetDto(this Model.Resource Resource)
    {
      if (Resource == null)
        return null;
      var oDtoResource = new BusinessEntities.DtoResource()
      {
        Id = Resource.Id,
        IsCurrent = Resource.IsCurrent,
        IsDeleted = Resource.IsDeleted,
        Received = Resource.Received,
        Version = Resource.Version,
        Xml = Resource.Xml
      };
      return oDtoResource;
    }
  }
}

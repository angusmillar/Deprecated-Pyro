using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Common.Tools.UriSupport;
using Pyro.DataLayer.DbModel.EntityGenerated;
using Pyro.DataLayer.DbModel.EntityBase;
using Pyro.DataLayer.Repository;
//using Pyro.DataModel.IndexSetter;


namespace Pyro.DataLayer.Support
{
  public static class IndexSettingSupport
  {

    private static void SetResourceBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Resource Resource, ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType> ResourceCurrentBase, string FhirResourceId, string Version, bool IsDeleted, Bundle.HTTPVerb Method)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      ResourceCurrentBase.IsDeleted = IsDeleted;
      ResourceCurrentBase.VersionId = Version;
      ResourceCurrentBase.Method = Method;
      if (!IsDeleted)
      {
        ResourceCurrentBase.FhirId = Resource.Id;
        ResourceCurrentBase.XmlBlob = Hl7.Fhir.Serialization.FhirSerializer.SerializeResourceToXml(Resource);
        ResourceCurrentBase.LastUpdated = (DateTimeOffset)Resource.Meta.LastUpdated;
      }
      else
      {
        ResourceCurrentBase.FhirId = FhirResourceId;
        ResourceCurrentBase.XmlBlob = "";
        ResourceCurrentBase.LastUpdated = DateTimeOffset.Now;
      }
    }

    public static DtoResource SetDtoResource<ResourceBaseType>(ResourceBaseType ResourceBase, FHIRAllTypes ResourceType)
      where ResourceBaseType : ResourceBase
    {
      var DtoResource = new DtoResource();

      DtoResource.FhirId = ResourceBase.FhirId;
      DtoResource.IsCurrent = ResourceBase.IsCurrent;
      DtoResource.IsDeleted = ResourceBase.IsDeleted;
      DtoResource.Received = ResourceBase.LastUpdated;
      DtoResource.Version = ResourceBase.VersionId;
      DtoResource.Xml = ResourceBase.XmlBlob;
      DtoResource.Method = ResourceBase.Method;
      DtoResource.ResourceType = ResourceType;
      return DtoResource;
    }

    public static void SetResourceBaseAsDelete<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType> ResourceCurrentBase, string FhirResourceId, string Version, Bundle.HTTPVerb Method)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      SetResourceBase(null, ResourceCurrentBase, FhirResourceId, Version, true, Method);
    }

    public static void SetResourceBaseAddOrUpdate<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Resource Resource, ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType> ResourceCurrentBase, string Version, bool IsDeleted, Bundle.HTTPVerb Method)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      SetResourceBase(Resource, ResourceCurrentBase, null, Version, false, Method);
    }

    public static void ResetResourceEntityBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType> ResourceCurrentBase)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      ResourceCurrentBase.IsCurrent = false;
      ResourceCurrentBase.FhirId = null;
      ResourceCurrentBase.IsDeleted = false;
      ResourceCurrentBase.LastUpdated = DateTimeOffset.MinValue;
      ResourceCurrentBase.Method = Bundle.HTTPVerb.GET;
      ResourceCurrentBase.VersionId = "Reset";
      ResourceCurrentBase.XmlBlob = null;
    }

    public static void SetHistoryResourceEntity<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType> ResourceCurrentBase, ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType> ResourceHistoryBase)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      ResourceHistoryBase.IsCurrent = false;
      ResourceHistoryBase.FhirId = ResourceCurrentBase.FhirId;
      ResourceHistoryBase.IsDeleted = ResourceCurrentBase.IsDeleted;
      ResourceHistoryBase.XmlBlob = ResourceCurrentBase.XmlBlob;
      ResourceHistoryBase.LastUpdated = ResourceCurrentBase.LastUpdated;
      ResourceHistoryBase.VersionId = ResourceCurrentBase.VersionId;
      ResourceHistoryBase.Method = ResourceCurrentBase.Method;
    }

  }
}
